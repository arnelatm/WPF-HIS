param(
    [switch]$ApplyQuarantine
)

$ErrorActionPreference = 'Stop'
$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$quarantineRoot = Join-Path $repositoryRoot '_Quarantine\UnusedProjects_2026-08-11'
$manifestRoot = Join-Path $quarantineRoot 'Manifests'

$selectedRoots = [ordered]@{
    'ImageResizer' = 'Deeply nested standalone sample utility with its own solution.'
    'Libraries/CBaseControlsLibrary/LegacyProjects' = 'Explicitly named legacy project metadata; no active includes.'
    'Libraries/FlexibleMessageBox/WindowsFormsApp1' = 'Generic standalone Windows Forms sample.'
    'Libraries/GlobalFuncNSubxxxx' = 'Clearly obsolete duplicate-name library tree.'
    'Libraries/Image' = 'Standalone ReadingImagesFromSqlServer sample with its own solution.'
    'Libraries/MessagingLibrary/Demo_For_FlexibleMessageBox' = 'Explicitly named demo application.'
    'Libraries/TimePicker - Copy' = 'Explicit copy of a standalone control and test solution.'
}
$additionalFiles = @('Libraries/MessagingLibrary/Demo_For_FlexibleMessageBox.sln')

function Get-RelativePath([string]$FullPath) {
    return $FullPath.Substring($repositoryRoot.Length).TrimStart('\').Replace('\', '/')
}

function Test-UnderSelectedRoot([string]$RelativePath) {
    $normalized = $RelativePath.Replace('\', '/').TrimStart('/')
    foreach ($root in $selectedRoots.Keys) {
        if ($normalized.Equals($root, [StringComparison]::OrdinalIgnoreCase) -or
            $normalized.StartsWith($root.TrimEnd('/') + '/', [StringComparison]::OrdinalIgnoreCase)) {
            return $root
        }
    }
    return $null
}

Set-Location -LiteralPath $repositoryRoot

$hisProjects = [Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
foreach ($match in Select-String -LiteralPath 'HIS.sln' -Pattern '^Project\(.*\) = .*"([^"]+\.(vbproj|csproj|sqlproj))"') {
    [void]$hisProjects.Add([IO.Path]::GetFullPath((Join-Path $repositoryRoot $match.Matches[0].Groups[1].Value)))
}

$projectPaths = @(& rg --files -g '*.vbproj' -g '*.csproj' -g '*.sqlproj' -g '!**/bin/**' -g '!**/obj/**' -g '!**/packages/**' -g '!**/_Quarantine/**')
$projects = @($projectPaths | ForEach-Object { Get-Item -LiteralPath (Join-Path $repositoryRoot $_) })

$solutionMembership = @{}
$solutionPaths = @(& rg --files -g '*.sln' -g '!**/bin/**' -g '!**/obj/**' -g '!**/packages/**' -g '!**/_Quarantine/**')
foreach ($solutionPath in $solutionPaths) {
    $solutionFullPath = Join-Path $repositoryRoot $solutionPath
    $solutionDirectory = Split-Path -Parent $solutionFullPath
    foreach ($match in Select-String -LiteralPath $solutionFullPath -Pattern '^Project\(.*\) = .*"([^"]+\.(vbproj|csproj|sqlproj))"') {
        $projectFullPath = [IO.Path]::GetFullPath((Join-Path $solutionDirectory $match.Matches[0].Groups[1].Value))
        $key = $projectFullPath.ToLowerInvariant()
        if (-not $solutionMembership.ContainsKey($key)) { $solutionMembership[$key] = New-Object Collections.Generic.List[string] }
        $solutionMembership[$key].Add($solutionPath.Replace('\', '/'))
    }
}

$projectReferences = @{}
foreach ($project in $projects) {
    try {
        [xml]$xml = Get-Content -LiteralPath $project.FullName
        foreach ($node in $xml.SelectNodes('//*[local-name()="ProjectReference"]')) {
            $target = [IO.Path]::GetFullPath((Join-Path $project.DirectoryName ([string]$node.Include)))
            $key = $target.ToLowerInvariant()
            if (-not $projectReferences.ContainsKey($key)) { $projectReferences[$key] = New-Object Collections.Generic.List[string] }
            $projectReferences[$key].Add((Get-RelativePath $project.FullName))
        }
    } catch {
        Write-Warning "Could not parse $($project.FullName): $($_.Exception.Message)"
    }
}

$auditRows = foreach ($project in ($projects | Where-Object { -not $hisProjects.Contains($_.FullName) })) {
    $relativePath = Get-RelativePath $project.FullName
    $key = $project.FullName.ToLowerInvariant()
    $selectedRoot = Test-UnderSelectedRoot $relativePath
    $solutions = if ($solutionMembership.ContainsKey($key)) { @($solutionMembership[$key] | Where-Object { $_ -ne 'HIS.sln' }) } else { @() }
    $references = if ($projectReferences.ContainsKey($key)) { @($projectReferences[$key]) } else { @() }
    $classification = if ($selectedRoot) {
        'Quarantined - clear isolated legacy/sample project'
    } elseif ($references.Count -gt 0) {
        'Retained - referenced by another project'
    } elseif ($solutions.Count -gt 0) {
        'Retained - belongs to another solution'
    } else {
        'Retained - ambiguous standalone project'
    }
    [pscustomobject]@{
        Project = $relativePath
        Classification = $classification
        SelectedRoot = if ($selectedRoot) { $selectedRoot } else { '' }
        Reason = if ($selectedRoot) { $selectedRoots[$selectedRoot] } else { '' }
        OtherSolutions = $solutions -join '; '
        ReferencedByProjects = $references -join '; '
    }
}

$indexRows = @{}
foreach ($line in (& git -c core.quotepath=false ls-files -s)) {
    if ($line -match '^\d+\s+([0-9a-f]+)\s+\d+\t(.+)$') {
        $indexRows[$Matches[2].Replace('\', '/').ToLowerInvariant()] = [pscustomobject]@{ Path = $Matches[2].Replace('\', '/'); BlobHash = $Matches[1] }
    }
}

$moveRows = foreach ($entry in $indexRows.Values) {
    $selectedRoot = Test-UnderSelectedRoot $entry.Path
    $isAdditionalFile = $additionalFiles -contains $entry.Path
    if (-not $selectedRoot -and -not $isAdditionalFile) { continue }
    $source = Join-Path $repositoryRoot $entry.Path.Replace('/', '\')
    if (-not [IO.File]::Exists($source)) { continue }
    [pscustomobject]@{
        Path = $entry.Path
        QuarantinePath = "_Quarantine/UnusedProjects_2026-08-11/Files/$($entry.Path)"
        BlobHash = $entry.BlobHash
        SizeBytes = ([IO.FileInfo]::new($source)).Length
        SelectedRoot = if ($selectedRoot) { $selectedRoot } else { 'Associated solution file' }
        Reason = if ($selectedRoot) { $selectedRoots[$selectedRoot] } else { 'Solution file belonging to the quarantined demo project.' }
    }
}

New-Item -ItemType Directory -Path $manifestRoot -Force | Out-Null
$auditRows | Sort-Object Project | Export-Csv -LiteralPath (Join-Path $manifestRoot 'UnusedProjectAudit.csv') -NoTypeInformation -Encoding UTF8
$moveRows | Sort-Object Path | Export-Csv -LiteralPath (Join-Path $manifestRoot 'QuarantinePlan.csv') -NoTypeInformation -Encoding UTF8

if ($ApplyQuarantine) {
    foreach ($row in $moveRows) {
        $source = [IO.Path]::GetFullPath((Join-Path $repositoryRoot $row.Path.Replace('/', '\')))
        $destination = [IO.Path]::GetFullPath((Join-Path $repositoryRoot $row.QuarantinePath.Replace('/', '\')))
        if (-not $source.StartsWith($repositoryRoot + '\', [StringComparison]::OrdinalIgnoreCase)) { throw "Source escaped repository: $source" }
        if (-not $destination.StartsWith($quarantineRoot + '\', [StringComparison]::OrdinalIgnoreCase)) { throw "Destination escaped quarantine: $destination" }
        if (Test-Path -LiteralPath $destination) { throw "Destination already exists: $destination" }
        New-Item -ItemType Directory -Path (Split-Path -Parent $destination) -Force | Out-Null
        Move-Item -LiteralPath $source -Destination $destination
    }
    $moveRows | Sort-Object Path | Export-Csv -LiteralPath (Join-Path $manifestRoot 'QuarantinedFiles.csv') -NoTypeInformation -Encoding UTF8
}

$totalBytes = ($moveRows | Measure-Object SizeBytes -Sum).Sum
Write-Output "Projects outside HIS.sln: $($auditRows.Count)"
Write-Output "Projects selected for quarantine: $(@($auditRows | Where-Object Classification -like 'Quarantined*').Count)"
Write-Output "Tracked files selected: $($moveRows.Count)"
Write-Output "Selected size MB: $([math]::Round($totalBytes / 1MB, 2))"
if ($ApplyQuarantine) { Write-Output 'Quarantine moves applied.' } else { Write-Output 'Dry run only; no project files moved.' }
