Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DurationListPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IDurationListView, TM)

        Public Sub New(itemView As IDurationListView)
            MyBase.New(itemView)
            Service = New AccountsService("Duration")
            TableName = "Duration"
            SortOrderKey = "IdNo"
            WithTreeView = False
            Service = New AccountsService("Duration")
            AddHandler View.LoadAll, AddressOf OnLoadAll
            AddHandler View.SaveCurrent, AddressOf OnSaveCurrent
            PromptOnSavedRecord = False
        End Sub


        Public Sub OnLoadAll(sortKey As String)
            Dim dmv As New List(Of IDurationView)
            Dim record = Service.GetAll(Of TM)(sortKey)
            If record IsNot Nothing Then
                GlobalVariables.Mapper.Map(record, dmv)
                View.DurationList = dmv
            End If
        End Sub

        Public Sub OnSaveCurrent(idNo As Int32, translation As String)
            Service.UpdateRecordWithIdNo(Of String)(idNo, "PmrQtyDays", "DescriptionArabic", translation)
        End Sub

        Private Sub OnAddDuration()
            GoAddRecord()
        End Sub

        Private Sub OnSaveDuration()
            Save(View)
        End Sub

        Public Sub OnFinderValueChanged(idNo As Int16)
            If idNo <> 0 Then
                RecordPositionNumber = GetSortedRecordPosition(idNo)
            End If
        End Sub

    End Class

End Namespace