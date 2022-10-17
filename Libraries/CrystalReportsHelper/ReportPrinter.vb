Imports System.Configuration
Imports CrystalDecisions.Shared

Public Class ReportPrinter

    Private Property Report As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Private Property ReportFileName As String

    Public Sub New()

    End Sub

    Public Sub New(printJobName As String, reportFileName As String, dataBaseConnectionName As String)
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


    Public Sub Load(reportPaths As String, reportFileName As String)
        Report.Load(reportPaths & reportFileName)
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


    'Private Sub ViewReport(reportFileName As String, reportTitle As String, cCulture As CultureInfo, ParamArray args() As Object)
    '    Dim cForm As Object


    '    cForm = New ReportFormNew(reportFileName, reportTitle, cCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboSupplierIdNo.SelectedItem.IdNo, "SupplierIdNo", cboSupplierIdNo.Text, "DisplayName")
    '    cForm.Show()


    'Public Sub ViewReport(ByVal fileName As String, ByVal reportTitle As String, formCulture As CultureInfo, ByVal ParamArray args() As Object)


    '    GetReportProperties()

    '    Dim language As String
    '    Dim establishmentName As String
    '    Presenter = New ReportPresenter(Me)
    '    language = Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
    '    If language <> "ar" Then
    '        establishmentName = Presenter.GetRecordField("Establishment", "EstablishmentName")
    '    Else
    '        establishmentName = Presenter.GetRecordField("Establishment", "EstablishmentNameAra")
    '    End If

    '    For i = 0 To args.Length - 1 Step 2
    '        Dim value As Object = args(i)
    '        Report.SetParameterValue(args(i + 1).ToString(), ConvertObjectToType(value))
    '    Next
    '    Report.SetParameterValue("ReportTitle", reportTitle)
    '    Report.SetParameterValue("EstablishmentName", establishmentName)
    '    Report.SetParameterValue("Language", language)
    '    Report.DataSourceConnections.Clear()
    '    ProcessReport()

    'End Sub

    Public Property MainTableName As String

End Class