Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class LeavePresenter(Of TM As New)
        Inherits PresenterNew(Of ILeaveView, LeaveModel)

        Public Sub New(view As ILeaveView)
            MyBase.New(view)

            Service = New ServiceAccounts("Leave")
            TableName = "Leave"
            TreeViewMainField = "LeaveName"
            TreeViewSecondaryField = "LeaveCode"
            SortOrderKey = "LeaveName"
        End Sub

    End Class

End Namespace