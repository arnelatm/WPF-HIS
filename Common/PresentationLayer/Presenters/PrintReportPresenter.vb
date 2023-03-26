Imports AATM.Common.Models
Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Presenters

    Public Class PrintReportPresenter

        Private ReadOnly _service As Object

        Public Sub New()
            _service = New CommonService("PrintJob")
        End Sub

        Public Sub PrintReport(reportFileName As String, databaseConnectionName As String, Optional args() As Object = Nothing, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            ProcessReport(reportFileName, databaseConnectionName, True, args, copies, collate, startPage, endPage)
        End Sub

        Private Sub ProcessReport(reportFileName As String, databaseConnectionName As String, print As Boolean, Optional args() As Object = Nothing, Optional copies As Int16 = 1, Optional collate As Boolean = False, Optional startPage As Int16 = 0, Optional endPage As Int16 = 0)
            Dim report As New ReportPrinter(reportFileName, databaseConnectionName, args)
            Dim pjModel As New PrintSetupModel
            Dim printer As PrinterModel = Nothing
            Dim computerName As String = Environment.MachineName
            Dim printSetupIdNo As Int32 = _service.GetPrintSetupIdNo(reportFileName)
            If printSetupIdNo <> 0 Then
                Dim computerIdNo As Int16 = _service.GetIdNoWithName(Of Int16)("Computer", computerName)
                Dim printJobIdNo As Int32 = GetPrintJobIdNo(computerIdNo, printSetupIdNo)
                If Not (computerIdNo = 0 Or printJobIdNo = 0) Then
                    pjModel = _service.GetRecordByIdNo(Of PrintSetupModel)(printJobIdNo)
                    Dim printerName As String = _service.GetFieldWithIdNo(pjModel.PrinterIdNo, "Printer", "PrinterName").ToString()  ' force null value to empty string
                    Dim hostOrIpName As String = _service.GetFieldWithIdNo(pjModel.IdNo, "Printer", "HostOrIpName").ToString()
                    Dim printerSharedName As String = IIf(GlobalFunctions.IsEmpty(hostOrIpName), printerName, "\\" & hostOrIpName & "\" & printerName)
                    Dim paperSizeName As String = _service.GetIcNameWithIdNo(CodeGroupSelection.PaperSize, pjModel.PaperSize)
                    report.SetPrintOption(printerSharedName, paperSizeName, pjModel.PaperOrientation, pjModel.PaperSource)
                End If
                If print Then
                    report.PrintReport(copies, collate, startPage, endPage)
                End If
            Else
                report.PrintReport(copies, collate, startPage, endPage)
            End If
        End Sub

        Private Function GetPrintJobIdNo(computerIdNo As Int16, printSetupIdNo As Integer) As Short
            Return _service.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(computerIdNo, printSetupIdNo, "PrintJob", "ComputerIdNo", "PrintSetupIdNo", "IdNo")
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
            Return _service
        End Function

    End Class

End Namespace