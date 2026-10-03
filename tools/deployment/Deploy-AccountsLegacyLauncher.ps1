[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param([switch]$UsersClosedLegacyApp)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'AccountsClickOnce.Common.ps1')
$repoRoot = Get-AccountsRepositoryRoot
$sourceDirectory = Join-Path $repoRoot 'Publish\AccountsLegacyLauncher'
$sourceExe = Join-Path $sourceDirectory 'Accounts.exe'
$sourceConfig = $sourceExe + '.config'
$destinationExe = '\\IBN-SERVER\ISP\Accounts\Accounts.exe'
$destinationConfig = $destinationExe + '.config'
$thumbprint = '1A175C7C0E61C34D09B6827C5E3D8738C562A831'
foreach ($path in @($sourceExe, $sourceConfig, $destinationExe)) {
    if (-not (Test-Path -LiteralPath $path -PathType Leaf)) { throw "Required file not found: $path" }
}
$signature = Get-AuthenticodeSignature -LiteralPath $sourceExe
if ($signature.Status -ne 'Valid' -or $signature.SignerCertificate.Thumbprint -ne $thumbprint) { throw 'The replacement launcher is not signed by the approved certificate.' }
if ((Get-Item -LiteralPath $sourceExe).VersionInfo.ProductName -ne 'Clinic Information System Launcher') { throw 'The replacement executable is not the legacy redirector.' }
$probe = Start-Process -FilePath $sourceExe -ArgumentList '--verify' -PassThru -Wait
if ($probe.ExitCode -ne 0) { throw 'The approved ClickOnce deployment is not available to the launcher.' }
$backupDirectory = Join-Path $repoRoot ('Publish\LegacyLauncherBackups\' + (Get-Date -Format 'yyyyMMdd-HHmmss'))
Write-Host "Replace: $destinationExe"
Write-Host "Restricted backup: $backupDirectory"
Write-Host 'The legacy EXE and its runtime config will be replaced. Report folders and other applications are not changed.'
if ($WhatIfPreference) {
    $null = $PSCmdlet.ShouldProcess($destinationExe, 'Back up the legacy EXE/config and replace them with the signed ClickOnce launcher')
    return
}
if (-not $UsersClosedLegacyApp) { throw 'Close the shared legacy program on all workstations, then use -UsersClosedLegacyApp.' }
$confirmation = Read-Host "Type 'REPLACE LEGACY ACCOUNTS' to continue"
if ($confirmation -cne 'REPLACE LEGACY ACCOUNTS') { throw 'Legacy replacement cancelled.' }
if (-not $PSCmdlet.ShouldProcess($destinationExe, 'Replace the legacy executable and its runtime config')) { return }

# Refuse replacement when Windows reports an open handle to the legacy executable.
$handle = [IO.File]::Open($destinationExe, [IO.FileMode]::Open, [IO.FileAccess]::ReadWrite, [IO.FileShare]::None)
$handle.Dispose()
New-Item -ItemType Directory -Path $backupDirectory -ErrorAction Stop | Out-Null
$security = New-Object Security.AccessControl.DirectorySecurity
$security.SetAccessRuleProtection($true, $false)
$owner = [Security.Principal.WindowsIdentity]::GetCurrent().User
$security.SetOwner($owner)
foreach ($sid in @($owner, (New-Object Security.Principal.SecurityIdentifier('S-1-5-18')), (New-Object Security.Principal.SecurityIdentifier('S-1-5-32-544')))) {
    $rule = New-Object Security.AccessControl.FileSystemAccessRule($sid, 'FullControl', 'ContainerInherit,ObjectInherit', 'None', 'Allow')
    $security.AddAccessRule($rule)
}
Set-Acl -LiteralPath $backupDirectory -AclObject $security
$backupExe = Join-Path $backupDirectory 'Accounts.exe'
$backupConfig = $backupExe + '.config'
$hadConfig = Test-Path -LiteralPath $destinationConfig -PathType Leaf
Copy-Item -LiteralPath $destinationExe -Destination $backupExe
Assert-AccountsFileMatches -Source $destinationExe -Destination $backupExe
if ($hadConfig) {
    Copy-Item -LiteralPath $destinationConfig -Destination $backupConfig
    Assert-AccountsFileMatches -Source $destinationConfig -Destination $backupConfig
}
$oldExeAcl = Get-Acl -LiteralPath $destinationExe
$oldConfigAcl = if ($hadConfig) { Get-Acl -LiteralPath $destinationConfig } else { $null }
$oldExeAcl.Sddl | Set-Content -LiteralPath (Join-Path $backupDirectory 'Accounts.exe.acl.txt')
if ($hadConfig) { $oldConfigAcl.Sddl | Set-Content -LiteralPath (Join-Path $backupDirectory 'Accounts.exe.config.acl.txt') }
try {
    Copy-Item -LiteralPath $sourceConfig -Destination $destinationConfig -Force
    Copy-Item -LiteralPath $sourceExe -Destination $destinationExe -Force
    Assert-AccountsFileMatches -Source $sourceExe -Destination $destinationExe
    Assert-AccountsFileMatches -Source $sourceConfig -Destination $destinationConfig
    Set-Acl -LiteralPath $destinationExe -AclObject $oldExeAcl
    if ($hadConfig) { Set-Acl -LiteralPath $destinationConfig -AclObject $oldConfigAcl }
    $liveProbe = Start-Process -FilePath $destinationExe -ArgumentList '--verify' -PassThru -Wait
    if ($liveProbe.ExitCode -ne 0) { throw 'The live replacement failed its deployment check.' }
}
catch {
    Copy-Item -LiteralPath $backupExe -Destination $destinationExe -Force
    Set-Acl -LiteralPath $destinationExe -AclObject $oldExeAcl
    if ($hadConfig) {
        Copy-Item -LiteralPath $backupConfig -Destination $destinationConfig -Force
        Set-Acl -LiteralPath $destinationConfig -AclObject $oldConfigAcl
    }
    else { Remove-Item -LiteralPath $destinationConfig -Force -ErrorAction SilentlyContinue }
    throw
}
Write-Host 'The legacy network shortcut now opens the approved ClickOnce deployment.'
Write-Host "Rollback files retained at: $backupDirectory"
