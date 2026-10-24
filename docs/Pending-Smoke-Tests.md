# Pending smoke tests

Last updated: 2026-10-24.

Pending suites:

- [SMOKE-NUMERIC-001: numeric grid display](#smoke-numeric-001-system-wide-numeric-grid-display)
- [SMOKE-BASE-002: control and base-form fixes](#smoke-base-002-control-and-base-form-fixes)
- [SMOKE-BASE-003: checkbox/date columns and validation collection](#smoke-base-003-checkboxdate-columns-and-validation-collection)
- [SMOKE-BASE-004: repeated validation-event setup](#smoke-base-004-repeated-validation-event-setup)
- [SMOKE-BASE-005: accepted and canceled form closing](#smoke-base-005-accepted-and-canceled-form-closing)
- [SMOKE-BASE-006: binding diagnostics and error-provider ownership](#smoke-base-006-binding-diagnostics-and-error-provider-ownership)
- [SMOKE-BASE-007: form-close cleanup and neutral language fallback](#smoke-base-007-form-close-cleanup-and-neutral-language-fallback)
- [SMOKE-BASE-008: validation control descriptions](#smoke-base-008-validation-control-descriptions)
- [SMOKE-BASE-009: RTL sort-key translation](#smoke-base-009-rtl-sort-key-translation)
- [SMOKE-BASE-010: shared double-buffering helper](#smoke-base-010-shared-double-buffering-helper)
- [SMOKE-BASE-011: culture-independent validation-name matching](#smoke-base-011-culture-independent-validation-name-matching)
- [SMOKE-BASE-012: Arabic autofill and numeric validation](#smoke-base-012-arabic-autofill-and-numeric-validation)
- [SMOKE-BASE-013: Pay Element Entry display updates](#smoke-base-013-pay-element-entry-display-updates)
- [SMOKE-BASE-014: Pay Element focus and quantity handler](#smoke-base-014-pay-element-focus-and-quantity-handler)
- [SMOKE-BASE-015: Summary means Computed](#smoke-base-015-summary-means-computed)
- [SMOKE-BASE-016: English form display shortcuts](#smoke-base-016-english-form-display-shortcuts)
- [SMOKE-BASE-017: Tree selection preserves record identity](#smoke-base-017-tree-selection-preserves-record-identity)
- [SMOKE-BASE-018: Scoped fast-layout control list](#smoke-base-018-scoped-fast-layout-control-list)
- [SMOKE-BASE-019: Lookup reuse during language refresh](#smoke-base-019-lookup-reuse-during-language-refresh)

Git batch 2026-10-24: suites SMOKE-BASE-015 through SMOKE-BASE-019 accompany
the Summary, language-display, tree-selection, layout, and lookup fixes in this
commit. Earlier uncommitted/unpushed statements below describe their implementation
time. Manual testing remains pending; this Git batch does not deploy ClickOnce.

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
- Deployment history: these three fixes were deployed in ClickOnce 1.0.0.44.
  Their manual smoke tests remain pending.


## SMOKE-BASE-004: repeated validation-event setup

**Status: pending; recorded for later manual testing on 2026-10-20.**

To resume, say: **"Resume SMOKE-BASE-004 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database and cancel edits. Repeat relevant checks
in English and Arabic/RTL. Do not deploy or save production records for this test.

### Scope and implementation evidence

- ErrorProviderExtended.SetErrorEvents now removes its matching Validating handler
  before adding it. Repeated setup and duplicate control entries leave one handler
  per provider/control. Validation_Event and validation rules were not changed.
- No direct application call to SetErrorEvents was found in the searched shared
  libraries, presentation, Accounts, and Common VB source. The defect was reproduced
  in isolation; a routine form check alone cannot prove repeated setup was exercised.
- The pre-fix compiled assembly reproduced two subscriptions after two setup calls.
- 41 focused checks passed for repeated setup (including 20 further calls), duplicate
  entries, newly added controls, unregistered controls, independent providers,
  unrelated event handlers, cancellation preservation, disabled validation, empty
  input errors, valid-input error clearing, and an empty collection. Checks used
  WinForms controls in LTR and RTL without application startup or database access.
- The preceding 206 checkbox/date/validation collection regression assertions passed.
- CBaseControlsLibrary Debug and the isolated Accounts Debug builds passed. Accounts
  reported nine existing Crystal interop warnings and one transient parallel-output
  copy warning; the copy retry succeeded. No build errors remained.
- This fix has not been deployed. It is not in ClickOnce 1.0.0.44. The subsequent
  form-closing fix is recorded in SMOKE-BASE-005.

### Deferred manual checks

1. On an entry form with a known required field, enter add/edit mode, leave that
   field empty, and invoke normal validation. Confirm the expected message/icon
   appears and the existing save restrictions still apply.
2. Correct the field and validate again. Confirm the error clears as before.
   Cancel, reopen the form, and repeat to check ordinary form lifecycle behavior.
3. Record the form, language, environment, build/commit, and actual results.
4. If an actual SetErrorEvents caller is identified later, additionally exercise
   its initialization/reinitialization path. In a debugger, confirm one
   Validation_Event invocation per field event after repeated setup. Until then,
   treat this as an isolated subscription fix with supporting form regression checks.


## SMOKE-BASE-005: accepted and canceled form closing

**Status: pending; recorded for later manual testing on 2026-10-20.**

To resume, say: **"Resume SMOKE-BASE-005 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database. Do not save test transactions or invoke
production shutdown, posting, printing, or database operations for these checks.
Repeat relevant checks in English and Arabic/RTL.

### Scope and checks already performed

- CFormEntry and CFormBase are included in the active Forms project. Their existing
  final cleanup now runs on FormClosed rather than FormClosing. The cleanup body,
  Quit notification, CancelClose decision, and presenter behavior are unchanged.
  This does not add an unsaved-changes prompt where one does not already exist.
- The pre-fix compiled assembly reproduced disposal during canceled closing in
  20 isolated cases across both bases and LTR/RTL settings.
- 128 checks passed using instantiated base-form subclasses, with application
  Load/Shown handlers suppressed to prevent database/workflow initialization.
  Checks cover preserved input and usable controls after cancellation, legacy
  CancelClose, delayed disposal until FormClosed, and owned-control disposal.
- Actual hidden-form Close calls verified cancellation by a later event subscriber
  and subsequent accepted closing. Modal dialogs verified a canceled first attempt,
  an accepted second attempt, preserved DialogResult.OK, and disposal. Actual MDI
  parent/child close checks verified cancellation and accepted disposal of both.
- Event-dispatch checks covered UserClosing, MdiFormClosing, ApplicationExitCall,
  WindowsShutDown, and FormOwnerClosing reasons. Real application exit and operating
  system shutdown were not performed; those reason checks were simulated.
- The earlier #4 validation-event suite passed again (41 checks).
- The focused Forms Debug build and isolated Accounts Debug build passed. Accounts
  reported nine existing Crystal interop warnings and no errors.
- No Accounts application workflow or database was started. This fix has not been
  deployed; it is not in ClickOnce 1.0.0.44.

### Deferred application checks

1. Open Employee Maintenance, load a record, enter edit mode, and change a harmless
   field without saving. If the existing workflow provides a canceled-close/keep-
   editing choice, exercise it using X and Alt+F4. Confirm the form stays open,
   entered values remain, and controls/navigation still work. If no such choice
   exists, record that cancellation is not exposed on that screen; do not assume
   this fix introduces it or intentionally discard valuable edits.
2. Cancel test edits, close normally with no pending changes, and reopen the form.
   Repeat for a tree-entry screen and a screen inheriting CFormBase. Confirm normal
   closing completes and reopening does not report disposed-control errors.
3. On the test installation, check relevant journal header/detail screens:
   GeneralJournal, ApJournal, ArJournal, ErJournal, CashReceiptJournal, CdJournal,
   SalesJournal, PurchaseJournal, and PcJournal. Exercise existing cancellation
   paths where available, then discard test edits and close/reopen. Existing posted,
   approved, closed-period, and reconciled protections must remain unchanged; no
   transaction state or accounting data should be changed for this test.
4. Exercise an existing modal entry dialog if available. Confirm its accepted and
   canceled results still reach its caller correctly. Close an MDI parent with a
   child open and verify existing child cancellation is respected where provided.
5. With no valuable edits pending, close the test application normally and restart.
   Record forms, languages, build/commit, database environment, actual results,
   and any cancellation paths that could not be exercised.


## SMOKE-BASE-006: binding diagnostics and error-provider ownership

**Status: pending; recorded for later manual testing on 2026-10-21.**

To resume, say: **"Resume SMOKE-BASE-006 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database and cancel test edits. Repeat relevant
checks in English and Arabic/RTL. Do not deliberately break a database connection
or save invalid production records to provoke an exception.

### Scope and checks already performed

- CFormEntry now captures the first deferred-binding failure with
  ExceptionDispatchInfo and rethrows it after attempting the remaining bindings.
  Original exception identity and failing-method stack frames are preserved.
  Binding order, first-error selection, and clearing of pending callbacks remain
  unchanged. This improves diagnostics rather than normal-path performance.
- Both BFMain constructors register the provider they create with the existing
  component container. The original public field and presenter access are retained;
  the designer-generated Dispose method already disposes that container.
- 44 focused binding assertions passed across success, first failure, second
  failure, multiple failures, original stack frames, exception identity, queue
  clearing, no repeat execution, and LTR/RTL settings. The pre-fix assembly
  reproduced loss of the original failing-method frame.
- 86 provider assertions passed across both BFMain constructors and CFormEntry,
  CFormBase, and CFormEntryTv, in LTR/RTL settings. These covered container ownership,
  provider identity, existing error display/clearing, disposal, repeated form
  disposal, and replacing the public provider field with a borrowed provider.
  The original owned component is still cleaned up; the borrowed component is
  left to its owner. The pre-fix assembly reproduced missing ownership/disposal.
- 128 earlier form-closing checks and 41 validation-event checks passed again.
- The focused Forms Debug build and isolated Accounts Debug build passed. Accounts
  reported nine existing Crystal interop warnings and no errors.
- Checks used isolated forms/controls with application initialization suppressed;
  no Accounts workflow or database was started. Synthetic modal/MDI windows were
  used by the closing regression harness.
- These changes have not been deployed. They are not part of ClickOnce 1.0.0.45.
  Manual suites above remain pending independently.

### Deferred application checks

1. Open Employee Maintenance, load/find a record, and navigate among its detail
   tabs. Confirm grid and lookup binding still displays expected values. Repeat
   on a tree-entry screen. Cancel any edits.
2. On a form with a known required field, invoke its normal validation with that
   field empty. Confirm the usual error appears. Correct the field and confirm
   the error clears, then cancel and close without saving.
3. Reopen, validate, and close those forms several times. Confirm no disposed-
   provider/control errors appear. Exercise existing canceled-close behavior where
   available, confirming the still-open form can continue displaying errors.
4. As a developer-only diagnostic check, if a genuine binding error is reproduced
   on the test installation, verify the original binding method appears in the
   exception stack. Do not manufacture a live-data failure just for this check.
5. Record build/commit, forms, language, database environment, and actual results.


## SMOKE-BASE-007: form-close cleanup and neutral language fallback

**Status: pending; recorded for later manual testing on 2026-10-21.**

To resume, say: **"Resume SMOKE-BASE-007 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database, cancel test edits, and repeat relevant
checks in English and Arabic/RTL. Do not change production connection settings
or perform an operating-system shutdown for these tests.

### Scope and checks already performed

- CFormEntry and CFormBase retain FormClosed cleanup, culture restoration, and
  Dispose, but no longer force GC.Collect, wait for pending finalizers, or trim
  the entire process working set. The now-unused private native declarations
  were removed. This is not a measured speedup or proof of stable long-term memory.
- BFMain's two fallback methods share a base-language extractor. Regional/script
  codes retain the part before the first hyphen; neutral codes use the whole
  value. Missing/blank input returns no fallback (ID 0/message Nothing) without
  accessing TranslatorDAC. An empty prefix such as -SA also returns no fallback.
- Existing translation query text, lookup order, and language-code casing were
  preserved. There are no database object/script changes and no SQL was executed.
- 114 focused assertions passed for neutral, regional, script, case-preserving,
  and missing-input cases in LTR/RTL settings. The pre-fix assembly reproduced
  neutral-code exceptions in both lookup methods (12 cases). Lookup execution
  used the DAC's design-time bypass; no database results were tested.
- 128 form-closing, 86 provider-ownership, and 44 binding-diagnostic assertions
  passed again. These include disposal on accepted close, cancellation, modal
  results, and MDI parent/child behavior in isolated forms.
- The focused Forms Debug build and isolated Accounts Debug build passed. Accounts
  reported nine existing Crystal interop warnings and no errors.
- The preceding SMOKE-BASE-006 changes were preserved. Neither suite's new changes
  have been deployed; they are not in ClickOnce 1.0.0.45.

### Deferred application checks

1. Open, close, and reopen Employee Maintenance, a tree-entry screen, and an entry
   screen using CFormBase several times. Confirm normal closing completes and
   canceled closing, where available, preserves the form. Check for unexpected
   pauses; do not treat a different Task Manager memory figure alone as a defect.
2. Check an existing modal dialog and MDI child close path. Confirm expected
   dialog results and parent/child closing behavior. Discard test edits.
3. Check normal en-PH and ar-SA display, switching languages through the existing
   supported UI. Confirm captions, menu items, and RTL layout remain correct.
4. As a developer-assisted test on the test installation, invoke fallback with
   neutral en/ar and the corresponding regional code where translation data exists.
   Confirm the same base-language lookup is used and no substring exception occurs.
   Do not rewrite live application settings just to expose a neutral culture.
5. Record build/commit, forms, language, environment, and results. Compare repeated
   open/close responsiveness and memory behavior under comparable workloads if
   assessing performance; no benchmark improvement has yet been claimed.


## SMOKE-BASE-008: validation control descriptions

**Status: pending; recorded for later manual testing on 2026-10-21.**

To resume, say: **"Resume SMOKE-BASE-008 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database and cancel test edits. Repeat relevant
checks in English and Arabic/RTL. Do not save production records for this test.

### Scope and checks already performed

- The active Presenters project includes PresenterBase.vb. ControlDescription now
  removes the conventional three-character prefix with Substring(3) when the name
  is long enough, preserves short names, and returns the control type name for
  an unnamed control. A missing control throws ArgumentNullException("control").
- The public method's return signature and linked-label description path remain
  unchanged. No validation rules, permissions, values, sorting, or database code
  were modified. Deriving a name does not add a translated/polished caption; the
  existing linked label remains the preferred description source.
- The pre-fix compiled assembly reproduced FormatException for txtAmount in LTR
  and RTL settings. The fixed build passed 62 assertions for prefix removal,
  short/empty names, linked English/Arabic/missing descriptions, null input,
  linked-provider call count, and unchanged control names and text values.
- Checks used an uninitialized test presenter to avoid constructor workflows;
  no Accounts application startup or database access occurred.
- Presenters Debug and the isolated Accounts Debug builds passed. Accounts reported
  nine existing Crystal interop warnings and four transient parallel-output copy
  warnings; retries succeeded and no build errors remained.
- Manual testing remains pending. The isolated checks above do not establish
  application-level validation coverage.

### Deferred application checks

1. On a test entry screen, exercise normal required-field or numeric validation
   for a control with a linked label. Confirm the existing English/Arabic field
   description still appears and clears after correction. Cancel edits.
2. With developer assistance, identify a validation path that calls this helper
   for a control without ILinkedLabel. Confirm a name such as txtAmount produces
   Amount rather than a conversion exception. Do not infer fallback coverage from
   testing only the custom controls that use linked labels.
3. Record build/commit, forms/controls, language, environment, and actual results.


## SMOKE-BASE-009: RTL sort-key translation

**Status: pending; recorded for later manual testing on 2026-10-21.**

To resume, say: **"Resume SMOKE-BASE-009 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database, cancel test edits, and check English
and Arabic/RTL. Do not save transactions or change production sort metadata.

### Scope and checks already performed

- The active PresenterBase now translates only the supplied single-field sort key.
  GetTranslatedSortOrderKey delegates to GetTranslatedField, removing the duplicate
  parsing that could substitute the presenter's stored SortOrderKey.
- Trailing ASC and DESC are recognized with ordinal case-insensitive comparisons;
  the requested suffix spelling/direction is retained. In RTL, the field gains
  Ara only when the model exposes that property. English/designer mode, missing
  Arabic properties, already translated fields, and null/blank keys are preserved.
  Short keys no longer cause negative substring positions.
- This remains a single-field translator. Compound expressions, bracketed fields,
  unsupported DES tokens, and trailing-whitespace expressions are not newly parsed.
  No SQL/database object files were changed and no SQL was executed.
- The pre-fix assembly reproduced three cases: a supplied Name key replaced by
  AlternateAra ASC from the stored key, Name DESC failing to use NameAra, and a
  short key throwing ArgumentOutOfRangeException.
- 660 isolated assertions passed across both helpers, LTR/RTL/designer mode,
  ascending/descending and mixed-case directions, differing stored keys (including
  short/empty/null), missing Arabic properties, already translated fields, short
  fields, null/blank keys, and preserved compound/unsupported expressions. The
  stored presenter key is not mutated. Presenter construction and DB access were
  bypassed; these checks did not exercise real database ordering/navigation.
- The preceding control-description change was preserved and its 62 checks passed.
- Presenters Debug and the isolated Accounts Debug builds passed. Accounts reported
  nine existing Crystal interop warnings and one transient parallel-output copy
  warning; its retry succeeded and no build errors remained.
- Manual testing remains pending. Other pending suites remain independent.

### Deferred application checks

1. On an existing entry/tree screen in English, load/find records and use first,
   previous, next, and last navigation. Confirm ordering and displayed positions
   remain correct. Repeat in Arabic/RTL using records with distinct Arabic names.
2. On the test installation, exercise a lookup that supplies its own sort key,
   such as a Deposit Type lookup using AccountsPresenter.GetDepositTypeModel.
   Confirm it follows the lookup field rather than the main form's default field.
3. With developer assistance, exercise a supported single-field sort in ASC and
   DESC on a model with an Ara property. Confirm RTL uses that property's ordering
   and English uses the original field. Check record position/find behavior too.
4. Check an ID/numeric field or another field without an Arabic counterpart. Its
   requested field/direction must remain intact. Confirm normal empty/default-sort
   callers still load correctly, including caption/message lists where available.
5. Record build/commit, forms, supplied/stored sort keys, language, environment,
   and actual results. Cancel edits; do not alter accounting states for this test.


## SMOKE-BASE-010: shared double-buffering helper

**Status: pending; recorded for later manual testing on 2026-10-21.**

To resume, say: **"Resume SMOKE-BASE-010 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database and repeat relevant checks in English and
Arabic/RTL. Do not print or save transactions for these repaint/layout checks.

### Scope and checks already performed

- BFMain.EnableDoubleBuff now caches the Control.DoubleBuffered property metadata
  in a private shared read-only field, following the existing CFormEntryTv pattern.
  It checks the control and metadata for Nothing before enabling the property.
  Existing callers and the separate tree-form implementation are unchanged.
- 25 isolated smoke assertions passed for Panel, TableLayoutPanel, and
  FlowLayoutPanel in LTR/RTL, including enabling the property, repeated calls,
  no changes to name/text/bounds/direction, and a missing control. No application
  forms were shown and no database was accessed.
- Forms Debug and the isolated Accounts Debug build passed. Accounts reported nine
  existing Crystal interop warnings and no errors.
- This removes repeated reflection work; no measurable speed or flicker reduction
  is claimed. Double buffering is still enabled only where existing callers use it.
- The preceding control-description and RTL sorting changes were preserved.
  Manual testing remains pending independently for all three changes.

### Deferred application checks

1. Open Check Printer, Disbursement Journal Entry, and PC Closing Entry in the test
   installation. Resize the windows and move between existing fields/tabs. Confirm
   layout and repainting remain normal. Do not print or change accounting states.
2. Repeat in Arabic/RTL, checking that direction, captions, and control positions
   remain correct. Close and reopen the screens, canceling test edits.
3. Record build/commit, forms, language, environment, and actual results. Treat a
   speed/flicker claim as unverified unless compared under the same workload.


## SMOKE-BASE-011: culture-independent validation-name matching

**Status: pending; recorded for later manual testing on 2026-10-22.**

To resume, say: **"Resume SMOKE-BASE-011 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database and cancel test edits. Check English and
Arabic/RTL. Do not change production workstation culture settings for this test.

### Scope and checks already performed

- ValidationControlCollection.GetIndex now compares names with String.Equals and
  OrdinalIgnoreCase rather than uppercasing both names using the current culture.
  It retains sequential first-match lookup and avoids uppercase-string allocations.
  Numeric value parsing, captions, validation rules, and Arabic autofill were not
  changed. This is identifier comparison, not language-aware display sorting.
- The pre-fix assembly matched Id/id in en-US and ar-SA but failed in tr-TR.
- 42 isolated assertions passed across en-US, ar-SA, and tr-TR for ASCII case
  matching, Arabic identifiers, missing/null names, distinct dotted/dotless-I
  identifiers, object-indexer get/set, first-match duplicate behavior, removal,
  and unchanged control names. No application or database was started.
- The existing 41 validation-event checks passed again, including error display,
  clearing, disabled validation, unrelated handlers, and independent providers.
- CBaseControlsLibrary Debug and the isolated Accounts Debug build passed. Accounts
  reported nine existing Crystal interop warnings and no errors.
- Included in the base-validation and Pay Element fixes Git batch. It has not
  been deployed and is not in ClickOnce 1.0.0.47. Manual suites remain pending.

### Deferred application checks

1. On a test entry form with required/numeric validation, leave a known required
   field empty and invoke normal validation. Confirm the expected field error
   appears, then correct the value and confirm it clears. Cancel edits.
2. Repeat in English and Arabic/RTL. Confirm existing captions, validation rules,
   control values, and save restrictions remain as before.
3. If a Turkish-culture workstation is actually supported, perform the same test
   there or in an isolated test process. Do not change a live workstation's culture
   just to exercise this case. Record forms, build/commit, culture, environment,
   and actual results.


## SMOKE-BASE-012: Arabic autofill and numeric validation

**Status: pending; recorded for later manual testing on 2026-10-22.**

To resume, say: **"Resume SMOKE-BASE-012 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database and cancel edits. Test English and
Arabic/RTL without changing production data, connection settings, or accounting
states. Do not infer manual validation coverage from successful compilation.

### Scope and checks already performed

- PresenterBase.UpdateArabicControl now requires AutoFill=True for both existing
  replacement cases (empty Arabic field or one matching the original English).
  AutoFill=False preserves the field; distinct manually translated text remains
  unchanged when autofill is enabled. English source controls are not modified.
- CTextBox has a runtime-Type TryGetValue overload delegating to its existing
  TryCalculateValue parser. The generic API, parsing policies, and legacy GetValue
  fallback remain intact. Both changed source files are in their active projects.
- PresenterBase.IsNumberValid uses the typed parsing result, not IsNumeric/Val.
  Integer/decimal type limits are enforced by existing TryParse routines; their
  control-bound comparisons use Decimal without Double rounding. Single/Double
  checks use their corresponding representation and reject NaN/infinity. Numeric
  fields exposed through nonnumeric properties retain floating-point validation.
- Parsing follows CultureInfo.CurrentCulture, matching the existing textbox getter:
  NumberStyles.Number for integers/Decimal and Float+AllowThousands for Single/Double.
  Inputs previously accepted only by IsNumeric but rejected by the actual getter
  are now rejected (for example exponent syntax in an integer field). No currency,
  hexadecimal, or additional input syntax was introduced. Blank input still passes
  this helper; separate required-field rules remain responsible for mandatory data.
- Fractional integer input uses MsgInvalidInteger; failed typed conversions/type
  overflow use MsgInvalidNumericValue; configured control-range violations use
  MsgNumericOverflow. A missing min/max bound is handled safely when formatting
  an error. Message keys were tested; rendered/translations require manual testing.
- 196 focused assertions passed for enabled/disabled autofill, preservation of
  manual text, grouped values, signed/unsigned type limits, nullable fields,
  fractional integers, exact Decimal bounds beyond Double precision, Single/Double
  limits and exponent syntax, finite values, one-sided bounds, blank/invalid input,
  numeric-string properties, generic/runtime parser compatibility, and en-US,
  ar-SA, de-DE, and tr-TR numeric cultures. The pre-fix build reproduced the autofill
  overwrite and acceptance of 1,000 with a maximum of 100.
- The earlier 42 culture-independent lookup and 41 validation-event checks passed
  again. Tests bypassed presenter construction and ran the DAC in design-time mode;
  no database connection/command was initialized and no SQL was executed.
- CBaseControlsLibrary/Presenters Debug and the isolated Accounts Debug build passed;
  Accounts reported nine existing Crystal interop warnings and no errors.
- The preceding SMOKE-BASE-011 change was preserved. Included in the base-validation
  and Pay Element fixes Git batch; not deployed or in ClickOnce 1.0.0.47.

### Deferred application checks

1. On caption/message translation forms where AutoFill=False, use test records whose
   translation equals the original English text. Change the English value, invoke
   the normal validation path, and confirm the translation is preserved. Cancel.
2. On an entry form with enabled Arabic autofill, check empty, unchanged-English-copy,
   and distinct Arabic-text cases. Only the existing enabled replacement cases
   should copy English. Cancel all edits and repeat under English and Arabic/RTL.
3. On appropriate numeric fields, exercise grouping and decimal separators supported
   by the active input culture. For a known maximum of 100, input equivalent to 1,000
   must fail, while 100 succeeds. Check minimum/maximum boundaries and error text.
4. Check integer fields reject nonzero fractional parts/type overflow, decimal fields
   retain expected precision, nullable blanks keep their normal behavior, and
   required fields still reject missing values through existing mandatory rules.
5. Check fields with only one configured bound and confirm a readable validation
   message appears. Correct rejected values and confirm existing error clearing and
   normal validation/save behavior. Do not save accounting test records unless that
   test environment and operation are separately authorized.
6. Record build/commit, forms/fields, input culture, language, environment, and results.
   No journal posting, approval, closed-period, or reconciliation rules were changed.

## SMOKE-BASE-013: Pay Element Entry display updates

Status: PENDING manual testing. Recorded 2026-10-22.

To resume, say: **"Resume SMOKE-BASE-013 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database and cancel edits. Repeat in English and
Arabic/RTL. Included in the base-validation and Pay Element fixes Git batch;
not deployed or included in ClickOnce 1.0.0.47.

### Implemented and checked

- PayElementEntryTv keeps both child grids connected to their BindingSources.
  Binding no longer clears a populated source first or forces three Refresh calls
  per grid. Same-reference lists use ResetBindings(False), preserving notification
  after additions/removals to the existing plain List collections. Replacement,
  empty, and null lists retain their binding behavior; Items retains AllowNew=True.
- Calculation-panel updates suspend layout on the flow/table containers and resume
  both through Finally. Updates no longer hide/show the parents unconditionally,
  and the Unit control moves only when its table position needs to change.
  Calculation and Summary value-assignment rules were preserved.
- Isolated fixture comparison passed 144 assertions on the changed build and 103
  baseline assertions. Forty final-state scenarios matched the previous build
  (five calculation codes, two quantity codes, Summary on/off, LTR/RTL). The checks
  compared field visibility, text, and Unit position and verified selections were
  preserved. Repeated updates caused zero parent visibility transitions versus
  eight across the two baseline fixtures. Each grid binder issued zero explicit
  Refresh calls versus three before; same-list mutations remained visible.
- Accounts Debug build passed with nine existing Crystal interop warnings and no
  errors. Tests bypassed the form/service constructors and used in-memory data;
  no database was accessed. This does not establish live-screen flicker elimination,
  full language translation, designer layout, or interactive editing behavior.

### Deferred application checks

1. Open Pay Element Entry, navigate between earning/deduction records, including
   records with populated and empty posting-account and Summary detail grids.
   Confirm rows, account/pay-group/pay-element/factor dropdown captions, and numeric
   formatting remain correct, without transient blank grids or binding errors.
2. Enter edit/add mode and exercise supported calculation types and quantity types.
   Confirm Rate, Default Quantity, Factor, Base Payment, and Unit visibility and
   Unit position follow existing rules. Repeat selecting the same option and
   switching tabs; watch for flashing, displaced controls, or lost selections.
3. Exercise Summary and Use Pay Groups on disposable edits. Check expected panel
   visibility and child-grid editing/add-row behavior; cancel and reload. Check
   normal permissions and validation. Do not save or run payroll without separately
   authorized test operations.
4. Repeat in English and Arabic/RTL, including language refresh if supported.
   Confirm lookup captions and selected IDs remain correct. Record screen size,
   language, build/commit, test environment, and observed flicker before/after.

### Remaining findings checked, not changed in this batch

1. Lookup columns are still configured on every child-list bind. UpdateReportGroup
   still clears its DataSource before selecting earning/deduction groups, including
   calls from Load, language refresh, and kind changes. Next candidate: configure
   stable column metadata once, replace lookup sources only when necessary, and
   preserve selection; ensure actual language/list refreshes still propagate.
2. Multiple event paths update visuals (calculation selection/validation, tab entry,
   InputsTurnedOn, and Summary). This is potential duplicate work; source inspection
   alone does not prove each user interaction invokes all of them. Consolidating
   visual refreshes must preserve existing value-assignment and mapping order.
3. FirstControl is assigned before InitializeComponent creates txtPayElementCode,
   so that assignment receives Nothing. Move it after initialization in a separate
   focused correction and verify initial/edit-mode keyboard focus.
4. The quantity handler tests cboCalculationType.Focused, passes its SelectedIndex,
   and can reset that calculation dropdown; its helper also compares PayElementType
   against a CalculationType enum code. These are likely copy/paste issues, but the
   permitted calculation/quantity combinations need review before changing rules.
   This handler retains a separate hide/show path outside the corrected display
   method, so some flicker may remain.
5. Summary's property setter assigns Computed, while CheckedChanged assigns OnDemand;
   both assign Factor calculation. The setter/event paths can therefore disagree.
   Confirm the intended Summary pay-element type before unifying the rule.

No SQL source, database contents, payroll calculations, or deployment settings
were changed. Existing unrelated working-tree changes were preserved.


## SMOKE-BASE-014: Pay Element focus and quantity handler

Status: PENDING manual testing. Recorded 2026-10-22.

To resume, say: **"Resume SMOKE-BASE-014 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database, cancel edits, and check English/Arabic RTL.

### Implemented and checked

- Addresses remaining findings 3 and 4 recorded in SMOKE-BASE-013. FirstControl is
  now assigned after InitializeComponent creates txtPayElementCode. Source order
  was checked; live initial/add/edit focus remains a manual test.
- The quantity handler now checks quantity-dropdown focus, validates the selected
  quantity code, and clears that dropdown's SelectedIndex when disallowed. It no
  longer checks/resets the calculation dropdown or forces a separate hide/show
  cycle. Allowed selections use the existing batched calculation-panel update.
- The helper retains the previous effective Regular-pay-element restriction on
  NotNeeded and Variable quantity choices. The former comparison used the unrelated
  CalculationType.FixedRate code, which also equals R; it now uses
  PayElementTypeSelection.Regular explicitly. It does not introduce a FixedRate-calculation restriction.
  Programmatic assignments without quantity focus remain outside this event path.
- 248 isolated assertions passed, covering all 12 quantity codes across four
  pay-element types with reordered rows, quantity/calculation focus guards,
  preservation of allowed selections/calculation type, the prior grid cases,
  and 40 matching display-state scenarios including RTL direction. Repeated parent
  visibility transitions remained zero. Tests bypassed form/service constructors
  and used in-memory data; no database was accessed or application launched.
- Accounts Debug build passed with nine existing Crystal interop warnings and no
  errors. No designer files were changed. Interactive warning-dialog rendering and
  dismissal were not automated; the invalid-selection path requires manual testing.

### Deferred application checks

1. Open Pay Element Entry and enter add/edit mode. Confirm Pay Element Code receives
   focus where enabled and normal tab navigation remains correct. Cancel edits.
2. For Regular elements with the quantity dropdown visible, choose NotNeeded and
   Variable. Confirm the existing warning appears and, after dismissal, only the
   quantity selection is cleared; Calculation Type remains unchanged. Choose a
   permitted quantity and verify it stays selected. Cancel edits.
3. For Computed/OnDemand elements, check Factor with NotNeeded versus a needed
   quantity. Confirm Unit/Default Quantity visibility and placement follow the
   selected calculation; changing quantity must not reset Calculation Type.
4. Change quantity, tab to Calculation Type, leave/re-enter the tab, and repeat.
   Confirm there are no unexpected messages, lost selections, or panel flashes.
   Repeat in English/Arabic RTL and check field names in the validation message.
5. Record build/commit, environment, permitted combinations, and actual results.
   Summary's Computed-versus-OnDemand conflict remains unresolved and unchanged;
   lookup-reset and repeated-event optimization findings remain separate work.

No SQL source or database changes, no payroll execution, and no deployment occurred.
Included in the base-validation and Pay Element fixes Git batch. Manual checks
remain pending; no deployment was requested with the Git push.


## SMOKE-BASE-015: Summary means Computed

Status: PENDING manual testing. Recorded 2026-10-24.

To resume, say: **"Resume SMOKE-BASE-015 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production database. Check English and Arabic/RTL.

### Rule and implementation

- User confirmed: Summary always means Computed. This resolves the type conflict
  previously recorded in SMOKE-BASE-013 and SMOKE-BASE-014.
- PayElementEntryTv uses ApplySummaryDefaults from both the Summary property setter
  and checkbox handler: checked Summary assigns Computed (C) and Factor (F).
  The setter still applies the rule when True is assigned repeatedly without a
  CheckedChanged event. Unchecked Summary does not rewrite ordinary element values.
- AfterUpdateView reapplies the rule after record mapping, so saved type/calculation
  assignments later in the mapping cannot leave a summary with inconsistent values.
  Existing Summary panel visibility behavior is retained. No mapper/DAO/schema or
  payroll calculation algorithm was changed. Existing database rows are not migrated;
  loading normalizes the form, and persistence still requires an ordinary save.
- Isolated checks use in-memory controls, bypass form/service constructors, and
  cover manual/property/repeated assignments, four starting types, post-mapping
  normalization, visibility, non-summary preservation, and LTR/RTL direction.
  Full application mapping/save, translated captions, and payroll amounts remain
  manual checks; no application/database or payroll execution was started.
- 64 focused assertions passed. Accounts Debug build passed with nine existing
  Crystal interop warnings and no errors. Compilation is not a full application test.
- This fix is not committed, pushed, or deployed. Earlier manual suites remain pending.

### Deferred application checks

1. On a disposable test record, check Summary. Confirm Summary details appear and
   calculation/posting/type controls retain their expected visibility. Confirm the
   resulting view values are Computed and Factor using the debugger if hidden.
2. Load Summary records, including a test fixture previously stored as OnDemand,
   and confirm the final view after mapping is Computed/Factor. Navigate away and
   back; repeat entering edit mode. Cancel edits unless a test save is authorized.
3. On an authorized disposable test save, save/reload and verify Summary=True,
   PayElementType=C, CalculationType=F, and unchanged child details/factors.
   Do not mass-update production rows as part of this test.
4. Uncheck Summary and confirm current values are retained for normal editing.
   Load non-summary records of different types and verify their saved type and
   calculation remain intact. Check permissions/validation; cancel edits.
5. Repeat in English/Arabic RTL. In a separately authorized payroll test, compare
   totals for a summary used as a base payment, including nested summaries where
   applicable. No change to the payroll algorithm is expected. Record build/commit,
   environment, records, and actual results.

No SQL source was modified or SQL executed, no database rows were changed, and
nothing was deployed. Unrelated outputs/ content was preserved.


## SMOKE-BASE-016: English form display shortcuts

Status: PENDING manual testing. Recorded 2026-10-24.

To resume, say: **"Resume SMOKE-BASE-016 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production environment. Cancel edits and check English/Arabic RTL.

### Implemented and checked

- BFMain.GetCachedTargetLanguageIdNo returns original-language ID zero before cache
  or database resolution when translation is unnecessary in normal operation.
  Original en-PH always qualifies; other en/en-* targets qualify when the existing
  UseOriginalAppTextLanguageForEnglish setting is enabled. Translation-initializer
  mode deliberately keeps its existing resolution and caption-maintenance path.
- GlobalFunctions.NeedToTranslateText now consistently checks the effective target
  (including explicit targets), ignores culture-code casing/outer whitespace, and
  recognizes neutral en and regional en-* English. English current language no
  longer suppresses an explicitly requested Arabic translation. The English option
  remains respected; no workstation configuration was changed.
- BFMain skips original-caption restoration only on the first original-English
  caption application in normal mode. Original-caption capture, layout, rendering,
  security, culture formatting, and language-switch hooks remain active. Subsequent
  English applications restore original captions, including return from Arabic.
  Non-English fallback and translation-initializer mode retain restoration behavior.
  A translated attempt marks caption state before applying captions, so a later
  English switch also restores originals after a partial translation failure.
- 60 isolated assertions passed for English option on/off, neutral/regional/case/
  whitespace targets, explicit Arabic/English overrides, no-DAC English ID lookup
  with empty cache, initial restoration skip, subsequent restoration, in-memory
  Arabic translation and English restoration of title/label/grid header/tab text,
  and opt-out behavior. Tests temporarily set the option in the test process only;
  no config file, database, application data, or workstation setting was modified.
- GlobalFuncNSub and Forms built as part of the Accounts Debug graph. Accounts build
  passed with nine existing Crystal interop warnings and no errors. Live form-open
  timing, complete translation-mode workflow, security, and rendered Arabic layout
  are not established by these isolated checks or compilation.

### Deferred application checks

1. With the existing English-original option enabled and translation-initializer
   mode off, open Pay Element Entry, Employee Entry, and a representative journal
   against the confirmed test environment. Confirm titles, labels, grid headers,
   tabs, toolbar text/images, permissions, and dynamic English captions are correct.
   Compare first/open-again timings under the same workload; do not assume a measured
   speed increase from the source changes alone.
2. Switch English to Arabic and back on the same form. Confirm translated captions
   appear and original English title/labels/tabs/headers/toolbar/images return.
   Check RTL layout, selected lookup values, numeric/date formatting, and cancel edits.
3. If supported in an isolated test setup, test English-original option disabled
   and translation-initializer mode enabled separately. Their existing translation/
   maintenance behavior should remain. Do not enable translation-initializer mode
   against production just for testing; it can maintain translation database rows.
4. Exercise an existing explicit-Arabic caption request while UI language is English.
   Confirm it receives Arabic. Check ordinary English captions remain original text.
5. Record build/commit, environment, culture, options, forms, timings, and results.
   Journal posting/approval/closed-period/reconciliation protections were not changed;
   no accounting writes or payroll generation are needed for these display checks.

No SQL source, database contents, or deployment settings changed; no SQL was run.
No application was launched against a configured database. Nothing was deployed.
Changes are uncommitted/unpushed. The earlier Summary fix and unrelated outputs/
content were preserved.


## SMOKE-BASE-017: Tree selection preserves record identity

Status: PENDING live reproduction. Recorded 2026-10-24.

To resume, say: **"Resume SMOKE-BASE-017 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production environment and cancel edits. Test English and Arabic RTL.

### Reported symptom, cause, and correction

- In RTL Pay Element Entry, selecting node 9 showed record 51 and returned the tree
  selection to that record. The shared Presenter handler converted node ID to sorted
  position, then used RecordPositionNumber's setter to resolve the position back to
  an ID. BaseDao's position query counts names <= the selected name; equal names
  can share a position and NULL sort values also do not provide a reliable identity.
  The user's actual database values were not inspected, so the exact equality/NULL
  condition behind that screenshot still requires live verification.
- Presenter.BfTvEntry_AfterSelect now uses e.Node, keeps position as display metadata,
  and loads TargetIdNo directly from that node's Tag. It does not reverse-resolve a
  clicked record's identity through an ambiguous sort position. Node text/direction
  are not parsed for identity. Existing mouse/keyboard action filtering, root behavior,
  change-record events, and edit/add BeforeSelect guard remain in place.
- This applies to active tree forms inheriting this Presenter chain, including Pay
  Element Entry. It does not change PresenterOld, DAO SQL, tree ordering, or generic
  numeric First/Previous/Next/Last navigation. Deterministic rank/order for duplicate
  or NULL names remains a separate follow-up; navigator position can still be
  ambiguous even though the clicked node now supplies the correct record ID.
- An isolated fake service deliberately returned position 45 and reverse ID 51.
  The old assembly reproduced ID 9 loading 51; the corrected assembly loaded the
  clicked ID and made no reverse-position lookup. Baseline and changed builds each
  passed 108 assertions across mouse/keyboard, LTR/RTL, IDs 9/51/2, duplicate names,
  programmatic-selection filtering, root behavior, load counts, and change events.
  Tests bypassed presenter constructors and overrode data/view updates; no database
  was accessed and the production application was not launched.
- Accounts Debug build passed with nine existing Crystal interop warnings and one
  transient copy-lock retry that recovered. Live mapping, record data, and permission
  behavior remain unverified by compilation/isolated tests.

### Deferred application checks

1. Reproduce the screenshot in RTL: select Pay Element node 9, then 51, then 9 again.
   Confirm displayed record ID, code, name, and tree highlight match the clicked node.
   Repeat via keyboard and English mode, including duplicate/blank translated names.
2. Switch English/Arabic, repeat selections, and navigate a second tree entry form.
   Confirm field values, child details, and selected node remain synchronized.
3. Enter add/edit mode and attempt to select another tree node; verify existing
   navigation restrictions remain. Cancel edits and repeat normal selection.
4. Check First/Previous/Next/Last separately, especially records sharing translated
   names or missing them. Record any wrong rank/skipped record for the separate
   deterministic-navigator follow-up; this correction only removes ID round-tripping
   for tree selection. Do not save a record whose displayed ID was not verified.
5. Record build/commit, environment, selected IDs, language, and actual results.

No SQL source or database changes were made; nothing was deployed, committed, or
pushed. Earlier pending Summary/English optimizations and unrelated outputs/ remain.


## SMOKE-BASE-018: Scoped fast-layout control list

Status: PENDING manual testing. Recorded 2026-10-24.

To resume, say: **"Resume SMOKE-BASE-018 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production environment; cancel edits and check English/Arabic RTL.

### Implemented and checked

- Detailed review found that language switching already collects one control list
  for its operation. This change avoids a redundant full-list scan in the fast
  layout path rather than caching a form's control tree across loads or callbacks.
- BFMain's existing general layout pass collects the five families needed by fast
  layout (CFlowLayout, ToolStrip, TreeView and subclasses, DataGridView, TableLayoutPanel).
  The base fast-layout pass reuses that short list. Other controls still receive
  their original general-layout processing, including numeric alignment and images.
- The overridable ApplyFastLanguageLayout method still receives the full original
  list and is called once in the same position. The existing protected LayOutControls
  entry point is retained. Direct calls and calls with a different list fall back
  to processing the supplied full list. Fixed/full layout policies retain behavior.
- The short list is scoped to one layout call; previous state is restored through
  Finally, including exceptions. Each operation builds candidates afresh, so controls
  added or removed between operations do not leave a stale lasting cache.
- The old build passed 74 fixture assertions; the changed build passed 91 including
  16 identical final-state comparisons across four layout policies, English/Arabic
  direction, and initial/shown states. Checks covered dynamic controls added/removed
  between operations, full-list delivery to overrides, once-per-operation hooks,
  and cleanup/recovery after a deliberately thrown override exception.
- Across the fixture's six fast-layout operations, second-pass control visits fell
  from 1,272 to 30 (five relevant controls each). Candidate classification happens
  inside the existing general pass. This is a scoped fixture count, not a measured
  percentage improvement in application startup time.
- Accounts Debug graph built successfully with nine existing Crystal interop warnings
  and transient copy-lock retries that recovered. Tests created only isolated controls
  in design-time mode; no production application, services, database, or SQL execution.

### Deferred application checks

1. Open Pay Element Entry and another tree form in English and Arabic RTL. Check
   flow/table layout, tree direction, grid direction, toolbar, numeric alignment,
   button images, initial display, and tab changes. Cancel edits.
2. Switch English/Arabic repeatedly after opening. Verify translation/restoration
   and direction remain correct and dynamic/conditional controls still appear.
3. Check Security Group Entry and Disbursement Journal Entry specifically: their
   existing fast-layout overrides must keep security-grid layout and conditional
   cheque/open-invoice controls correct. Do not post/save accounting test records.
4. Compare first and repeated form-open timings under the same environment/workload.
   Record build/commit, forms, language, control state, environment, and results.
   Manual startup-speed claims remain pending until measured.

No SQL source/database/deployment changes. Nothing committed, pushed, or deployed.
Earlier pending Summary/English/tree-selection fixes and unrelated outputs/ remain.
The duplicate/NULL-name numeric navigator issue remains a separate follow-up.

## SMOKE-BASE-019: Lookup reuse during language refresh

Status: PENDING manual testing. Recorded 2026-10-24.

To resume, say: **"Resume SMOKE-BASE-019 from docs/Pending-Smoke-Tests.md."**
Use a confirmed non-production environment; cancel edits and check English/Arabic RTL.

### Implemented and checked

- PresenterBase shares identical lookup tasks within one language-refresh operation
  through the existing plural control/variable data-source helpers. Each consumer
  receives its own DataTable copy, keeping mutable data and selection state separate.
- Keys include service, table, resolved fields, filter, sort key, and direction.
  Different queries remain separate. The scope is discarded in Finally, including
  failure paths; the next refresh fetches fresh data. Ordinary source loading keeps
  its existing independent queries. Existing language hooks run in their original order.
- Language-dependent lookups still reload. Singular MakeVarDataSource, metadata
  lookups, enum sources, and custom queries outside these helpers are not deduplicated.
  Benefit depends on identical requests actually occurring within a refresh.
- Isolated fake-DAO checks: baseline 32 assertions passed; changed build 42 assertions
  passed. Four identical fixture requests made four reads before and one afterward.
  Checks covered independent tables and selections, fresh result markers across
  English/Arabic/English refreshes, hooks, exception cleanup/retry, ordinary loading,
  and separation by service, table, fields, filter (including null versus empty),
  sort key, and direction. This is not a measured application startup improvement.
- Accounts Debug build passed with nine existing Crystal interop warnings and two
  recovered copy-lock retries. The test harness needed explicit dependency loading;
  its freshness marker was made explicit because worker-thread culture inheritance
  differed from the initial fixture assumption. No application or database was opened.

### Deferred application checks

1. Open Pay Element Entry and Employee Entry. Switch English/Arabic/English and
   verify lookup captions, selected record IDs, child details, and numeric displays.
2. Where multiple controls use the same lookup, change one selection and confirm
   other controls keep their own selections. Cancel edits.
3. Check Cash Receipt and Disbursement/Petty Cash payor/payee type-dependent lists.
   Confirm their existing language callbacks and filtering still work. Do not post
   or save accounting test records merely to test lookup display.
4. After an authorized master-data change in the test environment, refresh language
   again and confirm the new data appears. Confirm permissions and cancel behavior.
5. Record environment, build/commit, forms, languages, selected IDs, and timings.
   Actual form speed and preservation of pre-refresh selections remain manual checks.

No SQL source/database changes. Nothing committed, pushed, or deployed.
Earlier pending changes and unrelated outputs/ remain preserved.
