Imports System.Drawing.Printing
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class PrinterPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrinterView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IPrinterView)
            MyBase.New(view)
            Service = New CommonService("Printer")
            TableName = "Printer"
            TableBaseName = "Printer"
            TreeViewMainField = "PrinterName"
            TreeViewSecondaryField = "PrinterCode"
            AddHandler view.CheckPrinterClicked, AddressOf OnCheckPrinterClicked
            AddHandler view.PrinterChanged, AddressOf OnPrinterChanged

        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSourceGroupCode("DefaultPaperOrientation", "PPOR")
            'CreateDataSourceGroupCode("DefaultPaperSize", "PPSZ")
            'CreateDataSourceGroupCode("DefaultPaperSource", "PPSR")
        End Sub

        Private Sub OnCheckPrinterClicked(sender As Object)
            'Dim prPresenter As New PrintReportPresenter()
            'prPresenter.PrintReport(reportFileName, jobName, databaseConnectionName)
            If String.IsNullOrEmpty(View.PrinterName) Then
                Throw New ArgumentNullException("printerName")
            End If
            If View.PrinterName IsNot Nothing Then
                Dim printer As String
                If GlobalFunctions.IsEmpty(View.HostOrIpName) Or View.HostOrIpName = Environment.MachineName Then
                    printer = View.PrinterName
                Else
                    printer = "\\" + View.HostOrIpName + "\" + View.PrinterName
                End If
                If PrinterSettings.InstalledPrinters.Cast(Of String)().Any(Function(name) printer.ToUpper().Trim() = name.ToUpper().Trim()) Then
                    MessageBox.Show("Printer OK")
                    Dim data = GetPrinterPageInfo(printer)
                    Debugger.Break()
                    Dim supportedPaperSize As String = ""
                    For Each item As PaperSize In data.PrinterSettings.PaperSizes
                        supportedPaperSize += item.PaperName + item.PaperName + vbCrLf
                    Next
                    MessageBox.Show(supportedPaperSize)
                Else
                    MessageBox.Show("Printer doesn't exist")
                End If
                'Debugger.Break()
            End If

            'View.PayFrequency = Service.GetField(Of String, Int16)(View.PayCycleIdNo, "PayCycle", "IdNo", "PayFrequency")
        End Sub

        Private Sub OnPrinterChanged(sender As Object)
            SetPrinterSupportedPaper(View.PrinterName)
            SetPrinterSupportedSources(View.PrinterName)
        End Sub

        Private Sub SetPrinterSupportedPaper(pPrinterName As String)
            Dim data = GetPrinterPageInfo(pPrinterName)
            Dim paperSizeLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            For Each item As PaperSize In data.PrinterSettings.PaperSizes
                Dim dbLookup = New Lookup.LookupData
                dbLookup.IdNo = item.RawKind
                dbLookup.Name = item.PaperName
                dbLookup.Code = item.Kind
                dbLookup.Index = index
                paperSizeLookup.Add(dbLookup)
                index += 1
            Next
            GetControlName("DefaultPaperSize").DataSource = paperSizeLookup
        End Sub

        Private Sub SetPrinterSupportedSources(pPrinterName As String)
            Dim data = GetPrinterPageInfo(pPrinterName)
            Dim paperSourceLookup As New List(Of Lookup.LookupData)
            Dim index As Int16 = 0
            For Each item As PaperSource In data.PrinterSettings.PaperSources
                Dim dbLookup = New Lookup.LookupData
                dbLookup.IdNo = item.RawKind
                dbLookup.Name = item.SourceName
                dbLookup.Code = item.Kind
                dbLookup.Index = index
                paperSourceLookup.Add(dbLookup)
                index += 1
            Next
            GetControlName("DefaultPaperSource").DataSource = paperSourceLookup
        End Sub

        'Public Shared Function GetPrinterPageInfo(ByVal printerName As String) As PageSettings
        '    Dim settings As PrinterSettings

        '    If String.IsNullOrEmpty(printerName) Then

        '        For Each printer In PrinterSettings.InstalledPrinters
        '            settings = New PrinterSettings()
        '            settings.PrinterName = printer.ToString()
        '            If settings.IsDefaultPrinter Then Return settings.DefaultPageSettings
        '        Next

        '        Return Nothing
        '    End If

        '    settings = New PrinterSettings()
        '    settings.PrinterName = printerName
        '    Return settings.DefaultPageSettings
        'End Function

        'Public Shared Function GetPrinterPageInfo(printer As String) As PageSettings
        '    Return GetPrinterPageInfo(printer)
        'End Function

        'Public Overloads Sub SetPrintOption(printerName As String, paperSize As Int16?, paperOrientation As Int16?, paperSource As Int16?)
        '    If printerName IsNot Nothing Then
        '        Dim dPrinterName As String = _report.PrintOptions.PrinterName
        '        Dim noPrinter As Boolean = _report.PrintOptions.NoPrinter
        '        Try
        '            _report.PrintOptions.NoPrinter = False
        '            _report.PrintOptions.PrinterName = printerName
        '        Catch ex As Exception
        '            MessageTimeOut("The Printer <" & printerName & "> doesn't exist on this system, using Default Printer.", "Invalid Printer Setup", 5)
        '            _report.PrintOptions.NoPrinter = noPrinter
        '            _report.PrintOptions.PrinterName = dPrinterName
        '        End Try
        '    End If
        '    If paperSize IsNot Nothing Then
        '        Dim dPaperSize As Int32
        '        paperSize = _report.PrintOptions.PaperSize
        '        Try
        '            _report.PrintOptions.PaperSize = paperSize
        '        Catch ex As Exception
        '            _report.PrintOptions.PaperSize = dPaperSize
        '        End Try
        '    End If
        '    If paperOrientation IsNot Nothing Then
        '        Dim dPaperOrientation As Int16 = _report.PrintOptions.PaperOrientation
        '        Try
        '            _report.PrintOptions.PaperOrientation = paperOrientation
        '        Catch ex As Exception
        '            _report.PrintOptions.PaperOrientation = dPaperOrientation
        '        End Try
        '    End If
        '    If paperSource IsNot Nothing Then
        '        Dim dPaperSource As Int16
        '        dPaperSource = _report.PrintOptions.PaperSource
        '        Try
        '            _report.PrintOptions.PaperSource = paperSource
        '        Catch ex As Exception
        '            _report.PrintOptions.PaperSource = dPaperSource
        '        End Try
        '    End If
        'End Sub

    End Class

End Namespace