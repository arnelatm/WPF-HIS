# ComboBox Standardization Plan

## Objective

Standardize the behavior of combo boxes used by the Accounts system, including ordinary WinForms controls and combo boxes hosted inside DataGridViews, while preserving intentional fixed-choice and specialized controls.

## Current situation

The system currently contains several combo-box implementations:

- `CComboBox`: the standard active lookup control for database-backed fields, renamed from `CtComboBox` after migrating the old general-purpose control's instances.
- Native `System.Windows.Forms.ComboBox` controls for some special-purpose selections.
- `ColorComboBox` and `TxtComboBox` for specialized behavior.
- Older compiled controls such as `CbComboBox`, `CdComboBox`, `CfComboBox`, and `CxComboBox`.
- `CDgvComboBoxColumn` and related cell/editing-control classes for DataGridViews.

The active lookup behavior should be standardized, but not every combo should accept arbitrary typed text. Database lookup fields should allow typing to search and select an existing record; fixed choices should remain list-only.

## Recommended control structure

```text
BCombobox
└── StandardLookupComboBox
    ├── Form lookup control
    └── DataGridView lookup editing control

StandardLookupDataGridViewColumn
└── StandardLookupDataGridViewCell
    └── StandardLookupComboBox editing control
```

Use `CComboBox` as the canonical form lookup control. Its implementation was previously named `CtComboBox`; the active source references, designer type metadata, and project entry now use `CComboBox`. Grid editor classes retain their existing names and inherit the renamed control.

## Implemented lookup improvements

`CComboBox.LookupCache.vb` supplies the shared cache and suggestion identity behavior:

- Cache display text, normalized search text, and sorted source entries. Normalize the query once per search; compile a custom filter once when assigned.
- Invalidate on binding/member changes, list notifications, culture changes, formatting settings, and custom projection/sort changes. DataTable/DataView and notifying BindingList/BindingSource lookups reuse the cache between changes.
- Check unbound and non-notifying lists on each search, including same-count replacements. BindingList sources that do not report item property changes also use this check.
- Keep each suggestion's source item and source index. Mouse, Enter, unique-match completion, and leave validation commit that item. Reject suggestions retained across a source change. Exact-name validation preserves an existing duplicate selection and does not resolve an ambiguous name to the first row.
- Build results before replacing the popup's bound list. Suppress notifications before clearing, restore the previous notification flag in `Finally`, and send one reset for a changed result list. Empty, short, and unmatched input hide the popup; identical results avoid an extra reset.
- Dispose the popup and detach lookup subscriptions when the control is disposed.

`CDgvComboBoxCell.ParseFormattedValue` uses the active editor's selected value when its text matches the selected item. This preserves the chosen ID when duplicate display names reach a grid cell. Invalid text continues through the existing grid parser.

### Custom lookup rules

`PropertySelector` must return one display string for each source item, in the same order. Projection and sort rules should be stable for a given source. Call `RefreshLookupCache()` on the UI thread when external state used by these rules or a `Format` handler changes, or when source notifications were deliberately suppressed. Assigning `Nothing` to a custom filter, projection, or sort restores the default rule. Make bound-list changes on the UI thread, as required by WinForms binding.

The cache and validation retain the complete matching set. The popup displays a configurable subset as described below. Ordinary `DropDownList` controls retain their fixed-choice behavior.

### Keyboard, validation, and popup lifetime

`CComboBox.Interaction.vb` supplies the shared interaction behavior:

- Invalid or ambiguous nonempty lookup text is retained for correction and cancels validation. The old synthetic Backspace is removed. Empty input keeps the existing blank-value behavior; required-field rules remain with the existing form/presenter validation.
- Enter accepts the highlighted suggestion once and keeps focus in the field. With no suggestion popup, ordinary form controls retain Enter-to-next-field behavior through normal focus navigation. Grid controls return Enter to the grid when there is no popup.
- Tab and Shift+Tab accept the highlighted suggestion or validate the current text before normal forward/backward navigation. Invalid text prevents the move.
- Escape restores the value captured on entry or at the last explicit acceptance, including its ID when names are duplicated. Automatic text completion can still be undone. Once the pending edit is restored, another Escape is available to the parent form/grid.
- Key preview has no selection side effects. Native dropdowns retain their native selection/cancellation handling. Popup acceptance checks that its query still matches the current text.
- Reused grid editors initialize from the cell's stored ID before capturing their cancellation value; formatted names alone cannot distinguish duplicates. The cell parser also accepts pending suggestions before converting the editor's value.
- The suggestion form, ListBox binding, click handler and popup font are created on first use. Constructor, binding, layout, height-property access, focus checks, hiding and disposal do not create an unused popup. Created popups are reused and disposed with their control.

### Bounded suggestions, code search, and placement

`CComboBox.Suggestions.vb` provides these defaults to ordinary controls and inherited grid editors:

