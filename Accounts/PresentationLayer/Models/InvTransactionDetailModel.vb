Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class InvTransactionDetailModel

        Public Property BaseUnitIdNo As Int16
        Public Property BatchNo As String
        Public Property CategoryIdNo As Int16
        Public Property ExpiryDate As Date?
        Public Property IdNo As Int32
        Public Property InventoryIdNo As Int32
        Public Property InvTransactionIdNo As Int32
        Public Property NeedsExpiryDate As Boolean
        Public Property NetAmount As Decimal
        Public Property ProductCode As String
        Public Property ProductIdNo As Int32
        Public Property ProductName As String
        Public Property ProductNameAra As String
        Public Property Quantity As Int16
        Public Property Sequence As Int16
        Public Property UnitCost As Decimal
        Public Property UnitCount As Int16
        Public Property UnitIdNo As Int16


    End Class

End Namespace