' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class CashReceiptJournal
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationDataType.Date))
                AddRule(New ValidateRequired("Notes"))
                AddRule(New ValidateRequired("PayorType"))
                AddRule(New ValidateRequired("AccountIdNo"))
                'AddRule(New ValidateRequired("PayeeIdNo", $"Payor Name must not be blank.", {"PayorName", "PayeeIdNo"}))
                AddRule(New ValidateVatNumber("VatNumber"))
                AddRule(New ValidateIfRequired("VatNumber", "VatAmount", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
                AddRule(New ValidateIfRequired("DiscountAccountIdNo", "DiscountTaken", ValidationDataType.Decimal, ValidationOperator.NotEqual, 0))
                AddRule(New ValidateCompare("TotalDebits", "TotalCredits", ValidationOperator.Equal, ValidationDataType.Decimal))
            End If
        End Sub

        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property Approved As Boolean
        Public Property Cancelled As Boolean
        Public Property CheckDate As Date?
        Public Property CheckNumber As String
        Public Property ContactIdNo As Int32
        Public Property CsrOiItems As List(Of CsrOiItem)
        Public Property DateCreated As DateTime?
        Public Property DiscountAccountIdNo As Int16?
        Public Property DiscountTaken As Decimal
        Public Property IdNo As Int32
        Public Property JournalItems As List(Of JournalItem)
        Public Property Notes As String
        Public Property OrNumber As String
        Public Property PayorIdNo As Int32?
        Public Property PayorName As String
        Public Property PayorType As String
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