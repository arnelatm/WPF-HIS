using AATM.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    public abstract class BaseGridCrudForm<T> : Form where T : class
    {
        protected readonly ICrudService<T> _service;
        protected List<T> _items = new List<T>();

        // Re-entrancy guards
        private bool _isLoading;
        private bool _isMutating;

        // One-time wiring flags
        private bool _gridEventsWired;
        private bool _gridDataErrorWired;
        private bool _hasLoadedOnce;

        // Cancellation support
        private readonly CancellationTokenSource _cts = new CancellationTokenSource();

        // Retry link handler
        private EventHandler _statusRetryClickHandler;

        // ADDED: parameterless ctor for the Designer (routes to factory ctor)
        protected BaseGridCrudForm() : this(() => new DesignTimeCrudService()) { }

        // ADDED: factory-based ctor to avoid creating real services at design-time
        protected BaseGridCrudForm(Func<ICrudService<T>> serviceFactory)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _service = new DesignTimeCrudService();
            }
            else
            {
                _service = (serviceFactory != null ? serviceFactory() : null) ?? new DesignTimeCrudService();
            }
        }

        // EXISTING: runtime ctor remains for callers that pass a real service
        protected BaseGridCrudForm(ICrudService<T> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // ADDED: no-op service used at design-time
        public sealed class DesignTimeCrudService : ICrudService<T>
        {
            public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken ct = default(CancellationToken))
                => Task.FromResult((IReadOnlyList<T>)new List<T>());
            public Task<T> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
                => Task.FromResult(default(T));
            public Task<T> UpsertAsync(T dto, CancellationToken ct = default(CancellationToken))
                => Task.FromResult(dto);
            public Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
                => Task.FromResult(false);      
        }

        protected abstract DataGridView Grid { get; }

        // OPTIONAL: derived can supply a Label instead of StatusStrip
        protected virtual Label StatusLabel { get { return null; } }
        // OPTIONAL: derived can supply a ToolStripStatusLabel
        protected virtual ToolStripStatusLabel StatusStripLabel { get { return null; } }
        // OPTIONAL: derived can supply a StatusStrip progress bar
        protected virtual ToolStripProgressBar StatusProgress { get { return null; } }
        // OPTIONAL: derived can add more controls to disable when busy
        protected virtual IEnumerable<Control> BusyControls
        {
            get
            {
                yield return Grid;
            }
        }

        // Unified status writer
        protected virtual void SetStatusText(string text)
        {
            if (StatusStripLabel != null)
            {
                StatusStripLabel.Text = text ?? string.Empty;
                if (string.IsNullOrEmpty(StatusStripLabel.ToolTipText))
                    StatusStripLabel.ToolTipText = StatusStripLabel.Text;
            }
            else if (StatusLabel != null)
            {
                StatusLabel.Text = text ?? string.Empty;
            }
        }

        // Busy UI helper
        protected void SetBusy(bool busy, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
                SetStatusText(message);

            try { UseWaitCursor = busy; } catch { }

            var controls = BusyControls;
            if (controls != null)
            {
                foreach (var c in controls)
                {
                    if (c != null) c.Enabled = !busy;
                }
            }

            if (StatusProgress != null)
            {
                StatusProgress.Visible = busy;
                StatusProgress.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            }
        }

        protected abstract void PopulateFormFieldsFromGrid(int rowIndex);
        protected abstract T BuildModelFromForm(T current);
        protected abstract int GetEntityId(T entity);
        protected abstract void ClearFormFieldsCore();

        // OPTIONAL: give derived forms a place to configure columns/formatting
        protected virtual void ConfigureGrid(DataGridView grid) { }

        // Hooks (override as needed)
        protected virtual Task OnBeforeLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnBeforeSaveAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterSaveAsync(T saved) { return Task.CompletedTask; }
        protected virtual Task OnBeforeDeleteAsync(int id, T entity) { return Task.CompletedTask; }
        protected virtual Task OnAfterDeleteAsync(int id, bool ok) { return Task.CompletedTask; }

        // Auto-load on first show (runtime only)
        protected virtual bool AutoLoadOnShown { get { return true; } }

        // Confirmation abstraction
        protected virtual DialogResult ConfirmDelete(string message)
        {
            return MessageBox.Show(this,
                message ?? "Delete selected record?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
        }

        // Context-aware delete message (override to enrich details)
        protected virtual string GetDeleteConfirmationText(T entity)
        {
            int id = 0;
            try { id = entity != null ? GetEntityId(entity) : 0; } catch { }
            return id > 0 ? "Delete selected record (ID=" + id + ")?" : "Delete selected record?";
        }

        // Friendly exception -> short user text
        protected virtual string GetFriendlyErrorMessage(Exception ex)
        {
            if (ex == null) return "Unknown error.";
            if (ex is OperationCanceledException || ex is TaskCanceledException) return "Operation canceled.";
            if (ex is TimeoutException) return "The server took too long to respond.";
            if (ex is HttpRequestException) return "Network error. Please check your connection.";
            var msg = ex.Message;
            return string.IsNullOrWhiteSpace(msg) ? ex.GetType().Name : msg;
        }

        // Show concise status + optional retry link
        protected void ShowError(string context, Exception ex, Func<Task> retryAsync)
        {
            var friendly = GetFriendlyErrorMessage(ex);
            SetStatusText(context + " failed: " + friendly);

            if (StatusStripLabel == null) return;
            StatusStripLabel.ToolTipText = ex != null ? ex.Message : friendly;

            if (_statusRetryClickHandler != null)
            {
                StatusStripLabel.Click -= _statusRetryClickHandler;
                _statusRetryClickHandler = null;
            }

            if (retryAsync != null)
            {
                StatusStripLabel.IsLink = true;
                _statusRetryClickHandler = async (s, e) =>
                {
                    StatusStripLabel.IsLink = false;
                    try { await retryAsync(); }
                    catch (OperationCanceledException)
                    {
                        SetStatusText(context + " canceled.");
                    }
                    catch (Exception ex2)
                    {
                        SetStatusText(context + " failed: " + GetFriendlyErrorMessage(ex2));
                        StatusStripLabel.IsLink = true;
                        StatusStripLabel.ToolTipText = ex2.Message;
                    }
                };
                StatusStripLabel.Click += _statusRetryClickHandler;
            }
            else
            {
                StatusStripLabel.IsLink = false;
            }
        }

        protected void ClearRetryLink()
        {
            if (StatusStripLabel == null) return;
            if (_statusRetryClickHandler != null)
            {
                StatusStripLabel.Click -= _statusRetryClickHandler;
                _statusRetryClickHandler = null;
            }
            StatusStripLabel.IsLink = false;
        }

        // Helper: get the current selection as T
        protected T GetSelectedEntity()
        {
            var grid = Grid;
            if (grid == null) return null;

            if (grid.SelectedRows != null && grid.SelectedRows.Count > 0)
            {
                var row = grid.SelectedRows[0];
                if (row != null && !row.IsNewRow)
                    return row.DataBoundItem as T;
            }

            if (grid.CurrentCell != null)
            {
                var row = grid.Rows[grid.CurrentCell.RowIndex];
                if (row != null && !row.IsNewRow)
                    return row.DataBoundItem as T;
            }

            return null;
        }

        protected async Task LoadDataAsync()
        {
            if (_isLoading) return;
            _isLoading = true;
            SetBusy(true, "Loading...");
            try
            {
                await OnBeforeLoadAsync();

                var result = await _service.GetAllAsync(_cts.Token);
                _items = result != null ? result.ToList() : new List<T>();

                var grid = Grid;

                grid.SuspendLayout();
                try
                {
                    grid.DataSource = null;

                    // Let derived configure columns first; if none, allow auto-generate
                    ConfigureGrid(grid);
                    if (grid.Columns.Count == 0)
                        grid.AutoGenerateColumns = true;

                    grid.DataSource = _items;

                    WireGridDataErrorOnce();
                    WireGridSelectionEventsOnce();
                }
                finally
                {
                    grid.ResumeLayout();
                }

                SetStatusText("Loaded " + _items.Count + " records.");
                ClearRetryLink();
                GoFirst();

                await OnAfterLoadAsync();
            }
            catch (OperationCanceledException)
            {
                SetStatusText("Load canceled.");
            }
            catch (Exception ex)
            {
                // Keep last good data; offer retry
                ShowError("Load", ex, async () => await LoadDataAsync());
            }
            finally
            {
                _isLoading = false;
                _hasLoadedOnce = true;
                SetBusy(false);
            }
        }

        private void WireGridSelectionEventsOnce()
        {
            if (_gridEventsWired) return;
            var grid = Grid;
            if (grid == null) return;

            grid.SelectionChanged += (s, e) =>
            {
                try
                {
                    int rowIndex = -1;

                    if (grid.SelectedRows != null && grid.SelectedRows.Count > 0 && !grid.SelectedRows[0].IsNewRow)
                        rowIndex = grid.SelectedRows[0].Index;
                    else if (grid.CurrentCell != null && !grid.Rows[grid.CurrentCell.RowIndex].IsNewRow)
                        rowIndex = grid.CurrentCell.RowIndex;

                    if (rowIndex >= 0)
                        PopulateFormFieldsFromGrid(rowIndex);
                }
                catch
                {
                    // ignore transient selection errors
                }
            };
            _gridEventsWired = true;
        }

        protected void WireGridDataErrorOnce()
        {
            if (_gridDataErrorWired) return;
            var grid = Grid;
            if (grid == null) return;

            grid.DataError += (s, e) =>
            {
                e.ThrowException = false;
                SetStatusText("Display error in grid data.");
                if (StatusStripLabel != null && e.Exception != null)
                    StatusStripLabel.ToolTipText = e.Exception.Message;
            };
            _gridDataErrorWired = true;
        }

        protected void NavigateToRow(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= Grid.Rows.Count) return;

            var row = Grid.Rows[rowIndex];
            if (row.IsNewRow) return;

            Grid.ClearSelection();
            row.Selected = true;

            var firstVisibleCell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => c.Visible);
            if (firstVisibleCell != null)
                Grid.CurrentCell = firstVisibleCell;

            Grid.FirstDisplayedScrollingRowIndex = rowIndex;
            PopulateFormFieldsFromGrid(rowIndex);
        }

        // Convenience: navigate by predicate on T
        protected bool NavigateToEntity(Predicate<T> match)
        {
            if (match == null || _items == null || _items.Count == 0) return false;
            for (int i = 0; i < _items.Count; i++)
            {
                if (match(_items[i]))
                {
                    NavigateToRow(i);
                    return true;
                }
            }
            return false;
        }

        protected async Task SaveOrUpdateAsync()
        {
            if (_isMutating) return;
            _isMutating = true;
            SetBusy(true, "Saving...");
            try
            {
                await OnBeforeSaveAsync();

                var current = GetSelectedEntity();
                var dto = BuildModelFromForm(current);
                var saved = await _service.UpsertAsync(dto, _cts.Token);
                SetStatusText("Saved (ID=" + GetEntityId(saved) + ")");

                await OnAfterSaveAsync(saved);

                await LoadDataAsync();
                ClearFormFields();
            }
            catch (OperationCanceledException)
            {
                SetStatusText("Save canceled.");
            }
            catch (Exception ex)
            {
                SetStatusText("Save failed: " + ex.Message);
            }
            finally
            {
                _isMutating = false;
                SetBusy(false);
            }
        }

        protected async Task DeleteSelectedAsync()
        {
            if (_isMutating) return;
            _isMutating = true;
            SetBusy(true, "Deleting...");
            try
            {
                var entity = GetSelectedEntity();
                if (entity == null)
                {
                    MessageBox.Show(this, "Select a row to delete.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var id = GetEntityId(entity);

                if (ConfirmDelete(GetDeleteConfirmationText(entity)) != DialogResult.Yes)
                    return;

                await OnBeforeDeleteAsync(id, entity);

                var ok = await _service.DeleteAsync(id, _cts.Token);
                SetStatusText(ok ? "Deleted (ID=" + id + ")" : "Delete failed (ID=" + id + ")");

                await OnAfterDeleteAsync(id, ok);

                await LoadDataAsync();
            }
            catch (OperationCanceledException)
            {
                SetStatusText("Delete canceled.");
            }
            catch (Exception ex)
            {
                SetStatusText("Delete failed: " + ex.Message);
            }
            finally
            {
                _isMutating = false;
                SetBusy(false);
            }
        }

        protected void ClearFormFields()
        {
            ClearFormFieldsCore();
            Grid.ClearSelection();
        }

        // Navigation helpers
        protected void GoFirst()
        {
            for (int i = 0; i < Grid.Rows.Count; i++)
            {
                if (!Grid.Rows[i].IsNewRow)
                {
                    NavigateToRow(i);
                    SetStatusText("First record.");
                    return;
                }
            }
            SetStatusText("No records.");
        }

        protected void GoLast()
        {
            for (int i = Grid.Rows.Count - 1; i >= 0; i--)
            {
                if (!Grid.Rows[i].IsNewRow)
                {
                    NavigateToRow(i);
                    SetStatusText("Last record.");
                    return;
                }
            }
            SetStatusText("No records.");
        }

        protected void GoPrevious()
        {
            var rows = Grid.Rows;
            int firstIndex = -1;
            for (int i = 0; i < rows.Count; i++)
            {
                if (!rows[i].IsNewRow) { firstIndex = i; break; }
            }
            if (firstIndex == -1) { SetStatusText("No records."); return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                               Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : firstIndex;

            if (currentIndex <= firstIndex)
            {
                NavigateToRow(firstIndex);
                SetStatusText("Already at first.");
                return;
            }

            for (int i = currentIndex - 1; i >= firstIndex; i--)
            {
                if (!rows[i].IsNewRow) { NavigateToRow(i); SetStatusText("Previous record."); return; }
            }
            NavigateToRow(firstIndex);
        }

        protected void GoNext()
        {
            var rows = Grid.Rows;

            int lastIndex = -1;
            for (int i = rows.Count - 1; i >= 0; i--)
            {
                if (!rows[i].IsNewRow) { lastIndex = i; break; }
            }
            if (lastIndex == -1) { SetStatusText("No records."); return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                               Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : -1;

            if (currentIndex == -1)
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    if (!rows[i].IsNewRow) { currentIndex = i; break; }
                }
                if (currentIndex == -1) { SetStatusText("No records."); return; }
            }

            if (currentIndex >= lastIndex)
            {
                NavigateToRow(lastIndex);
                SetStatusText("Already at last.");
                return;
            }

            for (int i = currentIndex + 1; i <= lastIndex; i++)
            {
                if (!rows[i].IsNewRow) { NavigateToRow(i); SetStatusText("Next record."); return; }
            }
            NavigateToRow(lastIndex);
        }

        // OPTIONAL: helpers to auto-wire buttons in derived forms
        protected void WireNavigationButtons(Button btnFirst, Button btnPrevious, Button btnNext, Button btnLast)
        {
            if (btnFirst != null) btnFirst.Click += (s, e) => GoFirst();
            if (btnPrevious != null) btnPrevious.Click += (s, e) => GoPrevious();
            if (btnNext != null) btnNext.Click += (s, e) => GoNext();
            if (btnLast != null) btnLast.Click += (s, e) => GoLast();
        }

        // ADDED: ToolStrip overload
        protected void WireNavigationButtons(ToolStripButton btnFirst, ToolStripButton btnPrevious, ToolStripButton btnNext, ToolStripButton btnLast)
        {
            if (btnFirst != null) btnFirst.Click += (s, e) => GoFirst();
            if (btnPrevious != null) btnPrevious.Click += (s, e) => GoPrevious();
            if (btnNext != null) btnNext.Click += (s, e) => GoNext();
            if (btnLast != null) btnLast.Click += (s, e) => GoLast();
        }

        protected void WireCrudButtons(Button btnSave, ToolStripButton tsbSave, ToolStripButton tsbDelete)
        {
            if (btnSave != null) btnSave.Click += async (s, e) => await SaveOrUpdateAsync();
            if (tsbSave != null) tsbSave.Click += async (s, e) => await SaveOrUpdateAsync();
            if (tsbDelete != null) tsbDelete.Click += async (s, e) => await DeleteSelectedAsync();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseGridCrudForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseGridCrudForm";
            this.Load += new System.EventHandler(this.BaseGridCrudForm_Load);
            this.ResumeLayout(false);

        }

        private void BaseGridCrudForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
            if (AutoLoadOnShown && !_hasLoadedOnce)
            {
                var _ = LoadDataAsync();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { _cts.Cancel(); } catch { }
            base.OnFormClosing(e);
        }
    }
}