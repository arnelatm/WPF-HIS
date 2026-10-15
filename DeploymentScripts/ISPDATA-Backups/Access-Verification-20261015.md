# Backup access verification after user security changes

2026-10-15, approximately 08:39-08:43 server local time. Verification only on IBN-SERVER; no permissions, backup jobs, recovery settings or existing backup files were changed by this check. A separate unscheduled read-only Agent diagnostic job was created, run successfully, and disabled. It wrote one unique diagnostic JSON audit file.

## Confirmed current state

- E:\SQLBackupFallback\ISPDataBackup\ISPData_20260505.BAK still exists on IBN-SERVER, 53,078,016 bytes. This is the file that failed the approved cleanup deletion.
- The screenshot's share \\ibn-server\Ibn-Server-SqlBackup maps to F:\Ibn-Server-SqlBackup, confirmed using the server's share registry entry. It is not the E: fallback backup directory.
- The previously protected manual backup ISPDATA_Log.trn is now absent from both that UNC path and the corresponding local F: path; parent directories exist. SQL Server's VERIFYONLY returned operating-system error 2, file not found. An engine directory listing returned no files in the share. The previously verified manual GUID was C2B3DE3E-DD29-41B0-9E54-10D40EEA4DD4. No deletion of this file was performed by our approved cleanup, whose exact 17 deleted paths are recorded separately.
- SQL Agent identity NT Service\SQLSERVERAGENT still receives Access denied opening the manual UNC path. The provider-qualified Test-Path also returns Access denied. An unqualified Test-Path under SQLPS reports false, which must not be treated as conclusive absence by itself.
- The May 5 file is owned by NT SERVICE\MSSQLSERVER. Its inherited ACL grants full control to the named administrator, MSSQLSERVER, Administrators and SYSTEM; Users has read/execute. SQLSERVERAGENT has no dedicated allow rule there. The containing E: directory has the same full-control principals plus Users read/execute/create rights and creator-owner handling; no Agent-specific delete/modify grant was present.
- Scheduled backups remain timely and engine-readable: at 08:39:52 the latest log finished 08:30:00 and latest full 07:35:11. The exact installed five audit-only backup/cleanup commands remain unchanged.

## Limits of the check

The Agent WMI share query returned the share name but no local Path, and the share-security query returned no descriptor. UNC Get-Acl/directory enumeration did not yield a usable share ACL. These are failed or inconclusive probes, not evidence that security is fixed. The engine's registry entry independently establishes the share mapping. The screenshot alone cannot establish effective Agent access or whether deleted unresolved SIDs were unused.

## Follow-up

Confirm the exact filename deleted by the user and whether the manual ISPDATA_Log.trn is available in the Recycle Bin or an independent copy. Restoring that exact original segment, if available, preserves the October 14 baseline's forward log chain. A newer full backup remains a separate recovery starting point; current production data and scheduled backups were not damaged by these verification checks. Keep automatic cleanup audit-only.

Review permissions on the actual relevant folders, distinguishing SQL Server engine identity from SQL Agent identity. Share read access and NTFS read access both matter to Agent access; future backup deletion also needs appropriate delete/modify rights on the approved backup roots. No ACL/security corrections were authorized or applied in this verification.

## Evidence

Read-only source: Test-BackupAccess-20261015.ps1 (PowerShell parse passed). Actual Agent run succeeded in 5 seconds and collected both successful and failed probes. Detailed JSON remains in private _temp/ispdata-backup-hardening/access-check-20261015/AccessCheck.json and E:\SQLBackupFallback\ISPDataBackup\Audit\AccessCheck_20261015_084106_3f9b36a8f4e04749a5c7511148d26ce9.json. The diagnostic job ISPDATA Read-Only Access Check 20261015 is disabled and has no schedule. No application/DACPAC builds or deployment were involved.
