# ==============================================================================
# Script for taking down the OpenShift environment for the Schoolbus application
#
# * Requires the OpenShift Origin CLI
# ------------------------------------------------------------------------------
#
# USAGE:  
# projects_down
#
# ==============================================================================

function Confirm-Delete {
param(
   [string] $projectName = ''
  ,[bool] $defaultAnswer = $false
)
  if ($projectName -eq '') {return $false}

  $yes = '6'
  $no = '7'
  $msgBoxTimeout='-1'
  $defaultAnswerDisplay = 'Yes'
  $buttonType = 0x4;
  if (!$defaultAnswer) { $defaultAnswerDisplay = 'No'; $buttonType= 0x104;}

  $answer = $msgBoxTimeout
  try {
    $timeout = 10
    $question = "Are you sure you want to delete the $($projectName) project from OpenShift? Defaults to `'$defaultAnswerDisplay`' after $timeout seconds"
    $msgBox = New-Object -ComObject WScript.Shell
    $answer = $msgBox.Popup($question, $timeout, "Delete $projectName", $buttonType)
  }
  catch {
  }

  if ($answer -eq $yes -or ($answer -eq $msgBoxTimeout -and $defaultAnswer -eq $true)) {
    write-host "Deleting $projectName ..."
    return $true
  }

  write-host "Leaving $projectName ..."
  return $false
}

function Confirm-Server {
param(
  [bool] $defaultAnswer = $false
)
  $yes = '6'
  $no = '7'
  $msgBoxTimeout='-1'
  $defaultAnswerDisplay = 'Yes'
  $buttonType = 0x4;
  if (!$defaultAnswer) { $defaultAnswerDisplay = 'No'; $buttonType= 0x104;}

  $answer = $msgBoxTimeout
  try {
	$OpenShiftSession = oc project
    $timeout = 20
    $question = "You are: $($OpenShiftSession)
	
Is this the correct server?  Defaults to `'$defaultAnswerDisplay`' after $timeout seconds"
    $msgBox = New-Object -ComObject WScript.Shell
    $answer = $msgBox.Popup($question, $timeout, "Are You Connected to the Correct Server!", $buttonType)
  }
  catch {
  }

  if ($answer -eq $yes -or ($answer -eq $msgBoxTimeout -and $defaultAnswer -eq $true)) {
    return $true
  }
  return $false
}

if(Confirm-Server) {

if (Confirm-Delete 'tran-schoolbus-tools') {
  oc delete project tran-schoolbus-tools
}

if (Confirm-Delete 'tran-schoolbus-dev') {
  oc delete project tran-schoolbus-dev
}

if (Confirm-Delete 'tran-schoolbus-test') {
  oc delete project tran-schoolbus-test
}

if (Confirm-Delete 'tran-schoolbus-prod') {
  oc delete project tran-schoolbus-prod
}
}