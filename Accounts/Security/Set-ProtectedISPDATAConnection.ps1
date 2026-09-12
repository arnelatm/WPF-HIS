param(
    [ValidateSet('ISPDATA', 'KIZEN', 'BIOTIME', 'IGROUPCLINIC')]
    [string]$ConnectionName = 'ISPDATA',
    [string]$Path
)

$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Security

$Path = if ([string]::IsNullOrWhiteSpace($Path)) {
    "$env:ProgramData\AATM\Accounts\$ConnectionName.connection"
} else {
    $Path
}

$server = [string](Read-Host "SQL Server name")
$database = [string](Read-Host "Database name")
$user = [string](Read-Host "SQL login name")
$securePassword = Read-Host "SQL login password" -AsSecureString

$bstr = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($securePassword)
try {
    $password = [Runtime.InteropServices.Marshal]::PtrToStringBSTR($bstr)
    $builder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder
    $builder['Data Source'] = [string]$server
    $builder['Initial Catalog'] = [string]$database
    $builder['Persist Security Info'] = $true
    $builder['User ID'] = [string]$user
    $builder['Password'] = [string]$password
    $clearBytes = [Text.Encoding]::UTF8.GetBytes($builder.ConnectionString)
}
finally {
    if ($bstr -ne [IntPtr]::Zero) {
        [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($bstr)
    }
}

$directory = Split-Path -Parent $Path
New-Item -ItemType Directory -Path $directory -Force | Out-Null
$encryptedBytes = [System.Security.Cryptography.ProtectedData]::Protect(
    $clearBytes,
    $null,
    [System.Security.Cryptography.DataProtectionScope]::LocalMachine)
$base64 = [Convert]::ToBase64String($encryptedBytes)
[IO.File]::WriteAllText($Path, $base64, (New-Object Text.UTF8Encoding($false)))

Write-Host "Protected connection saved to $Path"
Write-Host "The password was not written to the configuration file or displayed."
