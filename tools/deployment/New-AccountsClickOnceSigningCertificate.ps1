[CmdletBinding()]
param()

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function ConvertTo-PlainText {
    param(
        [Parameter(Mandatory = $true)]
        [Security.SecureString]$SecureString
    )

    $pointer = [Runtime.InteropServices.Marshal]::SecureStringToBSTR($SecureString)
    try {
        return [Runtime.InteropServices.Marshal]::PtrToStringBSTR($pointer)
    }
    finally {
        [Runtime.InteropServices.Marshal]::ZeroFreeBSTR($pointer)
    }
}

$backupDirectory = 'C:\SecureBackups\AATM\ClickOnceSigning'
$subject = 'CN=AATM Software Publishing, O=AATM'
$friendlyName = 'AATM Accounts ClickOnce Signing'
$pfxPath = Join-Path $backupDirectory 'AATM-Software-Publishing.pfx'
$cerPath = Join-Path $backupDirectory 'AATM-Software-Publishing.cer'
$detailsPath = Join-Path $backupDirectory 'Certificate-Details.txt'
$resultPath = Join-Path $backupDirectory 'Certificate-Result.txt'

Write-Host 'AATM Accounts ClickOnce signing certificate' -ForegroundColor Cyan
Write-Host 'Choose a strong backup password and retain it in your approved password manager.'
Write-Host 'The password cannot be recovered from the exported PFX.' -ForegroundColor Yellow
Write-Host ''

$password = Read-Host 'Enter the PFX backup password' -AsSecureString
$confirmation = Read-Host 'Confirm the PFX backup password' -AsSecureString

$passwordText = ConvertTo-PlainText -SecureString $password
$confirmationText = ConvertTo-PlainText -SecureString $confirmation
try {
    if ([string]::IsNullOrWhiteSpace($passwordText)) {
        throw 'The backup password cannot be empty.'
    }
    if (-not [string]::Equals($passwordText, $confirmationText, [StringComparison]::Ordinal)) {
        throw 'The backup passwords did not match.'
    }
}
finally {
    $passwordText = $null
    $confirmationText = $null
}

if ((Test-Path -LiteralPath $pfxPath -PathType Leaf) -or
    (Test-Path -LiteralPath $cerPath -PathType Leaf) -or
    (Test-Path -LiteralPath $resultPath -PathType Leaf)) {
    throw "A certificate backup already exists in $backupDirectory. No certificate was created."
}

New-Item -ItemType Directory -Path $backupDirectory -Force | Out-Null

$identity = [Security.Principal.WindowsIdentity]::GetCurrent()
$directorySecurity = New-Object Security.AccessControl.DirectorySecurity
$directorySecurity.SetAccessRuleProtection($true, $false)
$inheritance = [Security.AccessControl.InheritanceFlags]'ContainerInherit, ObjectInherit'
$propagation = [Security.AccessControl.PropagationFlags]::None
$fullControl = [Security.AccessControl.FileSystemRights]::FullControl
$allow = [Security.AccessControl.AccessControlType]::Allow
$directorySecurity.AddAccessRule(
    (New-Object Security.AccessControl.FileSystemAccessRule(
        $identity.Name, $fullControl, $inheritance, $propagation, $allow)))
$directorySecurity.AddAccessRule(
    (New-Object Security.AccessControl.FileSystemAccessRule(
        'NT AUTHORITY\SYSTEM', $fullControl, $inheritance, $propagation, $allow)))
Set-Acl -LiteralPath $backupDirectory -AclObject $directorySecurity

$existingCertificate = Get-ChildItem Cert:\CurrentUser\My |
    Where-Object {
        $_.Subject -eq $subject -and
        $_.NotAfter -gt (Get-Date) -and
        $_.HasPrivateKey
    }
if ($existingCertificate) {
    throw "An active certificate already exists with subject '$subject'. No certificate was created."
}

$certificate = New-SelfSignedCertificate `
    -Type CodeSigningCert `
    -Subject $subject `
    -FriendlyName $friendlyName `
    -CertStoreLocation 'Cert:\CurrentUser\My' `
    -KeyAlgorithm RSA `
    -KeyLength 3072 `
    -HashAlgorithm SHA256 `
    -KeyExportPolicy Exportable `
    -NotAfter (Get-Date).AddYears(5)

try {
    Export-PfxCertificate `
        -Cert $certificate `
        -FilePath $pfxPath `
        -Password $password `
        -ChainOption EndEntityCertOnly `
        -NoProperties | Out-Null

    Export-Certificate `
        -Cert $certificate `
        -FilePath $cerPath `
        -Type CERT | Out-Null

    $pfxData = Get-PfxData -FilePath $pfxPath -Password $password
    if ($null -eq $pfxData.EndEntityCertificates -or
        $pfxData.EndEntityCertificates.Thumbprint -ne $certificate.Thumbprint) {
        throw 'The exported PFX failed certificate verification.'
    }

    $details = @(
        "Subject: $($certificate.Subject)"
        "Issuer: $($certificate.Issuer)"
        "Thumbprint: $($certificate.Thumbprint)"
        "Valid from: $($certificate.NotBefore.ToString('s'))"
        "Valid until: $($certificate.NotAfter.ToString('s'))"
        "Private-key backup: $pfxPath"
        "Public certificate: $cerPath"
        'Store the PFX password in the approved password manager. It is not stored here.'
    )
    [IO.File]::WriteAllLines($detailsPath, $details)
    [IO.File]::WriteAllLines($resultPath, @(
        "Thumbprint=$($certificate.Thumbprint)"
        "CerPath=$cerPath"
        "PfxPath=$pfxPath"
    ))

    Write-Host ''
    Write-Host 'Certificate created and backup verified.' -ForegroundColor Green
    Write-Host "Thumbprint: $($certificate.Thumbprint)"
    Write-Host "PFX backup: $pfxPath"
    Write-Host "Public certificate: $cerPath"
}
catch {
    Remove-Item -LiteralPath "Cert:\CurrentUser\My\$($certificate.Thumbprint)" -Force -ErrorAction SilentlyContinue
    throw
}
finally {
    $password.Dispose()
    $confirmation.Dispose()
}

Write-Host ''
Read-Host 'Press Enter to close this window'
