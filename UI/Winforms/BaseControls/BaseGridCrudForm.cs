#if DEBUG
#define DESIGN_TIME_SAFE
#endif
using AATM.Contracts.Attributes;
using AATM.Contracts.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{

    [DesignTimeVisible(false)]
    public class BaseGridCrudForm : Form // IEntityWithId constraint at Runtime
    {
        protected IEntityWithId _entity;
        protected readonly ICrudService<IEntityWithId> _service;
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

        //// ** [FIX]: Ensure Getter and Setter are defined as read/write properties **
        //private class TextBinding
        //{
        //    // Required for the previous fix (CS0117)
        //    public System.Windows.Forms.Control Control { get; set; }

        //    // ** These members MUST have { get; set; } to resolve CS0229 **
        //    public Func<IEntityWithId, object> Getter { get; set; }
        //    public Action<IEntityWithId, string> Setter { get; set; }

        //}


        // New: shared BindingSource + BindingNavigator
        private BindingSource _bindingSource;
        private BindingNavigator _navigator;

        // Exposed navigator items for optional customization
        protected ToolStripButton NavFirstButton { get; private set; }
        protected ToolStripButton NavPrevButton { get; private set; }
        protected ToolStripButton NavNextButton { get; private set; }
        protected ToolStripButton NavLastButton { get; private set; }
        protected ToolStripTextBox NavPositionTextBox { get; private set; }
        protected ToolStripLabel NavCountLabel { get; private set; }
        protected ToolStripButton SaveButton { get; private set; }
        protected ToolStripButton DeleteButton { get; private set; }
        protected ToolStripButton RefreshButton { get; private set; }

        public virtual void LoadEntity(IEntityWithId entity)
        {
            _entity = entity;
        }

        public IEntityWithId GetEntity()
        {
            // Collect data from bound controls and return as IEntityWithId
            var current = _bindingSource?.Current as IEntityWithId;
            if (current == null)
                return _entity;

            // Build a new model from form fields, preserving ID
            return BuildModelFromForm(current);
        }

        // Parameterless ctor always provides design-time safe service
        protected BaseGridCrudForm() : this(() => new DesignTimeCrudService()) { }

        protected BaseGridCrudForm(Func<ICrudService<IEntityWithId>> serviceFactory)
        {
            if (IsDesignTime())
            {
                _service = new DesignTimeCrudService();
            }
            else
            {
                _service = (serviceFactory != null ? serviceFactory() : null) ?? new DesignTimeCrudService();
            }

            InitializeNavigatorIfNeeded();
        }

        protected BaseGridCrudForm(ICrudService<IEntityWithId> service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            InitializeNavigatorIfNeeded();
        }

        // Design-time no-op service
        public sealed class DesignTimeCrudService : ICrudService<IEntityWithId>
        {
            public Task<IReadOnlyList<IEntityWithId>> GetAllAsync(CancellationToken ct = default(CancellationToken))
                => Task.FromResult((IReadOnlyList<IEntityWithId>)new List<IEntityWithId>());
            public Task<IEntityWithId> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
                => Task.FromResult(default(IEntityWithId));
            public Task<IEntityWithId> UpsertAsync(IEntityWithId dto, CancellationToken ct = default(CancellationToken))
                => Task.FromResult(dto);
            public Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
                => Task.FromResult(false);
        }

        /// <summary>
        /// Automatically binds form fields (TextBox controls) to properties of the given DTO type.
        /// For each property with a FieldControlAttribute, finds the corresponding control and creates
        /// getter/setter delegates for two-way binding.
        /// </summary>
        protected void AutoBindFormFields(Type dtoType)
        {
            // Get all public instance properties of the DTO type
            var properties = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                // Look for the FieldControlAttribute on the property
                var controlAttr = prop.GetCustomAttribute<AATM.Contracts.Attributes.FieldControlAttribute>();
                if (controlAttr == null)
                {
                    // Skip properties without the attribute
                    //System.Diagnostics.Debug.Fail($"Auto-binding failed: Property '{prop.Name}' does not have FieldControlAttribute.");
                    continue;
                }

                // Resolve the control type from the attribute
                Type concreteControlType = Type.GetType(controlAttr.ControlTypeName) ??
                                           typeof(System.Windows.Forms.Form).Assembly.GetType(controlAttr.ControlTypeName);

                // Find the control field in the current form by name
                var controlField = GetType().GetField(controlAttr.ControlName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                System.Windows.Forms.Control control = controlField?.GetValue(this) as System.Windows.Forms.Control;

                // If the control is missing or the type does not match, skip this property
                if (control == null || (concreteControlType != null && !concreteControlType.IsInstanceOfType(control)))
                {
                    System.Diagnostics.Debug.Fail($"Auto-binding failed: Control '{controlAttr.ControlName}' not found or type mismatch.");
                    continue;
                }

                // Build a getter delegate: Func<IEntityWithId, string>
                // - Casts the entity to the DTO type
                // - Accesses the property
                // - Converts to string, handling nulls
                var entityParam = Expression.Parameter(typeof(IEntityWithId), "entity");
                var castedEntity = Expression.Convert(entityParam, dtoType); 
                var propertyAccess = Expression.Property(castedEntity, prop.Name); 
                var toStringCall = Expression.Call(propertyAccess, typeof(object).GetMethod("ToString"));
                var nullCheck = Expression.Condition(
                    Expression.Equal(propertyAccess, Expression.Constant(null, prop.PropertyType)),
                    Expression.Constant(string.Empty),
                    toStringCall
                );
                var getterLambda = Expression.Lambda<Func<IEntityWithId, string>>(nullCheck, entityParam); 

                // Build a setter delegate: Action<IEntityWithId, string>
                // - Converts the string value to the property type
                // - Assigns it to the property
                var valueParam = Expression.Parameter(typeof(string), "value");
                Expression valueConverted;
                if (prop.PropertyType == typeof(string))
                {
                    valueConverted = valueParam;
                }
                else
                {
                    // Try to use a static Parse(string) method if available
                    var parseMethod = prop.PropertyType.GetMethod("Parse", new[] { typeof(string) });
                    if (parseMethod != null)
                    {
                        valueConverted = Expression.Call(parseMethod, valueParam);
                    }
                    // Otherwise, use Convert.ChangeType for value types
                    else if (prop.PropertyType.IsValueType)
                    {
                        valueConverted = Expression.Convert(
                            Expression.Call(typeof(Convert), "ChangeType", null, valueParam, Expression.Constant(prop.PropertyType)),
                            prop.PropertyType
                        );
                    }
                    // For reference types without Parse, assign null
                    else
                    {
                        valueConverted = Expression.Constant(null, prop.PropertyType);
                    }
                }
                // Assign the converted value to the property
                var setterExpression = Expression.Assign(Expression.Property(castedEntity, prop.Name), valueConverted); 
                var setterLambda = Expression.Lambda<Action<IEntityWithId, string>>(setterExpression, entityParam, valueParam); 

                // Add the binding to the internal list for later use
                _textBindings.Add(new TextBinding
                {
                    Box = control as TextBox,
                    Getter = getterLambda.Compile(),
                    Setter = setterLambda.Compile()
                });
            }
        }

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

        private void InitializeNavigatorIfNeeded()
        {
            if (IsDesignTime()) return;
            if (!UseDefaultNavigator) return;
            if (_navigator != null) return;

            _bindingSource = new BindingSource();

            _navigator = new BindingNavigator(false)
            {
                GripStyle = ToolStripGripStyle.Hidden,
                Dock = DockStyle.Top,
                BindingSource = _bindingSource,
                RenderMode = ToolStripRenderMode.System
            };

            // Build navigation items
            if (ShowNavigationButtons)
            {
                NavFirstButton = new ToolStripButton("|<") { ToolTipText = "First" };
                NavPrevButton = new ToolStripButton("<") { ToolTipText = "Previous" };
                NavPositionTextBox = new ToolStripTextBox { AutoSize = false, Width = 50, ToolTipText = "Position" };
                NavCountLabel = new ToolStripLabel { ToolTipText = "Count" };
                var sepNav1 = new ToolStripSeparator();
                var sepNav2 = new ToolStripSeparator();
                NavNextButton = new ToolStripButton(">") { ToolTipText = "Next" };
                NavLastButton = new ToolStripButton(">|") { ToolTipText = "Last" };

                // Wire standard binding navigator semantics
                _navigator.MoveFirstItem = NavFirstButton;
                _navigator.MovePreviousItem = NavPrevButton;
                _navigator.MoveNextItem = NavNextButton;
                _navigator.MoveLastItem = NavLastButton;
                _navigator.PositionItem = NavPositionTextBox;
                _navigator.CountItem = NavCountLabel;

                _navigator.Items.AddRange(new ToolStripItem[]
                {
                    NavFirstButton, NavPrevButton, sepNav1,
                    NavPositionTextBox, NavCountLabel, sepNav2,
                    NavNextButton, NavLastButton
                });
            }

            if (ShowCrudButtons)
            {
                var sepCrud = new ToolStripSeparator();
                SaveButton = new ToolStripButton("Save") { ToolTipText = "Save / Update", DisplayStyle = ToolStripItemDisplayStyle.Text };
                DeleteButton = new ToolStripButton("Delete") { ToolTipText = "Delete selected", DisplayStyle = ToolStripItemDisplayStyle.Text };
                SaveButton.Click += async (s, e) => await OnSaveRequestedAsync();
                DeleteButton.Click += async (s, e) => await OnDeleteRequestedAsync();

                _navigator.Items.AddRange(new ToolStripItem[]
                {
                    sepCrud, SaveButton, DeleteButton
                });
            }

            if (ShowRefreshButton)
            {
                var sepRefresh = new ToolStripSeparator();
                RefreshButton = new ToolStripButton("Refresh") { ToolTipText = "Reload data", DisplayStyle = ToolStripItemDisplayStyle.Text };
                RefreshButton.Click += async (s, e) => await OnRefreshRequestedAsync();
                _navigator.Items.AddRange(new ToolStripItem[]
                {
                    sepRefresh, RefreshButton
                });
            }

            // Let derived classes add more
            OnCreateAdditionalNavigatorItems(_navigator);

            // Insert into controls
            Controls.Add(_navigator);
            _navigator.BringToFront();
        }

        // -------------------- NEW BINDING SUPPORT --------------------

        private sealed class TextBinding
        {
            public TextBox Box;
            public Func<IEntityWithId, string> Getter;
            public Action<IEntityWithId, string> Setter;
        }

        /// <summary>
        /// Register a two-way text binding between a TextBox and a string property on IEntityWithId.
        /// </summary>
        protected void RegisterTextBinding(TextBox box, Expression<Func<IEntityWithId, string>> property)
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
            var dtoParam = Expression.Parameter(typeof(IEntityWithId), "dto");
            var valParam = Expression.Parameter(typeof(string), "val");
            var assign = Expression.Assign(Expression.Property(dtoParam, pi), valParam);
            var setter = Expression.Lambda<Action<IEntityWithId, string>>(assign, dtoParam, valParam).Compile();

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
            var entity = _bindingSource.Current as IEntityWithId;
            if (entity == null) return;

            foreach (var b in _textBindings)
            {
                if (b.Box != null)
                    b.Box.Text = b.Getter(entity) ?? string.Empty;
            }
        }

        //protected sealed override void PopulateFormFieldsFromGrid(int rowIndex)
        //{
        //    // rowIndex is ignored; using BindingSource.Current which is updated by the navigator/grid selection
        //    var entity = _bindingSource.Current as IEntityWithId;
        //    if (entity == null) return;

        //    foreach (var b in _textBindings)
        //    {
        //        if (b.Box != null)
        //            b.Box.Text = b.Getter(entity) ?? string.Empty;
        //    }
        //    //// Implementation uses _textBindings to set control text from DTO properties
        //    //var entity = _bindingSource.Current as IEntityWithId;
        //    //if (entity == null) return;

        //    //foreach (var binding in _textBindings)
        //    //{
        //    //    if (binding.Box != null)
        //    //        binding.Box.Text = binding.Getter(entity) ?? string.Empty;
        //    //}
        //}

        //protected virtual IEntityWithId BuildModelFromForm(IEntityWithId current)

        protected IEntityWithId BuildModelFromForm(IEntityWithId current)
        {
            var dto = current ?? Activator.CreateInstance<IEntityWithId>();

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

        //protected IEntityWithId BuildModelFromForm(IEntityWithId current)
        //{
        //    var dto = current ?? Activator.CreateInstance<IEntityWithId>();

        //    //// Preserve ID from the selected entity so the service performs an update
        //    //// rather than an insert or a no-op that ignores key changes.
        //    //if (current != null)
        //    //{
        //    //    var idProp = typeof(IEntityWithId).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
        //    //        .FirstOrDefault(p =>
        //    //            p.PropertyType == typeof(int) &&
        //    //            (string.Equals(p.Name, "ID", StringComparison.OrdinalIgnoreCase) ||
        //    //             string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase)));

        //    //    if (idProp != null && idProp.CanRead && idProp.CanWrite)
        //    //    {
        //    //        try
        //    //        {
        //    //            var id = (int)(idProp.GetValue(current) ?? 0);
        //    //            idProp.SetValue(dto, id);
        //    //        }
        //    //        catch { /* swallow; keep DTO usable */ }
        //    //    }
        //    //}

        //    foreach (var b in _textBindings)
        //        if (b.Box != null)
        //            b.Setter(dto, b.Box.Text);

        //    return dto;
        //}

        protected int GetEntityId(IEntityWithId entity)
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

        //protected virtual int GetEntityId(IEntityWithId entity)
        //{
        //    if (entity == null) return 0;
        //    // IEntityWithId is constrained to IEntityWithId, so direct access i
        //    return entity.ID;
        //    //if (entity == null) return 0;
        //    //if (_cachedIdGetter == null)
        //    //{
        //    //    // Look for int ID or Id
        //    //    var idProp = typeof(IEntityWithId).GetProperties(BindingFlags.Public | BindingFlags.Instance)
        //    //        .FirstOrDefault(p =>
        //    //            p.PropertyType == typeof(int) &&
        //    //            (string.Equals(p.Name, "ID", StringComparison.OrdinalIgnoreCase) ||
        //    //             string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase)));

        //    //    if (idProp != null && idProp.CanRead)
        //    //    {
        //    //        var param = Expression.Parameter(typeof(IEntityWithId), "e");
        //    //        var access = Expression.Property(param, idProp);
        //    //        var lambda = Expression.Lambda<Func<IEntityWithId, int>>(access, param);
        //    //        _cachedIdGetter = lambda.Compile();
        //    //    }
        //    //    else
        //    //    {
        //    //        _cachedIdGetter = _ => 0;
        //    //    }
        //    //}
        //    //return _cachedIdGetter(entity);
        //}


        //protected virtual void ClearFormFieldsCore()
        //{
        //    foreach (var b in _textBindings)
        //        if (b.Box != null)
        //            b.Box.Text = string.Empty;
        //}

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
            {
                col.DefaultCellStyle.NullValue = string.Empty;
                col.SortMode = DataGridViewColumnSortMode.Automatic; // Enable sorting
            }

            // Optionally, handle custom sorting or icons
            grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
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
        protected virtual Task OnAfterSaveAsync(IEntityWithId saved) { return Task.CompletedTask; }
        protected virtual Task OnBeforeDeleteAsync(int id, IEntityWithId entity) { return Task.CompletedTask; }
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

        protected virtual string GetDeleteConfirmationText(IEntityWithId entity)
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

        protected IEntityWithId GetSelectedEntity()
        {
            var grid = Grid;
            if (grid == null) return null;

            if (grid.SelectedRows != null && grid.SelectedRows.Count > 0)
            {
                var row = grid.SelectedRows[0];
                if (row != null && !row.IsNewRow)
                    return row.DataBoundItem as IEntityWithId;
            }

            if (grid.CurrentCell != null)
            {
                var row = grid.Rows[grid.CurrentCell.RowIndex];
                if (row != null && !row.IsNewRow)
                    return row.DataBoundItem as IEntityWithId;
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

                var grid = Grid;

                // Ensure navigator stack exists when enabled
                if (UseDefaultNavigator && _navigator == null)
                    InitializeNavigatorIfNeeded();

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

        protected bool NavigateToEntity(Predicate<IEntityWithId> match)
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

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (IsReallyDesignTime) return;
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

        protected bool IsReallyDesignTime
        {
            get
            {
                // 1. LicenseManager (works in most cases)
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return true;

                // 2. DesignMode property (works after initialization)
                if (this.DesignMode)
                    return true;

                // 3. Site.DesignMode (for controls in containers)
                if (this.Site != null && this.Site.DesignMode)
                    return true;

                return false;
            }
        }

        protected static bool IsDesignTime()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return true;

            try
            {
                var proc = Process.GetCurrentProcess();
                if (proc != null && proc.ProcessName.Equals("devenv", StringComparison.OrdinalIgnoreCase))
                    return true;

                //// Heuristic: VS designer assemblies loaded
                //if (AppDomain.CurrentDomain.GetAssemblies()
                //      .Any(a => a.FullName.StartsWith("Microsoft.VisualStudio", StringComparison.OrdinalIgnoreCase)))
                //    return true;
            }
            catch { /* swallow – never block design mode */ }

            return false;
        }

        /// <summary>
        /// Returns a design-time safe CRUD service. At design-time (or if the runtime factory throws),
        /// a no-op DesignTimeCrudService is returned. At runtime, the provided factory is invoked.
        /// </summary>
        protected static ICrudService<IEntityWithId> GetCrudServiceSafe(Func<ICrudService<IEntityWithId>> runtimeFactory)
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
            // BaseGridCrudForm
            // 
            this.ClientSize = new System.Drawing.Size(680, 307);
            this.Name = "BaseGridCrudForm";
            this.ResumeLayout(false);

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

            _items.Clear();
            foreach (var item in sorted)
                _items.Add(item);

            grid.Refresh();
        }
    }
}