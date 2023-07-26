Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DrugSaleModel
        Public Property BatchNo As String
        Public Property Expiry As Date?
        Public Property GTin As String
        Public Property IdNo As Int32
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property SaleDate As Date?
        Public Property SerializationNo As String
        Public Property UserIdNo As Int16
    End Class

End Namespace