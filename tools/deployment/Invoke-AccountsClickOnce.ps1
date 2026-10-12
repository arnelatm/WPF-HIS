[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [ValidateSet('Stage', 'Validate', 'Preview', 'Deploy')]
    [string]$Action,

    [Parameter(Mandatory = $true)]
    [ValidatePattern('^(0|[1-9][0-9]*)\.(0|[1-9][0-9]*)\.(0|[1-9][0-9]*)\.(0|[1-9][0-9]*)$')]
    [string]$Version,

    [switch]$OptionalUpdate
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'AccountsClickOnce.Common.ps1')

$releaseVersion = [version]::Parse($Version)
foreach ($part in @($releaseVersion.Major, $releaseVersion.Minor, $releaseVersion.Build, $releaseVersion.Revision)) {
    if ($part -gt 65535) { throw 'ClickOnce version components must be between 0 and 65535.' }
}
if ($OptionalUpdate -and $Action -ne 'Stage') {
    throw '-OptionalUpdate is only valid with -Action Stage.'
}

# Keep version-specific paths inside the scripts, outside the execution approval prefix.
# No caller-supplied destinations, script paths, MSBuild arguments or command strings.
switch ($Action) {
    'Stage' {
        & (Join-Path $PSScriptRoot 'Publish-AccountsClickOnce.ps1') -Version $Version -OptionalUpdate:$OptionalUpdate
    }
    'Validate' {
        $package = Get-AccountsClickOncePackage -Root (Get-AccountsStagingDirectory -Version $Version) -Version $Version
        $thumbprint = '1A175C7C0E61C34D09B6827C5E3D8738C562A831'
        Assert-AccountsClickOnceManifestSignature -Path $package.ManifestPath -CertificateThumbprint $thumbprint
        Assert-AccountsClickOnceManifestSignature -Path (Join-Path $package.VersionDirectory 'Accounts.exe.manifest') -CertificateThumbprint $thumbprint
        Write-Host "Staged Accounts $Version manifests and configuration validated."
    }
    'Preview' {
        & (Join-Path $PSScriptRoot 'Deploy-AccountsClickOnce.ps1') -Version $Version -WhatIf
    }
    'Deploy' {
        # Deliberately retain the deployment script's exact DEPLOY <version> confirmation.
        & (Join-Path $PSScriptRoot 'Deploy-AccountsClickOnce.ps1') -Version $Version
    }
}
