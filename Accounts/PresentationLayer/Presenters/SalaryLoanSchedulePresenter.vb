Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class SalaryLoanSchedulePresenter(Of TM As New)
        Inherits PresenterNew(Of ISalaryLoanScheduleView, TM)

        Public Sub New(view As ISalaryLoanScheduleView)
            MyBase.New(view)
            Service = New AccountsService("SalaryLoanSchedule")
            TableName = "SalaryLoanSchedule"
            SortOrderKey = "IdNo"
        End Sub

    End Class

End Namespace