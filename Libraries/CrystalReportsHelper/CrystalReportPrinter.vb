Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary.Messaging
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports PaperSize = CrystalDecisions.Shared.PaperSize

Public Class CrystalReportPrinter
    Private Const DefaultConnection As String = "ISPDATA"
    Private ReadOnly _report As New ReportDocument

    Private _reportPath As String
    Private _uid As String
    Private _pwd As String
    Private _server As String
    Private _database As String

    Public Sub New()
    End Sub

    Public Sub New(pReportFileName As String, Optional pDataBaseConnectionName As String = DefaultConnection, Optional pArgs() As Object = Nothing)
        ReportFileName = pReportFileName
        DataBaseConnectionName = IIf(pDataBaseConnectionName Is Nothing Or pDataBaseConnectionName = "", DefaultConnection, pDataBaseConnectionName)
        SetReportProperties(pReportFileName)
        If pArgs IsNot Nothing Then
            SetParameterValue(pArgs)
        End If

        'Args = pArgs
        'For i = 0 To Args.Length - 1 Step 2
        '    Dim value As Object = Args(i)
        '    _report.SetParameterValue(Args(i + 1).ToString(), ConvertObjectToType(value))
        'Next


        'Public Sub SetParameterValue(args() As Object)
        '    For i = 0 To args.Length - 1 Step 2
        '        Dim value As Object = GlobalFunctions.ConvertObjectToType(args(i))
        '        Dim name As String = args(i + 1).ToString()
        '        _report.SetParameterValue(name, value)
        '    Next
        'End Sub
        'If pArgs IsNot Nothing Then
        '    SetParameterValue(pArgs)
        'End If

    End Sub

    Public Sub SetReportProperties(pReportFileName As String)
        Select Case DataBaseConnectionName
            Case Nothing
                UseDefaultConnection()
            Case $"ISPDATA"
                UseDefaultConnection()
            Case $"IGROUPCLINIC"
                UseIGroupConnection()
            Case Else
                MessageBox.Show($"No database connection specified or connection name not recognized.")
                Debugger.Break()
                Return
        End Select
        _report.Load(_reportPath & pReportFileName)
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

    Public Property Args() As Object

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
                Case "PhItemBarcode"
                    _report.PrintOptions.PaperSize = 257
                    _report.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation
            End Select
        End If
    End Sub

    Public Overloads Sub SetPrintOption(printerName As String, paperSize As Int16, paperOrientation As Int16?, paperSource As Int16?)
        Dim dPrinterName As String = _report.PrintOptions.PrinterName
        Dim dPaperOrientation As Int16 = _report.PrintOptions.PaperOrientation
        Dim dPaperSource As Int16 = _report.PrintOptions.PaperSource
        Dim dPaperSize As Int16 = _report.PrintOptions.PaperSize
        Dim noPrinter As Boolean = _report.PrintOptions.NoPrinter
        Try
            If printerName IsNot Nothing Then
                _report.PrintOptions.NoPrinter = False
                _report.PrintOptions.PrinterName = printerName
                If paperSize <> 0 Then
                    Try
                        _report.PrintOptions.PaperSize = paperSize
                    Catch ex As Exception
                        _report.PrintOptions.PaperSize = dPaperOrientation
                    End Try
                Else
                    _report.PrintOptions.PaperSize = dPaperSize
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
                        _report.PrintOptions.PaperOrientation = po
                    Catch ex As Exception
                        _report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
                    End Try
                Else
                    _report.PrintOptions.PaperOrientation = dPaperOrientation
                End If
                If paperSource IsNot Nothing Then
                    Try
                        Try
                            _report.PrintOptions.PaperSource = paperSource
                        Catch ex As Exception
                            _report.PrintOptions.PaperSource = dPaperSource
                        End Try
                    Catch ex As Exception
                        _report.PrintOptions.PaperSource = dPaperSource
                    End Try
                Else
                    _report.PrintOptions.PaperSource = dPaperSource
                End If
            Else
                ' use currently selected printer and settings
                If PrinterExists(dPrinterName) Then
                    _report.PrintOptions.NoPrinter = noPrinter
                    _report.PrintOptions.PrinterName = dPrinterName
                    _report.PrintOptions.PaperSize = dPaperSize
                    _report.PrintOptions.PaperOrientation = dPaperOrientation
                    _report.PrintOptions.PaperSource = dPaperSource
                Else
                    Dim defaultPrinterName As PrinterSettings = New PrinterSettings()
                    Dim defaultPrinter As String = defaultPrinterName.PrinterName
                    _report.PrintOptions.PrinterName = defaultPrinterName.PrinterName
                    _report.PrintOptions.PaperSize = defaultPrinterName.DefaultPageSettings.PaperSize.RawKind
                    _report.PrintOptions.PaperSource = defaultPrinterName.DefaultPageSettings.PaperSource.RawKind
                    _report.PrintOptions.PaperOrientation = IIf(defaultPrinterName.DefaultPageSettings.Landscape, CrystalDecisions.Shared.PaperOrientation.Portrait, CrystalDecisions.Shared.PaperOrientation.Landscape)
                End If
            End If
        Catch
            MessageTimeOut("The specified printer does not exist or the report's printer setting is invalid, using Default Printer.", "Invalid Printer Setup", 5)
            Dim defaultPrinterName As PrinterSettings = New PrinterSettings()
            Dim defaultPrinter As String = defaultPrinterName.PrinterName
            _report.PrintOptions.PrinterName = defaultPrinterName.PrinterName
            _report.PrintOptions.PaperSize = defaultPrinterName.DefaultPageSettings.PaperSize.RawKind
            _report.PrintOptions.PaperSource = defaultPrinterName.DefaultPageSettings.PaperSource.RawKind
            _report.PrintOptions.PaperOrientation = IIf(defaultPrinterName.DefaultPageSettings.Landscape, CrystalDecisions.Shared.PaperOrientation.Portrait, CrystalDecisions.Shared.PaperOrientation.Landscape)
        End Try
    End Sub

    Private Sub SetPaperSize(paperName As String)
        Dim docToPrint As New System.Drawing.Printing.PrintDocument()
        docToPrint.PrinterSettings.PrinterName = _report.PrintOptions.PrinterName
        For i = 0 To docToPrint.PrinterSettings.PaperSizes.Count - 1
            Dim rawKind As Integer
            If docToPrint.PrinterSettings.PaperSizes(i).PaperName = paperName Then
                rawKind = CInt(docToPrint.PrinterSettings.PaperSizes(i).GetType().GetField("kind", Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(docToPrint.PrinterSettings.PaperSizes(i)))
                _report.PrintOptions.PaperSize = rawKind
                Exit For
            End If
        Next
    End Sub

    Public Sub PrintReport(Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 1, Optional endPage As Integer = 0)
        _report.PrintToPrinter(copies, collate, startPage, endPage)
    End Sub

    Public Sub SetParameterValue(args() As Object)
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

    Public Function SetPaperOrientation(paperOrientation As Int16) As CrystalDecisions.Shared.PaperOrientation
        Dim po As CrystalDecisions.Shared.PaperOrientation
        If paperOrientation = 1 Then
            po = CrystalDecisions.Shared.PaperOrientation.Portrait
        ElseIf paperOrientation = 2 Then
            po = CrystalDecisions.Shared.PaperOrientation.Landscape
        Else
            po = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation
        End If
        _report.PrintOptions.PaperOrientation = po
        Return po
    End Function

    Public Shared Function PrinterExists(printerName As String) As Boolean
        If String.IsNullOrEmpty(printerName) Then
            Throw New ArgumentNullException("printerName")
        End If
        Return PrinterSettings.InstalledPrinters.Cast(Of String)().Any(Function(name) printerName.ToUpper().Trim() = name.ToUpper().Trim())
    End Function

End Class