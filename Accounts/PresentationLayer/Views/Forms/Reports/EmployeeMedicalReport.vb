Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class EmployeeMedicalReport

        Public Property MainTableName As String
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Employee"
            SortOrderKey = "IdNo"
            dtpMedicalReportDate.Value = Today()
        End Sub

        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            Dim cForm
            Dim reportName As String
            Dim reportTitle As String
            Dim curCulture = CultureInfo.CurrentCulture
            Dim language As String
            Dim estName As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            reportName = Messaging.TranslateCaption("Employee Medical Report")
            reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName})
            estName = GlobalVariables.GetEstablishmentName(language)
            cForm = New ReportForm("Employee Medical Report.rpt", estName, "EstablishmentName", reportTitle, "ReportTitle", CultureInfo.CurrentCulture, cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo", Convert.ToDateTime(dtpMedicalReportDate.Value), "MedicalReportDate", chkVision.Checked, "Vision", chkHearing.Checked, "Hearing", chkBpPulse.Checked, "BPPulse", chkChestHeart.Checked, "ChestHeart", chkAbdomentDerma.Checked, "AbdomenDerma", chkNeuro.Checked, "Neuro", chkFinalResult.Checked, "FinalResult")
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub EmployeeMedicalReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
