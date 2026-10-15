# ISPDATA restore test: preflight evidence

Checked 2026-10-14 around 20:21 Arabia Standard Time using Windows authentication.
Historical preflight record. The approved restore subsequently completed successfully; see [the completed investigation](ISPDATA-Restore-and-Log-Investigation.md) for execution and CHECKDB results. Statements below about pending execution describe the preflight stage.

## Verified target

- Machine and default SQL instance: ISPADMIN2, distinct from source IBN-SERVER.
- Engine: SQL Server 2019 Developer Edition, 15.0.2104.1.
- ISPDATA_RestoreTest does not exist.
- SQL engine account NT Service\MSSQLSERVER can read all selected files through the UNC share.
- D: capacity 604.08 GiB; available 192.87 GiB at observation.
- Existing folder D:\Ispadmin2-Ispdata-Test is used by the instance for another test database.
- Proposed unique destinations ISPDATA_RestoreTest.mdf and ISPDATA_RestoreTest_log.ldf in that folder are absent, with their parent present; neither is registered in sys.master_files.
- No existing test database will be overwritten.

## Backup evidence

Source root: \\ibn-server\ExternalHdBackup\ISPDataBackup

| File, relative to source root | Type | Position | FirstLSN | LastLSN |
|---|---|---|---|---|
| ISPData_20261014.BAK | Full | 1 | 55000109610300216 | 55000109619200001 |
| Logs\ISPData_Log_20261014_011500.trn | Log | 1 | 55000109609800001 | 55000109620000001 |
| Logs\ISPData_Log_20261014_013000.trn | Log | 1 | 55000109620000001 | 55000109620300001 |
| Logs\ISPData_Log_20261014_014500.trn | Log | 1 | 55000109620300001 | 55000109620600001 |

All headers identify IBN-SERVER / ISPDATA, source version 12.0.5000, FULL recovery, checksum present and IsDamaged = 0. All share recovery fork 24690442-5675-4E2C-95DD-4AEC5DB151B4 and database family 2B28591F-27E9-4EA6-A222-9D97C73F514C. The first log spans the full backup's ending LSN; following logs are contiguous.

RESTORE FILELISTONLY WITH FILE = 1 shows exactly two present files:

- ISPDATA (data): 211,877,888 bytes, about 202.06 MiB.
- ISPDATA_log (log): 2,311,069,696 bytes, about 2,204.01 MiB.

Total initial allocation: 2,522,947,584 bytes, about 2.35 GiB, plus any recovery growth and CHECKDB temporary workspace. The backup was taken before the later shrink; the restore therefore recreates the earlier allocation, not today's 1,102 MiB file size. Full compressed backup payload is about 57.70 MiB; it does not represent restored disk requirements.

RESTORE VERIFYONLY WITH CHECKSUM reported every backup set valid. The full backup was verified with MOVE to the proposed destinations. Log-only verification emitted warnings about missing original production file directories on this computer. These are source-path warnings, addressed by relocating the full backup's files; actual restore remains the decisive test.

## Pending execution

Review ISPDATA-RestoreTest-Restore.sql: full NORECOVERY with both MOVE clauses; 01:15 and 01:30 logs NORECOVERY; 01:45 log RECOVERY; then ONLINE/file checks, CHECKDB and restore history. No REPLACE, DROP, shrink, recovery-model alteration or backup deletion is included. Sources are read directly from the existing share, with no backup-file modification or local copy. This avoids extra copy/storage operations and depends on share availability throughout the restore.

Recover through the end of the 01:45 log (LastLSN above). Backup finish time 01:45:01 is not proof of an exact transaction commit timestamp. No STOPAT test is proposed in this initial chain test. SQL Server 2019 recovery may upgrade internal database structures; the resulting test database cannot be backed up and restored to SQL Server 2014. Original source backups remain untouched.

Actual restore and DBCC CHECKDB have not run. The log-growth investigation on production has not started in this stage. This preflight does not establish the historical cause of growth or validate other retained backup chains.

## Scope and verification

Only diagnostic/review documents and SQL scripts were added; no application or database-project source changes. Initial existing untracked files AGENTS.md.backup and ISPDATA_Codex_Handoff.md are preserved. No production SQL connection or changes, no deployment, no commit, and no backup modification occurred. Application builds are unnecessary for standalone operator scripts. SQL runtime checks here are the actual read-only commands described above.
