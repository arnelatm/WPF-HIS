Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IProductView
        Inherits IView
        Property IdNo As Int32
        Property CategoryIdNo As Int16
        Property ProductCode As String
        Property ProductName As String
        Property ProductNameAra As String
        Property GlAccountIdNo As Int16?
        Property VatAccountIdNo As Int16?
        Property BaseUnit As Int16
        Property VatPercent As Decimal
        Property Active As Boolean
        Property DateCreated As Date?
    End Interface

End Namespace