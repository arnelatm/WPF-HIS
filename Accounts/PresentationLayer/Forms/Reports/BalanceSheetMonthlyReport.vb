Imports System.Windows.Forms
Imports AATM.Languages
Imports AATM.Libraries.GlobalFuncNSub.GlobalFunctions
Imports AATM.Libraries.Languages

Namespace PresentationLayer.Forms.Reports

    Public Class BalanceSheetMonthlyReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            AddHandler MyBase.OkButtonClicked, AddressOf OnOkButtonClicked
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub BalanceSheetMonthlyReport_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = DateAndTime.Now
            dmpReportDate.Value = dateToday.AddDays(DateAndTime.Day(dateToday) * -1)
            dmpReportDate.Refresh()
        End Sub

        Private Sub OnOkButtonClicked()
            If IsNothing(dmpReportDate.Value) Then
                MessageBox.Show(Messages.PleaseEnterTheEndingDateForTheReport, StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dmpReportDate.Value < GbDateSerial(2018, 1, 1) Then
                MessageBox.Show(Messages.DateCanTBeLessThan + DateSerial(2018, 1, 1).ToLongDateString(), StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dmpReportDate.Value > Today Then
                MessageBox.Show(Messages.DateCanTBeGreaterThanTodaySDate, StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Balance Sheet Arabic Monthly.rpt")
                Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "ibn-server", "IGroupClinic")
                Report.SetParameterValue("YearOfReport", Year(dmpReportDate.Value))
                Report.SetParameterValue("MonthOfReport", Month(dmpReportDate.Value))
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace