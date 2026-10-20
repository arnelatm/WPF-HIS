# Pending smoke tests

Last updated: 2026-10-20.

Pending suites:

- [SMOKE-NUMERIC-001: numeric grid display](#smoke-numeric-001-system-wide-numeric-grid-display)
- [SMOKE-BASE-002: control and base-form fixes](#smoke-base-002-control-and-base-form-fixes)
- [SMOKE-BASE-003: checkbox/date columns and validation collection](#smoke-base-003-checkboxdate-columns-and-validation-collection)

This is the repository checklist for deferred manual testing. It can be resumed
while other system updates continue. Pending items are not recorded as passed.

## SMOKE-NUMERIC-001: system-wide numeric grid display

**Status: pending; deferred at the user's request on 2026-10-20.**

### What has already been checked

- The user reported that the previous smoke tests all passed. Their exact form,
  language, and environment coverage was not recorded; this does not establish
  completion of the latest system-wide formatting checklist below.
- The user confirmed the Employee Earnings rate now displays four decimal places
  after leaving the cell.
- At implementation time, the library and Accounts Debug builds passed. Accounts
  was built into an isolated verification folder, not deployed.
- 227 focused numeric-formatting assertions and 98 earlier control-regression
  assertions passed. These checks accessed no database and did not replace manual
  form/workflow testing. Crystal Reports interop warnings remained in the build.

Implementation details and precision sources: [Numeric grid formatting](Numeric-Grid-Formatting.md).

### How to resume

In this conversation or a new Codex conversation opened in this repository, say:

> Resume SMOKE-NUMERIC-001 from docs/Pending-Smoke-Tests.md. Review the current
> changes, identify any updates since the checklist was recorded, and guide me
> through the remaining numeric-grid smoke tests one screen at a time.

Read this checklist and the linked implementation notes first. Preserve unrelated
working-tree changes. Recheck current code and build results because further
development may have changed the implementation since this checklist was saved.

### Before starting

- [ ] Record tester and date: ____________________
- [ ] Confirm the non-production environment and record a safe environment label:
      ____________________. Do not record credentials or a connection string.
- [ ] Close the running application/debugger normally, rebuild the current
      `Accounts/Accounts.vbproj`, and reopen that build against the confirmed test
      environment. Do not run an old executable or assume the isolated verification
      output is the normal application build.
- [ ] Record the tested revision or working-tree description: ____________________
- [ ] Choose disposable test records. Cancel edits by default. Saving or otherwise
      changing database records requires separate authorization for the confirmed
      test environment; this checklist grants none.

### Steps to repeat on each applicable screen

1. Load an existing record in view mode. Check that numbers are readable and
   protected fields cannot be edited.
2. Enter Edit mode where permitted. In an ordinary editable numeric field, enter
   an integer such as `500`, then leave the cell. Check the expected format below.
3. Try a valid fractional value, zero, and a negative or blank value only where
   permitted. Check existing validation. Display formatting must not change the
   underlying amount or relax any field restrictions.
4. Add a temporary detail row where supported. Check that newly entered and loaded
   values in the same column use the same format. Remove/cancel the temporary row.
5. Confirm that IDs, sequences, integer counts, and existing explicit formats are
   preserved. Check visible totals for unexpected changes; formatting must not
   change footer/calculation behavior.
6. Cancel edits and reload. Confirm the original record is unchanged.
7. Repeat the applicable checks in Arabic/RTL. Check separators, alignment,
   readable colors, and the same editing restrictions.

For read-only grids, inspect representative loaded values and formats; skip edit
steps and record them as not applicable. Never bypass permissions to perform a test.

### Screen checklist

Mark each box after the corresponding language checks pass. Note unavailable
screens or inapplicable fields in the results log rather than marking them passed.

| Screen or flow | Main expected display | English | Arabic/RTL |
| --- | --- | --- | --- |
| Employee Entry: Earnings | Rate remains `500.0000`; existing money formats remain | [ ] | [ ] |
| Employee Entry: Leave Credits | Allowed leave, paid percent, carryover, maximum and accumulated leave use two decimals | [ ] | [ ] |
| Employee Leave Earned Approval | Days earned remains an integer | [ ] | [ ] |
| Payroll Entry | Unformatted attendance/overtime fields use four decimals; Days Present keeps its existing two-decimal format | [ ] | [ ] |
| Distribution Scheme Entry | Percentage uses two decimals | [ ] | [ ] |
| Pay Element Entry | Factor value uses four decimals | [ ] | [ ] |
| Inventory Selector | On-hand quantity and unit cost use four decimals | [ ] | [ ] |
| Inventory Transaction Entry | Quantity and unit cost use four decimals | [ ] | [ ] |
| Inventory Request | On-hand, supplied and approved quantities use four decimals | [ ] | [ ] |
| Purchase Order Approval | On-hand, supplied and approved quantities use four decimals | [ ] | [ ] |
| Purchase Entry, including history | Quantities use four decimals; unit sales price uses two; existing explicit unit-cost format remains; unit count stays integer | [ ] | [ ] |
| Sale Entry | Quantity uses four decimals; existing explicit unit-cost/money formats remain; unit count stays integer | [ ] | [ ] |
| General Journal | Existing debit/credit precision remains; previously unformatted monetary fields follow configured currency precision | [ ] | [ ] |
| AP Journal | Same monetary-format expectations | [ ] | [ ] |
| AR Journal | Same monetary-format expectations | [ ] | [ ] |
| ER Journal | Same monetary-format expectations | [ ] | [ ] |
| Cash Receipt Journal, including invoice allocations | Same monetary-format expectations | [ ] | [ ] |
| Cash Disbursement / CdJournal, including invoice allocations | Same monetary-format expectations | [ ] | [ ] |
| Petty Cash / PcJournal | Uses Disbursement Journal Entry; check its monetary fields and protections | [ ] | [ ] |
| Sales Journal | Existing debit/credit and other explicit money formats remain | [ ] | [ ] |
| External lab sample grids, if available | Unknown-scale decimal values retain meaningful precision; stored trailing zeros do not cause inconsistent display; explicit formats remain | [ ] | [ ] |

No separate compiled Purchase Journal entry form was found during the audit;
Purchase Entry is covered above. If a different active purchase-journal screen is
identified later, verify its project inclusion and add it to this checklist.

### Accounting-state checks

Using existing test records and authorized operations only:

- [ ] Posted records retain their existing editing restrictions.
- [ ] Approved records retain their existing approval/security restrictions.
- [ ] Closed-period records remain protected.
- [ ] Reconciled lines remain protected.
- [ ] An existing balanced journal still displays matching debit/credit totals.
- [ ] The current user's view/edit permissions remain enforced.

### Results and resumption log

Do not include patient/employee personal data, credentials, or connection strings.

| Date | Screen/check | Language | Result: pass/fail/not applicable | Observation or follow-up |
| --- | --- | --- | --- | --- |
| | | | | |

Next unchecked screen/check: ____________________

- [ ] All applicable checks completed; skipped checks and reasons recorded.
- [ ] Any failures recorded with reproduction steps and resolved or explicitly
      accepted by the user before this suite is closed.

Completing this checklist does not authorize a commit, deployment, SQL execution,
database publication, or production data changes. Other development may continue
while this suite is pending; recheck any affected screens against the latest build.

## SMOKE-BASE-002: control and base-form fixes

**Status: pending manual testing. Implementation and isolated checks completed
on 2026-10-20.** This suite covers the next five improvements, separate from the
earlier smoke tests the user reported as passed.

To resume in this or a new repository conversation, say:

> Resume SMOKE-BASE-002 from docs/Pending-Smoke-Tests.md. Check the latest code and
> build, then guide me through these five base-class smoke tests one at a time.

Use the same confirmed non-production environment, current-build, disposable-record,
and cancel-edit preparation described in SMOKE-NUMERIC-001. Record language and
environment coverage; do not mark untested cases passed.

### Implementation and isolated verification

| Fix | Source files | Focused verification completed |
| --- | --- | --- |
| 1. Preserve text-column search metadata and styles, and checkbox-cell `AlwaysEditable`, when cloning | `CDgvTextColumn.vb`, `CDgvCheckboxCell.vb` | 64 cloning checks, including independent styles/templates and LTR/RTL |
| 2. Dispose replaced masked-text menu items and the control-owned menu | `CMaskedTextBox.vb` | 243 lifecycle checks across repeated menu openings; caller-owned menus preserved |
| 3. Dispose intermediate images and encoding resources, including failure paths | `ImageResizer.vb` | 29 regression/failure checks; BMP/JPG/PNG/GIF/TIFF outputs byte-for-byte identical to pre-change baselines |
| 4. Construct subform presenters once | `BFMain.vb` | 12 checks covering both affected overloads, constructor count, arguments and presenter assignment; no windows shown |
| 5. Guard grid edit/validation helpers when selection is missing | `BFMain.vb` | 36 checks covering null/empty/disposed inputs, valid events, binding resets and a subscriber clearing selection |

Focused builds of CBaseControlsLibrary, HelperLibraries and Forms passed. The
final Accounts Debug build also passed in an isolated verification folder, with
the existing Crystal Reports interop warnings. The 98 earlier control-regression
assertions also passed against the updated shared controls. The isolated checks
used no database and do not establish application-workflow results.

### Remaining manual checks

- [ ] **Text/checkbox grids:** load an existing record, add/cancel a temporary
      detail row, and check column styles and normal view/edit restrictions.
      Where column search is available, check its field selection, matching mode
      and case handling. Check a checkbox-based approval/selection screen without
      approving or saving anything; existing restrictions must still apply.
- [ ] **Masked-text menus:** on a date or other masked field, open/close its menu
      repeatedly. Check captions, shortcut keys, selection-dependent actions and
      view-mode restrictions. Close and reopen the form without errors or stale
      menu behavior. Do not change clipboard contents merely to perform this test.
- [ ] **Picture resizing:** using disposable image files, select several larger
      BMP/JPG/PNG/GIF/TIFF images where supported, then a corrupt file. Check that
      successful images look as before, failures retain the current picture, and
      selected source files can be renamed afterward. Cancel the record changes.
- [ ] **Payroll subforms:** open Payroll Detail and Employee Absence from Payroll
      Entry, one at a time. Check the correct payroll context and that a single
      window opens with normal data and navigation. Close/reopen each and check
      for duplicate dialogs, event effects or initialization errors. Do not post,
      generate, approve, or save payroll data as part of this check.
- [ ] **Grid selection/reset handling:** in a suitable entry screen, exercise an
      empty result, a temporary new row, cancelled edits, and a search/filter or
      record change that clears selection. No selection-related exception should
      occur. A normal valid edit must still trigger its usual calculation/lookup
      behavior. Cancel all edits and confirm the original record is unchanged.
- [ ] Repeat applicable display, menu, search and editing checks in Arabic/RTL.
- [ ] Confirm existing permissions and posted/approved/closed-period/reconciled
      protections remain enforced where the tested screens support them.

| Date | Fix/screen | Language | Result: pass/fail/not applicable | Observation or next step |
| --- | --- | --- | --- | --- |
| | | | | |

Next unchecked fix/screen: ____________________

- [ ] All applicable manual checks completed; failures and skipped checks recorded.

This suite is not authorization to commit, deploy, execute SQL, or change database
records. Continue other development as needed and test the latest relevant build
when returning to this checklist.


## SMOKE-BASE-003: checkbox/date columns and validation collection

**Status: pending; recorded for later manual testing on 2026-10-20.**

To resume, say: **"Resume SMOKE-BASE-003 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database. Cancel edits unless saving test data is
explicitly authorized. Run the relevant checks in English and Arabic/RTL.

### Deferred application checks

1. Open Employee Maintenance, find an existing employee, and enter edit mode.
   On Leave Credits, check the Cumulative and No Max Limit checkboxes. Confirm
   their appearance and editable/read-only behavior match the form's mode and
   existing permissions. Cancel, reload, and confirm the original values remain.
2. On Documents, inspect Issue Date and Expiry Date. Enter a valid test date,
   leave the cell, and confirm its displayed format and colors. Cancel and reload.
   Verify the date cells remain read-only in view mode and that keyboard navigation
   and the date editor still work in edit mode.
3. If the Prescription form is available in this installation, check Print Label
   and Label Printed behavior. Confirm the established AlwaysEditable behavior
   and permissions still apply. Do not print or invoke external label devices.
4. On an entry form with a known required field, start a new record, leave that
   field empty, and attempt validation. Confirm the expected error appears and
   prevents saving. Correct the value, confirm the error clears, then cancel.
5. Record the build/version, form names, language, database environment, results,
   and any screenshots. Keep this suite pending until these checks are completed.

### Implementation checks already performed

- The three changed source files are included in CBaseControlsLibrary.vbproj.
- 206 database-free assertions passed for checkbox-column settings, find/security
  metadata, independent cloned styles/templates, date-column styles/read-only
  state, accepted date-cell subclasses, rejected incompatible templates, and
  validation collection replacement/getter/error behavior. Clone checks cover
  both LTR and RTL settings.
- CBaseControlsLibrary Debug and the isolated Accounts Debug build passed.
  Accounts reported nine existing Crystal Reports interop warnings and no errors.
- 64 earlier clone checks and 98 earlier control regression checks passed.
- Null and unregistered control replacements now throw explicit argument errors
  without changing the validation collection. Registered replacements and the
  existing getter fallback are preserved. This does not change validation rules.
- No application was started and no database was accessed by these checks.
- These fixes have not been deployed. ClickOnce 1.0.0.43 contains the preceding
  batch, not these changes.
