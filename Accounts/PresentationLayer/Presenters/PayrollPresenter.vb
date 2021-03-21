Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports CrystalDecisions.Shared.Json

Namespace PresentationLayer.Presenters

    Public Class PayrollPresenter
        Inherits AccountsPresenter(Of IPayrollView, PayrollModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected DtOtInsertTable As New DataTable
        Protected DtOtUpdateTable As New DataTable
        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        Private _attendanceItemModel
        Private _otWorkHourModel
        Private _reinitialize As Boolean = False
        Private _payrollEarning
        Private _payrollPayElements As New List(Of PayrollPayElementModel)
        Private _savedPayrollPayElements As New List(Of PayrollPayElementModel)
        Private _computedEarnings As New List(Of PayElementModel)
        Private _globalEarnings As New List(Of PayElementModel)

        Private _daysInTheMonth As Int16
        Private _endDate As Date
        Private _payFrequency As PayFrequencySelection
        Private _payrollIdNo As Int16

        Private ReadOnly _deductionComputationMethod As String = "1"
        Private ReadOnly _dtPayrollDetailInsertTable As New DataTable
        Private ReadOnly _dtPayrollDetailUpdateTable As New DataTable
        Private ReadOnly _dtPayrollPayElementInsertTable As New DataTable
        Private ReadOnly _dtPayrollPayElementUpdateTable As New DataTable

        Private ReadOnly _attendanceItemDao = New AttendanceItemDao

        Private ReadOnly _employeeEarningsDao = New EmployeeEarningDao
        Private ReadOnly _otWorkHoursDao = New OtWorkHourDao
        Private ReadOnly _payCycleDao = New PayCycleDao
        Private ReadOnly _payElementsDao = New PayElementDao
        Private ReadOnly _payElementItemsDao = New PayElementItemDao
        Private ReadOnly _payrollDao = New PayrollDao
        Private ReadOnly _payrollDetailsDao = New PayrollDetailDao
        Private ReadOnly _payrollPayElementsDao = New PayrollPayElementDao

        Private ReadOnly _computedEarningType = EnumToCode(EarningTypeSelection.Computed)

        Private ReadOnly _factorType = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _fixedRateType = EnumToCode(CalculationTypeSelection.FixedRate)
        Private ReadOnly _overtimeHoursHolidayType = EnumToCode(AttendanceUnitSelection.OvertimeHoliday)
        Private ReadOnly _overtimeHoursRegularType = EnumToCode(AttendanceUnitSelection.OvertimeRegular)
        Private ReadOnly _overtimeHoursSpecialType = EnumToCode(AttendanceUnitSelection.OvertimeSpecial)
        Private ReadOnly _regularPayElement = EnumToCode(EarningTypeSelection.Regular)
        Private ReadOnly _variable = EnumToCode(CalculationTypeSelection.Variable)

        Public Sub New(view As IPayrollView)
            MyBase.New(view)
            TreeViewMainField = "PayrollName"
            TreeViewSecondaryField = "PayrollCode"
            TreeViewList = New List(Of Payroll)

            TableName = "Payroll"
            SortOrderKey = "EndDate"
            ModelPresenter = New ModelAccounts("Payroll")
            OriginalModel = New PayrollModel
            DataModel = New PayrollModel
            If TreeViewParentIdField IsNot Nothing Then
                SortOrderKey = "EndDate"
            End If

            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            _attendanceItemModel = New ModelAccounts("AttendanceItem", Nothing, Nothing)
            _otWorkHourModel = New ModelAccounts("OtWorkHour", Nothing, Nothing)

            CreateDataTable(DtInsertTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"PayrollIdNo", GetType(Int16)}
                                           })

            CreateDataTable(DtUpdateTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"PayrollIdNo", GetType(Int16)}
                                           })

            CreateDataTable(DtOtInsertTable, {{"EmployeeIdNo", GetType(Int32)},
                                            {"OvertimeRegular", GetType(Decimal)},
                                            {"OvertimeHoliday", GetType(Decimal)},
                                            {"OvertimeSpecial", GetType(Decimal)},
                                            {"PayrollIdNo", GetType(Int16)}
                                           })

            CreateDataTable(DtOtUpdateTable, {{"EmployeeIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"OvertimeRegular", GetType(Decimal)},
                                            {"OvertimeHoliday", GetType(Decimal)},
                                            {"OvertimeSpecial", GetType(Decimal)},
                                            {"PayrollIdNo", GetType(Int16)}
                                           })

            'CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            '                                {"EarningIdNo", GetType(Int16)},
            '                                {"EmployeeIdNo", GetType(Int32)},
            '                                {"PayrollIdNo", GetType(Int32)}
            '                               })

            'CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            '                                {"EarningIdNo", GetType(Int16)},
            '                                {"EmployeeIdNo", GetType(Int32)},
            '                                {"IdNo", GetType(Int32)},
            '                                {"PayrollIdNo", GetType(Int32)}
            '                               })

        End Sub

        Public Sub InitializeMonthlyPayroll(payCycleRecord As PayCycle)
            _payrollIdNo = View.IdNo
            If View.StartDate = Nothing And View.EndDate = Nothing Then
                If payCycleRecord.PayCycleCode = "Month" Then
                    Dim nIdNoMax As Int32
                    Dim maxRecord As PayrollModel
                    Dim payMonthText As String = "Payroll for the Month of"
                    Dim PayrollText As String = "Payroll for the Period"
                    nIdNoMax = ModelPresenter.GetMaxValueFiltered("EndDate", "Payroll", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
                    maxRecord = ModelPresenter.GetRecordByIdNo(Of PayrollModel)(nIdNoMax)
                    View.StartDate = maxRecord.EndDate.AddDays(1)
                    Dim arabicCulture As New CultureInfo("ar-ae", False)
                    If View.StartDate.Day = 1 Then
                        View.EndDate = View.StartDate.AddMonths(1).AddDays(-1)
                        View.PayrollName = payMonthText & " " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                        View.PayrollNameAra = Messaging.TranslateCaption(payMonthText, "ar-SA") + GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate) - 1) & " " & Year(View.EndDate).ToString()
                    Else
                        View.EndDate = maxRecord.EndDate.AddMonths(1)
                        View.PayrollName = PayrollText & " " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
                        View.PayrollNameAra = Messaging.TranslateCaption(PayrollText, "ar-SA") & " " & GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                    End If
                    View.PayrollCode = "M" + View.EndDate.ToString("yyMM")
                End If
            End If
        End Sub

        Public Sub OnBeforeAdd() Handles MyBase.BeforeAdd

            'Dim nIdNoMax As Int32
            'Dim maxRecord As PayrollModel
            'Dim payMonthText As String = "Payroll for the Month of"
            'Dim PayrollText As String = "Payroll for the Period"
            'nIdNoMax = ModelPresenter.GetMaxValueFiltered("EndDate", "Payroll", "IdNo", "PayCycleIdNo = 1") ' + View.PayCycleIdNo.ToString())
            'If nIdNoMax = 0 Then
            '    Dim now As Date = Today()
            '    View.EndDate = DateAdd(DateInterval.Day, DateAndTime.Day(now) * -1, now)
            '    View.StartDate = DateAdd(DateInterval.Day, DateAndTime.Day(View.EndDate) * -1 + 1, View.EndDate)
            'Else
            '    maxRecord = ModelPresenter.GetRecordByIdNo(Of PayrollModel)(nIdNoMax)
            '    View.StartDate = maxRecord.EndDate.AddDays(1)
            '    If View.StartDate.Day = 1 Then
            '        View.EndDate = View.StartDate.AddMonths(1).AddDays(-1)
            '    Else
            '        View.EndDate = maxRecord.EndDate.AddMonths(1)
            '    End If
            'End If
            'View.PayCycleIdNo = 1
            'Dim arabicCulture As New CultureInfo("ar-ae", False)
            'If View.StartDate.Day = 1 AndAlso DateAdd(DateInterval.Day, DateAndTime.Day(View.EndDate) * -1 + 1, View.EndDate) = View.StartDate Then
            '    View.PayrollName = payMonthText & " " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
            '    View.PayrollNameAra = Messaging.TranslateCaption(payMonthText, "ar-SA") + GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate) - 1) & " " & Year(View.EndDate).ToString()
            'Else
            '    View.PayrollName = PayrollText & " " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
            '    View.PayrollNameAra = Messaging.TranslateCaption(PayrollText, "ar-SA") & " " & GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
            'End If
            'View.PayrollCode = "M" + View.EndDate.ToString("yyMM")

        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PayrollAttendance, DtInsertTable, DtUpdateTable, AddressOf AttendanceItemFillData, AddressOf AttendanceItemFilter, "IdNo", "")
                ViewToDataTables(View.PayrollOvertime, DtOtInsertTable, DtOtUpdateTable, AddressOf OtWorkHourFillData, AddressOf OtWorkHourFilter, "IdNo", "")
            End If
            'For Each item In View.PayrollAttendance
            '    If item.Equals(DBNull.Value) Then
            '        item.Notes = ""
            '    End If
            '    If item.Notes Is Nothing Then
            '        item.Notes = ""
            '    End If
            'Next
        End Sub

        Public Sub InitializeAttendance()
            Dim payFrequency = GetFieldWithIdNo(View.PayCycleIdNo, "PayCycle", "PayFrequency")
            Dim employeeFilter = "PayCycleIdNo = " & View.PayCycleIdNo.ToString()
            Dim activeEmployees = GetFilteredRecords("Employee", "EmployeeName", employeeFilter, {"IdNo", "EmployeeName", "HiredDate", "ReleasedDate"})
            'Dim earningDao = New EarningDao
            'Dim earnings = earningDao.GetAll()
            Dim numberOfEmployees = Int(activeEmployees.Count() / 4)
            Dim daysInPeriod As Int16
            Dim daysOffInPeriod As Int16
            Dim seq As Int16
            Dim dateHired As Date
            Dim dateReleased As Date?
            Dim empId As Int32
            Dim empName As String
            Dim empFound As Boolean = False
            seq = View.PayrollAttendance.Count() + 1
            daysInPeriod = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
            daysOffInPeriod = FridaysInPeriod(View.StartDate, View.EndDate)
            If View.PayrollAttendance.Any() Then
                _reinitialize = True
            Else
                _reinitialize = False
            End If
            For i = 1 To numberOfEmployees
                'Dim empEarnings As List(Of EmployeeEarning) = earningDao.GetRecordsWithGroupIdNo(emp, "sequence")
                'Dim filter As String
                'filter = "EmployeeIdNo = " & emp.ToString()
                'Dim employeeEarnings = PresenterObj.GetFilteredRecords("EmployeeEarning", "", filter, {"EarningIdNo", "Amount"})

                empId = activeEmployees(i * 4 - 4)
                empName = activeEmployees(i * 4 - 3)
                dateHired = activeEmployees(i * 4 - 2)
                dateReleased = IIf(IsDBNull(activeEmployees(i * 4 - 1)), Nothing, activeEmployees(i * 4 - 1))

                If _reinitialize Then
                    Dim empAttendance As AttendanceItemView
                    empAttendance = View.PayrollAttendance.Find(Function(c) c.EmployeeIdNo = empId)
                    If empAttendance Is Nothing Then
                        empFound = False
                    Else
                        empFound = True
                        'empAttendance.DaysTotal = DateDiff(DateInterval.Day, dateHired, eDate) + 1
                        'empAttendance.DaysOff = FridaysInPeriod(dateHired, eDate)
                        If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
                            UpdateEmployeeAttendance(empAttendance, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
                            If empAttendance.DaysAbsentWithoutPay <> empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysPresent Then
                                empAttendance.DaysAbsentWithoutPay = empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysPresent
                            End If
                        Else
                            View.PayrollAttendance.Remove(empAttendance)
                        End If
                    End If
                End If
                If empFound Then
                    Continue For
                End If

                If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
                    AddEmployeeAttendance(dateHired, dateReleased, empId, empName, daysInPeriod, daysOffInPeriod, seq)
                    seq = seq + 1
                End If
                'For Each employeeEarning In employeeEarnings

                'Next
            Next
            If _reinitialize Then
                Dim i As Int16 = 1
                For Each item In View.PayrollAttendance
                    item.Sequence = i
                    i = i + 1
                Next
            End If
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

        Public Sub InitializeOvertime()
            Dim payFrequency = GetFieldWithIdNo(View.PayCycleIdNo, "PayCycle", "PayFrequency")
            Dim employeeFilter = "PayCycleIdNo = " & View.PayCycleIdNo.ToString()
            Dim matchedEmployees = GetFilteredRecords("Employee", "EmployeeName", employeeFilter, {"IdNo", "HiredDate", "ReleasedDate"})
            Dim numberOfEmployees = Int(matchedEmployees.Count() / 3)
            Dim seq As Int16
            Dim dateHired As Date
            Dim dateReleased As Date?
            Dim empId As Int32
            Dim empFound As Boolean = False
            seq = View.PayrollOvertime.Count() + 1
            If View.PayrollOvertime.Any() Then
                _reinitialize = True
            Else
                _reinitialize = False
            End If
            For i = 1 To numberOfEmployees
                empId = matchedEmployees(i * 3 - 3)
                dateHired = matchedEmployees(i * 3 - 2)
                dateReleased = IIf(IsDBNull(matchedEmployees(i * 3 - 1)), Nothing, matchedEmployees(i * 3 - 1))
                If _reinitialize Then
                    Dim empOvertime As OtWorkHourView
                    empOvertime = View.PayrollOvertime.Find(Function(c) c.EmployeeIdNo = empId)
                    If empOvertime Is Nothing Then
                        empFound = False
                    Else
                        empFound = True
                        If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
                            ' retain old data
                        Else
                            View.PayrollOvertime.Remove(empOvertime)
                        End If
                    End If
                End If
                If empFound Then
                    Continue For
                End If
                If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
                    AddEmployeeOvertime(dateHired, dateReleased, empId, seq)
                    seq = seq + 1
                End If
            Next
            If _reinitialize Then
                Dim i As Int16 = 1
                For Each item In View.PayrollOvertime
                    item.Sequence = i
                    i = i + 1
                Next
            End If
        End Sub

        Public Sub AddEmployeeAttendance(ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal empId As Int16, ByVal empName As String, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16, ByVal seq As Int16)
            Dim empAttendance As New AttendanceItemView
            Dim daysOff As Int16
            Dim daysTotal As Int16
            ComputeTotalDaysNOff(daysTotal, daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
            empAttendance.DaysTotal = daysTotal
            empAttendance.DaysOff = daysOff
            empAttendance.DaysPresent = daysTotal - daysOff
            empAttendance.PayrollIdNo = View.IdNo
            empAttendance.EmployeeIdNo = empId
            empAttendance.EmployeeName = empName
            empAttendance.Sequence = seq
            View.PayrollAttendance.Add(empAttendance)
        End Sub

        Public Sub AddEmployeeOvertime(ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal empId As Int16, ByVal seq As Int16)
            Dim empOvertime As New OtWorkHourView
            empOvertime.EmployeeIdNo = empId
            empOvertime.Sequence = seq
            View.PayrollOvertime.Add(empOvertime)
        End Sub

        Public Sub UpdateEmployeeAttendance(ByRef empAttendance As AttendanceItemView, ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16)
            Dim daysOff As Int16
            Dim daysTotal As Int16
            ComputeTotalDaysNOff(daysTotal, daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
            empAttendance.DaysTotal = daysTotal
            empAttendance.DaysOff = daysOff
        End Sub

        Private Sub ComputeTotalDaysNOff(ByRef daysTotal As Int16, ByRef daysOff As Int16, ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16)
            Dim eDate As Date
            If dateHired <= View.StartDate AndAlso (dateReleased Is Nothing OrElse dateReleased > View.EndDate) Then
                daysOff = daysOffInPeriod
                daysTotal = daysInPeriod
            Else
                If dateReleased Is Nothing OrElse dateReleased > View.EndDate Then
                    eDate = View.EndDate
                Else
                    Dim dDate As Date ' need to do this because Date? type is not accepted by DateAdd function
                    dDate = dateReleased
                    eDate = DateAndTime.DateAdd(DateInterval.Day, -1, dDate)
                End If
                daysTotal = DateDiff(DateInterval.Day, dateHired, eDate) + 1
                daysOff = FridaysInPeriod(dateHired, eDate)
            End If
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_attendanceItemModel, DtUpdateTable, DtInsertTable, passedValue, "PayrollIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_otWorkHourModel, DtOtUpdateTable, DtOtInsertTable, passedValue, "PayrollIdNo")
            End If
        End Sub

        Private Sub AttendanceItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("DaysAbsentWithoutPay") = itemDataView.DaysAbsentWithoutPay
            workRow("DaysAbsentWithPay") = itemDataView.DaysAbsentWithPay
            workRow("DaysOff") = itemDataView.DaysOff
            workRow("DaysPresent") = itemDataView.DaysPresent
            workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
            workRow("PayrollIdNo") = View.IdNo
        End Sub

        Public Function AttendanceItemFilter(ByVal obj As Object) As Boolean
            'If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
            '    Return False
            'End If
            Return True
        End Function

        Private Sub OtWorkHourFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
            workRow("OvertimeRegular") = itemDataView.OvertimeRegular
            workRow("OvertimeHoliday") = itemDataView.OvertimeHoliday
            workRow("OvertimeSpecial") = itemDataView.OvertimeSpecial
            workRow("PayrollIdNo") = View.IdNo
        End Sub

        Public Function OtWorkHourFilter(ByVal obj As Object) As Boolean
            If (obj.OvertimeRegular = 0 AndAlso obj.OvertimeHoliday = 0 AndAlso obj.OvertimeSpecial = 0) Then
                Return False
            End If
            Return True
        End Function

        Public Shared Function FridaysInPeriod(ByVal begDate As Date, endDate As Date) As Integer
            Dim count As Integer
            Dim d As DateTime = begDate
            Do Until d = endDate
                If d.DayOfWeek = DayOfWeek.Friday Then
                    count += 1
                End If
                d = d.AddDays(1)
            Loop
            Return count
        End Function

        'Public Sub New(view As IPayrollView)
        '    MyBase.New(view)
        '    TableName = "Account"
        '    ModelPresenter = New ModelAccounts("Payroll")
        '    TableName = "Payroll"
        '    SortOrderKey = "IdNo"
        '    OriginalModel = New PayrollModel()
        '    DataModel = New PayrollModel()
        '    CreateDataTable(_dtPayrollPayElementInsertTable, {{"Amount", GetType(Decimal)},
        '                                     {"EarningIdNo", GetType(Int16)},
        '                                     {"EmployeeIdNo", GetType(Int32)},
        '                                     {"PayrollIdNo", GetType(Int16)}
        '                                    })
        '    CreateDataTable(_dtPayrollPayElementUpdateTable, {{"Amount", GetType(Decimal)},
        '                                     {"EarningIdNo", GetType(Int16)},
        '                                     {"EmployeeIdNo", GetType(Int32)},
        '                                     {"IdNo", GetType(Int32)},
        '                                     {"PayrollIdNo", GetType(Int16)}
        '                                    })

        '    CreateDataTable(_dtPayrollDetailInsertTable, {{"EmployeeIdNo", GetType(Int32)},
        '                                                  {"PayrollIdNo", GetType(Int16)}
        '                                                 })

        '    CreateDataTable(_dtPayrollDetailUpdateTable, {{"EmployeeIdNo", GetType(Int32)},
        '                                                  {"IdNo", GetType(Int32)},
        '                                                  {"PayrollIdNo", GetType(Int16)}
        '                                                 })

        '    '_absenceDeductions = New List(Of Deduction)
        '    'Dim absencesDeductions = _deductionsDao.GetRecords("DeductionType = '" & EnumToCode(DeductionTypeSelection.Computed) & "' and QuantityType = '" & EnumToCode(AttendanceUnitSelection.OvertimeSpecial) & "'")
        '    'GlobalVariables.Mapper.Map(absencesDeductions, _absenceDeductions)
        '    _deductionComputationMethod = GetAppSetting($"PYCM", "Payroll", "Deduction Computation Method")

        'End Sub

        Public Sub GeneratePayroll(progressBar As ProgressBar)
            'Dim attendance As List(Of AttendanceItem)
            'Dim otWorkHours As List(Of OtWorkHour)
            'attendance = _attendanceItemDao.GetRecordsWithGroupIdNo(payrollIdNo)
            'otWorkHours = _otWorkHoursDao.GetRecordsWithGroupIdNo(payrollIdNo)
            'GlobalVariables.Mapper.Map(attendance, _attendance)
            'GlobalVariables.Mapper.Map(otWorkHours, _otWorkHours)
            If View.PayrollAttendance.Count() = 0 And View.PayrollOvertime.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendanceOt")
            Else
                Dim payroll As Payroll = _payrollDao.GetRecordByIdNo(View.IdNo)
                Dim payFrequency = _payCycleDao.GetRecordByIdNo(payroll.PayCycleIdNo).PayFrequency
                Dim payrollPayElements As List(Of PayrollPayElement)
                _payFrequency = CodeToEnum(Of PayFrequencySelection)(payFrequency)
                If _payFrequency = PayFrequencySelection.Monthly Then
                    _daysInTheMonth = DateTime.DaysInMonth(Year(View.EndDate), Month(View.EndDate))
                    payrollPayElements = _payrollPayElementsDao.GetRecordsWithGroupIdNo(View.IdNo)
                    If payrollPayElements.Count() = 0 Then
                        InitializeEmployeePayroll(False, progressBar)
                    Else
                        If Messaging.Show(True, "AskIfRegeneratePayroll",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            InitializeEmployeePayroll(True, progressBar)
                            'Dim payAbsencesDeductions = _payrollDeductionDao.GetRecordsWithGroupIdNo(payrollIdNo)
                            'ReGenerateEmployeePayroll(progressBar)
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub InitializeEmployeePayroll(ByRef regenerate As Boolean, progressBar As ProgressBar)
            _dtPayrollPayElementInsertTable.Clear()
            _dtPayrollDetailInsertTable.Clear()
            Dim payrollDetails As List(Of PayrollDetailModel)
            payrollDetails = CreatePayrollDetails()
            Dim computedEarnings As List(Of PayElement)
            computedEarnings = _payElementsDao.GetRecords("PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) &
                                                          "' and PayElementType = '" & EnumToCode(PayElementTypeSelection.Computed) &
                                                          "' and Summary=0")
            GlobalVariables.Mapper.Map(computedEarnings, _computedEarnings)
            Dim globalEarnings As List(Of PayElement)
            globalEarnings = _payElementsDao.GetRecords("PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) &
                                                        "' and CalculationType = '" & EnumToCode(PayElementTypeSelection.Global) &
                                                        "' and not Summary=0")
            GlobalVariables.Mapper.Map(globalEarnings, _globalEarnings)
            progressBar.Value = 0
            progressBar.Maximum = payrollDetails.Count() + 2
            progressBar.Visible = True
            If regenerate Then
                _savedPayrollPayElements = _payrollPayElementsDao.GetRecordsWithGroupIdNo(_payrollIdNo)
            End If
            For Each payrollDetail In payrollDetails
                GenerateRegularEarnings(regenerate, payrollDetail.EmployeeIdNo)
                GenerateComputedEarnings(regenerate, payrollDetail.EmployeeIdNo)
                GenerateGlobalEarnings(regenerate, payrollDetail.EmployeeIdNo)
            Next

            'GenerateRegularDeductions(attendance.EmployeeIdNo, payrollIdNo)
            'GenerateAbsencesDeductions(employeeAttendance.EmployeeIdNo, payrollIdNo, employeeAttendance.DaysAbsentWithoutPay)
            'progressBar.Value = progressBar.Value + 1

            '_payrollPayElementDao.InsertTvp(_dtPayrollPayElementInsertTable)
            'progressBar.Value = progressBar.Value + 1
            '_payrollDeductionDao.InsertTvp(_dtDeductionInsertTable)
            progressBar.Value = progressBar.Value + 1
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
            progressBar.Visible = False
        End Sub

        Private Sub GenerateRegularEarnings(regenerate As Boolean, employeeIdNo As Int32)
            Dim empEarnings As New List(Of EmployeeEarning)
            empEarnings = _employeeEarningsDao.GetRecordsWithGroupIdNo(employeeIdNo)
            Dim empEarningsModel As New List(Of EmployeeEarningModel)
            GlobalVariables.Mapper.Map(empEarnings, empEarningsModel)
            Dim amount As Decimal
            For Each empEarning In empEarningsModel
                Dim earning As PayElement
                Dim earningModel As PayElementModel
                earning = _payElementsDao.GetRecordByIdNo(empEarning.EarningIdNo)
                GlobalVariables.Mapper.Map(earning, earningModel)
                If earning.CalculationType = EnumToCode(CalculationTypeSelection.FixedAmount) Then
                    amount = ComputeFixedAmountEarning(empEarning.Amount, empEarning.Unit)
                    If Not regenerate Then
                        AddEarning(employeeIdNo, amount, earning.IdNo, 0)
                    Else
                        MakeEarning(employeeIdNo, amount, earning.IdNo)
                    End If
                ElseIf earning.CalculationType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                    Dim rate As Decimal = ComputeFixedAmountEarning(empEarning.Amount, earning.Unit)
                    Dim qty As Decimal = ComputeQuantity(empEarning.EmployeeIdNo, earning.QuantityType)
                    amount = rate * qty
                    If Not regenerate Then
                        AddEarning(employeeIdNo, amount, earning.IdNo, 0)
                    Else
                        MakeEarning(employeeIdNo, amount, earning.IdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub AddEarning(employeeIdNo As Int32, amount As Decimal, earningIdNo As Short, payrollPayEarningIdNo As Int16)
            If amount <> 0 Then
                Dim payrollPayElement As New PayrollPayElementModel
                payrollPayElement.Amount = Math.Round(amount, 2)
                payrollPayElement.PayrollIdNo = _payrollIdNo
                payrollPayElement.PayElementIdNo = earningIdNo
                payrollPayElement.EmployeeIdNo = employeeIdNo
                payrollPayElement.IdNo = payrollPayEarningIdNo
                _payrollPayElements.Add(payrollPayElement)
            End If
        End Sub

        Private Sub MakeEarning(employeeIdNo As Int32, amount As Decimal, earningIdNo As Int16)
            If amount <> 0 Then
                Dim earning As PayrollPayElementModel = _payrollPayElements.Find(Function(value As PayrollPayElementModel)
                                                                                     Return value.EmployeeIdNo = employeeIdNo And value.PayElementIdNo = earningIdNo
                                                                                 End Function)
                If earning Is Nothing Then
                    AddEarning(employeeIdNo, amount, earningIdNo, 0)
                Else
                    AddEarning(employeeIdNo, amount, earning.IdNo, earning.IdNo)
                End If
            End If
        End Sub

        Private Sub AddToGeneratedPayroll(employeeIdNo As Int32, amount As Decimal, earningIdNo As Short, earning As PayrollPayElementModel)
            Dim payrollPayElement As New PayrollPayElementModel
            payrollPayElement.Amount = Math.Round(amount, 2)
            payrollPayElement.PayrollIdNo = _payrollIdNo
            payrollPayElement.PayElementIdNo = earningIdNo
            payrollPayElement.EmployeeIdNo = employeeIdNo
            If earning IsNot Nothing Then
                payrollPayElement.IdNo = earning.IdNo
            End If
            _payrollPayElements.Add(payrollPayElement)
        End Sub

        Private Sub GenerateComputedEarnings(regenerate As Boolean, employeeIdNo As Int32)
            For Each earning As PayElementModel In _computedEarnings
                Dim amount As Decimal
                amount = CalculateComputedEarning(employeeIdNo, earning)
                If Not regenerate Then
                    AddEarning(employeeIdNo, amount, earning.IdNo, 0)
                Else
                    MakeEarning(employeeIdNo, amount, earning.IdNo)
                End If
            Next
        End Sub

        Private Sub GenerateGlobalEarnings(regenerate As Boolean, employeeIdNo As Int32)
            For Each earning As PayElementModel In _globalEarnings
                If Not regenerate Then
                    AddEarning(employeeIdNo, earning.Rate, earning.IdNo, 0)
                Else
                    MakeEarning(employeeIdNo, earning.Rate, earning.IdNo)
                End If
            Next
        End Sub

        Private Function CalculateComputedEarning(employeeIdNo As Int32, earning As PayElementModel) As Decimal
            Dim amount As Decimal
            If earning.CalculationType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                Dim rate As Decimal
                Dim payElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = earning.IdNo)
                If payElementModel IsNot Nothing Then
                    rate = ComputeFixedAmountEarning(payElementModel.Amount, earning.Unit)
                    Dim qty As Decimal = ComputeQuantity(employeeIdNo, earning.Unit)
                Else
                    amount = 0
                End If
            ElseIf earning.CalculationType = EnumToCode(CalculationTypeSelection.Factor) Then
                Dim bpEarning = _payElementsDao.GetRecordByIdNo(earning.BasePaymentIdNo)
                If bpEarning.Summary Then
                    amount = ComputeSummaryAmount(employeeIdNo, earning.BasePaymentIdNo)
                Else
                    Dim bpPayElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = earning.IdNo)
                    If bpPayElementModel IsNot Nothing Then
                        amount = ComputeFactoredAmount(bpPayElementModel.Amount, earning.FactorValue, earning.FactorType)
                    End If
                End If
            End If
            Return amount
        End Function

        Private Shared Function ComputeFactoredAmount(amount As Decimal, FactorValue As Decimal, FactorType As String)
            Dim factoredAmount As Decimal
            If FactorType = EnumToCode(FactorTypeSelection.PercentOfBasePaymentRate) Then
                factoredAmount = amount * FactorValue * 0.01D
            ElseIf FactorType = EnumToCode(FactorTypeSelection.MultiplyBasePaymentRate) Then
                factoredAmount = amount * FactorValue
            ElseIf FactorType = EnumToCode(FactorTypeSelection.DivideBasePaymentRate) Then
                If FactorValue <> 0 Then
                    factoredAmount = amount / FactorValue
                End If
            End If
            Return factoredAmount
        End Function

        Private Function ComputeSummaryAmount(employeeIdNo As Int32, earningIdNo As Int16) As Decimal
            Dim summaryAmount As Decimal
            Dim payElementItems As List(Of PayElementItem) = _payElementItemsDao.GetRecordsWithGroupIdNo(earningIdNo)
            For Each payElementItem As PayElementItem In payElementItems
                Dim payElement As PayElement = _payElementsDao.GetRecordByIdNo(payElementItem.PayElementIdNo)
                Dim amount As Decimal = 0
                If Not payElement.Summary Then
                    Dim empEarning As PayrollPayElementModel
                    empEarning = _payrollPayElements.Find(Function(e As PayrollPayElementModel) e.EmployeeIdNo = employeeIdNo And e.PayElementIdNo = payElementItem.PayElementIdNo)
                    If empEarning IsNot Nothing Then
                        amount = empEarning.Amount
                    End If
                Else
                    amount = ComputeSummaryAmount(employeeIdNo, payElementItem.PayElementIdNo)
                End If
                summaryAmount += ComputeSummaryItemAmount(amount, payElementItem.FactorValue, payElementItem.FactorType)
            Next
            Return summaryAmount
        End Function

        Private Shared Function ComputeSummaryItemAmount(amount As Decimal, FactorValue As Decimal, FactorType As String)
            Dim factoredAmount As Decimal
            If FactorType = EnumToCode(FactorTypeSelection.PercentOfBasePaymentRate) Then
                factoredAmount = amount * FactorValue * 0.01D
            ElseIf FactorType = EnumToCode(FactorTypeSelection.MultiplyBasePaymentRate) Then
                factoredAmount = amount * FactorValue
            ElseIf FactorType = EnumToCode(FactorTypeSelection.DivideBasePaymentRate) Then
                If FactorValue <> 0 Then
                    factoredAmount = amount / FactorValue
                End If
            End If
            Return factoredAmount
        End Function

        Private Function ComputeDeductionAmount(deduction As Deduction, daysAbsentWithoutPay As Decimal, basePayment As EmployeeEarning) As Decimal
            Dim daysToCompute As Decimal
            Dim amount As Decimal
            If _deductionComputationMethod = "DaysInMonth" Then
                daysToCompute = daysAbsentWithoutPay
                amount = Math.Round(basePayment.Amount / _daysInTheMonth * daysToCompute, 2)
            ElseIf _deductionComputationMethod = "30Days" Then
                If daysAbsentWithoutPay <= 15D Then
                    daysToCompute = daysAbsentWithoutPay
                Else
                    daysToCompute = 30D - (CDec(DateTime.DaysInMonth(Year(_endDate), Month(_endDate))) - daysAbsentWithoutPay)
                End If
                amount = Math.Round(basePayment.Amount / 30D * daysToCompute, 2)
            End If
            Return amount
        End Function

        Private Function CreatePayrollDetails()
            Dim payrollDetails As New List(Of PayrollDetailModel)
            For Each employeeAttendance In View.PayrollAttendance
                Dim payrollDetail As New PayrollDetailModel
                payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo
                payrollDetail.PayrollIdNo = View.IdNo
                payrollDetails.Add(payrollDetail)
            Next
            For Each employeeAttendance In View.PayrollOvertime
                Dim payrollDetail = payrollDetails.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
                If payrollDetail Is Nothing Then
                    payrollDetails.Add(payrollDetail)
                End If
            Next
            Return payrollDetails
        End Function

        Private Function ComputeFixedAmountEarning(amount As Decimal, unit As String) As Decimal
            Dim factor As Decimal
            Select Case _payFrequency
                Case PayFrequencySelection.Monthly
                    If unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 1D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 12D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 6D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 3D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 13D / 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 30D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D / 6D
                    End If
                Case PayFrequencySelection.Yearly
                    If unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 12D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 24D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 4D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 52D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 365D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 26D
                    End If
                Case PayFrequencySelection.SemiYearly
                    If unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 6D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 12D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 26D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 365D / 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D
                    End If
                Case PayFrequencySelection.Quarterly
                    If unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 3D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 6D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 4D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 13D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 365D / 4D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D / 2D
                    End If
                Case PayFrequencySelection.SemiMonthly
                    If unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 1D / 2D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 1D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 24D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 12D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 6D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 13D / 4D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 15D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D / 12D
                    End If
                Case PayFrequencySelection.Weekly
                    If unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 12D / 52D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 24D / 52D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 52D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 26D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 13D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 1D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 7D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 1D / 2D
                    End If
                Case PayFrequencySelection.Daily
                    If unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 1D / 30D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 1D / 15D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 360D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 180D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 90D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 1D / 7D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 1D
                    ElseIf unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 1D / 14D
                    End If

            End Select
            Return amount * factor
        End Function

        Private Function ComputeQuantity(employeeIdNo As Int32, quantityType As String)
            Dim quantity As Decimal
            If quantityType = EnumToCode(QuantityTypeSelection.HoursWorked) Then
                quantity = _otWorkHoursDao.GetRecord("EmployeeIdNo = " & employeeIdNo.ToString() & " PayrollIdNo = " & _payrollIdNo)
            End If
            Return quantity
        End Function

        Private Sub MakePayrollOt(payrollIdNo As Short, otHours As Decimal, otUnit As String, otRate As Decimal, otEarning As Earning, employeeIdNo As Integer)
            Dim otAmount As Decimal = ComputeOtAmount(otEarning, otHours, otRate)
            AddEarning(employeeIdNo, otAmount, payrollIdNo, otEarning.IdNo)
        End Sub

        Private Shared Function ComputeOtAmount(otEarning As Earning, otHours As Decimal, otRate As Decimal) As Decimal
            Dim otAmount As Decimal
            If otEarning IsNot Nothing Then
                otAmount = otHours * IIf(IsDBNull(otRate), 0, otRate)
            Else
                otAmount = otHours * IIf(IsDBNull(otEarning.Rate), 0, otEarning.Rate)
            End If
            Return otAmount
        End Function

    End Class

End Namespace