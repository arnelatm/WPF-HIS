Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfAp

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ApJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            cboSupplierIdNo.DataSource = PresenterObj.GetLookup("Supplier")
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim cForm
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim reportName As String
                Dim reportTitle As String
                reportName = Messaging.TranslateCaption("Statement of Accounts Payable")
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"beginningDate", dtpBeginningDate.Value.ToString, "endingDate", dtpEndingDate.Value.ToString})
                If Strings.Left(FormCulture.Name, 2) = "ar" Then
                    cForm = New ReportFormNew("Statement of Accounts Payable Arabic.Rpt", reportTitle, FormCulture, dtpBeginningDate.Value.ToString(), "BeginningDate", dtpEndingDate.Value, "EndingDate", cboSupplierIdNo.SelectedItem.IdNo, "SupplierIdNo", cboSupplierIdNo.Text, "DisplayName")
                Else
                    cForm = New ReportFormNew("Statement of Accounts Payable.Rpt", reportTitle, FormCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboSupplierIdNo.SelectedItem.IdNo, "SupplierIdNo", cboSupplierIdNo.Text, "DisplayName")
                End If
                cForm.Show()
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace