Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class EmployeeAbsencePresenter(Of TM As New)
        Inherits PresenterNew(Of IEmployeeAbsenceView, TM)

        Public Sub New(itemView As IEmployeeAbsenceView)
            MyBase.New(itemView)
            Service = New AccountsService("EmployeeAbsence")
            TableName = "EmployeeAbsence"
            SortOrderKey = "IdNo"
            WithTreeView = False
            AddHandler View.AddedByUserChanged, AddressOf OnAddedByUserChanged
        End Sub

        Protected Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.AddedByUser = GlobalVariables.UserIdNo
            View.UserName = GlobalVariables.UserName
        End Sub

        Protected Sub OnAddedByUserChanged()
            Dim userIdNo = View.AddedByUser
            View.UserName = Service.GetFieldWithIdNo(userIdNo, "User", "UserName")
        End Sub

    End Class

End Namespace