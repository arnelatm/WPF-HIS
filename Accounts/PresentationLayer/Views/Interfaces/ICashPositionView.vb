Imports System.Collections.Generic
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views
    Public Interface ICashPositionView
        Inherits IView
        ReadOnly Property BeginningDate As Date
        ReadOnly Property EndingDate As Date
        ReadOnly Property SelectedAccountIds As List(Of Short)
        ReadOnly Property IsGeneralAccountPosition As Boolean
        Event InitializeRequested()
        Event RefreshRequested()
        Event TransactionRequested(journalCode As String, journalIdNo As Integer, itemIdNo As Integer)
        Sub ShowTransaction(transaction As CashPositionTransactionModel)
        Sub SetAccounts(accounts As List(Of CashPositionAccountModel))
        Sub ShowPosition(position As CashPositionModel)
        Sub ClearPosition()
        Sub ShowError(messageKey As String)
        Sub SetBusy(busy As Boolean)
    End Interface

    Public Interface IGeneralAccountPositionView
        ReadOnly Property IncludeClosingEntries As Boolean
    End Interface
End Namespace
