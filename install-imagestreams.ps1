<#
.SYNOPSIS
    OpenShift .NET Core S2I Installer
.DESCRIPTION
    Install/Update/Remove .NET Core S2I streams.
.PARAMETER OS
    Installs image streams based on this distro ('rhel7', 'rhel8', or 'centos7').
.PARAMETER Namespace
    Namespace to add imagestreams to. Defaults to current 'oc' project.
    Set this to 'openshift' to install globally (requires admin priviledges).
.PARAMETER Remove
    Remove the image streams.
.PARAMETER User
    Username for pulling images from the registry..
.PARAMETER Password
    Password for pulling images from the registry.
#>

# TODO how to make help work??
# What is consuming this stuff above?
# echo "OpenShift .NET Core S2I Installer"
# echo "Usage: $script_name --os <os>"
# echo "       $script_name --rm"
# echo "       $script_name -h|-?|--help"
# echo ""
# echo "$script_name is a script for installing/updating/removing .NET S2I streams."
# echo ""
# echo "Options:"
# echo "  --o,--os                           Installs image streams based on this distro ('rhel7', 'rhel8', or 'centos7')."
# echo "  --n,--namespace                    Namespace to add imagestreams to. Defaults to current 'oc' project."
# echo "                                     Set this to 'openshift' to install globally (requires admin priviledges)."
# echo "  --rm                               Remove the image streams."
# echo "  --u,--user                         Username for pulling images from the registry."
# echo "  --p,--password                     Password for pulling images from the registry."
# echo "  -?,--?,-h,--help                   Shows this help message."
# echo ""
# echo "Credentials are required for the pulling the rhel7 images. If the project does not contain a secret"
# echo "for pulling the images yet, you can add one by specifying the '--user' and '--password' options."
# echo "For more information see: https://access.redhat.com/articles/3399531."

[cmdletbinding()]
param(
   [string]$OS,
   [string]$Namespace=$null,
   [switch]$Remove=$false,
   [string]$User=$null,
   [string]$Password=$null
)

$pull_secret_name="redhat-registry-dotnet-install"

Set-StrictMode -Version Latest
$ErrorActionPreference="Stop"
$ProgressPreference="SilentlyContinue"

function Say($str)
{
    Write-Host "dotnet-install: $str"
}

function Execute([string] $filename, [string] $arguments)
{
    $psi = New-Object System.Diagnostics.ProcessStartInfo
    $psi.FileName = $filename
    $psi.Arguments = $arguments
    $psi.RedirectStandardError = $true
    $psi.RedirectStandardOutput = $true
    $psi.UseShellExecute = $false

    $p = New-Object System.Diagnostics.Process
    $p.StartInfo = $psi
    $p.Start() | Out-Null
    $stdout = $p.StandardOutput.ReadToEnd().trim()
    $stderr = $p.StandardError.ReadToEnd().trim()

    return $p.ExitCode, $stdout, $stderr
}

function ExecuteCheckSuccess([string] $filename, [string] $arguments)
{
    $exitcode,$stdout,$stderr = Execute $filename $arguments
    If ($exitcode -eq 0)
    {
        Write-Host $stdout
    }
    Else
    {
        throw $stderr
    }
}

function OcDelete([string] $arguments)
{
    $exitcode,$stdout,$stderr = Execute "oc.exe" "delete $arguments"

    If (($exitcode -eq 0) -or ($stderr -like '*NotFound*'))
    {
        return
    }
    Else
    {
        throw "Cannot delete $arguments : $stderr"
    }
}

function GetCurrentNamespace()
{
    $exitcode, $stdout, $stderr = Execute "oc.exe" "project -q"

    If ($exitcode -eq 0)
    {
        return $stdout.trim()
    }
    Else
    {
        throw "Cannot determine current oc namespace"
    }
}

