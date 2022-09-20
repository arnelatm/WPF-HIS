Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DrugMapModel
        Public Property Batch As String
        Public Property BranchID As String
        Public Property CashPrice As Decimal
        Public Property Expiry As Date
        Public Property GTIN As String
        Public Property IdNo As Int32
        Public Property Item_Code As String
        Public Property ItemNameEnglish As String
        Public Property PurchaseNo As Decimal
        Public Property Quantity As Decimal
        Public Property SerialNo As String

    End Class

End Namespace