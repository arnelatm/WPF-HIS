Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PurchaseDetailModel

        Public Property BonusQuantity As Int32
        Public Property DiscountAmount As Decimal
        Public Property IdNo As Int32
        Public Property NetAmount As Decimal
        Public Property Price As Decimal
        Public Property ProductIdNo As Int32
        Public Property ProductName As String
        Public Property PurchaseIdNo As Int32
        Public Property Quantity As Int32
        Public Property Sequence As Int16
        Public Property UnitIdNo As Int32
        Public Property VatAmount As Decimal
        Public Property VatPercent As Decimal

    End Class

End Namespace