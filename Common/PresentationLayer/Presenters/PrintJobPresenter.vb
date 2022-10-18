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

        Public Sub PrintReport(reportName As String, printJobName As String, databaseConnectionName As String)
            SetPrintOption(True, reportName, printJobName, databaseConnectionName)
        End Sub

        Public Sub ViewReport(viewer As CrViewer, printJobName As String, databaseConnectionName As String)
            SetPrintJob(viewer, printJobName, databaseConnectionName)
        End Sub

        Public Sub SetPrintJob(viewer As CrViewer, printJobName As String, databaseConnectionName As String)
            Dim computerName As String = Environment.MachineName
            Dim pjModel As New PrintJobModel
            pjModel.ComputerName = Environment.MachineName
            Dim idNo As Int32 = _service.GetRecordFieldWith2KeyG(Of String, String, Int32)(computerName, printJobName, "PrintJob", "ComputerName", "PrintJobName", "IdNo")
            pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(idNo)
            viewer.Report.SetPrintOption(pjModel.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
        End Sub

        Private Sub SetPrintOption(showViewer As Boolean, reportFileName As String, printJobName As String, databaseConnectionName As String)
            Dim computerName As String = Environment.MachineName
            Dim pjModel As New PrintJobModel
            pjModel.ComputerName = Environment.MachineName
            Dim idNo As Int32 = _service.GetRecordFieldWith2KeyG(Of String, String, Int32)(computerName, printJobName, "PrintJob", "ComputerName", "PrintJobName", "IdNo")
            pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(idNo)
            Dim report As New ReportPrinter(databaseConnectionName, reportFileName, printJobName)
            report.SetPrintOption(pjModel.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
            If showViewer Then
                report.PrintReport()
            End If
        End Sub



        'Private Shared Sub SetPrinterOption(showViewer As Boolean, reportName As String, printJobName As String, databaseConnectionName As String, pjModel As PrintJobModel)
        '    Dim report As New ReportPrinter(databaseConnectionName, reportName, printJobName)
        '    report.SetPrintOption(pjModel.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
        '    If Not showViewer Then
        '        report.PrintReport()
        '    End If
        'End Sub

        Public Overloads Sub ReportPrinter(reportName As String, printJobName As String, databaseConnectionName As String,
                                           Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim report As New ReportPrinter(reportName, printJobName, databaseConnectionName)
            report.PrintReport(copies, collate, startPage, endPage)
        End Sub

        Public Function GetService()
            Return _service
        End Function


    End Class

End Namespace