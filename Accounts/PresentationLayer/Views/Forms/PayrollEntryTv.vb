Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PayrollEntryTv
        Implements IPayrollView

        Private _payrollAttendance As New List(Of AttendanceItemView)
        Private _payrollOvertime As New List(Of OtWorkHourView)

        'Private _payrollEarning As New List(Of PayrollEarningView)
        Private Property MyPresenter As PayrollPresenter

        Private _employees

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Payroll"
            TvMainFieldName = "PayrollName"
            TvSecondaryFieldName = "PayrollCode"
            SortOrderKey = "EndDate"
            FirstControl = txtPayrollName
            ' Add any initialization after the InitializeComponent() call.
            MyPresenter = New PayrollPresenter(Me)
            PresenterObj = MyPresenter
            Ea = MyPresenter.Ea
            Ea.SubscribeEvent(Me)
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
            cboPayCycleIdNo.DataSource = MyPresenter.GetLookup("PayCycle")
            _employees = MyPresenter.GetLookup("Employee")
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

        Public Property IdNo As Int32 Implements IPayrollView.IdNo
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
            Dim payFrequency As PayFrequencySelection
            Dim payCycleDaoObject As New PayCycleDao
            Dim payCycleRecord = payCycleDaoObject.GetRecordByIdNo(PayCycleIdNo)
            If payCycleRecord IsNot Nothing Then
                payFrequency = CodeToEnum(Of PayFrequencySelection)(payCycleRecord.PayFrequency)
                If MyPresenter.AddMode Then
                    If PayFrequencySelection.Monthly Then
                        MyPresenter.InitializeMonthlyPayroll(payCycleRecord)
                    End If
                End If
                If payFrequency = PayFrequencySelection.Monthly Then
                    dtpStartDate.DisplayOnly = True
                    dtpEndDate.DisplayOnly = True
                Else
                    dtpStartDate.DisplayOnly = False
                    dtpEndDate.DisplayOnly = False
                End If
                dtpStartDate.Refresh()
                dtpEndDate.Refresh()
            End If
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

        Protected Overrides Sub InputsTurnedOn()
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

        Protected Overrides Sub InputsTurnedOff()
            UpdateButtonText()
            btnInitializeAttendance.Enabled = False
            btnInitializeOvertime.Enabled = False
        End Sub

        Private Sub btnInitializeAttendance_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnInitializeAttendance.ClickButtonArea
            MyPresenter.InitializeAttendance()
            bsPayrollAttendance.ResetBindings(False)
        End Sub

        Private Sub btnInitialize_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnInitializeOvertime.ClickButtonArea
            MyPresenter.InitializeOvertime()
            bsPayrollOvertime.ResetBindings(True)
            'DataGridViewPayrollOvertime.Refresh()
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            MyPresenter.GeneratePayroll()
        End Sub

        Private Sub CButton3_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton3.ClickButtonArea
            Dim form As PayrollDetailEntry
            form = New PayrollDetailEntry(IdNo)
            form.Show()
        End Sub

    End Class

End Namespace