param(
    [switch]$Apply
)

$ErrorActionPreference = 'Stop'
$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$solutionPath = Join-Path $repositoryRoot 'HIS.sln'
$runName = 'CrystalReports_RemainingBackups_2026-08-11'
$quarantineRoot = [IO.Path]::GetFullPath((Join-Path $repositoryRoot "_Quarantine\$runName"))
$manifestRoot = Join-Path $quarantineRoot 'Manifests'
$manifestPath = Join-Path $manifestRoot 'QuarantinedRemainingIGroupReports.csv'

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

if (-not [IO.File]::Exists($solutionPath)) { throw 'HIS.sln was not found.' }

if ([IO.File]::Exists($manifestPath)) {
    $appliedRows = @(Import-Csv -LiteralPath $manifestPath)
    if ($appliedRows.Count -ne 110) {
        throw "Expected 110 applied manifest rows; found $($appliedRows.Count)."
    }
    $solutionText = [IO.File]::ReadAllText($solutionPath)
    if ($solutionText -match '(?im)^\s+IGroup[\\/]Reports[\\/].+\.rpt\s*=') {
        throw 'HIS.sln still contains one or more IGroup report backup entries.'
    }
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

if ($Apply -and [IO.Directory]::Exists($quarantineRoot)) {
    throw "Quarantine destination already exists without a completed manifest: $quarantineRoot"
}

$trackedHashes = @{}
foreach ($line in @(& git -c core.quotepath=false ls-files -s -- 'IGroup/Reports/*.rpt')) {
    if ($line -match '^\d+\s+([0-9a-f]+)\s+\d+\t(.+)$') {
        $trackedHashes[$Matches[2].Replace('\', '/').ToLowerInvariant()] = $Matches[1]
    }
}

$sourceFiles = @(Get-ChildItem -LiteralPath (Join-Path $repositoryRoot 'IGroup\Reports') `
    -Recurse -File -Filter '*.rpt' | Sort-Object FullName)
if ($sourceFiles.Count -ne 110) {
    throw "Expected 110 remaining IGroup reports; found $($sourceFiles.Count)."
}

$utf8Bom = [Text.UTF8Encoding]::new($true)
$solutionLines = [IO.File]::ReadAllLines($solutionPath, $utf8Bom)
$solutionItemCounts = @{}
foreach ($line in $solutionLines) {
    if ($line -match '^\s+([^=]+\.rpt)\s*=\s*([^=]+\.rpt)\s*$') {
        $left = $Matches[1].Trim().Replace('\', '/')
        $right = $Matches[2].Trim().Replace('\', '/')
        if ($left.StartsWith('IGroup/Reports/', [StringComparison]::OrdinalIgnoreCase)) {
            if (-not $left.Equals($right, [StringComparison]::OrdinalIgnoreCase)) {
                throw "Unexpected Solution Item mapping for $left."
            }
            $key = $left.ToLowerInvariant()
            if (-not $solutionItemCounts.ContainsKey($key)) { $solutionItemCounts[$key] = 0 }
            $solutionItemCounts[$key]++
        }
    }
}

$candidates = @($sourceFiles | ForEach-Object {
    $sourcePath = Get-RelativePath $_.FullName
    $key = $sourcePath.ToLowerInvariant()
    if (-not $trackedHashes.ContainsKey($key)) { throw "Report is not tracked: $sourcePath" }
    [pscustomobject]@{
        SourcePath = $sourcePath
        BlobHash = $trackedHashes[$key]
        SizeBytes = $_.Length
        SolutionItemOccurrences = if ($solutionItemCounts.ContainsKey($key)) { $solutionItemCounts[$key] } else { 0 }
        QuarantinePath = "_Quarantine/$runName/BackupReports/$sourcePath"
        Reason = 'User-confirmed backup-only report outside the configured Accounts runtime report tree'
    }
})

$candidatePaths = [Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
foreach ($candidate in $candidates) {
    [void]$candidatePaths.Add($candidate.SourcePath)
    $source = Join-Path $repositoryRoot $candidate.SourcePath.Replace('/', '\')
    $destination = Join-Path $repositoryRoot $candidate.QuarantinePath.Replace('/', '\')
    Assert-ChildPath $source $repositoryRoot 'Source path'
    Assert-ChildPath $destination $quarantineRoot 'Quarantine path'
}

$staleSolutionItems = @($solutionItemCounts.Keys | Where-Object { -not $candidatePaths.Contains($_) })
if ($staleSolutionItems.Count -ne 2) {
    throw "Expected 2 stale HIS.sln entries without physical reports; found $($staleSolutionItems.Count)."
}

$updatedSolutionLines = New-Object Collections.Generic.List[string]
$removedSolutionItems = 0
foreach ($line in $solutionLines) {
    $remove = $false
    if ($line -match '^\s+([^=]+\.rpt)\s*=\s*([^=]+\.rpt)\s*$') {
        $left = $Matches[1].Trim().Replace('\', '/')
        $right = $Matches[2].Trim().Replace('\', '/')
        if ($left.StartsWith('IGroup/Reports/', [StringComparison]::OrdinalIgnoreCase)) {
            if (-not $left.Equals($right, [StringComparison]::OrdinalIgnoreCase)) {
                throw "Unexpected Solution Item mapping for $left."
            }
            $remove = $true
            $removedSolutionItems++
        }
    }
    if (-not $remove) { $updatedSolutionLines.Add($line) }
}
if ($removedSolutionItems -ne 109) {
    throw "Expected 109 matching HIS.sln entries; found $removedSolutionItems."
}

$externalReferences = @(& rg -n -i 'IGroup[\\/]+Reports' . `
    --glob '!HIS.sln' --glob '!HIS.sln.bak' --glob '!_Quarantine/**' `
    --glob '!tools/QuarantineCrossRootCrystalReportDuplicates.ps1' `
    --glob '!tools/QuarantineRemainingIGroupReports.ps1' `
    --glob '!*.rpt' --glob '!*.dll' --glob '!*.exe' 2>$null)
if ($externalReferences.Count -gt 0) {
    throw "References outside HIS.sln were found:`r`n$($externalReferences -join "`r`n")"
}

$totalBytes = ($candidates | Measure-Object SizeBytes -Sum).Sum
Write-Output "Approved remaining backup reports: $($candidates.Count)"
Write-Output "Matching HIS.sln Solution Item lines: $removedSolutionItems"
Write-Output "Stale HIS.sln entries without physical reports: $($staleSolutionItems.Count)"
Write-Output "Reports without a Solution Item: $(@($candidates | Where-Object SolutionItemOccurrences -eq 0).Count)"
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
        New-Item -ItemType Directory -Path (Split-Path -Parent $destination) -Force | Out-Null
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
Write-Output 'Remaining IGroup report backups quarantined successfully.'
