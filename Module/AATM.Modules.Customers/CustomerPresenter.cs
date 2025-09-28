using System;
using System.Collections.Generic;
using System.Linq;
using AATM.Contracts;
using AATM.Contracts.Interfaces.Services;
using AATM.Core.Localization;

namespace AATM.Modules.Customers
{
    /// <summary>
    /// Presenter for the Customer management UI.
    /// </summary>
    public class CustomerPresenter
    {
        private const string ModuleName = "CustomerModule";

        private readonly ICustomerView _view;
        private readonly ICustomerService _service;
        private readonly ILogger _logger;
        private readonly IMessagingService _messagingService;
        private readonly ILocalizationService _localizationService;
        private readonly IUiLocalizationManager _uiLocalizationManager;

        public CustomerPresenter(
            ICustomerView view,
            ICustomerService service,
            ILogger logger,
            IMessagingService messagingService,
            ILocalizationService localizationService,
            IUiLocalizationManager uiLocalizationManager)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _messagingService = messagingService ?? throw new ArgumentNullException(nameof(messagingService));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
            _uiLocalizationManager = uiLocalizationManager ?? throw new ArgumentNullException(nameof(uiLocalizationManager));

            // NOTE: Your ICustomerView interface (as pasted) has no events.
            // If events exist in the real interface, wire them here.
            // Otherwise call the presenter methods explicitly from the view’s code-behind.
        }

        // Call this from the view once its WinForms Form handle is created (e.g. OnLoad).
        public void Initialize()
        {
            try
            {
                LoadCustomersIntoView();
                ProvideLanguagesToView();
                ApplyLocalizationToView();
                _logger.LogInfo("Customer view initialized.");
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                _messagingService.ShowError("Failed to initialize Customer view: " + ex.Message);
            }
        }

        public void ChangeLanguage(string languageCode)
        {
            if (string.IsNullOrWhiteSpace(languageCode))
                return;

            try
            {
                // Assuming richer localization service with SetLanguage (unify contracts!)
                TrySetLanguageIfSupported(languageCode);
                ApplyLocalizationToView();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                _messagingService.ShowError("Language change failed: " + ex.Message);
            }
        }

        public void SaveCustomer(CustomerDTO customer)
        {
            if (customer == null)
            {
                _messagingService.ShowError("No customer data.");
                return;
            }

            var result = _service.SaveCustomer(customer);
            if (result.IsValid)
            {
                _messagingService.ShowSuccess(LocalizeMessage("CustomerSaved", "Customer saved successfully."));
                _view.ClearCustomerDetails();
                LoadCustomersIntoView();
            }
            else
            {
                _messagingService.ShowError(LocalizeMessage(result.ErrorMessage, result.ErrorMessage));
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var result = _service.DeleteCustomer(customerId);
            if (result.IsValid)
            {
                _messagingService.ShowSuccess(LocalizeMessage("CustomerDeleted", "Customer deleted successfully."));
                _view.ClearCustomerDetails();
                LoadCustomersIntoView();
            }
            else
            {
                _messagingService.ShowError(LocalizeMessage(result.ErrorMessage, result.ErrorMessage));
            }
        }

        public void EditCustomer(CustomerDTO customer)
        {
            if (customer == null) return;
            _view.DisplayCustomerDetails(customer);
            _view.SetEditMode(true);
        }

        public void ClearEditing()
        {
            _view.ClearCustomerDetails();
            _view.SetEditMode(false);
        }

        // -------------------- Internal helpers --------------------

        private void LoadCustomersIntoView()
        {
            var customers = _service.GetCustomers() ?? new List<CustomerDTO>();
            _view.DisplayCustomers(customers);
            _view.SetEditMode(false);
        }

        private void ProvideLanguagesToView()
        {
            List<(string display, string code)> langs;
            try
            {
                langs = _localizationService.GetAvailableLanguages() ?? new List<(string, string)>();
            }
            catch
            {
                langs = new List<(string, string)> { ("English", "en-US") };
            }
            _view.DisplayLanguages(langs);
        }

        private void ApplyLocalizationToView()
        {
            // Register original texts (only needed once, safe to call again)
            var viewAsForm = _view as System.Windows.Forms.Form;
            if (viewAsForm != null)
            {
                _uiLocalizationManager.RegisterFormStrings(viewAsForm, ModuleName, GetCurrentLanguageCode());
            }

            var flat = SafeGetAllStrings();

            // Extract module-specific subset (keys like CustomerModule.SomeKey)
            var modulePairs = flat
                .Where(kvp => kvp.Key.StartsWith(ModuleName + ".", StringComparison.OrdinalIgnoreCase))
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            _view.SetLocalizedText(_uiLocalizationManager, modulePairs);

            // Apply RTL
            bool rtl = TryGetRtl();
            _view.SetRightToLeft(rtl);
        }

        private IDictionary<string, string> SafeGetAllStrings()
        {
            try
            {
                var dict = _localizationService.GetLocalizedStrings();
                return dict ?? new Dictionary<string, string>();
            }
            catch
            {
                return new Dictionary<string, string>();
            }
        }

        private string LocalizeMessage(string keyOrUiIdentifier, string fallback)
        {
            try
            {
                // If service supports module scoping via a compound key, look it up.
                var fullKey = ModuleName + "." + keyOrUiIdentifier;
                var all = SafeGetAllStrings();
                if (all.TryGetValue(fullKey, out var v) && !string.IsNullOrEmpty(v))
                    return v;

                // Fall back to direct key
                if (all.TryGetValue(keyOrUiIdentifier, out v) && !string.IsNullOrEmpty(v))
                    return v;
            }
            catch { }
            return fallback;
        }

        private bool TryGetRtl()
        {
            try { return _localizationService.IsRightToLeft; } catch { return false; }
        }

        private string GetCurrentLanguageCode()
        {
            // If using the richer LocalizationService, expose CurrentLanguageCode there.
            // If not available, you may need to store an internal field when setting language.
            var prop = _localizationService.GetType().GetProperty("CurrentLanguageCode");
            return prop != null ? prop.GetValue(_localizationService) as string ?? "en-US" : "en-US";
        }

        private void TrySetLanguageIfSupported(string code)
        {
            var mi = _localizationService.GetType().GetMethod("SetLanguage");
            if (mi != null) mi.Invoke(_localizationService, new object[] { code });
        }
    }
}