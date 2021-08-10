Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class LeavePresenter(Of TM As New)
        Inherits CommonPresenterNew(Of ILeaveView, LeaveModel)

        Public Sub New(view As ILeaveView)
            MyBase.New(view)

            Service = New AccountsService("Leave")
            TableName = "Leave"
            TreeViewMainField = "LeaveName"
            TreeViewSecondaryField = "LeaveCode"
            SortOrderKey = "LeaveName"
        End Sub

    End Class

End Namespace