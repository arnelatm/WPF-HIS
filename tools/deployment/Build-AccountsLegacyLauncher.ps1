[CmdletBinding()]
param(
    [ValidatePattern('^[0-9A-Fa-f]{40}$')]
    [string]$CertificateThumbprint = '1A175C7C0E61C34D09B6827C5E3D8738C562A831'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'AccountsClickOnce.Common.ps1')
$repoRoot = Get-AccountsRepositoryRoot
$source = Join-Path $PSScriptRoot 'LegacyLauncher\AccountsClickOnceLauncher.cs'
$outputDirectory = Join-Path $repoRoot 'Publish\AccountsLegacyLauncher'
New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
$outputExe = Join-Path $outputDirectory 'Accounts.exe'
$outputConfig = $outputExe + '.config'

$compilerCommand = Get-Command csc.exe -ErrorAction SilentlyContinue
$compiler = if ($null -ne $compilerCommand) { $compilerCommand.Source } else {
    Join-Path (Split-Path -Parent (Get-AccountsMsBuildPath)) 'Roslyn\csc.exe'
}
if (-not (Test-Path -LiteralPath $compiler)) { throw 'The Visual Studio C# compiler was not found.' }
$formsAssembly = Join-Path ([Runtime.InteropServices.RuntimeEnvironment]::GetRuntimeDirectory()) 'System.Windows.Forms.dll'
& $compiler /nologo /target:winexe /platform:anycpu /optimize+ "/reference:$formsAssembly" "/out:$outputExe" $source
if ($LASTEXITCODE -ne 0) { throw 'Legacy launcher compilation failed.' }

$configuration = '<?xml version="1.0" encoding="utf-8"?><configuration><startup><supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" /></startup></configuration>'
[IO.File]::WriteAllText($outputConfig, $configuration, (New-Object Text.UTF8Encoding($false)))
$signToolCommand = Get-Command signtool.exe -ErrorAction SilentlyContinue
$signTool = if ($null -ne $signToolCommand) { $signToolCommand.Source } else {
    $sdkBin = Join-Path ${env:ProgramFiles(x86)} 'Windows Kits\10\bin'
    Get-ChildItem -LiteralPath $sdkBin -Directory -ErrorAction SilentlyContinue |
        Sort-Object Name -Descending | ForEach-Object { Join-Path $_.FullName 'x64\signtool.exe' } |
        Where-Object { Test-Path -LiteralPath $_ } | Select-Object -First 1
}
if ([string]::IsNullOrWhiteSpace($signTool)) {
    $clickOnceSignTool = Join-Path ${env:ProgramFiles(x86)} 'Microsoft SDKs\ClickOnce\SignTool\signtool.exe'
    if (Test-Path -LiteralPath $clickOnceSignTool) { $signTool = $clickOnceSignTool }
}
if ([string]::IsNullOrWhiteSpace($signTool)) { throw 'The Windows SDK signing tool was not found.' }
$certificate = Get-Item -LiteralPath "Cert:\CurrentUser\My\$CertificateThumbprint"
if (-not $certificate.HasPrivateKey -or $certificate.NotAfter -le (Get-Date)) { throw 'An available, unexpired signing private key is required.' }
& $signTool sign /sha1 $CertificateThumbprint /fd SHA256 /tr 'http://timestamp.digicert.com' /td SHA256 $outputExe
if ($LASTEXITCODE -ne 0) { throw 'Legacy launcher signing failed.' }
$signature = Get-AuthenticodeSignature -LiteralPath $outputExe
if ($signature.Status -ne 'Valid' -or $signature.SignerCertificate.Thumbprint -ne $CertificateThumbprint) { throw 'Legacy launcher signature verification failed.' }
Write-Host "Signed launcher: $outputExe"
Write-Host "Runtime configuration: $outputConfig"
Write-Host 'No shared files were replaced.'
