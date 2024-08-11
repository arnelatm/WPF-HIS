Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DosageMasterListPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IDosageMasterListView, TM)

        Public Sub New(itemView As IDosageMasterListView)
            MyBase.New(itemView)
            Service = New AccountsService("DosageMaster")
            TableName = "DosageMaster"
            SortOrderKey = "IdNo"
            WithTreeView = False
            Service = New AccountsService("DosageMaster")
            AddHandler View.LoadAll, AddressOf OnLoadAll
            AddHandler View.SaveCurrent, AddressOf OnSaveCurrent
            PromptOnSavedRecord = False
        End Sub


        Public Sub OnLoadAll(sortKey As String)
            Dim dmv As New List(Of IDosageMasterView)
            Dim record = Service.GetAll(Of TM)(sortKey)
            If record IsNot Nothing Then
                GlobalFunctions.ManualMap(record, dmv)
                View.DosageMasterList = dmv
            End If
        End Sub

        Public Sub OnSaveCurrent(idNo As Int32, translation As String)
            Service.UpdateRecordWithIdNo(Of String)(idNo, "MedicineDosageMaster", "ItemNameArabic", translation)
        End Sub

        Private Sub OnAddDosageMaster()
            GoAddRecord()
        End Sub

        Private Sub OnSaveDosageMaster()
            Save(View)
        End Sub

        Public Sub OnFinderValueChanged(idNo As Int16)
            If idNo <> 0 Then
                RecordPositionNumber = GetSortedRecordPosition(idNo)
            End If
        End Sub


    End Class

End Namespace