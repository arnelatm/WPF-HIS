Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Presenters

    Public Class ChartPresenter
        Inherits AccountsPresenter(Of IChartView, ChartModel)

        Public ParentViewList As List(Of ChartModel)

        Public Sub New(view As IChartView)
            MyBase.New(view)
            ModelPresenter = New ModelAccounts("Chart")
            TableName = "Chart_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "AccountName"
            TreeViewSecondaryField = "AccountCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New ChartModel()
            DataModel = New ChartModel
            TreeViewList = New List(Of ChartModel)
            ParentViewList = New List(Of ChartModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetRecordFieldWithKey(idNoToSearch, "Chart", "ParentIdNo", "AccountName")
        End Function

    End Class

End Namespace