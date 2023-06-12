Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class StatementOfLeave

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "ErJournal"
            SortOrderKey = "IdNo"
            Presenter.CreateDataSource("Employee", cboEmployeeIdNo)
            Dim today = Now()
            dtpBeginningDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, 1, 1)
            dtpEndingDate.Value = GlobalFunctions.GregorianDateSerial(today.Year, today.Month, today.Day)

        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If dtpBeginningDate.Value <= dtpEndingDate.Value Then
                Dim cForm
                Dim reportName As String
                Dim reportTitle As String
                Dim bDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpBeginningDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                Dim eDate As String = GlobalFunctions.DateToSpecificCultureShortDateString(dtpEndingDate.Value, CultureInfo.CreateSpecificCulture("en-GB"))
                reportName = Messaging.TranslateCaption("Statement of Employee Leaves")
                reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName, "beginningDate", bDate, "endingDate", eDate})
                'If Strings.Left(FormCulture.Name, 2) = "ar" Then
                '    cForm = New ReportFormNew("Statement of Employee Loans Arabic.rpt", reportTitle, FormCulture, dtpBeginningDate.Value, "BeginningDate", dtpEndingDate.Value, "EndingDate", cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo", cboEmployeeIdNo.Text, "DisplayName")
                'Else
                cForm = New ReportFormNew("Statement of Employee Leaves.rpt", reportTitle, CultureInfo.CurrentCulture, dtpBeginningDate.Value, "DateStart", dtpEndingDate.Value, "DateEnd", cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo", cboEmployeeIdNo.Text, "DisplayName")
                'End If
                cForm.Show()
            Else
                Messaging.Show(True, "MsgBegDateMustBeLessThanEndDate")
            End If
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub StatementOfLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim showAll As Boolean = False
            If Presenter.UserHasAccess("HumanResources") Then
                Presenter.CreateDataSource("Employee", cboEmployeeIdNo)
            Else
                Dim employeeIdNo = Presenter.GetUserEmployeeIdNo()
                If Presenter.IsUserASupervisor() Then
                    Presenter.CreateDataSource("Employee", cboEmployeeIdNo, "SupervisorIdNo = " & employeeIdNo.ToString() & " or IdNo = " & employeeIdNo.ToString())
                Else
                    Presenter.CreateDataSource("Employee", cboEmployeeIdNo, "IdNo = " & employeeIdNo.ToString())
                End If
            End If
        End Sub

    End Class

End Namespace