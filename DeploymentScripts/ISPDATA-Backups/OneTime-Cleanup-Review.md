# One-time expired-backup review

2026-10-15. User accepted the restored October 14 full as the recovery baseline and requested a one-time review of expired files before deletion. Automatic cleanup remains audit-only with its original policy and commands.

New-OneTimeCleanupReview.ps1 is a fixed-date, review-only operator script for IBN-SERVER. It reuses the shared planner in a private script scope, replacing only its recovery-anchor selection with 2026-10-14 01:00:03 and preserving actual expiry limits (logs 14 days, daily 31 days, monthly 12 months). It asserts the anchor GUID A9ABD86A-45E3-460B-AAC9-14F70FAB25FA, independently confirmed in ISPADMIN2 restore history. This does not claim the previous 14-day historical window is recoverable.

The review inventories only the six existing primary/fallback daily, Logs and Monthly directories, uses metadata/header identity and managed-name checks, and checksum-verifies the protected anchor/latest full/log chain before publishing candidate and complete-inventory CSVs. It contains no deletion operation. Special/manual/unmapped/reparse/copy-only media are protected by the shared planner.

A required ordinary manual log from 2026-10-14 17:53:35 is outside these folders: \\ibn-server\Ibn-Server-SqlBackup\ISPDATA_Log.trn, GUID C2B3DE3E-DD29-41B0-9E54-10D40EEA4DD4. SQL Server can read its matching header, while the Agent filesystem existence test did not see it. This review checks existence via the engine, followed by header/checksum verification. It never makes this external path a deletion candidate. The unchanged automatic cleanup may also need this access discrepancy addressed before enabling deletion.

An unscheduled, review-only Agent job named ISPDATA One-Time Cleanup Review 20261015 was created. Initial inline-path default and engine-versus-Agent media visibility issues were corrected in that review job only. Existing three production job definitions were verified unchanged against the installed audit-only snapshot. No backup was deleted or copied, and no recovery model or security permissions were changed. Source/inline PowerShell parser checks passed. Builds are not applicable to standalone operator scripts. Final results and exact deletion manifest are recorded separately after job completion.

## Completed review and exact proposed deletion set

The final Agent run succeeded at 07:59:04, duration 1 minute 32 seconds. All three modes selected the exact accepted full GUID. The anchor full, latest full, and 128 covering logs (130 media total) passed checksum VERIFYONLY. This establishes checked headers/LSN continuity and media checksums through the 07:45 log, LastLSN 55000110504900001; it is not an additional actual restore of the entire chain.

Proposed deletion is limited to the exact 18 rows in [OneTime-Cleanup-Candidates-20261015.csv](OneTime-Cleanup-Candidates-20261015.csv), totaling 53,495,808 bytes (51.0176 MiB):

- 17 primary log files from October 1, 03:45 through 07:45, every 15 minutes; 417,792 bytes total.
- E:\SQLBackupFallback\ISPDataBackup\ISPData_20260505.BAK; 53,078,016 bytes.
- No monthly archives qualify. The accepted full, latest full, required manual log and newer retained files are excluded.

CSV SHA-256: 81a4b2c9acf9e78d9f5f7f125ff5d9934deee56bbebaefbbd9aa5079f9c0e595. Full inventory and detailed audit are in the private _temp/ispdata-backup-hardening/cleanup-review-20261015 folder; originals are under E:\SQLBackupFallback\ISPDataBackup\Audit on IBN-SERVER, tagged OneTimeReview_20261015_075736_61ad5ae03de348d4ae2ead4411181e3e.

The review-only Agent job has been disabled and has no schedule. The original backup/cleanup command comparison still passed. No backup media was deleted, renamed, overwritten or copied. At the review stage, approval of the exact deletion list was pending; the subsequent execution is recorded below. Execution must recheck metadata/header identity, file size/time, plain-file/path safeguards and the protected chain before deleting these paths only. Existing filesystem delete permissions have not been tested or changed.

## Subsequent approved execution

The user approved deletion after reviewing the list and expiry explanation. Execution deleted 17 logs; the May 5 full remains because Windows denied deletion. See [OneTime-Cleanup-Execution.md](OneTime-Cleanup-Execution.md) for authoritative final results. Earlier no-deletion statements above describe the review stage.
