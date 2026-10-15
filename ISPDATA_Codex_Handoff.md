# Codex Handoff — ISPDATA SQL Server 2014 Transaction Log Investigation and Restore Test

**Prepared:** 2026-10-14\
**System:** IBN-SERVER, SQL Server 2014 (`12.0.5000.0` in SSMS)\
**Production database:** `ISPDATA`\
**Primary goals:** (1) prove that a full backup plus subsequent transaction log backups can be restored on a separate test server, and (2) diagnose why the physical `.ldf` transaction log grew disproportionately relative to the `.mdf` data file, and whether its ongoing size/growth is appropriate.

> **Safety rule:** Production is live clinic data. Start with read-only inspection. Do not stop services, change recovery model, alter backup jobs, delete backup files, shrink files, execute `DBCC SHRINKFILE`, overwrite databases, or run `RESTORE ... WITH REPLACE` without explicit user review and approval. Prefer an isolated test SQL Server. Never commit patient data, database backups, or secrets to GitHub or logs.

## 1. Confirmed findings / chronology

| Fact | Evidence from SSMS or scripts |
|---|---|
| Database recovery model | `FULL` |
| Data (`ROWS`) file allocated size | `202.06 MB` (`ISPDATA`, logical name) |
| Transaction log logical name | `ISPDATA_log` |
| Original log file size | `2,204.01 MB` (~2.15 GiB) |
| Size after a successful manual log backup and shrink attempt | `1,102.01 MB` (~1.08 GiB), roughly 50% smaller |
| Requested shrink target | `100 MB`, **not reached** |
| Most recent log usage reading during investigation | ~`48.88%` of `1,102 MB` (about `539 MB` used as reported by `DBCC SQLPERF(LOGSPACE)`) |
| `log_reuse_wait_desc` at multiple checks | `LOG_BACKUP` (including after successful manual log backups) |
| `DBCC OPENTRAN` | `No active open transactions.` at time tested |
| `DBCC LOGINFO` on SQL Server 2014 | Two VLFs, each `577,765,376` bytes (~`551 MB`). First had `Status=2` (active); second `Status=0` (inactive) at time tested. |
| Log auto-growth | `10%` (requested improvement to fixed increment e.g. `256MB`, **not confirmed applied**) |
| Log `MAXSIZE` | ~`2,097,152 MB` (~2 TiB configuration limit, **not allocated**) |
| SQL Server Agent | Running; existing backups and cleanup jobs found |

**Critical correction to earlier hypothesis:** The log did *not* simply become large because no `.trn` backups were scheduled. Backup history subsequently proved that an existing job **has been creating compressed transaction log backups successfully every 15 minutes**. A large physical `.ldf` is not itself evidence of failure; it can reflect historical large transactions, maintenance, autogrowth, log reuse timing, VLF size/layout, or workload. `LOG_BACKUP` may legitimately recur between successful backups as new records are generated. Determine historical/logical cause before recommending changes.

**Why shrink did not reach 100 MB:** The observed file had two large ~551 MB VLFs, one active; SQL Server 2014's VLF structure limits what shrink can remove. Do not attempt to force the file to 100 MB. Right-size based on measured peak log usage and restore objectives; ~1.1 GB may be entirely reasonable for this system. Repeated shrink/regrow cycles are undesirable.

## 2. Confirmed SQL Server Agent jobs and schedules

