Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports CrystalReportsHelper

Namespace PresentationLayer.Presenters

    Public Class PrintJobPresenter

        Private ReadOnly _service As Object

        Public Sub New()
            _service = New CommonService("PrintJob")
        End Sub

        Public Overloads Sub PrintReport(databaseConnectionName As String, reportName As String, printJobName As String)
            Dim computerName As String = Environment.MachineName
            Dim pjModel As New PrintJobModel
            pjModel.ComputerName = Environment.MachineName
            Dim idNo As Int32 = _service.GetRecordFieldWith2KeyG(Of String, String, Int32)(computerName, printJobName, "PrintJob", "ComputerName", "PrintJobName", "IdNo")
            pjModel = _service.GetRecordByIdNo(Of PrintJobModel)(idNo)
            Dim report As New ReportPrinter(databaseConnectionName, reportName, printJobName)
            report.SetPrintOption(pjModel.PrinterName, pjModel.PaperSize, pjModel.PaperOrientation, pjModel.PaperSource)
            report.PrintReport()
        End Sub

        Public Overloads Sub ReportPrinter(databaseConnectionName As String, reportName As String, printJobName As String,
                                           Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim report As New ReportPrinter(databaseConnectionName, reportName, printJobName)
            report.PrintReport(copies, collate, startPage, endPage)
        End Sub

    End Class

End Namespace