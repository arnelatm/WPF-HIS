param(
    [switch]$Apply
)

$ErrorActionPreference = 'Stop'
$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$solutionPath = Join-Path $repositoryRoot 'HIS.sln'
$runName = 'CrystalReports_CrossRoot_2026-08-11'
$quarantineRoot = [IO.Path]::GetFullPath((Join-Path $repositoryRoot "_Quarantine\$runName"))
$manifestRoot = Join-Path $quarantineRoot 'Manifests'
$manifestPath = Join-Path $manifestRoot 'QuarantinedCrossRootDuplicates.csv'

function Get-RelativePath([string]$FullPath) {
    return $FullPath.Substring($repositoryRoot.Length).TrimStart('\').Replace('\', '/')
}

function Assert-ChildPath([string]$Path, [string]$Parent, [string]$Description) {
    $resolvedPath = [IO.Path]::GetFullPath($Path)
    $resolvedParent = [IO.Path]::GetFullPath($Parent).TrimEnd('\') + '\'
    if (-not $resolvedPath.StartsWith($resolvedParent, [StringComparison]::OrdinalIgnoreCase)) {
        throw "$Description escaped its expected parent: $resolvedPath"
    }
}

Set-Location -LiteralPath $repositoryRoot

if (-not (Test-Path -LiteralPath $solutionPath -PathType Leaf)) {
    throw 'HIS.sln was not found.'
}

if (Test-Path -LiteralPath $manifestPath -PathType Leaf) {
    $appliedRows = @(Import-Csv -LiteralPath $manifestPath)
    if ($appliedRows.Count -ne 536) {
        throw "Expected 536 applied manifest rows; found $($appliedRows.Count)."
    }
    $trackedHashes = @{}
    foreach ($line in @(& git -c core.quotepath=false ls-files -s -- '*.rpt')) {
        if ($line -match '^\d+\s+([0-9a-f]+)\s+\d+\t(.+)$') {
            $trackedHashes[$Matches[2].Replace('\', '/').ToLowerInvariant()] = $Matches[1]
        }
    }
    $solutionText = [IO.File]::ReadAllText($solutionPath)
    $quarantinedCount = 0
    $finalizedCount = 0
    foreach ($row in $appliedRows) {
        $source = Join-Path $repositoryRoot $row.SourcePath.Replace('/', '\')
        $destination = Join-Path $repositoryRoot $row.QuarantinePath.Replace('/', '\')
        if ([IO.File]::Exists($source)) { throw "Quarantined source still exists: $($row.SourcePath)" }
        if ([IO.File]::Exists($destination)) {
            if ((& git hash-object -- $destination) -ne $row.BlobHash) {
                throw "Quarantined file hash differs: $($row.QuarantinePath)"
            }
            $quarantinedCount++
        } else {
            $finalizedCount++
        }
        foreach ($accountsPath in $row.AccountsCopies.Split(';', [StringSplitOptions]::RemoveEmptyEntries)) {
            $normalizedAccountsPath = $accountsPath.Trim().Replace('\', '/')
            $accountsFullPath = Join-Path $repositoryRoot $normalizedAccountsPath.Replace('/', '\')
            if (-not [IO.File]::Exists($accountsFullPath)) {
                throw "Retained Accounts copy is unavailable: $($accountsPath.Trim())"
            }
            $hashKey = $normalizedAccountsPath.ToLowerInvariant()
            if (-not $trackedHashes.ContainsKey($hashKey) -or $trackedHashes[$hashKey] -ne $row.BlobHash) {
                throw "Retained Accounts copy no longer matches the manifest: $normalizedAccountsPath"
            }
        }
        $solutionItem = "`t`t$($row.SourcePath.Replace('/', '\')) = $($row.SourcePath.Replace('/', '\'))"
        if ($solutionText.Contains($solutionItem)) {
            throw "HIS.sln still contains quarantined report: $($row.SourcePath)"
        }
    }
    Write-Output "Applied quarantine verified: $($appliedRows.Count) reports"
    Write-Output "Reports still in quarantine: $quarantinedCount"
    Write-Output "Reports finalized as deletions: $finalizedCount"
    Write-Output "Manifest: $(Get-RelativePath $manifestPath)"
    Write-Output 'No additional changes required.'
    exit 0
}

if ($Apply -and (Test-Path -LiteralPath $quarantineRoot)) {
    throw "Quarantine destination already exists without a completed manifest: $quarantineRoot"
}

$entries = foreach ($line in @(& git -c core.quotepath=false ls-files -s -- '*.rpt')) {
    if ($line -match '^\d+\s+([0-9a-f]+)\s+\d+\t(.+)$') {
        [pscustomobject]@{
            BlobHash = $Matches[1]
            Path = $Matches[2].Replace('\', '/')
        }
    }
}

$blobHashes = @($entries.BlobHash | Sort-Object -Unique)
$blobSizes = @{}
foreach ($line in @($blobHashes | git cat-file --batch-check='%(objectname) %(objectsize)')) {
    if ($line -match '^([0-9a-f]+)\s+(\d+)$') {
        $blobSizes[$Matches[1]] = [int64]$Matches[2]
    }
}

$candidates = @($entries | Group-Object BlobHash | ForEach-Object {
    $group = $_.Group
    $accountsCopies = @($group | Where-Object Path -like 'Accounts/Reports/IGroup/*' | Sort-Object Path)
    if ($accountsCopies.Count -eq 0) { return }
    foreach ($source in @($group | Where-Object Path -like 'IGroup/Reports/*' | Sort-Object Path)) {
        [pscustomobject]@{
            SourcePath = $source.Path
            BlobHash = $source.BlobHash
            SizeBytes = $blobSizes[$source.BlobHash]
            AccountsCopies = ($accountsCopies.Path -join '; ')
            QuarantinePath = "_Quarantine/$runName/ExactDuplicates/$($source.Path)"
            Reason = 'Exact copy exists under the configured Accounts/Reports/IGroup runtime tree'
        }
    }
} | Sort-Object SourcePath)

if ($candidates.Count -ne 536) {
    throw "Expected 536 cross-root exact duplicates; found $($candidates.Count)."
}

$candidatePaths = [Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
foreach ($candidate in $candidates) {
    [void]$candidatePaths.Add($candidate.SourcePath)
    $source = Join-Path $repositoryRoot $candidate.SourcePath.Replace('/', '\')
    $destination = Join-Path $repositoryRoot $candidate.QuarantinePath.Replace('/', '\')
    Assert-ChildPath $source $repositoryRoot 'Source path'
    Assert-ChildPath $destination $quarantineRoot 'Quarantine path'
    if (-not [IO.File]::Exists($source)) {
        throw "Source report is unavailable: $($candidate.SourcePath)"
    }
    foreach ($accountsPath in $candidate.AccountsCopies.Split(';', [StringSplitOptions]::RemoveEmptyEntries)) {
        $accountsFullPath = Join-Path $repositoryRoot $accountsPath.Trim().Replace('/', '\')
        if (-not [IO.File]::Exists($accountsFullPath)) {
            throw "Retained Accounts copy is unavailable: $($accountsPath.Trim())"
        }
    }
}

$utf8Bom = [Text.UTF8Encoding]::new($true)
$solutionLines = [IO.File]::ReadAllLines($solutionPath, $utf8Bom)
$updatedSolutionLines = New-Object Collections.Generic.List[string]
$removedSolutionItems = 0
foreach ($line in $solutionLines) {
    $remove = $false
    if ($line -match '^\s+([^=]+\.rpt)\s*=\s*([^=]+\.rpt)\s*$') {
        $left = $Matches[1].Trim().Replace('\', '/')
        $right = $Matches[2].Trim().Replace('\', '/')
        if ($candidatePaths.Contains($left)) {
            if (-not $left.Equals($right, [StringComparison]::OrdinalIgnoreCase)) {
                throw "Unexpected Solution Item mapping for $left."
            }
            $remove = $true
            $removedSolutionItems++
        }
    }
    if (-not $remove) { $updatedSolutionLines.Add($line) }
}

if ($removedSolutionItems -ne $candidates.Count) {
    throw "Expected $($candidates.Count) matching HIS.sln entries; found $removedSolutionItems."
}

$externalReferences = @(& rg -n -i 'IGroup[\\/]+Reports' . `
    --glob '!HIS.sln' --glob '!HIS.sln.bak' --glob '!_Quarantine/**' `
    --glob '!tools/QuarantineCrossRootCrystalReportDuplicates.ps1' `
    --glob '!*.rpt' --glob '!*.dll' --glob '!*.exe' 2>$null)
if ($externalReferences.Count -gt 0) {
    throw "References outside HIS.sln were found:`r`n$($externalReferences -join "`r`n")"
}

$totalBytes = ($candidates | Measure-Object SizeBytes -Sum).Sum
Write-Output "Approved exact duplicates: $($candidates.Count)"
Write-Output "Matching HIS.sln Solution Items: $removedSolutionItems"
Write-Output "Retained Accounts runtime copies: verified"
Write-Output "References outside HIS.sln: 0"
Write-Output "Quarantine size MB: $([math]::Round($totalBytes / 1MB, 2))"

if (-not $Apply) {
    Write-Output 'Dry run only; no files or solution entries changed.'
    exit 0
}

$moved = New-Object Collections.Generic.List[object]
try {
    foreach ($candidate in $candidates) {
        $source = Join-Path $repositoryRoot $candidate.SourcePath.Replace('/', '\')
        $destination = Join-Path $repositoryRoot $candidate.QuarantinePath.Replace('/', '\')
        $destinationDirectory = Split-Path -Parent $destination
        New-Item -ItemType Directory -Path $destinationDirectory -Force | Out-Null
        Move-Item -LiteralPath $source -Destination $destination
        $moved.Add([pscustomobject]@{ Source = $source; Destination = $destination })
    }

    [IO.File]::WriteAllLines($solutionPath, $updatedSolutionLines, $utf8Bom)
    New-Item -ItemType Directory -Path $manifestRoot -Force | Out-Null
    $candidates | Export-Csv -LiteralPath $manifestPath -NoTypeInformation -Encoding UTF8
} catch {
    [IO.File]::WriteAllLines($solutionPath, $solutionLines, $utf8Bom)
    for ($index = $moved.Count - 1; $index -ge 0; $index--) {
        $entry = $moved[$index]
        if ([IO.File]::Exists($entry.Destination) -and -not [IO.File]::Exists($entry.Source)) {
            New-Item -ItemType Directory -Path (Split-Path -Parent $entry.Source) -Force | Out-Null
            Move-Item -LiteralPath $entry.Destination -Destination $entry.Source
        }
    }
    throw
}

Write-Output "Manifest: $(Get-RelativePath $manifestPath)"
Write-Output 'Approved cross-root report duplicates quarantined successfully.'
