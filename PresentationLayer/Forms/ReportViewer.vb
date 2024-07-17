Imports System.Windows.Forms
Imports AATM.Libraries.CrystalReportsHelper
Imports CrystalDecisions.ReportAppServer.DataDefModel

Public Class ReportViewer

    Public CrReportDocument As New CrystalReportDocument

    Public Event OkButtonClicked()

    Private ReadOnly _myCeLocale As CeLocale

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub New(reportFileName As String, reportParameters As Object, Optional databaseConnectionCode As String = Nothing)

        ' This call is required by the designer.
        InitializeComponent()
        If databaseConnectionCode Is Nothing Then
            CrReportDocument.DataBaseConnectionCode = "ISPDATA"
        Else
            CrReportDocument.DataBaseConnectionCode = databaseConnectionCode
        End If
        CrReportDocument.ReportFileName = reportFileName
        CrReportDocument.SetCrReportConnectionProperties()
        SetParameters(reportParameters)
        CrReportDocument.ClearDataSourceConnections()
        SetupReportViewer()

    End Sub

    Private Sub SetParameters(reportParameters As Object)
        CrReportDocument.SetParameterValue(reportParameters)
    End Sub

    Protected Sub SetupReportViewer()
        WindowState = FormWindowState.Maximized
        Dim ceCulture As CeLocale
        If Me.FormCulture.Name.ToLower().Remove(2) = "ar" Then
            ceCulture = CeLocale.ceLocaleArabicSaudiArabia
        Else
            ceCulture = CeLocale.ceLocaleEnglish
        End If
        With CrystalReportViewer1
            .Visible = True
            .BringToFront()
            .ReportSource = CrReportDocument.ReportDocument
            .SetProductLocale(CInt(ceCulture))
            .Refresh()
        End With
    End Sub

End Class