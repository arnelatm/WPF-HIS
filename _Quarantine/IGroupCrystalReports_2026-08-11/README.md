# IGroup Crystal Reports quarantine

This batch inventories Crystal Reports below Accounts/Reports/IGroup and protects a report when any of these usage signals exists:

- an exact .vbproj or .csproj item reference;
- a report filename or filename stem in a source/configuration string literal; or
- a matching ReportFileName in the live [ISPDATA].[dbo].[Report] or [ISPDATA].[dbo].[ReportFile] table on $SqlServer.

Both active and inactive database rows are protected. Generated report wrapper source inside the report asset directory is excluded from the literal scan to avoid treating an unused report as its own usage evidence.

## Batch summary

- Status: Applied
- IGroup reports inventoried: 1040
- Reports protected by usage evidence: 240
- Unreferenced reports selected for quarantine: 800
- Selected size: 403.25 MB
- Database report-registry filename rows inspected: 165

Manifests/IGroupCrystalReportUsage.csv records the decision and evidence for every report. Manifests/ReportTableSnapshot.csv records the live database rows used by this run. Manifests/QuarantinePlan.csv records the planned moves, and Manifests/QuarantinedReports.csv maps applied moves to their restore paths.

To restore a moved file, move it from QuarantinePath back to Path. Do not deploy reports directly from this quarantine directory.
