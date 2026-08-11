param(
    [switch]$Apply
)

$ErrorActionPreference = 'Stop'
$repositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$expectedHash = '83E8F9725626F5599A9191DDDD6EC7832E8BAB4F3808EDB5954748BE47C0723E'
$resources = [ordered]@{
    'Accounts/PresentationLayer/Views/Forms/SalesJournalEntry.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/ReportSelectorForm.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/PettyCashClosingEntry.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/PcClosingEntry.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/EmployeeIdPrinting.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/DosagePrintingForm.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/DosageEntryTv.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/CustomerEntryTvOld.resx' = 'floDataDisplay.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/CustomerEntryTv.resx' = 'floDataDisplay.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/Copy/EmployeeIdPrinting.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/CheckPrinter.resx' = '$this.BackgroundImage'
    'Accounts/PresentationLayer/Views/Forms/CashReceiptJournalEntry.resx' = '$this.BackgroundImage'
}

$sharedBitmap = Join-Path $repositoryRoot 'Libraries\GlobalResources\Resources\GreenGradientBackgroundLarge.bmp'
if ((Get-FileHash -Algorithm SHA256 -LiteralPath $sharedBitmap).Hash -ne $expectedHash) {
    throw 'The shared bitmap does not match the expected embedded background.'
}

$totalBefore = 0L
$totalAfter = 0L
$embeddedCount = 0
$consolidatedCount = 0
foreach ($entry in $resources.GetEnumerator()) {
    $path = Join-Path $repositoryRoot $entry.Key.Replace('/', '\')
    if (-not [IO.File]::Exists($path)) { throw "Missing RESX file: $($entry.Key)" }
    [xml]$xml = Get-Content -LiteralPath $path
    $node = @($xml.SelectNodes("/root/data[@name='$($entry.Value)']"))
    if ($node.Count -eq 0) {
        $currentSize = ([IO.FileInfo]::new($path)).Length
        $totalBefore += $currentSize
        $totalAfter += $currentSize
        $consolidatedCount++
        Write-Output "$($entry.Key): already consolidated"
        continue
    }
    if ($node.Count -ne 1) { throw "Expected no more than one $($entry.Value) entry in $($entry.Key); found $($node.Count)." }
    $embeddedCount++
    $bytes = [Convert]::FromBase64String(([string]$node[0].value).Trim())
    $sha = [Security.Cryptography.SHA256]::Create()
    try { $hash = ([BitConverter]::ToString($sha.ComputeHash($bytes))).Replace('-', '') } finally { $sha.Dispose() }
    if ($hash -ne $expectedHash) { throw "Embedded bitmap hash differs in $($entry.Key)." }

    $before = ([IO.FileInfo]::new($path)).Length
    $totalBefore += $before
    if ($Apply) {
        $text = [IO.File]::ReadAllText($path, [Text.Encoding]::UTF8)
        $escapedName = [regex]::Escape($entry.Value)
        $pattern = "(?ms)^  <data name=`"$escapedName`"[^>]*>\r?\n.*?^  </data>\r?\n"
        $updated = [regex]::Replace($text, $pattern, '', 1)
        if ($updated.Length -eq $text.Length) { throw "Could not remove the resource block from $($entry.Key)." }
        [IO.File]::WriteAllText($path, $updated, [Text.UTF8Encoding]::new($true))
    }
    $after = if ($Apply) { ([IO.FileInfo]::new($path)).Length } else { $before - $bytes.Length }
    $totalAfter += $after
    Write-Output "$($entry.Key): $([math]::Round($before / 1MB, 2)) MB -> $([math]::Round($after / 1MB, 2)) MB"
}

Write-Output "RESX files: $($resources.Count)"
Write-Output "Embedded resources found: $embeddedCount"
Write-Output "Already consolidated: $consolidatedCount"
Write-Output "Approximate reduction MB: $([math]::Round(($totalBefore - $totalAfter) / 1MB, 2))"
if ($Apply) { Write-Output 'Duplicate embedded backgrounds removed where present.' } else { Write-Output 'Validation only; use -Apply to remove any embedded resources found.' }
