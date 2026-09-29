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
    $approvedShortcut = $null
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
                $approvedShortcut = $applicationReference.FullName
                break
            }
        }
        if ($null -ne $approvedShortcut) {
            break
        }
    }

    $installedVersion = $null
    $uninstallRegistryPath = 'HKCU:\Software\Microsoft\Windows\CurrentVersion\Uninstall'
    if (Test-Path -LiteralPath $uninstallRegistryPath) {
        foreach ($uninstallKey in Get-ChildItem -LiteralPath $uninstallRegistryPath -ErrorAction SilentlyContinue) {
            $installedApplication = Get-ItemProperty -LiteralPath $uninstallKey.PSPath -ErrorAction SilentlyContinue
            if (-not [string]::Equals(
                    [string]$installedApplication.DisplayName,
                    'Clinic Information System',
                    [StringComparison]::OrdinalIgnoreCase) -or
                -not [string]::Equals(
                    [string]$installedApplication.Publisher,
                    'AATM Software',
                    [StringComparison]::OrdinalIgnoreCase)) {
                continue
            }

            $candidateVersion = [version]'0.0.0.0'
            if ([version]::TryParse([string]$installedApplication.DisplayVersion, [ref]$candidateVersion) -and
                ($null -eq $installedVersion -or $candidateVersion -gt $installedVersion)) {
                $installedVersion = $candidateVersion
            }
        }
    }

    if ($null -ne $approvedShortcut -and $null -ne $installedVersion) {
        if ($installedVersion -eq $liveVersion) {
            Write-AccountsBootstrapLog "Approved ClickOnce installation is current at version ${installedVersion}: $approvedShortcut"
            exit 0
        }
        if ($installedVersion -gt $liveVersion) {
            Write-AccountsBootstrapLog (
                "Installed version $installedVersion is newer than live version $liveVersion; refusing to downgrade. Shortcut=$approvedShortcut")
            exit 0
        }

        Write-AccountsBootstrapLog (
            "Installed version $installedVersion is behind live version $liveVersion; launching ClickOnce update from $setupPath")
    }
    elseif ($null -ne $approvedShortcut) {
        Write-AccountsBootstrapLog (
            "Found an approved shortcut but could not read its installed version; launching ClickOnce repair from $setupPath. Shortcut=$approvedShortcut")
    }
    else {
        Write-AccountsBootstrapLog "No approved ClickOnce shortcut was found; launching installation from $setupPath"
    }

    Write-AccountsBootstrapLog "Launching signed Accounts ClickOnce installer from $setupPath"
    Start-Process -FilePath $setupPath
    exit 0
}
catch {
    Write-AccountsBootstrapLog ('Installation bootstrap failed: ' + $_.Exception.Message)
    exit 20
}

