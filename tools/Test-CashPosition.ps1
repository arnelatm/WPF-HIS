param(
    [string]$Server,
    [string]$Database,
    [switch]$ReadOnlyTestDatabase,
    [switch]$Render,
    [switch]$CheckCaptions,
    [switch]$CheckTransactions,
    [string]$BinaryDirectory
)
$ErrorActionPreference = 'Stop'
$cashRoot = Split-Path -Parent $PSScriptRoot
$cashBin = Join-Path $cashRoot 'Accounts\bin\Debug'
if ($BinaryDirectory) { $cashBin = (Resolve-Path -LiteralPath $BinaryDirectory).Path }
$cashOutput = Join-Path $cashRoot '.tmp'
if (-not (Test-Path -LiteralPath $cashOutput)) { New-Item -ItemType Directory -Path $cashOutput | Out-Null }
$cashReferences = @('Accounts.exe','GlobalFuncNSub.dll','BaseControlsLibrary.dll','CBaseControlsLibrary.dll','Forms.dll','Views.dll','Common.dll','DataLayer.dll','BusinessLayer.dll') |
    ForEach-Object { Join-Path $cashBin $_ }
foreach ($cashReference in $cashReferences) { [void][Reflection.Assembly]::LoadFrom($cashReference) }
$cashReferences += @('System.dll','System.Core.dll','System.Data.dll','System.Xml.dll','System.Drawing.dll','System.Windows.Forms.dll')
$cashCompiler = New-Object Microsoft.CSharp.CSharpCodeProvider
$cashOptions = New-Object System.CodeDom.Compiler.CompilerParameters
$cashOptions.GenerateInMemory = $true
$cashOptions.ReferencedAssemblies.AddRange([string[]]$cashReferences)
try {
    $cashCompilation = $cashCompiler.CompileAssemblyFromFile($cashOptions, (Join-Path $PSScriptRoot 'CashPositionChecks.cs'))
    if ($cashCompilation.Errors.HasErrors) { throw (($cashCompilation.Errors | ForEach-Object ToString) -join [Environment]::NewLine) }
    $null = $cashCompilation.CompiledAssembly
} finally { $cashCompiler.Dispose() }
[CashPositionChecks]::ResolveRuntimeFrom($cashBin)
[CashPositionChecks]::RunOffline()
if ($CheckCaptions) { [CashPositionChecks]::RunCaptions() }
if ($CheckTransactions) { [CashPositionChecks]::RunTransactions($cashOutput) }
if ($ReadOnlyTestDatabase) {
    if ([string]::IsNullOrWhiteSpace($Server) -or [string]::IsNullOrWhiteSpace($Database)) {
        throw 'Specify the authorized test Server and Database. Do not use a production target.'
    }
    # Build the test connection in memory; never read or rewrite the application's configuration.
    $cashConnection = New-Object System.Data.SqlClient.SqlConnectionStringBuilder
    $cashConnection['Data Source'] = $Server
    $cashConnection['Initial Catalog'] = $Database
    $cashConnection['Integrated Security'] = $true
    $cashConnection['Connect Timeout'] = 15
    [AATM.Libraries.GlobalFuncNSub.GlobalVariables]::DacConnectionString = $cashConnection.ConnectionString
    $cashResult = [CashPositionChecks]::RunDatabase()
    if ($CheckTransactions) { [CashPositionChecks]::RunTransactionDatabase($cashResult, $cashOutput) }
    if ($Render) { [CashPositionChecks]::Render($cashResult, $cashOutput) }
} elseif ($Render) {
    throw 'Rendering realistic balances requires the explicitly selected test database.'
}
