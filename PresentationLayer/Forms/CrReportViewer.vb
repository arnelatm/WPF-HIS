Imports System.Configuration
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportAppServer.DataDefModel

Public Class CrReportViewer

    Public Report As New ReportDocument

    Public Event OkButtonClicked()

    Private ReadOnly _myCeLocale As CeLocale

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim valArray As Array = [Enum].GetValues(GetType(CeLocale))
        Dim lstCeLocale As New ListBox
        For Each obj As Object In valArray
            lstCeLocale.Items.Add(obj)
        Next

        _myCeLocale = CeLocale.ceLocaleArabicSaudiArabia

        Try
            Report.ReportClientDocument.LocaleID = _myCeLocale
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
        'Dim sqlCon As String = ConfigurationManager.ConnectionStrings("ISPDATA").ConnectionString

        Report.Load(reportPaths & ReportFileName)

        'Report.SetDatabaseLogon(uid, pwd, server, database)

        'This line is necessary to replace the dataSource in the report with the one
        'related to the environment

        If Report.DataSourceConnections.Count > 0 Then

            Report.DataSourceConnections(0).SetConnection(server, database, uid, pwd)

            '    SetConnection(Server, Database, UID, Pwd)

            'sqlCon = ConfigurationManager.ConnectionStrings("ISPDATA").ConnectionString
            'Report.DataSourceConnections(0).SetConnection(sqlCon.DataSource,
            '                                 "",
            '                                 sqlCon.UserID,
            '                                 sqlCon.Password)
        End If
        'This line sets the credentials for the dataSource set in the DataSourceConnections.SetConnection
        'Report.SetDatabaseLogon(sqlCon.UserID, sqlCon.Password, sqlCon.DataSource, "")

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