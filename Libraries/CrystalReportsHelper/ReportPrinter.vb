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
        'SetPrintOption(printJobName)
        Me.ReportFileName = reportFileName
    End Sub

    Public Overloads Sub SetPrintOption(printJobName As String)
        Dim computerName = System.Windows.Forms.SystemInformation.ComputerName
        If printJobName IsNot Nothing Then
            Select Case printJobName
                Case Nothing OrElse "" OrElse "Default"
                    Report.PrintOptions.PaperSize = PaperSize.PaperA4
                    Report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Case "A4P"
                    Report.PrintOptions.PaperSize = PaperSize.PaperA4
                    Report.PrintOptions.PaperOrientation = PaperOrientation.Portrait
                Case "A4L"
                    Report.PrintOptions.PaperSize = PaperSize.PaperA4
                    Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Case "A5P"
                    Report.PrintOptions.PaperSize = PaperSize.PaperA5
                    Report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Case "A5L"
                    Report.PrintOptions.PaperSize = PaperSize.PaperA5
                    Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Case "PhItemBarCode"
                    Report.PrintOptions.PaperSize = 257
                    Report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
            End Select
        End If
    End Sub

    Public Overloads Sub SetPrintOption(printerName As String, paperSize As Int16?, paperOrientation As Int16?, paperSource As Int16?)
        Dim computerName = System.Windows.Forms.SystemInformation.ComputerName
        If printerName IsNot Nothing Then
            Report.PrintOptions.NoPrinter = False
            Report.PrintOptions.PrinterName = printerName
        End If
        If paperSize IsNot Nothing Then
            Report.PrintOptions.PaperSize = paperSize
        End If
        If paperOrientation IsNot Nothing Then
            Report.PrintOptions.PaperOrientation = paperOrientation
        End If
        If paperSource IsNot Nothing Then
            Report.PrintOptions.PaperSource = paperSource
        End If
    End Sub

    Public Sub PrintReport(Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
        Report.PrintToPrinter(copies, collate, startPage, endPage)
    End Sub

End Class