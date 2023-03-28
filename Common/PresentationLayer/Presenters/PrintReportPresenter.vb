Imports AATM.Common.Models
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter

        Private ReadOnly _psService As Object
        Private ReadOnly _pjService As Object
        Private ReadOnly _prService As Object

        Public Sub New()
            _pjService = New CommonService("PrintJob")
            _psService = New CommonService("PrintSetup")
            _prService = New CommonService("Printer")
        End Sub

        Public Sub PrintReport(reportFileName As String, databaseConnectionName As String, Optional args() As Object = Nothing, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            ProcessReport(reportFileName, databaseConnectionName, True, args, copies, collate, startPage, endPage)
        End Sub

        Private Sub ProcessReport(reportFileName As String, databaseConnectionName As String, print As Boolean, Optional args() As Object = Nothing, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim report As New ReportPrinter(reportFileName, databaseConnectionName, args)
            Dim psModel As New PrintSetupModel
            Dim printer As PrinterModel = Nothing
            Dim computerName As String = Environment.MachineName
            Dim printJobIdNo As Int16 = _pjService.GetPrintJobIdNo(reportFileName)
            If printJobIdNo <> 0 Then
                Dim computerIdNo As Int16 = _pjService.GetIdNoWithName(Of Int16)("Computer", computerName)
                Dim printSetupIdNo As Int16 = _pjService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(printJobIdNo, computerIdNo, "PrintSetup", "PrintJobIdNo", "ComputerIdNo", "IdNo") 
                If printSetupIdNo <> 0 then
                    psModel = _psService.GetRecordByIdNo(Of PrintSetupModel)(printSetupIdNo)
                    If psModel IsNot Nothing Then
                        printer = _prService.GetRecordByIdNo(Of PrinterModel)(psModel.PrinterIdNo)
                        report.SetPrintOption(printer.PrinterName, psModel.PaperSize, psModel.PaperOrientation, psModel.PaperSource)
                    End If
                    'Dim printerName As String = _service.GetFieldWithIdNo(pjModel.PrinterIdNo, "Printer", "PrinterName").ToString()  ' force null value to empty string
                    'Dim hostOrIpName As String = _service.GetFieldWithIdNo(pjModel.IdNo, "Printer", "HostOrIpName").ToString()
                    'Dim printerSharedName As String = IIf(GlobalFunctions.IsEmpty(hostOrIpName), printerName, "\\" & hostOrIpName & "\" & printerName)
                    'Dim paperSizeName As String = _service.GetIcNameWithIdNo(CodeGroupSelection.PaperSize, pjModel.PaperSize)
                    
                End If
                If print Then
                    report.PrintReport(copies, collate, startPage, endPage)
                End If
            Else
                report.PrintReport(copies, collate, startPage, endPage)
            End If
        End Sub

        Private Function GetPrintJobIdNo(computerIdNo As Int16, printSetupIdNo As Integer) As Short
            Return GetService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(computerIdNo, printSetupIdNo, "PrintJob", "ComputerIdNo", "PrintSetupIdNo", "IdNo")
        End Function

        Public Sub ViewReport(viewer As CrViewer, databaseConnectionName As String)
            ProcessReport(viewer.Report.ReportFileName, databaseConnectionName, False)
            'Dim computerName As String = Environment.MachineName
            'Dim computerIdNo As Int16 = _service.GetIdNoWithName("Computer", computerName)
            'Dim pjModel As New PrintJobModel
            'pjModel.ComputerIdNo = computerIdNo ' _service.GetIdNoWithName("Computer", Environment.MachineName)
            'Dim printer As PrinterModel = _service.GetRecordByIdNo(pjModel.PrinterIdNo)
            'Dim idNo As Int32 = _service.GetRecordFieldWith2KeyG(Of String, String, Int32)(computerIdNo, printJobName, "PrintJob", "ComputerName", "PrintJobName", "IdNo")
            'pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(idNo)
            'viewer.Report.SetPrintOption(printer.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
        End Sub

        Public Function GetService()
            Return _pjService
        End Function

    End Class

End Namespace