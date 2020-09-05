Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries

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
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Function GetEmployeeBalance(idNo As Integer)
            Return View.OpeningBalance + Model.GetSqlValue(Of Decimal)("Sum(Debit-Credit)", "ErStatement_View", "EmployeeIdNo = " & idNo.ToString())
        End Function

    End Class

End Namespace