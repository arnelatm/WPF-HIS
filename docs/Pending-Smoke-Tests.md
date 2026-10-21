# Pending smoke tests

Last updated: 2026-10-21.

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
