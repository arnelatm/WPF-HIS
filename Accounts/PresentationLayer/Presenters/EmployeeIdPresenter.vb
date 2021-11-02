Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class EmployeeIdPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IEmployeeView, TM)

        Public Sub New(itemView As IEmployeeView)
            MyBase.New(itemView)
            Service = New AccountsService("Employee")
            TableName = "Employee"
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            SortOrderKey = "EmployeeName"
            WithTreeView = False
        End Sub

        Public Function GetEmployeeIdList() As List(Of EmployeeIdModel)
            Return Service.GetEmployeeIdList()
        End Function

    End Class

End Namespace