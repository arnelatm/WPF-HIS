' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DisbursementJournal
        Inherits AATM.BusinessLayer.BusinessObject
        Private Const JournalCode = 0

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New(ParamArray parameter As Object())
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
                AddRule(New ValidateRequired("Notes"))
                AddRule(New ValidateRequired("PaymentType"))
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateRequired("PayeeIdNo", $"Payeee Name must not be blank.", {"PayeeName", "PayeeIdNo"}))
                AddRule(New ValidateRequired("PayeeName", $"Payeee Name must not be blank.", {"PayeeName", "PayeeIdNo"}))
                AddRule(New ValidateVatNumber("VatNumber"))
                AddRule(New ValidateIfRequired("VatNumber", "VatAmount", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
                AddRule(New ValidateIfRequired("DiscountAccountIdNo", "DiscountTaken", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
                AddRule(New ValidateCompareIfTrue(PaymentType = "A", "Amount", "Applied", ValidationOperator.Equal, ValidationDataType.Decimal))
                AddRule(New ValidateCompare("TotalDebits", "TotalCredits", ValidationOperator.Equal, ValidationDataType.Decimal))
                If parameter(JournalCode) = "CD" Then
                    AddRule(New ValidateRequired("PayType"))
                    AddRule(New ValidateIfRequired("CheckDate", "PayType", ValidationDataType.String, ValidationOperator.Equal, "2"))
                    AddRule(New ValidateIfRequired("CheckNumber", "PayType", ValidationDataType.String, ValidationOperator.Equal, "2"))
                End If
            End If

        End Sub

        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property DjOiItems As List(Of DjOiItem)
        Public Property Cancelled As Boolean
        Public Property CheckDate As Date?
        Public Property CheckNumber As String
        Public Property DateCreated As DateTime?
        Public Property PayType As String
        Public Property DiscountAccountIdNo As Int16?
        Public Property DiscountTaken As Decimal
        Public Property IdNo As Int32
        Public Property JournalItems As List(Of JournalItem)
        Public Property Notes As String
        Public Property OrNumber As String
        Public Property PayeeIdNo As Int32?
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