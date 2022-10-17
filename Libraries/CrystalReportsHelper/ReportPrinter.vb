Imports System.Configuration
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports CrystalDecisions.ReportAppServer.CommonControls
Imports CrystalDecisions.Shared

Public Class ReportPrinter
    Private Const DefaultConnection As String = "ISPDATA"
    Private ReadOnly _report As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private _reportPath As String
    Private _uid As String
    Private _pwd As String
    Private _server As String
    Private _database As String

    Public Sub New()

    End Sub

    Public Sub New(pPrintJobName As String, pReportFileName As String, Optional pDataBaseConnectionName As String = DefaultConnection)
        PrintJobName = pPrintJobName
        ReportFileName = pReportFileName
        DataBaseConnectionName = pDataBaseConnectionName
        SetReportProperties()
    End Sub

    Public Sub SetReportProperties()
        Select Case DataBaseConnectionName
            Case Nothing
                UseDefaultConnection()
            Case $"ISPDATA"
                UseDefaultConnection()
            Case $"IGROUP"
                UseIGroupConnection()
            Case Else
                MessageBox.Show($"No database connection specified or connection name not recognized.")
                Debugger.Break()
                Return
        End Select
        _report.Load(_reportPath & ReportFileName)
        If _report.DataSourceConnections.Count > 0 Then
            _report.DataSourceConnections(0).SetConnection(_server, _database, _uid, _pwd)
        End If
    End Sub

    Private Sub UseDefaultConnection()
        _reportPath = ConfigurationManager.AppSettings.Get("ReportPaths")
        _uid = ConfigurationManager.AppSettings.Get("UID")
        _pwd = ConfigurationManager.AppSettings.Get("PWD")
        _server = ConfigurationManager.AppSettings.Get("ServerTranslator")
        _database = ConfigurationManager.AppSettings.Get("Database")
    End Sub

    Private Sub UseIGroupConnection()
        _reportPath = ConfigurationManager.AppSettings.Get("ReportPathsIGroup")
        _uid = ConfigurationManager.AppSettings.Get("UID")
        _pwd = ConfigurationManager.AppSettings.Get("PWD")
        _server = ConfigurationManager.AppSettings.Get("ServerTranslator")
        _database = ConfigurationManager.AppSettings.Get("DatabaseIGroup")
    End Sub

    Public Property ReportFileName() As String

    Public Property PrintJobName() As String

    Public Property DataBaseConnectionName() As String

    Public Sub Load(reportPaths As String, cReportFileName As String)
        _report.Load(reportPaths & cReportFileName)
    End Sub

    Public Overloads Sub SetPrintOption()
        Dim computerName = System.Windows.Forms.SystemInformation.ComputerName
        If PrintJobName IsNot Nothing Then
            Select Case PrintJobName
                Case Nothing OrElse "" OrElse "Default"
                    _report.PrintOptions.PaperSize = PaperSize.PaperA4
                    _report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Case "A4P"
                    _report.PrintOptions.PaperSize = PaperSize.PaperA4
                    _report.PrintOptions.PaperOrientation = PaperOrientation.Portrait
                Case "A4L"
                    _report.PrintOptions.PaperSize = PaperSize.PaperA4
                    _report.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Case "A5P"
                    _report.PrintOptions.PaperSize = PaperSize.PaperA5
                    _report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Case "A5L"
                    _report.PrintOptions.PaperSize = PaperSize.PaperA5
                    _report.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Case "PhItemBarCode"
                    _report.PrintOptions.PaperSize = 257
                    _report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
            End Select
        End If
    End Sub

    Public Overloads Sub SetPrintOption(printerName As String, paperSize As Int16?, paperOrientation As Int16?, paperSource As Int16?)
        Dim computerName = System.Windows.Forms.SystemInformation.ComputerName
        If printerName IsNot Nothing Then
            _report.PrintOptions.NoPrinter = False
            _report.PrintOptions.PrinterName = printerName
        End If
        If paperSize IsNot Nothing Then
            _report.PrintOptions.PaperSize = paperSize
        End If
        If paperOrientation IsNot Nothing Then
            _report.PrintOptions.PaperOrientation = paperOrientation
        End If
        If paperSource IsNot Nothing Then
            _report.PrintOptions.PaperSource = paperSource
        End If
    End Sub

    Public Sub PrintReport(Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
        _report.PrintToPrinter(copies, collate, startPage, endPage)
    End Sub

    Public Sub SetParameterValue(ParamArray args() As Object)
        For i = 0 To args.Length - 1 Step 2
            Dim value As Object = GlobalFunctions.ConvertObjectToType(args(i))
            Dim name As String = args(i + 1).ToString()
            _report.SetParameterValue(name, value)
        Next
    End Sub

    Public Sub ClearDataSourceConnections()
        _report.DataSourceConnections.Clear()
    End Sub

    Public Function GetReportSource() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Return _report
    End Function

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
    '        _report.SetParameterValue(args(i + 1).ToString(), ConvertObjectToType(value))
    '    Next
    '    _report.SetParameterValue("ReportTitle", reportTitle)
    '    _report.SetParameterValue("EstablishmentName", establishmentName)
    '    _report.SetParameterValue("Language", language)
    '    _report.DataSourceConnections.Clear()
    '    ProcessReport()

    'End Sub

    Public Property MainTableName As String

End Class