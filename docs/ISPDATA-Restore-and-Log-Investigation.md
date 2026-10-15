# ISPDATA restoration and transaction log investigation

2026-10-14. Actual restoration completed with explicit user approval. Production inspection was read-only.

## Restoration result

SUCCESS: ISPADMIN2 / ISPDATA_RestoreTest is ONLINE. Windows-authenticated SQLCMD executed the reviewed ISPDATA-RestoreTest-Restore.sql. Exit code 0. The full restore and each of the three log restores reported success. DBCC CHECKDB WITH NO_INFOMSGS, ALL_ERRORMSGS completed without diagnostic messages or errors.

Target: default instance ISPADMIN2, SQL Server 2019 Developer Edition 15.0.2104.1. Original source: IBN-SERVER / ISPDATA, SQL Server 2014 12.0.5000.0.

Files created only on the approved test server:

- D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest.mdf
- D:\Ispadmin2-Ispdata-Test\ISPDATA_RestoreTest_log.ldf

Read directly from \\ibn-server\ExternalHdBackup\ISPDataBackup; no backup files were overwritten or copied:

| Backup | Mode used | FirstLSN | LastLSN |
|---|---|---|---|
| ISPData_20261014.BAK | FILE=1, CHECKSUM, MOVE both files, NORECOVERY | 55000109610300216 | 55000109619200001 |
| Logs\ISPData_Log_20261014_011500.trn | FILE=1, CHECKSUM, NORECOVERY | 55000109609800001 | 55000109620000001 |
| Logs\ISPData_Log_20261014_013000.trn | FILE=1, CHECKSUM, NORECOVERY | 55000109620000001 | 55000109620300001 |
| Logs\ISPData_Log_20261014_014500.trn | FILE=1, CHECKSUM, RECOVERY | 55000109620300001 | 55000109620600001 |

Headers identified one database family and recovery fork 24690442-5675-4E2C-95DD-4AEC5DB151B4. Preflight checksum verification passed all four sets. Standalone log VERIFYONLY warned about original production paths absent on the test machine; the actual full restore relocated both logical files and the subsequent log restores succeeded.

Restore history (ISPADMIN2 local clock): full at 20:25:04.940, 01:15 log at 20:25:15.850, 01:30 log at 20:25:16.157, last log at 20:25:16.297. Full recovery=0; first two logs recovery=0; last log recovery=1. All replace=0. Restored backup-set IDs 10300 through 10303. The full restore took 9.977 seconds; this is a small-chain test, not a measured disaster-recovery RTO.

Recovered through the end of the selected 01:45 log, LastLSN 55000109620600001. Backup finish time 01:45:01 is not an exact commit-time guarantee; no STOPAT test was performed. Compatibility level remains 120. SQL Server 2019 upgraded internal structures from database version 782 to 904. Data allocation became 203.06 MiB after recovery/upgrade versus 202.06 MiB in the backup; log allocation is 2,204.01 MiB. This test database cannot subsequently be restored to SQL Server 2014 from a new SQL Server 2019 backup. The original 2014 backup files are unchanged.

This proves this specific full-plus-three-log chain is recoverable on this test instance. It does not validate every archive, later manual log chain, point-in-time selection, application behavior, or recovery onto an identical SQL Server 2014 engine. The test database remains present; no cleanup/drop is authorized or performed.

## Main finding: the 2.2 GB log was a legacy allocation, not recent growth

The premise needs a historical correction. ISPDATA did not recently grow from a 202 MB data file into a new 2.2 GB log while the current backup job ran. It already had a much larger log years earlier, and the observed 2.2 GB was the remainder of an earlier reduction.

Retained msdb full-backup file metadata:

| Recovery | Log allocation | First recorded | Last recorded | Full backup rows |
|---|---|---|---|---|
| FULL | 8,816.250 MiB | 2021-04-11 12:16:45 | 2026-03-07 17:13:20 | 5,804 |
| FULL | 2,204.008 MiB | 2026-03-08 01:00:01 | 2026-10-14 01:00:01 | 282 |

The exact sizes are backed by independent FILELISTONLY reads of retained monthly media: July 2021, May 2023, July 2023, December 2025 and February 2026 each record an 8,816.250 MiB log; March 2026 month-end records 2,204.008 MiB. The logical-file GUID is consistent across the inspected archives. The data file in July 2021 was only about 80.063 MiB. This disparity therefore substantially predates the current workload.

The reduction occurred between March 7, 2026 at 17:13:20 and March 8 at 01:00:01. The mechanism and operator for that historical reduction are not captured in the available evidence; it is consistent with a shrink, but the specific command is not proven. Today's 1,102.01 MiB production allocation reflects the later shrink already recorded in the handoff, not an operation performed in this investigation.

Confirmed cause of the presently oversized physical allocation: historical log capacity was retained after log backup/reuse, with very large VLFs limiting granular removal/reuse. Log backups make eligible portions reusable; they do not automatically reduce physical file size. The log has not regrown to 2.2 GB during the recent observed period.

