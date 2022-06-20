Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPayElementView
        Inherits IView
        Property AccountIdNo As Int16
        Property Active As Boolean
        Property BasePaymentIdNo As Int16?
        Property CalculationType As Char
        Property DefaultQuantity As Decimal
        Property FactorType As String
        Property FactorValue As Decimal
        Property IdNo As Int16
        Property IncludeInEos As Boolean
        Property Notes As String
        Property PayElementCode As String
        Property PayElementKind As Char
        Property PayElementName As String
        Property PayElementNameAra As String
        Property PayElementType As Char
        Property ReportGroupIdNo As Int16
        Property QuantityType As Char
        Property Rate As Decimal
        Property Summary As Boolean
        Property Taxable As Boolean
        Property Unit As Char
        Property UsePayGroups As Boolean
        Property UsePayGroupSetting As Boolean
        Property PayElementAccounts As List(Of PayElementAccountView)
        Property PayElementItems As List(Of PayElementItemView)
        Property FactorTypeByCode
        Property CalculationTypeByCode
        Property EarnReportGroupsByCode
        Property DedReportGroupsByCode
        Property PayElementsByCode
        Property PayGroupsByCode
        Property AccountsByCode
    End Interface

End Namespace