### `ISPData Log Backup`
- **Schedule:** enabled, recurring every **15 minutes**, 00:00 to 23:59:59, every day; actual successful 15-minute backups confirmed in `msdb.dbo.backupset` through 2026-10-14 18:45.
- **Primary:** `F:\ISPDataBackup\Logs\`.
- **Fallback:** `E:\SQLBackupFallback\ISPDataBackup\Logs\` if primary directory is absent.
- **File pattern:** `ISPData_Log_YYYYMMDD_HHMMSS.trn`.
- **Options:** `BACKUP LOG ISPDATA ... WITH COMPRESSION, INIT, CHECKSUM, STATS=5; RESTORE VERIFYONLY ...`.
- **Alerts:** if fallback chosen, attempts to email through Database Mail profile `SQLAlerts`; successful delivery not tested.
- **Caveats:** `xp_fileexist` only checks directory presence, not writability or free space. Fallback path isn't checked in advance. `INIT` overwrites an existing same-second filename if reused. `VERIFYONLY` is not a substitute for actual restore.

### `ISPData Log Backup Cleanup`
- **Schedule:** daily **03:30 AM**, successful SQL Agent execution recorded daily through 2026-10-14.
- **PowerShell:** delete *all* `*.trn` with `LastWriteTime < (Get-Date).AddDays(-14)` in both F: and E: log directories using `Remove-Item -Force`.
- **Caveats:** no backup-chain awareness, only age, no explicit reporting, broad filename glob; success of Agent job alone does not prove all intended files were deleted.
- **Observed behavior:** On 2026-10-14, files from September 30 after 03:30 remained; this is consistent with the precise 14-day cutoff at 03:30.

### `ISPData Data Backup` — 3 steps
1. **Backup of IspData** (T-SQL): daily **01:00 AM** actual full backup history confirmed from Oct 5–14, 2026. Writes `F:\ISPDataBackup\ISPData_YYYYMMDD.BAK` or `E:\SQLBackupFallback\ISPDataBackup\` when F: directory absent. `WITH COMPRESSION, INIT, CHECKSUM, STATS=10` and `RESTORE VERIFYONLY`. On calendar month-end (`EOMONTH(GETDATE()) = CAST(GETDATE() AS date)`), at **01:00 AM of the last day** creates additional `Monthly\ISPData_MonthEnd_YYYYMM.BAK`, which is **not a true end-of-day financial close snapshot**. Sends fallback warning through `SQLAlerts`; mail delivery untested.
2. **Delete old daily backups** (PowerShell): deletes files matching `ISPData_*.bak` (PowerShell filename matching is generally case-insensitive) older than **31 days** from primary/fallback root. This broad pattern can include manually named/special backups such as `ISPDATA_PreJournalCleanup...bak`.
3. **Monthly Cleanup** (PowerShell): deletes only `Monthly\ISPData_MonthEnd_*.bak` older than **12 months** in primary/fallback. Legacy monthly names (`ISPData_YYYYMM01.BAK`) are not matched, so historical files from 2021 onward remain.

### Physical monthly archive listing
- `F:\ISPDataBackup\Monthly\` contains legacy monthly `ISPData_20210701.BAK` etc., and `ISPData_MonthEnd_202603.BAK` through `ISPData_MonthEnd_202609.BAK` (Sep 30, 2026 01:00 AM).
- Fallback monthly folder `E:\SQLBackupFallback\ISPDataBackup\Monthly` listed no files in one check.
- A Windows network view of `\\ibn-server\ExternalHdBackup\ISPDataBackup` corresponds to the backup location shown in Explorer; confirm underlying mapping instead of assuming any network path is identical to F: on every machine.

**Current retention:** daily `.BAK` 31 days; `.trn` 14 days; new monthly archives 12 months; legacy monthly archives outside cleanup pattern. This can support short-term point-in-time recovery **only if** a full backup old enough for the target exists and the subsequent `.trn` sequence is complete (including any off-path/manual log backups). Review RPO/RTO and legal retention needs before changing retention.

## 3. Relevant backup history for the restore test

On the **production** SQL Server, `msdb` returned these backup rows around 2026-10-14 01:00 (paths are F: as seen by the production database engine):

| Type | Finished | FirstLSN | LastLSN | File |
|---|---|---|---|---|
| LOG | 00:45:01 | `55000109607100001` | `55000109609500001` | `F:\ISPDataBackup\Logs\ISPData_Log_20261014_004500.trn` |
| LOG | 01:00:01 | `55000109609500001` | `55000109609800001` | `F:\ISPDataBackup\Logs\ISPData_Log_20261014_010000.trn` |
| FULL | 01:00:03 | `55000109610300216` | `55000109619200001` | `F:\ISPDataBackup\ISPData_20261014.BAK` |
| LOG | 01:15:01 | `55000109609800001` | `55000109620000001` | `F:\ISPDataBackup\Logs\ISPData_Log_20261014_011500.trn` |
| LOG | 01:30:00 | `55000109620000001` | `55000109620300001` | `F:\ISPDataBackup\Logs\ISPData_Log_20261014_013000.trn` |
| LOG | 01:45:01 | `55000109620300001` | `55000109620600001` | `F:\ISPDataBackup\Logs\ISPData_Log_20261014_014500.trn` |

**Proposed initial restore chain:** 01:00 full, then 01:15 log, then 01:30 log, then 01:45 log. The 01:15 backup covers the full backup's ending log position; 01:15 → 01:30 → 01:45 LSN ranges are contiguous. Always verify using `RESTORE HEADERONLY` / actual restore: table metadata alone is not a guarantee that files are intact or correct.

Additional **manual** transaction log backups were created around 17:53, 18:01, 18:04, 18:08 on October 14 in a *different* path: `\\ibn-server\Ibn-Server-SqlBackup\...`. **Do not delete these**: they may be part of the later point-in-time log restore sequence across that interval. For the early-morning 01:00→01:45 test, they are not needed.

## 4. Codex task A — restore FULL + TRN on a non-production SQL Server

1. **Inspect and confirm:** test-server name, exact SQL Server version/build (must be same/newer compatible version), available disk, service-account file permissions, backup file paths *as seen by test SQL Server*, and whether `ISPDATA_RestoreTest` already exists. Never overwrite a database or physical file. If name conflicts, stop and ask for a new name.
2. Copy the four selected files to an accessible test folder (illustrative: `D:\SQLRestoreTest\BackupFiles\`), but do not assume D: exists until checked. Verify names, sizes, access, and preferably hashes of copies.
3. Run `RESTORE HEADERONLY` on all four files and `RESTORE FILELISTONLY` on the full backup. Inspect backup type, position, recovery fork, logical data/log names, physical destinations and LSN consistency. Account for `FILE=...` position if required.
4. Draft restore commands with **`WITH MOVE` to unique test-only physical `.mdf` and `.ldf` paths**. Restore full backup **WITH NORECOVERY**. Apply the 01:15 and 01:30 `.trn` backups **WITH NORECOVERY**. Apply the 01:45 `.trn` **WITH RECOVERY**. Never specify `REPLACE`.
5. Request explicit user approval for the first restore execution after showing target instance/database/physical paths, expected disk impact, and source files. If only production SQL Server is accessible, do **not** proceed automatically; ask for approval and prove isolation.
6. After success, run `DBCC CHECKDB(N'ISPDATA_RestoreTest') WITH NO_INFOMSGS, ALL_ERRORMSGS;`, confirm `ONLINE`, and inspect only safe non-sensitive metadata or aggregate validation. Avoid copying/exporting patient records or PHI. Document exact last restored log/point, relevant output, and any errors.
7. Note that successfully restoring this *single chain* does not validate every retained backup nor guarantee any future backup will work.

### Read-only metadata commands (execute only on approved target instance)
```sql
RESTORE HEADERONLY
FROM DISK = N'D:\SQLRestoreTest\BackupFiles\ISPData_20261014.BAK';