The event that originally allocated or grew the log to 8.8 GB occurred on or before April 11, 2021, before the earliest retained backup-history observation. There is no surviving growth trace from that time. Preallocation, a restored oversized log, historical unbacked FULL recovery, or a past large/long transaction cannot be distinguished conclusively from current evidence. Do not present any of these as a proven historical trigger.

## Backup history changes the historical hypothesis

- Existing current log job ISPData Log Backup was created March 7, 2026 at 17:22:01.
- Earliest retained log backup is March 5, 2026 at 09:23:02, an ordinary, uncompressed 384.711 MiB manual backup in the SQL Server default Backup directory.
- Production restore history records a full restore on March 5 at 09:25:21 and application of that log at 09:25:47. Restores also occurred April 2021 and June 2023. Historical file paths changed between C: and E:, consistent with moves/restores; the history does not prove why the first allocation was large.
- Retained FULL backups extend back to April 2021, but no retained log-backup rows precede March 2026. This suggests earlier log-backup coverage may have been absent and is a historical risk to investigate. Selective history cleanup or unrecorded external history prevents proving that no older log backups ever existed.
- Once configured, ordinary log backups run every 15 minutes. April through September have exactly the expected 96 backups per day in aggregate. Recent complete days in the daily summary likewise have 96.
- The continuity query across retained ordinary logs found no positive LSN gaps or recovery-fork discontinuities. Time gaps were in March: about 56 hours after the first manual backup, then several 30-45 minute intervals around March 11. Continuity metadata cannot prove old files remain on disk or are intact.
- Recent largest log backup: October 6 at 21:30, 140.453 MiB uncompressed, 24.575 MiB compressed; another at 11:45 was 43.641 MiB. These coincide with data-file growth and SQLCMD activity from ISPADMIN2. They identify batch activity, but do not establish the exact SQL transaction or explain a log size that already existed for months.
- October 6 total log backup payload was 202.375 MiB. Typical recent complete days were about 7.5-25 MiB. Backup payload includes overhead and is not a direct measure of maximum concurrent retained log space.

## Current state and VLF explanation

Read-only production target was independently verified as IBN-SERVER / ISPDATA, version 12.0.5000.0.

- FULL recovery; auto-shrink off; CDC/publication/subscription flags off; observed reuse wait LOG_BACKUP.
- Data file 202.06 MiB; log 1,102.01 MiB; log MAXSIZE setting approximately 2 TiB, not allocated disk usage.
- Log autogrowth ALREADY fixed at 256 MiB (growth=32768 pages, is_percent_growth=0). The handoff's 10% policy is no longer current. No growth-setting correction is needed now.
- Production C: has 22.72 GiB available of 166.61 GiB at observation. This is not an immediate log-space emergency; overall server storage policy still merits monitoring.
- Production log: two 551 MiB VLFs. First active, sequence 55; second inactive, sequence 0. Restored morning backup: four 551 MiB VLFs, only the first active. These confirm coarse existing layout; 256 MiB future growth does not resize existing VLFs.
- OPENTRAN emitted no active-transaction findings; database transaction DMV returned no rows. This excludes active database transactions at sampled instants, not historical long transactions.
- Default trace spans September 20 through October 14. All 89 ISPDATA file-size events were EventClass 92 (data-file autogrowth). No retained EventClass 93 log autogrowth or 94/95 auto-shrink events were found. A manual shrink need not appear in these automatic-event classes.
- Retained error logs matched database mentions from March onward. Broad keyword matches produced six apparent 9002 hits, all ordinary successful log-backup messages containing those digits in metadata, not transaction-log-full errors. No matched actual log-full/autogrowth error was established by these filters. This is not exhaustive proof that no historical error occurred.
- No maintenance plans were listed. Job inventory/command-marker checks found no explicit index rebuild or shrink commands for ISPDATA; SSIS/indirect/external/manual activity is not ruled out. An unrelated attendance-refresh job has failed entries; it is outside this change's scope.

Utilization readings before the next scheduled backup:

| Production local clock | Used log MiB | MiB since last log backup |
|---|---|---|
| 20:24:32 | 539.270 | not selected in first sample |
| 20:26:26 | 539.2695 | 0.0596 |
| 20:27:05 | 539.2695 | 0.0596 |
| 20:27:49 | 539.2695 | 0.0596 |

Last recorded backup for these readings was 20:15:01 with 0.0762 MiB uncompressed payload. Near-539 MiB occupied space is not evidence of 539 MiB of newly unbacked transactions. A successful backup cannot make a partially active VLF fully reusable, and coarse VLF boundaries can keep occupancy/wait indications persistent. Existing snapshots support this explanation; the original pre-2021 transaction/growth history remains unavailable.

At 20:30:40 production local time, the scheduled 20:30:01 backup had succeeded (0.0762 MiB uncompressed). Its LSN interval was 55000110384600001 to 55000110384900001, contiguous with the 20:15 backup ending at 55000110384600001. Used space was 539.2710 MiB, space since last backup 0.0596 MiB, reuse wait still LOG_BACKUP, and VLF statuses/sequence unchanged. No complete VLF became newly reusable in this sampled cycle. The small since-backup reading was present both before and after; a reset to zero was not directly observed. Successful backup and advancing LSN coverage are confirmed, while long-term wrap/reuse behavior is not yet sampled. Do not generate dummy production transactions or run extra backups merely to force a wrap.

