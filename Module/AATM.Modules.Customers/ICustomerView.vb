Imports AATM.Core.Localization
Imports AATM.Modules.Customers
Imports System.Collections.Generic
Imports System.Drawing

''' <summary>
''' Defines the contract for the Customer View.
''' The Presenter interacts with this interface, not the concrete form.
''' </summary>
Public Interface ICustomerView

    ' Events raised by the View
    Event LoadView As EventHandler
    Event SaveCustomer(customer As CustomerDTO)
    Event EditCustomer(customer As CustomerDTO)
    Event DeleteCustomer(customerID As Integer)
    Event ClearView As EventHandler
    Event LanguageChanged(languageCode As String)

    ' Methods called by the Presenter
    Sub DisplayCustomers(customers As List(Of CustomerDTO))
    Sub ClearCustomerDetails()
    Sub SetEditMode(isEditing As Boolean)
    Sub DisplayCustomerDetails(customer As CustomerDTO)
    Sub SetRightToLeft(isRtl As Boolean)
    Sub DisplayLanguages(languages As List(Of (display As String, code As String)))
    'Sub SetLocalizedText(localizedStrings As Dictionary(Of String, String))
    Sub SetLocalizedText(uiLocalizationManager As IUiLocalizationManager, localizedStrings As Dictionary(Of String, String))
    Function GetSelectedCustomerID() As Integer
End Interface