# ISPDATA production installation and audit results

Installed with explicit user approval on 2026-10-15, approximately 07:33-07:36 server local time (Asia/Riyadh). Verified target: IBN-SERVER default instance, SQL Server 2014 12.0.5000.0, database ISPDATA, ONLINE/FULL.

## Changes deployed

Five existing SQL Agent command bodies were updated: ISPData Data Backup steps 1/2/3, ISPData Log Backup step 1, and ISPData Log Backup Cleanup step 1. The three cleanup commands have Apply=false (audit-only). Original schedules, owners, step routing/retries and notification settings were preserved; before/after settings snapshots were identical. Exact final command comparison passed.

Current retention settings remain daily 31 days, logs/PITR 14 days, monthly 12 months. Nothing was deployed to application/schema projects. No database schema, application records, recovery model, log size/growth setting or existing backup media was changed. New full/log backup media and audit files were created. No backup files were deleted.

## Actual SQL Agent checks

| Check | Result |
| --- | --- |
| Updated log-backup step, 07:33:33 | Passed: unique primary F: file, checksum VERIFYONLY valid |
| Updated full-backup step, 07:35:08 | Passed: unique primary F: file, checksum VERIFYONLY valid |
| Log cleanup, 07:34:29 | Connected, read metadata/headers, inspected folders, wrote audit; held at missing-log boundary |
| Daily cleanup after full backup | Same safe hold; full job reports failure at cleanup step 2 although backup step 1 passed |
| Monthly cleanup, separately started at step 3 | Same safe hold; tested separately because daily failure prevents normal routing to monthly |

Agent service/execution identity: NT Service\SQLSERVERAGENT; no proxy configured on the reviewed steps. SQL Server engine identity: NT Service\MSSQLSERVER. The successful cleanup operations establish the permissions exercised so far: Windows SQL connection, current database/recovery identity, msdb backup metadata, engine HEADERONLY on checked full media, backup directory enumeration, and audit creation/writing. They do not establish delete permission, every later log's accessibility, or deletion-path VERIFYONLY. No ACL/security/login permissions were changed.

The first cleanup attempt failed before retention assessment with Keyword not supported: 'DataSource'. Reproduced locally: PowerShell adapts SqlConnectionStringBuilder property assignment as an unsupported key. Fixed initialization using explicit .NET property setters in cleanup and the local proposal generator. Applied a guarded patch to all three cleanup commands. All three PowerShell files passed parsing; 35 local safety checks passed, including the new regression case. Only a child test process used RemoteSigned; no persistent execution policy was changed.

## Retention result: hold, not deletion approval

For the current 14-day boundary (October 1 morning), the anchor is F:\ISPDataBackup\ISPData_20261001.BAK, finished 2026-10-01 01:00:03, backup set 55748, ending LSN 55000048410700001. Its first covering ordinary log is backup set 55749, ISPData_Log_20261001_011500.trn, finished 01:15:01. Engine xp_fileexist confirmed that file absent in BOTH configured primary and fallback Logs directories, with parent folders present. An independent copy elsewhere has not been ruled out.

All three audits recorded failure: Log coverage is missing at LSN 55000048410700001; cleanup held. All Start records show Apply=false. Planning stopped before producing a complete retention/deletion candidate list. No full 14-day recovery guarantee is established. Zero backup deletions occurred. A fresh backup cannot recreate the missing historical segment.

Audit directory on IBN-SERVER: E:\SQLBackupFallback\ISPDataBackup\Audit. Inspected files:

- Cleanup_Log_20261015_073434_94676c2293284dc1b0b4c6088e50ff3d.jsonl
- Cleanup_Daily_20261015_073519_871cc09b119f4633a721e920b80aca11.jsonl
- Cleanup_Monthly_20261015_073600_163ce95a8ea24d0ea7419269a7837615.jsonl

## Follow-up

Keep cleanup audit-only and preserve the available media. Locate an independent copy of the missing log if one exists; otherwise allow a complete retained full-plus-log window to accumulate and re-audit before any deletion decision. Do not shorten the promised retention period merely to obtain a successful job result. A passing audit is still subject to reviewing actual candidates, delete permissions and checksum verification before separate deletion approval.

Held cleanup is deliberately surfaced as job failure, including the daily backup job after its successful full step. Existing failure notifications may be sent; mail receipt remains unverified. Do not interpret this cleanup failure as a failed full backup or silently suppress it. Once the retained window is complete, rerun all modes and inspect candidate reasons. Until then monitor free space: at validation F: had 1,336,159 MiB and E: 1,637,216 MiB free; audit-only is temporary. No independent monitor schedule was installed. Production fallback writes, month-end creation, deletion, mail receipt and a new production-media restore trial were not exercised in this deployment. Prior isolated restore testing is recorded in Trial-Validation.md.

Private evidence/rollback folder: _temp/ispdata-backup-hardening/installation-20261015. Use Verify-Corrected.sql and Rollback-Corrected-to-Original.sql for the currently installed state; the original rollback predates the connection-builder fix. Corrected rollback passed SQL Server 2014 PARSEONLY. It restores original command bodies, including their old age-only deletion behavior, so do not run it casually. It cannot recover deleted media. No rollback was executed. Installation-History.txt and before/after settings snapshots are retained locally; keep private artifacts out of version control.

No HIS/Accounts/DACPAC build was needed for standalone operator scripts. No commit/push occurred.
