Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ProductModel
        Public Property Errors As List(Of String)
        Public Property DateCreated As Date?
        Public Property IdNo As Int32
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property ProductNameAra As String
        Public Property CategoryIdNo As Int16
        Public Property GlAccountIdNo As Int16?
        Public Property VatPurchaseAccountIdNo As Int16?
        Public Property VatSaleAccountIdNo As Int16?
        Public Property Unit1 As String
        Public Property Unit2 As String
        Public Property Unit3 As String
        Public Property Unit1Ara As String
        Public Property Unit2Ara As String
        Public Property Unit3Ara As String
        Public Property StdPrice1 As Decimal
        Public Property StdPrice2 As Decimal
        Public Property StdPrice3 As Decimal
        Public Property Active As Boolean

    End Class

End Namespace