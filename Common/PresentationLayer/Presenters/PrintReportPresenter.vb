Imports AATM.Common.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter

        Private ReadOnly _service As Object

        Public Sub New()
            _service = New CommonService("PrintJob")
        End Sub

        Public Sub PrintReport(reportFileName As String, databaseConnectionName As String, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            ProcessReport(reportFileName, databaseConnectionName, True, copies, collate, startPage, endPage)
        End Sub

        Private Sub ProcessReport(reportFileName As String, databaseConnectionName As String, print As Boolean, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim report As New ReportPrinter(reportFileName, databaseConnectionName)
            Dim pjModel As New PrintJobModel
            Dim printer As PrinterModel = Nothing
            Dim computerName As String = Environment.MachineName
            Dim printSetupIdNo As Int32 = _service.GetPrintSetupIdNo(reportFileName)
            pjModel.ComputerIdNo = _service.GetIdNoWithName(Of Int16)("Computer", computerName)
            'Dim printJobIdNo As Int32 = _service.GetIcIdNoWithName(AATM.DataLayer.CodeGroupSelection.PrintJobSetting, printJobName)
            'Dim printerIdNo As Int16 = GetPrinterIdNo(pjModel, printSetupIdNo)
            'Dim printerIdNo As Int16 = _service.GetIdNoWithName(Of Int16)("Printer", )
            pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(printSetupIdNo)
            printer = _service.GetRecordByIdNo(pjModel.PrinterIdNo)
            report.SetPrintOption(printer.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
            If print Then
                report.PrintReport(copies, collate, startPage, endPage)
            End If
        End Sub

        Private Function GetPrintJobIdNo(ByRef pjModel As PrintJobModel, printJobIdNo As Integer) As Short
            Return _service.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(pjModel.ComputerIdNo, printJobIdNo, "PrintJob", "ComputerIdNo", "PrintSetupIdNo", "IdNo")
        End Function

        Public Sub ViewReport(viewer As CrViewer, printJobName As String, databaseConnectionName As String)
            ProcessReport(viewer.Report.ReportFileName, printJobName, databaseConnectionName, True)
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
            Return _service
        End Function

    End Class

End Namespace