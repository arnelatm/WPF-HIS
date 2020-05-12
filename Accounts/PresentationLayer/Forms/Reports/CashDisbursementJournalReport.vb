Imports System.Configuration

Namespace PresentationLayer.Forms.Reports
    Public Class CashDisbursementJournalReport
        Public Sub New(ByVal idNo As Int32, ByVal amount As String, ByVal lineTotal As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            Dim reportPaths As String = ConfigurationManager.AppSettings.Get("ReportPaths")

            Report.Load(reportPaths & "Cash Disbursement Journal.rpt")
            Report.SetParameterValue("CashDisbursementJournalIdNo", idNo)
            Report.SetParameterValue("CreditAmountInWords", amount)
            Report.SetParameterValue("TotalLineAmountInWords", lineTotal)
            Report.DataSourceConnections.Clear()
            Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "IBN-SERVER", "ISPDATA")
            ProcessReport()

        End Sub
    End Class
End Namespace