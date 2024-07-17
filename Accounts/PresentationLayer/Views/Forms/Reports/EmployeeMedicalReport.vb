Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class EmployeeMedicalReport
        Implements IEmployeeMedicalReportView


        Protected SortOrderKey As String
        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "Employee"
            SortOrderKey = "IdNo"
            dtpMedicalReportDate.Value = Today()
            OnMakeDataRequested("Employee", EmployeeIdNoData)
            cboEmployeeIdNo.DataSource = EmployeeIdNoData
        End Sub

        Public Event MakeDataRequested1(tableName As String, variableName As DataTable) Implements IEmployeeMedicalReportView.MakeDataRequested1

        Public Property EmployeeIdNo As Integer Implements IEmployeeMedicalReportView.EmployeeIdNo

        Private _employeeIdNoData As DataTable

        Public Property EmployeeIdNoData As DataTable Implements IEmployeeMedicalReportView.EmployeeIdNoData
            Get
                Return _employeeIdNoData
            End Get
            Set(value As DataTable)
                _employeeIdNoData = value
                cboEmployeeIdNo.DataSource = Nothing
                cboEmployeeIdNo.DataSource = value
                cboEmployeeIdNo.Refresh()
            End Set
        End Property

        Public Property MainTableName As String
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
            If language = "ar" Then
                estName = GlobalVariables.EstablishmentNameAra
            Else
                estName = GlobalVariables.EstablishmentName
            End If
            cForm = New ReportFormOld("Employee Medical Report.rpt", estName, "EstablishmentName", reportTitle, "ReportTitle", CultureInfo.CurrentCulture, cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo", Convert.ToDateTime(dtpMedicalReportDate.Value), "MedicalReportDate", chkVision.Checked, "Vision", chkHearing.Checked, "Hearing", chkBpPulse.Checked, "BPPulse", chkChestHeart.Checked, "ChestHeart", chkAbdomentDerma.Checked, "AbdomenDerma", chkNeuro.Checked, "Neuro", chkFinalResult.Checked, "FinalResult")
            cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub EmployeeMedicalReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            OnMakeDataRequested("Employee", EmployeeIdNoData)
        End Sub

        'Private Sub EmployeeMedicalReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    Dim showAll As Boolean = False
        '    RaiseEvent FormLoaded()
        '    If Presenter.UserHasAccess("HumanResources") Then
        '        Presenter.CreateDataSource("Employee", cboEmployeeIdNo)
        '    Else
        '        Dim employeeIdNo = Presenter.GetUserEmployeeIdNo()
        '        If Presenter.IsUserASupervisor() Then                   
        '            Presenter.CreateDataSource("Employee", cboEmployeeIdNo, "SupervisorIdNo = " & employeeIdNo.ToString() & " or IdNo = " & employeeIdNo.ToString() )
        '        else
        '            Presenter.CreateDataSource("Employee", cboEmployeeIdNo, "IdNo = " & employeeIdNo.ToString() )
        '        End If
        '    End If
        'End Sub

    End Class

End Namespace