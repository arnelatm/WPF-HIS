Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ClosePettyCashPresenter
        Inherits AccountsPresenter(Of IPcJournalsView, PcJournalModel)

        Private _jiFooter As DgvFooter

        Public Sub New(view As IView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("PcJournals")
            TableName = "PcJournal_View"
            SortOrderKey = "IdNo"
            OriginalModel = New List(Of PcJournalModel)
            DataModel = New List(Of PcJournalModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Overrides Sub UpdateViewDisplay(idNo As Int32)
            Dim modelData As List(Of PcJournalModel)
            modelData = ModelPresenter.GetRecordsWithIdNo(Of PcJournalModel)(idNo)
            View.PcJournals = New List(Of IPcJournalView)
            GlobalVariables.Mapper.Map(modelData, View.PcJournals)

            For Each child In ChildPresenters
                child.UpdateViewDisplay(idNo)
            Next
        End Sub

        Public Overrides Sub SaveOriginalValues()
            'GlobalVariables.Mapper.Map(Of T, TM)(Me.View, Me.OriginalModel)
        End Sub


    End Class

End Namespace