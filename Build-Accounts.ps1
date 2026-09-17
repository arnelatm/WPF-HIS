[CmdletBinding()]
param(
    [ValidateSet('AuditTest', 'Live')]
    [string]$Environment = 'AuditTest',

    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Debug'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$accountsPath = Join-Path $repoRoot 'Accounts'
$activeConfigPath = Join-Path $accountsPath 'app.config'
$projectPath = Join-Path $accountsPath 'Accounts.vbproj'
$profileName = if ($Environment -eq 'Live') {
    'app - ibn-server.config'
} else {
    'app - ispadmin2.ispdata_audittest.config'
}
$profilePath = Join-Path $accountsPath $profileName

if (-not (Test-Path -LiteralPath $profilePath -PathType Leaf)) {
    throw "Configuration profile was not found: $profilePath"
}
if (-not (Test-Path -LiteralPath $activeConfigPath -PathType Leaf)) {
    throw "Active application configuration was not found: $activeConfigPath"
}
if (-not (Test-Path -LiteralPath $projectPath -PathType Leaf)) {
    throw "Accounts project was not found: $projectPath"
}

$msbuild = Get-Command msbuild.exe -ErrorAction SilentlyContinue
if ($null -eq $msbuild) {
    throw 'MSBuild.exe was not found. Run this script from a Visual Studio Developer PowerShell.'
}

$backupPath = Join-Path ([System.IO.Path]::GetTempPath()) ('Accounts.app.config.' + [Guid]::NewGuid().ToString('N') + '.bak')
Copy-Item -LiteralPath $activeConfigPath -Destination $backupPath

try {
    Copy-Item -LiteralPath $profilePath -Destination $activeConfigPath -Force
    Write-Host ("Building Accounts for {0} using {1}..." -f $Environment, $profileName)

    & $msbuild.Source $projectPath /m ("/p:Configuration={0}" -f $Configuration) /v:minimal
    if ($LASTEXITCODE -ne 0) {
        throw "Accounts build failed with exit code $LASTEXITCODE."
    }

    Write-Host ("Build completed. The {0} connection settings are in Accounts\bin\{1}\Accounts.exe.config." -f $Environment, $Configuration) -ForegroundColor Green
}
finally {
    Copy-Item -LiteralPath $backupPath -Destination $activeConfigPath -Force
    Remove-Item -LiteralPath $backupPath -Force
    Write-Host 'Restored Accounts\app.config.'
}
