Namespace PresentationLayer.Views.Forms

    Public Class ArJournalReport

        Public Sub New(ByVal idNo As Int32, ByVal amount As String, ByVal lineTotal As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            ReportFileName = "Accounts Receivable Journal.rpt"
            GetReportProperties()
            ReportDocument.SetParameterValue("ArJournalIdNo", idNo)
            ReportDocument.SetParameterValue("ArAmountInWords", amount)
            ReportDocument.SetParameterValue("TotalLineAmountInWords", lineTotal)
            ReportDocument.DataSourceConnections.Clear()
            ProcessReport()

        End Sub

    End Class

End Namespace