Namespace PresentationLayer.Forms.Reports
    Public Class APJournalReportForm

        Private Sub APJournalReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim rpt As APJournalReportForm = New APJournalReportForm()
            CrystalReportViewer1.ReportSource = rpt
        End Sub

    End Class
End NameSpace