' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class ArJournal
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
                AddRule(New ValidateRequired("Notes"))
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateRequired("CustomerIdNo"))
                AddRule(New ValidateRequired("InvoiceNo"))
                AddRule(New ValidateCompare("TotalDebits", "TotalCredits", ValidationOperator.Equal, ValidationDataType.Decimal))
            End If
        End Sub

        Public Property AccountIdNo As Int32
        Public Property Amount As Decimal
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime
        Public Property DueDate As Date?
        Public Property IdNo As Integer
        Public Property InvoiceNo As String
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property CustomerIdNo As Int16
        Public Property SettlementDiscount As Decimal
        Public Property SettlementDueDate As Date?
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TransactionDate As Date?
        Public Property TransactionType As String

    End Class
End NameSpace