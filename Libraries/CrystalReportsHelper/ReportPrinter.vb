Imports System.Configuration
Imports CrystalDecisions.Shared

Public Class ReportPrinter

    Private Property Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Private Property ReportFileName As String


    Public Sub New(dataBaseConnectionName As String, reportFileName As String, printJobName As String)
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
                database = ConfigurationManager.AppSettings.Get("Database")
            Case $"IGROUP"
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPathsIGroup")
                uid = ConfigurationManager.AppSettings.Get("UID")
                pwd = ConfigurationManager.AppSettings.Get("PWD")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator")
                database = ConfigurationManager.AppSettings.Get($"DatabaseIGroup")
        End Select
        Report.Load(reportPaths & reportFileName)
        If Report.DataSourceConnections.Count > 0 Then
            Report.DataSourceConnections(0).SetConnection(server, database, uid, pwd)
        End If
        SetPrintOption(printJobName)
        Me.ReportFileName = reportFileName
    End Sub

    Public Sub SetPrintOption(printJobName As String)
        If printJobName IsNot Nothing Then
            Select Case printJobName
                Case "PhItemBarCode"
                    Report.PrintOptions.PrinterName = $"ZDesigner GK420t Barcode"
                    Report.PrintOptions.PaperSize = 257
                    Report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                    Report.PrintOptions.PaperSource = PaperSource.Lower
            End Select

        End If
    End Sub

    Public Sub PrintReport()
        'Dim rptDOc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        'Report.Load(ReportFileName)
        Report.PrintToPrinter(1, False, 0, 0)
    End Sub

End Class