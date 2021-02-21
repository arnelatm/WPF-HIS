Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PayrollEntryTv
        Implements IPayrollView

        Private _PayrollAttendance As New List(Of AttendanceItemView)
        Private _payrollEarning As New List(Of PayrollEarningView)
        Private Property MyPresenter As PayrollPresenter

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
            dgvOvertime.SetFormat(8, 2)
            dgvDaysTotal.DisplayOnly = True
            dgvEmployeeName.DisplayOnly = True
            dgvEmployeeNameAra.DisplayOnly = True
            dgvDaysAbsentWoPay.DisplayOnly = True
        End Sub

        Protected Overrides Sub CreateDataSources()
            cboPayCycleIdNo.DataSource = MyPresenter.GetLookup("PayCycle")
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

        Public Property PayrollAttendance As List(Of AttendanceItemView) Implements IPayrollView.PayrollAttendance
            Get
                Return _PayrollAttendance
            End Get
            Set
                _PayrollAttendance = Value
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
                If RightToLeftLayout = True Then
                    dgvEmployeeNameAra.Visible = True
                    dgvEmployeeName.Visible = False
                Else
                    dgvEmployeeName.Visible = True
                    dgvEmployeeNameAra.Visible = False
                End If
                .Refresh()
            End With

        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"StartDate", dtpStartDate},
                {"EndDate", dtpEndDate},
                {"Description", txtPayrollName},
                {"IdNo", TxtIdNo},
                {"PayCycleIdNo", cboPayCycleIdNo}
                }
        End Sub

        Private Sub CacPayCycleIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayCycleIdNo.SelectedIndexChanged
            If MyPresenter.AddMode Then
                Dim payFrequency As PayFrequencySelection
                Dim payCycleDaoObject As New PayCycleDao
                Dim payCycleRecord = payCycleDaoObject.GetRecordById(PayCycleIdNo)
                payFrequency = CodeToEnum(Of PayFrequencySelection)(payCycleRecord.PayFrequency)
                Select Case payFrequency
                    Case PayFrequencySelection.Monthly
                        MyPresenter.InitializeMonthlyPayroll(payCycleRecord)
                End Select
            End If
        End Sub

        Private Sub btnInitialize_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnInitialize.ClickButtonArea
            MyPresenter.InitializeAttendance()
            bsPayrollAttendance.ResetBindings(False)

            'Dim payFrequency = MyPresenter.GetFieldWithIdNo(cboPayCycleIdNo.SelectedValue, "PayCycle", "PayFrequency")
            'Dim employeeFilter = "Active = 1 and PayCycleIdNo = " & cboPayCycleIdNo.SelectedValue.ToString()
            'Dim activeEmployees = MyPresenter.GetFilteredRecords("Employee", "EmployeeName", employeeFilter, {"IdNo", "EmployeeName"})
            'Dim earningDao = New EarningDao
            'Dim earnings = earningDao.GetAll()
            'Dim NumberOfEmployees = Int(activeEmployees.Count() / 2)
            'For i = 1 To NumberOfEmployees
            '    'Dim empEarnings As List(Of EmployeeEarning) = earningDao.GetRecordsWithIdNo(emp, "sequence")
            '    'Dim filter As String
            '    'filter = "EmployeeIdNo = " & emp.ToString()
            '    'Dim employeeEarnings = MyPresenter.GetFilteredRecords("EmployeeEarning", "", filter, {"EarningIdNo", "Amount"})
            '    Dim empAttendance As New AttendanceItemView
            '    empAttendance.PayrollIdNo = IdNo
            '    empAttendance.EmployeeIdNo = activeEmployees(i * 2 - 2)
            '    empAttendance.EmployeeName = activeEmployees(i * 2 - 1)
            '    empAttendance.Sequence = i
            '    _PayrollAttendance.Add(empAttendance)
            '    'For Each employeeEarning In employeeEarnings

            '    'Next
            'Next
            'bsPayrollAttendance.ResetBindings(False)
            'For i = 1 To Int(Data.Count / 3)
            '    Dim tData As New ActiveEmployee
            '    tData.IdNo = Data(i * 3 - 3)
            '    If Data(i * 3 - 1) Is DBNull.Value Then
            '        tData.PayGroupIdNo = 0
            '    Else
            '        tData.PayGroupIdNo = Data(i * 3 - 1)
            '    End If
            '    lEmployeePayGroups.Add(tData)
            'Next
            'For Each employee In lEmployeePayGroups
            '    If employee.PayGroupIdNo = node.Tag Then
            '        node.Nodes.Add(New TreeNode With {.Text = employee.Name,
            '                                   .Tag = employee.IdNo,
            '                                   .Name = employee.Name
            '                                 }
            '              )
            '    End If
            'Next employee
        End Sub

        Private Class ActiveEmployee
            Public IdNo As Int16
        End Class

        Private Class ActiveEmployees
            Public EmployeeIdNo As Int16
            Public EmployeeName As String
            Public EmployeeNameAra As String
            Public Active As Boolean
        End Class

        Private Sub DataGridViewAttendance_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPayrollAttendance.CellEndEdit
            With DataGridViewPayrollAttendance
                Dim nIndex = .CurrentRow.Index
                PayrollAttendance(nIndex).DaysAbsentWithoutPay = PayrollAttendance(nIndex).DaysTotal - PayrollAttendance(nIndex).DaysOff - PayrollAttendance(nIndex).DaysAbsentWithPay - PayrollAttendance(nIndex).DaysPresent
            End With
        End Sub

        Protected Overrides Sub InputsTurnedOn()
            If PayrollAttendance.Count() = 0 Then
                btnInitialize.Text = Messaging.TranslateCaption("Initialize Attendance")
            Else
                btnInitialize.Text = Messaging.TranslateCaption("Re-Process Attendance")
            End If
            btnInitialize.Enabled = True
        End Sub

        Protected Overrides Sub InputsTurnedOff()
            btnInitialize.Enabled = False
        End Sub

    End Class

End Namespace