function HasDotnetImagestreams()
{
    $exitcode, $stdout, $stderr = Execute "oc.exe" "get -n $Namespace is dotnet"

    If ($exitcode -ne 0)
    {
        Say $stderr
        If ($stderr -like '*NotFound*')
        {
            return $false
        }
        Else
        {
            throw "Cannot determine if the project already contains dotnet imagestreams."
        }
    }

    return $true
}

function HasSecretForRegistry()
{
    $exitcode, $stdout, $stderr = Execute "oc.exe" "get secret -o name -n $namespace"

    If ( $exitcode -ne 0 )
    {
        throw "Cannot retrieve secrets."
    }

    $secret_names = $stdout.Split("`n")
    foreach ($secret_name in $secret_names)
    {
        $exitcode, $stdout, $stderr = Execute "oc.exe" "get $secret_name -o json -n $namespace"
        $secret = ConvertFrom-Json $stdout
        $secret_type = $secret.type
        $data = $null
        switch ( $secret_type )
        {
            "kubernetes.io/dockercfg"
            {
                $data = $secret.data.".dockercfg"
            }
            "kubernetes.io/dockerconfigjson"
            {
                $data = $secret.data.".dockerconfigjson"
            }
        }
        If ( $data -ne $null )
        {
            $data = [Text.Encoding]::Utf8.GetString([Convert]::FromBase64String($data))
            If ( $data -like "*`"$registry`"*" )
            {
                return $true
            }
        }
    }

    return $false
}

# Check prerequisite tools
if ((Get-Command "oc.exe" -ErrorAction SilentlyContinue) -eq $null) 
{ 
   throw "Unable to find oc.exe on PATH. Please install oc."
}

# Remove
if($Remove.IsPresent)
{
    Say "Removing installed image streams."

    OcDelete "is dotnet"
    OcDelete "is dotnet-runtime"
    OcDelete "secret $pull_secret_name"

    exit
}

# The OS parameter is required.
switch ( $OS )
{
    "centos7"
    {
        $imagestreams_url = "https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams_centos.json"
        $registry_requires_auth = $false
    }
    "rhel7"
    {
        $imagestreams_url = "https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams.json"
        $registry_requires_auth = $true
        $registry="registry.redhat.io"
    }
    "rhel8"
    {
        $imagestreams_url = "https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams_rhel8.json"
        $registry_requires_auth = $false
    }
    default
    {
        throw "Unsupported value for --os: $OS. Valid values are 'centos7', 'rhel7', and 'rhel8'."
    }
}

$create_secret=[bool]$User

# Inform user he may need a pull secret
If (( $create_secret -eq $false) -and ($registry_requires_auth -eq $true))
{
    Say "note: The image streams for $OS require authentication against $registry. See '--help' for more info." # TODO: --help...
}

# Determine namespace
If (-not ($PSBoundParameters.ContainsKey("Namespace"))) # TODO: is this the proper way to check this?
{
    $Namespace = GetCurrentNamespace
}

# Create pull secret
If ( $create_secret -eq $true)
{
    If (HasSecretForRegistry)
    {
        Say "A secret for the registry is already present in the namespace."
    }
    Else
    {
        Say "Creating a secret for authenticating with $registry :"
        ExecuteCheckSuccess "oc.exe" "create secret docker-registry $pull_secret_name -n $namespace --docker-server=$registry --docker-username=$user --docker-password=$password --docker-email=unused"
        ExecuteCheckSuccess "oc.exe" "secrets link default $pull_secret_name --for=pull -n $namespace"
        ExecuteCheckSuccess "oc.exe" "secrets link builder $pull_secret_name -n $namespace"
    }
}

# Install/update imagestreams
If (HasDotnetImagestreams)
{
    Say "Updating image streams:"
    ExecuteCheckSuccess "oc.exe" "replace -n $namespace -f $imagestreams_url"
}
Else
{
    say "Installing image streams:"
    ExecuteCheckSuccess "oc.exe" "create -n $namespace -f $imagestreams_url"
}
