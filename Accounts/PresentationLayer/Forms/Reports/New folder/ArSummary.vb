Imports AATM.Accounts.PresentationLayer.Presenters

Namespace PresentationLayer.Forms.Reports
    Public Class ArSummary
        
        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            Dim today = Now()
            Dim nMonth As Integer =  iif(today.Month = 1,12, today.Month-1)
            Dim nYear As Integer =  iif(today.Month = 1,today.Year-1, today.Year)
            dtpBeginningDate.Value = DateSerial(nYear,nMonth,1)
            dtpEndingDate.Value = DateSerial(nYear,nMonth+1,0)
            dtpBeginningDate.EditingMode = True
            dtpEndingDate.EditingMode = True
            dtpEndingDate.Enabled = True
            dtpBeginningDate.Enabled = True
            
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea

            Dim cForm As New ReportForm("Summary of Accounts Receivables.rpt", dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate")
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub
    End Class

End NameSpace