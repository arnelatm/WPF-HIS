' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class PettyCashClosing
        Inherits AATM.BusinessLayer.BusinessObject
        Private Const JournalCode = 0

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationDataType.Date))
                AddRule(New ValidateContent("Amount", 0, ValidationOperator.GreaterThan, ValidationDataType.Decimal))
                AddRule(New ValidateRequired("Notes"))
                AddRule(New ValidateRequired("PayType"))
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateRequired("PcAccountIdNo"))
                AddRule(New ValidateRequired("PayeeIdNo", $"Payeee Name must not be blank.", {"PayeeName", "PayeeIdNo"}))
                AddRule(New ValidateRequired("PayeeName", $"Payeee Name must not be blank.", {"PayeeName", "PayeeIdNo"}))
                AddRule(New ValidateIfRequired("CheckDate", "PayType", ValidationDataType.String, ValidationOperator.Equal, "1"))
                AddRule(New ValidateIfRequired("CheckNumber", "PayType", ValidationDataType.String, ValidationOperator.Equal, "1"))
            End If

        End Sub

        Public Property AccountIdNo As Int16?
        Public Property Amount As Decimal
        Public Property Applied As Decimal
        Public Property CheckDate As Date?
        Public Property CheckNumber As String
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property PayeeIdNo As Int32?
        Public Property PayeeName As String
        Public Property PaymentType As String
        Public Property PayType As String
        Public Property PcAccountIdNo As Int16?
        Public Property PcClosed As Boolean
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TransactionDate As Date?
        Public Property PcClosingJournals As List(Of PcClosingJournal)

    End Class

End Namespace