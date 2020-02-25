Imports System.Windows.Forms
Imports AATM.Languages

Namespace PresentationLayer.Forms.Reports

    Public Class BalanceSheetYearlyReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            AddHandler MyBase.OkButtonClicked, AddressOf OnOkButtonClicked

        End Sub

        Private Sub BalanceSheetYearly_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = Now
            txtReportYear.Text = dateToday.Year - 1
            txtReportYear.Refresh()
        End Sub

        Protected Sub OnOkButtonClicked()
            If IsNothing(txtReportYear.Text) Then
                MessageBox.Show(Messages.PleaseEnterTheEndingDateForTheReport)
            ElseIf txtReportYear.Text < StringWords.Constant_LastPostingYearForAccountingData Then
                MessageBox.Show(Messages.DateCanTBeLessThan + StringWords.Constant_LastPostingYearForAccountingData)
            ElseIf txtReportYear.Text > Now.Year Then
                MessageBox.Show(Messages.DateCanTBeGreaterThanTodaySDate)
            Else
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Balance Sheet Arabic Yearly.rpt")
                Report.SetParameterValue("YearOfReport", txtReportYear.Text)
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace