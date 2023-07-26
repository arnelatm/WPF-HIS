Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class SaleDetailModel

        Public Property AmtBefVat As Decimal
        Public Property BaseUnitIdNo As Int16
        Public Property BatchNo As String
        Public Property CategoryIdNo As Int16
        Public Property DiscountAmount As Decimal
        Public Property DiscountPercent As Decimal
        Public Property ExpiryDate As Date?
        Public Property GrossAmount As Decimal
        Public Property IdNo As Int32
        Public Property NeedsExpiryDate As Boolean
        Public Property NetAmount As Decimal
        Public Property Price As Decimal
        Public Property ProductCode As String
        Public Property ProductIdNo As Int32
        Public Property ProductName As String
        Public Property ProductNameAra As String
        Public Property Quantity As Int16
        Public Property SaleIdNo As Int32
        Public Property Sequence As Int16
        Public Property UnitCost As Decimal
        Public Property UnitCount As Int16
        Public Property UnitIdNo As Int16
        Public Property UserIdNo As Int16
        Public Property VatAmount As Decimal
        Public Property VatPercent As Decimal
        Public Property WarehouseIdNo As Int16

    End Class

End Namespace