# SIG # Begin signature block
# MIIdvgYJKoZIhvcNAQcCoIIdrzCCHasCAQExDzANBglghkgBZQMEAgEFADB5Bgor
# BgEEAYI3AgEEoGswaTA0BgorBgEEAYI3AgEeMCYCAwEAAAQQH8w7YFlLCE63JNLG
# KX7zUQIBAAIBAAIBAAIBAAIBADAxMA0GCWCGSAFlAwQCAQUABCADmvkIDzGMlrG7
# kazEc3mHrNQhw7a1lEsaelKJi17B3qCCF3IwggQ0MIICnKADAgECAhAt4bV0Br4H
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
# i5cwggWNMIIEdaADAgECAhAOmxiO+dAt5+/bUOIIQBhaMA0GCSqGSIb3DQEBDAUA
# MGUxCzAJBgNVBAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsT
# EHd3dy5kaWdpY2VydC5jb20xJDAiBgNVBAMTG0RpZ2lDZXJ0IEFzc3VyZWQgSUQg
# Um9vdCBDQTAeFw0yMjA4MDEwMDAwMDBaFw0zMTExMDkyMzU5NTlaMGIxCzAJBgNV
# BAYTAlVTMRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdp
# Y2VydC5jb20xITAfBgNVBAMTGERpZ2lDZXJ0IFRydXN0ZWQgUm9vdCBHNDCCAiIw
# DQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAL/mkHNo3rvkXUo8MCIwaTPswqcl
# LskhPfKK2FnC4SmnPVirdprNrnsbhA3EMB/zG6Q4FutWxpdtHauyefLKEdLkX9YF
# PFIPUh/GnhWlfr6fqVcWWVVyr2iTcMKyunWZanMylNEQRBAu34LzB4TmdDttceIt
# DBvuINXJIB1jKS3O7F5OyJP4IWGbNOsFxl7sWxq868nPzaw0QF+xembud8hIqGZX
# V59UWI4MK7dPpzDZVu7Ke13jrclPXuU15zHL2pNe3I6PgNq2kZhAkHnDeMe2scS1
# ahg4AxCN2NQ3pC4FfYj1gj4QkXCrVYJBMtfbBHMqbpEBfCFM1LyuGwN1XXhm2Tox
# RJozQL8I11pJpMLmqaBn3aQnvKFPObURWBf3JFxGj2T3wWmIdph2PVldQnaHiZdp
# ekjw4KISG2aadMreSx7nDmOu5tTvkpI6nj3cAORFJYm2mkQZK37AlLTSYW3rM9nF
# 30sEAMx9HJXDj/chsrIRt7t/8tWMcCxBYKqxYxhElRp2Yn72gLD76GSmM9GJB+G9
# t+ZDpBi4pncB4Q+UDCEdslQpJYls5Q5SUUd0viastkF13nqsX40/ybzTQRESW+UQ
# UOsxxcpyFiIJ33xMdT9j7CFfxCBRa2+xq4aLT8LWRV+dIPyhHsXAj6KxfgommfXk
# aS+YHS312amyHeUbAgMBAAGjggE6MIIBNjAPBgNVHRMBAf8EBTADAQH/MB0GA1Ud
# DgQWBBTs1+OC0nFdZEzfLmc/57qYrhwPTzAfBgNVHSMEGDAWgBRF66Kv9JLLgjEt
# UYunpyGd823IDzAOBgNVHQ8BAf8EBAMCAYYweQYIKwYBBQUHAQEEbTBrMCQGCCsG
# AQUFBzABhhhodHRwOi8vb2NzcC5kaWdpY2VydC5jb20wQwYIKwYBBQUHMAKGN2h0
# dHA6Ly9jYWNlcnRzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEFzc3VyZWRJRFJvb3RD
# QS5jcnQwRQYDVR0fBD4wPDA6oDigNoY0aHR0cDovL2NybDMuZGlnaWNlcnQuY29t
# L0RpZ2lDZXJ0QXNzdXJlZElEUm9vdENBLmNybDARBgNVHSAECjAIMAYGBFUdIAAw
# DQYJKoZIhvcNAQEMBQADggEBAHCgv0NcVec4X6CjdBs9thbX979XB72arKGHLOyF
# XqkauyL4hxppVCLtpIh3bb0aFPQTSnovLbc47/T/gLn4offyct4kvFIDyE7QKt76
# LVbP+fT3rDB6mouyXtTP0UNEm0Mh65ZyoUi0mcudT6cGAxN3J0TU53/oWajwvy8L
# punyNDzs9wPHh6jSTEAZNUZqaVSwuKFWjuyk1T3osdz9HNj0d1pcVIxv76FQPfx2
# CWiEn2/K2yCNNWAcAgPLILCsWKAOQGPFmCLBsln1VWvPJ6tsds5vIy30fnFqI2si
# /xK4VC0nftg62fC2h5b9W9FcrBjDTZ9ztwGpn1eqXijiuZQwgga0MIIEnKADAgEC
# AhANx6xXBf8hmS5AQyIMOkmGMA0GCSqGSIb3DQEBCwUAMGIxCzAJBgNVBAYTAlVT
# MRUwEwYDVQQKEwxEaWdpQ2VydCBJbmMxGTAXBgNVBAsTEHd3dy5kaWdpY2VydC5j
# b20xITAfBgNVBAMTGERpZ2lDZXJ0IFRydXN0ZWQgUm9vdCBHNDAeFw0yNTA1MDcw
# MDAwMDBaFw0zODAxMTQyMzU5NTlaMGkxCzAJBgNVBAYTAlVTMRcwFQYDVQQKEw5E
# aWdpQ2VydCwgSW5jLjFBMD8GA1UEAxM4RGlnaUNlcnQgVHJ1c3RlZCBHNCBUaW1l
# U3RhbXBpbmcgUlNBNDA5NiBTSEEyNTYgMjAyNSBDQTEwggIiMA0GCSqGSIb3DQEB
# AQUAA4ICDwAwggIKAoICAQC0eDHTCphBcr48RsAcrHXbo0ZodLRRF51NrY0NlLWZ
# loMsVO1DahGPNRcybEKq+RuwOnPhof6pvF4uGjwjqNjfEvUi6wuim5bap+0lgloM
# 2zX4kftn5B1IpYzTqpyFQ/4Bt0mAxAHeHYNnQxqXmRinvuNgxVBdJkf77S2uPoCj
# 7GH8BLuxBG5AvftBdsOECS1UkxBvMgEdgkFiDNYiOTx4OtiFcMSkqTtF2hfQz3zQ
# Sku2Ws3IfDReb6e3mmdglTcaarps0wjUjsZvkgFkriK9tUKJm/s80FiocSk1VYLZ
# lDwFt+cVFBURJg6zMUjZa/zbCclF83bRVFLeGkuAhHiGPMvSGmhgaTzVyhYn4p0+
# 8y9oHRaQT/aofEnS5xLrfxnGpTXiUOeSLsJygoLPp66bkDX1ZlAeSpQl92QOMeRx
# ykvq6gbylsXQskBBBnGy3tW/AMOMCZIVNSaz7BX8VtYGqLt9MmeOreGPRdtBx3yG
# OP+rx3rKWDEJlIqLXvJWnY0v5ydPpOjL6s36czwzsucuoKs7Yk/ehb//Wx+5kMqI
# MRvUBDx6z1ev+7psNOdgJMoiwOrUG2ZdSoQbU2rMkpLiQ6bGRinZbI4OLu9BMIFm
# 1UUl9VnePs6BaaeEWvjJSjNm2qA+sdFUeEY0qVjPKOWug/G6X5uAiynM7Bu2ayBj
# UwIDAQABo4IBXTCCAVkwEgYDVR0TAQH/BAgwBgEB/wIBADAdBgNVHQ4EFgQU729T
# SunkBnx6yuKQVvYv1Ensy04wHwYDVR0jBBgwFoAU7NfjgtJxXWRM3y5nP+e6mK4c
# D08wDgYDVR0PAQH/BAQDAgGGMBMGA1UdJQQMMAoGCCsGAQUFBwMIMHcGCCsGAQUF
# BwEBBGswaTAkBggrBgEFBQcwAYYYaHR0cDovL29jc3AuZGlnaWNlcnQuY29tMEEG
# CCsGAQUFBzAChjVodHRwOi8vY2FjZXJ0cy5kaWdpY2VydC5jb20vRGlnaUNlcnRU
# cnVzdGVkUm9vdEc0LmNydDBDBgNVHR8EPDA6MDigNqA0hjJodHRwOi8vY3JsMy5k
# aWdpY2VydC5jb20vRGlnaUNlcnRUcnVzdGVkUm9vdEc0LmNybDAgBgNVHSAEGTAX
# MAgGBmeBDAEEAjALBglghkgBhv1sBwEwDQYJKoZIhvcNAQELBQADggIBABfO+xaA
# HP4HPRF2cTC9vgvItTSmf83Qh8WIGjB/T8ObXAZz8OjuhUxjaaFdleMM0lBryPTQ
# M2qEJPe36zwbSI/mS83afsl3YTj+IQhQE7jU/kXjjytJgnn0hvrV6hqWGd3rLAUt
# 6vJy9lMDPjTLxLgXf9r5nWMQwr8Myb9rEVKChHyfpzee5kH0F8HABBgr0UdqirZ7
# bowe9Vj2AIMD8liyrukZ2iA/wdG2th9y1IsA0QF8dTXqvcnTmpfeQh35k5zOCPmS
# Nq1UH410ANVko43+Cdmu4y81hjajV/gxdEkMx1NKU4uHQcKfZxAvBAKqMVuqte69
# M9J6A47OvgRaPs+2ykgcGV00TYr2Lr3ty9qIijanrUR3anzEwlvzZiiyfTPjLbnF
# RsjsYg39OlV8cipDoq7+qNNjqFzeGxcytL5TTLL4ZaoBdqbhOhZ3ZRDUphPvSRmM
# Thi0vw9vODRzW6AxnJll38F0cuJG7uEBYTptMSbhdhGQDpOXgpIUsWTjd6xpR6oa
# Qf/DJbg3s6KCLPAlZ66RzIg9sC+NJpud/v4+7RWsWCiKi9EOLLHfMR2ZyJ/+xhCx
# 9yHbxtl5TPau1j/1MIDpMPx0LckTetiSuEtQvLsNz3Qbp7wGWqbIiOWCnb5WqxL3
# /BAPvIXKUjPSxyZsq8WhbaM2tszWkPZPubdcMIIG7TCCBNWgAwIBAgIQCE/cM09+
# RU7bww+P+ZIYNTANBgkqhkiG9w0BAQsFADBpMQswCQYDVQQGEwJVUzEXMBUGA1UE
# ChMORGlnaUNlcnQsIEluYy4xQTA/BgNVBAMTOERpZ2lDZXJ0IFRydXN0ZWQgRzQg
# VGltZVN0YW1waW5nIFJTQTQwOTYgU0hBMjU2IDIwMjUgQ0ExMB4XDTI2MDgwNTAw
# MDAwMFoXDTM3MTEwNDIzNTk1OVowYzELMAkGA1UEBhMCVVMxFzAVBgNVBAoTDkRp
# Z2lDZXJ0LCBJbmMuMTswOQYDVQQDEzJEaWdpQ2VydCBTSEEyNTYgUlNBNDA5NiBU
# aW1lc3RhbXAgUmVzcG9uZGVyIDIwMjYgMTCCAiIwDQYJKoZIhvcNAQEBBQADggIP
# ADCCAgoCggIBALZ7pvLJ/s1K+NSbTGWz/TjGMPh8CQ6RucZCLv5anHzWJjF/NWJr
# FIhy24fcpKXlgRiky4WAawDfU3YP0BMxt9l3Dm5oCG5Z69AqEN1kgHg2epx+l+lZ
# BcmJCcN0ASURML5uFIS80sZsDwO3BSkUxDjLJhBI+qiZP3aixAC/qEGLjsBNlLol
# 9VZ7pfGEXiMlneJIC5/YKuizVzNFKZZEeoy/0B8Zm+nzKBgSWG52lCO1w+nCg6Xp
# CtklTJXeIg283hw7TmmsZXR+SMbjbrEOvZ3fP2VxIgeR28Y90ZStd3F9VuA5RVyn
# b/whITPAo9b75Zr4Ta6Mj3URm26QZYMn/FnbuTegcoRcFEZ9FOqM5T6MTdtr/n74
# lIT/ug0eeOzmZ6QTFg33otX+bFRsIolvykE1jive4PuESaT8zzVeFWDAMDtozNgL
# ctkGD1ZjkEyZtJrLl5ya0m5doH/ScpaZCZVl6pNUOCybMc/kxC6EAmSJY24L0yYK
# D1Nkddsnb/ItVKi/2nXpQNMu1PT5prW83vV8d67WowuUs0HdY4H8AMLGvdL/WHEj
# 3ZnqMqAQQP9u3Ai9t+5eQ02GDwy0ODjdzi0xlp70W+ow63/0++YDEX1M0iwgUHwb
# rJvfpklkZQvw3+kv3vUPItdwroczk9icflf55W1zOEKAcJVAIXpcMCU9AgMBAAGj
# ggGVMIIBkTAMBgNVHRMBAf8EAjAAMB0GA1UdDgQWBBQUyWOKMC7USvtulPPm40B+
# 9ezN4jAfBgNVHSMEGDAWgBTvb1NK6eQGfHrK4pBW9i/USezLTjAOBgNVHQ8BAf8E
# BAMCB4AwFgYDVR0lAQH/BAwwCgYIKwYBBQUHAwgwgZUGCCsGAQUFBwEBBIGIMIGF
# MCQGCCsGAQUFBzABhhhodHRwOi8vb2NzcC5kaWdpY2VydC5jb20wXQYIKwYBBQUH
# MAKGUWh0dHA6Ly9jYWNlcnRzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydFRydXN0ZWRH
# NFRpbWVTdGFtcGluZ1JTQTQwOTZTSEEyNTYyMDI1Q0ExLmNydDBfBgNVHR8EWDBW
# MFSgUqBQhk5odHRwOi8vY3JsMy5kaWdpY2VydC5jb20vRGlnaUNlcnRUcnVzdGVk
# RzRUaW1lU3RhbXBpbmdSU0E0MDk2U0hBMjU2MjAyNUNBMS5jcmwwIAYDVR0gBBkw
# FzAIBgZngQwBBAIwCwYJYIZIAYb9bAcBMA0GCSqGSIb3DQEBCwUAA4ICAQCNxTph
# Hp1SCt+ZrAmAfn0oQLFr0mLywSLaDXQIENoyKqxrFbJblzCVP/pkXmwXOdrOpWyg
# LzlT12os5ipDCy35RBCg2UMeApEtrfGhz45F4Wt4WGdNdIbRWt3YTYJmpR+b7lr4
# d7Uwn+H600u4D7RnOGf8Wj4UNgAdZkfHhHv1mx9EVh71SJelcEN/oORSjXzdjfw1
# iZH9d8Nh/thn6hH23d+VsPAr6GAYyzSA02nXD1nYLI7Ijmiv+xLCiYC41DSFYL3G
# hTiy0PxpawPtGRyaBVGzq+UiTfM8pD7KVyF5aQyWP4KhVGUUTnmm/RlYJoW3TiXA
# /+t0YcT2oRVBm3JETjajHug2AL+v5jhtKVnd3D0rbHXEu27o+Q8p4sEWPMqKDB+q
# bceb6T/6WcwTwXmQ9lOCLLYcsQeSWmvKqzpAec9etE14jOQAzLKWdE3w/TCaKtLR
# aRT7LCkRYVnhA2D73FLje1O5b3HR5eHs0NzU/+xX7NbEdcofy0W3Wdwd1XOqtlpg
# /JgwtKfZM5dqO94lbUveOiJBI+xZEbGRsMNbXmMREUTgu+Oca7Y73MPWcslIx2Vh
# kSKSXjDbD6rgg39H5Mh7QfieAIjWagkJNt68Yfim6cjEzVSiLSeZfdkr5dtFPTW6
# jATlWJdYeeDRGCyatf8R1hSjzSvdN8yWQPT9gzGCBaIwggWeAgEBMEYwMjENMAsG
# A1UECgwEQUFUTTEhMB8GA1UEAwwYQUFUTSBTb2Z0d2FyZSBQdWJsaXNoaW5nAhAt
# 4bV0Br4HpEC7wNHH03P+MA0GCWCGSAFlAwQCAQUAoIGEMBgGCisGAQQBgjcCAQwx
# CjAIoAKAAKECgAAwGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcCAQQwHAYKKwYBBAGC
# NwIBCzEOMAwGCisGAQQBgjcCARUwLwYJKoZIhvcNAQkEMSIEIDRmrMea+r9mx90d
# msxFpyjmgz9EuLXUdzx5x6sXZ/xwMA0GCSqGSIb3DQEBAQUABIIBgCKozf5ygoZc
# rARhw3S3QZceyHk5mx2m9dVG20VFZZsBnBLaJHHCJ7xHpFRHjUHpwt4rrgmDx0Op
# zgaNJChaEGQ+kXiaafcfbFXLQYS1QN7kxV2VZQtBPX7Rz2D6GOFLUBpP0sQa/pmb
# RXVbi4Cy0nQD52V3XHf6ZLqTItdobV2PN8iRDxq+a+ZptElEpQSeVXoDlqx3dZcd
# urdq3qzGV1oMYv0IM/sd3h7luDIQBxHDzvX319JWJOqN64UPFAgXodExaxLUGgwB
# 96AQLfMfLanG/wKLkh1IG9Vw8f1lkbGS7zOJsWoPouzgcLkO1Pzmzv1SEQeggHkh
# p3QoL0pOhmLqFb5TgIFTzoad1/TK/D1jyHaGDukuyxy+hXPYu2FapeMWuJhWl8ct
# AZ13o3vWV34j8P1o8IbZUISy6plPfL1lv2C/r0c9WNLzwdfStfRAkxmSz3paDISm
# 1OJQ3i6mvneFAdYFTSVDt5euZwDQqLbvPYgIs/2jAxqq3nKfPNBej6GCAyYwggMi
# BgkqhkiG9w0BCQYxggMTMIIDDwIBATB9MGkxCzAJBgNVBAYTAlVTMRcwFQYDVQQK
# Ew5EaWdpQ2VydCwgSW5jLjFBMD8GA1UEAxM4RGlnaUNlcnQgVHJ1c3RlZCBHNCBU
# aW1lU3RhbXBpbmcgUlNBNDA5NiBTSEEyNTYgMjAyNSBDQTECEAhP3DNPfkVO28MP
# j/mSGDUwDQYJYIZIAWUDBAIBBQCgaTAYBgkqhkiG9w0BCQMxCwYJKoZIhvcNAQcB
# MBwGCSqGSIb3DQEJBTEPFw0yNjA5MjkwOTAzNDNaMC8GCSqGSIb3DQEJBDEiBCDD
# ZNHQWer1wAeKlfoc9K7SAcguLqAdQrHsP7R5ipOWbzANBgkqhkiG9w0BAQEFAASC
# AgBC0aoHC1K0TF76jRLldAlIQjFI5alZDeOI9Dfm/2yhz6+d0F+g7n538la6WGli
# 5oZKiRJhdxpz2h+uH5nGSdyLrQQvSp+/Aa9EUrK+nkoHe3mOeBMUaaSduaId6SH9
# hgRtSPFBbcZFVgeqaIvAy63nder/5+DQbmsmhCoB1dNs+BRSpFwKNUdWtQSHQHyk
# feAe5VD1yMI9JKk/wZJbA5M7U/MalReIN9W8E3p56326mAY0uA7bDCL5IZJBhzJD
# vytfSoMKWRHcJyo6uT5yU0EAYZwUNzHfVlL8H5UJetKDGQ238pB1rtdKMPLAF7Ao
# 8RxJrrNAZ8zioreglZZwOWCFcnjP6xxHtuSy8iOsp0T0k2IzIbp5mgjlP8q/4EO/
# JJqzVHtQ31IHfpiSEUAEBTwzQFrTw7i5Z1tgED73xLwq2Zgs30vGpx3A/8sbxRI2
# G2/zafkVX3nO1C3FgLgvEVvs0FJ47zgPLbMqOOWiEMFAtegy/irjkzzsEUBtrH5I
# moVYT1YGqPHOQAjft+MTiKNnPIlFKLmgkUgNM3RT4ZRXjm02xs0lkN3v8FUWSp7z
# 4JBQFBJpzZzknMmr4hQDvk5hbVkQUsBVeltBenNGhd5Mlp/qtOReuqGgLPMv5Ork
# vgEbX2XOvF74vR5foK87u0FjyAVQ49Z1A7OkjAmNCtNjOg==
# SIG # End signature block
