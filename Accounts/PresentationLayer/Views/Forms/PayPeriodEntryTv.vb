Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PayPeriodEntryTv
        Implements IPayPeriodView

        Private _payPeriodAttendance As New List(Of IAttendanceItemView)

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PayPeriod"
            TvMainFieldName = "PayPeriodName"
            TvSecondaryFieldName = "PayPeriodCode"
            SortOrderKey = "EndDate"
            FirstControl = txtPayPeriodName
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PayPeriodPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

        Protected Overrides Sub CreateDataSources()
            cboPayCycleIdNo.DataSource = PresenterObj.GetLookup("PayCycle")
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IPayPeriodView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PayCycleIdNo As Int16 Implements IPayPeriodView.PayCycleIdNo
            Get
                Return cboPayCycleIdNo.GetValue()
            End Get
            Set
                cboPayCycleIdNo.SetValue(Value)
            End Set
        End Property

        Public Property StartDate As Date Implements IPayPeriodView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

        Public Property EndDate As Date Implements IPayPeriodView.EndDate
            Get
                Return dtpEndDate.Value
            End Get
            Set
                dtpEndDate.Value = Value
            End Set
        End Property

        Public Property PayPeriodName As String Implements IPayPeriodView.PayPeriodName
            Get
                Return txtPayPeriodName.Text
            End Get
            Set(value As String)
                txtPayPeriodName.Text = value
            End Set
        End Property

        Public Property PayPeriodNameAra As String Implements IPayPeriodView.PayPeriodNameAra
            Get
                Return txtPayPeriodNameAra.Text
            End Get
            Set(value As String)
                txtPayPeriodNameAra.Text = value
            End Set
        End Property

        Public Property PayPeriodCode As String Implements IPayPeriodView.PayPeriodCode
            Get
                Return txtPayPeriodCode.Text
            End Get
            Set(value As String)
                txtPayPeriodCode.Text = value
            End Set
        End Property

        Public Property PayPeriodAttendance As List(Of IAttendanceItemView) Implements IPayPeriodView.PayPeriodAttendance
            Get
                Return _payPeriodAttendance
            End Get
            Set
                _payPeriodAttendance = Value
                BindPayPeriodAttendance()
            End Set
        End Property

#End Region

        Private Sub BindPayPeriodAttendance()
            SuspendLayout()
            bsPayPeriodAttendance.DataSource = Nothing
            DataGridViewPayPeriodAttendance.Refresh()
            bsPayPeriodAttendance.DataSource = PayPeriodAttendance
            bsPayPeriodAttendance.AllowNew = True
            'bsPayPeriodAttendance.Sort = "Sequence"
            With DataGridViewPayPeriodAttendance
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsPayPeriodAttendance
                .Refresh()
            End With
            'With DataGridViewPayPeriodAttendance.Columns
            '    dgvEarningIdNo.DataSource = _PayPeriodAttendanceByName
            '    dgvEarningIdNo.DisplayMember = "Name"
            '    dgvEarningIdNo.ValueMember = "IdNo"
            '    dgvEarningIdNo.AutoComplete = AutoCompleteMode.SuggestAppend
            '    dgvEarningIdNo.DisplayStyleForCurrentCellOnly = True
            'End With
            ResumeLayout()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"StartDate", dtpStartDate},
                {"EndDate", dtpEndDate},
                {"Description", txtPayPeriodName},
                {"IdNo", TxtIdNo},
                {"PayCycleIdNo", cboPayCycleIdNo}
                }
        End Sub

        Private Sub CacPayCycleIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayCycleIdNo.SelectedIndexChanged
            If PresenterObj.AddMode Then
                Dim payFrequency As PayFrequencySelection
                Dim payCycleDaoObject As New PayCycleDao
                Dim payCycleRecord = payCycleDaoObject.GetRecordById(PayCycleIdNo)
                payFrequency = CodeToEnum(Of PayFrequencySelection)(payCycleRecord.PayFrequency)
                Select Case payFrequency
                    Case PayFrequencySelection.Monthly
                        PresenterObj.InitializeMonthlyPayroll(payCycleRecord)
                End Select
            End If
        End Sub

        Private Sub btnInitialize_ClickButtonArea(sender As Object, e As MouseEventArgs) Handles btnInitialize.ClickButtonArea
            Dim payFrequency = PresenterObj.GetFieldWithIdNo(cboPayCycleIdNo.SelectedValue, "PayCycle", "PayFrequency")
            Dim employeeFilter = "Active = 1 and PayCycleIdNo = " & cboPayCycleIdNo.SelectedValue.ToString()
            Dim activeEmployees = PresenterObj.GetFilteredRecords("Employee", "EmployeeName", employeeFilter, {"IdNo", "EmployeeName"})
            Dim earningDao = New EarningDao
            Dim earnings = earningDao.GetAll()
            Dim NumberOfEmployees = Int(activeEmployees.Count() / 2)
            For i = 1 To NumberOfEmployees
                'Dim empEarnings As List(Of EmployeeEarning) = earningDao.GetRecordsWithIdNo(emp, "sequence")
                'Dim filter As String
                'filter = "EmployeeIdNo = " & emp.ToString()
                'Dim employeeEarnings = PresenterObj.GetFilteredRecords("EmployeeEarning", "", filter, {"EarningIdNo", "Amount"})
                Dim empAttendance As New AttendanceItemView
                empAttendance.PayPeriodIdNo = IdNo
                empAttendance.EmployeeIdNo = activeEmployees(i * 2 - 2)
                empAttendance.EmployeeName = activeEmployees(i * 2 - 1)
                empAttendance.Sequence = i
                _payPeriodAttendance.Add(empAttendance)
                'For Each employeeEarning In employeeEarnings

                'Next
            Next
            bsPayPeriodAttendance.ResetBindings(False)
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

    End Class

End Namespace