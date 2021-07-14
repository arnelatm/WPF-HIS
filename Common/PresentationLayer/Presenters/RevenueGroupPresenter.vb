Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer

Namespace PresentationLayer.Presenters

    Public Class RevenueGroupPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IRevenueGroupView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IRevenueGroupView)
            MyBase.New(view)
            Service = New ServiceCommon("RevenueGroup")
            TableName = "RevenueGroup_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "RevenueGroupName"
            TreeViewSecondaryField = "RevenueGroupCode"
            TreeViewParentIdField = "ParentIdNo"
            ParentViewList = New List(Of TM)
        End Sub

        Public Function GetLastSortKey(ByVal searchValue As String) As String
            Return Service.GetLastSortKey(searchValue, TableName)
        End Function

    End Class

End Namespace