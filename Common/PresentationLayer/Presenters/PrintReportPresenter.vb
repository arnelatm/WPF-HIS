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

        Public Sub PrintReport(reportFileName As String, printJobName As String, databaseConnectionName As String, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            ProcessReport(reportFileName, printJobName, databaseConnectionName, True, copies, collate, startPage, endPage)
        End Sub

        Private Sub ProcessReport(reportFileName As String, printJobName As String, databaseConnectionName As String, print As Boolean, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim report As New ReportPrinter(reportFileName, printJobName, databaseConnectionName)
            Dim pjModel As New PrintJobModel
            Dim printer As PrinterModel = Nothing
            Dim computerName As String = Environment.MachineName
            pjModel.ComputerIdNo = _service.GetIdNoWithName(Of Int16)("Computer", Environment.MachineName)
            Dim printIdNo As Int16 =
            Dim idNo As Int32 = _service.GetRecordFieldWith2KeyG(Of String, String, Int32)(computerName, printJobName, "PrintJob", "ComputerName", "PrintJobName", "IdNo")
            pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(idNo)
            printer = _service.GetRecordByIdNo(pjModel.PrinterIdNo)
            report.SetPrintOption(printer.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
            If print Then
                report.PrintReport(copies, collate, startPage, endPage)
            End If
        End Sub

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