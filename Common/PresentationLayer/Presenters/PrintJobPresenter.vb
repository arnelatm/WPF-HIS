Imports System.Drawing.Printing
Imports AATM.Common.Models
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Presenters

    Public Class PrintJobPresenter

        Private ReadOnly _service As Object

        Public Sub New()
            _service = New CommonService("PrintJob")
        End Sub

        Public Sub PrintReport(reportFileName As String, printJobName As String, databaseConnectionName As String, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim computerName As String = Environment.MachineName
            Dim pjModel As New PrintJobModel
            pjModel.ComputerName = Environment.MachineName
            Dim idNo As Int32 = _service.GetRecordFieldWith2KeyG(Of String, String, Int32)(computerName, printJobName, "PrintJob", "ComputerName", "PrintJobName", "IdNo")
            pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(idNo)
            Dim report As New ReportPrinter(reportFileName, printJobName, databaseConnectionName)
            report.SetPrintOption(pjModel.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
            report.PrintReport(copies, collate, startPage, endPage)
        End Sub

        Public Sub ViewReport(viewer As CrViewer, printJobName As String, databaseConnectionName As String)
            Dim computerName As String = Environment.MachineName
            Dim pjModel As New PrintJobModel
            pjModel.ComputerName = Environment.MachineName
            Dim idNo As Int32 = _service.GetRecordFieldWith2KeyG(Of String, String, Int32)(computerName, printJobName, "PrintJob", "ComputerName", "PrintJobName", "IdNo")
            pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(idNo)
            viewer.Report.SetPrintOption(pjModel.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
        End Sub

        'Public Overloads Sub ReportPrinter(reportName As String, printJobName As String, databaseConnectionName As String,
        '                                   Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
        '    Dim report As New ReportPrinter(reportName, printJobName, databaseConnectionName)
        '    report.PrintReport(copies, collate, startPage, endPage)
        'End Sub

        Public Function GetService()
            Return _service
        End Function

    End Class

End Namespace