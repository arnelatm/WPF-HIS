Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PayrollEntryTv
        Implements IPayrollView

        Private _payrollAttendance As New List(Of AttendanceItemView)
        Private _payrollOvertime As New List(Of OtWorkHourView)
        Private _employees

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtPayrollName
            ' Add any initialization after the InitializeComponent() call.
            dgvDaysPresent.SetFormat(7, 4)
            dgvDaysAbsentWithPay.SetFormat(7, 4)
            dgvDaysOff.SetFormat(7, 4)
            dgvDaysAbsentWoPay.SetFormat(7, 4)
            dgvDaysTotal.SetFormat(7, 4)
            dgvDaysTotal.DisplayOnly = True
            dgvEmployeeIdNo.DisplayOnly = True
            dgvDaysAbsentWoPay.DisplayOnly = True
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("PayCycle", cboPayCycleIdNo)
            CreateLookupData("Employee", NameOf(_employees))
            dgvEmployeeIdNo.DataSource = _employees
            dgvEmployeeIdNoOt.DataSource = _employees
            dgvEmployeeIdNo.DisplayMember = "Name"
            dgvEmployeeIdNoOt.DisplayMember = "Name"
            dgvEmployeeIdNo.ValueMember = "IdNo"
            dgvEmployeeIdNoOt.ValueMember = "IdNo"
            dgvEmployeeIdNo.DisplayOnly = True
            dgvEmployeeIdNoOt.DisplayOnly = True
            dgvEmployeeIdNo.DisplayStyleForCurrentCellOnly = True
            dgvEmployeeIdNoOt.DisplayStyleForCurrentCellOnly = True
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPayrollView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
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

        Public Property StartDate As Date Implements IPayrollView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

        Public Property EndDate As Date Implements IPayrollView.EndDate
            Get
                Return dtpEndDate.Value
            End Get
            Set
                dtpEndDate.Value = Value
            End Set
        End Property

        Public Property PayrollName As String Implements IPayrollView.PayrollName
            Get
                Return txtPayrollName.Text
            End Get
            Set(value As String)
                txtPayrollName.Text = value
            End Set
        End Property

        Public Property PayrollNameAra As String Implements IPayrollView.PayrollNameAra
            Get
                Return txtPayrollNameAra.Text
            End Get
            Set(value As String)
                txtPayrollNameAra.Text = value
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

        Public Property PayrollOvertime As List(Of OtWorkHourView) Implements IPayrollView.PayrollOvertime
            Get
                Return _payrollOvertime
            End Get
            Set
                _payrollOvertime = Value
                BindPayrollOvertime()
            End Set
        End Property

        Public Property PayFrequency As Char Implements IPayrollView.PayFrequency
        '    Get
        '        Return _payFrequency
        '    End Get
        '    Set(value As PayFrequencySelection)
        '        _payFrequency = value
        '    End Set
        'End Property

        Public Property PayrollAttendance As List(Of AttendanceItemView) Implements IPayrollView.PayrollAttendance
            Get
                Return _payrollAttendance
            End Get
            Set
                _payrollAttendance = Value
                BindPayrollAttendance()
            End Set
        End Property

