 param (
    [Parameter(Mandatory=$true)][string]$role,
    [Parameter(Mandatory=$true)][string]$username
 )

$scriptDir = $(Split-Path -parent $MyInvocation.MyCommand.Definition)

function AssignRole {
param(
   [string] $role = 'edit',
   [string] $user = '',
   [string] $project = ''
   )

   write-host "Assigning role [$role], to user [$user], in project [$project] ..."
   oc policy add-role-to-user $role $user -n $project

   write-host ""
   write-host "Resulting policy bindings for; project [$project] ..."
   oc describe policyBindings --namespace=$project

   write-host ""
   write-host ""
}

AssignRole $role $username 'tran-schoolbus-tools'
AssignRole $role $username 'tran-schoolbus-dev'
AssignRole $role $username 'tran-schoolbus-test'
AssignRole $role $username 'tran-schoolbus-prod'

