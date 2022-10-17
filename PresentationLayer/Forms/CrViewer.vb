Imports System.Configuration
Imports System.Windows.Forms
Imports AATM.Libraries.CrystalReportsHelper
Imports CrystalDecisions.ReportAppServer.DataDefModel

Public Class CrViewer

    Public Report As New ReportPrinter

    Public Event OkButtonClicked()

    Private ReadOnly _myCeLocale As CeLocale

    Public Sub New() 'Optional ByVal ceLocal As CeLocale = CeLocale.ceLocaleEnglish)

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Property ReportFileName As String

    Protected Sub GetReportProperties()
        Dim reportPaths As String = ConfigurationManager.AppSettings.Get("ReportPaths")
        Dim uid As String = ConfigurationManager.AppSettings.Get("UID")
        Dim pwd As String = ConfigurationManager.AppSettings.Get("PWD")
        Dim server As String = ConfigurationManager.AppSettings.Get("ServerTranslator")
        Dim database As String = ConfigurationManager.AppSettings.Get("DATABASE")

        If reportPaths Is Nothing Or reportPaths = "" Then
            Dim computerName = System.Windows.Forms.SystemInformation.ComputerName
            If computerName = $"ISPADMIN2" Then
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPaths2")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator2")
            ElseIf computerName = "MARCELO-DELL" Then
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPaths3")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator3")
            Else
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPaths1")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator1")
            End If
        End If
        'MessageBox.Show(reportPaths & ReportFileName)
        Report.Load(reportPaths, ReportFileName)

        If Report.DataSourceConnections.Count > 0 Then

            Report.DataSourceConnections(0).SetConnection(server, database, uid, pwd)

        End If

    End Sub

    Protected Sub ProcessReport()
        WindowState = FormWindowState.Maximized
        Dim ceCulture As CeLocale
        If Me.FormCulture.Name.ToLower().Remove(2) = "ar" Then
            ceCulture = CeLocale.ceLocaleArabicSaudiArabia
        Else
            ceCulture = CeLocale.ceLocaleEnglish
        End If
        'Dim x As Integer = CInt(ceCulture)
        With CrystalReportViewer1
            .Visible = True
            .BringToFront()
            .ReportSource = Report
            .SetProductLocale(CInt(ceCulture))
            .Refresh()
        End With

        btnQuit.Visible = True

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        RaiseEvent OkButtonClicked()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Dispose()
        Close()
    End Sub

    Private Sub CButton1_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Dispose()
        Close()
    End Sub

End Class