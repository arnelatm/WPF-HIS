using AATM.Business.Logic.Validators;
using AATM.Contracts.Attributes;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.UI.Winforms.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;                  // Added for colors (watermark)
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AATM.UI.Winforms.BaseControls
{
    [DesignTimeVisible(false)]
    public class BaseGridCrudForm : Form
    {
        #region Private UI fields / state

        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _statusStripLabel;
        private ToolStripProgressBar _statusProgress;

        protected readonly ICrudService<IEntityWithId> _service;
        protected IEntityWithId _entity;
        protected BindingList<IEntityWithId> _items = new BindingList<IEntityWithId>();
        protected ErrorProvider myErrorProvider;

        private static readonly Dictionary<Type, List<GeneratedGridColumn>> _autoColumnCache =
            new Dictionary<Type, List<GeneratedGridColumn>>();

        private readonly CancellationTokenSource _cts = new CancellationTokenSource();
        private readonly List<TextBinding> _textBindings = new List<TextBinding>();
        private List<IEntityWithId> _allItems = new List<IEntityWithId>();
        private BindingSource _bindingSource;
        private Dictionary<string, Control> _fieldControlMap;
        private bool _gridDataErrorWired;
        private bool _gridEventsWired;
        private bool _hasLoadedOnce;
        private bool _isLoading;
        private bool _isMutating;
        private LanguageUiHelper _langHelper;
        private BindingNavigator _navigator;

        // Original search controls
        private ToolStripTextBox _searchBox;
        private ToolStripButton _searchButton;

        // --- Added search enhancement controls / state (features 1–7)
        private ToolStripButton _searchClearButton;
        private ToolStripDropDownButton _searchColumnsButton;
        private ToolStripButton _searchLiveToggleButton;
        private ToolStripDropDownButton _searchModeButton;
        private enum SearchMode { Normal, Regex, Fuzzy }
        private SearchMode _searchMode = SearchMode.Normal;
        private readonly HashSet<string> _searchSelectedColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private System.Windows.Forms.Timer _searchDebounceTimer;
        private bool _liveSearchEnabled = true;
        private bool _isWatermarkActive;
        private bool _suppressProgrammaticSearch;
        private const string SearchWatermark = "Type to search...";
        private const int SearchDebounceMs = 350;
        // -----------------------------------------------

        private EventHandler _statusRetryClickHandler;
        private BindingList<object> _typedBindingList;
        private IGridCrudController _typedController;

        #endregion

        #region Configuration state
        private bool _crudConfigured;
        private Type _configuredDtoType;
        protected bool IsCrudConfigured { get { return _crudConfigured; } }
        #endregion

        #region CrudFormConfig / Fluent (unchanged)
        protected sealed class CrudFormConfig<TDto>
            where TDto : class, IEntityWithId, new()
        {
            public Func<ICrudService<TDto>> ServiceFactory { get; set; }
            public Func<TDto, IEnumerable<ValidationError>> Validator { get; set; }
            public Control ErrorDisplayControl { get; set; }
            public bool AutoBindFields { get; set; } = true;
            internal bool Applied;
        }

        protected void ConfigureCrudForm<TDto>(CrudFormConfig<TDto> cfg)
            where TDto : class, IEntityWithId, new()
        {
            if (cfg == null) throw new ArgumentNullException("cfg");
            if (cfg.Applied) throw new InvalidOperationException("CrudFormConfig already applied.");
            if (_crudConfigured)
                throw new InvalidOperationException("CRUD already configured for: " +
                    (_configuredDtoType != null ? _configuredDtoType.FullName : "unknown"));
            if (cfg.ServiceFactory == null)
                throw new ArgumentException("ServiceFactory required.", "cfg.ServiceFactory");

            InitializeErrorHandling(cfg.ErrorDisplayControl);
            InitializeTypedController(cfg.ServiceFactory);

            _configuredDtoType = typeof(TDto);
            _crudConfigured = true;
            cfg.Applied = true;

            if (cfg.AutoBindFields)
                AutoBindFormFields(typeof(TDto));

            if (cfg.Validator != null)
                StructuredValidator = e => cfg.Validator((TDto)e);

#if DEBUG
            if (_typedController != null && _typedController.DtoType != _configuredDtoType)
                throw new InvalidOperationException("Configured DTO type and controller DTO type mismatch.");
#endif
        }

        protected void EnsureCrudConfiguredIfTyped()
        {
            if (_typedController != null && !_crudConfigured)
                throw new InvalidOperationException("Typed controller initialized without ConfigureCrudForm<> call.");
        }

        public CrudFormFluent<TDto> ForDto<TDto>()
            where TDto : class, IEntityWithId, new()
        {
            return new CrudFormFluent<TDto>(this);
        }

        public sealed class CrudFormFluent<TDto>
            where TDto : class, IEntityWithId, new()
        {
            private readonly BaseGridCrudForm _form;
            private readonly CrudFormConfig<TDto> _cfg = new CrudFormConfig<TDto>();
            private bool _applied;
            internal CrudFormFluent(BaseGridCrudForm form) { _form = form; }
            public CrudFormFluent<TDto> Service(Func<ICrudService<TDto>> factory) { _cfg.ServiceFactory = factory; return this; }
            public CrudFormFluent<TDto> Validator(Func<TDto, IEnumerable<ValidationError>> validator) { _cfg.Validator = validator; return this; }
            public CrudFormFluent<TDto> ErrorDisplay(Control control) { _cfg.ErrorDisplayControl = control; return this; }
            public CrudFormFluent<TDto> AutoBind(bool enabled = true) { _cfg.AutoBindFields = enabled; return this; }
            public void Apply()
            {
                if (_applied) throw new InvalidOperationException("CrudFormFluent already applied.");
                _form.ConfigureCrudForm(_cfg);
                _applied = true;
            }
        }
        #endregion

        #region Attribute auto-config (unchanged)
        private static readonly Dictionary<Type, CrudFormAttribute> _crudAttrCache =
            new Dictionary<Type, CrudFormAttribute>();

        protected void AutoConfigureFromDto<TDto>(Dictionary<string, object> comboBoxDataSources = null)
            where TDto : class, IEntityWithId, new()
        {
            var dtoType = typeof(TDto);
            CrudFormAttribute attr;
            if (!_crudAttrCache.TryGetValue(dtoType, out attr))
            {
                attr = (CrudFormAttribute)Attribute.GetCustomAttribute(dtoType, typeof(CrudFormAttribute), false);
                _crudAttrCache[dtoType] = attr;
            }
            if (attr == null)
                throw new InvalidOperationException("CrudFormAttribute not found on DTO: " + dtoType.FullName);

            if (!typeof(ICrudService<TDto>).IsAssignableFrom(attr.ServiceType))
                throw new InvalidOperationException("ServiceType must implement ICrudService<" + dtoType.Name + ">");
            if (attr.ServiceType.GetConstructor(Type.EmptyTypes) == null)
                throw new InvalidOperationException("ServiceType requires public parameterless constructor.");

            Func<ICrudService<TDto>> serviceFactory =
                () => (ICrudService<TDto>)Activator.CreateInstance(attr.ServiceType);

            Func<TDto, IEnumerable<ValidationError>> validator = null;
            if (attr.ValidatorRulesType != null)
            {
                var flags = BindingFlags.Public | BindingFlags.Static;
                var pi = attr.ValidatorRulesType.GetProperty("Rules", flags);
                var fi = attr.ValidatorRulesType.GetField("Rules", flags);
                object rulesObj = pi != null ? pi.GetValue(null, null) : (fi != null ? fi.GetValue(null) : null);
                if (rulesObj == null)
                    throw new InvalidOperationException("Rules not found or null on " + attr.ValidatorRulesType.FullName);

                validator = dto =>
                {
                    if (rulesObj == null) return Enumerable.Empty<ValidationError>();
                    var dtoValidatorType = typeof(DtoValidator);
                    var candidates = dtoValidatorType
                        .GetMethods(BindingFlags.Public | BindingFlags.Static)
                        .Where(m => m.Name == "Validate" && m.GetParameters().Length == 2)
                        .ToList();
                    MethodInfo selected = null;
                    foreach (var m in candidates)
                    {
                        MethodInfo closed = m;
                        if (m.IsGenericMethodDefinition)
                        {
                            if (m.GetGenericArguments().Length != 1)
                                continue;
                            try { closed = m.MakeGenericMethod(typeof(TDto)); } catch { continue; }
                        }
                        var pars = closed.GetParameters();
                        if (!pars[0].ParameterType.IsAssignableFrom(typeof(TDto))) continue;
                        if (rulesObj != null && !pars[1].ParameterType.IsInstanceOfType(rulesObj)) continue;
                        selected = closed;
                        break;
                    }

                    if (selected != null)
                    {
                        try
                        {
                            var result = selected.Invoke(null, new object[] { dto, rulesObj });
                            return result as IEnumerable<ValidationError> ?? Enumerable.Empty<ValidationError>();
                        }
                        catch { return Enumerable.Empty<ValidationError>(); }
                    }
#if DEBUG
                    Debug.WriteLine($"DtoValidator.Validate method not found for DTO '{typeof(TDto).Name}' and rules '{rulesObj.GetType().FullName}'.");
#endif
                    return Enumerable.Empty<ValidationError>();
                };
            }

            Control errorDisplay = null;
            if (!string.IsNullOrWhiteSpace(attr.ErrorDisplayControlName))
            {
                var ctlField = GetType().GetField(attr.ErrorDisplayControlName,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (ctlField != null)
                    errorDisplay = ctlField.GetValue(this) as Control;
            }

            var cfg = new CrudFormConfig<TDto>
            {
                ServiceFactory = serviceFactory,
                Validator = validator,
                ErrorDisplayControl = errorDisplay,
                AutoBindFields = attr.AutoBindFields
            };
            ConfigureCrudForm(cfg);

            // --- Generic ComboBox binding support ---
            var properties = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var controlAttr = prop.GetCustomAttribute<FieldControlAttribute>();
                if (controlAttr == null) continue;

                var controlField = GetType().GetField(controlAttr.ControlName,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var control = controlField?.GetValue(this);

                // ComboBox binding
                if (control is ComboBox combo && comboBoxDataSources != null && comboBoxDataSources.TryGetValue(prop.Name, out var dataSource))
                {
                    combo.DataSource = dataSource;
                    // Optionally set DisplayMember/ValueMember if your data source supports it
                    // combo.DisplayMember = "Display";
                    // combo.ValueMember = "Code";
                    combo.DataBindings.Clear();
                    combo.DataBindings.Add("SelectedValue", _bindingSource, prop.Name, true, DataSourceUpdateMode.OnPropertyChanged);
                }
                // TextBox binding (existing logic)
                else if (control is TextBox textBox)
                {
                    textBox.DataBindings.Clear();
                    textBox.DataBindings.Add("Text", _bindingSource, prop.Name, true, DataSourceUpdateMode.OnPropertyChanged);
                }
            }
        }
        #endregion

        #region Constructors
        protected BaseGridCrudForm() : this(() => new DesignTimeCrudService()) { }
        protected BaseGridCrudForm(Func<ICrudService<IEntityWithId>> serviceFactory)
        {
            if (IsDesignTime())
                _service = new DesignTimeCrudService();
            else
                _service = (serviceFactory != null ? serviceFactory() : null) ?? new DesignTimeCrudService();

            InitializeStatusStripAndLabel();
            InitializeNavigatorIfNeeded();
        }
        protected BaseGridCrudForm(string callingModule) : this(() => new DesignTimeCrudService())
        {
            moduleName = callingModule;
        }
        protected BaseGridCrudForm(ICrudService<IEntityWithId> service)
        {
            _service = service ?? throw new ArgumentNullException("service");
            InitializeNavigatorIfNeeded();
        }
        #endregion

        #region Feature flags
        protected virtual bool AutoGenerateColumnsFromAttributes { get { return true; } }
        protected virtual bool AutoLoadOnShown { get { return true; } }
        protected virtual bool AutoWireClearErrors { get { return true; } }
        protected virtual bool ShowCrudButtons { get { return true; } }
        protected virtual bool ShowErrorsInStatusBar { get; set; } = true;
        protected virtual bool ShowErrorsInStatusLabel { get; set; } = true;
        protected virtual bool ShowLanguageSelector { get { return true; } }
        protected virtual bool ShowNavigationButtons { get { return true; } }
        protected virtual bool ShowRefreshButton { get { return true; } }
        protected virtual bool ShowValidationErrorsOnlyInValidationTextBox { get; set; } = true;
        protected virtual bool UseDefaultNavigator { get { return true; } }
        #endregion

        #region Core exposed members
        protected Control ErrorDisplayControl { get; set; }
        protected virtual DataGridView Grid { get { return null; } }
        protected BindingSource DataBindingSource { get { return _bindingSource; } }
        protected ToolStripButton SaveButton { get; private set; }
        protected ToolStripButton DeleteButton { get; private set; }
        protected ToolStripButton RefreshButton { get; private set; }
        protected ToolStripComboBox LanguageComboBox { get; private set; }
        protected ToolStripButton LanguageApplyButton { get; private set; }
        protected ToolStripLabel NavCountLabel { get; private set; }
        protected ToolStripButton NavFirstButton { get; private set; }
        protected ToolStripButton NavPrevButton { get; private set; }
        protected ToolStripButton NavNextButton { get; private set; }
        protected ToolStripButton NavLastButton { get; private set; }
        protected ToolStripTextBox NavPositionTextBox { get; private set; }
        protected virtual ToolStripStatusLabel StatusStripLabel { get { return _statusStripLabel; } }
        protected virtual ToolStripProgressBar StatusProgress { get { return _statusProgress; } }
        protected virtual Label StatusLabel { get { return null; } }
        protected virtual ILocalizationService LocalizationService { get; private set; }
        protected virtual IUiLocalizationManager UiLocalizationManager { get; private set; }
        protected string moduleName { get; private set; }
        protected Func<IEntityWithId, IEnumerable<ValidationError>> StructuredValidator { get; set; }

        protected virtual IEnumerable<Control> BusyControls
        {
            get
            {
                if (Grid != null) yield return Grid;
            }
        }

        protected bool IsReallyDesignTime
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return true;
                if (DesignMode) return true;
                if (Site != null && Site.DesignMode) return true;
                return false;
            }
        }
        #endregion

        #region Error handling / initialization
        protected virtual void InitializeErrorHandling(Control errorDisplayControl = null)
        {
            EnsureErrorProvider();
            ErrorDisplayControl = errorDisplayControl;
        }

        protected void EnsureErrorProvider()
        {
            if (myErrorProvider != null) return;
            myErrorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink,
                ContainerControl = this
            };
            Disposed += delegate { try { myErrorProvider?.Dispose(); } catch { } };
        }
        #endregion

        #region Typed controller initialization
        protected void InitializeTypedController<TDto>(Func<ICrudService<TDto>> factory)
            where TDto : class, IEntityWithId, new()
        {
            if (factory == null) throw new ArgumentNullException("factory");
            _typedController = new GridCrudController<TDto>(factory());
            if (_bindingSource == null)
                _bindingSource = new BindingSource();
            _bindingSource.DataSource = typeof(TDto);
            _typedBindingList = new BindingList<object>();           
        }
        #endregion

        #region Auto field binding
        protected void AutoBindFormFields(Type dtoType, Dictionary<string, object> comboBoxDataSources = null)
        {
            // if DataSource is still a Type, keep it (good for property discovery); do not overwrite here.
            var properties = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var controlAttr = prop.GetCustomAttribute<FieldControlAttribute>();
                if (controlAttr == null) continue;
                var controlField = GetType().GetField(controlAttr.ControlName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var control = controlField != null ? controlField.GetValue(this) as Control : null;
                if (control == null) continue;

                // --- ComboBox binding ---
                if (control is ComboBox combo)
                {
                    if (comboBoxDataSources != null && comboBoxDataSources.TryGetValue(prop.Name, out var ds))
                    {
                        combo.DataSource = ds;
                        // Optionally set DisplayMember/ValueMember if your data source supports it
                        // combo.DisplayMember = "Display";
                        // combo.ValueMember = "Code";
                    }
                    combo.DataBindings.Clear();
                    combo.DataBindings.Add("SelectedValue", _bindingSource, prop.Name, true, DataSourceUpdateMode.OnPropertyChanged);
                    continue; // Skip TextBinding for ComboBox
                }
                // --- TextBox binding (existing logic) ---
                if (control is TextBox textBox)
                {
                    var entityParam = Expression.Parameter(typeof(IEntityWithId), "entity");
                    var castedEntity = Expression.Convert(entityParam, dtoType);
                    var propertyAccess = Expression.Property(castedEntity, prop.Name);

                    Expression getterBody;
                    if (prop.PropertyType == typeof(string))
                    {
                        getterBody = Expression.Coalesce(propertyAccess, Expression.Constant(string.Empty));
                    }
                    else
                    {
                        var toObj = Expression.Convert(propertyAccess, typeof(object));
                        var toStringCall = Expression.Call(toObj, typeof(object).GetMethod("ToString"));
                        getterBody = Expression.Condition(
                            Expression.Equal(propertyAccess, Expression.Constant(null, prop.PropertyType)),
                            Expression.Constant(string.Empty),
                            toStringCall);
                    }
                    var getterLambda = Expression.Lambda<Func<IEntityWithId, string>>(getterBody, entityParam);

                    var valueParam = Expression.Parameter(typeof(string), "value");
                    Expression valueConverted;
                    if (prop.PropertyType == typeof(string))
                        valueConverted = valueParam;
                    else
                    {
                        var parseMethod = prop.PropertyType.GetMethod("Parse", new Type[] { typeof(string) });
                        if (parseMethod != null)
                            valueConverted = Expression.Call(parseMethod, valueParam);
                        else if (prop.PropertyType.IsValueType)
                            valueConverted = Expression.Convert(
                                Expression.Call(typeof(Convert), "ChangeType", null, valueParam,
                                    Expression.Constant(prop.PropertyType)),
                                prop.PropertyType);
                        else
                            valueConverted = Expression.Constant(null, prop.PropertyType);
                    }
                    var setterExpr = Expression.Assign(Expression.Property(castedEntity, prop.Name), valueConverted);
                    var setterLambda = Expression.Lambda<Action<IEntityWithId, string>>(setterExpr, entityParam, valueParam);

                    _textBindings.Add(new TextBinding
                    {
                        Box = control as TextBox,
                        Getter = getterLambda.Compile(),
                        Setter = setterLambda.Compile()
                    });
                }
            }
            if (AutoWireClearErrors)
            {
                var boxes = _textBindings.Where(b => b.Box != null).Select(b => (Control)b.Box).ToArray();
                if (boxes.Length > 0) WireClearFieldErrorsOnTextChanged(boxes);
            };
        }


        protected virtual Dictionary<string, Control> FieldControlMap
        {
            get
            {
                if (_fieldControlMap != null) return _fieldControlMap;
                _fieldControlMap = new Dictionary<string, Control>(StringComparer.OrdinalIgnoreCase);
                var dtoType = _typedController != null ? _typedController.DtoType : null;
                if (dtoType == null) return _fieldControlMap;

                foreach (var prop in dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    var fca = prop.GetCustomAttribute<FieldControlAttribute>();
                    if (fca == null) continue;

                    var ctlField = GetType().GetField(fca.ControlName,
                        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (ctlField == null) continue;

                    var ctl = ctlField.GetValue(this) as Control;
                    if (ctl != null && !_fieldControlMap.ContainsKey(prop.Name))
                        _fieldControlMap[prop.Name] = ctl;
                }
                return _fieldControlMap;
            }
        }
        #endregion

        #region Data loading
        protected async Task LoadDataAsync()
        {
            EnsureCrudConfiguredIfTyped();
            if (_isLoading) return;
            if (Grid == null) return;

            _isLoading = true;
            SetBusy(true, "Loading...");
            try
            {
                await OnBeforeLoadAsync();

                if (_typedController != null)
                {
                    await _typedController.LoadAsync(_cts.Token);

                    if (UseDefaultNavigator && _navigator == null)
                        InitializeNavigatorIfNeeded();

                    if (_bindingSource == null)
                        _bindingSource = new BindingSource();

                    if (_typedBindingList == null)
                        _typedBindingList = new BindingList<object>();

                    _typedBindingList.RaiseListChangedEvents = false;
                    _typedBindingList.Clear();
                    foreach (var o in _typedController.LiveUntypedItems)
                        _typedBindingList.Add(o);
                    _typedBindingList.RaiseListChangedEvents = true;

                    // >>> MOD: once we have real items, switch DataSource from the Type to the actual list (only if still a Type placeholder)
                    if (_bindingSource.DataSource is Type)
                        _bindingSource.DataSource = _typedBindingList;

                    ConfigureGrid(Grid);

                    if (Grid.DataSource != _bindingSource)
                        Grid.DataSource = _bindingSource;

                    // Ensure bindings fully push and establish a current item
                    _bindingSource.ResetBindings(false);
                    if (_bindingSource.Count > 0 && _bindingSource.Position < 0)
                    {
                        try { _bindingSource.Position = 0; } catch { /* log if desired */ }
                    }

                    WireGridDataErrorOnce();
                    WireGridSelectionEventsOnce();

                    RefreshSearchColumns(); // update column scope options

                    SetStatusText("Loaded " + _typedController.LiveUntypedItems.Count + " records.");
                    ClearRetryLink();
                    GoFirst();
                    await OnAfterLoadAsync();
                    return;
                }

                // Legacy path
                var result = await _service.GetAllAsync(_cts.Token);
                _allItems = result != null ? new List<IEntityWithId>(result) : new List<IEntityWithId>();
                _items = result != null ? new BindingList<IEntityWithId>(result.ToList()) : new BindingList<IEntityWithId>();

                if (UseDefaultNavigator && _navigator == null)
                    InitializeNavigatorIfNeeded();

                Grid.SuspendLayout();
                try
                {
                    if (_bindingSource == null) _bindingSource = new BindingSource();
                    _bindingSource.DataSource = _items;

                    ConfigureGrid(Grid);
                    if (Grid.DataSource != _bindingSource)
                        Grid.DataSource = _bindingSource;

                    WireGridDataErrorOnce();
                    WireGridSelectionEventsOnce();
                }
                finally
                {
                    Grid.ResumeLayout();
                }

                RefreshSearchColumns();

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
                ShowError("Load", ex, async delegate { await LoadDataAsync(); });
            }
            finally
            {
                _isLoading = false;
                _hasLoadedOnce = true;
                SetBusy(false);
            }
        }
        #endregion

        #region Save / Update / Delete (unchanged logic except status)
        protected async Task SaveOrUpdateAsync()
        {
            EnsureCrudConfiguredIfTyped();
            if (_isMutating) return;
            if (Grid == null) return;

            _isMutating = true;
            SetBusy(true, "Saving...");
            try
            {
                await OnBeforeSaveAsync();

                if (_typedController != null)
                {
                    var currentObj = SafeCurrent();
                    var model = currentObj ?? _typedController.CreateNew();

                    foreach (var b in _textBindings)
                        if (b.Box != null)
                            b.Setter((IEntityWithId)model, b.Box.Text);

                    var validationMessage = RunValidation((IEntityWithId)model);
                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        if (ShowValidationErrorsOnlyInValidationTextBox)
                            SetStatusText("Validation failed, record not saved!");
                        else
                            SetStatusText("Validation failed: " + validationMessage);
                        return;
                    }

                    var saved = await _typedController.SaveAsync(model, _cts.Token);
                    SetStatusText("Saved (ID=" + _typedController.GetId(saved) + ")");
                    if (ErrorDisplayControl != null) SetErrorDisplay("");

                    await OnAfterSaveAsync((IEntityWithId)saved);
                    await LoadDataAsync();
                    ClearErrorDisplay();
                    ClearFormFields();
                    return;
                }

                var current = GetSelectedEntity();
                var dto = BuildModelFromForm(current);

                var legacyValidation = RunValidation(dto);
                if (!string.IsNullOrEmpty(legacyValidation))
                {
                    SetStatusText("Validation failed: " + legacyValidation);
                    return;
                }

                var savedLegacy = await _service.UpsertAsync(dto, _cts.Token);
                SetStatusText("Saved (ID=" + GetEntityId(savedLegacy) + ")");
                await OnAfterSaveAsync(savedLegacy);
                await LoadDataAsync();
                ClearFormFields();
            }
            catch (OperationCanceledException)
            {
                SetStatusText("Save canceled.");
                myErrorProvider?.Clear();
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
            EnsureCrudConfiguredIfTyped();
            if (_isMutating) return;
            if (Grid == null) return;

            _isMutating = true;
            SetBusy(true, "Deleting...");
            try
            {
                if (_typedController != null)
                {
                    var entity = SafeCurrent();
                    if (entity == null)
                    {
                        MessageBox.Show(this, "Select a row to delete.", "Delete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var id = _typedController.GetId(entity);
                    if (ConfirmDelete(GetDeleteConfirmationText((IEntityWithId)entity)) != DialogResult.Yes)
                        return;

                    await OnBeforeDeleteAsync(id, (IEntityWithId)entity);
                    var ok = await _typedController.DeleteAsync(id, _cts.Token);
                    SetStatusText(ok ? "Deleted (ID=" + id + ")" : "Delete failed (ID=" + id + ")");
                    await OnAfterDeleteAsync(id, ok);
                    await LoadDataAsync();
                    return;
                }

                var legacyEntity = GetSelectedEntity();
                if (legacyEntity == null)
                {
                    MessageBox.Show(this, "Select a row to delete.", "Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var legacyId = GetEntityId(legacyEntity);
                if (ConfirmDelete(GetDeleteConfirmationText(legacyEntity)) != DialogResult.Yes)
                    return;

                await OnBeforeDeleteAsync(legacyId, legacyEntity);
                var okLegacy = await _service.DeleteAsync(legacyId, _cts.Token);
                SetStatusText(okLegacy ? "Deleted (ID=" + legacyId + ")" : "Delete failed (ID=" + legacyId + ")");
                await OnAfterDeleteAsync(legacyId, okLegacy);
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
        #endregion

        #region Public / model helpers
        public IEntityWithId GetEntity()
        {
            var current = SafeCurrent() as IEntityWithId;
            if (current == null) return _entity;
            return BuildModelFromForm(current);
        }

        public virtual void LoadEntity(IEntityWithId entity)
        {
            _entity = entity;
        }

        protected IEntityWithId BuildModelFromForm(IEntityWithId current)
        {
            var dto = current ?? Activator.CreateInstance<IEntityWithId>();
            if (current != null && dto != null)
                dto.ID = current.ID;

            foreach (var b in _textBindings)
                if (b.Box != null)
                    b.Setter(dto, b.Box.Text);

            return dto;
        }

        protected void ClearFormFields()
        {
            ClearFormFieldsCore();
            Grid?.ClearSelection();
        }

        protected void ClearFormFieldsCore()
        {
            foreach (var b in _textBindings)
                if (b.Box != null)
                    b.Box.Text = string.Empty;
        }

        protected void ClearErrorDisplay()
        {
            SetErrorDisplay("");
        }

        protected void SetErrorDisplay(string message)
        {
            if (ErrorDisplayControl == null) return;
            if (ErrorDisplayControl is Label lbl)
                lbl.Text = message ?? "";
            else if (ErrorDisplayControl is TextBox txt)
                txt.Text = message ?? "";
        }

        protected void SetFieldError(Control ctl, string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<Control, string>(SetFieldError), ctl, message);
                return;
            }
            if (myErrorProvider == null || ctl == null) return;
            myErrorProvider.SetError(ctl, string.IsNullOrWhiteSpace(message) ? string.Empty : message);
        }
        #endregion

        #region Validation
        protected virtual string RunValidation(IEntityWithId entity)
        {
            if (StructuredValidator != null && entity != null)
            {
                EnsureErrorProvider();
                myErrorProvider?.Clear();
                ClearErrorDisplay();

                var errors = StructuredValidator(entity);
                var list = errors != null ? errors.ToList() : new List<ValidationError>();
                if (list.Count == 0) return null;

                var messages = new List<string>();
                foreach (var err in list)
                {
                    if (err == null || string.IsNullOrWhiteSpace(err.Message)) continue;
                    messages.Add(err.Message);
                    if (!string.IsNullOrEmpty(err.Property))
                    {
                        if (FieldControlMap.TryGetValue(err.Property, out var ctl) && ctl != null)
                        {
                            myErrorProvider.SetIconAlignment(ctl, ErrorIconAlignment.MiddleRight);
                            myErrorProvider.SetIconPadding(ctl, 0);
                            SetFieldError(ctl, err.Message);
                        }
                    }
                }

                if (messages.Count > 0)
                {
                    ShowValidationErrors(messages);
                    foreach (var kv in FieldControlMap)
                    {
                        var c = kv.Value;
                        if (c != null && myErrorProvider.GetError(c) != "")
                        {
                            c.Focus();
                            break;
                        }
                    }
                    return ErrorDisplayControl != null ? ErrorDisplayControl.Text :
                        string.Join(Environment.NewLine, messages.ToArray());
                }
                return null;
            }
            return ValidateBeforeSave(entity);
        }

        protected virtual string ValidateBeforeSave(IEntityWithId entity) { return null; }

        protected void ShowValidationErrors(IList<string> errors)
        {
            if (ErrorDisplayControl == null) return;
            ErrorDisplayControl.Text = (errors != null && errors.Count > 0)
                ? string.Join(Environment.NewLine, errors)
                : "";
        }
        #endregion

        #region Busy / status / error display
        protected void SetBusy(bool busy, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
                SetStatusText(message);

            try { UseWaitCursor = busy; } catch { }
            foreach (var c in BusyControls)
                if (c != null) c.Enabled = !busy;

            if (StatusProgress != null)
            {
                StatusProgress.Visible = busy;
                StatusProgress.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            }
        }

        protected virtual void SetStatusText(string text)
        {
            if (!ShowErrorsInStatusLabel) return;

            if (StatusStripLabel != null)
            {
                StatusStripLabel.Text = text ?? "";
                if (string.IsNullOrEmpty(StatusStripLabel.ToolTipText))
                    StatusStripLabel.ToolTipText = StatusStripLabel.Text;
            }
            else if (StatusLabel != null)
            {
                StatusLabel.Text = text ?? "";
            }
        }

        protected void ShowError(string context, Exception ex, Func<Task> retryAsync)
        {
            var friendly = GetFriendlyErrorMessage(ex);

            if (ShowErrorsInStatusBar)
                SetStatusText(context + " failed: " + friendly);

            SetErrorDisplay(friendly);

            if (StatusStripLabel == null || !ShowErrorsInStatusBar) return;

            if (_statusRetryClickHandler != null)
            {
                StatusStripLabel.Click -= _statusRetryClickHandler;
                _statusRetryClickHandler = null;
            }

            if (retryAsync != null)
            {
                StatusStripLabel.IsLink = true;
                _statusRetryClickHandler = async delegate
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

        protected virtual string GetFriendlyErrorMessage(Exception ex)
        {
            if (ex == null) return "Unknown error.";
            if (ex is OperationCanceledException || ex is TaskCanceledException) return "Operation canceled.";
            if (ex is TimeoutException) return "The server took too long to respond.";
            if (ex is HttpRequestException) return "Network error.";
            var msg = ex.Message;
            return string.IsNullOrWhiteSpace(msg) ? ex.GetType().Name : msg;
        }
        #endregion

        #region Navigation helpers
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

        // Replace existing NavigateToRow with this hardened version.
        protected void NavigateToRow(int rowIndex)
        {
            var grid = Grid;
            if (grid == null) return;

            // Abort if a load/filter just cleared rows
            if (rowIndex < 0 || rowIndex >= grid.Rows.Count) return;

            var row = grid.Rows[rowIndex];
            if (row == null || row.IsNewRow) return;

            // If the BindingSource is data source ensure its position is coherent
            if (_bindingSource != null && grid.DataSource == _bindingSource)
            {
                int count = _bindingSource.Count;
                if (count == 0)
                {
                    // Nothing to navigate
                    return;
                }
                if (rowIndex >= count)
                {
                    // Underlying list shrank; clamp or bail
                    rowIndex = Math.Min(count - 1, grid.Rows.Count - 1);
                    if (rowIndex < 0) return;
                    row = grid.Rows[rowIndex];
                    if (row.IsNewRow) return;
                }

                if (_bindingSource.Position != rowIndex)
                {
                    try { _bindingSource.Position = rowIndex; }
                    catch { /* ignore – will re-validate below */ }
                }
            }

            // Reconfirm after possible position adjustment
            if (rowIndex < 0 || rowIndex >= grid.Rows.Count) return;

            grid.ClearSelection();
            row.Selected = true;

            DataGridViewCell firstVisibleCell = null;
            foreach (DataGridViewCell c in row.Cells)
                if (c.Visible)
                {
                    firstVisibleCell = c;
                    break;
                }

            if (firstVisibleCell != null)
            {
                try
                {
                    grid.CurrentCell = firstVisibleCell; // May trigger data-binding re-sync
                }
                catch (ArgumentOutOfRangeException) { return; }
                catch (InvalidOperationException) { return; }
                catch (IndexOutOfRangeException) { return; }
            }

            // Safely set scrolling row (guard against "operation cannot be performed" during layout)
            if (rowIndex >= 0 && rowIndex < grid.RowCount)
            {
                try { grid.FirstDisplayedScrollingRowIndex = rowIndex; } catch { }
            }

            // Only populate form fields if we still have a valid current entity
            try
            {
                PopulateFormFieldsFromGrid(rowIndex);
            }
            catch { /* swallow to keep navigation safe */ }
        }

        protected void PopulateFormFieldsFromGrid(int rowIndex)
        {
            var entity = SafeCurrent() as IEntityWithId;

            // Fallback: if BindingSource.Position is still -1, derive entity directly from the row
            if (entity == null)
            {
                var grid = Grid;
                if (grid != null &&
                    rowIndex >= 0 &&
                    rowIndex < grid.Rows.Count &&
                    !grid.Rows[rowIndex].IsNewRow)
                {
                    entity = grid.Rows[rowIndex].DataBoundItem as IEntityWithId;

                    // If we retrieved an entity, try to advance the BindingSource for future calls
                    if (entity != null && _bindingSource != null && _bindingSource.Position < 0)
                    {
                        try { _bindingSource.Position = rowIndex; } catch { }
                    }
                }
            }

            if (entity == null) return;

            foreach (var b in _textBindings)
                if (b.Box != null)
                    b.Box.Text = b.Getter(entity) ?? string.Empty;

            ClearErrorDisplay();
            myErrorProvider?.Clear();
            SetStatusText("");
            SetErrorDisplay("");
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

        protected int GetEntityId(IEntityWithId entity)
        {
            if (entity == null) return 0;
            var cast = entity as IEntityWithId;
            return cast != null ? cast.ID : 0;
        }

        protected virtual string GetDeleteConfirmationText(IEntityWithId entity)
        {
            int id = 0;
            try { if (entity != null) id = GetEntityId(entity); } catch { }
            return id > 0 ? "Delete selected record (ID=" + id + ")?" : "Delete selected record?";
        }

        protected virtual DialogResult ConfirmDelete(string message)
        {
            return MessageBox.Show(this,
                message ?? "Delete selected record?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
        }

        // Rationale:
        // 1. Avoid selecting when the BindingSource has no items (Position would be -1).
        // 2. If the grid has not yet materialized rows (Rows.Count == 0) after data binding,
        //    defer selection via BeginInvoke so DataGridView can finish creating rows.
        // 3. Only navigate when we find a non-new row.
        // 4. Prevent premature SetStatusText("First record.") when there are actually no data rows.
        protected void GoFirst(bool allowDefer = true)
        {
            var grid = Grid;
            if (grid == null)
            {
                SetStatusText("No grid.");
                return;
            }

            // If there is a BindingSource, use its count as the authoritative source of items.
            if (_bindingSource == null || _bindingSource.Count == 0)
            {
                SetStatusText("No records.");
                return;
            }

            // If the binding source has items but the grid has not yet created rows, defer once.
            if (grid.Rows.Count == 0 && allowDefer)
            {
                // Defer so DataGridView finishes its initial layout / row generation.
                BeginInvoke(new Action(() => GoFirst(false)));
                return;
            }

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                var row = grid.Rows[i];
                if (row != null && !row.IsNewRow)
                {
                    NavigateToRow(i);
                    SetStatusText("First record.");
                    return;
                }
            }

            // If we reach here, either only the NewRow template exists or no usable rows appeared.
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

        protected void GoNext()
        {
            if (Grid == null) return;
            var rows = Grid.Rows;
            int lastIndex = -1;
            for (int i = rows.Count - 1; i >= 0; i--)
                if (!rows[i].IsNewRow) { lastIndex = i; break; }
            if (lastIndex == -1) { SetStatusText("No records."); return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                (Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : -1);

            if (currentIndex == -1)
            {
                for (int i = 0; i < rows.Count; i++)
                    if (!rows[i].IsNewRow) { currentIndex = i; break; }
                if (currentIndex == -1) { SetStatusText("No records."); return; }
            }

            if (currentIndex >= lastIndex)
            {
                NavigateToRow(lastIndex);
                SetStatusText("Already at last.");
                return;
            }

            for (int i = currentIndex + 1; i <= lastIndex; i++)
                if (!rows[i].IsNewRow) { NavigateToRow(i); SetStatusText("Next record."); return; }

            NavigateToRow(lastIndex);
        }

        protected void GoPrevious()
        {
            if (Grid == null) return;
            var rows = Grid.Rows;

            int firstIndex = -1;
            for (int i = 0; i < rows.Count; i++)
                if (!rows[i].IsNewRow) { firstIndex = i; break; }

            if (firstIndex == -1) { SetStatusText("No records."); return; }

            int currentIndex = Grid.SelectedRows.Count > 0 ? Grid.SelectedRows[0].Index :
                (Grid.CurrentCell != null ? Grid.CurrentCell.RowIndex : firstIndex);

            if (currentIndex <= firstIndex)
            {
                NavigateToRow(firstIndex);
                SetStatusText("Already at first.");
                return;
            }

            for (int i = currentIndex - 1; i >= firstIndex; i--)
                if (!rows[i].IsNewRow) { NavigateToRow(i); SetStatusText("Previous record."); return; }

            NavigateToRow(firstIndex);
        }
        #endregion

        #region Grid / columns
        protected virtual void ConfigureGrid(DataGridView grid)
        {
            if (grid.Columns.Count > 0) return;

            ApplyDefaultGridSettings(grid);
            DefineColumns(grid);

            if (grid.Columns.Count == 0 && _typedController != null && AutoGenerateColumnsFromAttributes)
                TryBuildAutoColumns(grid);

            if (grid.Columns.Count == 0)
                grid.AutoGenerateColumns = true;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DefaultCellStyle.NullValue = "";
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            grid.ColumnHeaderMouseClick -= Grid_ColumnHeaderMouseClick;
            grid.ColumnHeaderMouseClick += Grid_ColumnHeaderMouseClick;
        }

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
        }

        protected virtual void DefineColumns(DataGridView grid) { }

        private void TryBuildAutoColumns(DataGridView grid)
        {
            if (_typedController == null) return;
            var dtoType = _typedController.DtoType;
            if (dtoType == null) return;

            if (!_autoColumnCache.TryGetValue(dtoType, out var meta))
            {
                meta = BuildColumnMetadata(dtoType);
                _autoColumnCache[dtoType] = meta;
            }

            foreach (var m in meta.OrderBy(x => x.Order))
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = m.Property,
                    DataPropertyName = m.Property,
                    HeaderText = m.Header,
                    Width = m.Width,
                    ReadOnly = m.ReadOnly,
                    Visible = !m.Hidden,
                    AutoSizeMode = m.Fill ? DataGridViewAutoSizeColumnMode.Fill : DataGridViewAutoSizeColumnMode.None
                };
                grid.Columns.Add(col);
            }
        }

        private List<GeneratedGridColumn> BuildColumnMetadata(Type dtoType)
        {
            var list = new List<GeneratedGridColumn>();

            var decorated = dtoType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new { Prop = p, Attr = p.GetCustomAttribute<GridColumnAttribute>(true) })
                .Where(x => x.Attr != null)
                .ToList();

            if (decorated.Count > 0)
            {
                foreach (var d in decorated)
                {
                    list.Add(new GeneratedGridColumn
                    {
                        Property = d.Prop.Name,
                        Header = string.IsNullOrWhiteSpace(d.Attr.Header) ? d.Prop.Name : d.Attr.Header,
                        Order = d.Attr.Order,
                        Width = d.Attr.Width <= 0 ? 100 : d.Attr.Width,
                        Fill = d.Attr.Fill,
                        Hidden = d.Attr.Hidden,
                        ReadOnly = d.Attr.ReadOnly
                    });
                }
                return list;
            }

            var simpleProps = dtoType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && (p.PropertyType.IsValueType || p.PropertyType == typeof(string)))
                .ToList();

            int order = 0;
            foreach (var p in simpleProps)
            {
                list.Add(new GeneratedGridColumn
                {
                    Property = p.Name,
                    Header = p.Name,
                    Order = order++,
                    Width = 100,
                    Fill = false,
                    Hidden = false,
                    ReadOnly = true
                });
            }
            return list;
        }

        private void Grid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid == null) return;

            var column = grid.Columns[e.ColumnIndex];
            var propertyName = column.DataPropertyName;

            if (_typedController != null)
            {
                bool ascending = grid.SortOrder != SortOrder.Ascending;
                var sorted = _typedController.Sort(propertyName, ascending);

                _typedBindingList.RaiseListChangedEvents = false;
                try
                {
                    _typedBindingList.Clear();
                    foreach (var o in sorted) _typedBindingList.Add(o);
                }
                finally
                {
                    _typedBindingList.RaiseListChangedEvents = true;
                    _bindingSource.ResetBindings(false);
                }
                return;
            }

            bool asc = grid.SortOrder != SortOrder.Ascending;
            var sortedLegacy = asc
                ? _items.OrderBy(x => x.GetType().GetProperty(propertyName).GetValue(x, null)).ToList()
                : _items.OrderByDescending(x => x.GetType().GetProperty(propertyName).GetValue(x, null)).ToList();

            _items.Clear();
            for (int i = 0; i < sortedLegacy.Count; i++)
                _items.Add(sortedLegacy[i]);

            grid.Refresh();
        }
        #endregion

        #region Search (Enhanced 1–7)
        private void ApplySearch()
        {
            if (_searchBox == null) return;

            var raw = _searchBox.Text ?? string.Empty;
            if (_isWatermarkActive || string.Equals(raw, SearchWatermark, StringComparison.Ordinal))
                raw = string.Empty;

            var query = raw.Trim();
            bool restrictColumns = _searchSelectedColumns.Count > 0;

            // ---------- TYPED PATH ----------
            if (_typedController != null)
            {
                if (_bindingSource == null)
                    _bindingSource = new BindingSource();

                if (_bindingSource.DataSource != _typedBindingList)
                    _bindingSource.DataSource = _typedBindingList;

                int previouslySelectedId = 0;

                // Safely capture currently selected entity ID (only if a valid current item exists)
                if (_bindingSource.Count > 0 && _bindingSource.Position >= 0)
                {
                    object currentObj = null;
                    try { currentObj = _bindingSource.Current; } catch { currentObj = null; }
                    if (currentObj != null)
                    {
                        try { previouslySelectedId = _typedController.GetId(currentObj); } catch { previouslySelectedId = 0; }
                    }
                }

                IEnumerable<object> source;
                if (string.IsNullOrEmpty(query))
                {
                    source = _typedController.LiveUntypedItems;
                }
                else if (_searchMode == SearchMode.Regex)
                {

                    Regex regex = null;
                    try
                    {
                        regex = new Regex(query, RegexOptions.IgnoreCase);
                        _lastRegexInvalid = false;
                        SetSearchBoxError(false, null);
                    }
                    catch (Exception ex)
                    {
                        if (!_lastRegexInvalid)
                        {
                            SetStatusText("Invalid regex pattern.");
                            SetSearchBoxError(true, ex.Message);
                            _lastRegexInvalid = true;
                        }
                        // Show no results if regex is invalid
                        _typedBindingList.Clear();
                        _bindingSource.ResetBindings(false);
                        //UpdateSearchStatus(0, _typedController.LiveUntypedItems.Count);
                        return;
                    }

                    source = _typedController.LiveUntypedItems
                        .Where(o => MatchesScopedRegex(o, regex, _typedController.DtoType));
                }
                else if (_searchMode == SearchMode.Fuzzy)
                {
                    source = _typedController.LiveUntypedItems
                        .Where(o => MatchesScopedFuzzy(o, query, _typedController.DtoType));
                }
                else if (!restrictColumns)
                {
                    // Use controller filter for normal mode
                    source = _typedController.Filter(query) ?? Enumerable.Empty<object>();
                }
                else
                {
                    source = _typedController.LiveUntypedItems
                        .Where(o => MatchesScoped(o, query, _typedController.DtoType));
                }

                // Rebuild filtered list
                _typedBindingList.RaiseListChangedEvents = false;
                try
                {
                    _typedBindingList.Clear();
                    foreach (var o in source)
                        _typedBindingList.Add(o);
                }
                finally
                {
                    _typedBindingList.RaiseListChangedEvents = true;
                    _bindingSource.ResetBindings(false);
                }

                UpdateSearchStatus(_typedBindingList.Count, _typedController.LiveUntypedItems.Count);

                // Restore previous selection if still present
                if (previouslySelectedId != 0 && _typedBindingList.Count > 0)
                {
                    for (int i = 0; i < _typedBindingList.Count; i++)
                    {
                        int id = 0;
                        try { id = _typedController.GetId(_typedBindingList[i]); } catch { }
                        if (id == previouslySelectedId)
                        {
                            _bindingSource.Position = i;
                            goto TypedDone;
                        }
                    }
                    // Fallback to first if old selection not found
                    _bindingSource.Position = 0;
                }
                else if (_typedBindingList.Count > 0)
                {
                    // Nothing previously selected but we have results – select first
                    _bindingSource.Position = 0;
                }
                else
                {
                    // No results – leave position at -1 (no current)
                }

            TypedDone:
                return;
            }

            // ---------- LEGACY PATH ----------
            if (_bindingSource == null)
                _bindingSource = new BindingSource { DataSource = _items };

            int legacyPreviouslySelectedId = 0;
            if (_bindingSource.Count > 0 && _bindingSource.Position >= 0)
            {
                var currentLegacy = _bindingSource.Current as IEntityWithId;
                if (currentLegacy != null)
                    legacyPreviouslySelectedId = currentLegacy.ID;
            }

            List<IEntityWithId> filtered;
            if (string.IsNullOrEmpty(query))
            {
                filtered = _allItems;
            }
            else
            {
                filtered = _allItems
                    .Where(x => MatchesScoped(x, query, x.GetType(), legacy: true))
                    .ToList();
            }

            _items.RaiseListChangedEvents = false;
            try
            {
                _items.Clear();
                foreach (var item in filtered)
                    _items.Add(item);
            }
            finally
            {
                _items.RaiseListChangedEvents = true;
                _bindingSource.ResetBindings(false);
            }

            UpdateSearchStatus(_items.Count, _allItems.Count);

            if (legacyPreviouslySelectedId != 0 && _items.Count > 0)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    if (_items[i].ID == legacyPreviouslySelectedId)
                    {
                        _bindingSource.Position = i;
                        return;
                    }
                }
                // Previous not found – select first
                _bindingSource.Position = 0;
            }
            else if (_items.Count > 0)
            {
                _bindingSource.Position = 0;
            }
            // else: no results -> Position remains -1
        }

        private bool _lastRegexInvalid = false;
        private bool MatchesScoped(object obj, string query, Type type, bool legacy = false)
        {
            if (obj == null || string.IsNullOrWhiteSpace(query)) return false;
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.CanRead &&
                                        (p.PropertyType.IsValueType || p.PropertyType == typeof(string)));

            if (_searchSelectedColumns.Count > 0)
                props = props.Where(p => _searchSelectedColumns.Contains(p.Name));

            if (_searchMode == SearchMode.Regex)
            {
                // Regex should be compiled and error handled in ApplySearch, not here.
                throw new InvalidOperationException("Regex mode should use MatchesScopedRegex.");
            }
            else
            {
                _lastRegexInvalid = false;
                SetSearchBoxError(false, null);
                foreach (var p in props)
                {
                    object v;
                    try { v = p.GetValue(obj, null); } catch { continue; }
                    if (v == null) continue;
                    var str = v.ToString();
                    if (str != null &&
                        str.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                        return true;
                }
                return false;
            }
        }



        // Helper to set visual error on the search box
        private void SetSearchBoxError(bool isError, string tooltip)
        {
            if (_searchBox == null) return;
            _searchBox.BackColor = isError ? Color.MistyRose : SystemColors.Window;
            _searchBox.ToolTipText = isError ? (tooltip ?? "Invalid regex pattern.") : "Search";
        }

        private void UpdateSearchStatus(int filtered, int total)
        {
            if (filtered == 0)
                SetStatusText($"No matches (0 of {total}).");
            else
                SetStatusText($"{filtered} match(es) of {total}.");
        }

        private void ClearSearch()
        {
            _suppressProgrammaticSearch = true;
            try
            {
                _searchBox.Text = "";
                ApplySearchWatermark();

                // Reset selected columns (optional, if you want to clear column filters)
                _searchSelectedColumns.Clear();
                RefreshSearchColumns();

                // Optionally reset search mode to Normal
                _searchMode = SearchMode.Normal;
                foreach (ToolStripMenuItem item in _searchModeButton.DropDownItems)
                    item.Checked = item.Text == "Normal";

                SetSearchBoxError(false, null);
            }
            finally
            {
                _suppressProgrammaticSearch = false;
            }
            ApplySearch();
            _searchBox.Focus();
        }
        #endregion

        #region Event wiring (selection + clear errors)
        private void WireGridSelectionEventsOnce()
        {
            if (_gridEventsWired) return;
            var grid = Grid;
            if (grid == null) return;

            grid.SelectionChanged += delegate
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
                catch { }
            };
            _gridEventsWired = true;
        }

        protected void WireClearFieldErrorsOnTextChanged(params Control[] controls)
        {
            if (controls == null) return;
            foreach (var c in controls)
            {
                if (c == null) continue;
                c.TextChanged -= ClearErrorOnChange;
                c.TextChanged += ClearErrorOnChange;
            }

            void ClearErrorOnChange(object sender, EventArgs e)
            {
                try
                {
                    var epField = GetType()
                        .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                        .FirstOrDefault(f => typeof(ErrorProvider).IsAssignableFrom(f.FieldType));

                    var ep = epField != null ? epField.GetValue(this) as ErrorProvider : null;
                    if (ep != null && sender is Control ctl)
                        ep.SetError(ctl, string.Empty);
                }
                catch { }
            }
        }

        protected void WireGridDataErrorOnce()
        {
            if (_gridDataErrorWired) return;
            var grid = Grid;
            if (grid == null) return;

            grid.DataError += delegate (object s, DataGridViewDataErrorEventArgs e)
            {
                e.ThrowException = false;
                SetStatusText("Display error in grid data.");
                if (StatusStripLabel != null && e.Exception != null)
                    StatusStripLabel.ToolTipText = e.Exception.Message;
            };
            _gridDataErrorWired = true;
        }
        #endregion

        #region Navigator initialization (enhanced with search controls)
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

            // Search controls
            _navigator.Items.Add(new ToolStripSeparator());
            _navigator.Items.Add(new ToolStripLabel("Search:"));
            _searchBox = new ToolStripTextBox { Name = "tsSearchBox", ToolTipText = "Search", AutoSize = false, Width = 160 };
            _searchButton = new ToolStripButton("Search") { ToolTipText = "Execute search" };
            _searchButton.Click += (s, e) => ApplySearch();
            _searchBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    ApplySearch();
                    Grid?.Focus();
                }
            };
            _searchBox.GotFocus += (s, e) => RemoveWatermarkIfActive();
            _searchBox.LostFocus += (s, e) => ApplySearchWatermark();
            _searchBox.TextChanged += (s, e) =>
            {
                SetSearchBoxError(false, null); // Clear error as user edits
                if (_suppressProgrammaticSearch) return;
                if (_isWatermarkActive) return;
                if (_liveSearchEnabled)
                    RestartSearchDebounce();
            };

            // Clear button (feature 1)
            _searchClearButton = new ToolStripButton("X")
            {
                ToolTipText = "Clear search",
                DisplayStyle = ToolStripItemDisplayStyle.Text
            };
            _searchClearButton.Click += (s, e) => ClearSearch();

            // Columns selector (feature 6)
            _searchColumnsButton = new ToolStripDropDownButton("Cols")
            {
                ToolTipText = "Select columns to search (unchecked = all)"
            };
            _searchColumnsButton.DropDownItemClicked += (s, e) =>
            {
                // Handled individually in item CheckedChanged.
            };

            // Live toggle (feature 7)
            _searchLiveToggleButton = new ToolStripButton("Live")
            {
                CheckOnClick = true,
                Checked = true,
                ToolTipText = "Toggle live (debounced) search"
            };
            _searchLiveToggleButton.CheckedChanged += (s, e) =>
            {
                _liveSearchEnabled = _searchLiveToggleButton.Checked;
                if (_liveSearchEnabled)
                    RestartSearchDebounce();
            };

            _searchModeButton = new ToolStripDropDownButton("Mode")
            {
                ToolTipText = "Select search mode"
            };
            var normalItem = new ToolStripMenuItem("Normal") { Checked = true };
            var regexItem = new ToolStripMenuItem("Regex");
            var fuzzyItem = new ToolStripMenuItem("Fuzzy");

            normalItem.Click += (s, e) =>
            {
                _searchMode = SearchMode.Normal;
                normalItem.Checked = true;
                regexItem.Checked = false;
                ApplySearch();
            };
            regexItem.Click += (s, e) =>
            {
                _searchMode = SearchMode.Regex;
                normalItem.Checked = false;
                regexItem.Checked = true;
                ApplySearch();
            };
            fuzzyItem.Click += (s, e) =>
            {
                _searchMode = SearchMode.Fuzzy;
                normalItem.Checked = false;
                regexItem.Checked = false;
                fuzzyItem.Checked = true;
                ApplySearch();
            };
            _searchModeButton.DropDownItems.Add(normalItem);
            _searchModeButton.DropDownItems.Add(regexItem);
            _searchModeButton.DropDownItems.Add(fuzzyItem);

            _navigator.Items.AddRange(new ToolStripItem[]
            {
                _searchBox,
                _searchButton,
                _searchClearButton,
                _searchColumnsButton,
                _searchLiveToggleButton,
                _searchModeButton
            });

            ApplySearchWatermark();
            InitializeSearchDebounce();

            // Language selector
            if (ShowLanguageSelector && LanguageComboBox == null)
            {
                _navigator.Items.Add(new ToolStripSeparator());

                LanguageComboBox = new ToolStripComboBox
                {
                    Name = "tscLanguage",
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    ToolTipText = "Select UI language",
                    AutoSize = false,
                    Width = 130
                };
                LanguageApplyButton = new ToolStripButton("Apply")
                {
                    ToolTipText = "Apply selected language",
                    DisplayStyle = ToolStripItemDisplayStyle.Text
                };

                _navigator.Items.Add(new ToolStripLabel("Lang:"));
                _navigator.Items.Add(LanguageComboBox);
                _navigator.Items.Add(LanguageApplyButton);

                var localizationService = ResolveLocalizationService();
                OnLanguageSelectorCreated();
                _langHelper = new LanguageUiHelper(() => localizationService, () => Grid, OnAfterLanguageApplied);
                _langHelper.PopulateLanguages(LanguageComboBox);

                LanguageComboBox.SelectedIndexChanged += (s, e) => _langHelper.ApplySelectedLanguage(this, LanguageComboBox);
                LanguageApplyButton.Click += (s, e) => _langHelper.ApplySelectedLanguage(this, LanguageComboBox);
            }

            OnCreateAdditionalNavigatorItems(_navigator);
            Controls.Add(_navigator);
            _navigator.BringToFront();
        }

        private void InitializeSearchDebounce()
        {
            _searchDebounceTimer = new System.Windows.Forms.Timer { Interval = SearchDebounceMs };
            _searchDebounceTimer.Tick += (s, e) =>
            {
                _searchDebounceTimer.Stop();
                ApplySearch();
            };
        }

        private bool MatchesScopedRegex(object obj, Regex regex, Type type)
        {
            if (obj == null || regex == null) return false;
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            .Where(p => p.CanRead &&
                                        (p.PropertyType.IsValueType || p.PropertyType == typeof(string)));

            if (_searchSelectedColumns.Count > 0)
                props = props.Where(p => _searchSelectedColumns.Contains(p.Name));

            foreach (var p in props)
            {
                object v;
                try { v = p.GetValue(obj, null); } catch { continue; }
                if (v == null) continue;
                var str = v.ToString();
                if (str != null && regex.IsMatch(str))
                    return true;
            }
            return false;
        }

        private void RestartSearchDebounce()
        {
            _searchDebounceTimer.Stop();
            _searchDebounceTimer.Start();
        }

        private void ApplySearchWatermark()
        {
            if (_searchBox == null) return;
            if (!string.IsNullOrWhiteSpace(_searchBox.Text)) return;
            _isWatermarkActive = true;
            _suppressProgrammaticSearch = true;
            try
            {
                _searchBox.ForeColor = SystemColors.GrayText;
                _searchBox.Text = SearchWatermark;
            }
            finally
            {
                _suppressProgrammaticSearch = false;
            }
        }

        private void RemoveWatermarkIfActive()
        {
            if (!_isWatermarkActive) return;
            _isWatermarkActive = false;
            _suppressProgrammaticSearch = true;
            try
            {
                _searchBox.Text = "";
                _searchBox.ForeColor = SystemColors.WindowText;
            }
            finally
            {
                _suppressProgrammaticSearch = false;
            }
        }

        private void RefreshSearchColumns()
        {
            if (_searchColumnsButton == null) return;
            _searchColumnsButton.DropDownItems.Clear();

            var names = GetSearchablePropertyNames();
            // '(All)' item
            var allItem = new ToolStripMenuItem("(All)")
            {
                Checked = _searchSelectedColumns.Count == 0
            };
            allItem.Click += (s, e) =>
            {
                _searchSelectedColumns.Clear();
                RefreshSearchColumns();
                ApplySearch();
            };
            _searchColumnsButton.DropDownItems.Add(allItem);
            if (names != null)
            {
                foreach (var n in names)
                {
                    var itm = new ToolStripMenuItem(n)
                    {
                        Checked = _searchSelectedColumns.Contains(n),
                        CheckOnClick = true
                    };
                    itm.CheckedChanged += (s, e) =>
                    {
                        if (itm.Checked) _searchSelectedColumns.Add(n);
                        else _searchSelectedColumns.Remove(n);
                        // Update '(All)'
                        allItem.Checked = _searchSelectedColumns.Count == 0;
                        // If live search, re-apply
                        if (_liveSearchEnabled)
                            RestartSearchDebounce();
                    };
                    _searchColumnsButton.DropDownItems.Add(itm);
                }
            }
        }

        private IEnumerable<string> GetSearchablePropertyNames()
        {
            Type t = null;
            if (_typedController != null)
                t = _typedController.DtoType;
            else
            {
                var first = _allItems.FirstOrDefault() ?? _items.FirstOrDefault();
                if (first != null) t = first.GetType();
            }
            if (t == null) return Enumerable.Empty<string>();

            return t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead &&
                            (p.PropertyType.IsValueType || p.PropertyType == typeof(string)))
                .Select(p => p.Name)
                .OrderBy(n => n)
                .ToList();
        }
        #endregion

        #region Status strip
        protected void InitializeStatusStripAndLabel()
        {
            if (_statusStrip == null)
            {
                _statusStrip = new StatusStrip();
                Controls.Add(_statusStrip);
                _statusStrip.BringToFront();
            }

            if (_statusProgress == null)
            {
                _statusProgress = new ToolStripProgressBar
                {
                    Name = "StatusProgress",
                    Visible = false,
                    Style = ProgressBarStyle.Blocks
                };
                _statusStrip.Items.Add(_statusProgress);
            }

            if (_statusStripLabel == null)
            {
                _statusStripLabel = new ToolStripStatusLabel
                {
                    Name = "StatusLabel",
                    Text = "",
                    Spring = false
                };
                _statusStrip.Items.Add(_statusStripLabel);
            }
        }
        #endregion

        #region Hooks / overrides
        protected virtual Task OnBeforeLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterLoadAsync() { return Task.CompletedTask; }
        protected virtual Task OnBeforeSaveAsync() { return Task.CompletedTask; }
        protected virtual Task OnAfterSaveAsync(IEntityWithId saved) { return Task.CompletedTask; }
        protected virtual Task OnBeforeDeleteAsync(int id, IEntityWithId entity) { return Task.CompletedTask; }
        protected virtual Task OnAfterDeleteAsync(int id, bool ok) { return Task.CompletedTask; }
        protected virtual void OnLanguageSelectorCreated() { }
        protected virtual void OnAfterLanguageApplied(string code)
        {
            ControlLocalizer.ApplyRightToLeftLayout(this, code);
            StatusStripLabel.Text = "Language applied: " + code;
        }
        protected virtual void OnCreateAdditionalNavigatorItems(BindingNavigator navigator) { }
        protected virtual Task OnRefreshRequestedAsync() { return LoadDataAsync(); }
        protected virtual Task OnDeleteRequestedAsync() { return DeleteSelectedAsync(); }
        protected virtual Task OnSaveRequestedAsync() { return SaveOrUpdateAsync(); }
        #endregion

        #region Lifecycle
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
        #endregion

        #region Localization helpers
        protected virtual ILocalizationService ResolveLocalizationService()
        {
            var li = LanguageComboBox != null && LanguageComboBox.SelectedItem is LanguageUiHelper.LanguageItem
                ? (LanguageUiHelper.LanguageItem)LanguageComboBox.SelectedItem
                : null;
            var code = li != null ? li.Code : "en-US";
            return new LocalizationService(code, GetType().Name);
        }
        protected virtual IUiLocalizationManager ResolveUiLocalizationManager()
        {
            return new InMemoryUiLocalizationManager();
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
            }
            catch { }
            return false;
        }
        #endregion

        #region Support types
        private sealed class GeneratedGridColumn
        {
            public string Property;
            public string Header;
            public int Order;
            public int Width;
            public bool Fill;
            public bool Hidden;
            public bool ReadOnly;
        }

        private sealed class TextBinding
        {
            public TextBox Box;
            public Func<IEntityWithId, string> Getter;
            public Action<IEntityWithId, string> Setter;
        }

        public sealed class DesignTimeCrudService : ICrudService<IEntityWithId>
        {
            public Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken)) =>
                Task.FromResult(false);
            public Task<IReadOnlyList<IEntityWithId>> GetAllAsync(CancellationToken ct = default(CancellationToken)) =>
                Task.FromResult((IReadOnlyList<IEntityWithId>)new List<IEntityWithId>());
            public Task<IEntityWithId> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken)) =>
                Task.FromResult<IEntityWithId>(null);
            public Task<IEntityWithId> UpsertAsync(IEntityWithId dto, CancellationToken ct = default(CancellationToken)) =>
                Task.FromResult(dto);
        }
        #endregion

        #region Designer stub
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new System.Drawing.Size(680, 307);
            Name = "BaseGridCrudForm";
            ResumeLayout(false);
        }
        #endregion

        #region Retry link helper
        private void ClearRetryLink()
        {
            if (StatusStripLabel == null)
                return;

            if (_statusRetryClickHandler != null)
            {
                StatusStripLabel.Click -= _statusRetryClickHandler;
                _statusRetryClickHandler = null;
            }

            StatusStripLabel.IsLink = false;
            if (!string.IsNullOrEmpty(StatusStripLabel.ToolTipText))
                StatusStripLabel.ToolTipText = string.Empty;
        }
        #endregion

        #region Keyboard shortcuts (feature 5)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                _searchBox?.Focus();
                if (_searchBox != null && !_isWatermarkActive)
                    _searchBox.SelectAll();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                if (_searchBox != null && !_isWatermarkActive && !string.IsNullOrEmpty(_searchBox.Text))
                {
                    ClearSearch();
                    return true;
                }
            }
            if (keyData == Keys.Enter && _searchBox != null && _searchBox.Focused)
            {
                ApplySearch();
                Grid?.Focus();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        //Implement Fuzzy Matching (Levenshtein Distance)
        private int LevenshteinDistance(string a, string b)
        {
            if (string.IsNullOrEmpty(a)) return b?.Length ?? 0;
            if (string.IsNullOrEmpty(b)) return a.Length;

            int[,] d = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++) d[i, 0] = i;
            for (int j = 0; j <= b.Length; j++) d[0, j] = j;

            for (int i = 1; i <= a.Length; i++)
            {
                for (int j = 1; j <= b.Length; j++)
                {
                    int cost = (a[i - 1] == b[j - 1]) ? 0 : 1;
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[a.Length, b.Length];
        }

        private bool MatchesScopedFuzzy(object obj, string query, Type type, int maxDistance = 2)
        {
            if (obj == null || string.IsNullOrWhiteSpace(query)) return false;
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && (p.PropertyType.IsValueType || p.PropertyType == typeof(string)));

            if (_searchSelectedColumns.Count > 0)
                props = props.Where(p => _searchSelectedColumns.Contains(p.Name));

            foreach (var p in props)
            {
                object v;
                try { v = p.GetValue(obj, null); } catch { continue; }
                if (v == null) continue;
                var str = v.ToString();
                if (str != null && LevenshteinDistance(str.ToLowerInvariant(), query.ToLowerInvariant()) <= maxDistance)
                    return true;
            }
            return false;
        }

        #endregion

        /// <summary>
        /// Safely returns the current item in the BindingSource or null if there is
        /// no valid current (Position == -1, list empty, or Current throws).
        /// Centralizes the guard to eliminate "Index -1 does not have a value." errors.
        /// </summary>
        private object SafeCurrent()
        {
            if (_bindingSource == null) return null;
            if (_bindingSource.Count == 0) return null;
            if (_bindingSource.Position < 0) return null;
            try { return _bindingSource.Current; }
            catch { return null; }
        }



    }
}