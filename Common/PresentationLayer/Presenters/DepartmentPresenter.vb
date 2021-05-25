Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries

Namespace PresentationLayer.Presenters

    Public Class DepartmentPresenter
        Inherits CommonPresenter(Of IDepartmentView, DepartmentModel)

        Public ParentViewList As List(Of DepartmentModel)

        Public Sub New(view As IDepartmentView)
            MyBase.New(view)
            TreeViewParentIdField = "ParentIdNo"
            'InitializerWithTv("Department")
            'TableName = "Department"
            SortOrderKey = "DepartmentName"
            TreeViewMainField = "DepartmentName"
            TreeViewSecondaryField = "DepartmentCode"
            ModelOfPresenter = New ModelCommon("Department")
            OriginalModel = New DepartmentModel()
            DataModel = New DepartmentModel
            TreeViewList = New List(Of DepartmentModel)
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Model.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

End Namespace