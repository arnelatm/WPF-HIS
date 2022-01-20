Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class GeneratePayrollBankCsv
        Implements IPayrollView

        Public Property MainTableName As String

        Public Property EndDate As Date? Implements IPayrollView.EndDate
            Get
                Return dtpEndDate.Value
            End Get
            Set
                dtpEndDate.Value = Value
            End Set
        End Property

        Public Property IdNo As Int16 Implements IPayrollView.IdNo
            Get
                Return cboIdNo.GetValue()
            End Get
            Set
                cboIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayCycleIdNo As Int16 Implements IPayrollView.PayCycleIdNo
            Get
                Return cboPayCycleIdNo.GetValue()
            End Get
            Set
                cboPayCycleIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayrollCode As String Implements IPayrollView.PayrollCode
            Get
                Return txtPayrollCode.Text
            End Get
            Set(value As String)
                txtPayrollCode.Text = value
            End Set
        End Property

        Public Property PayrollName As String Implements IPayrollView.PayrollName
        Public Property PayrollNameAra As String Implements IPayrollView.PayrollNameAra

        Public Property StartDate As Date? Implements IPayrollView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

        Public Property PayrollAttendance As List(Of AttendanceItemView) Implements IPayrollView.PayrollAttendance
        Public Property PayrollOvertime As List(Of OtWorkHourView) Implements IPayrollView.PayrollOvertime
        Public Property PayFrequency As Char Implements IPayrollView.PayFrequency

        Public Property Employees As Object Implements IPayrollView.Employees

        Protected SortOrderKey As String

        Public Event InitializeAttendance(sender As Object) Implements IPayrollView.InitializeAttendance
        Public Event InitializeOvertime(sender As Object) Implements IPayrollView.InitializeOvertime
        Public Event GenerateRegularPayElements(sender As Object) Implements IPayrollView.GenerateRegularPayElements
        Public Event InitializePayroll(sender As Object) Implements IPayrollView.InitializePayroll
        Public Event GenerateCsvFile(payrollIdNo As Int16) Implements IPayrollView.GenerateCsvFile
        Public Event SelectedPayrollChanged(payrollIdNo As Int16) Implements IPayrollView.SelectedPayrollChanged
        Public Event ClearAllEmployee(sender As Object, clear As Boolean) Implements IPayrollView.ClearAllEmployee

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            MainTableName = "Payroll"
            SortOrderKey = "IdNo"
            SingleData = True
        End Sub

        Private Sub GeneratePayrollBankCsv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            btnPrint.Visible = False
            btnSave.Visible = False
            btnEdit.Visible = False
            btnFilter.Visible = False
            btnDelete.Visible = False
            btnUndo.Visible = False
            btnNew.Visible = False
            btnOpen.Visible = False
            TurnOnInputs()
        End Sub

        Private Sub btnOk_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent GenerateCsvFile(cboIdNo.SelectedValue)
        End Sub

        Private Sub cboIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboIdNo.SelectedValueChanged
            RaiseEvent SelectedPayrollChanged(cboIdNo.SelectedValue)
        End Sub

        Private Sub btnCancel_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"IdNo", cboIdNo},
                {"PayCycleIdNo", cboPayCycleIdNo},
                {"PayrollCode", txtPayrollCode},
                {"StartDate", dtpStartDate},
                {"EndDate", dtpEndDate}
                }
        End Sub

    End Class

End Namespace