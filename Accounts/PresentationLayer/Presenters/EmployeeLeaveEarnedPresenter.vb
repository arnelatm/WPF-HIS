Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeaveEarnedPresenter(Of TM As New)
        Inherits CommonPresenter(Of IEmployeeLeaveEarnedView, TM)

        Public Sub New(itemView As IEmployeeLeaveEarnedView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeaveEarned")
            TableName = "EmployeeLeaveEarned"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("User", "EnteredBy", {"IdNo", "UserName"})
            CreateDataSource("Leave", "LeaveIdNo", "EmployeeLeaveEarned = 1")
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EnteredBy = GlobalVariables.UserIdNo
        End Sub


    End Class

End Namespace