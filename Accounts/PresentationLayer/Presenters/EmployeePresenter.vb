Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class EmployeePresenter
        Inherits AccountsPresenter(Of IEmployeeView, EmployeeModel)

        Public Sub New(view As IEmployeeView)
            MyBase.New(view)
            TableName = "Employee"
            SortOrderKey = "EmployeeName"
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            ModelPresenter = New ModelAccounts("Employee")
            OriginalModel = New EmployeeModel()
            DataModel = New EmployeeModel
            TreeViewList = New List(Of EmployeeModel)
        End Sub

    End Class

End Namespace