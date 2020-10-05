Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DepartmentPresenter
        Inherits CommonPresenter(Of IDepartmentView, DepartmentModel)

        Public ParentViewList As List(Of DepartmentModel)

        Public Sub New(view As IDepartmentView)
            MyBase.New(view)
            ModelPresenter = New ModelCommon("Department")
            TableName = "Department_View"
            SortOrderKey = "SortKey"
            TreeViewMainField = "DepartmentName"
            TreeViewSecondaryField = "DepartmentCode"
            TreeViewParentIdField = "ParentIdNo"
            OriginalModel = New DepartmentModel()
            DataModel = New DepartmentModel
            TreeViewList = New List(Of DepartmentModel)
            ParentViewList = New List(Of DepartmentModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

End Namespace