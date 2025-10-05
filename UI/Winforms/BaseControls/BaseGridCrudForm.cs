using AATM.Business.Logic.Validators;
using AATM.Contracts.Attributes;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;
using AATM.UI.Winforms.Localization;
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
    /// <summary>
    /// Base WinForms CRUD form that supports:
    /// - Legacy (untyped) CRUD via <see cref="ICrudService{IEntityWithId}"/>
    /// - Typed runtime configuration (designer-safe) via <see cref="ConfigureCrudForm{TDto}"/> or fluent <see cref="ForDto{TDto}"/>
    /// - Optional attribute-based auto configuration (<see cref="CrudFormAttribute"/>)
    /// - Auto-binding of text fields via <see cref="FieldControlAttribute"/>
    /// - Auto column generation via <see cref="GridColumnAttribute"/>
    /// - Validation (structured + legacy) and status/error reporting
    /// - Navigator (record navigation, search, refresh, language, CRUD buttons)
    /// - Localization integration
    /// </summary>
    [DesignTimeVisible(false)]
    public class BaseGridCrudForm : Form // IEntityWithId constraint at Runtime
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
        private ToolStripTextBox _searchBox;
        private ToolStripButton _searchButton;
        private EventHandler _statusRetryClickHandler;
        private BindingList<object> _typedBindingList;
        private IGridCrudController _typedController;

        #endregion

        #region Configuration state

        private bool _crudConfigured;
        private Type _configuredDtoType;

        /// <summary>
        /// Indicates whether typed CRUD has been configured for this instance.
        /// </summary>
        protected bool IsCrudConfigured { get { return _crudConfigured; } }

        /// <summary>
        /// Configuration container used to set up typed CRUD behavior without a generic base class.
        /// </summary>
        protected sealed class CrudFormConfig<TDto>
            where TDto : class, IEntityWithId, new()
        {
            /// <summary>Factory that returns a concrete <see cref="ICrudService{TDto}"/> instance.</summary>
            public Func<ICrudService<TDto>> ServiceFactory { get; set; }
            /// <summary>Structured validator delegate returning zero or more <see cref="ValidationError"/>.</summary>
            public Func<TDto, IEnumerable<ValidationError>> Validator { get; set; }
            /// <summary>Control (Label/TextBox/etc.) to display aggregated validation errors.</summary>
            public Control ErrorDisplayControl { get; set; }
            /// <summary>If true, auto-binds <see cref="TextBox"/> controls discovered via <see cref="FieldControlAttribute"/>.</summary>
            public bool AutoBindFields { get; set; } = true;
            internal bool Applied;
        }

        /// <summary>
        /// One-shot configuration entry for typed DTO support (designer-safe).
        /// Must be called after <c>InitializeComponent()</c>. Enforces single application.
        /// </summary>
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
                StructuredValidator = delegate (IEntityWithId e) { return cfg.Validator((TDto)e); };

#if DEBUG
            if (_typedController != null && _typedController.DtoType != _configuredDtoType)
                throw new InvalidOperationException("Configured DTO type and controller DTO type mismatch.");
