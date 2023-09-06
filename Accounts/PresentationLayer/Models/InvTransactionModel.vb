Imports AATM.Accounts.BusinessLayer

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class InvTransactionModel
        Inherits InvRequestHeader

        Public Property InvTransactionDetails As List(Of InvTransactionDetailModel)

    End Class

    Public Class InvRequestHeader

        Public Property Amount As Decimal
        Public Property Cancelled As Boolean
        Public Property DateCreated As Date
        Public Property IdNo As Int32
        Public Property InvTransTypeIdNo As Int16
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TransactionDate As Date?
        Public Property UserIdNo As Int32
        Public Property WarehouseIdNo As Int16
        Public Property WarehouseToIdNo As Int16?
    End Class

    Public Class InvRequestModel

        Public Property InvTransactionRequests As List(Of InvTransactionModel)
        Public Property WarehouseIdNo As Int16

    End Class


End Namespace