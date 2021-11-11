Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
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
            View.AppliedBy = GlobalVariables.UserIdNo
        End Sub

    End Class

End Namespace