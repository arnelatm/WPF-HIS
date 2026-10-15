#requires -Version 3.0
# Pure in-memory safety tests. No SQL connection, backup, email, directory creation or deletion.
$ErrorActionPreference='Stop'
. (Join-Path $PSScriptRoot 'Invoke-BackupCleanup.ps1') -LibraryOnly
$script:Checks=0
function Assert-True([bool]$Condition,[string]$Message) {
    if (-not $Condition) { throw ('FAIL: '+$Message) }
    $script:Checks++
}
function Assert-Throws([scriptblock]$Action,[string]$Message) {
    $threw=$false
    try { & $Action | Out-Null } catch { $threw=$true }
    Assert-True $threw $Message
}
# Exercise the actual ADO.NET builder setters; no SQL connection is opened.
$builderProbe=New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$builderProbe.set_DataSource('TestServer'); $builderProbe.set_InitialCatalog('master')
$builderProbe.set_IntegratedSecurity($true); $builderProbe.set_ConnectTimeout(15)
Assert-True ($builderProbe.get_DataSource() -eq 'TestServer' -and $builderProbe.get_InitialCatalog() -eq 'master' -and $builderProbe.get_IntegratedSecurity() -and $builderProbe.get_ConnectTimeout() -eq 15) 'Explicit CLR connection-builder setters work without opening SQL'
$testNow=[datetime]'2026-10-14T12:00:00'
$base=[decimal]'55000110380000000'
function New-FixtureBackup([int]$Id,[string]$Kind,[string]$File,[datetime]$Finish,[decimal]$First,[decimal]$Last) {
    return [pscustomobject]@{SetId=$Id;Kind=$Kind;File=$File;Start=$Finish.AddSeconds(-1);Finish=$Finish;
        FirstLSN=$First;LastLSN=$Last;CheckpointLSN=$First;Fork='fork';FirstFork='fork';Family='family';
        Guid=[string]$Id;Position=1;FamilyCount=1;HasChecksum=$true;IsDamaged=$false;IsCopyOnly=$false}
}
function New-FixtureFile([string]$Path,[datetime]$Written) {
    return [pscustomobject]@{Path=$Path;Name=[IO.Path]::GetFileName($Path);Length=100;
        LastWriteTime=$Written;LastWriteTimeUtc=$Written.ToUniversalTime()}
}
function New-Fixture {
    $anchor=New-FixtureBackup 1 D 'F:\ISPDataBackup\ISPData_20260930.BAK' ([datetime]'2026-09-30T01:00:00') ($base+10) ($base+20)
    $latest=New-FixtureBackup 2 D 'F:\ISPDataBackup\ISPData_20261014.BAK' ([datetime]'2026-10-14T01:00:00') ($base+35) ($base+36)
    $old=New-FixtureBackup 3 L 'F:\ISPDataBackup\Logs\ISPData_Log_20260929_010000.trn' ([datetime]'2026-09-29T01:00:00') $base ($base+10)
    $first=New-FixtureBackup 4 L 'F:\ISPDataBackup\Logs\ISPData_Log_20260930_011500.trn' ([datetime]'2026-09-30T01:15:00') ($base+10) ($base+30)
    $last=New-FixtureBackup 5 L 'E:\SQLBackupFallback\ISPDataBackup\Logs\ISPData_Log_20261014_114500.trn' ([datetime]'2026-10-14T11:45:00') ($base+30) ($base+37)
    return [pscustomobject]@{Backups=@($anchor,$latest,$old,$first,$last);Files=@(
        (New-FixtureFile $old.File $old.Finish),(New-FixtureFile $first.File $first.Finish),
        (New-FixtureFile $last.File $last.Finish),(New-FixtureFile 'F:\ISPDataBackup\Logs\Manual.trn' $old.Finish))}
}
function Get-FixturePlan($Fixture,[scriptblock]$Exists={param($path) $true},[scriptblock]$Validate={param($b) $true},[string]$Kind='Log',[int]$LogDays=14) {
    $planParameters=@{Backups=$Fixture.Backups;Files=$Fixture.Files;Now=$testNow;Family='family';Fork='fork';
        CleanupMode=$Kind;LogDays=$LogDays;DailyDays=31;MonthlyMonths=12;PathExists=$Exists;ValidateBackup=$Validate}
    return Get-RetentionPlan @planParameters
}

