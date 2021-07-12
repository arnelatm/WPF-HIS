Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class SalaryLoanSchedulePresenter(Of TV As ISalaryLoanScheduleView, TM As New)
        Inherits PresenterNew(Of ISalaryLoanScheduleView, TM)

        Public Sub New(view As ISalaryLoanScheduleView)
            MyBase.New(view)
            Service = New ServiceAccounts("SalaryLoanSchedule")
            TableName = "SalaryLoanSchedule"
            SortOrderKey = "IdNo"
            'OriginalModel = New SalaryLoanScheduleModel()
            'DataModel = New SalaryLoanScheduleModel()
            QuitOnSave = False
        End Sub

    End Class

End Namespace