RESTORE FILELISTONLY
FROM DISK = N'D:\SQLRestoreTest\BackupFiles\ISPData_20261014.BAK';

RESTORE HEADERONLY
FROM DISK = N'D:\SQLRestoreTest\BackupFiles\ISPData_Log_20261014_011500.trn';
RESTORE HEADERONLY
FROM DISK = N'D:\SQLRestoreTest\BackupFiles\ISPData_Log_20261014_013000.trn';
RESTORE HEADERONLY
FROM DISK = N'D:\SQLRestoreTest\BackupFiles\ISPData_Log_20261014_014500.trn';
```

> The path above is a proposed destination on the **test server**, not a confirmed existing folder. Construct final `RESTORE DATABASE ... WITH MOVE, NORECOVERY` and `RESTORE LOG` commands only after reading actual logical filenames and ensuring unique physical target paths.

## 5. Codex task B — diagnose large `.ldf` versus `.mdf` (read-only first)

**Questions to answer:** (a) Is `1,102 MB` a reasonable steady-state log allocation for ISPDATA? (b) What event led to prior `2,204 MB` log allocation? (c) Is the 48.88% reported usage transient or sustained? (d) Are log backups actually freeing reusable log portions? (e) Is autogrowth and VLF layout appropriate? (f) Is storage pressure real, and does any intervention help more than it risks?

### Diagnostic SQL — compatible with SQL Server 2014

```sql
-- File sizing, actual paths, growth policy (read-only)
USE ISPDATA;
GO
SELECT name, type_desc, physical_name,
       CAST(size / 128.0 AS DECIMAL(18,2)) AS SizeMB,
       growth, is_percent_growth,
       CAST(CASE WHEN is_percent_growth = 1 THEN NULL
                 ELSE growth / 128.0 END AS DECIMAL(18,2)) AS GrowthMB,
       max_size
FROM sys.database_files;
GO

-- Recovery and immediate reuse wait
SELECT name, recovery_model_desc, log_reuse_wait_desc
FROM sys.databases WHERE name = N'ISPDATA';
GO

-- Log size/utilization for ISPDATA (view introduced before SQL Server 2014)
USE ISPDATA;
GO
SELECT total_log_size_in_bytes / 1048576.0 AS TotalLogMB,
       used_log_space_in_bytes / 1048576.0 AS UsedLogMB,
       used_log_space_in_percent AS UsedLogPercent
