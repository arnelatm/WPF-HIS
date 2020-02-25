Imports System.Windows.Forms
Imports AATM.Libraries.Languages

Namespace PresentationLayer.Forms.Reports

    Public Class IncomeStatementYearly

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            AddHandler MyBase.OkButtonClicked, AddressOf Me.OnOkButtonClicked
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub ApSummary_Load() Handles MyBase.Load
            Dim dateToday As DateTime
            dateToday = DateAndTime.Now
            txtReportYear.Text = dateToday.Year - 1
            txtReportYear.Refresh()
        End Sub

        Protected Sub OnOkButtonClicked()
            If IsNothing(txtReportYear.Text) Then
                MessageBox.Show(Messages.PleaseEnterDesiredYearOf_Report)
            ElseIf txtReportYear.Text < StringWords.Constant_LastPostingYearForAccountingData Then
                MessageBox.Show(Messages.DateCanTBeLessThan + " " + StringWords.Constant_LastPostingYearForAccountingData)
            ElseIf txtReportYear.Text > Now.Year Then
                MessageBox.Show(Messages.DateCanTBeGreaterThanTodaySDate)
            Else
                Report.Load("\\IBN-SERVER\ISP\Accounts\Reports\Income Statement Arabic Yearly.rpt")
                Report.SetParameterValue("YearOfReport", txtReportYear.Text)
                ProcessReport()
            End If
        End Sub

    End Class

End Namespace