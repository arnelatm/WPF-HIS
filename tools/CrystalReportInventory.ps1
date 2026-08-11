param(
    [switch]$ApplyQuarantine
)

$ErrorActionPreference = 'Stop'
$repositoryRoot = [System.IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$runName = 'CrystalReports_2026-08-11'
$quarantineRoot = Join-Path $repositoryRoot "_Quarantine\$runName"
$manifestRoot = Join-Path $quarantineRoot 'Manifests'

function Get-RelativePath([string]$FullPath) {
    return $FullPath.Substring($repositoryRoot.Length).TrimStart('\').Replace('\', '/')
}

function Test-BackupStyle([string]$RelativePath) {
    $normalized = $RelativePath.Replace('\', '/')
    $directoryPattern = '(?i)(^|/)(backup|backups|copy|copies|old|trial|test|archive|archived)(/|$)'
    $filePattern = '(?i)(?:\s*-\s*)?(copy|backup|old|trial|test|original)(?:\s*\(\d+\)|\s*\d+)?\.rpt$|\s\(\d+\)\.rpt$'
    return ($normalized -match $directoryPattern) -or ([System.IO.Path]::GetFileName($normalized) -match $filePattern)
}

function Get-BackupReason([string]$RelativePath) {
    $normalized = $RelativePath.Replace('\', '/')
    if ($normalized -match '(?i)(^|/)(backup|backups|copy|copies|old|trial|test|archive|archived)(/|$)') {
        return 'Archive-style directory'
    }
    return 'Archive-style filename'
}

function Test-StrongArchiveDirectory([string]$RelativePath) {
    return $RelativePath.Replace('\', '/') -match '(?i)(^|/)(backup|backups|copy|copies|old|trial|test|archive|archived)(/|$)'
}

Set-Location -LiteralPath $repositoryRoot

$indexRows = @{}
$indexLines = & git -c core.quotepath=false ls-files -s -- '*.rpt'
foreach ($line in $indexLines) {
    if ($line -match '^\d+\s+([0-9a-f]+)\s+\d+\t(.+)$') {
        $path = $Matches[2].Replace('\', '/')
        $indexRows[$path.ToLowerInvariant()] = [pscustomobject]@{
            Path = $path
            BlobHash = $Matches[1]
        }
    }
}

$projectIncludes = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
$projectPaths = & rg --files -g '*.vbproj' -g '*.csproj' -g '!**/bin/**' -g '!**/obj/**' -g '!**/packages/**' -g '!**/_Quarantine/**'
$projectPaths | ForEach-Object {
    $projectFile = Get-Item -LiteralPath (Join-Path $repositoryRoot $_)
    try {
        [xml]$xml = Get-Content -LiteralPath $projectFile.FullName
        foreach ($node in $xml.SelectNodes('//*[@Include]')) {
            $include = [string]$node.Include
            if ($include -match '(?i)\.rpt$') {
                $full = [System.IO.Path]::GetFullPath((Join-Path $projectFile.DirectoryName $include))
                if ($full.StartsWith($repositoryRoot, [System.StringComparison]::OrdinalIgnoreCase)) {
                    [void]$projectIncludes.Add((Get-RelativePath $full))
                }
            }
        }
    } catch {
        Write-Warning "Could not parse project file $($projectFile.FullName): $($_.Exception.Message)"
    }
}

$textReferencedNames = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
$referenceEvidence = @{}
$quotedReportPattern = '["'']([^"''\r\n<>]*?\.rpt)["'']|>([^<\r\n]*?\.rpt)<'
$sourcePaths = & rg --files -g '*.vb' -g '*.cs' -g '*.config' -g '*.xml' -g '*.sql' -g '*.vbproj' -g '*.csproj' -g '*.json' -g '*.txt' -g '!**/bin/**' -g '!**/obj/**' -g '!**/packages/**' -g '!**/_Quarantine/**'
$sourcePaths | ForEach-Object {
    $source = Get-Item -LiteralPath (Join-Path $repositoryRoot $_)
    try {
        $lineNumber = 0
        foreach ($line in [System.IO.File]::ReadLines($source.FullName)) {
            $lineNumber++
            if ($line.IndexOf('.rpt', [System.StringComparison]::OrdinalIgnoreCase) -lt 0) { continue }
            foreach ($match in [regex]::Matches($line, $quotedReportPattern, [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)) {
                $value = if ($match.Groups[1].Success) { $match.Groups[1].Value } else { $match.Groups[2].Value }
                $name = [System.IO.Path]::GetFileName($value.Replace('/', '\'))
                if ([string]::IsNullOrWhiteSpace($name)) { continue }
                [void]$textReferencedNames.Add($name)
                $key = $name.ToLowerInvariant()
                if (-not $referenceEvidence.ContainsKey($key)) {
                    $referenceEvidence[$key] = New-Object System.Collections.Generic.List[string]
                }
                if ($referenceEvidence[$key].Count -lt 5) {
                    $referenceEvidence[$key].Add("$(Get-RelativePath $source.FullName):$lineNumber")
                }
            }
        }
    } catch {
        Write-Warning "Could not scan $($source.FullName): $($_.Exception.Message)"
    }
}

$reports = foreach ($indexRow in $indexRows.Values) {
    $relativePath = $indexRow.Path
    $fullPath = Join-Path $repositoryRoot $relativePath.Replace('/', '\')
    $exists = [System.IO.File]::Exists($fullPath)
    $sizeBytes = 0
    if ($exists) {
        try {
            $sizeBytes = ([System.IO.FileInfo]::new($fullPath)).Length
        } catch {
            $exists = $false
        }
    }
    $fileName = [System.IO.Path]::GetFileName($relativePath)
    $projectIncluded = $projectIncludes.Contains($relativePath)
    $textReferenced = $textReferencedNames.Contains($fileName)
    $evidenceKey = $fileName.ToLowerInvariant()
    [pscustomobject]@{
        Path = $relativePath
        FullPath = $fullPath
        Exists = $exists
        BlobHash = $indexRow.BlobHash
        SizeBytes = $sizeBytes
        FileName = $fileName
        BackupStyle = Test-BackupStyle $relativePath
        BackupReason = if (Test-BackupStyle $relativePath) { Get-BackupReason $relativePath } else { '' }
        StrongArchiveDirectory = Test-StrongArchiveDirectory $relativePath
        ProjectIncluded = $projectIncluded
        TextReferenced = $textReferenced
        ReferenceEvidence = if ($referenceEvidence.ContainsKey($evidenceKey)) { $referenceEvidence[$evidenceKey] -join '; ' } else { '' }
        DuplicateCount = 1
        CanonicalPath = ''
        Classification = ''
        ProposedAction = 'Retain'
        QuarantinePath = ''
    }
}

foreach ($group in ($reports | Group-Object BlobHash | Where-Object Count -gt 1)) {
    $ranked = @($group.Group | Sort-Object `
        @{ Expression = { if ($_.ProjectIncluded) { 0 } else { 1 } } },
        @{ Expression = { if ($_.TextReferenced) { 0 } else { 1 } } },
        @{ Expression = { if (-not $_.BackupStyle) { 0 } else { 1 } } },
        @{ Expression = { $_.Path.Length } },
        Path)
    $canonical = $ranked[0]
    foreach ($report in $group.Group) {
        $report.DuplicateCount = $group.Count
        $report.CanonicalPath = $canonical.Path
    }
}

foreach ($report in $reports) {
    if (-not $report.Exists) {
        $report.Classification = 'Tracked path unavailable on this checkout'
        continue
    }
    if ($report.ProjectIncluded -or $report.TextReferenced) {
        $report.Classification = 'Protected by static or project reference'
        continue
    }
    if ($report.DuplicateCount -gt 1 -and $report.Path -ne $report.CanonicalPath -and $report.BackupStyle) {
        $report.Classification = 'Unreferenced exact duplicate with archive-style name/path'
        $report.ProposedAction = 'QuarantineExactDuplicate'
        continue
    }
    if ($report.DuplicateCount -gt 1 -and $report.Path -eq $report.CanonicalPath) {
        $report.Classification = 'Canonical copy retained for exact duplicate group'
        continue
    }
    if ($report.StrongArchiveDirectory) {
        $report.Classification = 'Unreferenced report in explicit archive directory'
        $report.ProposedAction = 'QuarantineBackupVariant'
        continue
    }
    if ($report.DuplicateCount -gt 1) {
        $report.Classification = 'Exact duplicate retained pending filename/path validation'
        continue
    }
    if ($report.BackupStyle) {
        $report.Classification = 'Archive-style filename retained pending runtime validation'
        continue
    }
    $report.Classification = 'No static reference found; retained because reports are loaded dynamically'
}

New-Item -ItemType Directory -Path $manifestRoot -Force | Out-Null
$inventoryPath = Join-Path $manifestRoot 'CrystalReportUsage.csv'
$planPath = Join-Path $manifestRoot 'QuarantinePlan.csv'
$reports | Sort-Object Path | Select-Object Path, Exists, BlobHash, SizeBytes, FileName, BackupStyle,
    BackupReason, ProjectIncluded, TextReferenced, ReferenceEvidence, DuplicateCount, CanonicalPath,
    Classification, ProposedAction | Export-Csv -LiteralPath $inventoryPath -NoTypeInformation -Encoding UTF8

$candidates = @($reports | Where-Object ProposedAction -ne 'Retain' | Sort-Object ProposedAction, Path)
$candidates | Select-Object Path, BlobHash, SizeBytes, DuplicateCount, CanonicalPath, Classification,
    ProposedAction, ProjectIncluded, TextReferenced | Export-Csv -LiteralPath $planPath -NoTypeInformation -Encoding UTF8

if ($ApplyQuarantine) {
    foreach ($report in $candidates) {
        $reasonDirectory = if ($report.ProposedAction -eq 'QuarantineExactDuplicate') { 'ExactDuplicates' } else { 'BackupVariants' }
        $destination = Join-Path (Join-Path $quarantineRoot $reasonDirectory) $report.Path.Replace('/', '\')
        $sourceResolved = [System.IO.Path]::GetFullPath($report.FullPath)
        $destinationResolved = [System.IO.Path]::GetFullPath($destination)
        if (-not $sourceResolved.StartsWith($repositoryRoot + '\', [System.StringComparison]::OrdinalIgnoreCase)) {
            throw "Source escaped repository root: $sourceResolved"
        }
        if (-not $destinationResolved.StartsWith($quarantineRoot + '\', [System.StringComparison]::OrdinalIgnoreCase)) {
            throw "Destination escaped quarantine root: $destinationResolved"
        }
        if (Test-Path -LiteralPath $destinationResolved) {
            throw "Quarantine destination already exists: $destinationResolved"
        }
        New-Item -ItemType Directory -Path (Split-Path -Parent $destinationResolved) -Force | Out-Null
        Move-Item -LiteralPath $sourceResolved -Destination $destinationResolved
        $report.QuarantinePath = Get-RelativePath $destinationResolved
    }
    $movedPath = Join-Path $manifestRoot 'QuarantinedReports.csv'
    $candidates | Select-Object Path, QuarantinePath, BlobHash, SizeBytes, DuplicateCount, CanonicalPath,
        Classification, ProposedAction | Export-Csv -LiteralPath $movedPath -NoTypeInformation -Encoding UTF8
}

$exactCount = @($candidates | Where-Object ProposedAction -eq 'QuarantineExactDuplicate').Count
$backupCount = @($candidates | Where-Object ProposedAction -eq 'QuarantineBackupVariant').Count
$bytes = ($candidates | Measure-Object SizeBytes -Sum).Sum
Write-Output "Tracked reports: $($reports.Count)"
Write-Output "Accessible reports: $(@($reports | Where-Object Exists).Count)"
Write-Output "Project/static-reference protected: $(@($reports | Where-Object { $_.ProjectIncluded -or $_.TextReferenced }).Count)"
Write-Output "Exact duplicate quarantine candidates: $exactCount"
Write-Output "Backup variant quarantine candidates: $backupCount"
Write-Output "Candidate size MB: $([math]::Round($bytes / 1MB, 2))"
Write-Output "Manifest: $(Get-RelativePath $inventoryPath)"
Write-Output "Plan: $(Get-RelativePath $planPath)"
if ($ApplyQuarantine) { Write-Output 'Quarantine moves applied.' } else { Write-Output 'Dry run only; no reports moved.' }
