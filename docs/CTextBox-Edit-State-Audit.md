# CTextBox edit-state audit

## Scope

Reviewed explicit source entries in the projects listed by `HIS.sln`: 774 custom
textbox construction sites in 108 source files (730 `CTextBox`, 43
`CTextBoxArabic`, and one `gTimeBox`). These are source construction sites,
including reusable controls and compiled legacy code, not a count of controls
visible in the running application. Standalone projects outside this solution
were excluded.

## State contract

- `DisplayOnly=True` keeps a textbox read-only, including security restrictions.
- Otherwise, `EditingMode=True` or `AlwaysEditable=True` allows editing.
- Disabled controls remain disabled during mode changes.
- Record-entry bases recursively set `EditingMode` during Add/Edit and View,
  including textboxes nested in user controls.
- A standalone input dialog must set its input mode explicitly. Clearing
  `ReadOnly` or `DisplayOnly` does not replace entering edit mode.

## Corrections and findings

- `LoginEntry` serialized `EditingMode=False` for its four textboxes, then tried
  to unlock them by clearing `ReadOnly` and `DisplayOnly`. Its non-designer code
  now sets edit mode explicitly in the constructor and Load handler. The username
  remains display-only during password changes.
- The compiled `TxtComboBox` wrapper started with its parent in edit mode while
  its internal textbox remained in view mode. Initialization and `DisplayOnly`
  changes now synchronize its internal editors through the existing update
  method. No direct form construction sites for this wrapper were found.
- Other standalone input screens already set edit mode. Record-entry textboxes
  use the shared recursive input workflow. No further active form with the login
  mismatch was found in the source audit.
- Existing display-only, disabled, and legacy controls were preserved. The base
  `CTextBox` state rules were not weakened to make view-mode controls editable.

## Verification

- The control library built without warnings or errors.
- Accounts built in an isolated output folder with zero errors and nine Crystal
  Reports interop warnings. Manifest signing was disabled for this build only.
- 18,258 offline assertions passed, exercising all 774 recorded textbox
  configurations in English and Arabic, mode transitions, 5,664 native input
  checks, and 176 checks of composite and nested editors.
- The existing login probe passed 341 assertions; the combo compatibility probe
  passed 1,107 assertions against the updated build.

The configuration checks instantiate shared controls using recorded source
settings; they do not instantiate every complete application screen. The login
probe uses the real designer settings and input-state methods with an offline
form host. Authentication, database-backed workflows, and complete screen
layout/RTL verification still require a manual smoke test in an authorized
non-production environment. No SQL was executed, database changed, or output
deployed.
