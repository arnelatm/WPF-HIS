# Medical fitness names by report format

Open **Medical Fitness Report Formats**, select a format, and choose **Configure Items**.
The English Name and Arabic Name columns show the shared clinical/XRay item names.
Edit the two optional name overrides, then choose **Save Items**.

| Column | Used for | Blank value |
| --- | --- | --- |
| English Name Override | English item name for this report format | Shared English item name |
| Arabic Name Override | Arabic item name for this report format | Shared Arabic item name |

For `CARDIOVASCULAR_SYSTEM`, set English Name Override to `CVS` in the Standard
format and to `Cardiovascular` in the Legacy format. The entry form displays the
name configured for the selected report format. Both formats use the same item code.
English and Arabic overrides are independent. Clear an override to restore inheritance.
The test code, results, unit, and fit/unfit decisions remain attached to the same item.

New entries use the selected format's labels. Retrieving a saved report or changing its
format refreshes the entry labels while retaining matching results. Printing resolves
the current labels for the **saved** report format; save a format change before printing.
Changing configuration also changes labels on reprints of older reports. There is no
historical label versioning.

The standard Crystal report already reads `MedicalFitnessReportTestResult.TestNameEnglish`
and `TestNameArabic`; those fields receive the same configured item names.
The supplied template table receives matching labels for layouts using that table.
The SQL print view also resolves the clinical/XRay labels. Hard-coded Crystal text
objects, including the legacy report's fixed `CVS` caption, require a separate Crystal
designer change to use data fields. These overrides do not change static text objects.

## Deployment and verification

The authoritative schema is in `IspDataDb/dbo/Tables/MedicalFitnessReportFormatItem.sql`
and `IspDataDb/dbo/Views/MedicalFitnessReportPrint_View.sql`. The companion script
`DatabaseScripts/AddMedicalFitnessReportItemNameOverrides.sql` adds the two nullable
columns and refreshes that view atomically; it does not seed labels or rewrite results.
Apply the script before using the matching Accounts build. It is safe to rerun.

Database application requires a confirmed server/database, explicit authorization,
a backup, and validation on a restored test database. No database changes were run
while implementing this feature.

Implementation checks passed: the Accounts project graph built using an isolated
output folder, the ISPDATA DACPAC built, and all seven affected DAO SQL statements
plus the deployment script parsed with the SQL Server 2014 parser. Existing assembly
and schema-reference warnings remain. The standard Crystal name formula was inspected
read-only. Database-backed form checks and rendered report previews remain pending.

On a restored test copy, verify:

1. Configure the same code in two formats with different English/Arabic labels.
2. Check a new report and a retrieved saved report in each format; switching formats
   must retain entered results for matching codes and refresh the names.
3. Clear each override independently and confirm the fallback, including Arabic-only
   overrides, whitespace, and apostrophes.
4. Save and preview the standard Crystal report with `InvoiceNo` and `SuppressLogo`;
   confirm data-bound names match the selected format and result values persist.
5. Check both English and Arabic/RTL entry layouts, long names, and XRay items.
6. Confirm a format without overrides and laboratory rows still behave as before.
