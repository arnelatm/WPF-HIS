Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrintReportView, TM)
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
            'Ea = New EventAggregator()
            'Ea.SubscribeEvent(Me)
        End Sub

        Public Sub New(view As IPrintReportView)
            MyBase.New(view)
            MakeServices()
            AddHandler view.PrintReport, AddressOf OnPrintReport
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

        Public Sub OnPrintReport(reportFileName As String, databaseConnectionName As String, Optional args() As Object = Nothing, Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 1, Optional endPage As Integer = 100000)
            ProcessReport(reportFileName, databaseConnectionName, True, args, copies, collate, startPage, endPage)
        End Sub

        Private Function GetPrintSetupIdNo(reportFileName As String, printJobIdNo As Int16) As Int16
            Return _psService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(printJobIdNo, _computerIdNo, "PrintSetup", "PrintJobIdNo", "ComputerIdNo", "IdNo")
        End Function

        Private Function GetPrintJobIdNo(reportFileName) As Int16
            Return _psService.GetRecordFieldWithKeyG(Of Int16, String)(reportFileName, "Report", "ReportFileName", "PrintJobIdNo")
        End Function

        Private Sub ProcessReport(reportFileName As String, databaseConnectionName As String, print As Boolean, Optional args() As Object = Nothing, Optional copies As Integer = 1, Optional collate As Boolean = False, Optional startPage As Integer = 1, Optional endPage As Integer = 0)
            If print Then
                Dim printJobIdNo As Int16 = GetPrintJobIdNo(reportFileName)
                Dim printSetupIdNo As Int16 = GetPrintSetupIdNo(reportFileName, printJobIdNo)
                Dim crReport As New CrystalReportPrinter(reportFileName, databaseConnectionName, args)
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

    End Class

End Namespace