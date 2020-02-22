Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Public Class CrReportViewer

    Public Report As New ReportDocument

    Public Event OkButtonClicked()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Protected Sub ProcessReport()
        WindowState = FormWindowState.Maximized
        With CrystalReportViewer1
            .Visible = True
            .BringToFront()
            .ReportSource = Report
            .Refresh()
        End With
        btnQuit.Visible = True

    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        RaiseEvent OkButtonClicked()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub CButton1_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        Me.Dispose()
        Me.Close()
    End Sub

End Class