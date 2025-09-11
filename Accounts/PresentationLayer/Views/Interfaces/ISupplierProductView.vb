Imports AATM.Accounts.BusinessLayer
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ISupplierProductView
        Inherits IView

        Property IdNo As Int32
        Property ProductIdNo As Int32
        Property SupplierIdNo As Int32
        Property SupplierProductCode As String
        Property SupplierProductName As String
        Property SupplierProductNameAra As String

    End Interface

End Namespace
