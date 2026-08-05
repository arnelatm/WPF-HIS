Legacy Excluded Controls
========================

These controls are intentionally kept out of the active CBaseControlsLibrary project.

Moved here:
- CaComboBox.vb
- CaDgvComboBox.vb
- CaDgvComboBox.resx

Reason:
The source files exist in the repository, but they are not included in CBaseControlsLibrary.vbproj and are not part of the currently compiled program. Old designer files reference CaComboBox and CaDgvComboBoxColumn, but those old forms are also excluded from the active Accounts project, and CaDgvComboBoxColumn has no active class declaration in this repository.

Do not use these for new forms. Prefer CtComboBox for normal ComboBox controls and CDgvComboBoxColumn for DataGridView ComboBox columns.
