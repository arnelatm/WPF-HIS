# Crystal Reports quarantine

This directory contains Crystal Report files quarantined on 2026-08-11.

## Applied batch

- Tracked reports inventoried: 2,451
- Reports protected by a detected project or static-text reference: 156
- Exact-content archive-style duplicates quarantined: 377
- Unreferenced reports from explicit archive directories quarantined: 43
- Total reports moved: 420
- Total moved size: approximately 39.77 MB
- Project-included reports moved: 0
- Exact-duplicate canonical reports moved: 0

The inventory is deliberately conservative because the application can obtain report filenames dynamically from database data and configured report directories. A report is eligible for automatic quarantine only when it has no detected project or static-text reference and is either:

- an exact-content duplicate with an archive-style filename or directory; or
- located inside an explicit backup, copy, old, trial, test, or archive directory.

`Manifests/CrystalReportUsage.csv` records every tracked report and the evidence used to classify it. `Manifests/QuarantinePlan.csv` records the planned moves. After moves are applied, `Manifests/QuarantinedReports.csv` maps every original path to its quarantine path and provides the canonical retained report for exact duplicates.

To restore a report, move it from its recorded `QuarantinePath` back to `Path`. Do not deploy files from this quarantine directory.

The inventory can be regenerated from the repository root with:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\CrystalReportInventory.ps1
```

Apply the conservative quarantine plan with:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File .\tools\CrystalReportInventory.ps1 -ApplyQuarantine
```
