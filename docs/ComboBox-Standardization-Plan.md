# ComboBox Standardization Plan

## Objective

Standardize the behavior of combo boxes used by the Accounts system, including ordinary WinForms controls and combo boxes hosted inside DataGridViews, while preserving intentional fixed-choice and specialized controls.

## Current situation

The system currently contains several combo-box implementations:

- `CtComboBox`: the preferred active lookup control for database-backed fields.
- `CComboBox`: an older general-purpose combo control.
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

Initially, keep the existing `CtComboBox` name to avoid unnecessary WinForms designer and runtime-reflection changes. It can serve as the canonical lookup control. A new base class can be introduced later if a cleaner hierarchy is needed.

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
- `Libraries\CBaseControlsLibrary\ComboBoxControls\Active\CtComboBox.vb`
- `Libraries\CBaseControlsLibrary\ComboBoxControls\Active\CComboBox.vb`
- `Libraries\CBaseControlsLibrary\ComboBoxControls\Active\CtComboBoxEditingControl.vb`
- `Libraries\CBaseControlsLibrary\DataGridViewControls\Columns\CDgvComboBoxColumn.vb`
- `Libraries\CBaseControlsLibrary\DataGridViewControls\Cells\CDgvComboBoxCell.vb`
- `Libraries\CBaseControlsLibrary\DataGridViewControls\EditingControls\CDgvComboBoxEditingControl.vb`
