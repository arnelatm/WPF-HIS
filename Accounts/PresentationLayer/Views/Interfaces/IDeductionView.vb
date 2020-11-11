Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDeductionView
        Inherits IView

        Property AccountIdNo As Int16
        Property BasePaymentIdNo As Int16?
        Property CalculationType As Char
        Property DeductionCode As String
        Property DeductionName As String
        Property DeductionNameAra As String
        Property DeductionType As Char
        Property DefaultQuantity As Decimal
        Property IdNo As Int16
        Property Multiplier As Decimal
        Property MultiplierType As Char
        Property Notes As String
        Property Rate As Decimal
        Property Unit As Char
        Property UsePayGroups As Boolean
        Property PayrollDeductAccounts As List(Of PayrollDeductAccountView)

    End Interface

End Namespace