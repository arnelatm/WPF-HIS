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
    [DesignTimeVisible(false)]
    public class BaseGridCrudForm : Form // IEntityWithId constraint at Runtime
    {
        private StatusStrip _statusStrip;
        private ToolStripStatusLabel _statusStripLabel;
        private ToolStripProgressBar _statusProgress;

        protected readonly ICrudService<IEntityWithId> _service;
        protected IEntityWithId _entity;
        protected BindingList<IEntityWithId> _items = new BindingList<IEntityWithId>();

        // Shared ErrorProvider
        protected ErrorProvider myErrorProvider;

        // Auto column cache
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

        // -------------------- HARDENED CRUD CONFIGURATION SUPPORT --------------------
        private bool _crudConfigured;
        private Type _configuredDtoType;
        protected bool IsCrudConfigured { get { return _crudConfigured; } }

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
                StructuredValidator = delegate (IEntityWithId e) { return cfg.Validator((TDto)e); };

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

        // ================== FLUENT CONFIGURATION (optional helper) ==================
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

            public CrudFormFluent<TDto> Service(Func<ICrudService<TDto>> factory)
            {
                _cfg.ServiceFactory = factory;
                return this;
            }
            public CrudFormFluent<TDto> Validator(Func<TDto, IEnumerable<ValidationError>> validator)
            {
                _cfg.Validator = validator;
                return this;
            }
            public CrudFormFluent<TDto> ErrorDisplay(Control control)
            {
                _cfg.ErrorDisplayControl = control;
                return this;
            }
            public CrudFormFluent<TDto> AutoBind(bool enabled = true)
            {
                _cfg.AutoBindFields = enabled;
                return this;
            }
            public void Apply()
            {
                if (_applied) throw new InvalidOperationException("CrudFormFluent already applied.");
                _form.ConfigureCrudForm(_cfg);
                _applied = true;
            }
        }

        // ================== OPTIONAL ATTRIBUTE AUTO-CONFIG (if DTO decorated) ==================
        private static readonly Dictionary<Type, CrudFormAttribute> _crudAttrCache =
            new Dictionary<Type, CrudFormAttribute>();

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
                validator = dto =>
                {
                    if (rulesObj == null)
                        return Enumerable.Empty<ValidationError>();

                    var dtoValidatorType = typeof(DtoValidator);

                    // Cacheable: find candidate static Validate methods with exactly 2 parameters
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
                            // Only support single generic argument methods like Validate<T>(T dto, RulesType rules)
                            if (m.GetGenericArguments().Length != 1)
                                continue;

                            try
                            {
                                closed = m.MakeGenericMethod(typeof(TDto));
                            }
                            catch
                            {
                                continue;
                            }
                        }

                        var pars = closed.GetParameters();
                        // First param must accept TDto
                        if (!pars[0].ParameterType.IsAssignableFrom(typeof(TDto)))
                            continue;

                        // Second param must accept the runtime rulesObj
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
                        catch
                        {
                            return Enumerable.Empty<ValidationError>();
                        }
                    }

#if DEBUG
                    // Optional: help diagnose missing / mismatched signatures during development
                    System.Diagnostics.Debug.WriteLine(
                        $"DtoValidator.Validate method not found for DTO '{typeof(TDto).Name}' and rules type '{rulesObj.GetType().FullName}'.");
#endif

                    return Enumerable.Empty<ValidationError>();
                };  
            }
            ;  


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

        // -------------------- Constructors --------------------
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

        // -------------------- Virtual feature flags --------------------
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

        // -------------------- Core exposed members --------------------
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
                if (this.DesignMode) return true;
                if (this.Site != null && this.Site.DesignMode) return true;
                return false;
            }
        }

        // -------------------- Initialization / Setup --------------------
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
            Disposed += delegate { try { if (myErrorProvider != null) myErrorProvider.Dispose(); } catch { } };
        }

        // -------------------- Typed Controller Init --------------------
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

        // -------------------- Auto-binding --------------------
        protected void AutoBindFormFields(Type dtoType)
        {
            var properties = dtoType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in properties)
            {
                var controlAttr = prop.GetCustomAttribute<AATM.Contracts.Attributes.FieldControlAttribute>();
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
                    var fca = prop.GetCustomAttribute<AATM.Contracts.Attributes.FieldControlAttribute>();
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

        // -------------------- Data Loading --------------------
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

        // -------------------- Save / Update --------------------
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

        // -------------------- Delete --------------------
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

        // -------------------- Support / Utility Methods --------------------
        public IEntityWithId GetEntity()
        {
            var current = _bindingSource != null ? _bindingSource.Current as IEntityWithId : null;
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
            if (Grid != null)
                Grid.ClearSelection();
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
            var lbl = ErrorDisplayControl as Label;
            if (lbl != null) lbl.Text = message ?? "";
            var txt = ErrorDisplayControl as TextBox;
            if (txt != null) txt.Text = message ?? "";
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

        protected virtual string ValidateBeforeSave(IEntityWithId entity) { return null; }

        protected void ShowValidationErrors(IList<string> errors)
        {
            if (ErrorDisplayControl == null) return;
            if (errors != null && errors.Count > 0)
                ErrorDisplayControl.Text = string.Join(Environment.NewLine, errors);
            else
                ErrorDisplayControl.Text = "";
        }

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

        // -------------------- Navigation helpers --------------------
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

        // -------------------- Grid / Columns --------------------
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

        // -------------------- Search --------------------
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

        // -------------------- Event Wiring --------------------
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

        // -------------------- Navigator --------------------
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

        // -------------------- Status strip --------------------
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

        // -------------------- Hooks (override points) --------------------
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

        // -------------------- Lifecycle --------------------
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

        // -------------------- Misc Helpers --------------------
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

        // -------------------- Support Types --------------------
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

        // -------------------- Design-time safe service --------------------
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

        // Simple InitializeComponent placeholder (base)
        private void InitializeComponent()
        {
            SuspendLayout();
            ClientSize = new System.Drawing.Size(680, 307);
            Name = "BaseGridCrudForm";
            ResumeLayout(false);
        }

        // Add this helper (restored) somewhere near other private helpers in the class
        private void ClearRetryLink()
        {
            // Safely remove previously wired retry link behavior on the status label
            if (StatusStripLabel == null)
                return;

            if (_statusRetryClickHandler != null)
            {
                StatusStripLabel.Click -= _statusRetryClickHandler;
                _statusRetryClickHandler = null;
            }

            StatusStripLabel.IsLink = false;
            // Optionally clear tooltip so stale error/retry hints disappear
            if (!string.IsNullOrEmpty(StatusStripLabel.ToolTipText))
                StatusStripLabel.ToolTipText = string.Empty;
        }

    }
}