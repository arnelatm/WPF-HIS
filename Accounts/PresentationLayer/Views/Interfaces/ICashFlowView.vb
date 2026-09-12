Imports System.Collections.Generic
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views
    Public Interface ICashFlowView
        Inherits IView
        ReadOnly Property BeginningDate As Date
        ReadOnly Property EndingDate As Date
        ReadOnly Property SelectedAccountIds As List(Of Short)
        Event InitializeRequested()
        Event RefreshRequested()
        Event SourceRequested(journalCode As String, journalIdNo As Integer, itemIdNo As Integer)
        Sub SetAccounts(accounts As List(Of CashFlowAccountModel))
        Sub ShowStatement(statement As CashFlowModel)
        Sub ClearStatement()
        Sub ShowSource(source As CashPositionTransactionModel)
        Sub ShowError(messageKey As String)
        Sub SetBusy(busy As Boolean)
    End Interface
End Namespace
