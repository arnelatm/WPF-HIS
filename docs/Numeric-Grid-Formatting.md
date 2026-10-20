# Numeric grid display formatting

The Accounts grid formatting changes apply to display only. They do not round or
rewrite model values, change database types, or change accounting calculations.

## Rules

- `NumericGridFormatting.SetFormatIfMissing` supplies a column format only when
  its inherited format is empty. Explicit column, grid, and cell formats retain
  priority. Forms apply their missing formats on `Shown`, after existing setup.
- Use the field's verified precision rather than a universal decimal count.
- Monetary columns retain their existing formats. Previously unformatted journal
  amount columns use the configured currency decimal digits and grouping.
- Identifiers and sequence numbers retain their existing integer presentation.
- Decimal fields without a verified scale use the shared `CDgvDecimalCell`
  fallback `0.############################`. This removes differences caused only
  by stored trailing zeros, without rounding away any of Decimal's 28 fractional
  digits. It does not impose a guessed precision on external lab data.
- `CDgvDecimalColumn.DecimalPlaces` retains its existing footer-calculation role.
  Its meaning was not broadened to change cell display or footer calculations.

## Field policies

These policies fill missing formats; they do not replace explicit formats.

| Forms | Fields | Missing display format | Source evidence |
| --- | --- | --- | --- |
| Employee Entry | Leave allowed, paid percent, carryover, maximum and accumulated leave | `F2` | `IspDataDb/dbo/Tables/EmployeeLeaveCredit.sql` |
| Employee Leave Earned Approval | Days earned | `F0` | `IspDataDb/dbo/Tables/EmployeeLeaveEarned.sql` (`SMALLINT`) |
| Payroll Entry | Attendance days and overtime hours | `F4` | `AttendanceItem.sql`, `OtWorkHour.sql` |
| Distribution Scheme Entry | Percentage | `F2` | `DistributionSchemeItem.sql` |
| Pay Element Entry | Factor value | `F4` | `PayElementItem.sql` |
| Inventory Selector | Quantity on hand and unit cost | `F4` | `Inventory.sql` |
| Inventory Transaction Entry | Quantity and unit cost | `F4` | `InvTransactionDetail.sql` |
| Inventory Request and Purchase Order Approval | On-hand, supplied and approved quantities | `F4` | `InvRequestDetail_View.sql`, `PurchaseOrderApprovalDetail_View.sql`, inventory/detail and supplied-quantity tables |
| Purchase Entry | Quantities and history quantities | `F4` | `PurchaseDetail.sql` |
| Purchase Entry | Unit sales price | `F2` | `PurchaseDetail.sql` |
| Sale Entry | Quantity | `F4` | `SaleDetail.sql` |
| Purchase and Sale Entry | Unit count | `F0` | `PurchaseDetailModel`, `SaleDetailModel` (`Int16`) |
| Purchase and Sale Entry | Unit cost | `F4` fallback only | Inventory cost scale; existing `SetFormat(7, 2)` retains priority |
| General, AP, AR, ER, Cash Receipt and Disbursement journal entry | Previously unformatted original, paid and discount amounts | Configured currency precision | Existing journal debit/credit formatting convention |

Disbursement Journal Entry also serves the `PcJournal` flow. Existing money and
debit/credit formatting in other journal grids remains in effect. No separate
compiled Purchase Journal entry form was found; the compiled Purchase Entry grid
is included above. No historical form was added to compilation.

The earlier Employee Earnings rate correction remains `0.0000`. Employee Deduction
Rate and Payroll Days Present retain their explicit two-decimal formats.

## Verification and manual smoke tests

The outstanding manual tests are recorded in
[Pending smoke tests: SMOKE-NUMERIC-001](Pending-Smoke-Tests.md#smoke-numeric-001-system-wide-numeric-grid-display).
They were deferred at the user's request on 2026-10-20. The checklist includes
per-screen results, accounting-state checks, and instructions for resuming later.

The focused control checks cover culture-aware formatting, explicit/inherited
format preservation, Decimal extremes, unchanged stored values, and the compiled
formatting handlers for 54 columns across 17 forms. These checks construct no
application presenters and access no database.

Manual checks still require a confirmed non-production environment:

1. Enter an integer and then a fractional value into an editable numeric column;
   leave the cell and check its configured display precision.
2. Add a detail row and check that it uses the same column format as loaded rows.
3. Check zero, negative and blank/nullable values where the field permits them.
4. Confirm that existing two-decimal money/unit-cost/Days Present formats remain.
5. Confirm that IDs, sequences, permissions, view-mode and posted-record
   restrictions are unchanged. Cancel edits unless saving test data is authorized.
6. Repeat in English and Arabic/RTL, checking separators and alignment.

Compilation and isolated formatting checks do not establish full form, database,
or accounting-workflow correctness.
