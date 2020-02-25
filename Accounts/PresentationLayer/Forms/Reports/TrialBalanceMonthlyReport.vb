Imports System.Windows.Forms
Imports AATM.Libraries.Languages
Imports AATM.Libraries.GlobalFuncNSub.GlobalFunctions

Namespace PresentationLayer.Forms.Reports

    Public Class TrialBalanceMonthlyReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            AddHandler OkButtonClicked, AddressOf OnOkButtonClicked
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub BalanceSheetMonthlyReport_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = Now
            dmpReportDate.Value = dateToday.AddDays(DateAndTime.Day(dateToday) * -1)
            dmpReportDate.Refresh()
        End Sub

        Private Sub OnOkButtonClicked()
            Dim dDate As Date = GbDateSerial(2018, 1, 1)
            If IsNothing(dmpReportDate.Value) Then
                MessageBox.Show(Messages.PleaseEnterTheEndingDateForTheReport, StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dmpReportDate.Value < DateSerial(2018, 1, 1) Then
                MessageBox.Show(Messages.DateCanTBeLessThan + dDate.ToLongDateString(), StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dmpReportDate.Value > Today Then
                MessageBox.Show(Messages.DateCanTBeGreaterThanTodaySDate, StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Trial Balance Arabic Monthly.rpt")
                Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "ibn-server", "IGroupClinic")
                Report.SetParameterValue("YearOfReport", Year(dmpReportDate.Value))
                Report.SetParameterValue("MonthOfReport", Month(dmpReportDate.Value))
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace