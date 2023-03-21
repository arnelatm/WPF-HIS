Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class CategoryModel

        Public Property Errors As List(Of String)
        
        Public Property IdNo As Int16
        Public Property CategoryCode As String
        Public Property CategoryName As String
        Public Property CategoryNameAra As String
        Public Property PurchaseAccountIdNo As Int16
        Public Property SaleAccountIdNo As Int16
        Public Property VatPurchaseAccountIdNo As Int16
        Public Property VatSaleAccountIdNo As Int16
        Public Property VatPercentage As Decimal
        Public Property Notes As String

    End Class

End Namespace