Imports AATM.Accounts.BusinessLayer
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEarningView
        Inherits IView
        Property AccountIdNo As Int16
        Property BasePaymentIdNo As Int16?
        Property CalculationType As Char
        Property DefaultQuantity As Decimal
        Property EarningCode As String
        Property Summary As Boolean
        Property EarningName As String
        Property EarningNameAra As String
        Property EarningType As Char
        Property IdNo As Int16
        Property IncludeInEos As Boolean
        Property FactorValue As String
        Property FactorType As Char
        Property Notes As String
        Property Rate As Decimal
        Property Taxable As Boolean
        Property Unit As Char
        Property UnitAttendance As Char
        Property UsePayGroups As Boolean
        Property PayrollEarnAccounts As List(Of PayrollEarnAccountView)
        Property EarningsSummary As List(Of EarningSummaryView)
    End Interface

End Namespace