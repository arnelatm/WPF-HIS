
Namespace PresentationLayer.Models
    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PurchaseItemModel
        Public Property Errors As List(Of String)
        Public Property DateCreated As Date?
        Public Property IdNo As Integer
        Public Property PurchaseItemCode As String
        Public Property PurchaseItemName As String
        Public Property PurchaseItemNameAra As String
        Public Property CategoryIdNo As Integer
        Public Property GlAccountIdNo As Integer
        Public Property VatAccountIdNo As Integer
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
End NameSpace