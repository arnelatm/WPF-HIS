Imports System.Configuration
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportAppServer.Controllers
Imports CrystalDecisions.ReportAppServer.DataDefModel
Imports CrystalDecisions.Shared

Public Class ReportPrinter

    Private Property Report As New ReportDocument

    Public Sub New(dataBaseConnectionName As String, reportFileName As String)
        Dim reportPaths As String = ""
        Dim uid As String = ""
        Dim pwd As String = ""
        Dim server As String = ""
        Dim database As String = ""
        Select Case dataBaseConnectionName
            Case $"ISPDATA"
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPaths")
                uid = ConfigurationManager.AppSettings.Get("UID")
                pwd = ConfigurationManager.AppSettings.Get("PWD")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator")
                database = ConfigurationManager.AppSettings.Get("DATABASE")
            Case $"ISPDATA"
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPathsIGroup")
                uid = ConfigurationManager.AppSettings.Get("UID")
                pwd = ConfigurationManager.AppSettings.Get("PWD")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator")
                database = ConfigurationManager.AppSettings.Get($"DATABASEIGroup")
        End Select
        Report.Load(reportPaths & reportFileName)
        If Report.DataSourceConnections.Count > 0 Then
            Report.DataSourceConnections(0).SetConnection(server, database, uid, pwd)
        End If
    End Sub

    Public Sub SetPrintOption(printJobName As String)
        If printJobName IsNot Nothing Then
            Select Case printJobName
                Case "PhItemBarCode"
                    Report.PrintOptions.PrinterName = "Ad"
                    Report.PrintOptions.PaperSize = 257
                    Report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                    Report.PrintOptions.PaperSource = PaperSource.Auto
            End Select

        End If
    End Sub

End Class