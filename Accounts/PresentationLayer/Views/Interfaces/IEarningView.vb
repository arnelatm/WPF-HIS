Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEarningView
        Inherits IView
        Property AccountIdNo As Int16
        Property BasePaymentIdNo As Int16
        Property CalculationType As Char
        Property DefaultQuantity As Decimal
        Property EarningCode As String
        Property EarningName As String
        Property EarningNameAra As String
        Property EarningType As Char

        'Property Frequency As Char
        Property IdNo As Int16

        Property IncludeInEos As Boolean
        Property IncludeInPension As Boolean
        Property Multiplier As Decimal
        Property MultiplierType As Char
        Property Notes As String
        Property Rate As Decimal
        Property Taxable As Boolean
        Property Unit As Char
        Property PayrollEarnAccounts As List(Of PayrollEarnAccountView)
    End Interface

End Namespace