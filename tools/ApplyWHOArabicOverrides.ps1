$ErrorActionPreference = 'Stop'
$connectionString = 'Data Source=ibn-server;Initial Catalog=ISPData;Integrated Security=True;Connect Timeout=30'
$whoEndpoint = 'https://umd.emro.who.int/WHODictionary/Home/Search'

function Get-WhoArabic([string]$english) {
    $form = @{ targetLang = 'ara'; sourceLanguage = 'eng'; entry = $english; SearchCheck = 'Exactly_' }
    $response = Invoke-RestMethod -Uri $whoEndpoint -Method Post -Body $form -TimeoutSec 60
    if ($response.checkresult -ne 'found' -or $null -eq $response.TBSearchResultListALL) { return $null }
    $arabic = @($response.TBSearchResultListALL |
        Where-Object { $_.Language -eq 'ara' } |
        ForEach-Object { ([string]$_.Entry).Split('|')[0].Trim() } |
        Where-Object { $_ -ne '' })
    if ($arabic.Count -eq 0) { return $null }
    return $arabic[0]
}

$rows = New-Object System.Collections.Generic.List[object]
$connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
try {
    $connection.Open()
    $command = $connection.CreateCommand()
    $command.CommandText = 'SELECT TestCode,TestNameEnglish FROM dbo.MedicalFitnessReportLabTemplate ORDER BY TestCode;'
    $reader = $command.ExecuteReader()
    try { while ($reader.Read()) { $rows.Add([pscustomobject]@{TestCode=[string]$reader['TestCode']; English=[string]$reader['TestNameEnglish']}) } }
    finally { $reader.Dispose() }
} finally { $connection.Dispose() }

$updates = New-Object System.Collections.Generic.List[object]
$index = 0
foreach ($row in $rows) {
    $index++
    try {
        $arabic = Get-WhoArabic $row.English
        if ($arabic -and $arabic.Length -le 255) {
            $updates.Add([pscustomobject]@{TestCode=$row.TestCode;Arabic=$arabic;English=$row.English})
        }
    } catch { Write-Warning ("WHO lookup failed for " + $row.TestCode + ': ' + $_.Exception.Message) }
    if (($index % 25) -eq 0) { Write-Output ("Checked $index / " + $rows.Count + '; exact WHO matches: ' + $updates.Count) }
    Start-Sleep -Milliseconds 150
}

$connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
try {
    $connection.Open()
    $transaction = $connection.BeginTransaction()
    try {
        foreach ($row in $updates) {
            $command = $connection.CreateCommand()
            $command.Transaction = $transaction
            $command.CommandText = 'UPDATE dbo.MedicalFitnessReportLabTemplate SET TestNameArabic=@Arabic,ArabicTranslationReview=0 WHERE TestCode=@TestCode;'
            [void]$command.Parameters.Add('@Arabic',[System.Data.SqlDbType]::NVarChar,255)
            [void]$command.Parameters.Add('@TestCode',[System.Data.SqlDbType]::NVarChar,255)
            $command.Parameters['@Arabic'].Value = $row.Arabic
            $command.Parameters['@TestCode'].Value = $row.TestCode
            [void]$command.ExecuteNonQuery()
        }
        $transaction.Commit()
    } catch { $transaction.Rollback(); throw }
} finally { $connection.Dispose() }
Write-Output ("Applied " + $updates.Count + ' exact WHO Arabic overrides and marked them verified.')
