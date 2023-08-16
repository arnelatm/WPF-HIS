Imports System.Globalization
Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.[Interface]
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter(Of TM As New)
        Inherits CommonPresenter(Of ICrPrintableReportView, TM)
        Implements ISubscriber(Of GetControlDataSource)

        Private _psService As Object
        Private _pjService As Object
        Private _prService As Object
        Private _presenter As CommonPresenter(Of IView, ReportModel)
        Private _computerName As String
        Private _computerIdNo As Int16

        Public Sub New()
            MakeServices()
            _computerName = Environment.MachineName      ' "Pharmacy" '
            _computerIdNo = _psService.GetRecordFieldWithKeyG(Of Int16)(_computerName, "Computer", "ComputerName", "IdNo")
            'AddHandler View.PrintReport, AddressOf OnPrintCrystalReport
            'Ea = New EventAggregator()
            'Ea.SubscribeEvent(Me)
        End Sub

        Public Sub New(view As ICrPrintableReportView)
            MyBase.New(view)
            MakeServices()
            'AddHandler view.PrintReport, AddressOf OnPrintReport
            AddHandler view.PrintReport, AddressOf OnPrintCrystalReport
            'AddHandler view.GetLanguageAndCo, AddressOf OnGetLanguageAndCo
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Private Sub MakeServices()
            Service = New CommonService("Report")
            _pjService = New CommonService("PrintJob")
            _psService = New CommonService("PrintSetup")
            _prService = New CommonService("Printer")
        End Sub

        'Protected Sub CreateDataSources(tableName As String, control As Control)
        '    _presenter.CreateDataSource(tableName, control)
        'End Sub

        Public Sub OnPrintReport(reportFileName As String, databaseConnectionName As String, Optional args() As Object = Nothing, Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 0, Optional endPage As Integer = 0)
            ' leave startpage and endpage to 0 - to print all pages
            ProcessReport(reportFileName, databaseConnectionName, True, args, copies, collate, startPage, endPage)
        End Sub

        Private Function GetPrintSetupIdNo(reportFileName As String, printJobIdNo As Int16) As Int16
            Return _psService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(printJobIdNo, _computerIdNo, "PrintSetup", "PrintJobIdNo", "ComputerIdNo", "IdNo")
        End Function

        Private Function GetPrintJobIdNo(reportFileName) As Int16
            Return _psService.GetRecordFieldWithKeyG(Of Int16, String)(reportFileName, "Report", "ReportFileName", "PrintJobIdNo")
        End Function

        Public Sub ProcessReport(reportFileName As String, databaseConnectionName As String, print As Boolean, Optional args() As Object = Nothing, Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 0, Optional endPage As Integer = 0)
            ' leave startPage & endPage to 0 to print all pages
            If print Then
                Dim printJobIdNo As Int16 = GetPrintJobIdNo(reportFileName)
                Dim printSetupIdNo As Int16 = GetPrintSetupIdNo(reportFileName, printJobIdNo)
                Dim crReport As New CrystalReportsPrinter(reportFileName, databaseConnectionName, args)
                Dim printer As New PrinterModel
                Dim psModel As New PrintSetupModel
                If printSetupIdNo <> 0 Then
                    psModel = _psService.GetRecordByIdNo(Of PrintSetupModel)(printSetupIdNo)
                    If psModel IsNot Nothing Then
                        printer = _prService.GetRecordByIdNo(Of PrinterModel)(psModel.PrinterIdNo)
                        printer.PaperSize = IIf(psModel.PaperSize <> 0, psModel.PaperSize, printer.PaperSize)
                        printer.PaperOrientation = IIf(psModel.PaperOrientation <> 0, psModel.PaperOrientation, printer.PaperOrientation)
                        printer.PaperSource = IIf(psModel.PaperSource <> 0, psModel.PaperSource, printer.PaperSource)
                    Else
                        Dim pjModel As New PrintJobModel
                        pjModel = _pjService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
                        If pjModel IsNot Nothing Then
                            printer = _prService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
                            printer.PaperSize = IIf(pjModel.PaperSize <> 0, pjModel.PaperSize, printer.PaperSize)
                            printer.PaperOrientation = IIf(pjModel.PaperOrientation <> 0, pjModel.PaperOrientation, printer.PaperOrientation)
                            printer.PaperSource = IIf(pjModel.PaperSource <> 0, pjModel.PaperSource, printer.PaperSource)
                        Else
                            printer.PrinterName = Nothing
                        End If
                    End If
                Else
                    Dim pjModel As New PrintJobModel
                    pjModel = _pjService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
                    If pjModel.IdNo <> 0 Then
                        printer = _prService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
                        printer.PaperSize = IIf(pjModel.PaperSize <> 0, pjModel.PaperSize, printer.PaperSize)
                        printer.PaperOrientation = IIf(pjModel.PaperOrientation <> 0, pjModel.PaperOrientation, printer.PaperOrientation)
                        printer.PaperSource = IIf(pjModel.PaperSource <> 0, pjModel.PaperSource, printer.PaperSource)
                    End If
                End If
                crReport.SetPrintOption(printer.PrinterName, printer.PaperSize, printer.PaperOrientation, printer.PaperSource)
                crReport.PrintReport(copies, collate, startPage, endPage)
            End If
        End Sub

        Private Function GetPrintJobIdNo(computerIdNo As Int16, printSetupIdNo As Integer) As Short
            Return GetService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(computerIdNo, printSetupIdNo, "PrintJob", "ComputerIdNo", "PrintSetupIdNo", "IdNo")
        End Function

        Public Sub ViewReport(viewer As CrViewer, databaseConnectionName As String)
            ProcessReport(viewer.ReportPrinter.ReportFileName, databaseConnectionName, False)
        End Sub

        Public Function GetService1()
            Return _pjService
        End Function

        Public Sub OnGetControlDataSourceHandler(ByRef eventType As GetControlDataSource) Implements ISubscriber(Of GetControlDataSource).OnEventHandler
            SetDataSource(eventType.TableName, eventType.Control)
        End Sub

        Public Sub PrintReport(reportFileName As String, reportArgs As CrPrintableArgs)
            ' leave startpage and endpage to 0 - to print all pages
            Dim rp As CrPrintableArgs = reportArgs
            ProcessReport(reportFileName, rp.DataBaseConnectionName, True, rp.ReportParameters, rp.Copies, rp.Collate, rp.StartPage, rp.EndPage)
        End Sub


        Public Sub OnPrintCrystalReport(reportFileName As String, reportArgs As CrPrintableArgs)
            'Dim printModel As New ReportModel
            'Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
            If reportFileName Is Nothing Or reportFileName = "" Then
                Debugger.Break()
                MessageBox.Show("Crystal Report Printing - Empty Filename Error")
            End If
            PrintReport(reportFileName, reportArgs)
            'reportPrinter.PrintReport(reportFileName, reportArgs)
        End Sub

        'Private Sub OnGetLanguageAndCo(ByVal sender As IReportPrinterView, ByVal formCulture As String, ByRef language As String, ByRef establishmentName As String, ByRef reportTitle As String)
        '    language = Strings.Left(formCulture, formCulture.IndexOf("-", StringComparison.Ordinal))
        '    If language <> "ar" Then
        '        establishmentName = Service.GetRecordField("Establishment", "EstablishmentName")
        '    Else
        '        establishmentName = Service.GetRecordField("Establishment", "EstablishmentNameAra")
        '    End If
        '    'ProcessReport(sender.FileName, "", True, args)
        'End Sub
        'Private Sub MakeReport(ByVal fileName As String, ByVal reportTitle As String, formCulture As CultureInfo, ByVal ParamArray args() As Object)
        '    Dim language As String
        '    Dim establishmentName As String
        '    language = Strings.Left(formCulture.Name, formCulture.Name.IndexOf("-", StringComparison.Ordinal))
        '    If language <> "ar" Then
        '        establishmentName = Service.GetRecordField("Establishment", "EstablishmentName")
        '    Else
        '        establishmentName = Service.GetRecordField("Establishment", "EstablishmentNameAra")
        '    End If

        '    ReportDocument.SetParameterValue("ReportTitle", reportTitle)
        '    ReportDocument.SetParameterValue("EstablishmentName", establishmentName)
        '    ReportDocument.SetParameterValue("Language", language)
        'End Sub

    End Class

    'Public Class CrPrintableReport(Of TM As New)
    '    Inherits PrintReportPresenter(Of TM)

    '    Public Sub New(View As ICrPrintableReportView)
    '        AddHandler View.PrintReport, AddressOf OnPrintReport
    '    End Sub

    '    Public Sub OnPrintReport(reportFileName As String, reportArgs As CrPrintableArgs)
    '        Dim printModel As New ReportModel
    '        Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
    '        If reportArgs.ReportFileName Is Nothing Or reportArgs.ReportFileName = "" Then
    '            Debugger.Break()
    '            MessageBox.Show("Crystal Report Printing - Empty Filename Error")
    '        End If
    '        reportPrinter.PrintReport(reportFileName, reportArgs)
    '    End Sub

    'End Class

End Namespace