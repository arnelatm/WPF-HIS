# Approved one-time cleanup results

2026-10-15, IBN-SERVER / ISPDATA, SQL Server 2014. Explicit user approval covered the reviewed 18-file manifest. Execution ran through SQL Agent as NT Service\SQLSERVERAGENT from 08:19:25 to 08:21:40 server local time.

## Actual result

- Deleted the 17 approved October 1 log backups, 417,792 bytes total (408 KiB). Independent engine xp_fileexist checks confirmed all 17 absent.
- Could not delete E:\SQLBackupFallback\ISPDataBackup\ISPData_20260505.BAK, 53,078,016 bytes. Remove-Item -LiteralPath -Force returned Access to the path is denied. Independent verification confirms it remains present. It was attempted once; no ACL/ownership/security changes or alternate-account retry occurred.
- No other files were deleted. The refreshed review found 20 candidates, but execution was restricted to the frozen, previously reviewed 18 paths. The two newly expired files were excluded.
- The one-time job reports failure because one approved deletion failed. The completed deletion count is 17, not 18; the actual reclaimed size is 408 KiB, not 51 MiB.

[Per-file results](OneTime-Cleanup-Results-20261015.csv). [Original immutable approval manifest](OneTime-Cleanup-Candidates-20261015.csv).

## Protection and verification

The accepted October 14 full was reidentified by GUID A9ABD86A-45E3-460B-AAC9-14F70FAB25FA. Before any deletion, the accepted full, latest full, and 130 covering ordinary logs (132 media total) passed checksum VERIFYONLY, with matching headers/family/fork and continuous LSN coverage through the 08:15 log, ending LSN 55000110505500001. This includes the manual log \\ibn-server\Ibn-Server-SqlBackup\ISPDATA_Log.trn. This was chain/header/checksum validation, not a new actual restore of all media.

All 18 files passed fresh expiry, metadata/GUID, exact path, length, modification time and plain-directory/file checks before deletion began. The executor rechecked fingerprints and headers immediately before each operation and flushed an audit intent before deleting. No recursive delete, wildcard delete, directory deletion or permission change occurred.

After execution, independent engine checks confirmed the accepted full, latest full, required manual log and latest scheduled log remain present. ISPDATA remains ONLINE/FULL. All five existing backup/cleanup commands still exactly match the installed audit-only baseline. Full/log backups remain timely and engine-readable. Neither database schema/application records nor recovery/log-growth settings were changed.

The unscheduled review and one-time deletion jobs are both disabled. Automatic cleanup remains audit-only; no automatic deletion was enabled. The historical 14-day boundary gap and Agent-versus-engine visibility of the required manual share remain operational follow-up items before automatic deletion is considered. Retention limits remain 31-day daily / 14-day logs / 12-month monthly.

## Remaining manual action

An authorized Windows administrator on IBN-SERVER must review the May 5 file's delete permission/access restriction and remove that exact file if still desired. The deletion authorization is already recorded, but this task did not authorize changing filesystem security. No repeated attempts or permission bypass were made.

## Evidence and source

- Source: Invoke-OneTimeCleanup-20261015.ps1. Standalone and inline versions passed PowerShell static parsing; actual preflight/deletion ran under SQL Agent. No application/DACPAC builds were needed for operator scripts.
- Execution audit on IBN-SERVER: E:\SQLBackupFallback\ISPDataBackup\Audit\OneTimeDelete_20261015_082056_f447a05e6e4d4a75a0fd1367b7ca00d0.jsonl.
- Fresh protection audit: OneTimeReview_20261015_081930_c9782bb08f6243f88f8547dd8c7eda5f.jsonl in the same directory.
- Private local evidence: _temp/ispdata-backup-hardening/cleanup-review-20261015/Deletion-Audit.jsonl, Deletion-Verification.txt and PreDelete-Review.jsonl. These private artifacts remain ignored.

No application/schema deployment, commit or push occurred. The one-time SQL Agent job and approved backup deletions were the production actions in this step. Pre-existing workspace files were preserved.
