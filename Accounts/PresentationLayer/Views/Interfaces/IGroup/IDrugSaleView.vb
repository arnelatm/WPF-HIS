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

        Event FinderValueChanged(itemIdNo As Int16)

        Event GenerateCsvFile(salesDate As Date)

        Event GetDrugName()

    End Interface

End Namespace