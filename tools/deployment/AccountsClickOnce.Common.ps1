Set-StrictMode -Version Latest

function Get-AccountsRepositoryRoot {
    return (Split-Path -Parent (Split-Path -Parent $PSScriptRoot))
}

function Get-AccountsMsBuildPath {
    $command = Get-Command MSBuild.exe -ErrorAction SilentlyContinue
    if ($null -ne $command) {
        return $command.Source
    }

    $vsWhere = Join-Path ${env:ProgramFiles(x86)} 'Microsoft Visual Studio\Installer\vswhere.exe'
    if (Test-Path -LiteralPath $vsWhere -PathType Leaf) {
        $candidate = & $vsWhere -latest -products * -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' |
            Select-Object -First 1
        if (-not [string]::IsNullOrWhiteSpace($candidate)) {
            return $candidate
        }
    }

    throw 'MSBuild.exe was not found. Install Visual Studio 2022 with the .NET desktop workload.'
}

function Get-AccountsVersionToken {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Version
    )

    return $Version.Replace('.', '_')
}

function Get-AccountsStagingDirectory {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Version
    )

    $repoRoot = Get-AccountsRepositoryRoot
    $versionToken = Get-AccountsVersionToken -Version $Version
    return (Join-Path $repoRoot ("Publish\Accounts_{0}_staging" -f $versionToken))
}

function Get-ExpectedAccountsDeploymentProvider {
    return 'file://ibn-server/isp/COAccounts/Accounts.application'
}

function Assert-AccountsLiveConfiguration {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Path
    )

    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "Accounts configuration was not found: $Path"
    }

    $raw = [System.IO.File]::ReadAllText($Path)
    if ([regex]::IsMatch($raw, 'ISPADMIN2|AUDITTEST', [Text.RegularExpressions.RegexOptions]::IgnoreCase)) {
        throw "A test server reference was found in: $Path"
    }

    try {
        [xml]$configuration = $raw
    }
    catch {
        throw "Accounts configuration is not valid XML: $Path"
    }

    $appSettings = @{}
    foreach ($setting in @($configuration.configuration.appSettings.add)) {
        $appSettings[[string]$setting.key] = [string]$setting.value
    }

    if (-not $appSettings.ContainsKey('ServerTranslator') -or
        -not [string]::Equals($appSettings['ServerTranslator'], 'IBN-SERVER', [StringComparison]::OrdinalIgnoreCase)) {
        throw "ServerTranslator does not target IBN-SERVER in: $Path"
    }
    if (-not $appSettings.ContainsKey('DATABASE') -or
        -not [string]::Equals($appSettings['DATABASE'], 'ISPDATA', [StringComparison]::OrdinalIgnoreCase)) {
        throw "DATABASE does not target ISPDATA in: $Path"
    }

    $requiredConnectionNames = @(
        'ISPDATA',
        'AATM.ISPHIS.My.MySettings.ISPDATAConnectionString'
    )
    foreach ($connectionName in $requiredConnectionNames) {
        $connection = @($configuration.configuration.connectionStrings.add) |
            Where-Object { [string]$_.name -eq $connectionName } |
            Select-Object -First 1
        if ($null -eq $connection) {
            throw "Required connection string '$connectionName' is missing from: $Path"
        }

        try {
            $builder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder([string]$connection.connectionString)
        }
        catch {
            throw "Connection string '$connectionName' could not be parsed in: $Path"
        }

        if (-not [string]::Equals($builder.DataSource, 'IBN-SERVER', [StringComparison]::OrdinalIgnoreCase) -or
            -not [string]::Equals($builder.InitialCatalog, 'ISPDATA', [StringComparison]::OrdinalIgnoreCase)) {
            throw "Connection '$connectionName' does not target IBN-SERVER.ISPDATA in: $Path"
        }
    }
}

