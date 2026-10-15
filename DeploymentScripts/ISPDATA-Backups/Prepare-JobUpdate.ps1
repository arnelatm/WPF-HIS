#requires -Version 3.0
# Reads job definitions and writes review files locally. Does NOT update jobs or run backups/cleanup.
[CmdletBinding()]
param([string]$SqlInstance='IBN-SERVER',[string]$ExpectedMachine='IBN-SERVER',
      [ValidateRange(1,3650)][int]$LogRetentionDays=14,[switch]$EnableCleanupDeletion)
$ErrorActionPreference='Stop'
Set-StrictMode -Version 2.0
$repoRoot=Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
$outputRoot=[IO.Path]::GetFullPath((Join-Path $repoRoot '_temp\ispdata-backup-hardening'))
$allowed=[IO.Path]::GetFullPath((Join-Path $repoRoot '_temp')).TrimEnd('\')+'\'
if (-not $outputRoot.StartsWith($allowed,[StringComparison]::OrdinalIgnoreCase)) { throw 'Output escaped the verification folder.' }
[void][IO.Directory]::CreateDirectory($outputRoot)
$runFolder=Join-Path $outputRoot ((Get-Date).ToString('yyyyMMdd_HHmmss')+'_'+[guid]::NewGuid().ToString('N'))
[void][IO.Directory]::CreateDirectory($runFolder)
$builder=New-Object System.Data.SqlClient.SqlConnectionStringBuilder
$builder.set_DataSource($SqlInstance); $builder.set_InitialCatalog('msdb'); $builder.set_IntegratedSecurity($true); $builder.set_ConnectTimeout(15)
$connection=New-Object System.Data.SqlClient.SqlConnection $builder.ConnectionString
try {
    $connection.Open()
    $command=$connection.CreateCommand()
    $command.CommandText="SELECT CONVERT(nvarchar(128),SERVERPROPERTY('MachineName'));"
    if ([string]$command.ExecuteScalar() -ne $ExpectedMachine) { throw 'Unexpected machine; no review bundle generated.' }
    $command.CommandText=@'
SELECT j.job_id,j.name AS JobName,s.step_id,s.step_name,s.subsystem,s.database_name,
       s.on_success_action,s.on_success_step_id,s.on_fail_action,s.on_fail_step_id,
       s.retry_attempts,s.retry_interval,s.command
FROM dbo.sysjobs AS j JOIN dbo.sysjobsteps AS s ON s.job_id=j.job_id
WHERE j.name IN (N'ISPData Data Backup',N'ISPData Log Backup',N'ISPData Log Backup Cleanup')
ORDER BY j.name,s.step_id;
'@
    $table=New-Object System.Data.DataTable
    $adapter=New-Object System.Data.SqlClient.SqlDataAdapter $command
    [void]$adapter.Fill($table)
} finally { $connection.Dispose() }
if ($table.Rows.Count -ne 5) { throw 'Expected exactly the five reviewed steps; inspect changed job structure.' }
$backupTemplate=[IO.File]::ReadAllText((Join-Path $PSScriptRoot 'Backup-ISPDATA.sql'))
$cleanupTemplate=[IO.File]::ReadAllText((Join-Path $PSScriptRoot 'Invoke-BackupCleanup.ps1'))
function Get-BackupCommand([string]$Kind) {
    $result=$backupTemplate.Replace("DECLARE @BackupType char(1) = 'D';","DECLARE @BackupType char(1) = '"+$Kind+"';")
    $result=$result.Replace("DECLARE @ExpectedMachine sysname = N'IBN-SERVER';","DECLARE @ExpectedMachine sysname = N'"+$ExpectedMachine.Replace("'","''")+"';")
    return $result
}
function Get-CleanupCommand([string]$Kind) {
    $result=$cleanupTemplate.Replace("[string]"+'$Mode'+"='Log'","[string]"+'$Mode'+"='"+$Kind+"'")
    $result=$result.Replace('[int]$LogRetentionDays=14','[int]$LogRetentionDays='+$LogRetentionDays)
    if ($EnableCleanupDeletion) { $result=$result.Replace('[switch]$Apply,','[switch]$Apply=$true,') }
    return $result
}
$changes=New-Object 'System.Collections.Generic.List[object]'
foreach ($row in $table.Rows) {
    if ([string]$row.command -match '(?i)(password|pwd|connectionstring)\s*=') { throw 'Sensitive step content detected; export blocked.' }
    $newCommand=$null
    if ($row.JobName -eq 'ISPData Data Backup' -and [int]$row.step_id -eq 1) { $newCommand=Get-BackupCommand D }
    elseif ($row.JobName -eq 'ISPData Data Backup' -and [int]$row.step_id -eq 2) { $newCommand=Get-CleanupCommand Daily }
    elseif ($row.JobName -eq 'ISPData Data Backup' -and [int]$row.step_id -eq 3) { $newCommand=Get-CleanupCommand Monthly }
    elseif ($row.JobName -eq 'ISPData Log Backup' -and [int]$row.step_id -eq 1) { $newCommand=Get-BackupCommand L }
    elseif ($row.JobName -eq 'ISPData Log Backup Cleanup' -and [int]$row.step_id -eq 1) { $newCommand=Get-CleanupCommand Log }
    else { throw 'Unexpected job step mapping.' }
    if ($newCommand -eq [string]$row.command) { throw 'No replacement was generated.' }
    $expectedSubsystem='PowerShell'; if ($row.JobName -eq 'ISPData Log Backup' -or ($row.JobName -eq 'ISPData Data Backup' -and [int]$row.step_id -eq 1)) { $expectedSubsystem='TSQL' }
    if ($row.subsystem -ne $expectedSubsystem) { throw 'A reviewed subsystem changed.' }
    $changes.Add([pscustomobject]@{JobId=[string]$row.job_id;JobName=[string]$row.JobName;StepId=[int]$row.step_id;
        StepName=[string]$row.step_name;Subsystem=[string]$row.subsystem;DatabaseName=[string]$row.database_name;
        OldCommand=[string]$row.command;NewCommand=$newCommand;
        OnSuccessAction=[int]$row.on_success_action;OnSuccessStep=[int]$row.on_success_step_id;
        OnFailAction=[int]$row.on_fail_action;OnFailStep=[int]$row.on_fail_step_id;
        RetryAttempts=[int]$row.retry_attempts;RetryInterval=[int]$row.retry_interval})
}
function ConvertTo-SqlLiteral([string]$Text) { return "N'"+$Text.Replace("'","''")+"'" }
function New-UpdateSql([bool]$Rollback) {
    $sql=New-Object Text.StringBuilder
    [void]$sql.AppendLine('-- REVIEW ONLY: explicit production approval required before execution.')
    [void]$sql.AppendLine('-- Changes only five step commands. Schedules, owners, notifications, routing and retries remain unchanged.')
    [void]$sql.AppendLine('USE [msdb];')
    [void]$sql.AppendLine('SET NOCOUNT ON; SET XACT_ABORT ON;')
    [void]$sql.AppendLine('IF CONVERT(nvarchar(128),SERVERPROPERTY(''MachineName'')) <> '+(ConvertTo-SqlLiteral $ExpectedMachine)+' THROW 51100,''Unexpected machine.'',1;')
    [void]$sql.AppendLine('DECLARE @rc int; BEGIN TRY BEGIN TRANSACTION;')
    [void]$sql.AppendLine('IF EXISTS (SELECT 1 FROM dbo.sysjobactivity AS a JOIN dbo.sysjobs AS j ON j.job_id=a.job_id WHERE a.session_id=(SELECT MAX(session_id) FROM dbo.syssessions) AND a.start_execution_date IS NOT NULL AND a.stop_execution_date IS NULL AND j.name IN (N''ISPData Data Backup'',N''ISPData Log Backup'',N''ISPData Log Backup Cleanup'')) THROW 51101,''A target job is running; choose a quiet interval.'',1;')
    foreach ($change in $changes) {
        $expected=$change.OldCommand; if ($Rollback) { $expected=$change.NewCommand }
        $guard='IF NOT EXISTS (SELECT 1 FROM dbo.sysjobsteps AS s JOIN dbo.sysjobs AS j ON j.job_id=s.job_id WHERE j.job_id='+(ConvertTo-SqlLiteral $change.JobId)+' AND j.name='+(ConvertTo-SqlLiteral $change.JobName)+' AND s.step_id='+$change.StepId+' AND s.step_name='+(ConvertTo-SqlLiteral $change.StepName)+' AND s.subsystem='+(ConvertTo-SqlLiteral $change.Subsystem)+' AND s.database_name='+(ConvertTo-SqlLiteral $change.DatabaseName)+' AND s.on_success_action='+$change.OnSuccessAction+' AND s.on_success_step_id='+$change.OnSuccessStep+' AND s.on_fail_action='+$change.OnFailAction+' AND s.on_fail_step_id='+$change.OnFailStep+' AND s.retry_attempts='+$change.RetryAttempts+' AND s.retry_interval='+$change.RetryInterval+' AND DATALENGTH(s.command)=DATALENGTH('+(ConvertTo-SqlLiteral $expected)+') AND s.command COLLATE Latin1_General_100_BIN2='+(ConvertTo-SqlLiteral $expected)+' COLLATE Latin1_General_100_BIN2) THROW 51102,''A target step differs from the reviewed baseline; no changes applied.'',1;'
        [void]$sql.AppendLine($guard)
    }
    foreach ($change in $changes) {
        $replacement=$change.NewCommand; if ($Rollback) { $replacement=$change.OldCommand }
        [void]$sql.AppendLine('EXEC @rc=dbo.sp_update_jobstep @job_id='+(ConvertTo-SqlLiteral $change.JobId)+',@step_id='+$change.StepId+',@command='+(ConvertTo-SqlLiteral $replacement)+';')
        [void]$sql.AppendLine('IF @rc<>0 THROW 51103,''Job-step update failed.'',1;')
    }
    [void]$sql.AppendLine('COMMIT TRANSACTION; PRINT ''Five reviewed job-step commands updated.''; END TRY BEGIN CATCH IF @@TRANCOUNT>0 ROLLBACK TRANSACTION; THROW; END CATCH;')
    return $sql.ToString()
}
$utf8=New-Object Text.UTF8Encoding $false
[IO.File]::WriteAllText((Join-Path $runFolder 'Install-JobCommands.sql'),(New-UpdateSql $false),$utf8)
[IO.File]::WriteAllText((Join-Path $runFolder 'Rollback-JobCommands.sql'),(New-UpdateSql $true),$utf8)
[IO.File]::WriteAllText((Join-Path $runFolder 'Baseline-and-Proposal.json'),(ConvertTo-Json -InputObject $changes.ToArray() -Depth 6),$utf8)
Write-Output ('Review bundle generated: '+$runFolder)
Write-Output ('No jobs modified. Cleanup deletion enabled in proposal: '+[bool]$EnableCleanupDeletion)
