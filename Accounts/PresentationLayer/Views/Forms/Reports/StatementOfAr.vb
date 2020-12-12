Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

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
            cboCustomerIdNo.DataSource = PresenterObj.GetLookup("Customer")
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim cForm As New ReportFormNew("Statement of Accounts Receivable.Rpt", FormCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboCustomerIdNo.SelectedItem.IdNo, "EmployeeIdNo", cboCustomerIdNo.Text, "EmployeeDisplayName")
                cForm.Show()
            Else
                Messaging.Show(True, "MsgBegDateLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

    End Class

End Namespace