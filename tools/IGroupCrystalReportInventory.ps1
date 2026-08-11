param(
    [switch]$ApplyQuarantine,
    [string]$SqlServer = 'IBN-SERVER',
    [string]$Database = 'ISPDATA'
)

$ErrorActionPreference = 'Stop'
$repositoryRoot = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$targetRelativeRoot = 'Accounts/Reports/IGroup'
$targetRoot = [System.IO.Path]::GetFullPath((Join-Path $repositoryRoot $targetRelativeRoot.Replace('/', '\')))
$runName = 'IGroupCrystalReports_2026-08-11'
$quarantineRoot = [System.IO.Path]::GetFullPath((Join-Path $repositoryRoot "_Quarantine\$runName"))
$manifestRoot = Join-Path $quarantineRoot 'Manifests'

function Get-RelativePath([string]$FullPath) {
    return [System.IO.Path]::GetFullPath($FullPath).
        Substring($repositoryRoot.Length).
        TrimStart('\').
        Replace('\', '/')
}

function Get-ReportFileKey([string]$Value) {
    if ([string]::IsNullOrWhiteSpace($Value)) {
        return $null
    }

    $normalized = $Value.Trim().Replace('/', '\')
    try {
        $normalized = [System.IO.Path]::GetFileName($normalized)
    } catch {
        return $null
    }

    if ([string]::IsNullOrWhiteSpace($normalized)) {
        return $null
    }

    if (-not $normalized.EndsWith('.rpt', [System.StringComparison]::OrdinalIgnoreCase)) {
        $normalized += '.rpt'
    }

    return $normalized.ToLowerInvariant()
}

function Add-Evidence([hashtable]$EvidenceMap, [string]$Key, [string]$Evidence) {
    if ([string]::IsNullOrWhiteSpace($Key) -or [string]::IsNullOrWhiteSpace($Evidence)) {
        return
    }

    if (-not $EvidenceMap.ContainsKey($Key)) {
        $EvidenceMap[$Key] = [System.Collections.Generic.List[string]]::new()
    }

    if ($EvidenceMap[$Key].Count -ge 20) {
        return
    }

    if (-not $EvidenceMap[$Key].Contains($Evidence)) {
        $EvidenceMap[$Key].Add($Evidence)
    }
}

if (-not (Test-Path -LiteralPath $targetRoot -PathType Container)) {
    throw "IGroup report root not found: $targetRoot"
}
if (-not $targetRoot.StartsWith($repositoryRoot + '\', [System.StringComparison]::OrdinalIgnoreCase)) {
    throw "Target report root escaped the repository: $targetRoot"
}
if (-not $quarantineRoot.StartsWith($repositoryRoot + '\', [System.StringComparison]::OrdinalIgnoreCase)) {
    throw "Quarantine root escaped the repository: $quarantineRoot"
}

Set-Location -LiteralPath $repositoryRoot

# Read the tracked IGroup reports and their index hashes. Using the Git index
# makes the manifest useful even after the working-tree files are moved.
$indexRows = [System.Collections.Generic.List[object]]::new()
$indexLines = & git -c core.quotepath=false ls-files -s -- $targetRelativeRoot
if ($LASTEXITCODE -ne 0) {
    throw 'Unable to enumerate tracked IGroup files from Git.'
}
foreach ($line in $indexLines) {
    if ($line -notmatch '^\d+\s+([0-9a-f]+)\s+\d+\t(.+)$') {
        continue
    }

    $relativePath = $Matches[2].Replace('\', '/')
    if (-not $relativePath.EndsWith('.rpt', [System.StringComparison]::OrdinalIgnoreCase)) {
        continue
    }

    $fullPath = [System.IO.Path]::GetFullPath((Join-Path $repositoryRoot $relativePath.Replace('/', '\')))
    if (-not (Test-Path -LiteralPath $fullPath -PathType Leaf)) {
        throw "Tracked report is missing before inventory: $relativePath"
    }

    $indexRows.Add([pscustomobject]@{
        Path = $relativePath
        FullPath = $fullPath
        BlobHash = $Matches[1]
        FileName = [System.IO.Path]::GetFileName($relativePath)
        FileKey = [System.IO.Path]::GetFileName($relativePath).ToLowerInvariant()
        FileStem = [System.IO.Path]::GetFileNameWithoutExtension($relativePath)
        SizeBytes = (Get-Item -LiteralPath $fullPath -Force).Length
    })
}

if ($indexRows.Count -eq 0) {
    throw 'No tracked Crystal Reports were found under Accounts/Reports/IGroup.'
}

$fileKeyByStem = @{}
foreach ($report in $indexRows) {
    $stemKey = $report.FileStem.ToLowerInvariant()
    if (-not $fileKeyByStem.ContainsKey($stemKey)) {
        $fileKeyByStem[$stemKey] = $report.FileKey
    }
}

# Exact project-item references are authoritative even when the report name is
# never present in executable source code.
$projectIncludes = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
$projectPaths = & rg --files -g '*.vbproj' -g '*.csproj' -g '!**/bin/**' -g '!**/obj/**' -g '!**/packages/**' -g '!**/_Quarantine/**'
if ($LASTEXITCODE -gt 1) {
    throw 'Unable to enumerate project files.'
}
foreach ($projectPath in $projectPaths) {
    $projectFile = Get-Item -LiteralPath (Join-Path $repositoryRoot $projectPath)
    try {
        [xml]$projectXml = Get-Content -LiteralPath $projectFile.FullName -Raw
        foreach ($node in $projectXml.SelectNodes('//*[@Include]')) {
            $include = [string]$node.Include
            if (-not $include.EndsWith('.rpt', [System.StringComparison]::OrdinalIgnoreCase)) {
                continue
            }

            $includedPath = [System.IO.Path]::GetFullPath((Join-Path $projectFile.DirectoryName $include))
            if ($includedPath.StartsWith($repositoryRoot + '\', [System.StringComparison]::OrdinalIgnoreCase)) {
                [void]$projectIncludes.Add((Get-RelativePath $includedPath))
            }
        }
    } catch {
        Write-Warning "Could not parse project file $($projectFile.FullName): $($_.Exception.Message)"
    }
}

# Scan string literals and XML values outside the report asset tree. The tree
# contains generated ReportClass source whose ResourceName would otherwise be
# circular evidence for an unused report.
$staticReferenceEvidence = @{}
$sourcePaths = & rg --files `
    -g '*.vb' -g '*.cs' -g '*.config' -g '*.xml' -g '*.resx' -g '*.xaml' `
    -g '*.sql' -g '*.json' -g '*.txt' -g '*.settings' -g '*.props' -g '*.targets' `
    -g '*.vbproj' -g '*.csproj' `
    -g '!**/bin/**' -g '!**/obj/**' -g '!**/packages/**' -g '!**/_Quarantine/**' `
    -g '!Accounts/Reports/IGroup/**'
if ($LASTEXITCODE -gt 1) {
    throw 'Unable to enumerate source files for report references.'
}
$quotedValuePattern = '"([^"\r\n<>]+)"|''([^''\r\n<>]+)''|>([^<\r\n]+)<'
foreach ($sourcePath in $sourcePaths) {
    $sourceFullPath = Join-Path $repositoryRoot $sourcePath
    try {
        $lineNumber = 0
        foreach ($line in [System.IO.File]::ReadLines($sourceFullPath)) {
            $lineNumber++
            foreach ($match in [regex]::Matches($line, $quotedValuePattern)) {
                $value = if ($match.Groups[1].Success) {
                    $match.Groups[1].Value
                } elseif ($match.Groups[2].Success) {
                    $match.Groups[2].Value
                } else {
                    $match.Groups[3].Value
                }

                $leaf = $value.Trim().Replace('/', '\')
                try {
                    $leaf = [System.IO.Path]::GetFileName($leaf)
                } catch {
                    continue
                }
                if ([string]::IsNullOrWhiteSpace($leaf)) {
                    continue
                }

                $fileKey = $null
                if ($leaf.EndsWith('.rpt', [System.StringComparison]::OrdinalIgnoreCase)) {
                    $fileKey = $leaf.ToLowerInvariant()
                } else {
                    $stemKey = $leaf.ToLowerInvariant()
                    if ($fileKeyByStem.ContainsKey($stemKey)) {
                        $fileKey = $fileKeyByStem[$stemKey]
                    }
                }

                if ($null -ne $fileKey) {
                    Add-Evidence $staticReferenceEvidence $fileKey "$($sourcePath.Replace('\', '/')):$lineNumber"
                }
            }
        }
    } catch {
        Write-Warning "Could not scan source file ${sourcePath}: $($_.Exception.Message)"
    }
}

# The deployed program reads ISPDATA.dbo.Report, not a DBF file. ReportFile is
# the only other live table with a ReportFileName column, so include its two
# label-printing registrations as well. Protect inactive rows because they can
# be re-enabled.
$query = @'
SET NOCOUNT ON;
SELECT
    'Report',
    CAST(IdNo AS varchar(10)),
    ISNULL(CAST(Active AS varchar(1)), ''),
    REPLACE(ISNULL(DatabaseName, ''), '|', '/'),
    REPLACE(ISNULL(ReportCode, ''), '|', '/'),
    REPLACE(ISNULL(ReportFileName, ''), '|', '/'),
    REPLACE(ISNULL(ReportName, ''), '|', '/')
FROM dbo.Report
WHERE NULLIF(LTRIM(RTRIM(ReportFileName)), '') IS NOT NULL
UNION ALL
SELECT
    'ReportFile',
    CAST(IdNo AS varchar(10)),
    ISNULL(CAST(Active AS varchar(1)), ''),
    '',
    '',
    REPLACE(ISNULL(ReportFileName, ''), '|', '/'),
    REPLACE(ISNULL(ReportTitle, ''), '|', '/')
FROM dbo.ReportFile
WHERE NULLIF(LTRIM(RTRIM(ReportFileName)), '') IS NOT NULL
ORDER BY 1, 6, 2;
'@
$sqlOutput = & sqlcmd -S $SqlServer -d $Database -E -b -W -s '|' -h -1 -Q $query
if ($LASTEXITCODE -ne 0) {
    throw "Unable to read [$Database].[dbo].[Report] from $SqlServer."
}

$reportTableRows = [System.Collections.Generic.List[object]]::new()
$databaseReferenceEvidence = @{}
foreach ($line in $sqlOutput) {
    if ([string]::IsNullOrWhiteSpace($line)) {
        continue
    }

    $parts = $line -split '\|', 7
    if ($parts.Count -ne 7) {
        throw "Unexpected sqlcmd output while reading the report registry: $line"
    }

    $row = [pscustomobject]@{
        SourceTable = $parts[0].Trim()
        IdNo = $parts[1].Trim()
        Active = $parts[2].Trim()
        DatabaseName = $parts[3].Trim()
        ReportCode = $parts[4].Trim()
        ReportFileName = $parts[5].Trim()
        ReportName = $parts[6].Trim()
    }
    $reportTableRows.Add($row)

    $fileKey = Get-ReportFileKey $row.ReportFileName
    if ($null -ne $fileKey) {
        $evidence = "Table=$($row.SourceTable); IdNo=$($row.IdNo); Active=$($row.Active); Database=$($row.DatabaseName); Value=$($row.ReportFileName)"
        Add-Evidence $databaseReferenceEvidence $fileKey $evidence
    }
}

if ($reportTableRows.Count -eq 0) {
    throw "The live [$Database] report registry query returned no filename rows; refusing to classify reports."
}

$fileNameCounts = @{}
foreach ($group in ($indexRows | Group-Object FileKey)) {
    $fileNameCounts[$group.Name] = $group.Count
}

$reports = foreach ($report in $indexRows) {
    $projectIncluded = $projectIncludes.Contains($report.Path)
    $staticReferenced = $staticReferenceEvidence.ContainsKey($report.FileKey)
    $databaseReferenced = $databaseReferenceEvidence.ContainsKey($report.FileKey)
    $protectionReasons = [System.Collections.Generic.List[string]]::new()
    if ($projectIncluded) { $protectionReasons.Add('Project item') }
    if ($staticReferenced) { $protectionReasons.Add('Source/config literal') }
    if ($databaseReferenced) { $protectionReasons.Add("$Database report registry") }
    $protected = $protectionReasons.Count -gt 0

    [pscustomobject]@{
        Path = $report.Path
        FullPath = $report.FullPath
        BlobHash = $report.BlobHash
        SizeBytes = $report.SizeBytes
        FileName = $report.FileName
        DuplicateFileNameCount = $fileNameCounts[$report.FileKey]
        ProjectIncluded = $projectIncluded
        StaticReferenced = $staticReferenced
        StaticEvidence = if ($staticReferenced) { $staticReferenceEvidence[$report.FileKey] -join '; ' } else { '' }
        ReportTableReferenced = $databaseReferenced
        ReportTableEvidence = if ($databaseReferenced) { $databaseReferenceEvidence[$report.FileKey] -join '; ' } else { '' }
        Classification = if ($protected) { 'Protected: ' + ($protectionReasons -join ', ') } else { 'Unused: no project, source/config, or Report-table reference' }
        ProposedAction = if ($protected) { 'Retain' } else { 'QuarantineUnused' }
        QuarantinePath = ''
    }
}

$candidates = @($reports | Where-Object ProposedAction -eq 'QuarantineUnused' | Sort-Object Path)

New-Item -ItemType Directory -Path $manifestRoot -Force | Out-Null
$inventoryPath = Join-Path $manifestRoot 'IGroupCrystalReportUsage.csv'
$planPath = Join-Path $manifestRoot 'QuarantinePlan.csv'
$tableSnapshotPath = Join-Path $manifestRoot 'ReportTableSnapshot.csv'
$reports | Sort-Object Path | Select-Object Path, BlobHash, SizeBytes, FileName, DuplicateFileNameCount,
    ProjectIncluded, StaticReferenced, StaticEvidence, ReportTableReferenced, ReportTableEvidence,
    Classification, ProposedAction | Export-Csv -LiteralPath $inventoryPath -NoTypeInformation -Encoding UTF8
$candidates | Select-Object Path, BlobHash, SizeBytes, FileName, DuplicateFileNameCount,
    Classification, ProposedAction | Export-Csv -LiteralPath $planPath -NoTypeInformation -Encoding UTF8
$reportTableRows | Export-Csv -LiteralPath $tableSnapshotPath -NoTypeInformation -Encoding UTF8

if ($ApplyQuarantine) {
    # Resolve and validate every destination before moving the first file so a
    # collision cannot leave a partially applied quarantine batch.
    foreach ($report in $candidates) {
        $sourceResolved = [System.IO.Path]::GetFullPath($report.FullPath)
        $destination = Join-Path (Join-Path $quarantineRoot 'Unused') $report.Path.Replace('/', '\')
        $destinationResolved = [System.IO.Path]::GetFullPath($destination)
        if (-not $sourceResolved.StartsWith($targetRoot + '\', [System.StringComparison]::OrdinalIgnoreCase)) {
            throw "Source escaped the IGroup report root: $sourceResolved"
        }
        if (-not $destinationResolved.StartsWith($quarantineRoot + '\', [System.StringComparison]::OrdinalIgnoreCase)) {
            throw "Destination escaped the quarantine root: $destinationResolved"
        }
        if (-not (Test-Path -LiteralPath $sourceResolved -PathType Leaf)) {
            throw "Candidate source no longer exists: $sourceResolved"
        }
        if (Test-Path -LiteralPath $destinationResolved) {
            throw "Quarantine destination already exists: $destinationResolved"
        }
        $report.QuarantinePath = Get-RelativePath $destinationResolved
    }

    foreach ($report in $candidates) {
        $destinationResolved = [System.IO.Path]::GetFullPath((Join-Path $repositoryRoot $report.QuarantinePath.Replace('/', '\')))
        New-Item -ItemType Directory -Path (Split-Path -Parent $destinationResolved) -Force | Out-Null
        Move-Item -LiteralPath $report.FullPath -Destination $destinationResolved -Force
    }

    $movedPath = Join-Path $manifestRoot 'QuarantinedReports.csv'
    $candidates | Select-Object Path, QuarantinePath, BlobHash, SizeBytes, FileName,
        DuplicateFileNameCount, Classification, ProposedAction |
        Export-Csv -LiteralPath $movedPath -NoTypeInformation -Encoding UTF8
}

$candidateBytes = ($candidates | Measure-Object SizeBytes -Sum).Sum
$protectedCount = $reports.Count - $candidates.Count
$readmePath = Join-Path $quarantineRoot 'README.md'
$applyStatus = if ($ApplyQuarantine) { 'Applied' } else { 'Dry run only' }
$readme = @"
# IGroup Crystal Reports quarantine

This batch inventories Crystal Reports below `Accounts/Reports/IGroup` and protects a report when any of these usage signals exists:

- an exact `.vbproj` or `.csproj` item reference;
- a report filename or filename stem in a source/configuration string literal; or
- a matching `ReportFileName` in the live `[$Database].[dbo].[Report]` or `[$Database].[dbo].[ReportFile]` table on `$SqlServer`.

Both active and inactive database rows are protected. Generated report wrapper source inside the report asset directory is excluded from the literal scan to avoid treating an unused report as its own usage evidence.

## Batch summary

- Status: $applyStatus
- IGroup reports inventoried: $($reports.Count)
- Reports protected by usage evidence: $protectedCount
- Unreferenced reports selected for quarantine: $($candidates.Count)
- Selected size: $([math]::Round($candidateBytes / 1MB, 2)) MB
- Database report-registry filename rows inspected: $($reportTableRows.Count)

`Manifests/IGroupCrystalReportUsage.csv` records the decision and evidence for every report. `Manifests/ReportTableSnapshot.csv` records the live database rows used by this run. `Manifests/QuarantinePlan.csv` records the planned moves, and `Manifests/QuarantinedReports.csv` maps applied moves to their restore paths.

To restore a moved file, move it from `QuarantinePath` back to `Path`. Do not deploy reports directly from this quarantine directory.
"@
Set-Content -LiteralPath $readmePath -Value $readme -Encoding UTF8

Write-Output "IGroup reports inventoried: $($reports.Count)"
Write-Output "Live report-registry rows inspected: $($reportTableRows.Count)"
Write-Output "Protected reports: $protectedCount"
Write-Output "Unused quarantine candidates: $($candidates.Count)"
Write-Output "Candidate size MB: $([math]::Round($candidateBytes / 1MB, 2))"
Write-Output "Inventory: $(Get-RelativePath $inventoryPath)"
Write-Output "Plan: $(Get-RelativePath $planPath)"
if ($ApplyQuarantine) {
    Write-Output 'Quarantine moves applied.'
} else {
    Write-Output 'Dry run only; no reports moved.'
}