Assert-True (-not (Test-ManagedBackupName 'ISPData_20261399.BAK' Daily)) 'Invalid calendar date is protected'
Assert-True (-not (Test-ManagedBackupName 'ISPData_Log_20261014_996099.trn' Log)) 'Invalid clock time is protected'
Assert-True (-not (Test-ManagedBackupName 'ISPData_MonthEnd_202609_20261001_010000_0123456789abcdef0123456789abcdef.bak' Monthly)) 'Inconsistent month-end date is protected'
$f=New-Fixture; $p=Get-FixturePlan $f
Assert-True ($p.Chain.Count -eq 2) 'Ordinary logs cover anchor through latest log across both roots'
Assert-True ($p.ThroughLSN -eq ($base+37)) 'LSN comparisons preserve every digit beyond double precision'
Assert-True (@($p.Actions | Where-Object { $_.Action -eq 'DeleteCandidate' }).Count -eq 1) 'Only the expired unneeded ordinary log is a candidate'
Assert-True ($p.Actions[1].Action -eq 'Keep') 'Pre-cutoff log needed to cover the full ending LSN is protected'
Assert-True ($p.Actions[3].Action -eq 'Keep') 'Manual log name is protected'
Assert-True (Test-ManagedBackupName 'ISPData_20261014.BAK' Daily) 'Legacy daily generated name accepted'
Assert-True (Test-ManagedBackupName 'ISPData_20261014_010000_0123456789abcdef0123456789abcdef.bak' Daily) 'New unique daily name accepted'
Assert-True (-not (Test-ManagedBackupName 'ISPDATA_PreJournalCleanup_20261014.bak' Daily)) 'Special/manual daily backup protected'
Assert-True (-not (Test-ManagedBackupName 'ISPData_20210701.BAK' Monthly)) 'Legacy monthly archive left untouched'
Assert-True (Test-ManagedBackupName 'ISPData_MonthEnd_202609.BAK' Monthly) 'Existing month-end filename accepted'
Assert-True (Test-ManagedBackupName 'ISPData_MonthEnd_202609_20260930_010000_0123456789abcdef0123456789abcdef.bak' Monthly) 'Unique month-end filename accepted'
Assert-True (-not (Test-ManagedBackupName 'OtherDatabase.trn' Log)) 'Unrelated log file protected'
Assert-True (-not (Test-ManagedBackupName 'ISPData_Log_20261014_011500.trn.partial' Log)) 'Partial filename protected'

