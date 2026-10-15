#requires -Version 3.0
# One-time read-only list; no deletion or production job/policy update.
[CmdletBinding()]
param([string]$LibraryPath=(Join-Path $PSScriptRoot 'Invoke-BackupCleanup.ps1'))
$ErrorActionPreference='Stop'
Set-StrictMode -Version 2.0
if ([Environment]::MachineName -ne 'IBN-SERVER') { throw 'Review is restricted to IBN-SERVER.' }
$reviewLibrary=[IO.File]::ReadAllText($LibraryPath)
$anchorNeedle='$cutoff=$Now.AddDays(-$LogDays)'
$expiryNeedle='if ($CleanupMode -eq ''Log'') { $deleteBefore=$cutoff }'
if ($reviewLibrary.Split(@($anchorNeedle),[StringSplitOptions]::None).Count -ne 2 -or $reviewLibrary.Split(@($expiryNeedle),[StringSplitOptions]::None).Count -ne 2) { throw 'Shared planner changed; stop for review.' }
# Anchor only this private review at the restored full; expiry remains 14/31 days, 12 months.
$reviewLibrary=$reviewLibrary.Replace($anchorNeedle,'$cutoff=[datetime]''2026-10-14T01:00:03''')
$reviewLibrary=$reviewLibrary.Replace($expiryNeedle,'if ($CleanupMode -eq ''Log'') { $deleteBefore=$Now.AddDays(-$LogDays) }')
. ([scriptblock]::Create($reviewLibrary)) -LibraryOnly
$script:HeaderCache=@{}
$identity=Invoke-ReadOnlySql @'
SELECT CONVERT(nvarchar(128),SERVERPROPERTY('MachineName')) AS MachineName,d.state_desc,d.recovery_model_desc,r.family_guid,r.recovery_fork_guid,GETDATE() AS ServerNow
FROM sys.databases d JOIN sys.database_recovery_status r ON r.database_id=d.database_id WHERE d.name=@Database;
'@ @{'@Database'=$Database}
if ($identity.Rows.Count -ne 1 -or [string]$identity.Rows[0].MachineName -ne 'IBN-SERVER' -or [string]$identity.Rows[0].state_desc -ne 'ONLINE' -or [string]$identity.Rows[0].recovery_model_desc -ne 'FULL') { throw 'Unexpected database identity.' }
$now=[datetime]$identity.Rows[0].ServerNow
$history=Invoke-ReadOnlySql @'
SELECT bs.backup_set_id AS SetId,bs.type AS Kind,bs.backup_start_date AS Start,bs.backup_finish_date AS Finish,bs.first_lsn AS FirstLSN,bs.last_lsn AS LastLSN,
bs.checkpoint_lsn AS CheckpointLSN,bs.last_recovery_fork_guid AS Fork,bs.first_recovery_fork_guid AS FirstFork,bs.family_guid AS Family,bs.backup_set_uuid AS Guid,
bs.position AS Position,mf.physical_device_name AS [File],bs.has_backup_checksums AS HasChecksum,bs.is_damaged AS IsDamaged,bs.is_copy_only AS IsCopyOnly,
(SELECT COUNT(*) FROM msdb.dbo.backupmediafamily x WHERE x.media_set_id=bs.media_set_id) AS FamilyCount
FROM msdb.dbo.backupset bs JOIN msdb.dbo.backupmediafamily mf ON mf.media_set_id=bs.media_set_id
WHERE bs.database_name=@Database AND bs.type IN('D','L') AND mf.device_type=2;
'@ @{'@Database'=$Database}
$expectedGuid='a9abd86a-45e3-460b-aac9-14f70fab25fa'
$activeRoots=@($Roots | ForEach-Object { if (Test-Path -LiteralPath $_ -PathType Container -ErrorAction Stop) { Assert-PlainDirectory $_ } })
if ($activeRoots.Count -eq 0) { throw 'No approved roots accessible.' }
$auditFolder=Assert-PlainDirectory $AuditDirectory
$tag='OneTimeReview_'+$now.ToString('yyyyMMdd_HHmmss')+'_'+[guid]::NewGuid().ToString('N')
$auditFile=Join-Path $auditFolder ($tag+'.jsonl')
$candidateFile=Join-Path $auditFolder ($tag+'_Candidates.csv')
$inventoryFile=Join-Path $auditFolder ($tag+'_Inventory.csv')
$stream=New-Object IO.FileStream $auditFile,([IO.FileMode]::CreateNew),([IO.FileAccess]::Write),([IO.FileShare]::Read)
$script:AuditWriter=New-Object IO.StreamWriter $stream,(New-Object Text.UTF8Encoding $false)
try {
    Write-CleanupAudit @{Event='Start';Apply=$false;Purpose='Review only';BaselineGuid=$expectedGuid;LogRetentionDays=14;DailyRetentionDays=31;MonthlyRetentionMonths=12}
    $allActions=New-Object 'System.Collections.Generic.List[object]'
    $verified=@{}
    # Required media may be on a share readable by the engine but not the Agent identity.
    # This only establishes existence for protection; actual headers/checksums are verified below.
    $existsCache=@{}
    $exists={param($path)
        $key=Get-PathKey $path
        if (-not $existsCache.ContainsKey($key)) {
            $result=Invoke-ReadOnlySql 'DECLARE @r TABLE(FileExists int,IsDirectory int,ParentExists int); INSERT INTO @r EXEC master.dbo.xp_fileexist @File; SELECT FileExists,IsDirectory FROM @r;' @{'@File'=[string]$path}
            $existsCache[$key]=($result.Rows.Count -eq 1 -and [int]$result.Rows[0].FileExists -eq 1 -and [int]$result.Rows[0].IsDirectory -eq 0)
        }
        return $existsCache[$key]
    }
    foreach ($reviewMode in @('Log','Daily','Monthly')) {
        $inventory=New-Object 'System.Collections.Generic.List[object]'
        foreach ($root in $activeRoots) {
            $folder=$root
            if ($reviewMode -eq 'Log') { $folder=Join-Path $root 'Logs' } elseif ($reviewMode -eq 'Monthly') { $folder=Join-Path $root 'Monthly' }
            if (-not (Test-Path -LiteralPath $folder -PathType Container -ErrorAction Stop)) { continue }
            $folder=Assert-PlainDirectory $folder
            foreach ($item in Get-ChildItem -LiteralPath $folder -File -Force -ErrorAction Stop) {
                if (($item.Attributes -band [IO.FileAttributes]::ReparsePoint) -ne 0) { Write-CleanupAudit @{Event='Keep';Path=$item.FullName;Reason='Reparse point'}; continue }
                $inventory.Add([pscustomobject]@{Path=$item.FullName;Name=$item.Name;Length=$item.Length;LastWriteTime=$item.LastWriteTime;LastWriteTimeUtc=$item.LastWriteTimeUtc})
            }
        }
        $planArgs=@{Backups=@($history.Rows);Files=$inventory.ToArray();Now=$now;Family=[string]$identity.Rows[0].family_guid;Fork=[string]$identity.Rows[0].recovery_fork_guid;CleanupMode=$reviewMode;LogDays=14;DailyDays=31;MonthlyMonths=12;PathExists=$exists;ValidateBackup={param($b) Assert-BackupHeader $b}}
        $plan=Get-RetentionPlan @planArgs
        if ([string]$plan.Anchor.Guid -ne $expectedGuid) { throw 'Anchor is not the full restored on ISPADMIN2.' }
        foreach ($backup in (@($plan.Anchor,$plan.LatestFull)+@($plan.Chain))) {
            $key=[string]$backup.Guid+'|'+(Get-PathKey $backup.File)+'|'+[string]$backup.Position
            if ($verified.ContainsKey($key)) { continue }
            [void](Invoke-ReadOnlySql 'RESTORE VERIFYONLY FROM DISK=@File WITH FILE=@Position,CHECKSUM,STOP_ON_ERROR;' @{'@File'=[string]$backup.File;'@Position'=[int]$backup.Position})
            $verified[$key]=$true
            Write-CleanupAudit @{Event='ChecksumVerified';Path=$backup.File;Guid=[string]$backup.Guid;Position=[int]$backup.Position}
        }
        Write-CleanupAudit @{Event='RecoveryChain';Mode=$reviewMode;Anchor=$plan.Anchor.File;AnchorGuid=[string]$plan.Anchor.Guid;LogFiles=$plan.Chain.Count;ThroughLSN=[string]$plan.ThroughLSN}
        foreach ($action in $plan.Actions) {
            $allActions.Add([pscustomobject]@{Mode=$reviewMode;Action=$action.Action;Path=$action.File.Path;Bytes=[long]$action.File.Length;LastWriteTimeUtc=$action.File.LastWriteTimeUtc.ToString('o');Reason=$action.Reason})
        }
    }
    $candidates=@($allActions | Where-Object { $_.Action -eq 'DeleteCandidate' })
    $allActions.ToArray() | Export-Csv -LiteralPath $inventoryFile -NoTypeInformation -Encoding UTF8 -NoClobber
    if ($candidates.Count -gt 0) { $candidates | Export-Csv -LiteralPath $candidateFile -NoTypeInformation -Encoding UTF8 -NoClobber } else { $candidateFile='None' }
    $bytes=[decimal]0
    foreach ($candidate in $candidates) { $bytes+=[decimal]$candidate.Bytes }
    Write-CleanupAudit @{Event='Complete';Apply=$false;Deleted=0;Candidates=$candidates.Count;CandidateBytes=[string]$bytes;CandidateFile=$candidateFile;InventoryFile=$inventoryFile;VerifiedMedia=$verified.Count}
    Write-Output ('REVIEW ONLY: '+$candidates.Count+' candidates, '+$bytes+' bytes, 0 deleted.')
    Write-Output ('Candidates: '+$candidateFile)
    Write-Output ('Inventory: '+$inventoryFile)
    Write-Output ('Audit: '+$auditFile)
} catch { try { Write-CleanupAudit @{Event='Failure';Message=$_.Exception.Message;Deleted=0} } catch { }; throw } finally { $script:AuditWriter.Dispose() }
