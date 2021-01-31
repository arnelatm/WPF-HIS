Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ClosePettyCashPresenter
        Inherits AccountsPresenter(Of IView, PcJournals)

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
            If idNo <> 0 Then
                Dim modelData As List(Of PcJournal)
                modelData = ModelPresenter.GetRecordsWithIdNo(Of PcJournal)(idNo)
                GlobalVariables.Mapper.Map(modelData, View)
                For Each child In ChildPresenters
                    child.UpdateViewDisplay(idNo)
                Next
            End If
        End Sub

    End Class

End Namespace