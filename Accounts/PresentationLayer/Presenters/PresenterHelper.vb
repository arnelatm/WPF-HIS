Imports AATM.Common.Models
Imports AATM.Libraries.CrystalReportsHelper

Public Module PresenterHelper

    Public Function GetPrinterSetup(printSetupService As Object, printerService As Object, printJobService As Object, reportFileName As String, databaseConnectionName As String, args() As Object) As CrystalReportPrinter
        Dim crReport As New CrystalReportPrinter(reportFileName, databaseConnectionName, args)
        Dim printer As PrinterModel = Nothing
        Dim printJobIdNo As Int16 = GetPrintJobIdNo(printSetupService, reportFileName)
        Dim printSetupIdNo As Int16 = GetPrintSetupIdNo(printSetupService, reportFileName, printJobIdNo)
        Dim psModel As New PrintSetupModel
        If printSetupIdNo <> 0 Then
            psModel = printSetupService.GetRecordByIdNo(Of PrintSetupModel)(printSetupIdNo)
            If psModel IsNot Nothing Then
                printer = printerService.GetRecordByIdNo(Of PrinterModel)(psModel.PrinterIdNo)
                printer.PaperSize = IIf(psModel.PaperSize <> 0, psModel.PaperSize, printer.PaperSize)
                printer.PaperOrientation = IIf(psModel.PaperOrientation <> 0, psModel.PaperOrientation, printer.PaperOrientation)
                printer.PaperSource = IIf(psModel.PaperSource <> 0, psModel.PaperSource, printer.PaperSource)
            Else
                Dim pjModel As New PrintJobModel
                pjModel = printJobService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
                If pjModel IsNot Nothing Then
                    printer = printerService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
                    printer.PaperSize = IIf(pjModel.PaperSize <> 0, pjModel.PaperSize, printer.PaperSize)
                    printer.PaperOrientation = IIf(pjModel.PaperOrientation <> 0, pjModel.PaperOrientation, printer.PaperOrientation)
                    printer.PaperSource = IIf(pjModel.PaperSource <> 0, pjModel.PaperSource, printer.PaperSource)
                Else
                    printer.PrinterName = Nothing
                End If
            End If
        Else
            Dim pjModel As New PrintJobModel
            pjModel = printJobService.GetRecordByIdNo(Of PrintJobModel)(printJobIdNo)
            If pjModel.IdNo <> 0 Then
                printer = printerService.GetRecordByIdNo(Of PrinterModel)(pjModel.PrinterIdNo)
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


    Private Function GetPrintSetupIdNo(printSetupService As Object, reportFileName As String, printJobIdNo As Int16) As Int16
        Dim computerName As String = Environment.MachineName
        Dim computerIdNo As Int16 = printSetupService.GetRecordFieldWithKeyG(Of Int16)(computerName, "Computer", "ComputerName", "IdNo")
        Return printSetupService.GetRecordFieldWith2KeyG(Of Int16, Int16, Int16)(printJobIdNo, computerIdNo, "PrintSetup", "PrintJobIdNo", "ComputerIdNo", "IdNo")
    End Function

    Private Function GetPrintJobIdNo(printSetupService, reportFileName) As Int16
        Return printSetupService.GetRecordFieldWithKeyG(Of Int16, String)(reportFileName, "Report", "ReportFileName", "PrintJobIdNo")
    End Function

End Module

