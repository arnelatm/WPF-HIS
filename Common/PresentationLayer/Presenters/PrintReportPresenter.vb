Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports AATM.Libraries
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter
        Implements ISubscriber(Of GetControlDataSource)

        Private ReadOnly _psService As Object
        Private ReadOnly _pjService As Object
        Private ReadOnly _prService As Object
        Private _presenter As CommonPresenter(Of IView, ReportModel)

        Public Sub New()
            _pjService = New CommonService("PrintJob")
            _psService = New CommonService("PrintSetup")
            _prService = New CommonService("Printer")
        End Sub

        Protected Sub CreateDataSources(tableName As String, control As Control)
            _presenter.CreateDataSource(tableName, control)
        End Sub


        Public Sub PrintReport(reportFileName As String, databaseConnectionName As String, Optional args() As Object = Nothing, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            ProcessReport(reportFileName, databaseConnectionName, True, args, copies, collate, startPage, endPage)
        End Sub

        Private Sub ProcessReport(reportFileName As String, databaseConnectionName As String, print As Boolean, Optional args() As Object = Nothing, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim report As New CrystalReportPrinter(reportFileName, databaseConnectionName, args)
            If print Then
                Dim psModel As New PrintSetupModel
                Dim printer As New PrinterModel
                Dim computerName As String = Environment.MachineName
                Dim printJobIdNo As Int16 = _pjService.GetPrintJobIdNo(reportFileName)
                Dim printerFound As Boolean = False
                If printJobIdNo <> 0 Then
                    Dim computerIdNo As Int16 = _pjService.GetIdNoWithKey(Of Int16)("Computer", computerName)
                    Dim printSetupIdNo As Int16 = _pjService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(printJobIdNo, computerIdNo, "PrintSetup", "PrintJobIdNo", "ComputerIdNo", "IdNo")
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
                End If
                report.SetPrintOption(printer.PrinterName, printer.PaperSize, printer.PaperOrientation, printer.PaperSource)
            End If
            report.PrintReport(copies, collate, startPage, endPage)
        End Sub

        Private Function GetPrintJobIdNo(computerIdNo As Int16, printSetupIdNo As Integer) As Short
            Return GetService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(computerIdNo, printSetupIdNo, "PrintJob", "ComputerIdNo", "PrintSetupIdNo", "IdNo")
        End Function

        Public Sub ViewReport(viewer As CrViewer, databaseConnectionName As String)
            ProcessReport(viewer.ReportPrinter.ReportFileName, databaseConnectionName, False)
        End Sub

        Public Function GetService()
            Return _pjService
        End Function

        Public Sub OnEventHandler(ByRef eventType As GetControlDataSource) Implements ISubscriber(Of GetControlDataSource).OnEventHandler
            _presenter.SetDataSource(eventType.TableName, eventType.Control)
        End Sub
    End Class

End Namespace