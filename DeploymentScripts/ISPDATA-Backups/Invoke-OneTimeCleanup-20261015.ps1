#requires -Version 3.0
# User approved deletion of the exact reviewed 18-file manifest on 2026-10-15.
# No recursive deletion, ACL change, broad wildcard or automatic-cleanup update.
[CmdletBinding()]
param([string]$SourceDirectory=$PSScriptRoot)
$ErrorActionPreference='Stop'
Set-StrictMode -Version 2.0
if ([Environment]::MachineName -ne 'IBN-SERVER') { throw 'Deletion restricted to IBN-SERVER.' }
# Rebuild the protected chain and verify checksums before considering this frozen subset.
. (Join-Path $SourceDirectory 'New-OneTimeCleanupReview.ps1') -LibraryPath (Join-Path $SourceDirectory 'Invoke-BackupCleanup.ps1')

$approved=@(
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_034500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T00:45:01.0589551Z';Guid='1D5E4FA2-E83F-4338-B315-CCD95BDA9265';SetId=55759;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_040000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T01:00:01.4160913Z';Guid='82D6C0CE-4C95-42FE-8E4D-645B4B99EF82';SetId=55760;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_041500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T01:15:01.7353602Z';Guid='BCD4266A-7BAF-4DE9-8286-3C6BFD0DC76D';SetId=55761;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_043000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T01:30:01.1610829Z';Guid='F389BB99-2232-4360-81F9-B7174EC173E3';SetId=55762;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_044500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T01:45:01.4905971Z';Guid='E778F06E-C858-4ADC-832C-E717619C8BBA';SetId=55763;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_050000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T02:00:00.8620744Z';Guid='D98BE1D7-6C0E-45C2-A9C9-B5447D584502';SetId=55764;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_051500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T02:15:01.2516021Z';Guid='E8ADF1CE-B898-4790-BE50-EACEC9EBEF42';SetId=55765;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_053000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T02:30:01.6276748Z';Guid='95FA8DA9-633D-47D1-A705-3EF328A80CC8';SetId=55766;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_054500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T02:45:00.9674611Z';Guid='4B18DBB8-378D-4BA6-A457-722CEB5AA5F6';SetId=55767;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_060000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T03:00:01.3506038Z';Guid='40240D4D-C427-49E5-91DB-F69566C4BBDF';SetId=55768;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_061500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T03:15:01.7426292Z';Guid='619A2757-A4CF-4705-8626-11D748189654';SetId=55769;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_063000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T03:30:01.1056088Z';Guid='E1BE8230-C7B7-4357-ADDA-2208F62857C8';SetId=55770;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_064500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T03:45:01.5110710Z';Guid='96C695A2-A4EE-4A49-A3E6-9E2395EDA6F6';SetId=55771;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_070000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T04:00:00.8466568Z';Guid='9FDA8A53-B67E-45A4-BD64-917C7ACE8ABB';SetId=55772;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_071500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T04:15:01.2068202Z';Guid='38E5A2D4-EC5E-449A-9109-60FC64FDF402';SetId=55773;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_073000.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T04:30:01.6017450Z';Guid='47EA9B63-8BA1-4988-80F0-79888F42786E';SetId=55774;Position=1}
    [pscustomobject]@{Mode='Log';Path='F:\ISPDataBackup\Logs\ISPData_Log_20261001_074500.trn';Bytes=[long]24576;ExpectedUtc='2026-10-01T04:45:00.9537538Z';Guid='0608D49A-2D42-4158-B136-90FAD2DF7996';SetId=55775;Position=1}
    [pscustomobject]@{Mode='Daily';Path='E:\SQLBackupFallback\ISPDataBackup\ISPData_20260505.BAK';Bytes=[long]53078016;ExpectedUtc='2026-05-05T15:31:51.6331051Z';Guid='8C142033-4B21-4C60-98D9-A52D1B2295DB';SetId=41246;Position=1}
)
if ($approved.Count -ne 18 -or @($approved | Select-Object -ExpandProperty Path -Unique).Count -ne 18) { throw 'Exact approved manifest is invalid.' }
$approvedBytes=[long]0
foreach ($entry in $approved) { $approvedBytes+=$entry.Bytes }
if ($approvedBytes -ne 53495808) { throw 'Approved byte total changed.' }
$allowedFolders=@('F:\ISPDataBackup','F:\ISPDataBackup\Logs','E:\SQLBackupFallback\ISPDataBackup','E:\SQLBackupFallback\ISPDataBackup\Logs')
$executionFile=Join-Path $auditFolder ('OneTimeDelete_'+(Get-Date).ToString('yyyyMMdd_HHmmss')+'_'+[guid]::NewGuid().ToString('N')+'.jsonl')
$stream=New-Object IO.FileStream $executionFile,([IO.FileMode]::CreateNew),([IO.FileAccess]::Write),([IO.FileShare]::Read)
$script:AuditWriter=New-Object IO.StreamWriter $stream,(New-Object Text.UTF8Encoding $false)
$deleted=0; $deletedBytes=[long]0; $failed=0
try {
    Write-CleanupAudit @{Event='Start';Purpose='User-approved exact manifest deletion';ManifestSHA256='81a4b2c9acf9e78d9f5f7f125ff5d9934deee56bbebaefbbd9aa5079f9c0e595';ApprovedFiles=18;ApprovedBytes=53495808;ReviewAudit=$auditFile;Apply=$true}
    $ready=New-Object 'System.Collections.Generic.List[object]'
    foreach ($entry in $approved) {
        $planned=@($allActions | Where-Object { $_.Path -eq $entry.Path -and $_.Mode -eq $entry.Mode -and $_.Action -eq 'DeleteCandidate' })
        if ($planned.Count -ne 1) { throw ('Approved file no longer qualifies: '+$entry.Path) }
        $utc=[datetime]::Parse($entry.ExpectedUtc,[Globalization.CultureInfo]::InvariantCulture,[Globalization.DateTimeStyles]::RoundtripKind)
        $f=[pscustomobject]@{Path=$entry.Path;Length=$entry.Bytes;LastWriteTimeUtc=$utc}
        [void](Assert-UnchangedCandidate $f $allowedFolders $entry.Mode)
        $sets=@($history.Rows | Where-Object { [int]$_.SetId -eq $entry.SetId -and [string]$_.Guid -eq $entry.Guid -and [string]$_.File -eq $entry.Path -and [int]$_.Position -eq $entry.Position })
        if ($sets.Count -ne 1 -or -not (Assert-BackupHeader $sets[0])) { throw ('Approved backup identity changed: '+$entry.Path) }
        $ready.Add([pscustomobject]@{Entry=$entry;File=$f;Backup=$sets[0]})
        Write-CleanupAudit @{Event='PreflightPassed';Path=$entry.Path;Guid=$entry.Guid;Bytes=$entry.Bytes}
    }
    foreach ($item in ($ready | Sort-Object @{Expression={$_.Entry.Mode}},@{Expression={$_.Entry.Path}})) {
        $entry=$item.Entry
        $target=Assert-UnchangedCandidate $item.File $allowedFolders $entry.Mode
        $headerKey=(Get-PathKey $entry.Path)+'|'+[string]$entry.Position+'|'+$entry.Guid
        $script:HeaderCache.Remove($headerKey)
        if (-not (Assert-BackupHeader $item.Backup)) { throw ('Header changed before deletion: '+$entry.Path) }
        Write-CleanupAudit @{Event='DeleteIntent';Path=$target;Guid=$entry.Guid;Bytes=$entry.Bytes}
        try {
            Remove-Item -LiteralPath $target -Force -ErrorAction Stop
        } catch {
            Write-CleanupAudit @{Event='DeleteFailed';Path=$target;Message=$_.Exception.Message}
            $failed++
            continue
        }
        if (Test-Path -LiteralPath $target -ErrorAction Stop) { throw ('Deletion did not remove approved file: '+$target) }
        $deleted++; $deletedBytes+=$entry.Bytes
        Write-CleanupAudit @{Event='Deleted';Path=$target;Guid=$entry.Guid;Bytes=$entry.Bytes}
    }
    Write-CleanupAudit @{Event='Complete';Deleted=$deleted;DeletedBytes=$deletedBytes;Failed=$failed;ApprovedFiles=18}
    Write-Output ('EXACT CLEANUP: '+$deleted+' files deleted; '+$deletedBytes+' bytes; '+$failed+' failed. Audit: '+$executionFile)
    if ($failed -gt 0) { throw 'Some approved files could not be deleted; no permissions were changed. Inspect audit.' }
} catch {
    try { Write-CleanupAudit @{Event='Failure';Message=$_.Exception.Message;Deleted=$deleted;DeletedBytes=$deletedBytes;Failed=$failed} } catch { }
    throw
} finally { $script:AuditWriter.Dispose() }
