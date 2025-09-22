# WinForms Grid CRUD Full Reference
Reusable patterns and snippets for DataGridView-based CRUD forms using BaseGridCrudForm<T> and a concrete TranslationFrm.

How to save/print this guide
- Save this file and open it in Visual Studio or a browser.
- Visual Studio: use __File > Print__ and select “Microsoft Print to PDF”.
- Browser: open the .md in Edge/Chrome, press Ctrl+P, choose “Save as PDF”.

Contents
1) Context and goals
2) TranslationFrm essentials
3) BaseGridCrudForm extensions (navigation, busy UI, errors, selection)
4) ConfigureGrid: best practices and pitfalls
5) Data binding and error handling
6) Performance with large datasets
7) Server-side paging: best practices, challenges, error handling
8) Server-side sorting: best practices, pitfalls, implementation
9) Server-side filtering: strategies and debounce pattern
10) User feedback: loading indicators, status messages, errors, retry
11) Confirmation dialogs (delete/save)
12) Quick checklist

--------------------------------------------------------------------------------

1) Context and goals

Context
- BaseGridCrudForm<T>: Generic WinForms base for CRUD with DataGridView.
- TranslationFrm: Concrete form inheriting TranslationGridCrudForm (a shim over BaseGridCrudForm<TranslationDto>).
- Status routed to a ToolStripStatusLabel, optional Label fallback.
- Wiring helpers for navigation and CRUD.

Goals
- Reuse navigation and CRUD wiring across forms.
- Clear, non-blocking UX: loading indicators, concise status, friendly errors with optional retry.
- Robust ConfigureGrid with explicit, stable columns.
- Design-time safety via a no-op service.

--------------------------------------------------------------------------------

2) TranslationFrm essentials

Key overrides and wiring
- Use a factory ctor so the base constructs the real service at runtime:
  - public TranslationFrm() : base(() => new TranslationCrudService()) { … }
- Map base to actual controls:
  - protected override DataGridView Grid => _dataGridView;
  - protected override ToolStripStatusLabel StatusStripLabel => statusLabel;
- Wire toolbar buttons to base once:
  - WireNavigationButtons(_btnFirst, _btnPrevious, _btnNext, _btnLast);
  - WireCrudButtons(null, tsbSave, tsbDelete);
- Load on first show (runtime only):
  - this.Shown += async (_, __) => await LoadDataAsync();

ConfigureGrid (explicit columns)
- grid.AutoGenerateColumns = false
- ReadOnly = true, MultiSelect = false, SelectionMode = FullRowSelect, AllowUserToAddRows = false
- Columns: ID (hidden), ModuleName, UIIdentifier, OriginalString (Fill), LanguageCode, LocalizedString (Fill)

Form-field mapping
- PopulateFormFieldsFromGrid(rowIndex): copy from row.Cells to textboxes.
- BuildModelFromForm(current): copy from textboxes to TranslationDto; preserve selected ID if applicable.
- GetEntityId(entity) => entity?.ID ?? 0
- ClearFormFieldsCore(): reset textboxes.

--------------------------------------------------------------------------------

3) BaseGridCrudForm extensions (navigation, busy UI, errors, selection)

A. Wire ToolStrip navigation buttons (overload)