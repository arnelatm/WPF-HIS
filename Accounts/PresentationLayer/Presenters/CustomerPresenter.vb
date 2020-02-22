Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters


    Public Class CustomerPresenter
        Inherits CommonPresenterOld(Of ICustomerView, Customer, CustomerModel)

        Public ParentViewList As List(Of CustomerModel)

        Public Sub New(view As ICustomerView)
            MyBase.New(view)
            TableName = "Customer"
            SortOrderKey = "CustomerName"
            TreeViewMainField = "CustomerName"
            TreeViewSecondaryField = "CustomerCode"
            OriginalModel = New CustomerModel()
            BizObject = New Customer
            DataModel = New CustomerModel
            DbDataDao = New CustomerDao
            TreeViewList = New List(Of CustomerModel)
            ParentViewList = New List(Of CustomerModel)
            Model.SetService(New CustomerService)
        End Sub

        'Public Function GetCustomerList()
        '    Return GetTreeViewList("CustomerName")
        'End Function
    End Class
End NameSpace