Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views

    Public Class AccountReconciliationItemView
        Implements IAccountReconciliationItemView

        Public Property AccountIdNo As Int16? Implements IAccountReconciliationItemView.AccountIdNo
        Public Property AccountReconciliationIdNo As Integer Implements IAccountReconciliationItemView.AccountReconciliationIdNo
        Public Property Cleared As Boolean Implements IAccountReconciliationItemView.Cleared
        Public Property Credit As Decimal Implements IAccountReconciliationItemView.Credit
        Public Property Debit As Decimal Implements IAccountReconciliationItemView.Debit
        Public Property DocumentNumber As String Implements IAccountReconciliationItemView.DocumentNumber
        Public Property IdNo As Integer Implements IAccountReconciliationItemView.IdNo
        Public Property JournalCode As String Implements IAccountReconciliationItemView.JournalCode
        Public Property JournalIdNo As Integer Implements IAccountReconciliationItemView.JournalIdNo
        Public Property JournalItemIdNo As Integer Implements IAccountReconciliationItemView.JournalItemIdNo
        Public Property PayDescription As String Implements IAccountReconciliationItemView.PayDescription
        Public Property PayDescriptionAra As String Implements IAccountReconciliationItemView.PayDescriptionAra
        Public Property ReferenceNo As String Implements IAccountReconciliationItemView.ReferenceNo
        Public Property Sequence As Int32 Implements IAccountReconciliationItemView.Sequence
        Public Property TransactionDate As Date? Implements IAccountReconciliationItemView.TransactionDate
        Public Property DataFilter As String Implements IView.DataFilter
        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace