Namespace PresentationLayer.Forms.Reports
    Public Class APJournalReport
        Private Sub APJournalReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim rpt As EmployeeList = New EmployeeList()
            crystalReportViewer1.ReportSource = rpt
        End Sub
    End Class
End NameSpace