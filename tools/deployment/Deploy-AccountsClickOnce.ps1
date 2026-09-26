[CmdletBinding(SupportsShouldProcess = $true, ConfirmImpact = 'Medium')]
param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern('^\d+\.\d+\.\d+\.\d+$')]
    [string]$Version
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

. (Join-Path $PSScriptRoot 'AccountsClickOnce.Common.ps1')

$releaseVersion = [version]::Parse($Version)
$stagingDirectory = Get-AccountsStagingDirectory -Version $Version
$destination = '\\IBN-SERVER\ISP\COAccounts'
$expectedDestination = '\\IBN-SERVER\ISP\COAccounts'

if (-not [string]::Equals($destination.TrimEnd('\'), $expectedDestination, [StringComparison]::OrdinalIgnoreCase)) {
    throw "Production destination is not the approved COAccounts path: $destination"
}

$package = Get-AccountsClickOncePackage -Root $stagingDirectory -Version $Version
if (-not (Test-Path -LiteralPath $destination -PathType Container)) {
    throw "Production ClickOnce directory was not found: $destination"
}

$liveManifest = Join-Path $destination 'Accounts.application'
if (-not (Test-Path -LiteralPath $liveManifest -PathType Leaf)) {
    throw "Production deployment manifest was not found: $liveManifest"
}

try {
    [xml]$liveManifestXml = Get-Content -LiteralPath $liveManifest -Raw
}
catch {
    throw "Production deployment manifest is not valid XML: $liveManifest"
}
$liveIdentity = $liveManifestXml.SelectSingleNode('/*[local-name()="assembly"]/*[local-name()="assemblyIdentity"]')
if ($null -eq $liveIdentity) {
    throw "Production manifest identity was not found: $liveManifest"
}
$liveVersion = [version]::Parse([string]$liveIdentity.version)
if ($releaseVersion -le $liveVersion) {
    throw "Requested version $Version must be greater than live version $liveVersion."
}
$currentLivePackage = Get-AccountsClickOncePackage -Root $destination -Version $liveVersion.ToString()

$destinationVersionDirectory = Join-Path $destination ("Application Files\Accounts_{0}" -f (Get-AccountsVersionToken -Version $Version))
if (Test-Path -LiteralPath $destinationVersionDirectory) {
    throw "Production version directory already exists: $destinationVersionDirectory"
}

$backupName = 'COAccounts_Backup_{0}_{1}' -f (Get-Date -Format 'yyyyMMdd_HHmmss'), $liveVersion
$backupDirectory = Join-Path (Split-Path -Parent $destination) $backupName
if (Test-Path -LiteralPath $backupDirectory) {
    throw "Deployment backup directory already exists: $backupDirectory"
}

Write-Host ''
Write-Host 'Accounts ClickOnce production deployment' -ForegroundColor Yellow
Write-Host "Current live version: $liveVersion"
Write-Host "New version:          $Version"
Write-Host "Source:               $stagingDirectory"
Write-Host "Destination:          $destination"
Write-Host "Backup:               $backupDirectory"
Write-Host "Payload files:         $($package.PayloadFileCount)"
Write-Host "Required update:       $($package.IsRequiredUpdate)"

if ($WhatIfPreference) {
    $null = $PSCmdlet.ShouldProcess($backupDirectory, 'Create production deployment backup')
    $null = $PSCmdlet.ShouldProcess($destinationVersionDirectory, 'Copy and verify version payload')
    $null = $PSCmdlet.ShouldProcess((Join-Path $destination 'setup.exe'), 'Replace setup.exe')
    $null = $PSCmdlet.ShouldProcess($liveManifest, 'Promote Accounts.application last')
    return
}

$confirmation = Read-Host ("Type 'DEPLOY {0}' to continue" -f $Version)
if (-not [string]::Equals($confirmation, ("DEPLOY {0}" -f $Version), [StringComparison]::Ordinal)) {
    throw 'Deployment cancelled because the confirmation text did not match.'
}

$backupCreated = $false
$rootFilesMutationStarted = $false
try {
    if ($PSCmdlet.ShouldProcess($backupDirectory, 'Create production deployment backup')) {
        Copy-Item -LiteralPath $destination -Destination $backupDirectory -Recurse
        $backupManifest = Join-Path $backupDirectory 'Accounts.application'
        if (-not (Test-Path -LiteralPath $backupManifest -PathType Leaf)) {
            throw "Deployment backup verification failed: $backupDirectory"
        }
        $backupPackage = Get-AccountsClickOncePackage -Root $backupDirectory -Version $liveVersion.ToString()
        Assert-AccountsFileMatches -Source $currentLivePackage.ManifestPath -Destination $backupPackage.ManifestPath
        Assert-AccountsFileMatches -Source $currentLivePackage.SetupPath -Destination $backupPackage.SetupPath
        Assert-AccountsPayloadMatches -SourceDirectory $currentLivePackage.VersionDirectory -DestinationDirectory $backupPackage.VersionDirectory
        $backupCreated = $true
    }

    if ($PSCmdlet.ShouldProcess($destinationVersionDirectory, 'Copy version payload')) {
        $destinationApplicationFiles = Join-Path $destination 'Application Files'
        Copy-Item -LiteralPath $package.VersionDirectory -Destination $destinationApplicationFiles -Recurse
        Assert-AccountsPayloadMatches -SourceDirectory $package.VersionDirectory -DestinationDirectory $destinationVersionDirectory
    }

    $destinationSetup = Join-Path $destination 'setup.exe'
    if ($PSCmdlet.ShouldProcess($destinationSetup, 'Replace setup.exe')) {
        $rootFilesMutationStarted = $true
        Copy-Item -LiteralPath $package.SetupPath -Destination $destinationSetup -Force
        Assert-AccountsFileMatches -Source $package.SetupPath -Destination $destinationSetup
    }

    if ($PSCmdlet.ShouldProcess($liveManifest, 'Promote Accounts.application last')) {
        $rootFilesMutationStarted = $true
        Copy-Item -LiteralPath $package.ManifestPath -Destination $liveManifest -Force
        Assert-AccountsFileMatches -Source $package.ManifestPath -Destination $liveManifest
    }

    $livePackage = Get-AccountsClickOncePackage -Root $destination -Version $Version
    Assert-AccountsPayloadMatches -SourceDirectory $package.VersionDirectory -DestinationDirectory $livePackage.VersionDirectory

    Write-Host ''
    Write-Host "Accounts $Version was deployed and verified successfully." -ForegroundColor Green
    Write-Host "Backup retained at: $backupDirectory"
}
catch {
    if ($backupCreated -and $rootFilesMutationStarted) {
        Write-Warning 'Deployment verification failed. Restoring the previous root manifest and setup file.'
        Copy-Item -LiteralPath (Join-Path $backupDirectory 'setup.exe') -Destination (Join-Path $destination 'setup.exe') -Force
        Copy-Item -LiteralPath (Join-Path $backupDirectory 'Accounts.application') -Destination $liveManifest -Force
    }
    throw
}
