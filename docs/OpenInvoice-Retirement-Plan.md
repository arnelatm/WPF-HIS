# AP/AR OpenInvoice Retirement Plan

## Purpose

Retire the legacy stored summary fields from `ApOpenInvoice` and `ArOpenInvoice` only after all open-invoice transactions, payment links, views, reports, and application workflows have been verified.

Legacy fields planned for retirement:

- `ApOpenInvoice.PaidAmount`
- `ApOpenInvoice.DiscountTaken`
- `ArOpenInvoice.PaidAmount`
- `ArOpenInvoice.DiscountTaken`

## Current AP status

Live database: `IBN-SERVER.ISPData`

- AP control balance reconciles with calculated `ApOpenInvoice_View` balance.
- No orphan AP open invoices were found.
- No orphan `CdOiItem`, `CkOiItem`, or `PcOiItem` records were found.
- No duplicate AP source links remain.
- The `0.01` difference in `CdJournal 19579` is valid advance activity. `ApOpenInvoice 3941` was created by that journal and settled by `CdOiItem 4789` in `CdJournal 19621`.
- The eight AP-related functional views were redirected to calculated values from `ApOpenInvoice_View` in production.
- The stored AP summary fields remain physically present and stale in some historical rows. They are no longer authoritative for the updated views.

## Current AR status

The AR investigation is still pending. Complete the AR audit before removing any AP or AR summary columns.

## Required retirement sequence

### 1. Complete the AR audit

Verify:

- AR control balance versus `ArOpenInvoice_View` balance.
- No orphan `ArOpenInvoice` records.
- No orphan `CsrOiItem` records.
- No duplicate AR source links.
- All CROI allocations and customer advances are understood.
- No unexplained customer-level balance differences remain.

### 2. Inventory all dependencies

Search the database:

```sql
USE [ISPData];

SELECT
    OBJECT_SCHEMA_NAME(m.object_id) + '.' + OBJECT_NAME(m.object_id) AS ObjectName,
    o.type_desc
FROM sys.sql_modules m
INNER JOIN sys.objects o ON o.object_id = m.object_id
WHERE m.definition LIKE '%OpenInvoice%'
  AND (
       m.definition LIKE '%PaidAmount%'
       OR m.definition LIKE '%DiscountTaken%'
      )
ORDER BY ObjectName;
```

Search the application, reports, scheduled jobs, exports, and integrations for:

```text
ApOpenInvoice.PaidAmount
ApOpenInvoice.DiscountTaken
ArOpenInvoice.PaidAmount
ArOpenInvoice.DiscountTaken
PaidAmount
DiscountTaken
```

External Crystal Reports, SSRS reports, scripts, and integrations must be checked separately because SQL Server dependency metadata cannot detect every external reference.

### 3. Redirect all functional references

Use calculated values from:

- `ApOpenInvoice_View`
- `ArOpenInvoice_View`

Do not calculate balances from the base-table summary columns.

### 4. Remove write dependencies

Remove `PaidAmount` and `DiscountTaken` from AP and AR insert statements. New open-invoice rows should be created using only their source-link fields, for example:

```sql
INSERT dbo.ApOpenInvoice
    (JournalCode, JournalIdNo, JournalItemIdNo)
VALUES
    (@JournalCode, @JournalIdNo, @JournalItemIdNo);
```

Apply the equivalent change to `ArOpenInvoice` procedures and DAOs.

### 5. Update the source project

After dependency review, update:

- `IspDataDb\dbo\Tables\ApOpenInvoice.sql`
- `IspDataDb\dbo\Tables\ArOpenInvoice.sql`
- AP and AR stored procedures
- AP and AR business/model classes if no longer required
- DAO mappings and reports

Remove only the four legacy summary columns. Do not alter payment-child tables.

### 6. Test on the audit database

Build without publishing:

```powershell
msbuild IspDataDb\IspDataDb.sqlproj /p:Configuration=Debug
```

Deploy first to:

```text
ISPADMIN2.ISPDATA_AuditTest
```

Test AP and AR invoice creation, payments, partial payments, full settlement, advances, journal editing, reports, and balance displays.

### 7. Back up production

Before removing columns from production, take and verify a full backup of:

```text
IBN-SERVER.ISPData
```

Use a unique backup filename and run `RESTORE VERIFYONLY`.

### 8. Deploy to production

Publish the tested schema change to `IBN-SERVER.ISPData` during a maintenance window. The production server is SQL Server 2014, so use SQL Server 2014-compatible syntax; do not rely on `CREATE OR ALTER VIEW`.

### 9. Post-deployment verification

Run:

- AP and AR control-to-open-invoice reconciliations.
- Orphan payment-link checks.
- Duplicate source-link checks.
- AP and AR screen/report smoke tests.
- New invoice and payment workflow tests.

## Recommendation

Do not remove the fields immediately. Leave them deprecated for one or two release cycles after all functional references have been redirected. Remove them only after the AP and AR audits, audit-database tests, external dependency review, and production backup are complete.

The fields contain stale legacy summaries, but the calculated views are the authoritative source for invoice payment and balance values.
