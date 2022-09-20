Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDrugSaleView
        Inherits IView

        Property BatchNo As String
        Property Expiry As Date?
        Property GTin As String
        Property IdNo As Int32
        Property Item_Code As String
        Property ItemNameEnglish As String
        Property SaleDate As Date?
        Property SerializationNo As String
        Property QrCode As String
        Property Manufacture As Date?
        Event FinderValueChanged(itemIdNo As Int16)

        Event GenerateCsvFile(salesDate As Date)

        'Event GetDrugName()
        Event CheckDuplicateDrug(ByRef duplicate As Boolean)
        Event ClearEntry()
        Event ValidateEntries()
        Event ValidateQrCode(ByRef valid As Boolean)
        Event SaveDrugSale()
        Event AddDrugSale()
    End Interface

End Namespace