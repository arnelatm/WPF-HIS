Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PurchaseDetailModel

        Public Property AmtBefVat As Decimal
        Public Property BaseUnitIdNo As Int16
        Public Property BonusQuantity As Int16
        Public Property CategoryIdNo As Int16
        Public Property DiscountAmount As Decimal
        Public Property DiscountPercent As Decimal
        Public Property GrossAmount As Decimal
        Public Property IdNo As Int32
        Public Property NetAmount As Decimal
        Public Property Price As Decimal
        Public Property ProductCode As String
        Public Property ProductIdNo As Int32
        Public Property ProductName As String
        Public Property ProductNameAra As String
        Public Property PurchaseIdNo As Int32
        Public Property Quantity As Int16
        Public Property Sequence As Int16
        Public Property UnitCount As Int16
        Public Property UnitIdNo As Int16
        Public Property UnitCost As Decimal
        Public Property UnitSalesPrice As Decimal
        Public Property VatAmount As Decimal
        Public Property VatPercent As Decimal


    End Class

End Namespace