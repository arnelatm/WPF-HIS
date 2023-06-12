Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class IqamaCbcReport

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private _mode As String

        Public Sub New(mode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "CBCResults"
            SortOrderKey = "IdNo"
            txtSampleNo.Text = ""
            _mode = mode
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim parameters As New ArrayList
            Dim reportName As String
            parameters.Add({"ReportTitle", "Complete Blood Count"})
            If _mode = "SampleNo" Then
                parameters.Add({"SampleNo", txtSampleNo.GetValue(Of Int32)})
                reportName = "CBCReportDyMindBySampleNo.Rpt"
            Else
                parameters.Add({"InvoiceNo", txtSampleNo.GetValue(Of Int32)})
                reportName = "CBCReportDyMindByInvoiceNo.Rpt"
            End If
            Dim cForm As New ReportFormIGroup(reportName, FormCulture, parameters)
            cForm.Show()            
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace