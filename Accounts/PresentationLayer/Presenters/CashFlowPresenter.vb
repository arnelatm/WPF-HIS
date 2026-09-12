Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters
    Public Class CashFlowPresenter
        Inherits AccountsPresenter(Of ICashFlowView, CashFlowModel)
        Private ReadOnly _service As New CashFlowService()

        Public Sub New(view As ICashFlowView)
            MyBase.New(view)
            TableName = "Account" : WithTreeView = False
            AddHandler view.InitializeRequested, AddressOf Initialize
            AddHandler view.RefreshRequested, AddressOf Refresh
            AddHandler view.SourceRequested, AddressOf OpenSource
        End Sub

        Private Sub Initialize()
            View.SetBusy(True)
            Try
                If Not GlobalVariables.IsUserLoggedIn Then Throw New InvalidOperationException("CashFlowLoginRequired")
                View.SetAccounts(_service.GetAccounts())
            Catch ex As Exception
                View.ShowError("CashFlowLoadFailed")
            Finally
                View.SetBusy(False)
            End Try
        End Sub

        Private Sub Refresh()
            View.ClearStatement() : View.SetBusy(True)
            Try
                If Not GlobalVariables.IsUserLoggedIn Then Throw New InvalidOperationException("CashFlowLoginRequired")
                View.ShowStatement(_service.GetStatement(View.BeginningDate, View.EndingDate, View.SelectedAccountIds))
            Catch ex As ArgumentException
                View.ShowError(ex.Message)
            Catch ex As Exception
                View.ShowError("CashFlowLoadFailed")
            Finally
                View.SetBusy(False)
            End Try
        End Sub

        Private Sub OpenSource(code As String, journalId As Integer, itemId As Integer)
            View.SetBusy(True)
            Try
                View.ShowSource(_service.GetTransaction(code, journalId, itemId))
            Catch ex As Exception
                View.ShowError("CashFlowSourceUnavailable")
            Finally
                View.SetBusy(False)
            End Try
        End Sub
    End Class
End Namespace
