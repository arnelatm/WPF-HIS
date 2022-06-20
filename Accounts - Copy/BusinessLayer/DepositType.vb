' DepositType business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DepositType
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("DepositTypeCode"))
                AddRule(New ValidateRequired("DepositTypeName"))
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateIfRequired("BankChargesAccountIdNo", "WithBankCharges", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("BankChargesVatAccountIdNo", "WithBankCharges", ValidationDataType.Boolean, ValidationOperator.Equal, True))
                AddRule(New ValidateIfRequired("Rate", "WithBankCharges", ValidationDataType.Boolean, ValidationOperator.Equal, True))
            End If
        End Sub

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Property AccountIdNo As Int16

        Public Property BankChargesAccountIdNo As Int16?
        Public Property BankChargesVatAccountIdNo As Int16?
        Public Property DepositTypeCode As String
        Public Property DepositTypeName As String
        Public Property DepositTypeNameAra As String
        Public Property IdNo As Int16
        Public Property Notes As String
        Public Property Rate As Decimal
        Public Property WithBankCharges As Boolean

    End Class

End Namespace