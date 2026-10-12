# Offline orchestration tests. Never reads or writes the production share.
[CmdletBinding()]
param()
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$testRoot = Join-Path ([IO.Path]::GetTempPath()) ('AccountsClickOnceTest_' + [guid]::NewGuid().ToString('N'))
$null = New-Item -ItemType Directory -Path $testRoot
try {
    $source = [IO.File]::ReadAllText((Join-Path $PSScriptRoot 'Deploy-AccountsClickOnce.ps1'))
    $localLive = Join-Path $testRoot 'COAccounts'
    # Only the isolated test copy gets a local destination. Production has no override.
    $source = $source.Replace('\\IBN-SERVER\ISP\COAccounts', $localLive)
    [IO.File]::WriteAllText((Join-Path $testRoot 'Deploy-AccountsClickOnce.ps1'), $source)
    Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'AccountsClickOnce.Common.ps1') -Destination $testRoot
    Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'Invoke-AccountsClickOnce.ps1') -Destination $testRoot
    $mocks = @'

function Get-AccountsStagingDirectory { param($Version) Join-Path $PSScriptRoot 'stage' }
function Get-AccountsClickOncePackage {
    param($Root, $Version)
    [xml]$xml = Get-Content -LiteralPath (Join-Path $Root 'Accounts.application') -Raw
    if ($xml.assembly.assemblyIdentity.version -ne $Version) { throw 'Fixture version mismatch' }
    [pscustomobject]@{
        ManifestPath = Join-Path $Root 'Accounts.application'
        SetupPath = Join-Path $Root 'setup.exe'
        VersionDirectory = Join-Path $Root ('Application Files\Accounts_' + $Version.Replace('.', '_'))
        PayloadFileCount = 1
        IsRequiredUpdate = $true
    }
}
function Assert-AccountsClickOnceManifestSignature {
    param($Path, $CertificateThumbprint)
    if ($env:AATM_CLICKONCE_TEST_CASE -eq 'signature') { throw 'Fixture signature rejection' }
}
function Read-Host { param($Prompt) 'DEPLOY 1.0.0.2' }
function Assert-AccountsFileMatches {
    param($Source, $Destination)
    if ($env:AATM_CLICKONCE_TEST_CASE -eq 'rollback' -and
        $Destination -eq (Join-Path $PSScriptRoot 'COAccounts\Accounts.application')) {
        throw 'Fixture promotion failure'
    }
    if ((Get-FileHash -LiteralPath $Source).Hash -ne (Get-FileHash -LiteralPath $Destination).Hash) {
        throw 'Fixture hash mismatch'
    }
}
'@
    Add-Content -LiteralPath (Join-Path $testRoot 'AccountsClickOnce.Common.ps1') -Value $mocks
    $shell = Join-Path $PSHOME 'powershell.exe'
    $entry = Join-Path $testRoot 'Invoke-AccountsClickOnce.ps1'
    foreach ($case in @('preview', 'signature', 'deploy', 'rollback', 'older', 'invalid')) {
        # Reset only the verified isolated fixture directory, never a computed share path.
        foreach ($item in Get-ChildItem -LiteralPath $testRoot -Directory) {
            if (-not $item.FullName.StartsWith($testRoot + '\', [StringComparison]::OrdinalIgnoreCase)) { throw 'Unsafe test cleanup' }
            Remove-Item -LiteralPath $item.FullName -Recurse -Force
        }
        foreach ($pair in @(@('COAccounts', '1.0.0.1'), @('stage', '1.0.0.2'))) {
            $root = Join-Path $testRoot $pair[0]
            $payload = Join-Path $root ('Application Files\Accounts_' + $pair[1].Replace('.', '_'))
            $null = New-Item -ItemType Directory -Path $payload -Force
            Set-Content -LiteralPath (Join-Path $root 'Accounts.application') -Value ('<assembly><assemblyIdentity version="' + $pair[1] + '"/></assembly>')
            Set-Content -LiteralPath (Join-Path $root 'setup.exe') -Value $pair[1]
            Set-Content -LiteralPath (Join-Path $payload 'payload.deploy') -Value $pair[1]
        }
        $before = (Get-FileHash -LiteralPath (Join-Path $localLive 'Accounts.application')).Hash
        $beforeSetup = (Get-FileHash -LiteralPath (Join-Path $localLive 'setup.exe')).Hash
        $env:AATM_CLICKONCE_TEST_CASE = $case
        $action = if ($case -eq 'preview') { 'Preview' } else { 'Deploy' }
        $version = if ($case -eq 'invalid') { '1.0.0.65536' } else { '1.0.0.2' }
        if ($case -eq 'older') {
            Set-Content -LiteralPath (Join-Path $localLive 'Accounts.application') -Value '<assembly><assemblyIdentity version="1.0.0.3"/></assembly>'
            $before = (Get-FileHash -LiteralPath (Join-Path $localLive 'Accounts.application')).Hash
        }
        $ErrorActionPreference = 'Continue'
        $result = & $shell -NoProfile -ExecutionPolicy Bypass -File $entry -Action $action -Version $version 2>&1
        $ErrorActionPreference = 'Stop'
        $shouldSucceed = $case -in @('preview', 'deploy')
        if (($LASTEXITCODE -eq 0) -ne $shouldSucceed) { throw "Unexpected result for $case`: $result" }
        if ($case -ne 'deploy') {
            if ((Get-FileHash -LiteralPath (Join-Path $localLive 'Accounts.application')).Hash -ne $before -or
                (Get-FileHash -LiteralPath (Join-Path $localLive 'setup.exe')).Hash -ne $beforeSetup) {
                throw "$case changed live root fixture files"
            }
        }
        if ($case -in @('preview', 'signature', 'older', 'invalid') -and
            (Test-Path -LiteralPath (Join-Path $localLive 'Application Files\Accounts_1_0_0_2'))) {
            throw "$case copied a payload"
        }
        if ($case -eq 'deploy') {
            . (Join-Path $PSScriptRoot 'AccountsClickOnce.Common.ps1')
            Assert-AccountsFileMatches -Source (Join-Path $testRoot 'stage\Accounts.application') -Destination (Join-Path $localLive 'Accounts.application')
            Assert-AccountsFileMatches -Source (Join-Path $testRoot 'stage\setup.exe') -Destination (Join-Path $localLive 'setup.exe')
            Assert-AccountsPayloadMatches -SourceDirectory (Join-Path $testRoot 'stage\Application Files\Accounts_1_0_0_2') -DestinationDirectory (Join-Path $localLive 'Application Files\Accounts_1_0_0_2')
            Set-Content -LiteralPath (Join-Path $localLive 'Application Files\Accounts_1_0_0_2\payload.deploy') -Value '9.9.9.9'
            $rejected = $false
            try {
                Assert-AccountsPayloadMatches -SourceDirectory (Join-Path $testRoot 'stage\Application Files\Accounts_1_0_0_2') -DestinationDirectory (Join-Path $localLive 'Application Files\Accounts_1_0_0_2')
            }
            catch { $rejected = $true }
            if (-not $rejected) { throw 'SHA256 validation accepted corrupted payload' }
        }
        if ($case -in @('deploy', 'rollback')) {
            $backups = @(Get-ChildItem -LiteralPath $testRoot -Directory -Filter 'COAccounts_Backup_*')
            if ($backups.Count -ne 1 -or
                (Get-FileHash -LiteralPath (Join-Path $backups[0].FullName 'Accounts.application')).Hash -ne $before) {
                throw 'Expected verified original backup'
            }
        }
        Write-Host "PASS: $case"
    }
}
finally {
    Remove-Item Env:\AATM_CLICKONCE_TEST_CASE -ErrorAction SilentlyContinue
    $resolved = [IO.Path]::GetFullPath($testRoot)
    $expectedParent = [IO.Path]::GetFullPath([IO.Path]::GetTempPath()).TrimEnd('\') + '\'
    if ($resolved.StartsWith($expectedParent, [StringComparison]::OrdinalIgnoreCase) -and
        (Split-Path -Leaf $resolved) -match '^AccountsClickOnceTest_[0-9a-f]{32}$') {
        Remove-Item -LiteralPath $resolved -Recurse -Force
    }
}
