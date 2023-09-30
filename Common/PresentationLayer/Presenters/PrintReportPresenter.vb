Imports System.Globalization
Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter(Of TM As New)
        Inherits CommonPresenter(Of ICrPrintableReportView, TM)
        Implements ISubscriber(Of GetControlDataSource)
        Implements ISubscriber(Of GetControlEnumDataSource)
        Implements ISubscriber(Of GetLookupDataTableRequested)

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

        End Sub

        Public Sub New(view As ICrPrintableReportView)
            MyBase.New(view)
            MakeServices()
            AddHandler view.PrintReport, AddressOf OnPrintCrystalReport
            'AddHandler view.CreateDataSourceEnum, AddressOf OnCreateDataSourceEnum
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
        End Sub

        Private Sub MakeServices()
            Service = New CommonService("Report")
            _pjService = New CommonService("PrintJob")
            _psService = New CommonService("PrintSetup")
            _prService = New CommonService("Printer")
        End Sub

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

        Public Sub ProcessReport(reportFileName As String, printArgs As CrPrintableArgs, printDirectly As Boolean, Optional addDefaultParameters As Boolean = False)
            Dim crReport As CrystalReportPrinter
            crReport = GetPrinterSetup(reportFileName, printArgs.DataBaseConnectionName, printArgs.ReportParameters)
            If printDirectly Then
                crReport.PrintReport(printArgs.Copies, printArgs.Collate, printArgs.StartPage, printArgs.EndPage)
            Else
                Dim crViewer As New CrViewer(reportFileName, printArgs, addDefaultParameters, crReport)
                crViewer.Show()
            End If
        End Sub


        Public Sub ProcessReport(reportFileName As String, databaseConnectionName As String, printDirectly As Boolean, Optional args() As Object = Nothing, Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 0, Optional endPage As Integer = 0)
            ' leave startPage & endPage to 0 to print all pages
            Dim crReport As CrystalReportPrinter
            If printDirectly Then
                crReport = GetPrinterSetup(reportFileName, databaseConnectionName, args)
                crReport.PrintReport(copies, collate, startPage, endPage)
            Else
                crReport = GetPrinterSetup(reportFileName, databaseConnectionName, args)
                Dim reportArgs As New CrPrintableArgs
                reportArgs.ReportTitle = reportFileName
                reportArgs.Copies = copies
                reportArgs.StartPage = startPage
                reportArgs.EndPage = endPage
                reportArgs.ReportParameters = args
                reportArgs.CultureInfo = CultureInfo.CurrentCulture.Name
                reportArgs.DataBaseConnectionName = databaseConnectionName
                ViewReport(reportFileName, reportArgs)
            End If
        End Sub


        Private Function GetPrinterSetup(reportFileName As String, databaseConnectionName As String, args() As Object) As CrystalReportPrinter
            Dim crReport As New CrystalReportPrinter(reportFileName, databaseConnectionName, args)
            Dim printer As PrinterModel = Nothing
            Dim printJobIdNo As Int16 = GetPrintJobIdNo(reportFileName)
            Dim printSetupIdNo As Int16 = GetPrintSetupIdNo(reportFileName, printJobIdNo)
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
            If printer IsNot Nothing Then
                crReport.SetPrintOption(printer.PrinterName, printer.PaperSize, printer.PaperOrientation, printer.PaperSource)
            End If
            Return crReport
        End Function

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
            If TypeOf eventType.Control Is CtComboBox Then
                MakeControlDataSourcesT({New Object() {eventType.TableName, eventType.Control, Nothing, eventType.Filter}})
            Else
                SetDataSource(eventType.TableName, eventType.Control,, eventType.SortOrder, eventType.Filter, eventType.Ascending)
            End If
        End Sub

        Public Sub OnGetControlDataSourceHandler(ByRef eventType As GetControlEnumDataSource) Implements ISubscriber(Of GetControlEnumDataSource).OnEventHandler
            CreateEnumDataSourceT2(eventType.Control, eventType.EnumObj)
        End Sub

        'Public Sub OnGetControlDataSourceHandler(ByRef eventType As GetLookupDataTableRequested) Implements ISubscriber(Of GetLookupDataTableRequested).OnEventHandler
        '    SetDataSourceT(eventType.TableName, eventType.Control,,, eventType.Filter)
        'End Sub

        Public Sub PrintReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean, Optional addDefaultParameters As Boolean = False)
            ' leave startpage and endpage to 0 - to print all pages
            'Dim rp As CrPrintableArgs = reportArgs
            ProcessReport(reportFileName, reportArgs, printDirectly, addDefaultParameters) 'rp.DataBaseConnectionName, True, rp.ReportParameters, rp.Copies, rp.Collate, rp.StartPage, rp.EndPage)
        End Sub


        Public Sub ViewReport(reportFileName As String, reportArgs As CrPrintableArgs, Optional AddDefaultParameters As Boolean = False)
            'Dim rp As CrPrintableArgs = reportArgs
            ProcessReport(reportFileName, reportArgs, False, AddDefaultParameters)
            'Dim crViewerForm As New CrViewer(reportFileName, reportArgs, crReport)
            'crViewerForm.Show()
        End Sub

        Public Sub ViewReport(reportFileName As String, reportTitle As String, cFormCulture As CultureInfo, dbConnectionName As String, args As Object)
            Dim crViewerForm As New CrViewer(reportFileName, reportTitle, cFormCulture, args)
            crViewerForm.Show()
        End Sub

        Public Sub OnPrintCrystalReport(reportFileName As String, reportArgs As CrPrintableArgs, printDirectly As Boolean)
            If reportFileName Is Nothing Or reportFileName = "" Then
                Debugger.Break()
                MessageBox.Show("Crystal Report Printing - Empty Filename Error")
            End If
            PrintReport(reportFileName, reportArgs, printDirectly)
        End Sub
    End Class

End Namespace