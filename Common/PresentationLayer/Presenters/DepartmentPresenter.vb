Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class DepartmentPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IDepartmentView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IDepartmentView)
            MyBase.New(view)
            Service = New CommonService("Department")
            TableName = "Department_View"
            TableBaseName = "Department"
            ParentFieldName = "ParentIdNo"
            TreeViewMainField = "DepartmentName"
            ParentFieldName = "ParentIdNo"
            TreeViewSecondaryField = "DepartmentCode"
            SortOrderKey = "SortKey"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Department", "ParentIdNo")
            CreateDataSource("RevCostCenter", "RevCostCenterIdNo")
        End Sub

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

End Namespace