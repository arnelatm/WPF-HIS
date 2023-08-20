Imports System.Globalization
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms.Reports

    Public Class EmployeeInfo
        Implements IHrReportsView

        Public Property MainTableName As String
        Public Event PrintButtonClicked() Implements IHrReportsView.PrintButtonClicked
        Public Event FormLoaded() Implements IHrReportsView.FormLoaded
        Protected SortOrderKey As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "EmployeeInfo_View"
            SortOrderKey = "IdNo"
        End Sub

        Public Property EmployeeSelectorControl As Control Implements IHrReportsView.EmployeeSelectorControl


        Public ReadOnly Property BeginningDate As Date? Implements IHrReportsView.BeginningDate

        Public ReadOnly Property EndingDate As Date? Implements IHrReportsView.EndingDate

        Public ReadOnly Property Language As String Implements IHrReportsView.Language
            Get
                Dim curCulture = CultureInfo.CurrentCulture
                Return Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-"))
            End Get
        End Property

        Public Property EmployeeIdNo As Integer Implements IHrReportsView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboEmployeeIdNo.SetValue(value)
            End Set
        End Property

        Public Property UserHasHrAccess As Boolean Implements IHrReportsView.UserHasHrAccess

        Public ReadOnly Property ReportName As String Implements IHrReportsView.ReportName
            Get
                Return "HR Employee Info"
            End Get
        End Property

        Public ReadOnly Property ReportFileName As String Implements IHrReportsView.ReportFileName
            Get
                Return "HR Employee Info.Rpt"
            End Get
        End Property


        Private Sub CButton1_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PrintButtonClicked()
            'Dim cForm
            'Dim reportName As String
            'Dim reportTitle As String
            'reportName = Messaging.TranslateCaption("Statement of Employee Leaves")
            'reportTitle = Messaging.GetParametrizedMessage(True, "RptForThePeriod", {"reportName", reportName})
            'cForm = New ReportFormNew("HR Employee Info.rpt", reportTitle, CultureInfo.CurrentCulture, cboEmployeeIdNo.SelectedItem.IdNo, "EmployeeIdNo")
            'cForm.Show()
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub EmployeeInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboEmployeeIdNo.EditingMode = False
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
            cboEmployeeIdNo.EditingMode = True
        End Sub


    End Class

End Namespace