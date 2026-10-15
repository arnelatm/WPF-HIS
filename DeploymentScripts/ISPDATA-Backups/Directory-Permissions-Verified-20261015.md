# SQL Agent directory-permission verification

2026-10-15, 10:03-10:05 server local time, IBN-SERVER / ISPDATA. User requested verification after manually applying permissions. No ACL/security changes or backup deletions were made by this verification.

## Result

| Path | Configured SQL Agent permission | Actual check |
| --- | --- | --- |
| F:\ISPDataBackup | Allow Modify + Synchronize; applies to folder/subfolders/files | Directory listing and representative backup read passed |
| E:\SQLBackupFallback\ISPDataBackup | Allow Modify + Synchronize; inherited | Directory listing passed; no backup files remain there to sample |
| F:\Ibn-Server-SqlBackup | Allow Modify + Synchronize; applies to folder/subfolders/files | Local directory listing passed |
| \\ibn-server\Ibn-Server-SqlBackup | Effective folder listing allowed | UNC directory enumeration passed under SQL Agent |

Actual execution identity was NT Service\SQLSERVERAGENT. The Modify ACL mask was 1,245,631 (Modify plus Synchronize). Logs/Monthly on both primary and fallback roots, plus the fallback Audit folder, inherit the Agent entry. All eight inspected local directories were readable; no deny ACL entries were found in those directories. Representative existing primary daily/log/monthly files were readable and inherited Agent Modify. Empty folders could not supply a sample file.

The manual-backup folder was granted Modify instead of the requested Read & execute/List/Read; this is sufficient but broader than needed. No permission reduction was applied. Its inheritance is protected, but the explicit Agent allow entry propagates to children. Some unrelated unresolved SIDs remain in that folder ACL; they were not identified, changed or removed. This check verifies Agent access and the requested entries, not the legitimacy of every other principal.

## Expected missing files and diagnostic limits

The deleted May 5 full and missing manual ISPDATA_Log.trn are still absent. The manual log open now returns File not found rather than Access denied; local/UNC directory reads succeed. Absence of the old log is not a current permission failure.

WMI share-security-descriptor inspection and Get-Acl through the UNC path still did not return usable descriptors. Local ACLs and actual UNC enumeration establish the access exercised. A new real file create/delete test was not performed; Modify is verified from ACLs and read access was tested. Unique diagnostic audit writing still succeeds. No backup file was created, modified, renamed, copied or deleted by this check.

## Backup and job status

At 10:04:40, the latest full finished 07:35:11 and latest log finished 10:00:00; both were timely and engine-readable. The existing five backup/cleanup commands remain unchanged. Automatic cleanup remains audit-only; retention-chain validation is a separate remaining prerequisite before enabling deletion. This check did not establish a complete historical 14-day recovery window.

The existing unscheduled diagnostic job was updated only to add read-only folder/child/sample probes, executed successfully in five seconds, and remains disabled with no schedule. PowerShell static parsing passed, and the actual probes ran under SQL Agent. Application/DACPAC builds were not relevant. No application/schema deployment occurred.

## Evidence

Read-only diagnostic source: Test-BackupAccess-20261015.ps1. Server JSON: E:\SQLBackupFallback\ISPDataBackup\Audit\AccessCheck_20261015_100446_4cb8b239e23a404f8ae6b9bb69bd68be.json. Private local JSON: _temp/ispdata-backup-hardening/permissions-final-20261015/Results.json. Earlier reports of Agent access denied are historical; the successful checks in this report supersede those access results.
