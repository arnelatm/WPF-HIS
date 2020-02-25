Imports System.Windows.Forms
Imports AATM.Libraries.Languages

Namespace PresentationLayer.Forms.Reports

    Public Class TrialBalanceYearlyReport

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            AddHandler OkButtonClicked, AddressOf OnOkButtonClicked
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub BalanceSheetMonthlyReport_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = Now
            txtReportYear.Text = dateToday.Year - 1
            txtReportYear.Refresh()
        End Sub

        Private Sub OnOkButtonClicked()
            If IsNothing(txtReportYear.Text) Then
                MessageBox.Show(Messages.PleaseEnterDesiredYearOf_Report)
            ElseIf txtReportYear.Text < StringWords.Constant_LastPostingYearForAccountingData Then
                MessageBox.Show(Messages.YearCanTBeLessThan + "2018!")
            ElseIf txtReportYear.Text > Now.Year Then
                MessageBox.Show(Messages.YearCanTBeGreaterThanTodaySYear)
            Else
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Trial Balance Arabic Yearly.rpt")
                Report.SetParameterValue("YearOfReport", txtReportYear.Text)
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace