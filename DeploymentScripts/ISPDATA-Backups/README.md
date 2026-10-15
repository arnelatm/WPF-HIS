# ISPDATA backup hardening

Prepared 2026-10-14. **Installed with user approval on IBN-SERVER, 2026-10-15; cleanup remains audit-only.** See [Deployment-Validation.md](Deployment-Validation.md) for actual Agent results and the unresolved recovery-boundary gap.
Production target is IBN-SERVER / ISPDATA (SQL Server 2014). The original job schedules, owners, routing, retries and failure notifications are preserved. The prior approved restore on ISPADMIN2 remains available for testing.

## Files and behavior

- **Backup-ISPDATA.sql:** one SQL Server 2014-compatible step template, configured as D for the full job and L for the log job. New timestamp-plus-GUID filenames; existing-file guard; NOINIT/NOFORMAT instead of INIT; COMPRESSION, CHECKSUM and STOP_ON_ERROR; conservative disk-capacity reserve (1,024 MiB plus allocated source-file size); primary then fallback directory checks; actual backup write tests writability. No directories or partial backup files are automatically deleted. Monthly creation keeps the current 01:00 last-day semantics and uses unique names.
- **Invoke-BackupCleanup.ps1:** daily, monthly and log cleanup from a shared script. Strict generated-name patterns include valid calendar/time checks. It protects special/manual names, copy-only full backups, unrelated .trn files, legacy monthly names and unmapped/multi-set media. Required backup GUIDs are protected across alternate paths/copies. It preserves a full before the PITR boundary and a header-validated ordinary-log chain through the latest backup, including required older/manual/fallback segments. It checks database family/fork, GUID, position, LSN coverage, backup age and current checksums; it fails closed on missing/mismatched/unsupported required media. Default behavior is audit-only. Before approved deletion, required media undergo checksum VERIFYONLY, candidate paths/size/timestamp are checked again, and intent/result records are flushed to a unique JSON-lines audit file. No recursive enumeration or deletion, directory deletion, junction traversal or recovery-model changes.
- **Prepare-JobUpdate.ps1:** reads current production definitions using Windows authentication and writes an installation, exact rollback and baseline proposal into the ignored _temp directory. It does not execute the update. Both installation and rollback guard against changed command bodies, step configuration or running target jobs, and update all five commands in one transaction. Only @command is changed. Default proposals keep cleanup in audit mode; enabling deletion requires a separate explicit decision.
- **Check-BackupFreshness.sql:** independent read-only monitor candidate. It fails for an absent/overdue log (>30 minutes), overdue full (>26 hours), unexpected database identity or inaccessible latest media. It needs a separately approved Agent schedule/notification configuration to provide ongoing monitoring; no monitor job has been installed.
- **Test-BackupCleanup.ps1:** in-memory safety checks for exact decimal LSN arithmetic, full/log coverage, missing files, header/fork mismatch, copy-only/striped media, stale overwritten history, overdue backups, strict filenames, misleading filesystem timestamps and a boundary full older than daily retention. It performs no SQL connections, backups or filesystem mutation.

The backup retry boundary is deliberate: checksum verification and fallback email happen after the retry loop. A completed/registered backup is never followed by an automatic fallback backup merely because verification or email failed. Preserve every successful log file and investigate such failures. Original retry_attempts=0 is preserved.

Fallback warnings use the existing SQLAlerts profile and DBA_Alert operator rather than embedding a recipient address. Existing job failure notification settings remain configured. Email receipt has not been verified. No dedicated test message was sent; held audit runs may trigger the existing job failure notifications.

## Policy retained in this proposal

- Daily full retention: 31 days.
- Log/PITR retention: 14 days.
- Month-end archive retention: 12 months.
- Monthly creation: current last-calendar-day job run, not a financial-close trigger.
- Full: 01:00 daily; log: every 15 minutes; log cleanup: 03:30 daily.

Optional policy questions were asked; no replacement policy has been received, so existing values are preserved. Fourteen days of logs do not promise 31-day PITR merely because full backups last 31 days. A required full/log may be kept beyond nominal age to protect the selected recovery boundary.

Large existing VLFs, FULL recovery and the already-fixed 256 MiB log growth remain untouched. No new backup architecture, database objects or application changes are introduced. Periodic real restores and an independently protected copy remain operational recommendations; they are not automatically scheduled or copied by this package.

## Current validation results and limitations

Passed:

1. SQL Server 2014 PARSEONLY checks of the backup template and concrete installation/rollback proposals. No BACKUP or job update was executed by these syntax checks.
2. Compilation/binding of cleanup history SELECT fields against current SQL Server 2014 msdb. A reserved alias File initially failed and was corrected to [File]; the corrected query passed.
3. Actual read-only freshness check on IBN-SERVER: at 21:04:31, last log 21:00:01 and last full 01:00:03 were timely and engine-readable.
4. Exact read-only baseline comparison: all five current command bodies, subsystem/context and routing/retry values still match the pre-change snapshot.
5. Syntax-only trial checks and ISPADMIN2 identity, source database, target-name/physical-file availability and folder visibility checks.
6. Actual static PowerShell parser checks passed all three .ps1 files, using Parser.ParseFile without executing their contents.
7. After user approval, all 34 in-memory cleanup safety checks passed in one PowerShell process using RemoteSigned. A separate fresh process confirmed every policy scope remains Undefined; no persistent policy changed.
8. On ISPADMIN2, two full backups from ISPDATA_RestoreTest produced distinct files, and two log backups used the deliberately selected fallback directory. All four media passed checksum VERIFYONLY. The latest matching full/log pair restored into ISPDATA_BackupScriptsTest, ONLINE/FULL; CHECKDB completed without errors. Restore history confirms no REPLACE. See Trial-Validation.md.
9. Before installation, read-only production checks confirmed the five original command bodies and routing still matched the captured baseline. On 2026-10-15, exact checks confirmed all five installed bodies match the audit-only proposal plus the connection-builder correction; owners, schedules, notifications, routing and retries were preserved.
10. Production SQL Agent full/log steps passed with checksum verification on SQL Server 2014. All three cleanup modes connected/read/wrote audit records under NT Service\SQLSERVERAGENT, then safely held at the same missing-log boundary. Thirty-five local safety checks now pass, including the connection-builder regression case.

Not passed or not run:

- Complete retained-chain validation and deletion candidates: blocked by missing historical media. Agent SQL connection, metadata/header reads, directory inspection and audit writing worked; later chain files and deletion-path checksum verification have not all been exercised. Filesystem delete permission was not tested.
- Automatic cleanup deletion remains disabled. A separately approved one-time run subsequently deleted 17 reviewed log files; the May 5 full remains after an access-denied error. See OneTime-Cleanup-Execution.md.
- Mail receipt, independent monitoring schedule, financial-close scheduling and an independent protected copy: not deployed/tested.

No application or schema-project code changed, so an HIS/Accounts/DACPAC build is not relevant. SQL and PowerShell operator scripts are not included in HIS.sln or IspDataDb.sqlproj and are not automatically deployed. Source files use CRLF. No patient records, passwords or full connection strings were selected/output. Private baseline/review files are local ignored artifacts; do not commit them or test database media.

## Confirmed boundary gap in the existing retention scheme

At 2026-10-14 21:32:51 production local time, the exact 14-day boundary was September 30 at 21:32:51. The newest full before that boundary is the September month-end archive, finished September 30 at 01:00:08. Its first covering log is ISPData_Log_20260930_011500.trn, finished 01:15:01. The full exists, but this required log is absent from BOTH configured F: and E: folders, as checked with engine xp_fileexist. An independent copy elsewhere has not been ruled out. Retained history is continuous, but age-only cleanup has not preserved all media needed for that oldest recovery boundary. A fresh backup cannot reconstruct a deleted historical log.

The new cleanup intentionally holds when such a boundary is incomplete; it will not pretend that 14-day PITR is established or delete more media. A complete boundary must be available before enabling deletion. Preventing further loss and preserving a full plus its covering logs must be included in the approved rollout. The approved 2026-10-15 installation switched the three cleanup commands to audit-only. Their schedules remain enabled; no backup media is deleted. The advancing October 1 boundary has the same missing-log problem, detailed in Deployment-Validation.md.

## Concrete review artifacts (ignored local files)

The initial pre-installation bundle is archived under _temp/ispdata-backup-hardening/review:

- Install-JobCommands.sql: five replacement commands, audit-only cleanup.
- Rollback-JobCommands.sql: exact original commands, with drift checks.
- Baseline-and-Proposal.json: original and proposed text for local review.
- Verify-Baseline.sql: read-only check that live jobs are still unchanged.

Current installed-state verification and rollback are under _temp/ispdata-backup-hardening/installation-20261015: Verify-Corrected.sql, Corrected-Proposal.json, and Rollback-Corrected-to-Original.sql. Use the corrected rollback because its guards recognize the deployed connection-builder fix. Never run an archived installer blindly. If production definitions change, regenerate and review; do not weaken a guard. Keep the private rollback/snapshot independently available. The source preparer is not itself runtime-validated yet; this initial concrete bundle was generated through file access from a read-only SQLCMD snapshot while PowerShell runtime execution was blocked.

## Isolated trial: approved and completed 2026-10-14

Target SQL computer/default instance: **ISPADMIN2**, Windows authentication.

Source database: **ISPDATA_RestoreTest** (the previously approved/restored copy).
New destination database: **ISPDATA_BackupScriptsTest**, checked unused.

Private trial scripts are under _temp/ispdata-backup-hardening/trial:

1. Run Trial-Full.sql twice. It is the current template with machine/database and destinations substituted exclusively for the test environment. Confirm two distinct full files, both checksum-verified.
2. Run Trial-Log-Fallback.sql after the full backup has completed. Its primary folder intentionally does not exist; fallback is the private trial Fallback\Logs folder. Confirm one successful fallback log and checksum verification. Fallback mail is disabled in both trial variants.
3. Inspect fresh full/log headers, FILELISTONLY, selected positions, family/fork and LSN coverage. If they do not match expectations, stop without restoring.
4. Trial-Restore.sql defaults to metadata-only inspection (@ExecuteRestore=0). After approved header/file-list review, set @ExecuteRestore=1 in a separate approved execution copy and restore the fresh trial full/log into ISPDATA_BackupScriptsTest, then CHECKDB and ONLINE checks. No REPLACE or automatic drop.

New backup files are restricted to these already-created private test folders on ISPADMIN2:

- D:\AATM\_temp\ispdata-backup-hardening\trial\Primary
- D:\AATM\_temp\ispdata-backup-hardening\trial\Fallback

New restoration files:

- D:\AATM\_temp\ispdata-backup-hardening\trial\restore\ISPDATA_BackupScriptsTest.mdf
- D:\AATM\_temp\ispdata-backup-hardening\trial\restore\ISPDATA_BackupScriptsTest_log.ldf

Expected restored allocation is about 2.35 GiB plus new backup media and CHECKDB workspace; allow 10 GiB conservative headroom for this small trial. The approved trial created new backup media and restored database files in these folders. SQL-engine writing and restoration were verified. Do not change ACLs automatically if writes fail.

No production paths, email sends, existing backup deletion, job installation or production recovery changes are included in this trial. Test files/database remain until explicitly approved cleanup. Restore acceptance on SQL Server 2019 is not identical-version SQL Server 2014 acceptance; keep that limitation visible.

## Rollout controls and remaining work

1. Completed: local PowerShell safety/syntax checks and approved full/log/fallback/restore trial.
2. Review exact installation/rollback files, a quiet execution interval and the current production baseline. Confirm recoverable backups and protected copies of the job definitions.
3. Completed with explicit user approval: installed commands on IBN-SERVER, followed by the connection-builder correction. All cleanup remains audit-only. This suspends age-based deletion for these jobs; monitor disk space and do not leave audit mode indefinitely.
4. Under the actual Agent identity, review audit output across primary/fallback/manual paths and fix any permission/mapping/gap issues. Dry run creates only audit files/directories; it does not delete backup media.
5. Review actual deletion candidates and get explicit approval before generating/applying an EnableCleanupDeletion proposal. Checksum verification adds I/O; measure its daily cost and scheduling overlap before enabling.
6. Add the independent freshness monitor, test notification receipt and schedule repeat actual restores only after approval. Specify separate storage for an independently protected copy before automating it.

Rollback returns command bodies to the exact captured baseline and preserves unrelated settings. It does not erase newly generated backups/audit files or undo deleted media. If reverting to the original broad cleanup commands, review the files now present first: old globs may match the new generated names. A rollback of definitions cannot recover deleted files; protect copies and separately decide cleanup behavior.

References: [BACKUP media options/checksums](https://learn.microsoft.com/en-us/sql/t-sql/statements/backup-transact-sql?view=sql-server-ver17), [RESTORE VERIFYONLY limitations](https://learn.microsoft.com/en-us/sql/t-sql/statements/restore-statements-verifyonly-transact-sql?view=sql-server-ver17).

PowerShell policy reference: [Restricted permits individual commands but blocks script files](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-5.1).

## One-time expired-file review

After acceptance of the October 14 restored full as a new recovery baseline, a separate review-only job validated the protected chain and identified an exact expired-file list. See [OneTime-Cleanup-Review.md](OneTime-Cleanup-Review.md) and [candidate CSV](OneTime-Cleanup-Candidates-20261015.csv). At the review stage nothing was deleted. The one-time review does not alter the installed automatic cleanup commands or promise a complete historical 14-day window.

## Approved one-time deletion result

The subsequent user-approved run deleted the 17 reviewed log files (408 KiB). The May 5 fallback full could not be deleted because Windows denied access; it remains for an authorized administrator. Both one-time jobs are disabled, and the existing automatic cleanup remains audit-only. See [final execution report](OneTime-Cleanup-Execution.md) and [per-file results](OneTime-Cleanup-Results-20261015.csv). No filesystem permissions were changed.

## Subsequent user security changes and verification

The 2026-10-15 08:39 verification found the May 5 fallback full still present, the screenshot share mapped to a different F: folder, the previously protected manual ISPDATA_Log.trn absent, and Agent share access still denied. Current scheduled backups remained healthy. No permissions were changed by verification. See [Access-Verification-20261015.md](Access-Verification-20261015.md) before acting on earlier protection/access results.

## Latest recheck: 2026-10-15 09:17

The user subsequently removed the May 5 file; it is now confirmed absent. Today's 07:35 full and seven subsequent logs through 09:15 passed checksum verification with continuous recorded LSN coverage and do not require the missing older manual log. Agent access to the manual-backup folder/share is still denied; automatic cleanup stays audit-only. See [Access-Recheck-20261015.md](Access-Recheck-20261015.md) for the current state.

## Directory permissions verified: 2026-10-15 10:04

After the user's changes, SQL Agent has Modify on both backup roots with inheritance to Logs/Monthly; all eight local directory reads and UNC share listing passed. The manual-backup folder has Modify too, which is broader than the Read/List needed. No permissions or backup files were changed by verification. Automatic cleanup remains audit-only pending retention validation. See [Directory-Permissions-Verified-20261015.md](Directory-Permissions-Verified-20261015.md) for checks and limits.
