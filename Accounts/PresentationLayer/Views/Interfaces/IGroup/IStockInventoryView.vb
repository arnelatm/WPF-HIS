Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IStockInventoryView
        Inherits IView

        Property Batch As String
        Property BranchId As String
        Property CashPrice As Decimal
        Property Expiry As Date
        Property GTIN As String
        Property IdNo As Int32
        Property Item_Code As String
        Property ItemNameEnglish As String
        Property PurchaseNo As Decimal
        Property Quantity As Decimal
        Property SerialNo As String
        Event FinderValueChanged(itemIdNo As Short)
    End Interface

End Namespace