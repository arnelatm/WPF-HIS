using System;
using System.Collections.Generic;
using AATM.Core.Localization;

namespace AATM.Modules.Customers
{

    /// <summary>
/// Defines the contract for the Customer View.
/// The Presenter interacts with this interface, not the concrete form.
/// </summary>
    public interface ICustomerView
    {

        // Events raised by the View
        event EventHandler LoadView;
        event SaveCustomerEventHandler SaveCustomer;

        delegate void SaveCustomerEventHandler(CustomerDTO customer);
        event EditCustomerEventHandler EditCustomer;

        delegate void EditCustomerEventHandler(CustomerDTO customer);
        event DeleteCustomerEventHandler DeleteCustomer;

        delegate void DeleteCustomerEventHandler(int customerID);
        event EventHandler ClearView;
        event LanguageChangedEventHandler LanguageChanged;

        delegate void LanguageChangedEventHandler(string languageCode);

        // Methods called by the Presenter
        void DisplayCustomers(List<CustomerDTO> customers);
        void ClearCustomerDetails();
        void SetEditMode(bool isEditing);
        void DisplayCustomerDetails(CustomerDTO customer);
        void SetRightToLeft(bool isRtl);
        void DisplayLanguages(List<(string display, string code)> languages);
        // Sub SetLocalizedText(localizedStrings As Dictionary(Of String, String))
        void SetLocalizedText(IUiLocalizationManager uiLocalizationManager, Dictionary<string, string> localizedStrings);
        int GetSelectedCustomerID();
    }
}