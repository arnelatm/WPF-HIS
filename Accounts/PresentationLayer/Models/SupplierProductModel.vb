Imports AATM.Accounts.BusinessLayer

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SupplierProductModel
        Public Property IdNo As Int32
        Public Property ProductIdNo As Int32
        Public Property SupplierIdNo As Int32
        Public Property SupplierProductCode As String
        Public Property SupplierProductName As String
        Public Property SupplierProductNameAra As String
    End Class

End Namespace