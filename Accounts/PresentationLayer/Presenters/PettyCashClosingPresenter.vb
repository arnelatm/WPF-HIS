Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PettyCashClosingPresenter
        Inherits AccountsPresenter(Of IPettyCashClosingView, PettyCashClosingModel)

        Private _jiFooter As DgvFooter

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PettyCashClosing")
            TableName = "CdJournal"
            SortOrderKey = "IdNo"
            OriginalModel = New PettyCashClosingModel()
            DataModel = New PettyCashClosingModel()
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Sub GetOpenPettyCash()
            Dim modelData As List(Of PcJournalModel)
            modelData = ModelPresenter.GetOpenPettyCash()
            View.PcJournals = New List(Of IPcJournalView)
            GlobalVariables.Mapper.Map(modelData, View.PcJournals)
        End Sub

        'Public Overrides Sub SaveOriginalValues()
        '    'GlobalVariables.Mapper.Map(Of T, TM)(Me.View, Me.OriginalModel)
        'End Sub

        Public Sub SelectChoice(ByVal SelectAll As Boolean)
            Dim total As Decimal = 0
            For Each item In View.PcJournals
                item.PcClosed = SelectAll
                If SelectAll Then
                    total += item.Amount
                End If
            Next item
            View.Amount = total
            View.Applied = total
        End Sub

        Public Function TotalSelection()
            Dim total As Decimal = 0D
            For Each item In View.PcJournals
                If item.PcClosed Then
                    total += item.Amount
                End If
            Next item
            Return total
        End Function

    End Class

End Namespace