#End Region

        Public Event InitializeAttendance(sender As Object) Implements IPayrollView.InitializeAttendance

        Public Event InitializeOvertime(sender As Object) Implements IPayrollView.InitializeOvertime

        Public Event GenerateRegularPayElements(sender As Object) Implements IPayrollView.GenerateRegularPayElements

        Public Event InitializePayroll(sender As Object) Implements IPayrollView.InitializePayroll

        Public Event GenerateCsvFile(payrollIdNo As Int16) Implements IPayrollView.GenerateCsvFile

        Public Event SelectedPayrollChanged(payrollIdNo As Int16) Implements IPayrollView.SelectedPayrollChanged

        Private Sub BindPayrollAttendance()
            SuspendLayout()
            bsPayrollAttendance.DataSource = Nothing
            DataGridViewPayrollAttendance.Refresh()
            bsPayrollAttendance.DataSource = PayrollAttendance
            bsPayrollAttendance.AllowNew = True
            With DataGridViewPayrollAttendance
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPayrollAttendance
                .Refresh()
            End With

        End Sub

        Private Sub BindPayrollOvertime()
            SuspendLayout()
            bsPayrollOvertime.DataSource = Nothing
            DataGridViewPayrollOvertime.Refresh()
            bsPayrollOvertime.DataSource = PayrollOvertime
            bsPayrollOvertime.AllowNew = True
            With DataGridViewPayrollOvertime
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPayrollOvertime
                .Refresh()
            End With

        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"StartDate", dtpStartDate},
                {"EndDate", dtpEndDate},
                {"Description", txtPayrollName},
                {"IdNo", TxtIdNo},
                {"PayCycleIdNo", cboPayCycleIdNo}
                }
        End Sub

        Private Sub CacPayCycleIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayCycleIdNo.SelectedIndexChanged
            RaiseEvent InitializePayroll(Me)
            If CodeToEnum(Of PayFrequencySelection)(PayFrequency) = PayFrequencySelection.Monthly Then
                dtpStartDate.DisplayOnly = True
                dtpEndDate.DisplayOnly = True
            Else
                dtpStartDate.DisplayOnly = False
                dtpEndDate.DisplayOnly = False
            End If
            dtpStartDate.Refresh()
            dtpEndDate.Refresh()
        End Sub

        'Private Class ActiveEmployee
        '    Public IdNo As Int16
        'End Class

        'Private Class ActiveEmployees
        '    Public EmployeeIdNo As Int16
        '    Public EmployeeName As String
        '    Public EmployeeNameAra As String
        '    Public Active As Boolean
        'End Class

        Private Sub DataGridViewAttendance_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPayrollAttendance.CellEndEdit
            With DataGridViewPayrollAttendance
                If .CurrentRow() IsNot Nothing Then
                    Dim nIndex = .CurrentRow.Index
                    PayrollAttendance(nIndex).DaysPresent = PayrollAttendance(nIndex).DaysTotal - PayrollAttendance(nIndex).DaysOff - PayrollAttendance(nIndex).DaysAbsentWithPay - PayrollAttendance(nIndex).DaysAbsentWithoutPay
                    'PayrollAttendance(nIndex).DaysAbsentWithoutPay = PayrollAttendance(nIndex).DaysTotal - PayrollAttendance(nIndex).DaysOff - PayrollAttendance(nIndex).DaysAbsentWithPay - PayrollAttendance(nIndex).DaysPresent
                End If
            End With
        End Sub

        Protected Sub OnInputsTurnedOn() Handles MyBase.InputsTurnedOn
            UpdateButtonText()
            btnInitializeAttendance.Enabled = True
            btnInitializeOvertime.Enabled = True
        End Sub

        Private Sub UpdateButtonText()
            If PayrollAttendance.Count() = 0 Then
                btnInitializeAttendance.Text = Messaging.TranslateCaption("Initialize Attendance")
                btnInitializeOvertime.Text = Messaging.TranslateCaption("Initialize Overtime")
            Else
                btnInitializeAttendance.Text = Messaging.TranslateCaption("Re-Process Attendance")
                btnInitializeOvertime.Text = Messaging.TranslateCaption("Re-Process Overtime")
            End If
        End Sub

        Protected Sub OnInputsTurnedOff() Handles MyBase.InputsTurnedOff
            UpdateButtonText()
            btnInitializeAttendance.Enabled = False
            btnInitializeOvertime.Enabled = False
        End Sub

        Private Sub OnInitializeAttendance_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnInitializeAttendance.ClickButtonArea
            RaiseEvent InitializeAttendance(Me)
            bsPayrollAttendance.ResetBindings(False)
        End Sub

        Private Sub InitializeOvertime_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnInitializeOvertime.ClickButtonArea
            RaiseEvent InitializeOvertime(Me)
            bsPayrollOvertime.ResetBindings(True)
        End Sub

        Private Sub BtnGeneratePayElements_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnGenerateRegularPayElements.ClickButtonArea
            RaiseEvent GenerateRegularPayElements(Me)
        End Sub

        Private Sub BtnViewPayrollReport_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnViewPayrollReport.ClickButtonArea
            RunSubForm(Of PayrollDetailEntry, PayrollDetailPresenter(Of PayrollDetailModel))(IdNo, ParentForm)
        End Sub

    End Class

End Namespace