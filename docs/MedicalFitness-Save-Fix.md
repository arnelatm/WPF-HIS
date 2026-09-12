# Medical fitness save: long Kizen test codes

Read-only diagnosis on 9 September 2026 found that invoice 77341/report 85
was missing its Random Blood Glucose row in the saved details. Kizen supplies
the 60-character code `Item_L658_PropertyGroup__Property_Random Blood Glucose (RBS)`.
Both medical fitness result and lab-template tables allowed only `varchar(50)`.
Kizen's source `VisitAnalysesResult.Code` is `nvarchar(255)`.

Retrieving/refreshing the invoice adds the glucose row to the grid again, while
printing reads the saved details. The old save deleted/reinserted details through
separate connections. The shared `Db.Scalar` helper could show an insert error,
return without throwing, and allow later rows and a success message to continue.

The fix preserves full codes as `nvarchar(255)` in both destination tables.
Medical fitness saves now use one SQL connection and transaction for the header
and all details, with `XACT_ABORT ON` and rollback on failure. IDs and the success
message are published only after commit. SQL errors leave the form entries in
place and show a bilingual failure message without SQL result/patient values.
The shared database helpers and Crystal report definitions were not changed.

## Verification

Accounts and the ISPDATA SQL project built successfully with existing warnings.
Fourteen checks passed against an isolated LocalDB database with synthetic data:
the original 60-character failure, rollback of new/existing reports, migration
repeatability, full Unicode codes, template uniqueness, successful new/update
saves, invoice lookup, and glucose inclusion in the print dataset both with a
numeric entry result and with an automatic Fit status alone.

Run after building Accounts to an isolated output directory:

```powershell
powershell -NoProfile -ExecutionPolicy Bypass -File tools\Test-MedicalFitnessSave.ps1 -BinaryDirectory .tmp\medical-save-build
```

The runner creates and removes only a randomly named LocalDB test database.
It uses synthetic configuration and never reads the application's connections.

## Deployment pending approval

The diagnosed database is `ISPADMIN2 / ISPData`. No production writes were made.
Back it up and exercise the migration on a restored test copy before applying
`DatabaseScripts/WidenMedicalFitnessLabTestCode.sql` to the confirmed live target.
The script changes only the two code column definitions, preserving the lab
template unique constraint within the same transaction. Deploy the matching
Accounts application using the approved build/deployment process.

After deployment, retrieve invoice 77341, review and save its results, then open
a fresh preview. Confirm glucose appears and check English and Arabic/RTL views.
If the numeric value is wanted on the certificate, populate Entry Result before
saving. A restored-production form smoke test and rendered report preview remain
pending; print-dataset checks do not replace these checks.
