Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class SalaryLoanSchedulePresenter
        Inherits PresenterNew(Of ISalaryLoanScheduleView, SalaryLoanScheduleModel)

        'Private _ea As EventAggregator

        Public Sub New(view As IViewNew)
            MyBase.New(view)
            ModelOfPresenter = New ModelAccounts("SalaryLoanSchedule")
            TableName = "SalaryLoanSchedule"
            SortOrderKey = "IdNo"
            OriginalModel = New SalaryLoanScheduleModel()
            DataModel = New SalaryLoanScheduleModel()
            QuitOnSave = False
            AskBeforeSave = True
        End Sub

    End Class

End Namespace