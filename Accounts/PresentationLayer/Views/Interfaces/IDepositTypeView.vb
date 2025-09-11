Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDepositTypeView
        Inherits IView

        Property AccountIdNo As Int16
        Property BankChargesAccountIdNo As Int16?
        Property BankChargesVatAccountIdNo As Int16?
        Property DepositTypeCode As String
        Property DepositTypeName As String
        Property DepositTypeNameAra As String
        Property IdNo As Int16
        Property Notes As String
        Property Rate As Decimal
        Property WithBankCharges As Boolean

    End Interface

End Namespace