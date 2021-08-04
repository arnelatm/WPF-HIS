Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class EmployeeLeavePresenter(Of TM As New)
        Inherits PresenterNew(Of IEmployeeLeaveView, TM)

        Public Sub New(itemView As IEmployeeLeaveView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeLeave")
            TableName = "EmployeeLeave"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

    End Class

End Namespace