#endif
        }

        /// <summary>
        /// Ensures that if a typed controller is present, configuration was properly applied.
        /// Throws if the contract is violated (debugging safety).
        /// </summary>
        protected void EnsureCrudConfiguredIfTyped()
        {
            if (_typedController != null && !_crudConfigured)
                throw new InvalidOperationException("Typed controller initialized without ConfigureCrudForm<> call.");
        }

        #endregion

        #region Fluent configuration

        /// <summary>
        /// Fluent builder entry point for typed configuration (designer-safe generics).
        /// </summary>
        public CrudFormFluent<TDto> ForDto<TDto>()
            where TDto : class, IEntityWithId, new()
        {
            return new CrudFormFluent<TDto>(this);
        }

        /// <summary>
        /// Fluent typed configuration wrapper around <see cref="ConfigureCrudForm{TDto}"/>.
        /// </summary>
        public sealed class CrudFormFluent<TDto>
            where TDto : class, IEntityWithId, new()
        {
            private readonly BaseGridCrudForm _form;
            private readonly CrudFormConfig<TDto> _cfg = new CrudFormConfig<TDto>();
            private bool _applied;
            internal CrudFormFluent(BaseGridCrudForm form) { _form = form; }

            /// <summary>Sets a service factory.</summary>
            public CrudFormFluent<TDto> Service(Func<ICrudService<TDto>> factory)
            {
                _cfg.ServiceFactory = factory;
                return this;
            }

            /// <summary>Sets a structured validator.</summary>
            public CrudFormFluent<TDto> Validator(Func<TDto, IEnumerable<ValidationError>> validator)
            {
                _cfg.Validator = validator;
                return this;
            }

            /// <summary>Sets the error display control to show validation messages.</summary>
            public CrudFormFluent<TDto> ErrorDisplay(Control control)
            {
                _cfg.ErrorDisplayControl = control;
                return this;
            }

            /// <summary>Enables/disables auto field binding.</summary>
            public CrudFormFluent<TDto> AutoBind(bool enabled = true)
            {
                _cfg.AutoBindFields = enabled;
                return this;
            }

            /// <summary>Applies the configuration (one-shot).</summary>
            public void Apply()
            {
                if (_applied) throw new InvalidOperationException("CrudFormFluent already applied.");
                _form.ConfigureCrudForm(_cfg);
                _applied = true;
            }
        }

        #endregion

        #region Attribute auto-config

        private static readonly Dictionary<Type, CrudFormAttribute> _crudAttrCache =
            new Dictionary<Type, CrudFormAttribute>();

        /// <summary>
        /// Automatically configures the form for <typeparamref name="TDto"/> using <see cref="CrudFormAttribute"/> metadata.
        /// Requires that the DTO is decorated with <see cref="CrudFormAttribute"/>.
        /// </summary>
        protected void AutoConfigureFromDto<TDto>()
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
                delegate { return (ICrudService<TDto>)Activator.CreateInstance(attr.ServiceType); };

            Func<TDto, IEnumerable<ValidationError>> validator = null;
            if (attr.ValidatorRulesType != null)
            {
                var flags = BindingFlags.Public | BindingFlags.Static;
                var pi = attr.ValidatorRulesType.GetProperty("Rules", flags);
                var fi = attr.ValidatorRulesType.GetField("Rules", flags);
                object rulesObj = pi != null ? pi.GetValue(null, null) : (fi != null ? fi.GetValue(null) : null);
                if (rulesObj == null)
                    throw new InvalidOperationException("Rules not found or null on " + attr.ValidatorRulesType.FullName);

                // Flexible reflection-based validation invocation
                validator = dto =>
                {
                    if (rulesObj == null)
                        return Enumerable.Empty<ValidationError>();

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
                            try { closed = m.MakeGenericMethod(typeof(TDto)); }
                            catch { continue; }
                        }

                        var pars = closed.GetParameters();
                        if (!pars[0].ParameterType.IsAssignableFrom(typeof(TDto)))
                            continue;
                        if (rulesObj != null && !pars[1].ParameterType.IsInstanceOfType(rulesObj))
                            continue;

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
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Design-time safe constructor (uses <see cref="DesignTimeCrudService"/>).
        /// </summary>
        protected BaseGridCrudForm() : this(() => new DesignTimeCrudService()) { }

        /// <summary>
        /// Constructor allowing runtime injection of a CRUD service factory.
        /// </summary>
        protected BaseGridCrudForm(Func<ICrudService<IEntityWithId>> serviceFactory)
        {
            if (IsDesignTime())
                _service = new DesignTimeCrudService();
            else
                _service = (serviceFactory != null ? serviceFactory() : null) ?? new DesignTimeCrudService();

            InitializeStatusStripAndLabel();
            InitializeNavigatorIfNeeded();
        }

        /// <summary>
        /// Constructor that also records a logical module name (used by localization/status messages).
        /// </summary>
        protected BaseGridCrudForm(string callingModule) : this(() => new DesignTimeCrudService())
        {
            moduleName = callingModule;
        }

        /// <summary>
        /// Constructor accepting an already constructed legacy (untyped) CRUD service.
        /// </summary>
        protected BaseGridCrudForm(ICrudService<IEntityWithId> service)
        {
            _service = service ?? throw new ArgumentNullException("service");
            InitializeNavigatorIfNeeded();
        }

        #endregion

        #region Feature flags (override points)

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

        #region Core exposed members (virtual for flexibility)

        /// <summary>Optional aggregated validation/error message output control.</summary>
        protected Control ErrorDisplayControl { get; set; }

        /// <summary>DataGridView the form operates on. Override in derived form.</summary>
        protected virtual DataGridView Grid { get { return null; } }

        /// <summary>Underlying <see cref="BindingSource"/> used for grid binding (typed or legacy).</summary>
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

        /// <summary>Structured validator (if configured).</summary>
        protected Func<IEntityWithId, IEnumerable<ValidationError>> StructuredValidator { get; set; }

        /// <summary>
        /// Enumerates controls disabled while the form is 'busy'.
        /// Override to add to disable-set (e.g., toolbar, edit panels).
        /// </summary>
        protected virtual IEnumerable<Control> BusyControls
        {
            get
            {
                if (Grid != null) yield return Grid;
            }
        }

        /// <summary>
        /// Design-time detection (robust: license mode / container design mode).
        /// </summary>
        protected bool IsReallyDesignTime
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return true;
                if (this.DesignMode) return true;
                if (this.Site != null && this.Site.DesignMode) return true;
                return false;
            }
        }

        #endregion

        #region Error handling / initialization

        /// <summary>
        /// Ensures an <see cref="ErrorProvider"/> exists and optionally sets the display control for aggregate errors.
        /// </summary>
        protected virtual void InitializeErrorHandling(Control errorDisplayControl = null)
        {
            EnsureErrorProvider();
            ErrorDisplayControl = errorDisplayControl;
        }

        /// <summary>
        /// Creates a shared <see cref="ErrorProvider"/> if missing (non-blinking).
        /// </summary>
        protected void EnsureErrorProvider()
        {
            if (myErrorProvider != null) return;
            myErrorProvider = new ErrorProvider
            {
                BlinkStyle = ErrorBlinkStyle.NeverBlink,
                ContainerControl = this
            };
            Disposed += delegate { try { if (myErrorProvider != null) myErrorProvider.Dispose(); } catch { } };
        }

        #endregion

        #region Typed controller initialization

        /// <summary>
        /// Initializes the typed CRUD controller (runtime generic) and binds a backing list.
        /// </summary>
        protected void InitializeTypedController<TDto>(Func<ICrudService<TDto>> factory)
            where TDto : class, IEntityWithId, new()
        {
            if (factory == null) throw new ArgumentNullException("factory");
            _typedController = new GridCrudController<TDto>(factory());

            if (_bindingSource == null)
                _bindingSource = new BindingSource();

            _typedBindingList = new BindingList<object>();
            _bindingSource.DataSource = _typedBindingList;
        }

        #endregion

        #region Auto field binding

        /// <summary>
        /// Discovers DTO properties decorated with <see cref="FieldControlAttribute"/> and builds
        /// compiled getter/setter delegates to drive simple text field bindings.
        /// </summary>
        /// <param name="dtoType">Runtime DTO type.</param>
        protected void AutoBindFormFields(Type dtoType)
        {
            var properties = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var controlAttr = prop.GetCustomAttribute<FieldControlAttribute>();
                if (controlAttr == null) continue;

                var controlField = GetType().GetField(controlAttr.ControlName,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                var control = controlField != null ? controlField.GetValue(this) as Control : null;
                if (control == null) continue;

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

            if (AutoWireClearErrors)
            {
                var boxes = _textBindings.Where(b => b.Box != null).Select(b => (Control)b.Box).ToArray();
                if (boxes.Length > 0) WireClearFieldErrorsOnTextChanged(boxes);
            }
        }

        /// <summary>
        /// Lazily builds a map of DTO property name -> bound control (using <see cref="FieldControlAttribute"/>).
        /// </summary>
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

        /// <summary>
        /// Loads data either via typed controller (if configured) or via legacy service.
        /// Wires grid events, builds columns, updates status.
        /// </summary>
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

                    _bindingSource.DataSource = _typedController.LiveUntypedItems;
                    ConfigureGrid(Grid);

                    if (Grid.DataSource != _bindingSource)
                        Grid.DataSource = _bindingSource;

                    WireGridDataErrorOnce();
                    WireGridSelectionEventsOnce();

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

        #region Save / Update

        /// <summary>
        /// Persists the current entity (typed or legacy).
        /// Performs validation before calling the service.
        /// </summary>
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
                    var currentObj = _bindingSource != null ? _bindingSource.Current : null;
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

                // Legacy path
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
                if (myErrorProvider != null) myErrorProvider.Clear();
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

        #endregion

        #region Delete

        /// <summary>
        /// Deletes the currently selected entity (typed or legacy) after confirmation.
        /// </summary>
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
                    var entity = _bindingSource != null ? _bindingSource.Current : null;
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

        /// <summary>
        /// Returns the current edited entity (built from bound fields if present).
        /// </summary>
        public IEntityWithId GetEntity()
        {
            var current = _bindingSource != null ? _bindingSource.Current as IEntityWithId : null;
            if (current == null) return _entity;
            return BuildModelFromForm(current);
        }

        /// <summary>
        /// Loads an existing entity into the form (legacy path only).
        /// </summary>
        public virtual void LoadEntity(IEntityWithId entity)
        {
            _entity = entity;
        }

        /// <summary>
        /// Builds a DTO instance from the current text bindings (preserving ID).
        /// </summary>
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

        /// <summary>Clears all bound form fields and deselects grid.</summary>
        protected void ClearFormFields()
        {
            ClearFormFieldsCore();
            if (Grid != null)
                Grid.ClearSelection();
        }

        /// <summary>Clears text in bound text boxes (internal step).</summary>
        protected void ClearFormFieldsCore()
        {
            foreach (var b in _textBindings)
                if (b.Box != null)
                    b.Box.Text = string.Empty;
        }

        /// <summary>Clears aggregate error display.</summary>
        protected void ClearErrorDisplay()
        {
            SetErrorDisplay("");
        }

        /// <summary>
        /// Writes a message into the configured <see cref="ErrorDisplayControl"/>.
        /// </summary>
        protected void SetErrorDisplay(string message)
        {
            if (ErrorDisplayControl == null) return;
            var lbl = ErrorDisplayControl as Label;
            if (lbl != null) lbl.Text = message ?? "";
            var txt = ErrorDisplayControl as TextBox;
            if (txt != null) txt.Text = message ?? "";
        }

        /// <summary>
        /// Sets (or clears) error text on a specific control using the shared <see cref="ErrorProvider"/>.
        /// </summary>
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

        /// <summary>
        /// Runs structured validation (if available) or falls back to <see cref="ValidateBeforeSave"/>.
        /// Returns null/empty if valid; otherwise a message (or aggregated messages).
        /// </summary>
        protected virtual string RunValidation(IEntityWithId entity)
        {
            if (StructuredValidator != null && entity != null)
            {
                EnsureErrorProvider();
                if (myErrorProvider != null) myErrorProvider.Clear();
                ClearErrorDisplay();

                var errors = StructuredValidator(entity);
                var list = errors != null ? errors.ToList() : new List<ValidationError>();
                if (list.Count == 0) return null;

                var messages = new List<string>();
                for (int i = 0; i < list.Count; i++)
                {
                    var err = list[i];
                    if (err == null || string.IsNullOrWhiteSpace(err.Message)) continue;
                    messages.Add(err.Message);

                    if (!string.IsNullOrEmpty(err.Property))
                    {
                        Control ctl;
                        if (FieldControlMap.TryGetValue(err.Property, out ctl) && ctl != null)
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

        /// <summary>
        /// Legacy hook for subclasses (string-based validation). Prefer structured validator.
        /// </summary>
        protected virtual string ValidateBeforeSave(IEntityWithId entity) { return null; }

        /// <summary>
        /// Displays aggregated validation errors in the configured error display control.
        /// </summary>
        protected void ShowValidationErrors(IList<string> errors)
        {
            if (ErrorDisplayControl == null) return;
            if (errors != null && errors.Count > 0)
                ErrorDisplayControl.Text = string.Join(Environment.NewLine, errors);
            else
                ErrorDisplayControl.Text = "";
        }

        #endregion

        #region Busy / status / error display

        /// <summary>
        /// Toggles busy state (disables controls, shows wait cursor and progress bar). Optionally sets status text.
        /// </summary>
        protected void SetBusy(bool busy, string message = null)
        {
            if (!string.IsNullOrEmpty(message))
                SetStatusText(message);

            try { UseWaitCursor = busy; } catch { }
            var controls = BusyControls;
            foreach (var c in controls)
                if (c != null) c.Enabled = !busy;

            if (StatusProgress != null)
            {
                StatusProgress.Visible = busy;
                StatusProgress.Style = busy ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks;
            }
        }

        /// <summary>
        /// Updates status text (StatusStripLabel or custom label) if enabled.
        /// </summary>
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

        /// <summary>
        /// Central error reporting helper (sets status + error display + optional retry link).
        /// </summary>
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

        /// <summary>
        /// Produces user-friendly error messages for known exception types.
        /// </summary>
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

        #region Navigation helpers (grid row / entity positioning)

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

        /// <summary>
        /// Moves selection to a row by index (ignores new-row placeholder).
        /// </summary>
        protected void NavigateToRow(int rowIndex)
        {
            if (Grid == null) return;
            if (rowIndex < 0 || rowIndex >= Grid.Rows.Count) return;

            var row = Grid.Rows[rowIndex];
            if (row.IsNewRow) return;

            Grid.ClearSelection();
            row.Selected = true;

            DataGridViewCell firstVisibleCell = null;
            foreach (DataGridViewCell c in row.Cells)
                if (c.Visible) { firstVisibleCell = c; break; }

            if (firstVisibleCell != null)
                Grid.CurrentCell = firstVisibleCell;

            Grid.FirstDisplayedScrollingRowIndex = rowIndex;
            PopulateFormFieldsFromGrid(rowIndex);
        }

        /// <summary>
        /// Copies the selected row entity into bound text boxes.
        /// </summary>
        protected void PopulateFormFieldsFromGrid(int rowIndex)
        {
            var entity = _bindingSource != null ? _bindingSource.Current as IEntityWithId : null;
            if (entity == null) return;

            foreach (var b in _textBindings)
                if (b.Box != null)
                    b.Box.Text = b.Getter(entity) ?? string.Empty;

            ClearErrorDisplay();
            if (myErrorProvider != null) myErrorProvider.Clear();
            SetStatusText("");
            SetErrorDisplay("");
        }

        /// <summary>
        /// Returns the currently selected entity from the grid (legacy binding path).
        /// </summary>
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

        /// <summary>
        /// Returns the ID for the given entity (safe cast).
        /// </summary>
        protected int GetEntityId(IEntityWithId entity)
        {
            if (entity == null) return 0;
            var cast = entity as IEntityWithId;
            return cast != null ? cast.ID : 0;
        }

        /// <summary>
        /// Builds a confirmation message for deletion (override to add custom tokens).
        /// </summary>
        protected virtual string GetDeleteConfirmationText(IEntityWithId entity)
        {
            int id = 0;
            try { if (entity != null) id = GetEntityId(entity); } catch { }
            return id > 0 ? "Delete selected record (ID=" + id + ")?" : "Delete selected record?";
        }

        /// <summary>
        /// Prompts the user to confirm deletion. Override to customize dialog.
        /// </summary>
        protected virtual DialogResult ConfirmDelete(string message)
        {
            return MessageBox.Show(this,
                message ?? "Delete selected record?",
                "Confirm delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
        }

        /// <summary>Navigate to first non-new row, if present.</summary>
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

        /// <summary>Navigate to last non-new row, if present.</summary>
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

        /// <summary>Navigate to next logical row (bounded).</summary>
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

        /// <summary>Navigate to previous logical row (bounded).</summary>
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

        /// <summary>
        /// Applies default grid settings, defines custom columns, then optionally auto-generates columns from attributes.
        /// </summary>
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

        /// <summary>
        /// Basic consistent grid styling (override to adjust).
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
        }

        /// <summary>
        /// Override to create custom columns manually. If none added, auto generation may occur.
        /// </summary>
        protected virtual void DefineColumns(DataGridView grid) { }

        /// <summary>
        /// Builds columns from <see cref="GridColumnAttribute"/> metadata (cached).
        /// </summary>
        private void TryBuildAutoColumns(DataGridView grid)
        {
            if (_typedController == null) return;
            var dtoType = _typedController.DtoType;
            if (dtoType == null) return;

            List<GeneratedGridColumn> meta;
            if (!_autoColumnCache.TryGetValue(dtoType, out meta))
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
                    AutoSizeMode = m.Fill
                        ? DataGridViewAutoSizeColumnMode.Fill
                        : DataGridViewAutoSizeColumnMode.None
                };
                grid.Columns.Add(col);
            }
        }

        /// <summary>
        /// Builds metadata for grid columns from attributes or heuristics.
        /// </summary>
        private List<GeneratedGridColumn> BuildColumnMetadata(Type dtoType)
        {
            var list = new List<GeneratedGridColumn>();

            var decorated = dtoType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Select(p => new
                {
                    Prop = p,
                    Attr = p.GetCustomAttribute<GridColumnAttribute>(true)
                })
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
                .Where(p =>
                    p.CanRead &&
                    (p.PropertyType.IsValueType || p.PropertyType == typeof(string)))
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

        /// <summary>
        /// Handles header clicks to provide simple sorting (typed or legacy).
        /// </summary>
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

        #region Search

        /// <summary>
        /// Applies filter text (simple contains across property string values) for typed or legacy mode.
        /// </summary>
        private void ApplySearch()
        {
            if (_searchBox == null) return;
            var query = _searchBox.Text != null ? _searchBox.Text.Trim() : null;

            if (_typedController != null)
            {
                var filtered = _typedController.Filter(query);
                _typedBindingList.RaiseListChangedEvents = false;
                try
                {
                    _typedBindingList.Clear();
                    foreach (var o in filtered) _typedBindingList.Add(o);
                }
                finally
                {
                    _typedBindingList.RaiseListChangedEvents = true;
                    _bindingSource.ResetBindings(false);
                }
                return;
            }

            if (string.IsNullOrEmpty(query))
            {
                _items.Clear();
                foreach (var item in _allItems)
                    _items.Add(item);
                return;
            }

            var filteredLegacy = _allItems.Where(x =>
                x.GetType().GetProperties()
                    .Any(p =>
                    {
                        var v = p.GetValue(x, null);
                        return v != null &&
                               v.ToString().IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
                    })).ToList();

            _items.Clear();
            foreach (var item in filteredLegacy)
                _items.Add(item);
        }

        #endregion

        #region Event wiring

        /// <summary>
        /// Wires grid selection events once (ignores row header pseudo rows).
        /// </summary>
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

        /// <summary>
        /// Wires TextChanged handlers to clear per-field validation errors.
        /// </summary>
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

        /// <summary>
        /// Wires a global grid DataError handler to suppress exceptions and show status.
        /// </summary>
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

        #region Navigator initialization

        /// <summary>
        /// Creates a binding navigator with navigation, CRUD, refresh, search, language (if enabled).
        /// </summary>
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

            // Search
            _searchBox = new ToolStripTextBox { Name = "tsSearchBox", ToolTipText = "Search" };
            _searchButton = new ToolStripButton("Search") { ToolTipText = "Search" };
            _searchButton.Click += (s, e) => ApplySearch();
            _searchBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) ApplySearch(); };
            _navigator.Items.Add(new ToolStripSeparator());
            _navigator.Items.Add(new ToolStripLabel("Search:"));
            _navigator.Items.Add(_searchBox);
            _navigator.Items.Add(_searchButton);

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

        #endregion

        #region Status strip

        /// <summary>
        /// Ensures the status strip, progress bar and label exist.
        /// </summary>
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

        /// <summary>
        /// Loads initial data automatically (unless disabled) when the form is first shown.
        /// </summary>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (IsReallyDesignTime) return;
            if (AutoLoadOnShown && !_hasLoadedOnce)
            {
                var _ = LoadDataAsync();
            }
        }

        /// <summary>
        /// Cancels outstanding work when form closes.
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try { _cts.Cancel(); } catch { }
            base.OnFormClosing(e);
        }

        #endregion

        #region Localization helpers

        /// <summary>
        /// Resolves an <see cref="ILocalizationService"/> (override to inject).
        /// </summary>
        protected virtual ILocalizationService ResolveLocalizationService()
        {
            var li = LanguageComboBox != null && LanguageComboBox.SelectedItem is LanguageUiHelper.LanguageItem
                ? (LanguageUiHelper.LanguageItem)LanguageComboBox.SelectedItem
                : null;
            var code = li != null ? li.Code : "en-US";
            return new LocalizationService(code, GetType().Name);
        }

        /// <summary>
        /// Resolves a UI localization manager (override for persistence/backing store).
        /// </summary>
        protected virtual IUiLocalizationManager ResolveUiLocalizationManager()
        {
            return new InMemoryUiLocalizationManager();
        }

        /// <summary>
        /// Static design-time detection (IDE process heuristics).
        /// </summary>
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

        /// <summary>
        /// Design-time (no-op) CRUD service; prevents designer crashes due to null service.
        /// </summary>
        public sealed class DesignTimeCrudService : ICrudService<IEntityWithId>
        {
            public Task<bool> DeleteAsync(int id, CancellationToken ct = default(CancellationToken))
            {
                return Task.FromResult(false);
            }
            public Task<IReadOnlyList<IEntityWithId>> GetAllAsync(CancellationToken ct = default(CancellationToken))
            {
                return Task.FromResult((IReadOnlyList<IEntityWithId>)new List<IEntityWithId>());
            }
            public Task<IEntityWithId> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
            {
                return Task.FromResult<IEntityWithId>(null);
            }
            public Task<IEntityWithId> UpsertAsync(IEntityWithId dto, CancellationToken ct = default(CancellationToken))
            {
                return Task.FromResult(dto);
            }
        }

        #endregion

        #region Designer stub

        /// <summary>
        /// Minimal InitializeComponent stub (real forms override / provide their own).
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new System.Drawing.Size(680, 307);
            Name = "BaseGridCrudForm";
            ResumeLayout(false);
        }

        #endregion

        #region Retry link helper

        /// <summary>
        /// Removes an active retry link from the status label (if previously set by <see cref="ShowError"/>).
        /// </summary>
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
    }
}