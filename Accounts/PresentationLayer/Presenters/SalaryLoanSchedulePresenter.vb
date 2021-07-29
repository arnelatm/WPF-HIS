Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class SalaryLoanSchedulePresenter(Of TM As New)
        Inherits PresenterNew(Of ISalaryLoanScheduleView, TM)

        Public Sub New(itemView As ISalaryLoanScheduleView)
            MyBase.New(itemView)
            Service = New AccountsService("SalaryLoanSchedule")
            TableName = "SalaryLoanSchedule"
            SortOrderKey = "IdNo"
            WithTreeView = False
        End Sub

    End Class

End Namespace