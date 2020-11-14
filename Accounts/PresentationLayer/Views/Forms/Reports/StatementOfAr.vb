Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfAr

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ArJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            cboCustomerIdNo.DataSource = PresenterObj.GetListByCodeName("Customer")
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim language As String
            Dim curCulture = CultureInfo.CurrentCulture
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            Dim cForm As New ReportForm("Statement of Accounts Receivable.Rpt", dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboCustomerIdNo.SelectedItem.IdNo, "CustomerIdNo", language, "Language")
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace