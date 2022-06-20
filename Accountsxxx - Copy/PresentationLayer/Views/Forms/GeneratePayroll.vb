Imports System.Dynamic
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class GeneratePayroll
        Implements IPayrollView

        Public Property MainTableName As String
        Protected SortOrderKey As String
        Private Property MyPresenter As GeneratePayrollPresenter

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "Payroll"
            SortOrderKey = "IdNo"
            PresenterObj = New GeneratePayrollPresenter(Me)
            MyPresenter = PresenterObj
            ProgressBar.Minimum = 0
            ProgressBar.Maximum = 100

        End Sub

        Public Property EndDate As Date Implements IPayrollView.EndDate

        Public Property IdNo As Integer Implements IPayrollView.IdNo
            Get
                Return txtPayrollIdNo.Text
            End Get
            Set(value As Integer)
                txtPayrollIdNo.Text = value
            End Set
        End Property

        Public Property PayCycleIdNo As Short Implements IPayrollView.PayCycleIdNo
        Public Property PayrollCode As String Implements IPayrollView.PayrollCode
        Public Property PayrollName As String Implements IPayrollView.PayrollName
        Public Property PayrollNameAra As String Implements IPayrollView.PayrollNameAra
        Public Property StartDate As Date Implements IPayrollView.StartDate
        Public Property PayrollAttendance As List(Of AttendanceItemView) Implements IPayrollView.PayrollAttendance
        Public Property PayrollOvertime As List(Of OtWorkHourView) Implements IPayrollView.PayrollOvertime

        Private Sub GeneratePayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboPayrollIdNo.DataSource = PresenterObj.GetLookup("Payroll")
            cboPayCycleIdNo.DataSource = PresenterObj.GetLookup("PayCycle")
            cboPayCycleIdNo.EditingMode = False
            cboPayrollIdNo.EditingMode = True
            txtPayrollIdNo.EditingMode = False
            txtPayrollName.EditingMode = False
            dtpBeginningDate.EditingMode = False
            dtpEndingDate.EditingMode = False
        End Sub

        Private Sub cboPayrollIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayrollIdNo.SelectedIndexChanged
            Dim payroll As Object = New ExpandoObject
            payroll = PresenterObj.ModelPresenter.GetFieldsWithIdNo(cboPayrollIdNo.SelectedValue, "Payroll", "IdNo,PayrollCode,StartDate,EndDate,PayrollName,PayCycleIdNo")
            dtpBeginningDate.Value = CType(payroll.StartDate, Date)
            dtpEndingDate.Value = CType(payroll.EndDate, Date)
            txtPayrollName.Text = payroll.PayrollName
            txtPayrollIdNo.Text = payroll.IdNo
            cboPayCycleIdNo.SetValue(payroll.PayCycleIdNo)
        End Sub

        Private Sub btnCancel_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            PresenterObj.GeneratePayroll(cboPayrollIdNo.SelectedValue, dtpBeginningDate.Value, dtpEndingDate.Value, ProgressBar)
        End Sub

    End Class

End Namespace