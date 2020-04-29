' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class SalesJournal
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("TransactionDate"))
                AddRule(New ValidateRange("TransactionDate", Date.MinValue, Date.Today, ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
                AddRule(New ValidateRequired("Notes"))
                AddRule(New ValidateCompare("TotalDebits", "TotalCredits", ValidationOperator.Equal, ValidationDataType.Decimal))
            End If
        End Sub

        Public Property AccountIdNo as Int32
        Public Property Cancelled As Boolean
        Public Property DateCreated As DateTime
        Public Property IdNo As Int32
        Public Property Notes As String
        Public Property Posted As Boolean
        Public Property ReferenceNo As String
        Public Property TotalBankCharges As Decimal
        Public Property TotalBankChargesVat As Decimal
        Public Property TotalCredits As Decimal
        Public Property TotalDebits As Decimal
        Public Property TotalDeposits As Decimal
        Public Property TotalSales As Decimal
        Public Property TransactionDate As Date?
    End Class

End Namespace