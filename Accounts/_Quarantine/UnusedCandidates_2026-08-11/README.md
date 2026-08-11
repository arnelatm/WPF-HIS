# Unused candidates quarantine

These files had no direct static references as of 2026-08-11. They remain included in `Accounts.vbproj`, so runtime behavior is unchanged while the application is observed and tested.

- `AccountEvents.vb` — contains `ReconciliationItemCheckedChangeEvent`
- `PresenterHelper.vb`
- `MainPresenter.vb`
- `MainModel.vb`
- `SettingModel.vb`
- `ReconciledModel.vb`
- `OpInvItemModel.vb`
- `LabReportStatusDetail.vb` — split from the active `LabReportStatus.vb` file

Do not delete or exclude them until runtime usage through reflection, configuration, or database metadata has been ruled out for at least one stable release.
