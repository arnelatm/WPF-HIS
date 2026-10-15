# ISPDATA backup-script trial validation

Completed on 2026-10-14 with explicit user approval. SQL computer/default instance: ISPADMIN2, SQL Server 2019 Developer 15.0.2104.1, Windows authentication.

- All 34 pure in-memory cleanup safety cases passed. RemoteSigned applied only to the test PowerShell process. A fresh process reported MachinePolicy, UserPolicy, Process, CurrentUser and LocalMachine all Undefined.
- Two full backups of ISPDATA_RestoreTest produced distinct timestamp/GUID names in the private trial Primary directory. Backup sets 10304 and 10306 each passed checksum VERIFYONLY.
- Two ordinary log backups successfully selected the private Fallback/Logs folder because AbsentPrimary/Logs was intentionally unavailable. Backup sets 10305 and 10307 each passed checksum VERIFYONLY. Mail was disabled.
- The first log ran while the second full was completing. The metadata-only restore selector correctly rejected that pair because the log did not cover the full ending LSN. After the full completed, another test log was taken and accepted. No restore was attempted for the rejected pair.
- Full set 10306 (GUID 6658FE88-CE3D-4A1B-BFCE-827023ECF9B6) and log set 10307 (GUID 1817CFCA-DE20-436D-8258-AD280CC50BBA) had matching family/recovery fork and covering LSNs. Full LastLSN 55000109969400001 lies within log FirstLSN 55000109969300001 / LastLSN 55000109970700001. File list confirmed logical files ISPDATA and ISPDATA_log.
- Restored to ISPDATA_BackupScriptsTest with FULL NORECOVERY then LOG RECOVERY. CHECKDB completed without errors; database ONLINE, recovery FULL. Restore history records replace=0 for both operations.
- New physical files remain under D:\AATM\_temp\ispdata-backup-hardening\trial\restore. New backups remain under the trial Primary and Fallback folders. No test files or database were deleted.
- Read-only production baseline verification after testing confirms all five commands and routing/retry settings unchanged on IBN-SERVER. Existing backup files, recovery model and production database were not modified. Nothing deployed.

SQL Agent execution identity permissions, live cleanup audit, real deletion, email receipt, month-end branch and SQL Server 2014 runtime acceptance remain untested. SQL Server 2014 syntax checks passed; the actual trial used SQL Server 2019. No application/schema changes occurred, so application and DACPAC builds were not needed.

Private detailed evidence is in _temp/ispdata-backup-hardening/trial/Metadata-Results.txt and Restore-Results.txt. Preserve these private artifacts and test media until separately approved cleanup. Production deployment requires separate authorization; proposed initial cleanup commands are audit-only.
