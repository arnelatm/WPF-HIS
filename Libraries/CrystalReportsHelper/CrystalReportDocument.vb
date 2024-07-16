Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary.Messaging
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports PaperSize = CrystalDecisions.Shared.PaperSize

Public Class CrystalReportDocument
    Private Const DEFAULT_CONNECTION As String = "ISPDATA"
    Private ReadOnly _crystalReportDocument As New ReportDocument

    Private _reportPath As String
    Private _uid As String
    Private _pwd As String
    Private _server As String
    Private _database As String
    Private _reportFileName As String
    Private _databaseConnectionCode As String = DEFAULT_CONNECTION

    Public Sub New()
    End Sub


    Public Sub New(crReportFileName As String, Optional crReportArgs() As Object = Nothing, Optional dbConnectionCode As String = DEFAULT_CONNECTION)
        Me.ReportFileName = crReportFileName
        Me.DataBaseConnectionCode = dbConnectionCode
        SetCrReportConnectionProperties()
        If crReportArgs IsNot Nothing Then
            SetParameterValue(crReportArgs)
        End If
    End Sub

    Public Property ReportFileName As String
        Get
            Return _reportFileName
        End Get
        Set(value As String)
            _reportFileName = value
        End Set
    End Property

    Public Property DataBaseConnectionCode As String
        Get
            Return _databaseConnectionCode
        End Get
        Set(value As String)
            _databaseConnectionCode = value
        End Set
    End Property

    Public ReadOnly Property ReportDocument As ReportDocument
        Get
            Return _crystalReportDocument
        End Get
    End Property


    Public Sub SetCrReportConnectionProperties()
        Select Case DataBaseConnectionCode.ToUpper()
            Case Nothing
                UseDefaultConnection()
            Case DEFAULT_CONNECTION
                UseDefaultConnection()
            Case $"IGROUPCLINIC"
                UseIGroupConnection()
            Case Else
                MessageBox.Show($"No database connection specified or connection name not recognized.")
                Debugger.Break()
                Return
        End Select
        Dim fileSpecification As String = _reportPath & ReportFileName
        _crystalReportDocument.Load(fileSpecification)
        If _crystalReportDocument.DataSourceConnections.Count > 0 Then
            _crystalReportDocument.DataSourceConnections(0).SetConnection(_server, _database, _uid, _pwd)
        End If
    End Sub

    Private Sub UseDefaultConnection()
        _reportPath = ConfigurationManager.AppSettings.Get("ReportPaths")
        _database = ConfigurationManager.AppSettings.Get("Database")
        SetupServerUserNPassword()
    End Sub

    Private Sub UseIGroupConnection()
        _reportPath = ConfigurationManager.AppSettings.Get("ReportPathsIGroup")
        _database = ConfigurationManager.AppSettings.Get("DatabaseIGroup")
        SetupServerUserNPassword()
    End Sub

    Private Sub SetupServerUserNPassword()
        _uid = ConfigurationManager.AppSettings.Get("UID")
        _pwd = ConfigurationManager.AppSettings.Get("PWD")
        _server = ConfigurationManager.AppSettings.Get("ServerTranslator")
    End Sub

    Public Property PrintJobName As String

    'Public Sub Load(reportPaths As String, cReportFileName As String)
    '    _report.Load(reportPaths & cReportFileName)
    'End Sub

    Public Overloads Sub SetPrintOption()
        'Dim computerName = System.Windows.Forms.SystemInformation.ComputerName
        If PrintJobName IsNot Nothing Then
            Select Case PrintJobName
                Case Nothing OrElse "" OrElse "Default"
                    _crystalReportDocument.PrintOptions.PaperSize = PaperSize.PaperA4
                    _crystalReportDocument.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Case "A4P"
                    _crystalReportDocument.PrintOptions.PaperSize = PaperSize.PaperA4
                    _crystalReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Portrait
                Case "A4L"
                    _crystalReportDocument.PrintOptions.PaperSize = PaperSize.PaperA4
                    _crystalReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Case "A5P"
                    _crystalReportDocument.PrintOptions.PaperSize = PaperSize.PaperA5
                    _crystalReportDocument.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
                Case "A5L"
                    _crystalReportDocument.PrintOptions.PaperSize = PaperSize.PaperA5
                    _crystalReportDocument.PrintOptions.PaperOrientation = PaperOrientation.Landscape
                Case "PhItemBarcode"
                    _crystalReportDocument.PrintOptions.PaperSize = 257
                    _crystalReportDocument.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
            End Select
        End If
    End Sub

    Public Overloads Sub SetPrintOption(printerName As String, paperSize As Int16, paperOrientation As Int16?, paperSource As Int16?)
        Dim dPrinterName As String = _crystalReportDocument.PrintOptions.PrinterName
        Dim dPaperOrientation As Int16 = _crystalReportDocument.PrintOptions.PaperOrientation
        Dim dPaperSource As Int16 = _crystalReportDocument.PrintOptions.PaperSource
        Dim dPaperSize As Int16 = _crystalReportDocument.PrintOptions.PaperSize
        Dim noPrinter As Boolean = _crystalReportDocument.PrintOptions.NoPrinter
        Try
            If printerName IsNot Nothing Then
                _crystalReportDocument.PrintOptions.NoPrinter = False
                _crystalReportDocument.PrintOptions.PrinterName = printerName
                If paperSize <> 0 Then
                    Try
                        _crystalReportDocument.PrintOptions.PaperSize = paperSize
                    Catch ex As Exception
                        _crystalReportDocument.PrintOptions.PaperSize = dPaperOrientation
                    End Try
                Else
                    _crystalReportDocument.PrintOptions.PaperSize = dPaperSize
                End If
                If paperOrientation IsNot Nothing Then
                    Try
                        Dim po As CrystalDecisions.Shared.PaperOrientation
                        If paperOrientation = 1 Then
                            po = CrystalDecisions.Shared.PaperOrientation.Portrait
                        ElseIf paperOrientation = 2 Then
                            po = CrystalDecisions.Shared.PaperOrientation.Landscape
                        Else
                            po = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
                        End If
                        _crystalReportDocument.PrintOptions.PaperOrientation = po
                    Catch ex As Exception
                        _crystalReportDocument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
                    End Try
                Else
                    _crystalReportDocument.PrintOptions.PaperOrientation = dPaperOrientation
                End If
                If paperSource IsNot Nothing Then
                    Try
                        Try
                            _crystalReportDocument.PrintOptions.PaperSource = paperSource
                        Catch ex As Exception
                            _crystalReportDocument.PrintOptions.PaperSource = dPaperSource
                        End Try
                    Catch ex As Exception
                        _crystalReportDocument.PrintOptions.PaperSource = dPaperSource
                    End Try
                Else
                    _crystalReportDocument.PrintOptions.PaperSource = dPaperSource
                End If
            Else
                ' use currently selected printer and settings
                If PrinterExists(dPrinterName) Then
                    _crystalReportDocument.PrintOptions.NoPrinter = noPrinter
                    _crystalReportDocument.PrintOptions.PrinterName = dPrinterName
                    _crystalReportDocument.PrintOptions.PaperSize = dPaperSize
                    _crystalReportDocument.PrintOptions.PaperOrientation = dPaperOrientation
                    _crystalReportDocument.PrintOptions.PaperSource = dPaperSource
                Else
                    Dim defaultPrinterName As PrinterSettings = New PrinterSettings()
                    Dim defaultPrinter As String = defaultPrinterName.PrinterName
                    _crystalReportDocument.PrintOptions.PrinterName = defaultPrinterName.PrinterName
                    _crystalReportDocument.PrintOptions.PaperSize = defaultPrinterName.DefaultPageSettings.PaperSize.RawKind
                    _crystalReportDocument.PrintOptions.PaperSource = defaultPrinterName.DefaultPageSettings.PaperSource.RawKind
                    _crystalReportDocument.PrintOptions.PaperOrientation = IIf(defaultPrinterName.DefaultPageSettings.Landscape, CrystalDecisions.Shared.PaperOrientation.Portrait, CrystalDecisions.Shared.PaperOrientation.Landscape)
                End If
            End If
        Catch
            MessageTimeOut("The specified printer does not exist or the report's printer setting is invalid, using Default Printer.", "Invalid Printer Setup", 5)
            Dim defaultPrinterName As PrinterSettings = New PrinterSettings()
            Dim defaultPrinter As String = defaultPrinterName.PrinterName
            _crystalReportDocument.PrintOptions.PrinterName = defaultPrinterName.PrinterName
            _crystalReportDocument.PrintOptions.PaperSize = defaultPrinterName.DefaultPageSettings.PaperSize.RawKind
            _crystalReportDocument.PrintOptions.PaperSource = defaultPrinterName.DefaultPageSettings.PaperSource.RawKind
            _crystalReportDocument.PrintOptions.PaperOrientation = IIf(defaultPrinterName.DefaultPageSettings.Landscape, CrystalDecisions.Shared.PaperOrientation.Portrait, CrystalDecisions.Shared.PaperOrientation.Landscape)
        End Try
    End Sub

    Private Sub SetPaperSize(paperName As String)
        Dim docToPrint As New System.Drawing.Printing.PrintDocument()
        docToPrint.PrinterSettings.PrinterName = _crystalReportDocument.PrintOptions.PrinterName
        For i = 0 To docToPrint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            If docToPrint.PrinterSettings.PaperSizes(i).PaperName = paperName Then
                rawKind = CInt(docToPrint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(docToPrint.PrinterSettings.PaperSizes(i)))
                _crystalReportDocument.PrintOptions.PaperSize = rawKind
                Exit For
            End If
        Next
    End Sub

    Public Sub PrintReport(Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 1, Optional endPage As Integer = 0)
        _crystalReportDocument.PrintToPrinter(copies, collate, startPage, endPage)
    End Sub

    Public Sub SetParameterValue(args() As Object)
        For i = 0 To args.Length - 1 Step 2
            Dim value As Object = GlobalFunctions.ConvertObjectToType(args(i))
            Dim name As String = args(i + 1).ToString()
            _crystalReportDocument.SetParameterValue(name, value)
        Next
    End Sub

    Public Sub ClearDataSourceConnections()
        _crystalReportDocument.DataSourceConnections.Clear()
    End Sub

    Public Function GetReportSource() As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Return _crystalReportDocument
    End Function

    Public Function SetPaperOrientation(paperOrientation As Int16) As CrystalDecisions.Shared.PaperOrientation
        Dim po As CrystalDecisions.Shared.PaperOrientation
        If paperOrientation = 1 Then
            po = CrystalDecisions.Shared.PaperOrientation.Portrait
        ElseIf paperOrientation = 2 Then
            po = CrystalDecisions.Shared.PaperOrientation.Landscape
        Else
            po = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
        End If
        _crystalReportDocument.PrintOptions.PaperOrientation = po
        Return po
    End Function

    Public Shared Function PrinterExists(printerName As String) As Boolean
        If String.IsNullOrEmpty(printerName) Then
            Throw New ArgumentNullException("printerName")
        End If
        Return PrinterSettings.InstalledPrinters.Cast(Of String)().Any(Function(name) printerName.ToUpper().Trim() = name.ToUpper().Trim())
    End Function

End Class