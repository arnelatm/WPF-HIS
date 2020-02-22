Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine

Public Class CrReportViewerForm

    Public Report As New ReportDocument

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        
    End Sub

    Protected Sub ProcessReport()
        WindowState = FormWindowState.Maximized
        With CrystalReportViewer1
            .Visible = True
            .BringToFront()
            .ReportSource = Report
            .Refresh()
        End With
    End Sub

End Class
