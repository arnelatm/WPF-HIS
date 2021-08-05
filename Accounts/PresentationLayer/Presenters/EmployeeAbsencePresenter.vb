Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
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
        End Sub

    End Class

End Namespace