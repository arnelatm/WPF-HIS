[CmdletBinding()]
param()

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$deploymentPath = '\\IBN-SERVER\ISP\COAccounts\Accounts.application'
$setupPath = '\\IBN-SERVER\ISP\COAccounts\setup.exe'
$minimumVersion = [version]'1.0.0.9'
$expectedPublicKeyToken = '38a655a256ce2e97'
$expectedCertificateThumbprint = '1A175C7C0E61C34D09B6827C5E3D8738C562A831'
$logDirectory = Join-Path $env:LOCALAPPDATA 'AATM\Logs'
$logPath = Join-Path $logDirectory 'AccountsClickOnceBootstrap.log'

function Write-AccountsBootstrapLog {
    param([Parameter(Mandatory = $true)][string]$Message)

    if (-not (Test-Path -LiteralPath $logDirectory -PathType Container)) {
        New-Item -ItemType Directory -Path $logDirectory -Force | Out-Null
    }
    Add-Content -LiteralPath $logPath -Value ('{0:s} {1}' -f (Get-Date), $Message)
}

try {
    if (-not (Test-Path -LiteralPath $deploymentPath -PathType Leaf)) {
        Write-AccountsBootstrapLog "Deployment manifest is unavailable: $deploymentPath"
        exit 10
    }
    if (-not (Test-Path -LiteralPath $setupPath -PathType Leaf)) {
        Write-AccountsBootstrapLog "ClickOnce setup is unavailable: $setupPath"
        exit 10
    }

    [xml]$manifest = Get-Content -LiteralPath $deploymentPath -Raw
    $identity = $manifest.SelectSingleNode(
        '/*[local-name()="assembly"]/*[local-name()="assemblyIdentity"]')
    if ($null -eq $identity) {
        throw 'The live ClickOnce manifest does not contain an assembly identity.'
    }

    $liveVersion = [version]::Parse([string]$identity.version)
    $livePublicKeyToken = [string]$identity.publicKeyToken
    if ($liveVersion -lt $minimumVersion -or
        -not [string]::Equals(
            $livePublicKeyToken,
            $expectedPublicKeyToken,
            [StringComparison]::OrdinalIgnoreCase)) {
        Write-AccountsBootstrapLog (
            "Live package is not the approved signed release. Version=$liveVersion; Token=$livePublicKeyToken")
        exit 11
    }

    $certificateNodes = @($manifest.SelectNodes('//*[local-name()="X509Certificate"]'))
    $manifestCertificateMatches = $false
    foreach ($certificateNode in $certificateNodes) {
        $certificateBytes = [Convert]::FromBase64String($certificateNode.InnerText)
        $certificate = New-Object Security.Cryptography.X509Certificates.X509Certificate2(,$certificateBytes)
        if ([string]::Equals(
                $certificate.Thumbprint,
                $expectedCertificateThumbprint,
                [StringComparison]::OrdinalIgnoreCase)) {
            $manifestCertificateMatches = $true
            break
        }
    }
    if (-not $manifestCertificateMatches) {
        throw 'The live ClickOnce manifest is not signed by the approved certificate.'
    }

    foreach ($store in @('Cert:\LocalMachine\Root', 'Cert:\LocalMachine\TrustedPublisher')) {
        $certificatePath = Join-Path $store $expectedCertificateThumbprint
        if (-not (Test-Path -LiteralPath $certificatePath)) {
            Write-AccountsBootstrapLog "The approved certificate is not trusted in $store. Installation deferred."
            exit 12
        }
    }

    $setupSignature = Get-AuthenticodeSignature -LiteralPath $setupPath
    if ($setupSignature.Status -ne [Management.Automation.SignatureStatus]::Valid -or
        $null -eq $setupSignature.SignerCertificate -or
        -not [string]::Equals(
            $setupSignature.SignerCertificate.Thumbprint,
            $expectedCertificateThumbprint,
            [StringComparison]::OrdinalIgnoreCase)) {
        throw 'The live ClickOnce setup is not signed by the approved certificate.'
    }

    $shortcutRoots = @(
        [Environment]::GetFolderPath('Desktop'),
        [Environment]::GetFolderPath('Programs')
    ) | Select-Object -Unique
    foreach ($shortcutRoot in $shortcutRoots) {
        if (-not (Test-Path -LiteralPath $shortcutRoot -PathType Container)) {
            continue
        }

        $applicationReferences = Get-ChildItem `
            -LiteralPath $shortcutRoot `
            -Recurse `
            -File `
            -Filter '*.appref-ms' `
            -ErrorAction SilentlyContinue
        foreach ($applicationReference in $applicationReferences) {
            $referenceText = Get-Content -LiteralPath $applicationReference.FullName -Raw -ErrorAction SilentlyContinue
            if ($referenceText -match [regex]::Escape($expectedPublicKeyToken) -and
                $referenceText -match '(?i)Accounts\.application') {
                Write-AccountsBootstrapLog "Approved signed ClickOnce application is already installed: $($applicationReference.FullName)"
                exit 0
            }
        }
    }

    Write-AccountsBootstrapLog "Launching signed Accounts ClickOnce installation from $setupPath"
    Start-Process -FilePath $setupPath
    exit 0
}
catch {
    Write-AccountsBootstrapLog ('Installation bootstrap failed: ' + $_.Exception.Message)
    exit 20
}

# SIG # Begin signature block
# MIIHWgYJKoZIhvcNAQcCoIIHSzCCB0cCAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCAq0vW7ssP3kcwD
# TbOesVqp0Xtscywgo4nVZV9q2/q/vKCCBDgwggQ0MIICnKADAgECAhAt4bV0Br4H
# pEC7wNHH03P+MA0GCSqGSIb3DQEBCwUAMDIxDTALBgNVBAoMBEFBVE0xITAfBgNV
# BAMMGEFBVE0gU29mdHdhcmUgUHVibGlzaGluZzAeFw0yNjA5MjQwOTAxMDRaFw0z
# MTA5MjQwOTExMDNaMDIxDTALBgNVBAoMBEFBVE0xITAfBgNVBAMMGEFBVE0gU29m
# dHdhcmUgUHVibGlzaGluZzCCAaIwDQYJKoZIhvcNAQEBBQADggGPADCCAYoCggGB
# AJZvJVuktrXq6wdvGT3LH68wW1zZ+Yvn6/WCPjielb9s1toh0xeqlkBo9syG6pyc
# qhKYhjcokhgWzAEegYap6l2LuyDpz2EoDFTh2tBuHQHzidoQDGtyXPA3I9OQOmrK
# 2iWow1HPVY7YwYNbUB6jK/i7ZXGD4mMKzngbWqMVYT0nnknJVJKPPRHXwfAopNiN
# /OoLQHz6j5XPFrdKGll8SUG+l3PLZ3mhNZHCdRIMtQ7yWjktyW63JkqigPD70nDQ
# +/XoGPOCRqWPF4n80Tqs/Z9ZrjTMPrvW4EJLmQNH2uIgLDVYtXZHNgHqYxAE6+TM
# 1EbBHtbUXjYrBV/kvBX+POWVaoHFqRXuUKWrKczo3PEDffEuQfyacuGlbDL+gMHs
# UWuq3lrJstAQq2m6ydNttOGFmase/1LKitEpVxDBENfxDMwQXPuIdQFvxJcmLwtB
# 12m5ZI/p5tS2ahVor3Q9yVx3muyRxnCFpeXSizFbcFl+y70yjHMvGchkJt4X0oq7
# xQIDAQABo0YwRDAOBgNVHQ8BAf8EBAMCB4AwEwYDVR0lBAwwCgYIKwYBBQUHAwMw
# HQYDVR0OBBYEFOjptGlsZ3Zea/0rd4hXVavvveyiMA0GCSqGSIb3DQEBCwUAA4IB
# gQAQa0DhBVcw6EDSkaOUr2u6yBJVtiYLLydGbVR9O3iD+8Y+cXvxmXijHs+ek0tC
# gVVP6OGtN+U1CtoIpSWPLBgQnWiHfinzZMNIKGFuu1GO12qpz+mo3eBa2gomunIe
# HvQMfD7yQDteaHA2fXKOfVr3OS4HxkSxSssNoqYg/u0r4uJW2fFCpcw1epZhk1ER
# z6NYtSs7vNRjAUPdZEubPHPp2SUKqi2Tsq4ngQ1tD7ptVlEtuV1Y26dhRDJ/ooo0
# CmpNa2keB6ZDT0filVZmeKZ8k8Ar5g+vFWi4oy+6j63ddKxwKu3n9x+z9TZvf22m
# HCwx9XzuRwKSYd1Ik9+0PUnYFgeZOGZ4OJEE10YIfQQXhJN/O2pPaSPFqZKk1el6
# I7M2N4djf0xXEmJisW2XL413Vh1v9DtnrgiKSBGjbiRAMpbDfli0AsptglHE5UIE
# RaRZ3ml+goPXqjqU6sMCLOmHUYKUQMB4XokR/PW8LavKMOwEpS69/gdhRbkf/mgv
# i5cxggJ4MIICdAIBATBGMDIxDTALBgNVBAoMBEFBVE0xITAfBgNVBAMMGEFBVE0g
# U29mdHdhcmUgUHVibGlzaGluZwIQLeG1dAa+B6RAu8DRx9Nz/jANBglghkgBZQME
# AgEFAKCBhDAYBgorBgEEAYI3AgEMMQowCKACgAChAoAAMBkGCSqGSIb3DQEJAzEM
# BgorBgEEAYI3AgEEMBwGCisGAQQBgjcCAQsxDjAMBgorBgEEAYI3AgEVMC8GCSqG
# SIb3DQEJBDEiBCDGOlYV3YPSz4qvMfXTcMxj2t75854vaGHtHu3lBG45DzANBgkq
# hkiG9w0BAQEFAASCAYAGa5JzhXYavB7IHH4tquUsa7lh30KhQDGqaEndT/a4ybW3
# oMtqBBPqe8GnP+d6taENxObcVWs7R3sks40d2tjF+tlggJWbKgsPkCd1IDob0K7a
# mCfVAq+P7mu1qX5BEjzGIGA5PPZNjM1w9KaU03o+AHggl5q8n606t3Ezhdv83cC9
# nNm6twfrdmvJRHaIlr4M5RrUyBmzPM4n4tryCFQsRJLUI9aUqb++1n71cwBga6tI
# Kg3IaqnoJcYOdRjgReraXc/0VLvOUj+Iel26YxI6RjReyn4HN9/eAYz+pgCt3/gn
# M0dtrT4iaJiiX7LHyRS8BV89p8qJFHApaXFzCeIvb0zc3t+jj4AlMJ09r/Qbgvrz
# 0Twu+hbLaQsfEW+eBtn3RZ5CFd8PwQQ+KSfxCc0u8NP7XlKCvq2SWFpNozUtSQVz
# re1vsl/AruQnSJo4OZ7HsmCGjW7hq/pwml5Tiz5GxJ3dvzsf9EhC3WW56ZQpTy/Q
# L22GVmRscbgImzwzkHc=
# SIG # End signature block
