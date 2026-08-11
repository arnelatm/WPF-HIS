# Unused candidates quarantine

These files had no direct static references as of 2026-08-11. They remain included in `Common.vbproj`, so runtime behavior is unchanged while the application is observed and tested.

- `CommonForm.vb`
- `CommonForm.Designer.vb`

Do not delete or exclude them until runtime usage through reflection, configuration, or database metadata has been ruled out for at least one stable release.
