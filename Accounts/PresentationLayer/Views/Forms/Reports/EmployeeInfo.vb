Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class EmployeeInfo

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "EmployeeInfo_View"
            SortOrderKey = "IdNo"
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim cForm
            Dim reportName As String
            Dim reportTitle As String
            reportName = Messaging.TranslateCaption("Statement of Employee Leaves")
            reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName})
            cForm = New ReportFormNew("HR Employee Info.rpt", reportTitle, CultureInfo.CurrentCulture, cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo")
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub EmployeeInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim showAll As Boolean = False
            If Presenter.UserHasAccess("HumanResources") Then
                Presenter.CreateDataSource("Employee", cboEmployeeIdNo)
            Else
                Dim employeeIdNo = Presenter.GetUserEmployeeIdNo()
                If Presenter.IsUserASupervisor() Then                   
                    Presenter.CreateDataSource("Employee", cboEmployeeIdNo, "SupervisorIdNo = " & employeeIdNo.ToString() & " or IdNo = " & employeeIdNo.ToString() )
                else
                    Presenter.CreateDataSource("Employee", cboEmployeeIdNo, "IdNo = " & employeeIdNo.ToString() )
                End If
            End If
        End Sub


    End Class

End Namespace