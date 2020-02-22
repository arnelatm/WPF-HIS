Imports System.Windows.Forms
Imports AATM.Languages
Imports AATM.Libraries.GlobalFuncNSub.GlobalFunctions
Imports AATM.Libraries.Languages

Namespace PresentationLayer.Forms.Reports

    Public Class ApSummaryReport

        Public Sub New()

            InitializeComponent()

            AddHandler MyBase.OkButtonClicked, AddressOf OnOkButtonClicked

        End Sub

        Private Sub ArSummary_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = DateAndTime.Now
            dmpReportDate.Value = dateToday.AddDays(DateAndTime.Day(dateToday) * -1)
            dmpReportDate.Refresh()
        End Sub

        Private Sub OnOkButtonClicked()
            If IsNothing(dmpReportDate.Value) Then
                MessageBox.Show(Messages.PleaseEnterTheEndingDateForTheReport, StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dmpReportDate.Value < GbDateSerial(2018, 1, 1) Then
                Dim dDate = GbDateSerial(2018, 1, 1)
                MessageBox.Show(Messages.DateCanTBeLessThan + dDate.ToString(), StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf dmpReportDate.Value > Today Then
                MessageBox.Show(Messages.DateCanTBeGreaterThanTodaySDate, StringWords.ShowErrorMessage_Error, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Summary of Accounts Payables Arabic.rpt")
                Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "ibn-server", "IGroupClinic")
                Report.SetParameterValue("YearOfReport", GregorianYear(dmpReportDate.Value))
                Report.SetParameterValue("MonthOfReport", GregorianMonth(dmpReportDate.Value))
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace