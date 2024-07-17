Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms
Imports System.Globalization

Module Module1

    Public Sub PrintReportToScreen(reportFileName As String, reportParameters As Object)
        Dim DataBaseConnectionName As String = "ISPDATA"
        Dim FormCulture As CultureInfo = GlobalVariables.AppCurrentCultureInfo
        Dim reportArgs As New CrPrintableArgs
        reportArgs.ReportParameters = reportParameters
        PrintReportToScreen(reportFileName, DataBaseConnectionName, FormCulture, reportArgs)
    End Sub

    Public Sub PrintReportToScreen(reportFileName As String, reportArgs As CrPrintableArgs)
        Dim DataBaseConnectionName As String = "ISPDATA"
        Dim FormCulture As CultureInfo = GlobalVariables.AppCurrentCultureInfo
        PrintReportToScreen(reportFileName, DataBaseConnectionName, FormCulture, reportArgs)
    End Sub

    Public Sub PrintReportToScreen(reportFileName As String, dataBaseConnectionName As String, formCulture As CultureInfo, reportArgs As CrPrintableArgs)
        Using reportPrinter As New AATM.Common.ReportPrinter(reportFileName, dataBaseConnectionName, formCulture, reportArgs)
            reportPrinter.ShowReport()
        End Using
    End Sub

    'Public Sub ShowReportToScreen(reportFileName As String, reportParameters As Object)
    '    Dim crReportDocument As New CrystalReportDocument
    '    Dim ReportViewer As New ReportViewer(reportFileName, reportParameters)
    '    ReportViewer.Show()
    'End Sub

    Public Sub ShowReportToScreen(reportFileName As String, Optional reportParameters As Object = Nothing, Optional dataBaseConnectionCode As String = Nothing)
        Dim crReportDocument As New CrystalReportDocument
        Dim ReportViewer As New ReportViewer(reportFileName, reportParameters, dataBaseConnectionCode)
        ReportViewer.Show()
    End Sub


    Public Function GetEstablishmentName(languageCode As String) As String
        Dim establishmentName As String
        If languageCode Is Nothing OrElse languageCode <> "ar" Then
            establishmentName = GlobalVariables.EstablishmentName
        Else
            establishmentName = GlobalVariables.EstablishmentNameAra
        End If
        Return establishmentName
    End Function



End Module
