Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayPeriodPresenter
        Inherits AccountsPresenter(Of IPayPeriodView, PayPeriodModel)

        Public Sub New(view As IPayPeriodView)
            MyBase.New(view)
            InitializerWithTv("PayPeriod")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Public Sub InitializeMonthlyPayroll(payCycleRecord As PayCycle)
            If View.StartDate = Nothing And View.EndDate = Nothing Then
                Dim nIdNoMax As Int32
                Dim maxRecord As New PayPeriodModel
                nIdNoMax = ModelPresenter.GetMaxValueFiltered("EndDate", "PayPeriod", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
                maxRecord = ModelPresenter.GetRecordById(Of PayPeriodModel)(nIdNoMax)
                View.StartDate = maxRecord.EndDate.AddDays(1)
                Dim arabicCulture As New CultureInfo("ar-ae", False)
                If View.StartDate.Day = 1 Then
                    View.EndDate = View.StartDate.AddMonths(1).AddDays(-1)
                    View.PayPeriodName = "Payroll for the Month of " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                    View.PayPeriodNameAra = " رواتب الشهر" + GetMonthNamesInCulture(Month(View.EndDate), arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                Else
                    View.EndDate = maxRecord.EndDate.AddMonths(1)
                    View.PayPeriodName = "Payroll for the Period " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
                    View.PayPeriodNameAra = " رواتب الشهر" & GetMonthNamesInCulture(Month(View.EndDate), arabicCulture)
                End If
                View.PayPeriodCode = "M" + View.EndDate.ToString("yyMM")
            End If
        End Sub

    End Class

End Namespace