#requires -Version 3.0
[CmdletBinding(SupportsShouldProcess=$true)]
param(
    [ValidateSet('Daily','Monthly','Log')][string]$Mode='Log',
    [string]$SqlInstance='IBN-SERVER',
    [string]$ExpectedMachine='IBN-SERVER',
    [string]$Database='ISPDATA',
    [string[]]$Roots=@('F:\ISPDataBackup','E:\SQLBackupFallback\ISPDataBackup'),
    [ValidateRange(1,3650)][int]$LogRetentionDays=14,
    [ValidateRange(1,3650)][int]$DailyRetentionDays=31,
    [ValidateRange(1,120)][int]$MonthlyRetentionMonths=12,
    [string]$AuditDirectory='E:\SQLBackupFallback\ISPDataBackup\Audit',
    [switch]$Apply,
    [switch]$LibraryOnly
)
Set-StrictMode -Version 2.0
$ErrorActionPreference='Stop'

function Get-PathKey([string]$Path) {
    if (-not [IO.Path]::IsPathRooted($Path)) { throw 'Backup paths must be absolute.' }
    return [IO.Path]::GetFullPath($Path).TrimEnd('\').ToLowerInvariant()
}

function Test-ManagedBackupName([string]$Name,[string]$Kind) {
    switch ($Kind) {
        'Daily' { $pattern='^ISPData_(?<Date>\d{8})(?:_(?<Time>\d{6})_[0-9a-f]{32})?\.bak$' }
        'Monthly' { $pattern='^ISPData_MonthEnd_(?<Month>\d{6})(?:_(?<Date>\d{8})_(?<Time>\d{6})_[0-9a-f]{32})?\.bak$' }
        'Log' { $pattern='^ISPData_Log_(?<Date>\d{8})_(?<Time>\d{6})(?:_[0-9a-f]{32})?\.trn$' }
        default { return $false }
    }
    $match=[regex]::Match($Name,$pattern,[Text.RegularExpressions.RegexOptions]::IgnoreCase)
    if (-not $match.Success) { return $false }
    $date=$match.Groups['Date'].Value
    if ($date -eq '') { $date=$match.Groups['Month'].Value+'01' }
    $time=$match.Groups['Time'].Value; if ($time -eq '') { $time='000000' }
    $parsed=[datetime]::MinValue
    if (-not [datetime]::TryParseExact(($date+$time),'yyyyMMddHHmmss',[Globalization.CultureInfo]::InvariantCulture,[Globalization.DateTimeStyles]::None,[ref]$parsed)) {
        return $false
    }
    if ($Kind -eq 'Monthly' -and $match.Groups['Date'].Success -and $date.Substring(0,6) -ne $match.Groups['Month'].Value) {
        return $false
    }
    return $true
}

function Get-RetentionPlan {
    param([object[]]$Backups,[object[]]$Files,[datetime]$Now,[string]$Family,[string]$Fork,
          [string]$CleanupMode,[int]$LogDays,[int]$DailyDays,[int]$MonthlyMonths,
          [scriptblock]$PathExists,[scriptblock]$ValidateBackup)
    $cutoff=$Now.AddDays(-$LogDays)
    # History can contain obsolete records from INIT overwrites. Keep the latest set per file/position.
    $latestByPosition=@{}
    foreach ($b in $Backups) {
        if ([string]$b.Family -ne $Family -or [string]$b.Fork -ne $Fork -or
            [string]$b.FirstFork -ne $Fork -or $b.IsDamaged -or -not $b.HasChecksum -or
            [int]$b.FamilyCount -ne 1) { continue }
        $key=(Get-PathKey $b.File)+'|'+[string]$b.Position
        if (-not $latestByPosition.ContainsKey($key) -or [int]$b.SetId -gt [int]$latestByPosition[$key].SetId) {
            $latestByPosition[$key]=$b
        }
    }
    $valid=@($latestByPosition.Values)
    $fulls=@($valid | Where-Object { $_.Kind -eq 'D' } | Sort-Object Finish -Descending)
    if ($fulls.Count -eq 0) { throw 'No checksum-protected full backup in the current family/fork; cleanup held.' }
    if (($Now-[datetime]$fulls[0].Finish).TotalHours -gt 26) { throw 'Latest full backup is overdue; cleanup held.' }
    if (-not (& $PathExists $fulls[0].File) -or -not (& $ValidateBackup $fulls[0])) {
        throw 'Latest full backup media is unavailable or mismatched; cleanup held.'
    }
    $anchor=$null
    foreach ($b in $fulls) {
        if ([datetime]$b.Finish -le $cutoff -and (& $PathExists $b.File)) {
            if (-not (& $ValidateBackup $b)) { throw 'Recovery-boundary full header mismatched; cleanup held.' }
            $anchor=$b
            break
        }
    }
    if ($null -eq $anchor) { throw 'No accessible full backup before the PITR cutoff; cleanup held.' }
    $logs=@($valid | Where-Object { $_.Kind -eq 'L' -and -not $_.IsCopyOnly } |
        Sort-Object @{Expression={[decimal]$_.FirstLSN}},@{Expression={[decimal]$_.LastLSN};Descending=$true})
    if ($logs.Count -eq 0) { throw 'No ordinary log backups; cleanup held.' }
    $newest=@($logs | Sort-Object Finish -Descending)[0]
    if (($Now-[datetime]$newest.Finish).TotalMinutes -gt 30) { throw 'Latest log backup is overdue; cleanup held.' }
    # LSNs exceed IEEE double precision: keep comparisons decimal throughout.
    $goal=[decimal]0
    foreach ($b in $logs) { if ([decimal]$b.LastLSN -gt $goal) { $goal=[decimal]$b.LastLSN } }
    $cursor=[decimal]$anchor.LastLSN
    $protected=@{}
    $protectedGuids=@{}
    $protectedGuids[[string]$anchor.Guid]=$true
    $protectedGuids[[string]$fulls[0].Guid]=$true
    $protected[(Get-PathKey $anchor.File)]=$true
    $protected[(Get-PathKey $fulls[0].File)]=$true
    $chain=New-Object 'System.Collections.Generic.List[object]'
    $index=0
    while ($cursor -lt $goal) {
        $best=$null
        while ($index -lt $logs.Count -and [decimal]$logs[$index].FirstLSN -le $cursor) {
            $candidate=$logs[$index]
            if ([decimal]$candidate.LastLSN -gt $cursor -and
                ($null -eq $best -or [decimal]$candidate.LastLSN -gt [decimal]$best.LastLSN) -and
                (& $PathExists $candidate.File)) { $best=$candidate }
            $index++
        }
        if ($null -eq $best) { throw ('Log coverage is missing at LSN '+$cursor+'; cleanup held.') }
        if (-not (& $ValidateBackup $best)) { throw 'Required log header mismatched; cleanup held.' }
        $chain.Add($best)
        $protectedGuids[[string]$best.Guid]=$true
        $protected[(Get-PathKey $best.File)]=$true
        $cursor=[decimal]$best.LastLSN
    }
    if ($CleanupMode -eq 'Log') { $deleteBefore=$cutoff }
    elseif ($CleanupMode -eq 'Daily') { $deleteBefore=$Now.AddDays(-$DailyDays) }
    else { $deleteBefore=$Now.AddMonths(-$MonthlyMonths) }
    $byFile=@{}
    foreach ($b in $valid) {
        $key=Get-PathKey $b.File
        if (-not $byFile.ContainsKey($key)) { $byFile[$key]=New-Object 'System.Collections.Generic.List[object]' }
        $byFile[$key].Add($b)
    }
    $actions=New-Object 'System.Collections.Generic.List[object]'
    foreach ($f in $Files) {
        $key=Get-PathKey $f.Path
        $action='Keep'; $reason='Outside managed filename pattern'
        if (Test-ManagedBackupName $f.Name $CleanupMode) {
            $reason='Within retention period'
            if ([datetime]$f.LastWriteTime -lt $deleteBefore) {
                $reason='Protected recovery-chain media'
                if (-not $protected.ContainsKey($key)) {
                    $reason='Unmapped or multi-set media; manual review required'
                    if ($byFile.ContainsKey($key) -and $byFile[$key].Count -eq 1) {
                        $b=$byFile[$key][0]
                        $expectedKind='D'; if ($CleanupMode -eq 'Log') { $expectedKind='L' }
                        if ($b.Kind -eq $expectedKind -and -not $protectedGuids.ContainsKey([string]$b.Guid) -and
                            -not $b.IsCopyOnly -and [datetime]$b.Finish -lt $deleteBefore -and
                            [int]$b.Position -eq 1 -and (& $ValidateBackup $b)) {
                            $action='DeleteCandidate'; $reason='Expired and not needed by verified retained chain'
                        } else { $reason='Backup metadata/header/age did not authorize deletion' }
                    }
                }
            }
        }
        $actions.Add([pscustomobject]@{File=$f;Action=$action;Reason=$reason})
    }
    return [pscustomobject]@{Anchor=$anchor;LatestFull=$fulls[0];Chain=@($chain.ToArray());
        ThroughLSN=$cursor;Cutoff=$cutoff;Actions=@($actions.ToArray())}
}

function Assert-PlainDirectory([string]$Path) {
    $full=[IO.Path]::GetFullPath($Path)
    if ($full.TrimEnd('\') -eq [IO.Path]::GetPathRoot($full).TrimEnd('\')) { throw 'Filesystem roots are not cleanup/audit directories.' }
    $item=Get-Item -LiteralPath $full -Force -ErrorAction Stop
    if (-not $item.PSIsContainer) { throw 'Expected an existing directory.' }
    while ($null -ne $item) {
        if (($item.Attributes -band [IO.FileAttributes]::ReparsePoint) -ne 0) { throw 'Reparse-point directories are not permitted.' }
        $item=$item.Parent
    }
    return $full.TrimEnd('\')
}

function Assert-UnchangedCandidate($File,[string[]]$AllowedFolders,[string]$CleanupMode) {
    $item=Get-Item -LiteralPath $File.Path -Force -ErrorAction Stop
    if ($item.PSIsContainer -or ($item.Attributes -band [IO.FileAttributes]::ReparsePoint) -ne 0) {
        throw 'Deletion candidate is not a plain file.'
    }
    $parent=Assert-PlainDirectory $item.DirectoryName
    if (@($AllowedFolders | Where-Object { (Get-PathKey $_) -eq (Get-PathKey $parent) }).Count -ne 1) {
        throw 'Deletion candidate is outside the reviewed folders.'
    }
    if (-not (Test-ManagedBackupName $item.Name $CleanupMode)) { throw 'Deletion candidate filename changed.' }
    if ([long]$item.Length -ne [long]$File.Length -or $item.LastWriteTimeUtc.Ticks -ne $File.LastWriteTimeUtc.Ticks) {
        throw 'Deletion candidate changed after planning; cleanup stopped.'
    }
    return $item.FullName
}

function Invoke-ReadOnlySql([string]$Text,[hashtable]$Parameters=@{}) {
    $builder=New-Object System.Data.SqlClient.SqlConnectionStringBuilder
    $builder.set_DataSource($SqlInstance)
    $builder.set_InitialCatalog('master')
    $builder.set_IntegratedSecurity($true)
    $builder.set_ConnectTimeout(15)
    $connection=New-Object System.Data.SqlClient.SqlConnection $builder.ConnectionString
    try {
        $connection.Open()
        $command=$connection.CreateCommand(); $command.CommandText=$Text; $command.CommandTimeout=60
        foreach ($key in $Parameters.Keys) { [void]$command.Parameters.AddWithValue($key,$Parameters[$key]) }
        $adapter=New-Object System.Data.SqlClient.SqlDataAdapter $command
        $table=New-Object System.Data.DataTable
        [void]$adapter.Fill($table)
        return ,$table
    } finally { $connection.Dispose() }
}

function Assert-BackupHeader($Backup) {
    $key=(Get-PathKey $Backup.File)+'|'+[string]$Backup.Position+'|'+[string]$Backup.Guid
    if ($script:HeaderCache.ContainsKey($key)) { return $script:HeaderCache[$key] }
    $headers=Invoke-ReadOnlySql 'RESTORE HEADERONLY FROM DISK=@File;' @{'@File'=[string]$Backup.File}
    $matching=@($headers.Rows | Where-Object { [int]$_.Position -eq [int]$Backup.Position })
    $good=$false
    if ($matching.Count -eq 1) {
        $h=$matching[0]; $type=1; if ($Backup.Kind -eq 'L') { $type=2 }
        $good=([string]$h.DatabaseName -eq $Database -and [int]$h.BackupType -eq $type -and
            [string]$h.BackupSetGUID -eq [string]$Backup.Guid -and
            [string]$h.FamilyGUID -eq [string]$Backup.Family -and
            [string]$h.RecoveryForkID -eq [string]$Backup.Fork -and
            [string]$h.FirstRecoveryForkID -eq [string]$Backup.FirstFork -and
            [decimal]$h.FirstLSN -eq [decimal]$Backup.FirstLSN -and
            [decimal]$h.LastLSN -eq [decimal]$Backup.LastLSN -and
            [decimal]$h.CheckpointLSN -eq [decimal]$Backup.CheckpointLSN -and
            [datetime]$h.BackupFinishDate -eq [datetime]$Backup.Finish -and
            [bool]$h.HasBackupChecksums -and -not [bool]$h.IsDamaged)
    }
    $script:HeaderCache[$key]=$good
    return $good
}

function Write-CleanupAudit([hashtable]$Fields) {
    $Fields['UtcTime']=[datetime]::UtcNow.ToString('o')
    $json=ConvertTo-Json -InputObject $Fields -Compress -Depth 5
    $script:AuditWriter.WriteLine($json)
    $script:AuditWriter.Flush()
    $script:AuditWriter.BaseStream.Flush($true)
}

if ($LibraryOnly) { return }


if ([Environment]::MachineName -ne $ExpectedMachine) { throw 'Run cleanup on the approved SQL Server computer; no files inspected/deleted.' }
$identity=Invoke-ReadOnlySql @'
SELECT CONVERT(nvarchar(128),SERVERPROPERTY('MachineName')) AS MachineName,
       d.recovery_model_desc,d.state_desc,r.family_guid,r.recovery_fork_guid,
       GETDATE() AS ServerNow
FROM sys.databases AS d
JOIN sys.database_recovery_status AS r ON r.database_id=d.database_id
WHERE d.name=@Database;
'@ @{'@Database'=$Database}
if ($identity.Rows.Count -ne 1 -or [string]$identity.Rows[0].MachineName -ne $ExpectedMachine -or
    [string]$identity.Rows[0].recovery_model_desc -ne 'FULL' -or [string]$identity.Rows[0].state_desc -ne 'ONLINE') {
    throw 'Expected ONLINE/FULL database identity could not be confirmed; cleanup held.'
}
$now=[datetime]$identity.Rows[0].ServerNow
$activeRoots=New-Object 'System.Collections.Generic.List[string]'
foreach ($root in $Roots) {
    [void](Get-PathKey $root)
    if (Test-Path -LiteralPath $root -PathType Container -ErrorAction Stop) {
        $activeRoots.Add((Assert-PlainDirectory $root))
    }
}
if ($activeRoots.Count -eq 0) { throw 'No accessible approved backup root; cleanup held.' }
if ($activeRoots.Count -ne @($activeRoots.ToArray() | Select-Object -Unique).Count) { throw 'Duplicate cleanup roots.' }
# Only the named Audit child of an approved root may be created.
if (-not (Test-Path -LiteralPath $AuditDirectory -PathType Container)) {
    $auditParent=Assert-PlainDirectory (Split-Path -Parent $AuditDirectory)
    if ((Split-Path -Leaf $AuditDirectory) -ne 'Audit' -or
        @($activeRoots | Where-Object { (Get-PathKey $_) -eq (Get-PathKey $auditParent) }).Count -ne 1) {
        throw 'New audit directory must be the Audit child of an accessible approved backup root.'
    }
    [void][IO.Directory]::CreateDirectory([IO.Path]::GetFullPath($AuditDirectory))
}
$auditFolder=Assert-PlainDirectory $AuditDirectory
$auditFile=Join-Path $auditFolder ('Cleanup_'+$Mode+'_'+$now.ToString('yyyyMMdd_HHmmss')+'_'+[guid]::NewGuid().ToString('N')+'.jsonl')
$stream=New-Object IO.FileStream $auditFile,([IO.FileMode]::CreateNew),([IO.FileAccess]::Write),([IO.FileShare]::Read)
$script:AuditWriter=New-Object IO.StreamWriter $stream,(New-Object Text.UTF8Encoding $false)
$script:HeaderCache=@{}
try {
    Write-CleanupAudit @{Event='Start';Mode=$Mode;Apply=[bool]$Apply;Server=$SqlInstance;Database=$Database;
        LogRetentionDays=$LogRetentionDays;DailyRetentionDays=$DailyRetentionDays;MonthlyRetentionMonths=$MonthlyRetentionMonths}
    $history=Invoke-ReadOnlySql @'
SELECT bs.backup_set_id AS SetId,bs.type AS Kind,bs.backup_start_date AS Start,
       bs.backup_finish_date AS Finish,bs.first_lsn AS FirstLSN,bs.last_lsn AS LastLSN,
       bs.checkpoint_lsn AS CheckpointLSN,bs.last_recovery_fork_guid AS Fork,
       bs.first_recovery_fork_guid AS FirstFork,bs.family_guid AS Family,
       bs.backup_set_uuid AS Guid,bs.position AS Position,mf.physical_device_name AS [File],
       bs.has_backup_checksums AS HasChecksum,bs.is_damaged AS IsDamaged,bs.is_copy_only AS IsCopyOnly,
       (SELECT COUNT(*) FROM msdb.dbo.backupmediafamily AS x WHERE x.media_set_id=bs.media_set_id) AS FamilyCount
FROM msdb.dbo.backupset AS bs
JOIN msdb.dbo.backupmediafamily AS mf ON mf.media_set_id=bs.media_set_id
WHERE bs.database_name=@Database AND bs.type IN ('D','L') AND mf.device_type=2;
'@ @{'@Database'=$Database}
    $folders=New-Object 'System.Collections.Generic.List[string]'
    $inventory=New-Object 'System.Collections.Generic.List[object]'
    foreach ($root in $activeRoots) {
        $folder=$root
        if ($Mode -eq 'Log') { $folder=Join-Path $root 'Logs' }
        elseif ($Mode -eq 'Monthly') { $folder=Join-Path $root 'Monthly' }
        if (-not (Test-Path -LiteralPath $folder -PathType Container)) { continue }
        $folder=Assert-PlainDirectory $folder; $folders.Add($folder)
        foreach ($item in Get-ChildItem -LiteralPath $folder -File -Force -ErrorAction Stop) {
            if (($item.Attributes -band [IO.FileAttributes]::ReparsePoint) -ne 0) {
                Write-CleanupAudit @{Event='Keep';Path=$item.FullName;Reason='Reparse-point file'}
                continue
            }
            $inventory.Add([pscustomobject]@{Path=$item.FullName;Name=$item.Name;Length=$item.Length;
                LastWriteTime=$item.LastWriteTime;LastWriteTimeUtc=$item.LastWriteTimeUtc})
        }
    }
    $existsCache=@{}
    $exists={param($path)
        $key=Get-PathKey $path
        if (-not $existsCache.ContainsKey($key)) { $existsCache[$key]=Test-Path -LiteralPath $path -PathType Leaf -ErrorAction Stop }
        return $existsCache[$key]
    }
    $planArguments=@{Backups=@($history.Rows);Files=$inventory.ToArray();Now=$now;
        Family=[string]$identity.Rows[0].family_guid;Fork=[string]$identity.Rows[0].recovery_fork_guid;
        CleanupMode=$Mode;LogDays=$LogRetentionDays;DailyDays=$DailyRetentionDays;MonthlyMonths=$MonthlyRetentionMonths;
        PathExists=$exists;ValidateBackup={param($b) Assert-BackupHeader $b}}
    $plan=Get-RetentionPlan @planArguments
    Write-CleanupAudit @{Event='RecoveryChain';Anchor=$plan.Anchor.File;ThroughLSN=[string]$plan.ThroughLSN;
        LogFiles=$plan.Chain.Count;Cutoff=$plan.Cutoff.ToString('o')}
    $candidates=@($plan.Actions | Where-Object { $_.Action -eq 'DeleteCandidate' })
    foreach ($action in $plan.Actions) {
        Write-CleanupAudit @{Event='Plan';Action=$action.Action;Path=$action.File.Path;Reason=$action.Reason;Length=$action.File.Length}
    }
    # Before actual deletion, checksum-verify required media. HEADERONLY alone is insufficient.
    if ($Apply -and -not $WhatIfPreference -and $candidates.Count -gt 0) {
        $verify=@($plan.Anchor,$plan.LatestFull)+@($plan.Chain)
        $verified=@{}
        foreach ($b in $verify) {
            $key=(Get-PathKey $b.File)+'|'+[string]$b.Position
            if ($verified.ContainsKey($key)) { continue }
            [void](Invoke-ReadOnlySql 'RESTORE VERIFYONLY FROM DISK=@File WITH FILE=@Position,CHECKSUM,STOP_ON_ERROR;' @{'@File'=[string]$b.File;'@Position'=[int]$b.Position})
            Write-CleanupAudit @{Event='ChecksumVerified';Path=$b.File;Position=[int]$b.Position}
            $verified[$key]=$true
        }
    }
    $deleted=0
    foreach ($action in $candidates) {
        if (-not $Apply) { continue }
        if ($PSCmdlet.ShouldProcess($action.File.Path,'Delete expired backup outside the protected recovery chain')) {
            $target=Assert-UnchangedCandidate $action.File $folders.ToArray() $Mode
            Write-CleanupAudit @{Event='DeleteIntent';Path=$target;Length=$action.File.Length}
            Remove-Item -LiteralPath $target -Force -ErrorAction Stop
            Write-CleanupAudit @{Event='Deleted';Path=$target}
            $deleted++
        }
    }
    Write-CleanupAudit @{Event='Complete';Candidates=$candidates.Count;Deleted=$deleted;Apply=[bool]$Apply}
    Write-Output ('Cleanup '+$Mode+': '+$candidates.Count+' candidates, '+$deleted+' deleted. Audit: '+$auditFile)
} catch {
    try { Write-CleanupAudit @{Event='Failure';Message=$_.Exception.Message} } catch { }
    throw
} finally { $script:AuditWriter.Dispose() }
