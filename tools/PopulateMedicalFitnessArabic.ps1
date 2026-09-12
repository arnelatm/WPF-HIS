param(
    [switch]$Apply,
    [int]$PreviewCount = 20
)

$ErrorActionPreference = 'Stop'
$server = 'ibn-server'
$database = 'ISPData'
$connectionString = "Data Source=$server;Initial Catalog=$database;Integrated Security=True;Connect Timeout=30"

function Get-Translation([string]$english) {
    $query = [Uri]::EscapeDataString($english)
    $uri = "https://api.mymemory.translated.net/get?q=$query&langpair=en|ar&de=codex@openai.com"
    for ($attempt = 1; $attempt -le 3; $attempt++) {
        try {
            $response = Invoke-RestMethod -Uri $uri -UseBasicParsing -TimeoutSec 30
            $translated = [string]$response.responseData.translatedText
            if (-not [string]::IsNullOrWhiteSpace($translated)) {
                return $translated.Trim()
            }
        } catch {
            if ($attempt -eq 3) { throw }
            Start-Sleep -Seconds 2
        }
    }
    throw "No translation returned for: $english"
}

$rows = New-Object System.Collections.Generic.List[object]
$connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
try {
    $connection.Open()
    $command = $connection.CreateCommand()
    $command.CommandText = @"
SELECT TestCode, TestNameEnglish
FROM dbo.MedicalFitnessReportLabTemplate
WHERE TestNameArabic IS NULL OR LTRIM(RTRIM(TestNameArabic)) = N''
ORDER BY TestCode;
"@
    $reader = $command.ExecuteReader()
    try {
        while ($reader.Read()) {
            $rows.Add([pscustomobject]@{ TestCode = [string]$reader['TestCode']; English = [string]$reader['TestNameEnglish'] })
        }
    } finally { $reader.Dispose() }
} finally { $connection.Dispose() }

Write-Output "Rows requiring translation: $($rows.Count)"
$translatedRows = New-Object System.Collections.Generic.List[object]
$index = 0
$applied = 0
$writeConnection = $null
function Apply-Batch([object[]]$batch) {
    if (-not $Apply -or $batch.Count -eq 0) { return }
    if ($null -eq $script:writeConnection) {
        $script:writeConnection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
        $script:writeConnection.Open()
    }
    $transaction = $script:writeConnection.BeginTransaction()
    try {
        foreach ($item in $batch) {
            $command = $script:writeConnection.CreateCommand()
            $command.Transaction = $transaction
            $command.CommandText = "UPDATE dbo.MedicalFitnessReportLabTemplate SET TestNameArabic=@Arabic, ArabicTranslationReview=1 WHERE TestCode=@TestCode AND (TestNameArabic IS NULL OR LTRIM(RTRIM(TestNameArabic))=N'');"
            [void]$command.Parameters.Add('@Arabic', [System.Data.SqlDbType]::NVarChar, 255)
            [void]$command.Parameters.Add('@TestCode', [System.Data.SqlDbType]::NVarChar, 255)
            $command.Parameters['@Arabic'].Value = $item.Arabic
            $command.Parameters['@TestCode'].Value = $item.TestCode
            [void]$command.ExecuteNonQuery()
        }
        $transaction.Commit()
        $script:applied += $batch.Count
        Write-Output "Applied $($script:applied) translations"
    } catch {
        $transaction.Rollback()
        throw
    }
}
foreach ($row in $rows) {
    $index++
    $arabic = Get-Translation $row.English
    if ($arabic.Length -gt 255) { $arabic = $arabic.Substring(0, 255) }
    $translatedRows.Add([pscustomobject]@{ TestCode = $row.TestCode; English = $row.English; Arabic = $arabic })
    if ($Apply -and $translatedRows.Count -ge 25) {
        Apply-Batch $translatedRows.ToArray()
        $translatedRows.Clear()
    }
    if (($index % 25) -eq 0) { Write-Output "Translated $index / $($rows.Count)" }
    Start-Sleep -Milliseconds 150
}

$translatedRows | Select-Object -First $PreviewCount | Format-Table -AutoSize
if (-not $Apply) {
    Write-Output 'Preview only. Re-run with -Apply after reviewing the generated values.'
    exit 0
}

$connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
try {
    $connection.Open()
    $transaction = $connection.BeginTransaction()
    try {
        foreach ($row in $translatedRows) {
            $command = $connection.CreateCommand()
            $command.Transaction = $transaction
            $command.CommandText = @"
UPDATE dbo.MedicalFitnessReportLabTemplate
SET TestNameArabic = @Arabic, ArabicTranslationReview = 1
WHERE TestCode = @TestCode
  AND (TestNameArabic IS NULL OR LTRIM(RTRIM(TestNameArabic)) = N'');
"@
            [void]$command.Parameters.Add('@Arabic', [System.Data.SqlDbType]::NVarChar, 255)
            [void]$command.Parameters.Add('@TestCode', [System.Data.SqlDbType]::NVarChar, 255)
            $command.Parameters['@Arabic'].Value = $row.Arabic
            $command.Parameters['@TestCode'].Value = $row.TestCode
            [void]$command.ExecuteNonQuery()
        }
        $transaction.Commit()
    } catch {
        $transaction.Rollback()
        throw
    }
} finally { $connection.Dispose() }
Apply-Batch $translatedRows.ToArray()
if ($null -ne $writeConnection) { $writeConnection.Dispose() }
Write-Output "Applied $applied translations; all remain marked for review."
