Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeavePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of IEmployeeLeaveView, TM)

        Public Sub New(itemView As IEmployeeLeaveView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeave")
            TableName = "EmployeeLeave"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.FullDay = True
            View.EmployeeIdNo = Service.GetField(Of Int32, Int32)(GlobalVariables.UserIdNo, "User", "IdNo", "EmployeeIdNo")
            View.AppliedBy = GlobalVariables.UserIdNo
            View.StartDate = Today()
            View.EndDate = Today()
        End Sub

    End Class

End Namespace