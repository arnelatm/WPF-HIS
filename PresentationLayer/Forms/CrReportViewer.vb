Imports System.Configuration
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportAppServer.CommonControls

Public Class CrReportViewer

    Public Report As New ReportDocument

    Public Event OkButtonClicked()
    Private myceLocale As CrystalDecisions.ReportAppServer.CommonControls.CeLocale


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim valArray As Array = [Enum].GetValues(GetType(CrystalDecisions.ReportAppServer.CommonControls.CeLocale))
        Dim lstCeLocale As New ListBox
        For Each obj As Object In valArray
            lstCeLocale.Items.Add(obj)
        Next

        myceLocale = CeLocale.ceLocaleArabicSaudiArabia

        Try
            Report.ReportClientDocument.LocaleID = CType(myceLocale, CrystalDecisions.ReportAppServer.DataDefModel.CeLocale)



        Catch ex As Exception
            MessageBox.Show("ERROR: " & ex.Message)
        End Try

    End Sub

    Public Property ReportFileName As String

    Protected Sub GetReportProperties()
        Dim reportPaths As String = ConfigurationManager.AppSettings.Get("ReportPaths")
        Dim uid As String = ConfigurationManager.AppSettings.Get("UID")
        Dim pwd As String = ConfigurationManager.AppSettings.Get("PWD")
        Dim server As String = ConfigurationManager.AppSettings.Get("SERVER")
        Dim database As String = ConfigurationManager.AppSettings.Get("DATABASE")
        Report.Load(reportPaths & ReportFileName)

        Report.SetDatabaseLogon(uid, pwd, server, database)
    End Sub

    Protected Sub ProcessReport()
        WindowState = FormWindowState.Maximized
        Dim x As Integer = CInt(Report.ReportClientDocument.LocaleID)
        With CrystalReportViewer1
            .Visible = True
            .BringToFront()
            .ReportSource = Report
            .SetProductLocale(x)
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