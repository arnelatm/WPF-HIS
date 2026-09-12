Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters
    Public Class CashPositionPresenter
        Inherits AccountsPresenter(Of ICashPositionView, CashPositionModel)

        Private ReadOnly _cashService As New CashPositionService()

        Public Sub New(view As ICashPositionView)
            MyBase.New(view)
            TableName = "Account"
            WithTreeView = False
            Service = New AccountsService("Account")
            AddHandler view.InitializeRequested, AddressOf Initialize
            AddHandler view.RefreshRequested, AddressOf RefreshPosition
            AddHandler view.TransactionRequested, AddressOf OpenTransaction
        End Sub

        Private Sub OpenTransaction(journalCode As String, journalIdNo As Integer, itemIdNo As Integer)
            View.SetBusy(True)
            Try
                If Not GlobalVariables.IsUserLoggedIn Then
                    View.ShowError("CashPositionLoginRequired")
                    Return
                End If
                View.ShowTransaction(_cashService.GetTransaction(journalCode, journalIdNo, itemIdNo, View.IsGeneralAccountPosition))
            Catch ex As ArgumentException
                View.ShowError("CashPositionTransactionUnavailable")
            Catch ex As InvalidOperationException
                View.ShowError("CashPositionTransactionUnavailable")
            Catch ex As Exception
                View.ShowError("CashPositionTransactionLoadFailed")
            Finally
                View.SetBusy(False)
            End Try
        End Sub

        Private Sub Initialize()
            View.SetBusy(True)
            Try
                If Not GlobalVariables.IsUserLoggedIn Then Throw New InvalidOperationException("CashPositionLoginRequired")
                View.SetAccounts(If(View.IsGeneralAccountPosition, _cashService.GetAllAccounts(), _cashService.GetAccounts()))
            Catch ex As Exception
                View.ShowError("CashPositionLoadFailed")
            Finally
                View.SetBusy(False)
            End Try
        End Sub

        Private Sub RefreshPosition()
            View.ClearPosition()
            View.SetBusy(True)
            Try
                If Not GlobalVariables.IsUserLoggedIn Then Throw New InvalidOperationException("CashPositionLoginRequired")
                Dim generalView = TryCast(View, IGeneralAccountPositionView)
                Dim includeClosing = If(generalView Is Nothing, True, generalView.IncludeClosingEntries)
                View.ShowPosition(If(View.IsGeneralAccountPosition, _cashService.GetGeneralPosition(View.BeginningDate, View.EndingDate, View.SelectedAccountIds, includeClosing), _cashService.GetPosition(View.BeginningDate, View.EndingDate, View.SelectedAccountIds)))
            Catch ex As ArgumentException
                View.ShowError(ex.Message)
            Catch ex As InvalidOperationException
                View.ShowError(ex.Message)
            Catch ex As Exception
                View.ShowError("CashPositionLoadFailed")
            Finally
                View.SetBusy(False)
            End Try
        End Sub
    End Class
End Namespace
