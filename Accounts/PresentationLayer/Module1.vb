Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports System.Globalization

Module Module1

    Public Sub PrintReportToScreen(reportFileName As String, dataBaseConnectionName As String, formCulture As CultureInfo, reportArgs As CrPrintableArgs)
        Using reportPrinter As New AATM.Common.ReportPrinter(reportFileName, dataBaseConnectionName, formCulture, reportArgs)
            reportPrinter.ShowReport()
        End Using
    End Sub

End Module