function Assert-AccountsClickOnceManifestSignature {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Path,

        [Parameter(Mandatory = $true)]
        [ValidatePattern('^[0-9A-Fa-f]{40}$')]
        [string]$CertificateThumbprint
    )

    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "ClickOnce manifest was not found: $Path"
    }

    try {
        [xml]$manifest = Get-Content -LiteralPath $Path -Raw
    }
    catch {
        throw "ClickOnce manifest is not valid XML: $Path"
    }

    $certificateNodes = @($manifest.SelectNodes('//*[local-name()="X509Certificate"]'))
    if ($certificateNodes.Count -eq 0) {
        throw "ClickOnce manifest is not signed: $Path"
    }

    $expectedThumbprint = $CertificateThumbprint.ToUpperInvariant()
    $matchingCertificate = $false
    foreach ($certificateNode in $certificateNodes) {
        try {
            $certificateBytes = [Convert]::FromBase64String($certificateNode.InnerText)
            $certificate = New-Object Security.Cryptography.X509Certificates.X509Certificate2(,$certificateBytes)
            if ([string]::Equals(
                    $certificate.Thumbprint,
                    $expectedThumbprint,
                    [StringComparison]::OrdinalIgnoreCase)) {
                $matchingCertificate = $true
                break
            }
        }
        catch {
            throw "A signing certificate embedded in the manifest is invalid: $Path"
        }
    }

    if (-not $matchingCertificate) {
        throw "ClickOnce manifest was not signed by certificate $expectedThumbprint`: $Path"
    }

    $mageCommand = Get-Command mage.exe -ErrorAction SilentlyContinue
    if ($null -eq $mageCommand) {
        throw 'mage.exe was not found. Install the .NET Framework SDK manifest tools.'
    }

    $verificationOutput = & $mageCommand.Source -Verify $Path 2>&1
    if ($LASTEXITCODE -ne 0) {
        throw "mage.exe rejected the ClickOnce manifest '$Path': $($verificationOutput -join ' ')"
    }
}

function Get-AccountsClickOncePackage {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Root,

        [Parameter(Mandatory = $true)]
        [string]$Version,

        [switch]$RequiredUpdate
    )

    $manifestPath = Join-Path $Root 'Accounts.application'
    $setupPath = Join-Path $Root 'setup.exe'
    $versionToken = Get-AccountsVersionToken -Version $Version
    $versionDirectory = Join-Path $Root ("Application Files\Accounts_{0}" -f $versionToken)
    $configurationPath = Join-Path $versionDirectory 'Accounts.exe.config.deploy'

    foreach ($requiredFile in @($manifestPath, $setupPath, $configurationPath)) {
        if (-not (Test-Path -LiteralPath $requiredFile -PathType Leaf)) {
            throw "Required ClickOnce file was not found: $requiredFile"
        }
    }
    if (-not (Test-Path -LiteralPath $versionDirectory -PathType Container)) {
        throw "ClickOnce version directory was not found: $versionDirectory"
    }

    try {
        [xml]$manifest = Get-Content -LiteralPath $manifestPath -Raw
    }
    catch {
        throw "ClickOnce deployment manifest is not valid XML: $manifestPath"
    }

    $identity = $manifest.SelectSingleNode('/*[local-name()="assembly"]/*[local-name()="assemblyIdentity"]')
    $deployment = $manifest.SelectSingleNode('/*[local-name()="assembly"]/*[local-name()="deployment"]')
    $provider = $manifest.SelectSingleNode('/*[local-name()="assembly"]/*[local-name()="deployment"]/*[local-name()="deploymentProvider"]')
    if ($null -eq $identity -or $null -eq $deployment -or $null -eq $provider) {
        throw "ClickOnce deployment metadata is incomplete: $manifestPath"
    }
    if (-not [string]::Equals([string]$identity.version, $Version, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Manifest version '$($identity.version)' does not match requested version '$Version'."
    }

    $expectedProvider = Get-ExpectedAccountsDeploymentProvider
    if (-not [string]::Equals([string]$provider.codebase, $expectedProvider, [StringComparison]::OrdinalIgnoreCase)) {
        throw "Deployment provider '$($provider.codebase)' does not match '$expectedProvider'."
    }

    $manifestText = [System.IO.File]::ReadAllText($manifestPath)
    if ($manifestText -notmatch 'createDesktopShortcut="true"') {
        throw 'The ClickOnce package is not configured to create the desktop shortcut.'
    }
    if ($manifestText -notmatch '<beforeApplicationStartup\s*/>') {
        throw 'The ClickOnce package is not configured to check for updates before startup.'
    }
    $minimumRequiredVersionText = $deployment.GetAttribute('minimumRequiredVersion')
    if ($RequiredUpdate -and
        -not [string]::Equals($minimumRequiredVersionText, $Version, [StringComparison]::OrdinalIgnoreCase)) {
        throw "The package does not require minimum version '$Version'."
    }

    Assert-AccountsLiveConfiguration -Path $configurationPath

    $payloadFiles = @(Get-ChildItem -LiteralPath $versionDirectory -Recurse -File)
    if ($payloadFiles.Count -eq 0) {
        throw "ClickOnce version directory is empty: $versionDirectory"
    }

    return [pscustomobject]@{
        Root = $Root
        Version = [version]$Version
        MinimumRequiredVersion = if ([string]::IsNullOrWhiteSpace($minimumRequiredVersionText)) {
            $null
        }
        else {
            [version]::Parse($minimumRequiredVersionText)
        }
        IsRequiredUpdate = [string]::Equals(
            $minimumRequiredVersionText,
            $Version,
            [StringComparison]::OrdinalIgnoreCase)
        ManifestPath = $manifestPath
        SetupPath = $setupPath
        VersionDirectory = $versionDirectory
        ConfigurationPath = $configurationPath
        PayloadFileCount = $payloadFiles.Count
        DeploymentProvider = [string]$provider.codebase
    }
}