FROM sys.dm_db_log_space_usage;
GO

-- Fallback/log check across DBs
DBCC SQLPERF(LOGSPACE);
GO

-- Open transaction check: do NOT KILL anything
USE ISPDATA;
GO
DBCC OPENTRAN;
GO

-- SQL Server 2014 VLF layout; Status 2 active, Status 0 inactive
DBCC LOGINFO;
GO

-- Recent backup history, including uncompressed and compressed bytes
SELECT TOP (100)
       bs.backup_start_date, bs.backup_finish_date, bs.type,
       CAST(bs.backup_size / 1048576.0 AS DECIMAL(18,2)) AS BackupSizeMB,
       CAST(bs.compressed_backup_size / 1048576.0 AS DECIMAL(18,2)) AS CompressedMB,
       bs.first_lsn, bs.last_lsn,
       bmf.physical_device_name
FROM msdb.dbo.backupset AS bs
JOIN msdb.dbo.backupmediafamily AS bmf
  ON bmf.media_set_id = bs.media_set_id
WHERE bs.database_name = N'ISPDATA'
  AND bs.type = 'L'
ORDER BY bs.backup_finish_date DESC;
GO

-- Historical LOG autogrowth events, if SQL Server's default trace retains them
DECLARE @TracePath NVARCHAR(260);
SELECT TOP (1) @TracePath = path
FROM sys.traces WHERE is_default = 1;
IF @TracePath IS NOT NULL
BEGIN
    SELECT TOP (100) StartTime, DatabaseName, Filename,
                     EventClass, IntegerData, Duration,
                     ApplicationName, HostName
    FROM sys.fn_trace_gettable(@TracePath, DEFAULT)
    WHERE DatabaseName = N'ISPDATA'
      AND EventClass IN (92, 93, 94, 95)
    ORDER BY StartTime DESC;
END;
GO
```

**Method:** Collect utilization at different times (between 15-minute log backups and around 01:00 full backup, without disruptive polling), compare VLF status, compare log-backup `backup_size` (uncompressed) versus `compressed_backup_size`, examine backup history and default trace for earlier autogrowth and any maintenance/batch operations. Inspect existing agent-job history, SQL Server error logs and documented workloads with least privileges. Lack of historical trace is not proof an event never occurred. `FULL` recovery with frequent successful `.trn` backups can still have a large physical log file.

**Do not execute DDL in initial investigation.** In recommendations, assess a fixed increment such as `FILEGROWTH = 256MB` versus existing 10% and consider whether to retain the 1.1-GB allocation. A proposal to shrink must account for VLF layout, expected peak workload, and downstream log regrowth. Absolutely do not change recovery model to SIMPLE just to reduce file size.

## 6. Desired Codex deliverables

1. **Restore evidence**: actual restored test-instance/database, full and log files used, LSN/check details, commands executed, final recovery point, DBCC CHECKDB result, no production impact.
2. **Root-cause report** for oversized log: confirmed facts versus hypotheses, log usage trends, VLF/growth and historical data, whether `1.1 GB` should be retained.
3. **Hardening proposal, not automatic deployment:** prevent overwrite (`INIT` with date-only names); validate writable primary/fallback destinations; Agent failure alerts; gap-aware retention for daily/monthly/log backups; make cleanup filename filters narrowly scoped; add deletion logging and safe failure behavior; clarify midnight/month-end archive semantics; test recoverability regularly; independently protected backup copy. Include steps to test each change and rollback.
4. **Ask before modifying production jobs, recovery model, files, storage retention or configuration.** No automatic cleanup or DB drop.

## 7. Suggested initial Codex instruction

> Read this entire handoff first. Begin by reporting the confirmed state and a concise, safe plan. Verify the target instance: production is IBN-SERVER / ISPDATA; the restore must be on a separate, approved SQL Server and into ISPDATA_RestoreTest (or an unused alternate name). Start with read-only checks and backup-file inspection; ask me to approve the final RESTORE commands before executing them. Then investigate the historic growth of ISPDATA_log (2,204 MB at first, 1,102 MB after shrink, compared with 202 MB allocated data file), accounting for the confirmed 15-minute log backup job, two ~551-MB VLFs and FULL recovery mode. Do not assert that missing log backups caused the growth: they were demonstrably already scheduled. Produce a written restoration report, root-cause findings and a proposed job hardening plan. Do not change production or delete/overwrite any backup files without approval.