$f=New-Fixture; $f.Backups=@($f.Backups | Where-Object { $_.SetId -ne 4 })
Assert-Throws { Get-FixturePlan $f } 'A missing LSN segment holds cleanup'
$f=New-Fixture
Assert-Throws { Get-FixturePlan $f -Exists {param($path) $path -notlike '*20260930_011500*'} } 'Missing required media holds cleanup'
$f=New-Fixture
Assert-Throws { Get-FixturePlan $f -Validate {param($b) $b.SetId -ne 4} } 'Required header mismatch holds cleanup'
$f=New-Fixture; $f.Backups[3].Fork='other'
Assert-Throws { Get-FixturePlan $f } 'Recovery-fork mismatch cannot bridge a gap'
$f=New-Fixture; $f.Backups[3].FirstFork='other'
Assert-Throws { Get-FixturePlan $f } 'Cross-fork transition is not silently accepted'
$f=New-Fixture; $f.Backups[3].IsCopyOnly=$true
Assert-Throws { Get-FixturePlan $f } 'Copy-only logs are not substituted for the ordinary chain'
$f=New-Fixture; $f.Backups[3].HasChecksum=$false
Assert-Throws { Get-FixturePlan $f } 'Required non-checksummed media holds cleanup'
$f=New-Fixture; $f.Backups[3].FamilyCount=2
Assert-Throws { Get-FixturePlan $f } 'Unsupported striped/mirrored required media holds cleanup'
$f=New-Fixture; $f.Backups[4].Finish=$testNow.AddMinutes(-31)
Assert-Throws { Get-FixturePlan $f } 'Overdue latest log backup holds cleanup'
$f=New-Fixture; $f.Backups[1].Finish=$testNow.AddHours(-27)
Assert-Throws { Get-FixturePlan $f } 'Overdue latest full backup holds cleanup'
$f=New-Fixture; $f.Backups[0].Finish=$testNow.AddDays(-13)
Assert-Throws { Get-FixturePlan $f } 'No full before the retention boundary holds cleanup'
$f=New-Fixture
$p=Get-FixturePlan $f -Validate {param($b) $b.SetId -ne 3}
Assert-True (@($p.Actions | Where-Object { $_.Action -eq 'DeleteCandidate' }).Count -eq 0) 'Mismatched expired candidate is preserved'
$f=New-Fixture; $f.Backups[2].Finish=$testNow.AddMinutes(-10)
$p=Get-FixturePlan $f
Assert-True ($p.Actions[0].Action -eq 'Keep') 'Old filesystem timestamp cannot expire a recent backup'
$f=New-Fixture
$replacement=New-FixtureBackup 40 L $f.Backups[3].File $f.Backups[3].Finish ($base+10) ($base+30)
$f.Backups=@($f.Backups)+@($replacement)
$p=Get-FixturePlan $f -Validate {param($b) $b.SetId -ne 4}
Assert-True ($p.Chain[0].SetId -eq 40) 'Stale INIT-overwrite history does not select the obsolete set'
$f=New-Fixture; $f.Backups[0].Finish=[datetime]'2026-09-12T01:00:00'
$f.Files=@((New-FixtureFile $f.Backups[0].File $f.Backups[0].Finish))
$p=Get-FixturePlan $f -Kind Daily -LogDays 31
Assert-True ($p.Actions[0].Action -eq 'Keep') 'A full just before a 31-day PITR window is preserved beyond nominal daily retention'
$f=New-Fixture; $f.Backups[3].FirstLSN=$base+21
Assert-Throws { Get-FixturePlan $f } 'A one-LSN gap is detected at full/log boundary'

$f=New-Fixture
$alias=New-FixtureBackup 30 L $f.Backups[2].File $f.Backups[3].Finish $f.Backups[3].FirstLSN $f.Backups[3].LastLSN
$alias.Guid=$f.Backups[3].Guid
$f.Backups=@($f.Backups | Where-Object { $_.SetId -ne 3 })+@($alias)
$p=Get-FixturePlan $f -Exists {param($path) $path -notlike '*20260929_010000*'}
Assert-True ($p.Actions[0].Action -eq 'Keep') 'A required backup GUID is protected through alternate paths/copies'
$f=New-Fixture
$manual=New-FixtureBackup 31 D 'F:\ISPDataBackup\ISPData_20260801.BAK' ([datetime]'2026-08-01T01:00:00') ($base-20) ($base-10)
$manual.IsCopyOnly=$true
$f.Backups=@($f.Backups)+@($manual)
$f.Files=@((New-FixtureFile $manual.File $manual.Finish))
$p=Get-FixturePlan $f -Kind Daily
Assert-True ($p.Actions[0].Action -eq 'Keep') 'Expired copy-only full backups are protected even with generated-looking names'
Write-Output ('PASS: '+$script:Checks+' in-memory backup-cleanup safety checks; no SQL or filesystem mutation.')
