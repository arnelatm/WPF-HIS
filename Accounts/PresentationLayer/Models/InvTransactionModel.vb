Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class InvTransactionModel


        Public Property Amount As Decimal
        Public Property BranchIdNo As Int16
        Public Property Cancelled As Boolea
        Public Property DateCreated As Date
        Public Property IdNo As Int16
        Public Property InvTransTypeIdNo As Int16
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TransactionDate As Date
        Public Property UserIdNo As Int16
        Public Property WarehouseIdNo As Int16
        Public Property WarehouseToIdNo As Int16?

    End Class

End Namespace