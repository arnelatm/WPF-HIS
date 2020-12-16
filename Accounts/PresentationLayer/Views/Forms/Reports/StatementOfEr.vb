Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfEr

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ErJournal"
            SortOrderKey = "IdNo"
            PresenterObj = New ReportPresenter(Me)
            cboEmployeeIdNo.DataSource = PresenterObj.GetLookup("Employee")
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim cForm
                If Strings.Left(FormCulture.Name, 2) = "ar" Then
                    cForm = New ReportFormNew("Statement of Employee Loans Arabic.rpt", FormCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo", cboEmployeeIdNo.Text, "EmployeeDisplayName")
                Else
                    cForm = New ReportFormNew("Statement of Employee Loans.rpt", FormCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo", cboEmployeeIdNo.Text, "EmployeeDisplayName")
                End If
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