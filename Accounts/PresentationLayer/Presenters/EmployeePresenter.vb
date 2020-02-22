
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class EmployeePresenter
        Inherits CommonPresenterNew(Of IEmployeeView, Employee, EmployeeModel)

        Public ParentViewList As List(Of EmployeeModel)

        Public Sub New(view As IEmployeeView)
            MyBase.New(view)
            TableName = "Employee"
            SortOrderKey = "EmployeeName"
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            OriginalModel = New EmployeeModel()
            BizObject = New Employee(True, Me)
            DataModel = New EmployeeModel
            DbDataDao = New EmployeeDao
            TreeViewList = New List(Of EmployeeModel)
            ParentViewList = New List(Of EmployeeModel)
            Model.SetService(New EmployeeService)
        End Sub

    End Class
End NameSpace