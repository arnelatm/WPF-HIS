using AATM.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace AATM.UI.Winforms.BaseControls
{

    [DesignTimeVisible(false)]
    [Obsolete("Do not inherit directly. Use StrictGridCrudForm<T>.", false)]
#if DESIGN_TIME_SAFE
    public class BaseGridCrudFrm<T> : Form where T : class // No IEntityWithId constraint at Design Time
#else
    public class BaseGridCrudFrm<T> : Form where T : class, IEntityWithId // IEntityWithId constraint at Runtime
#endif
    {
        protected readonly ICrudService<T> _service;
        protected BindingList<IEntityWithId> _items = new BindingList<IEntityWithId>();

        private bool _isLoading;
        private bool _isMutating;

        private bool _gridEventsWired;
        private bool _gridDataErrorWired;
        private bool _hasLoadedOnce;

        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private EventHandler _statusRetryClickHandler;

        // Bindings for forms
        private readonly List<TextBinding> _textBindings = new List<TextBinding>();

        // New: shared BindingSource + BindingNavigator
        private BindingSource _bindingSource;
        private BindingNavigator _navigator;

        private List<(string Property, ListSortDirection Direction)> _sortColumns = new List<(string, ListSortDirection)>();
        private readonly Dictionary<string, SortOrder> _columnSortOrders = new Dictionary<string, SortOrder>();

        //// Exposed navigator items for optional customization
        //protected ToolStripButton NavFirstButton { get; private set; }
        //protected ToolStripButton NavPrevButton { get; private set; }
        //protected ToolStripButton NavNextButton { get; private set; }
        //protected ToolStripButton NavLastButton { get; private set; }
        //protected ToolStripTextBox NavPositionTextBox { get; private set; }
        //protected ToolStripLabel NavCountLabel { get; private set; }
        //protected ToolStripButton SaveButton { get; private set; }
        //protected ToolStripButton DeleteButton { get; private set; }
        //protected ToolStripButton RefreshButton { get; private set; }

        // Parameterless ctor always provides design-time safe service
        protected BaseGridCrudFrm() : this(() => new DesignTimeCrudService()) { }

        protected BaseGridCrudFrm(Func<ICrudService<T>> serviceFactory)
        {
            if (IsDesignTime())
            {
                _service = new DesignTimeCrudService();
            }
            else
            {
                _service = (serviceFactory != null ? serviceFactory() : null) ?? new DesignTimeCrudService();
            }

            // InitializeNavigatorIfNeeded();
        }

        protected BaseGridCrudFrm(ICrudService<T> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            // InitializeNavigatorIfNeeded();
        }

        // Design-time no-op service
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

        protected void AutoBindFormFields()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                var controlAttr = prop.GetCustomAttribute<AATM.Contracts.Attributes.FieldControlAttribute>();
                if (controlAttr == null) continue;

                // 1. Resolve Control Type and Instance
                Type concreteControlType = Type.GetType(controlAttr.ControlTypeName) ??
                                           typeof(System.Windows.Forms.Form).Assembly.GetType(controlAttr.ControlTypeName);

                var controlField = GetType().GetField(controlAttr.ControlName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                System.Windows.Forms.Control control = controlField?.GetValue(this) as System.Windows.Forms.Control;

                if (control == null || !concreteControlType.IsInstanceOfType(control))
                {
                    System.Diagnostics.Debug.Fail($"Auto-binding failed: Control '{controlAttr.ControlName}' not found or type mismatch.");
                    continue;
                }

                // 2. Generate Getter Expression: Func<T, object>
                var entityParam = Expression.Parameter(typeof(T), "d");
                var propertyAccess = Expression.Property(entityParam, prop.Name);
                var convertedAccess = Expression.Convert(propertyAccess, typeof(object));
                var getterLambda = Expression.Lambda<Func<T, object>>(convertedAccess, entityParam);

                // 3. Generate Setter Expression: Action<T, string>
                var valueParam = Expression.Parameter(typeof(string), "v");
                var setterExpression = Expression.Assign(
                    Expression.Property(entityParam, prop.Name),
                    valueParam
                );
                var setterLambda = Expression.Lambda<Action<T, string>>(setterExpression, entityParam, valueParam);

                // 4. Add to the internal _textBindings list
                _textBindings.Add(new TextBinding
                {
                    // ** Both Control and Compile() are now resolved **
                    Box = control as TextBox,
                    Getter = d => getterLambda.Compile()(d)?.ToString(),
                    Setter = setterLambda.Compile()
                });
            }
        }

        //protected void AutoBindFormFields()
        //{
        //    var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //    foreach (var prop in properties)
        //    {
        //        var controlAttr = prop.GetCustomAttribute<FieldControlAttribute>();
        //        if (controlAttr == null) continue;

        //        // ... (Existing logic to find concreteControlType and control instance) ...
        //        Type concreteControlType = Type.GetType(controlAttr.ControlTypeName) ??
        //                                   typeof(System.Windows.Forms.Form).Assembly.GetType(controlAttr.ControlTypeName);
        //        // ... (Error handling for null control or type mismatch) ...

        //        // Assuming 'control' is the found TextBox instance
        //        if (control == null || !concreteControlType.IsInstanceOfType(control))
        //        {
        //            Debug.Fail($"Auto-binding failed: Control '{controlAttr.ControlName}' not found or type mismatch.");
        //            continue;
        //        }

        //        // ** [CRITICAL FIX]: Dynamically generate the expression and add to _textBindings **

        //        // 1. Parameter for the entity (T d)
        //        var entityParam = Expression.Parameter(typeof(T), "d");

        //        // 2. Access the property (d.PropertyName)
        //        var propertyAccess = Expression.Property(entityParam, prop.Name);

        //        // 3. Create Getter Expression: Func<T, object>
        //        // Convert property access to object for boxing/unboxing
        //        var convertedAccess = Expression.Convert(propertyAccess, typeof(object));
        //        var getterLambda = Expression.Lambda<Func<T, object>>(convertedAccess, entityParam);

        //        // 4. Create Setter Expression: Action<T, string> 
        //        // Note: This requires a slightly different approach or helper method, 
        //        // as your original RegisterTextBinding likely handled the setter implicitly based on TextBox.Text.

        //        // Assuming your original RegisterTextBinding method (or internal logic) accepted a Control 
        //        // and a Func<T, object> expression for the GETTER, and handled the SETTER implicitly:

        //        // ** Since we don't have the original RegisterTextBinding source, we must manually populate 
        //        // ** the TextBinding list using the generated Getter and a generated Setter. **

        //        // 5. Generate Setter Logic (Action<T, string>)
        //        var valueParam = Expression.Parameter(typeof(string), "v");
        //        var castValue = Expression.Convert(valueParam, prop.PropertyType); // Convert string to target type (e.g., string/int)

        //        // We assume all DTO properties are strings in this scenario (or rely on Try/Catch in the actual setter logic)
        //        // If the DTO properties are non-string (e.g., int), the setter logic must handle parsing.

        //        // Expression for assignment: d.PropertyName = v
        //        var setterExpression = Expression.Assign(
        //            Expression.Property(entityParam, prop.Name),
        //            valueParam
        //        );
        //        var setterLambda = Expression.Lambda<Action<T, string>>(setterExpression, entityParam, valueParam);

        //        // 6. Add to the internal list:
        //        // We assume TextBinding is a struct/class that holds the Control, Getter, and Setter.

        //        // ** If your original BaseGridCrudFrm used a protected method like 'RegisterTextBinding(Control, Func<T, object>)', 
        //        //    you must call that protected method here. **

        //        // Since we don't have that method, we will directly add the binding:
        //        _textBindings.Add(new TextBinding
        //        {
        //            Control = control,
        //            Getter = getterLambda.Compile(),
        //            Setter = (Action<T, string>)setterLambda.Compile()
        //        });

        //        // The TextBinding structure is assumed to be:
        //        // private readonly List<TextBinding> _textBindings = new List<TextBinding>();
        //        // private class TextBinding { public Control Control; public Func<T, object> Getter; public Action<T, string> Setter; }
        //    }
        //}

        //protected void AutoBindFormFields()
        //{
        //    // ** [FIX]: Declare and initialize the properties variable. **
        //    var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        //    foreach (var prop in properties)
        //    {
        //        var controlAttr = prop.GetCustomAttribute<FieldControlAttribute>();
        //        if (controlAttr == null) continue;

        //        // ... (The rest of the logic remains the same)
        //        Type concreteControlType = Type.GetType(controlAttr.ControlTypeName) ??
        //                                   typeof(System.Windows.Forms.Form).Assembly.GetType(controlAttr.ControlTypeName);

        //        if (concreteControlType == null)
        //        {
        //            Debug.Fail($"Auto-binding failed: Control Type '{controlAttr.ControlTypeName}' could not be resolved.");
        //            continue;
        //        }

        //        // ... (The logic to find the control field and perform binding)
        //    }
        //}

        // Prefer derived classes to expose their grid
        protected virtual DataGridView Grid => null;

        protected virtual Label StatusLabel { get { return null; } }
        protected virtual ToolStripStatusLabel StatusStripLabel { get { return null; } }
        protected virtual ToolStripProgressBar StatusProgress { get { return null; } }

        // New: allow opting out of the default BindingNavigator and its sections
        protected virtual bool UseDefaultNavigator => true;
        protected virtual bool ShowNavigationButtons => true;
        protected virtual bool ShowCrudButtons => true;
        protected virtual bool ShowRefreshButton => true;

        // Hook for derived forms to append items after defaults
        protected virtual void OnCreateAdditionalNavigatorItems(BindingNavigator navigator) { }

        // Hooks to override CRUD actions if needed
        protected virtual Task OnSaveRequestedAsync() => SaveOrUpdateAsync();
        protected virtual Task OnDeleteRequestedAsync() => DeleteSelectedAsync();
        protected virtual Task OnRefreshRequestedAsync() => LoadDataAsync();

        protected virtual IEnumerable<Control> BusyControls
        {
            get
            {
                if (Grid != null) yield return Grid;
            }
        }

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

        // -------------------- NEW: BindingNavigator + BindingSource --------------------

        protected BindingSource DataBindingSource => _bindingSource;
        protected BindingNavigator Navigator => _navigator;

        //private void InitializeNavigatorIfNeeded()
        //{
        //    if (IsDesignTime()) return;
        //    if (!UseDefaultNavigator) return;
        //    if (_navigator != null) return;

        //    _bindingSource = new BindingSource();

        //    _navigator = new BindingNavigator(false)
        //    {
        //        GripStyle = ToolStripGripStyle.Hidden,
        //        Dock = DockStyle.Top,
        //        BindingSource = _bindingSource,
        //        RenderMode = ToolStripRenderMode.System
        //    };

        //    // Build navigation items
        //    if (ShowNavigationButtons)
        //    {
        //        NavFirstButton = new ToolStripButton("|<") { ToolTipText = "First" };
        //        NavPrevButton = new ToolStripButton("<") { ToolTipText = "Previous" };
        //        NavPositionTextBox = new ToolStripTextBox { AutoSize = false, Width = 50, ToolTipText = "Position" };
        //        NavCountLabel = new ToolStripLabel { ToolTipText = "Count" };
        //        var sepNav1 = new ToolStripSeparator();
        //        var sepNav2 = new ToolStripSeparator();
        //        NavNextButton = new ToolStripButton(">") { ToolTipText = "Next" };
        //        NavLastButton = new ToolStripButton(">|") { ToolTipText = "Last" };

        //        // Wire standard binding navigator semantics
        //        _navigator.MoveFirstItem = NavFirstButton;
        //        _navigator.MovePreviousItem = NavPrevButton;
        //        _navigator.MoveNextItem = NavNextButton;
        //        _navigator.MoveLastItem = NavLastButton;
        //        _navigator.PositionItem = NavPositionTextBox;
        //        _navigator.CountItem = NavCountLabel;

        //        _navigator.Items.AddRange(new ToolStripItem[]
        //        {
        //            NavFirstButton, NavPrevButton, sepNav1,
        //            NavPositionTextBox, NavCountLabel, sepNav2,
        //            NavNextButton, NavLastButton
        //        });
        //    }

        //    if (ShowCrudButtons)
        //    {
        //        var sepCrud = new ToolStripSeparator();
        //        SaveButton = new ToolStripButton("Save") { ToolTipText = "Save / Update", DisplayStyle = ToolStripItemDisplayStyle.Text };
        //        DeleteButton = new ToolStripButton("Delete") { ToolTipText = "Delete selected", DisplayStyle = ToolStripItemDisplayStyle.Text };
        //        SaveButton.Click += async (s, e) => await OnSaveRequestedAsync();
        //        DeleteButton.Click += async (s, e) => await OnDeleteRequestedAsync();

        //        _navigator.Items.AddRange(new ToolStripItem[]
        //        {
        //            sepCrud, SaveButton, DeleteButton
        //        });
        //    }

        //    if (ShowRefreshButton)
        //    {
        //        var sepRefresh = new ToolStripSeparator();
        //        RefreshButton = new ToolStripButton("Refresh") { ToolTipText = "Reload data", DisplayStyle = ToolStripItemDisplayStyle.Text };
        //        RefreshButton.Click += async (s, e) => await OnRefreshRequestedAsync();
        //        _navigator.Items.AddRange(new ToolStripItem[]
        //        {
        //            sepRefresh, RefreshButton
        //        });
        //    }

        //    // Let derived classes add more
        //    OnCreateAdditionalNavigatorItems(_navigator);

        //    // Insert into controls
        //    Controls.Add(_navigator);
        //    _navigator.BringToFront();
        //}

        // -------------------- NEW BINDING SUPPORT --------------------

        private sealed class TextBinding
        {
            public TextBox Box;
            public Func<T, string> Getter;
            public Action<T, string> Setter;
        }

        /// <summary>
        /// Register a two-way text binding between a TextBox and a string property on T.
        /// </summary>
        protected void RegisterTextBinding(TextBox box, Expression<Func<T, string>> property)
        {
            if (box == null) throw new ArgumentNullException(nameof(box));
            if (property == null) throw new ArgumentNullException(nameof(property));

            var member = property.Body as MemberExpression;
            if (member == null || !(member.Member is PropertyInfo pi))
                throw new ArgumentException("Expression must be a simple property access", nameof(property));

            if (!pi.CanRead || !pi.CanWrite)
                throw new InvalidOperationException("Property must be readable and writable.");

            var getter = property.Compile();

            // Build setter
            var dtoParam = Expression.Parameter(typeof(T), "dto");
            var valParam = Expression.Parameter(typeof(string), "val");
            var assign = Expression.Assign(Expression.Property(dtoParam, pi), valParam);
            var setter = Expression.Lambda<Action<T, string>>(assign, dtoParam, valParam).Compile();

            _textBindings.Add(new TextBinding
            {
                Box = box,
                Getter = getter,
                Setter = setter
            });
        }

        // -------------------- DEFAULT IMPLEMENTATIONS USING BINDINGS --------------------

        protected void PopulateFormFieldsFromGrid(int rowIndex)
        {
            var entity = _bindingSource.Current as T;
            if (entity == null) return;

            foreach (var b in _textBindings)
            {
                if (b.Box != null)
                    b.Box.Text = b.Getter(entity) ?? string.Empty;
            }
        }


        protected T BuildModelFromForm(T current)
        {
            var dto = current ?? Activator.CreateInstance<T>();

            // Preserve ID from the selected entity using the IEntityWithId interface constraint
            if (current != null && current is IEntityWithId currentWithId && dto is IEntityWithId newWithId)
            {
                newWithId.ID = currentWithId.ID;
            }

            foreach (var b in _textBindings)
            {
                if (b.Box != null)
                    b.Setter(dto, b.Box.Text);
            }

            return dto;
        }

        protected int GetEntityId(T entity)
        {
            if (entity == null) return 0;

            // CS1061 fix: Safely cast 'entity' to the required interface.
            if (entity is IEntityWithId entityWithId)
            {
                return entityWithId.ID;
            }
            // Fallback for types that somehow failed the constraint check (or if the constraint is removed at design time)
            return 0;
        }

        // -------------------- COLUMN HELPERS & GRID CONFIG --------------------

        /// <summary>
        /// Override only if you want to add columns. Base will call this after applying default settings.
        /// </summary>
        protected virtual void DefineColumns(DataGridView grid) { }

        /// <summary>
        /// Extracted default grid setup (common settings)
        /// </summary>
        protected virtual void ApplyDefaultGridSettings(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.EditMode = DataGridViewEditMode.EditProgrammatically;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.RowHeadersVisible = false;
            grid.CellPainting += Grid_CellPainting;
            //// Enable double buffering (reflection)
            //var pi = grid.GetType().GetProperty("DoubleBuffered",
            //    System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //pi?.SetValue(grid, true, null);
        }

        /// <summary>
        /// Simplified configuration flow: Apply defaults then let derived add columns.
        /// </summary>
        protected virtual void ConfigureGrid(DataGridView grid)
        {
            if (grid.Columns.Count > 0) return;
            ApplyDefaultGridSettings(grid);
            DefineColumns(grid);

            // Fallback: allow auto-generation if no columns were added
            if (grid.Columns.Count == 0)
                grid.AutoGenerateColumns = true;

            foreach (DataGridViewColumn col in grid.Columns)
                col.DefaultCellStyle.NullValue = string.Empty;
            col.SortMode = DataGridViewColumnSortMode.Automatic; // Enable sorting
            // Optionally, handle custom sorting or icons
            grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
        }

        private void Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var grid = sender as DataGridView;
            var column = grid.Columns[e.ColumnIndex];
            var propertyName = column.DataPropertyName;

            // Toggle sort direction
            bool ascending = grid.SortOrder != SortOrder.Ascending;

            // Sort the BindingList manually
            var sorted = ascending
                ? _items.OrderBy(x => x.GetType().GetProperty(propertyName)?.GetValue(x, null)).ToList()
                : _items.OrderByDescending(x => x.GetType().GetProperty(propertyName)?.GetValue(x, null)).ToList();

            // Update the BindingList
            _items.Clear();
            foreach (var item in sorted)
                _items.Add(item);

            grid.Refresh();
        }

        protected DataGridViewTextBoxColumn AddTextColumn(DataGridView grid, string dataProp, string header, int width = 100, bool fill = false)
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = dataProp,
                DataPropertyName = dataProp,
                HeaderText = header,
                Width = width,
                AutoSizeMode = fill ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.None
            };
            grid.Columns.Add(col);
            return col;
        }

        protected DataGridViewTextBoxColumn AddHiddenIdColumn(DataGridView grid, string name = "ID")
        {
            var col = new DataGridViewTextBoxColumn
            {
                Name = name,
                DataPropertyName = name,
                HeaderText = "ID",
                Visible = false,
                Width = 60,
                ValueType = typeof(int)
            };
            grid.Columns.Add(col);
            return col;
        }

        // -------------------- Lifecycle hooks & core operations --------------------

        protected virtual Task OnBeforeLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnBeforeSaveAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterSaveAsync(T saved) { return Task.CompletedTask; }
        protected virtual Task OnBeforeDeleteAsync(int id, T entity) { return Task.CompletedTask; }
        protected virtual Task OnAfterDeleteAsync(int id, bool ok) { return Task.CompletedTask; }

        protected virtual bool AutoLoadOnShown { get { return true; } }

        protected virtual DialogResult ConfirmDelete(string message)
        {
            return MessageBox.Show(this,
                message ?? "Delete selected record?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
        }

        protected virtual string GetDeleteConfirmationText(T entity)
        {
            int id = 0;
            try { id = entity != null ? GetEntityId(entity) : 0; } catch { }
            return id > 0 ? $"Delete selected record (ID={id})?" : "Delete selected record?";
        }

        protected virtual string GetFriendlyErrorMessage(Exception ex)
        {
            if (ex == null) return "Unknown error.";
            if (ex is OperationCanceledException || ex is TaskCanceledException) return "Operation canceled.";
            if (ex is TimeoutException) return "The server took too long to respond.";
            if (ex is HttpRequestException) return "Network error. Please check your connection.";
            var msg = ex.Message;
            return string.IsNullOrWhiteSpace(msg) ? ex.GetType().Name : msg;
        }

        protected void ShowError(string context, Exception ex, Func<Task> retryAsync)
        {
            var friendly = GetFriendlyErrorMessage(ex);
            SetStatusText($"{context} failed: {friendly}");

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
                        SetStatusText($"{context} canceled.");
                    }
                    catch (Exception ex2)
                    {
                        SetStatusText($"{context} failed: {GetFriendlyErrorMessage(ex2)}");
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
            if (Grid == null) return;
            _isLoading = true;
            SetBusy(true, "Loading...");
            try
            {
                await OnBeforeLoadAsync();

                var result = await _service.GetAllAsync(_cts.Token);
                _items = result != null ? new BindingList<IEntityWithId>(result.ToList()) : new BindingList<IEntityWithId>();
                _bindingSource.DataSource = _items;

                var grid = Grid;

                grid.SuspendLayout();
                try
                {
                    // Bind via BindingSource (preferred)
                    if (_bindingSource == null) _bindingSource = new BindingSource();

                    _bindingSource.DataSource = _items;

                    ConfigureGrid(grid);
                    if (grid.DataSource != _bindingSource)
                        grid.DataSource = _bindingSource;

                    WireGridDataErrorOnce();
                    WireGridSelectionEventsOnce();
                }
                finally
                {
                    grid.ResumeLayout();
                }

                SetStatusText($"Loaded {_items.Count} records.");
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
            if (Grid == null) return;
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
            if (Grid == null) return;
            _isMutating = true;
            SetBusy(true, "Saving...");
            try
            {
                await OnBeforeSaveAsync();

                var current = GetSelectedEntity();
                var dto = BuildModelFromForm(current);
                var saved = await _service.UpsertAsync(dto, _cts.Token);
                SetStatusText($"Saved (ID={GetEntityId(saved)})");

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
            if (Grid == null) return;
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
                SetStatusText(ok ? $"Deleted (ID={id})" : $"Delete failed (ID={id})");

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
            if (Grid != null)
                Grid.ClearSelection();
        }

        protected void ClearFormFieldsCore()
        {
            foreach (var b in _textBindings)
                if (b.Box != null)
                    b.Box.Text = string.Empty;
        }

        protected void GoFirst()
        {
            if (Grid == null) return;
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
            if (Grid == null) return;
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
            if (Grid == null) return;
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
            if (Grid == null) return;
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

        private void Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var grid = sender as DataGridView;
            var column = grid.Columns[e.ColumnIndex];
            var propertyName = column.DataPropertyName;

            // Toggle sort direction for this column
            var direction = ListSortDirection.Ascending;
            if (_columnSortOrders.TryGetValue(propertyName, out var currentOrder) && currentOrder == SortOrder.Ascending)
                direction = ListSortDirection.Descending;

            // Update sort state
            _sortColumns.RemoveAll(x => x.Property == propertyName);
            _sortColumns.Insert(0, (propertyName, direction));
            _columnSortOrders[propertyName] = direction == ListSortDirection.Ascending ? SortOrder.Ascending : SortOrder.Descending;

            // Multi-column sort using LINQ
            IEnumerable<IEntityWithId> sorted = _items;
            foreach (var sort in _sortColumns.AsEnumerable().Reverse())
            {
                var prop = typeof(T).GetProperty(sort.Property);
                if (prop == null) continue;
                sorted = sort.Direction == ListSortDirection.Ascending
                    ? sorted.OrderBy(x => prop.GetValue(x, null))
                    : sorted.OrderByDescending(x => prop.GetValue(x, null));
            }

            // Update BindingList
            var sortedList = sorted.ToList();
            _items.Clear();
            foreach (var item in sortedList)
                _items.Add(item);

            // Update header icons
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
            column.HeaderCell.SortGlyphDirection = _columnSortOrders[propertyName];
        }

        private void Grid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (e.RowIndex == -1 && _columnSortOrders.TryGetValue(grid.Columns[e.ColumnIndex].DataPropertyName, out var order))
            {
                // Draw your custom icon here based on 'order'
                // Example: e.Graphics.DrawImage(yourIcon, e.CellBounds.X, e.CellBounds.Y);
                // Don't forget to set e.Handled = true if you fully custom paint
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (IsDesignTime()) return;
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

        // -------------------- Shared design-time helpers --------------------
        protected static bool IsDesignTime()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return true;

            try
            {
                var proc = Process.GetCurrentProcess();
                if (proc != null && proc.ProcessName.Equals("devenv", StringComparison.OrdinalIgnoreCase))
                    return true;

                // Heuristic: VS designer assemblies loaded
                if (AppDomain.CurrentDomain.GetAssemblies()
                      .Any(a => a.FullName.StartsWith("Microsoft.VisualStudio", StringComparison.OrdinalIgnoreCase)))
                    return true;
            }
            catch { /* swallow – never block design mode */ }

            return false;
        }

        /// <summary>
        /// Returns a design-time safe CRUD service. At design-time (or if the runtime factory throws),
        /// a no-op DesignTimeCrudService is returned. At runtime, the provided factory is invoked.
        /// </summary>
        protected static ICrudService<T> GetCrudServiceSafe(Func<ICrudService<T>> runtimeFactory)
        {
            if (IsDesignTime())
                return new DesignTimeCrudService();

            if (runtimeFactory == null)
                return new DesignTimeCrudService();

            try
            {
                var svc = runtimeFactory();
                return svc ?? new DesignTimeCrudService();
            }
            catch
            {
                return new DesignTimeCrudService();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseGridCrudFrm
            // 
            this.ClientSize = new System.Drawing.Size(680, 307);
            this.Name = "BaseGridCrudFrm";
            this.ResumeLayout(false);

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
    }
}