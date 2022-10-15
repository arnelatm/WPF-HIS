Imports System.Configuration
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportAppServer.DataDefModel

Public Class CrystalReporsHelper

    Public Report As New ReportDocument

    Public Property ReportFileName As String

    Protected Sub New()
        Dim reportPaths As String = ConfigurationManager.AppSettings.Get("ReportPaths")
        Dim uid As String = ConfigurationManager.AppSettings.Get("UID")
        Dim pwd As String = ConfigurationManager.AppSettings.Get("PWD")
        Dim server As String = ConfigurationManager.AppSettings.Get("ServerTranslator")
        Dim database As String = ConfigurationManager.AppSettings.Get("DATABASE")
        Report.Load(reportPaths & ReportFileName)
        If Report.DataSourceConnections.Count > 0 Then
            Report.DataSourceConnections(0).SetConnection(server, database, uid, pwd)
        End If
    End Sub

    Protected Sub ProcessReport()
        WindowState = FormWindowState.Maximized
        Dim ceCulture As CeLocale
        If Me.FormCulture.Name.ToLower().Remove(2) = "ar" Then
            ceCulture = CeLocale.ceLocaleArabicSaudiArabia
        Else
            ceCulture = CeLocale.ceLocaleEnglish
        End If
        'Dim x As Integer = CInt(ceCulture)
        With CrystalReportViewer1
            .Visible = True
            .BringToFront()
            .ReportSource = Report
            .SetProductLocale(CInt(ceCulture))
            .Refresh()
        End With

        btnQuit.Visible = True

    End Sub

End Class