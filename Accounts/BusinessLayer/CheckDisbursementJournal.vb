' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class CheckDisbursementJournal
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
                AddRule(New ValidateRequired("Notes"))
                AddRule(New ValidateRequired("PaymentType"))
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateRequired("CheckNumber"))
                AddRule(New ValidateRange("CheckDate", Date.Today.AddDays(-366), Date.Today.AddDays(366), ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
                AddRule(New ValidateRequired("PayeeIdNo", $"Payeee Name must not be blank.", {"PayeeName", "PayeeIdNo"}))
                AddRule(New ValidateRequired("PayeeName", $"Payeee Name must not be blank.", {"PayeeName", "PayeeIdNo"}))
                AddRule(New ValidateValueIf("TotalDebits", "TotalCredits", ValidationOperator.Equal, ValidationDataType.Decimal, $"PaymentType", ValidationDataType.String, "A", ValidationOperator.Equal))
                AddRule(New ValidateVatNumber("VatNumber"))
                'AddRule(New ValidateValueIf("Applied", "Amount", ValidationOperator.Equal, ValidationDataType.String, $"PaymentType", ValidationDataType.String, "A", ValidationOperator.Equal))
                AddRule(New ValidateIfRequired("VatNumber", "VatAmount", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
                AddRule(New ValidateIfRequired("DiscountAccountIdNo", "DiscountTaken", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
            End If
        End Sub

        Public Property AccountIdNo As Int32
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property Cancelled As Boolean
        Public Property CheckDate As Date?
        Public Property CheckNumber As String
        Public Property DateCreated As DateTime?
        Public Property DiscountAccountIdNo As Int32
        Public Property DiscountTaken As Decimal
        Public Property IdNo As Integer
        Public Property Notes As String
        Public Property OrNumber As String
        Public Property PayeeIdNo As Int32
        Public Property PayeeName As String
        Public Property PaymentType As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property UnApplied As Decimal
        Public Property VatAmount As Decimal
        Public Property VatNumber As String
    End Class

End Namespace