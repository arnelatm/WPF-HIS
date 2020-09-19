' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class AccountReconciliation
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If createRules Then
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("AccountIdNo"))
                AddRule(New ValidateRequired("ReconciliationDate"))
                AddRule(New ValidateRange("ReconciliationDate", Date.MinValue, Date.Today, ValidationOperator.LessThanOrEqual, ValidationDataType.Date))
            End If
        End Sub

        Public Property AccountIdNo As Int16?
        Public Property Balance As Decimal
        Public Property DateCreated As DateTime?
        Public Property GlSystemBalance As Decimal
        Public Property IdNo As Int32
        Public Property Posted As Boolean
        Public Property ReconciliationDate As Date?
        Public Property TotalCreditsCleared As Decimal
        Public Property TotalCreditsNotCleared As Decimal
        Public Property TotalDebitsCleared As Decimal
        Public Property TotalDebitsNotCleared As Decimal
        Public Property TotalQtyCreditsCleared As Integer
        Public Property TotalQtyCreditsNotCleared As Integer
        Public Property TotalQtyDebitsCleared As Integer
        Public Property TotalQtyDebitsNotCleared As Integer
        Public Property UnreconciledDifference As Decimal
        Public Property AccountReconciliationItems As List(Of AccountReconciliationItem)
    End Class

End Namespace