Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters


    Public Class ChartPresenter
        Inherits AccountsPresenter(Of IChartView, Chart, ChartModel)

        Public ParentViewList As List(Of ChartModel)

        Shared Sub New()
            ModelTblColProp = New ModelTblColProp
            ModelDefaultFieldValue = New ModelDefaultFieldValue
        End Sub

        Public Sub New(view As IChartView)
            MyBase.New(view)
            CurrentModel = New ModelChart()
            TableName = "Chart_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "AccountName"
            TreeViewSecondaryField = "AccountCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New ChartModel()
            BizObject = New Chart
            DataModel = New ChartModel
            TreeViewList = New List(Of ChartModel)
            ParentViewList = New List(Of ChartModel)
        End Sub

        Public Function GetParentList() As List(Of ChartModel)
            Dim xModel As New ChartModel
            Dim newSortOrderKey As String = GetTranslatedSortOrderKey(Of ChartModel)(SortOrderKey, xModel)
            Dim modelData = Model.GetAll(Of ChartModel)(newSortOrderKey)
            If TreeViewList IsNot Nothing And TreeViewList.Count > 0 Then
                TreeViewList.Clear()
            End If
            For Each modData In modelData
                Dim modelTb As New ChartModel
                GlobalVariables.Mapper.Map(modData, modelTb)
                TreeViewList.Add(modelTb)
            Next
            Return TreeViewList
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetRecordFieldWithKey(idNoToSearch, "Chart", "ParentIdNo", "AccountName")
        End Function

    End Class
End NameSpace