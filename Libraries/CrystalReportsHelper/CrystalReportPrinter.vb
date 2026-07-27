Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary.Messaging
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows.Forms
Imports PaperSize = CrystalDecisions.Shared.PaperSize
Imports System.IO

Public Class CrystalReportPrinter
    Private Const DefaultConnection As String = "ISPDATA"
    Private _report As ReportDocument

    Private _reportPath As String
    Private _uid As String
    Private _pwd As String
    Private _server As String
    Private _database As String

    Public Sub New()
    End Sub

    Public Sub New(pReportFileName As String,
               Optional pDataBaseConnectionName As String = DefaultConnection,
               Optional pArgs() As Object = Nothing,
               Optional promptForParametersWhenMissing As Boolean = False)

        ReportFileName = pReportFileName
        DataBaseConnectionName = IIf(pDataBaseConnectionName Is Nothing Or pDataBaseConnectionName = "", DefaultConnection, pDataBaseConnectionName)
        SetReportProperties(pReportFileName)

        If pArgs IsNot Nothing Then
            SetParameterValue(pArgs)
        ElseIf promptForParametersWhenMissing Then
            Try
                If _report IsNot Nothing AndAlso _report.DataDefinition IsNot Nothing AndAlso _report.DataDefinition.ParameterFields.Count > 0 Then
                    PromptForParameters()
                End If
            Catch
            End Try
        End If
    End Sub

    Public Sub SetReportProperties(pReportFileName As String, databaseConnection As String)
        Select Case databaseConnection.ToUpper()
            Case Nothing
                UseDefaultConnection()
            Case $"ISPDATA"
                UseDefaultConnection()
            Case $"IGROUPCLINIC"
                UseIGroupConnection()
            Case $"KIZEN"
                UseKizenConnection()
            Case $"BIOTIME"
                UseBioTimeConnection()
            Case Else
                MessageBox.Show($"No database connection specified or connection name not recognized.")
                Debugger.Break()
                Return
        End Select
        _report.Load(_reportPath & IIf(Strings.Right(pReportFileName, 4).ToLower() = $".rpt", pReportFileName, pReportFileName + ".rpt"))
        If _report.DataSourceConnections.Count > 0 Then
            _report.DataSourceConnections(0).SetConnection(_server, _database, _uid, _pwd)
        End If
    End Sub


    Private Sub ResetReportDocument()
        If _report IsNot Nothing Then
            Try
                _report.Close()
            Catch
            End Try

            Try
                _report.Dispose()
            Catch
            End Try

            _report = Nothing
        End If

        _report = New ReportDocument()
    End Sub

    Public Sub SetReportProperties(pReportFileName As String)
        Select Case DataBaseConnectionName.ToUpper()
            Case Nothing
                UseDefaultConnection()
            Case $"ISPDATA"
                UseDefaultConnection()
            Case $"IGROUPCLINIC"
                UseIGroupConnection()
            Case $"KIZEN"
                UseKizenConnection()
            Case $"BIOTIME"
                UseBioTimeConnection()
            Case Else
                MessageBox.Show($"No database connection specified or connection name not recognized.")
                Debugger.Break()
                Return
        End Select

        ResetReportDocument()

        Dim fileSpecification As String = Path.Combine(_reportPath, pReportFileName)
        _report.Load(fileSpecification, OpenReportMethod.OpenReportByTempCopy)

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

    Private Sub UseKizenConnection()
        _reportPath = ConfigurationManager.AppSettings.Get("ReportPathsKizen")
        _uid = ConfigurationManager.AppSettings.Get("UIDKizen")
        _pwd = ConfigurationManager.AppSettings.Get("PWDKizen")
        _server = ConfigurationManager.AppSettings.Get("ServerTranslatorKizen")
        _database = ConfigurationManager.AppSettings.Get("DatabaseKizen")
    End Sub

    Private Sub UseBioTimeConnection()
        _reportPath = ConfigurationManager.AppSettings.Get("ReportPathsBioTime")
        _uid = ConfigurationManager.AppSettings.Get("UIDBioTime")
        _pwd = ConfigurationManager.AppSettings.Get("PWDBioTime")
        _server = ConfigurationManager.AppSettings.Get("ServerTranslatorBioTime")
        _database = ConfigurationManager.AppSettings.Get("DatabaseBioTime")
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
        If args IsNot Nothing Then
            For i = 0 To args.Length - 1 Step 2
                Dim value As Object = GlobalFunctions.ConvertObjectToType(args(i))
                Dim name As String = args(i + 1).ToString()
                SetReportParameterValue(name, value)
            Next
        End If
    End Sub

    Public Sub SetParameterValues(args() As Object)
        For i = 0 To args.Length - 1 Step 2
            Dim value As Object = GlobalFunctions.ConvertObjectToType(args(i))
            Dim name As String = args(i + 1).ToString()
            SetReportParameterValue(name, value)
        Next
    End Sub

    Private Sub SetReportParameterValue(name As String, value As Object)
        Dim resolvedName As String = ResolveParameterName(name)

        If resolvedName Is Nothing Then
            If IsOptionalReportParameter(name) Then
                Return
            End If

            Throw New ArgumentException(
                $"Crystal report parameter '{name}' was not found. Available parameters: {GetAvailableParameterNames()}")
        End If

        _report.SetParameterValue(resolvedName, value)
    End Sub

    Private Function ResolveParameterName(name As String) As String
        If _report Is Nothing OrElse _report.DataDefinition Is Nothing Then
            Return name
        End If

        For Each pf As ParameterFieldDefinition In _report.DataDefinition.ParameterFields
            If String.Equals(pf.ParameterFieldName, name, StringComparison.OrdinalIgnoreCase) Then
                Return pf.ParameterFieldName
            End If
        Next

        Dim alternateName As String
        If name.StartsWith("@", StringComparison.Ordinal) Then
            alternateName = name.Substring(1)
        Else
            alternateName = "@" & name
        End If

        For Each pf As ParameterFieldDefinition In _report.DataDefinition.ParameterFields
            If String.Equals(pf.ParameterFieldName, alternateName, StringComparison.OrdinalIgnoreCase) Then
                Return pf.ParameterFieldName
            End If
        Next

        For Each pf As ParameterFieldDefinition In _report.DataDefinition.ParameterFields
            Dim normalizedParameterName As String = pf.ParameterFieldName.TrimStart("@"c)
            Dim normalizedRequestedName As String = name.TrimStart("@"c)
            If String.Equals(normalizedParameterName, normalizedRequestedName, StringComparison.OrdinalIgnoreCase) Then
                Return pf.ParameterFieldName
            End If
        Next

        Return Nothing
    End Function

    Private Function IsOptionalReportParameter(name As String) As Boolean
        Return String.Equals(name, "ReportTitle", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(name, "EstablishmentName", StringComparison.OrdinalIgnoreCase) OrElse
               String.Equals(name, "Language", StringComparison.OrdinalIgnoreCase)
    End Function

    Private Function GetAvailableParameterNames() As String
        If _report Is Nothing OrElse _report.DataDefinition Is Nothing Then
            Return String.Empty
        End If

        Dim names As New System.Collections.Generic.List(Of String)
        For Each pf As ParameterFieldDefinition In _report.DataDefinition.ParameterFields
            names.Add(pf.ParameterFieldName)
        Next

        Return String.Join(", ", names)
    End Function

    Private Sub ClearParameterValues()
        If _report Is Nothing OrElse _report.DataDefinition Is Nothing Then
            Return
        End If

        For Each pf As ParameterFieldDefinition In _report.DataDefinition.ParameterFields
            Try
                ' Skip parameters that Crystal manages internally (often start with ?)
                ' If you have no such params, you can remove this check.
                If pf.ParameterFieldName IsNot Nothing AndAlso pf.ParameterFieldName.StartsWith("?", StringComparison.Ordinal) Then
                    Continue For
                End If

                ' Reset value so Crystal considers it "missing" and prompts again
                _report.SetParameterValue(pf.ParameterFieldName, DBNull.Value)
            Catch
                ' Some parameter types / subreport parameters may throw; best-effort
            End Try
        Next
    End Sub

    Public Sub ClearParameterValues(parameterNames As IEnumerable(Of String))
        If parameterNames Is Nothing OrElse _report Is Nothing OrElse _report.DataDefinition Is Nothing Then
            Return
        End If

        For Each name As String In parameterNames
            Dim resolvedName As String = ResolveParameterName(name)

            If resolvedName Is Nothing Then
                Continue For
            End If

            Try
                Dim parameterDefinition As ParameterFieldDefinition = _report.DataDefinition.ParameterFields(resolvedName)
                Dim emptyValues As New ParameterValues()
                parameterDefinition.ApplyCurrentValues(emptyValues)
            Catch
            End Try
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

    ''' <summary>
    ''' Show a modal dialog with a CrystalReportViewer configured to prompt for missing parameter values.
    ''' Call this when you want the user to be prompted for parameters instead of setting them programmatically.
    ''' </summary>
    Public Sub PromptForParameters(Optional owner As IWin32Window = Nothing)
        Try
            If _report Is Nothing Then
                Throw New InvalidOperationException("Report document is not loaded.")
            End If

            If _report.DataDefinition Is Nothing OrElse _report.DataDefinition.ParameterFields.Count = 0 Then
                Return
            End If

            ClearParameterValues()

            Using frm As New Form()
                Using viewer As New CrystalDecisions.Windows.Forms.CrystalReportViewer()
                    viewer.Dock = DockStyle.Fill
                    viewer.ReportSource = _report
                    viewer.ToolPanelView = ToolPanelViewType.ParameterPanel
                    viewer.ShowParameterPanelButton = True

                    ' Best-effort for versions that have it
                    Try
                        Dim pi = viewer.GetType().GetProperty("EnableParameterPrompt")
                        If pi IsNot Nothing AndAlso pi.CanWrite Then
                            pi.SetValue(viewer, True, Nothing)
                        End If
                    Catch
                    End Try

                    frm.Text = If(String.IsNullOrEmpty(PrintJobName), ReportFileName, PrintJobName) & " - Parameters"
                    frm.StartPosition = FormStartPosition.CenterParent
                    frm.Width = 900
                    frm.Height = 700
                    frm.Controls.Add(viewer)

                    ' Trigger the prompt by refreshing once the form is displayed
                    AddHandler frm.Shown,
                    Sub(sender, e)
                        Try
                            viewer.RefreshReport()
                        Catch
                            ' If refresh fails, the user can still input via parameter panel
                        End Try
                    End Sub

                    If owner IsNot Nothing Then
                        frm.ShowDialog(owner)
                    Else
                        frm.ShowDialog()
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Unable to prompt for parameters: {ex.Message}", "Parameter Prompt Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Public Class CrPrintableArgs

        Public Property ReportFileName As String
        Public Property CultureInfo As String
        Public Property Language As String
        Public Property ReportParameters As Object()
        Public Property DataBaseConnectionName As String = "ISPDATA"
        Public Property Copies As Integer = 1
        Public Property Collate As Boolean = True
        Public Property StartPage As Integer = 0
        Public Property EndPage As Integer = 0
        Public Property ReportTitle As String = ""
        Public Property PromptParameterNames As String()
        Public Property RepeatPromptAfterClose As Boolean = False


    End Class

End Class
