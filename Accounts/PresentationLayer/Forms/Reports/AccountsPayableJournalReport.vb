Imports System.Configuration
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Forms.Reports
    Public Class AccountsPayableJournalReport
        Public Sub New(ByVal idNo As Int32, ByVal amount As String, ByVal lineTotal As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            Dim reportPaths As String = ConfigurationManager.AppSettings.Get("ReportPaths")
            Dim uid As String = ConfigurationManager.AppSettings.Get("UID")
            Dim pwd As String = ConfigurationManager.AppSettings.Get("PWD")
            Dim server As String = ConfigurationManager.AppSettings.Get("SERVER")
            Dim database As String = ConfigurationManager.AppSettings.Get("DATABASE")

            Report.Load(reportPaths & "Accounts Payable Journal.rpt")
            Report.SetParameterValue("AccountsPayableJournalIdNo", idNo)
            Report.SetParameterValue("CreditAmountInWords", amount)
            Report.SetParameterValue("TotalLineAmountInWords", lineTotal)
            Report.DataSourceConnections.Clear()

            Report.SetDatabaseLogon(uid, pwd, server, database)
            ProcessReport()
        End Sub


        Private Sub btnOk_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Close()
        End Sub
    End Class
End Namespace