Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class IqamaCbcReport2

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "CBCResults"
            SortOrderKey = "IdNo"
            Presenter = New ReportPresenter(Me)
            Dim currentDate = Now()
            ' returns previous month last day
            Dim endDate = GlobalFunctions.GregorianDateSerial(currentDate.Year, currentDate.Month, 0)
            txtInvoiceNumber.Text = ""
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim parameters As New ArrayList
            parameters.Add({"ReportTitle", "Complete Blood Count"})
            parameters.Add({"InvoiceNumber", txtInvoiceNumber.GetValue(Of Int32)})
            Dim cForm As New ReportFormIGroup("CBCReportDyMindByInvoiceNo.Rpt", FormCulture, parameters)
            cForm.Show()            
        End Sub

        Private Sub CButton2_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub
        
    End Class

End Namespace