| Property | Default | Behavior |
| --- | --- | --- |
| `MaxSuggestions` | `100` | Maximum popup rows; `0` explicitly restores unlimited results. Source items and validation remain complete. |
| `ShowSuggestionCode` | `True` | Show `Code — Name` when the loaded source supplies a nonempty code. Avoid repeating codes already present in pipe-separated/prefixed names. The selected control text remains its original display member. |
| `SearchByCode` | `True` | Default contains-search also checks the code and ranks exact codes first. Exact code validation can select a row outside the visible subset. Custom `FilterRule` expressions retain their existing display-text contract. |
| `SuggestionCodeMember` | `"Code"` | Configure another source property/column when needed; an absent member leaves ordinary name search/display intact. No additional database query is made. |
| `SearchDelayMilliseconds` | `0` | Search after the native edit message finishes, coalescing pending updates to the latest text. A positive value enables a WinForms timer only for sources with at least 2,000 items. Small lists remain immediate. |

The non-selectable popup footer shows the displayed/total counts and an English/Arabic prompt to type more. Its text is embedded in `ComboBoxStrings.resx` and `ComboBoxStrings.ar.resx`; the Arabic satellite resource is part of the application build output. A displayed cap of one cannot turn a multi-match query into automatic unique selection. Keyboard acceptance flushes a pending search; programmatic text changes, source changes, focus loss, switching to view mode and disposal prevent stale callbacks from opening a popup.

Search requests originate from `TextUpdate`. Programmatic `Text`/`SelectedValue` changes continue raising the established binding/grid events without starting a suggestion search. Native typing is processed after the edit message completes, avoiding recursive filtering and caret changes within that message.

Popup bounds use the control's current monitor working area, including monitors with negative coordinates. They choose space above/below the control, clamp both axes, right-align in RTL mode, follow owner movement/resize, and hide on parent scrolling or owner deactivation. The popup follows the control font and uses `DeviceDpi` for logical height/padding; no application DPI-awareness, manifest or framework settings were changed. Physical mixed-DPI/multiple-monitor movement and IME composition still require manual checks.

### Popup measurements (2026-10-17)

An offline WinForms probe on this workstation compared five runs constructing and parenting 227 fixed-choice controls. Median construction time decreased from **143.63 ms to 102.82 ms**, retained managed allocation from **1,950.9 KiB to 1,168.6 KiB**, and popup instances from **227 to 0**. These measure control construction, not complete Accounts screen loading. Popup resources are deferred until used.

A separate probe used in-memory DataTables with 1,000, 10,000 and 50,000 rows, English and Arabic text, a 300 by 200 popup, and complete result sets. First display includes creating/binding the popup, native list population, showing it and forcing a repaint; search-cache construction is timed separately. Warm measurements are medians of seven alternating full/filtered result updates, including search, native list replacement and synchronous repaint. Filtering on digit `7` yielded 271, 3,439 and 17,195 matches respectively. Viewport bitmap rendering was also measured separately.

| Full matching rows | Warm search | First popup display | Warm search/list update/repaint | Largest warm update |
| --- | --- | --- | --- | --- |
| 1,000 | 0.11-0.13 ms | 141-149 ms | 5-8 ms | 14-15 ms |
| 10,000 | 0.92-0.93 ms | 1,305-1,325 ms | 42-55 ms | 91-149 ms |
| 50,000 | 4.30-4.92 ms | 6,285-6,401 ms | 159-173 ms | 492-513 ms |

Visible-viewport bitmap painting took roughly 1.5-3.8 ms; native list population dominates the large-list cost. These measurements preceded the bounded popup implementation above. They exclude SQL, full form loading and monitor presentation latency.

Repeating the same English/Arabic in-memory probe with the default 100-row cap produced:

| Total matching rows | First popup display | Warm search/list update/repaint |
| --- | --- | --- |
| 1,000 | 31-45 ms | 10-11 ms |
| 10,000 | 25-28 ms | 12-14 ms |
| 50,000 | 26-30 ms | 15-17 ms |

First popup display excludes the one-time search-cache build (about 143-185 ms for 50,000 rows in this run). The source/native ComboBox was already bound before timing. These local results support keeping the default typing delay at **zero**; the optional large-list delay is available when a particular screen needs it.

### Verification of these improvements

The control library and Accounts Debug project graph build successfully. The Accounts build used the command-line `SignManifests=false` override for local certificate-store restrictions; existing Crystal interop warnings remain. Offline probes passed 1,432 assertions: 1,107 compatibility checks, 97 cache/identity/list-update checks, 73 interaction checks, 149 remaining-feature checks and 6 native-input checks. Existing probes were adapted to signal user input through `TextUpdate` and pump the queued callback. Coverage includes capped/full-set validation, code lookup using the real shared `LookupData` type, timer cancellation/coalescing, English/Arabic footer layout, popup ownership/font/RTL behavior, geometry at positive/negative monitor origins and multiple scale factors, native character input, and programmatic changes without searching. English and Arabic popup bitmaps were visually reviewed. No database was used. Full interactive typing/IME workflows, actual Accounts screens, physical mixed-DPI/multiple-monitor behavior and opening forms in the Visual Studio designer still need manual checks on a confirmed test environment. Nothing was deployed.

## Implementation steps

### 1. Inventory and classify controls

Review only files included by `HIS.sln` and the active project files. Classify every combo as:

- Database lookup: Customer, Supplier, Employee, Account, Product, Warehouse, and similar fields.
- Fixed choice: payment type, month, blood type, status, and enum values.
- Free text: fields where arbitrary text is valid.
- Specialized: color, language, calendar, or other custom controls.

Legacy and excluded forms should be tracked separately from production forms.

### 2. Define the standard form-combo contract

The canonical lookup control should provide:

- `SelectedValue` as the stored database value.
- Typed text only as a search mechanism.
- Exact-match commitment on suggestion click, Enter, and leaving the field.
- Invalid-text rejection or clearing.
- Consistent empty and zero-value handling.
- Duplicate-name handling without silently selecting an unintended record.
- A common selection-committed event.
- Configurable search mode: starts-with or contains.
- Consistent `LimitToList` and required-selection behavior.

Arbitrary text should not be saved into an ID-backed field unless the database field is explicitly designed for free text.

### 3. Standardize DataGridView lookup controls

Create or consolidate one standard column/cell/editing-control group. The editing control should inherit the same lookup behavior as the form control.

Specific items to resolve:

- Ensure the cell `EditType` points to the one canonical editing control.
- Consolidate the duplicate `CtComboBoxEditingControl` and `CDgvComboBoxEditingControl` implementations.
- Copy `ValueMember`, `DisplayMember`, search settings, and validation settings from the column to the editor.
- Commit the selected ID during `CellValidating` or `CellEndEdit`.
- Mark the row dirty only after a valid selection.
- Preserve read-only and display-only behavior.
- Preserve the existing zero-as-blank behavior where required.

The current `CDgvComboBoxColumn` is the preferred migration target for active lookup grids.

### 4. Migrate active forms in groups

Recommended order:

1. AR, AP, Cash Receipt, and Cash Disbursement journals.
2. Purchase, Sale, Inventory, and Product forms.
3. Employee, Payroll, Leave, and Approval forms.
4. Reports and selection dialogs.
5. Common and security forms.

Migrate older `CfDgv...`, `Cx...`, and similar implementations only where they are active. Do not remove legacy classes until references and runtime/reflection use have been verified.

### 5. Preserve intentional exceptions

Keep these list-only or specialized:

- Month selectors.
- Blood-type and enum selectors.
- Color selectors.
- Language selectors.
- Hidden read-only ID columns.
- Controls where arbitrary text is intentionally valid.

Hidden product-ID combo columns in Purchase and Sale are storage columns, not user-entry controls, so they do not need conversion.

### 6. Centralize RTL/LTR and language refresh

The standard control should provide one refresh path that:

- Switches between `Name` and `NameAra`.
- Refreshes the suggestion list.
- Preserves the selected ID during rebinding.
- Updates DataGridView lookup columns.
- Repositions the suggestion popup correctly for RTL.
- Works when switching language while a form is already open.

This should replace form-specific language-refresh code wherever practical.

### 7. Add usability and validation improvements

The standard implementation should support:

- Mouse and keyboard selection.
- Enter to commit and Escape to restore the previous value.
- Consistent validation messages.
- No stale `SelectedValue` after text changes.
- Code-plus-name display where duplicate names are possible.
- Safe data-source refresh without losing the current selection.
- Caching or indexed searching for large lookup lists.

### 8. Test before completion

Test both form and DataGridView controls in LTR and RTL modes, including:

- Switching language while the form is open.
- Mouse selection, Enter, Tab, and Escape.
- Invalid and empty text.
- Duplicate names.
- Zero and null IDs.
- Data-source rebinding.
- New rows, row cancellation, and row validation in DataGridViews.
- Read-only/view mode.
- Save and reopen.

### 9. Retire legacy controls carefully

After confirming there are no active references:

1. Mark old controls obsolete.
2. Stop adding new usages.
3. Migrate remaining active usages.
4. Only then consider excluding old implementations from the project.

## Database impact

No database schema change should be required. Existing ID-backed fields can continue storing their current numeric IDs. The main risk is DataGridView editor compatibility, so grid standardization should be implemented and tested separately from ordinary form combo boxes.

## Relevant source files

- `Libraries\BaseControlsLibrary\BCombobox.vb`
- `Libraries\CBaseControlsLibrary\ComboBoxControls\Active\CComboBox.vb`
- `Libraries\CBaseControlsLibrary\ComboBoxControls\Active\CtComboBoxEditingControl.vb`
- `Libraries\CBaseControlsLibrary\DataGridViewControls\Columns\CDgvComboBoxColumn.vb`
- `Libraries\CBaseControlsLibrary\DataGridViewControls\Cells\CDgvComboBoxCell.vb`
- `Libraries\CBaseControlsLibrary\DataGridViewControls\EditingControls\CDgvComboBoxEditingControl.vb`
