Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class AccountReconciliationItemView
        Implements IAccountReconciliationItemView

        Public Property AccountIdNo As Integer Implements IAccountReconciliationItemView.AccountIdNo

        Public Property AccountReconciliationIdNo As Integer Implements IAccountReconciliationItemView.AccountReconciliationIdNo

        Public Property Cleared As Boolean Implements IAccountReconciliationItemView.Cleared

        Public Property Credit As Decimal Implements IAccountReconciliationItemView.Credit

        Public Property Debit As Decimal Implements IAccountReconciliationItemView.Debit

        Public Property DocumentNumber As String Implements IAccountReconciliationItemView.DocumentNumber

        Public Property IdNo As Integer Implements IAccountReconciliationItemView.IdNo

        Public Property JournalCode As String Implements IAccountReconciliationItemView.JournalCode

        Public Property JournalIdNo As Integer Implements IAccountReconciliationItemView.JournalIdNo

        Public Property PayDescription As String Implements IAccountReconciliationItemView.PayDescription

        Public Property PayDescriptionAra As String Implements IAccountReconciliationItemView.PayDescriptionAra

        Public Property ReferenceNo As String Implements IAccountReconciliationItemView.ReferenceNo

        Public Property TransactionDate As Date? Implements IAccountReconciliationItemView.TransactionDate

        Public Property Sequence As Integer Implements IAccountReconciliationItemView.Sequence

        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property JournalItemIdNo As Integer Implements IAccountReconciliationItemView.JournalItemIdNo

    End Class

End Namespace