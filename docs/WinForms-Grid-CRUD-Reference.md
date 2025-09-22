# WinForms Grid CRUD Reference (BaseGridCrudForm + TranslationFrm)

This guide consolidates best practices and snippets from the thread to build reusable, user-friendly WinForms CRUD grids based on BaseGridCrudForm<T>.

## 1) Goals
- Reuse navigation and CRUD wiring across forms.
- Keep UX responsive: clear status, loading indicators, error handling, and retry.
- Enable design-time safety with a no-op service.
- Make ConfigureGrid robust and consistent.

## 2) BaseGridCrudForm highlights
- Generic base for CRUD over DataGridView.
- Design-time-safe service via DesignTimeCrudService.
- Hooks: OnBefore/AfterLoad/Save/Delete.
- Status routing: optional Label or ToolStripStatusLabel.
- Navigation helpers: GoFirst/Previous/Next/Last and NavigateToRow/NavigateToEntity.
- Wiring helpers:
  - WireNavigationButtons(ToolStripButton first, prev, next, last)
  - WireCrudButtons(Button btnSave, ToolStripButton tsbSave, ToolStripButton tsbDelete)

Optional improvements (recommended):
- ToolStrip overload for navigation wiring (already included above).
- GetSelectedEntity() helper to read current bound item.
- Selection sync: wire Grid.SelectionChanged once to call PopulateFormFieldsFromGrid.
- Auto-load on first show (override AutoLoadOnShown to true).
- Centralized busy UI (SetBusy) and friendly error helpers with optional retry link.
- DataGridView.DataError wiring once (never throw).

## 3) TranslationFrm essentials
- Inherit: TranslationFrm : TranslationGridCrudForm.
- Pass real service via factory ctor: base(() => new TranslationCrudService()).
- Override:
  - Grid => _dataGridView
  - StatusStripLabel => statusLabel
  - ConfigureGrid(grid) => define columns explicitly
  - PopulateFormFieldsFromGrid(rowIndex)
  - BuildModelFromForm(current) => map form fields -> dto (+ preserve ID if selected)
  - GetEntityId(entity)
  - ClearFormFieldsCore()

- Wire toolbar to base once:
  - WireNavigationButtons(_btnFirst, _btnPrevious, _btnNext, _btnLast)
  - WireCrudButtons(null, tsbSave, tsbDelete)

- Load on first show:
  - this.Shown += async (_, __) => await LoadDataAsync();

## 4) ConfigureGrid best practices
- Set once; early-return if Columns.Count > 0.
- grid.AutoGenerateColumns = false; define columns explicitly using nameof where possible.
- Read-only list editing: grid.ReadOnly = true, SelectionMode = FullRowSelect, MultiSelect = false, EditMode = EditProgrammatically, AllowUserToAddRows = false, RowHeadersVisible = false.
- Layout: use Fill for long text; set Width/FillWeight for others; hide ID column.
- Formatting: set DefaultCellStyle.NullValue; set Format on dates/numbers; avoid heavy CellFormatting.
- Stability: handle grid.DataError once (e.ThrowException = false).
- Performance: avoid AutoSizeRowsMode=AllCells for large sets; optional DoubleBuffered via reflection to reduce flicker.

## 5) Common ConfigureGrid pitfalls
- AutoGenerateColumns left on (inconsistent columns).
- Duplicating columns on each call (guard with Columns.Count > 0).
- Name vs DataPropertyName mismatches (use consistent names).
- Leaving grid editable when form fields also edit (conflicting sources of truth).
- Sort glyphs without actual sorting (List<T> won’t sort automatically).

## 6) Loading indicators (user-friendly)
- Show “Loading…” in status, then “Loaded N records.”.
- Add a ToolStripProgressBar (Marquee) to StatusStrip; toggle during operations.
- Use wait cursor and disable grid/toolbar while busy.
- Wrap binds in SuspendLayout/ResumeLayout; keep last good data on failure.
- Treat OperationCanceledException as normal.

## 7) Error handling and retry
- Non-blocking feedback: StatusStrip for short messages; put exception details in status tooltip.
- Optional retry link: make the status label a link for idempotent failures (load/paging/filter/sort).
- Handle DataGridView.DataError once; e.ThrowException = false.
- Keep the last good DataSource; only rebind on success.
- Map exceptions to friendly, short messages (timeout, network).

## 8) Server-side paging/filtering/sorting (patterns)
- Service shape: GetPageAsync(pageIndex, pageSize, sortBy, sortDesc, filter, ct) => Items + TotalCount.
- Reset to page 0 on sort/filter changes, show page info in status.
- Debounce filter inputs (300–500 ms) and cancel in-flight requests.
- Programmatic sorting: set SortMode=Programmatic, toggle glyphs manually, call server with sortBy/DataPropertyName.
- Stable ordering: add a secondary key (e.g., ID) on the server.

## 9) Confirmation dialogs (delete/save)
- Confirm destructive actions only (delete by default).
- Provide context in delete prompt (ID, Module, UI Identifier, Language, snippet of Original).
- Safe defaults: owner-centered, warning icon, default button = No.
- Override base ConfirmDelete/GetDeleteConfirmationText(entity) to enrich messages.
- For overwrite saves (optional), ask in OnBeforeSaveAsync and cancel if declined.

## 10) Quick snippets (sketches)

- Wire navigation/CRUD:
  - WireNavigationButtons(_btnFirst, _btnPrevious, _btnNext, _btnLast)
  - WireCrudButtons(null, tsbSave, tsbDelete)

- ConfigureGrid guard:
  - if (grid.Columns.Count > 0) return;

- Friendly status helpers (optional style):
  - SetStatusText("Loading..."); SetStatusText("Loaded " + _items.Count + " records.");

- Error + retry:
  - catch (Exception ex) { ShowError("Load", ex, async () => await LoadDataAsync()); }

- Delete confirmation (context-rich, override in form):
  - return $"Are you sure?\r\n\r\nID: {entity.ID}\r\nModule: {entity.ModuleName}\r\n…";

## 11) Printing this guide to PDF
- Visual Studio: open this file, then use __File > Print__ -> “Microsoft Print to PDF”.
- Or open in Edge/Chrome and print to PDF (Ctrl+P).
