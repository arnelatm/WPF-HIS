Imports AATM.Accounts.BusinessLayer
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IProductView
        Inherits IView

        Property Active As Boolean
        Property Barcode As String
        Property BaseUnitIdNo As Int16
        Property CategoryIdNo As Int16
        Property DateCreated As DateTime?
        Property Drug As Boolean
        Property GTIN As String
        Property IdNo As Int32
        Property ProductCode As String
        Property ProductName As String
        Property ProductNameAra As String
        Property ProductUnits As List(Of ProductUnitView)
        Property UnitsByCode As Object
    End Interface

End Namespace