function Assert-AccountsPayloadMatches {
    param(
        [Parameter(Mandatory = $true)]
        [string]$SourceDirectory,

        [Parameter(Mandatory = $true)]
        [string]$DestinationDirectory
    )

    if (-not (Test-Path -LiteralPath $SourceDirectory -PathType Container)) {
        throw "Source payload directory was not found: $SourceDirectory"
    }
    if (-not (Test-Path -LiteralPath $DestinationDirectory -PathType Container)) {
        throw "Destination payload directory was not found: $DestinationDirectory"
    }

    $sourceFiles = @(Get-ChildItem -LiteralPath $SourceDirectory -Recurse -File)
    $destinationFiles = @(Get-ChildItem -LiteralPath $DestinationDirectory -Recurse -File)
    if ($sourceFiles.Count -ne $destinationFiles.Count) {
        throw "Payload file counts differ. Source=$($sourceFiles.Count), destination=$($destinationFiles.Count)."
    }

    foreach ($sourceFile in $sourceFiles) {
        $relativePath = $sourceFile.FullName.Substring($SourceDirectory.Length).TrimStart('\')
        $destinationPath = Join-Path $DestinationDirectory $relativePath
        if (-not (Test-Path -LiteralPath $destinationPath -PathType Leaf)) {
            throw "Destination payload file is missing: $relativePath"
        }

        $destinationFile = Get-Item -LiteralPath $destinationPath
        if ($sourceFile.Length -ne $destinationFile.Length) {
            throw "Payload file size differs: $relativePath"
        }

        $sourceHash = (Get-FileHash -LiteralPath $sourceFile.FullName -Algorithm SHA256).Hash
        $destinationHash = (Get-FileHash -LiteralPath $destinationPath -Algorithm SHA256).Hash
        if ($sourceHash -ne $destinationHash) {
            throw "Payload file hash differs: $relativePath"
        }
    }
}

function Assert-AccountsFileMatches {
    param(
        [Parameter(Mandatory = $true)]
        [string]$Source,

        [Parameter(Mandatory = $true)]
        [string]$Destination
    )

    if (-not (Test-Path -LiteralPath $Source -PathType Leaf) -or
        -not (Test-Path -LiteralPath $Destination -PathType Leaf)) {
        throw "A file comparison target is missing: '$Source' or '$Destination'."
    }

    $sourceHash = (Get-FileHash -LiteralPath $Source -Algorithm SHA256).Hash
    $destinationHash = (Get-FileHash -LiteralPath $Destination -Algorithm SHA256).Hash
    if ($sourceHash -ne $destinationHash) {
        throw "Files do not match: '$Source' and '$Destination'."
    }
}
