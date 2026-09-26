[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern('^\d+\.\d+\.\d+\.\d+$')]
    [string]$Version,

    [switch]$RequiredUpdate,

    [ValidatePattern('^[0-9A-Fa-f]{40}$')]
    [string]$CertificateThumbprint = '1A175C7C0E61C34D09B6827C5E3D8738C562A831'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

. (Join-Path $PSScriptRoot 'AccountsClickOnce.Common.ps1')

$releaseVersion = [version]::Parse($Version)
$repoRoot = Get-AccountsRepositoryRoot
$accountsDirectory = Join-Path $repoRoot 'Accounts'
$activeConfiguration = Join-Path $accountsDirectory 'app.config'
$liveConfiguration = Join-Path $accountsDirectory 'app - ibn-server.config'
$projectPath = Join-Path $accountsDirectory 'Accounts.vbproj'
$stagingDirectory = Get-AccountsStagingDirectory -Version $Version
$installUrl = '\\IBN-SERVER\ISP\COAccounts\'
$CertificateThumbprint = $CertificateThumbprint.ToUpperInvariant()

foreach ($requiredPath in @($activeConfiguration, $liveConfiguration, $projectPath)) {
    if (-not (Test-Path -LiteralPath $requiredPath -PathType Leaf)) {
        throw "Required file was not found: $requiredPath"
    }
}

Assert-AccountsLiveConfiguration -Path $liveConfiguration

$certificatePath = "Cert:\CurrentUser\My\$CertificateThumbprint"
if (-not (Test-Path -LiteralPath $certificatePath)) {
    throw "The ClickOnce signing certificate was not found: $certificatePath"
}
$signingCertificate = Get-Item -LiteralPath $certificatePath
if (-not $signingCertificate.HasPrivateKey) {
    throw "The ClickOnce signing certificate does not have an accessible private key: $CertificateThumbprint"
}
if ($signingCertificate.NotBefore -gt (Get-Date) -or $signingCertificate.NotAfter -le (Get-Date)) {
    throw "The ClickOnce signing certificate is not currently valid: $CertificateThumbprint"
}
if ($signingCertificate.EnhancedKeyUsageList.ObjectId -notcontains '1.3.6.1.5.5.7.3.3') {
    throw "The certificate is not valid for code signing: $CertificateThumbprint"
}

if (Test-Path -LiteralPath $stagingDirectory) {
    throw "Staging directory already exists. Move or remove it before republishing the same version: $stagingDirectory"
}

$msBuildPath = Get-AccountsMsBuildPath
$configurationBackup = Join-Path ([IO.Path]::GetTempPath()) ("Accounts.app.config.{0}.bak" -f [guid]::NewGuid().ToString('N'))
Copy-Item -LiteralPath $activeConfiguration -Destination $configurationBackup

try {
    Copy-Item -LiteralPath $liveConfiguration -Destination $activeConfiguration -Force
    Assert-AccountsLiveConfiguration -Path $activeConfiguration

    $publishUrl = $stagingDirectory.TrimEnd('\') + '\'
    $arguments = @(
        $projectPath,
        '/m',
        '/t:Publish',
        '/nologo',
        '/v:minimal',
        '/clp:ErrorsOnly;Summary',
        '/p:Configuration=Release',
        '/p:Platform=AnyCPU',
        "/p:PublishUrl=$publishUrl",
        "/p:PublishDir=$publishUrl",
        "/p:InstallUrl=$installUrl",
        "/p:ApplicationVersion=$Version",
        "/p:ApplicationRevision=$($releaseVersion.Revision)",
        '/p:Install=true',
        '/p:InstallFrom=Unc',
        '/p:UpdateEnabled=true',
        '/p:UpdateMode=Foreground',
        '/p:UpdateInterval=0',
        '/p:UpdateIntervalUnits=Days',
        '/p:MapFileExtensions=true',
        '/p:CreateDesktopShortcut=true',
        '/p:SignManifests=true',
        "/p:ManifestCertificateThumbprint=$CertificateThumbprint"
    )
    if ($RequiredUpdate) {
        $arguments += "/p:MinimumRequiredVersion=$Version"
    }

    Write-Host "Publishing Accounts $Version to local staging..." -ForegroundColor Cyan
    & $msBuildPath @arguments
    if ($LASTEXITCODE -ne 0) {
        throw "Accounts ClickOnce publish failed with exit code $LASTEXITCODE."
    }

    $package = Get-AccountsClickOncePackage -Root $stagingDirectory -Version $Version -RequiredUpdate:$RequiredUpdate
    $applicationManifest = Join-Path $package.VersionDirectory 'Accounts.exe.manifest'
    Assert-AccountsClickOnceManifestSignature `
        -Path $package.ManifestPath `
        -CertificateThumbprint $CertificateThumbprint
    Assert-AccountsClickOnceManifestSignature `
        -Path $applicationManifest `
        -CertificateThumbprint $CertificateThumbprint
    Write-Host ''
    Write-Host "Local ClickOnce package verified successfully." -ForegroundColor Green
    Write-Host "Version:             $Version"
    Write-Host "Payload files:       $($package.PayloadFileCount)"
    Write-Host "Required update:     $($package.IsRequiredUpdate)"
    Write-Host "Signing certificate: $CertificateThumbprint"
    Write-Host "Deployment provider: $($package.DeploymentProvider)"
    Write-Host "Staging directory:   $stagingDirectory"
}
finally {
    if (Test-Path -LiteralPath $configurationBackup -PathType Leaf) {
        Copy-Item -LiteralPath $configurationBackup -Destination $activeConfiguration -Force
        Remove-Item -LiteralPath $configurationBackup -Force
        Write-Host 'Restored Accounts\app.config.'
    }
}

Write-Host ''
Write-Host 'Review the staged package, then deploy it with:' -ForegroundColor Yellow
Write-Host ("  .\tools\deployment\Deploy-AccountsClickOnce.ps1 -Version {0}" -f $Version)