Longer sampling around overnight backups, heavy batches, month-end and rollback scenarios has not been performed; no claim of measured long-term peak utilization is made.

## Recommended corrections: proposals only

| Area | Recommended action | Test before rollout | Rollback/preservation |
|---|---|---|---|
| Log sizing | Keep current 1,102 MiB allocation for now. Retain fixed 256 MiB growth and FULL recovery. Collect peak usage, reuse waits and backup latency over representative operating cycles before any one-time resizing/VLF change. | Monitor a restored test copy under representative authorized workload and observe production metadata across backups, batch work and month-end. Do not simulate destructive workloads on production. | No setting change now. Any later layout change needs separate approved commands, capacity check and a tested recovery plan; physical layout changes are not simply reversible. |
| Backup overwrite | Replace date-only/same-second collision risk with unique per-execution names and collision checks. Historical metadata shows many full backups overwriting the same date-only filename. | Execute two test backups rapidly into an isolated scratch location; both files must remain distinct and restore successfully. | Preserve reviewed original job definitions and all required files; revert definitions without deleting new backups. |
| Destinations | Validate both primary and fallback accessibility, available capacity and successful engine writes; fail clearly if neither is usable. Directory presence alone is insufficient. | Exercise absent, denied and full destinations only with isolated test paths. | Revert job definition; retain files on both paths and document which chain segments live where. |
| Alerts | Failure email notifications ARE configured for all three ISPData jobs to an enabled DBA_Alert operator with an address. Verify delivery and add missed-backup-age monitoring independent of job success. | Approved test alert/failure in a separate test job; confirm receipt and late-backup alert behavior. | Revert added monitor/configuration; keep existing failure notification. No test mail sent in this task. |
| Cleanup selection | Narrow patterns to generated filenames; isolate manual/pre-cleanup backups from daily cleanup; record candidates, successful deletions and failures. | Dry-run mixed filenames and forced failures against a scratch directory; verify special/manual files remain protected. | Keep deletion disabled until reviewed; preserve independent copies because deleted files are not recoverable through a job-definition rollback. |
| Retention and chains | Age alone is insufficient. Before deletion, preserve the required full baseline and complete logs across primary/fallback/manual locations for the promised PITR window. The current 31-day full / 14-day log policy does not provide 31-day PITR. | Inventory and restore earliest promised recovery boundary plus a chain spanning a manual/fallback log backup. | Suspend proposed cleanup and restore prior settings; never rely on rollback to recover deleted media. |
| Monthly archive | Define whether the archive represents start of the last day or actual financial close. Current 01:00 last-day backup is not an end-of-day close snapshot. Assess legacy files separately. | Verify approved close-time semantics and restore a sample archive. | Preserve current archives; revert scheduling/naming definitions only. |
| Recoverability/protection | Schedule periodic actual chain restores and an independent protected/offline backup copy, matched to agreed RPO/RTO. Monthly full archives without intervening logs provide snapshot recovery, not PITR across the intervening period. | Time a full-window restore and CHECKDB; test independent-copy access and integrity. | Retain existing backups and jobs while new copy/restore process is validated; remove only newly configured scheduling after review if necessary. |

## Limits, changes and safeguards

Production: only read-only diagnostic SQL, backup metadata and error-log inspection. No production data/schema edits, backup execution, shrink, checkpoint, recovery-model changes, job edits, retention changes, service stops or backup deletion. Neither production nor test backup jobs were altered. No deployment or application launch occurred. No patient records were selected/exported, and no credentials or connection strings were logged.

Approved test writes: creation/restoration and recovery of ISPDATA_RestoreTest, normal msdb restore-history entries and CHECKDB's normal metadata updates. Nothing else was restored or overwritten. The test database remains isolated from application validation.

Repository additions: diagnostic SQL, reviewed restore SQL, preflight evidence, and this report. No application/database-project source modifications, so no MSBuild run was needed. Runtime validation consisted of actual restores, checksum checks, CHECKDB, online/file/history checks and production read-only diagnostics. Application, reporting, financial-balance and bilingual/RTL smoke tests were not run; they are separate from this backup-chain test.

One exploratory metadata batch initially failed compilation because two assumed maintenance-plan columns were not present. It made no persistent changes; the corrected read-only batch succeeded. Command-runner initialization was intermittent, but direct SQLCMD commands succeeded. File changes are reviewed directly, existing user files are preserved, and git diff --check/status are checked before completion. No commit or push.

References for interpretation:

- [SQL Server transaction log architecture and VLF management](https://learn.microsoft.com/en-us/sql/relational-databases/logs/sql-server-transaction-log-architecture-and-management-guide?view=sql-server-ver17)
- [Transaction log truncation and reuse waits](https://learn.microsoft.com/en-us/sql/relational-databases/logs/the-transaction-log-sql-server?view=sql-server-ver17)
- [SQL Server 2014-compatible log-space DMV and bytes since last backup](https://learn.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/sys-dm-db-log-space-usage-transact-sql?view=sql-server-ver17)
