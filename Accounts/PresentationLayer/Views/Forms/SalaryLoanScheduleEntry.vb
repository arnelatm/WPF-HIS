Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class SalaryLoanScheduleEntry

        Private ReadOnly _ea As New EventAggregator

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "SalaryLoanSchedule"
            SortOrderKey = "SalaryLoanScheduleName"
            Ea = _ea
            PresenterObj = New SalaryLoanSchedulePresenter(SalaryLoanScheduleView, Ea)

            'GlobalVariables.EventAggregator.SubscribeEvent(Me)

        End Sub

    End Class

End Namespace