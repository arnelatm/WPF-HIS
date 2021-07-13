Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.PresentationLayer.Presenters
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class DepartmentPresenter(Of TM As New)
        Inherits PresenterNew(Of IDepartmentView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IDepartmentView)
            MyBase.New(view)
            Service = New ServiceCommon("Department")
            TableName = "Department_View"
            ParentFieldName = "ParentIdNo"
            TreeViewMainField = "DepartmentName"
            TreeViewParentIdField = "ParentIdNo"
            TreeViewSecondaryField = "DepartmentCode"
            SortOrderKey = "SortKey"
        End Sub

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

End Namespace