Namespace PresentationLayer.Forms
    Public Class ArJournalReport
        Public Sub New(ByVal idNo As Int32, ByVal amount As String, ByVal lineTotal As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            ReportFileName = "Accounts Receivable Journal.rpt"
            GetReportProperties()
            Report.SetParameterValue("ArJournalIdNo", idNo)
            Report.SetParameterValue("ArAmountInWords", amount)
            Report.SetParameterValue("TotalLineAmountInWords", lineTotal)
            Report.DataSourceConnections.Clear()
            ProcessReport()

        End Sub



    End Class
End NameSpace