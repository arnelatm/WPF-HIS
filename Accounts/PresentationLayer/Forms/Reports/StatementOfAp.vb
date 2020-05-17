Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms.Reports
    Public Class StatementOfAp

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "AccountsPayableJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            cboSupplierCode.DataSource = PresenterObj.GetSupplierListByCode()
            Dim today = Now()
            dtpBeginningDate.Value = DateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = DateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim cForm As New ReportForm("Statement of Accounts Payable.Rpt", dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboSupplierCode.SelectedItem.Code, "SupplierCode")
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class
End Namespace