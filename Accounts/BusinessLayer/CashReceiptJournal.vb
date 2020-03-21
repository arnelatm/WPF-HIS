' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class CashReceiptJournal
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
                AddRule(New ValidateRequired("Notes"))
                AddRule(New ValidateRequired("PayorType"))
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateRequired("PayeeIdNo", $"Payor Name must not be blank.", {"PayorName", "PayorIdNo"}))
                AddRule(New ValidateRequired("PayeeName", $"Payor Name must not be blank.", {"PayorName", "PayorIdNo"}))
                AddRule(New ValidateIfRequired("DiscountAccountIdNo", "DiscountTaken", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
                AddRule(New ValidateCompare("TotalDebits", "TotalCredits", ValidationOperator.Equal, ValidationDataType.Decimal))
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
        Public Property PayorIdNo As Int32
        Public Property PayorName As String
        Public Property PayorType As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property UnApplied As Decimal
    End Class

End Namespace