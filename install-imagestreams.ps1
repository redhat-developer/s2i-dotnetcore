<#
.SYNOPSIS
    OpenShift .NET Core S2I Installer

.DESCRIPTION
    Install/Update/Remove .NET Core S2I streams.

.PARAMETER Namespace
    Namespace to add imagestreams to. Defaults to current 'oc' project.
    Set this to 'openshift' to install globally (requires admin priviledges).

.PARAMETER Remove
    Remove the image streams.

.LINK
    https://github.com/redhat-developer/s2i-dotnetcore

.EXAMPLE
    .\install-imagestreams

    Install image streams into the current OpenShift 'oc' project.

.EXAMPLE

    .\install-imagestreams -Remove

    Remove all image streams from the current OpenShift 'oc' project.
#>

[cmdletbinding()]
param(
   [Obsolete("The parameter is no longer used and may be omitted.")]
   [string]$OS=$null,
   [string]$Namespace=$null,
   [switch]$Remove=$false,
   [Obsolete("The parameter is no longer used and may be omitted.")]
   [string]$User=$null,
   [Obsolete("The parameter is no longer used and may be omitted.")]
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
        throw "Cannot delete ${arguments}: $stderr"
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
    OcDelete "secret redhat-registry-dotnet-install"

    exit
}

$imagestreams_url = "https://raw.githubusercontent.com/redhat-developer/s2i-dotnetcore/master/dotnet_imagestreams.json"

# Determine namespace
If (-not ($PSBoundParameters.ContainsKey("Namespace")))
{
    $Namespace = GetCurrentNamespace
}

# Install/update imagestreams
If (HasDotnetImagestreams)
{
    Say "Updating image streams:"
    ExecuteCheckSuccess "oc.exe" "replace -n $namespace -f $imagestreams_url"
}
Else
{
    Say "Installing image streams:"
    ExecuteCheckSuccess "oc.exe" "create -n $namespace -f $imagestreams_url"
}
