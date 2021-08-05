Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Presenters
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class PayrollPresenter(Of TM As New)
        Inherits PresenterNew(Of IPayrollView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected DtOtInsertTable As New DataTable
        Protected DtOtUpdateTable As New DataTable
        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        Private _attendanceItemService As New AccountsService("AttendanceItem")
        Private _otWorkHourService As New AccountsService("OtWorkHour")
        Private _reinitialize As Boolean = False
        Private _payrollEarning
        Private _payrollPayElements As New List(Of PayrollPayElementModel)
        Private _savedPayrollPayElements As New List(Of PayrollPayElementModel)
        Private _computedPayElements As New List(Of PayElementModel)
        Private _globalEarnings As New List(Of PayElementModel)
        Private _otWorkHoursModel As New List(Of OtWorkHour)

        Private _daysInTheMonth As Int16
        Private _endDate As Date
        Private _payFrequency As PayFrequencySelection
        Private _payrollIdNo As Int16

        Private ReadOnly _deductionComputationMethod As String = "1"
        Private ReadOnly _dtPayrollDetailInsertTable As New DataTable
        Private ReadOnly _dtPayrollDetailUpdateTable As New DataTable

        Private ReadOnly _payCycleService As New AccountsService("PayCycle")
        Private ReadOnly _payElementsService As New AccountsService("PayElement")
        Private ReadOnly _payElementItemsService As New AccountsService("PayElementItem")
        Private ReadOnly _payrollDetailsService As New AccountsService("PayrollDetail")
        Private ReadOnly _payrollPayElementsService As New AccountsService("PayrollPayElement")

        Private ReadOnly _computedPayElementType = EnumToCode(PayElementTypeSelection.Computed)

        Private ReadOnly _regularType = EnumToCode(PayElementTypeSelection.Regular)
        Private ReadOnly _globalType = EnumToCode(PayElementTypeSelection.Global)
        Private ReadOnly _computedType = EnumToCode(PayElementTypeSelection.Computed)
        Private ReadOnly _onDemandType = EnumToCode(PayElementTypeSelection.OnDemand)
        Private ReadOnly _factorType = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _fixedAmountType = EnumToCode(CalculationTypeSelection.FixedAmount)
        Private ReadOnly _fixedRateType = EnumToCode(CalculationTypeSelection.FixedRate)
        Private ReadOnly _variableType = EnumToCode(CalculationTypeSelection.Variable)
        Private ReadOnly _daysOffType = EnumToCode(QuantityTypeSelection.DaysOff)
        Private ReadOnly _daysPresentType = EnumToCode(QuantityTypeSelection.DaysPresent)
        Private ReadOnly _daysLeaveWithoutPayType = EnumToCode(QuantityTypeSelection.DaysLeaveWithoutPay)
        Private ReadOnly _daysPaidType = EnumToCode(QuantityTypeSelection.DaysPaid)
        Private ReadOnly _overtimeRegularType = EnumToCode(QuantityTypeSelection.OvertimeRegular)
        Private ReadOnly _overtimeHolidayType = EnumToCode(QuantityTypeSelection.OvertimeHoliday)
        Private ReadOnly _overTimeSpecialType = EnumToCode(QuantityTypeSelection.OvertimeSpecial)
        Private ReadOnly _hoursWorkedType = EnumToCode(QuantityTypeSelection.HoursWorked)
        Private ReadOnly _daysLeaveWithPayType = EnumToCode(QuantityTypeSelection.DaysLeaveWithPay)
        Private ReadOnly _payElementType = EnumToCode(PayElementKindSelection.Earning)
        Private ReadOnly _deductionType = EnumToCode(PayElementKindSelection.Deduction)
        Private ReadOnly _factorPercentType = EnumToCode(FactorTypeSelection.PercentOfBasePaymentRate)
        Private ReadOnly _factorMultiplyType = EnumToCode(FactorTypeSelection.MultiplyBasePaymentRate)
        Private ReadOnly _factorDivideType = EnumToCode(FactorTypeSelection.DivideBasePaymentRate)
        Private ReadOnly ServiceAccounts
        Private _roundToWholeNumber As Boolean = True

        Public Sub New(view As IPayrollView)
            MyBase.New(view)
            Service = New AccountsService("Payroll")
            TreeViewMainField = "PayrollName"
            TreeViewSecondaryField = "PayrollCode"
            TableName = "Payroll"
            SortOrderKey = "EndDate"

            '_attendanceItemService = New AccountsService("AttendanceItem", Nothing, Nothing)
            '_otWorkHourService = New AccountsService("OtWorkHour", Nothing, Nothing)

            AddHandler view.InitializeAttendance, AddressOf InitializeAttendance
            AddHandler view.InitializeOvertime, AddressOf InitializeOvertime
            AddHandler view.GenerateRegularPayElements, AddressOf GenerateRegularPayElements

            CreateDataTable(DtInsertTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"PayrollIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                           })

            CreateDataTable(DtUpdateTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"PayrollIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                           })

            CreateDataTable(DtOtInsertTable, {{"EmployeeIdNo", GetType(Int32)},
                                            {"HoursWorked", GetType(Decimal)},
                                            {"OvertimeHoliday", GetType(Decimal)},
                                            {"OvertimeRegular", GetType(Decimal)},
                                            {"OvertimeSpecial", GetType(Decimal)},
                                            {"PayrollIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                           })

            CreateDataTable(DtOtUpdateTable, {{"EmployeeIdNo", GetType(Int32)},
                                            {"HoursWorked", GetType(Decimal)},
                                            {"IdNo", GetType(Int32)},
                                            {"OvertimeHoliday", GetType(Decimal)},
                                            {"OvertimeRegular", GetType(Decimal)},
                                            {"OvertimeSpecial", GetType(Decimal)},
                                            {"PayrollIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                           })

            'CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            '                                {"EarningIdNo", GetType(Int16)},
            '                                {"EmployeeIdNo", GetType(Int32)},
            '                                {"PayrollIdNo", GetType(Int16)}
            '                               })

            'CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            '                                {"EarningIdNo", GetType(Int16)},
            '                                {"EmployeeIdNo", GetType(Int32)},
            '                                {"IdNo", GetType(Int32)},
            '                                {"PayrollIdNo", GetType(Int16)}
            '                               })

        End Sub

        Public Sub InitializeMonthlyPayroll(payCycleRecord As PayCycleModel)
            If View.StartDate = Nothing And View.EndDate = Nothing Then
                If payCycleRecord.PayCycleCode = "Month" Then
                    Dim nIdNoMax As Int32
                    Dim maxRecord As PayrollModel
                    Dim payMonthText As String = "Payroll for the Month of"
                    Dim PayrollText As String = "Payroll for the Period"
                    nIdNoMax = Service.GetFieldOnMaxField("EndDate", "Payroll", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
                    maxRecord = Service.GetRecordByIdNo(Of PayrollModel)(nIdNoMax)
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

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            Dim nIdNoMax As Int32
            Dim maxRecord As PayrollModel
            Dim payMonthText As String = "Payroll for the Month of"
            Dim PayrollText As String = "Payroll for the Period"
            nIdNoMax = Service.GetFieldOnMaxField("EndDate", "Payroll", "IdNo", "PayCycleIdNo = 1") ' + View.PayCycleIdNo.ToString())
            If nIdNoMax = 0 Then
                Dim now As Date = Today()
                View.EndDate = DateAdd(DateInterval.Day, DateAndTime.Day(now) * -1, now)
                View.StartDate = DateAdd(DateInterval.Day, DateAndTime.Day(View.EndDate) * -1 + 1, View.EndDate)
            Else
                maxRecord = Service.GetRecordByIdNo(Of PayrollModel)(nIdNoMax)
                View.StartDate = maxRecord.EndDate.AddDays(1)
                If View.StartDate.Day = 1 Then
                    View.EndDate = View.StartDate.AddMonths(1).AddDays(-1)
                Else
                    View.EndDate = maxRecord.EndDate.AddMonths(1)
                End If
            End If
            View.PayCycleIdNo = 1
            Dim arabicCulture As New CultureInfo("ar-ae", False)
            If View.StartDate.Day = 1 AndAlso DateAdd(DateInterval.Day, DateAndTime.Day(View.EndDate) * -1 + 1, View.EndDate) = View.StartDate Then
                View.PayrollName = payMonthText & " " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                View.PayrollNameAra = Messaging.TranslateCaption(payMonthText, "ar-SA") + GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate) - 1) & " " & Year(View.EndDate).ToString()
            Else
                View.PayrollName = PayrollText & " " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
                View.PayrollNameAra = Messaging.TranslateCaption(PayrollText, "ar-SA") & " " & GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
            End If
            View.PayrollCode = "M" + View.EndDate.ToString("yyMM")
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PayrollAttendance, DtInsertTable, DtUpdateTable, AddressOf AttendanceItemFillData, AddressOf AttendanceItemFilter, "IdNo")
                ViewToDataTables(View.PayrollOvertime, DtOtInsertTable, DtOtUpdateTable, AddressOf OtWorkHourFillData, AddressOf OtWorkHourFilter, "IdNo")
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
            View.PayFrequency = GetFieldWithIdNo(View.PayCycleIdNo, "PayCycle", "PayFrequency")
            Dim employeeFilter = "PayCycleIdNo = " & View.PayCycleIdNo.ToString() & " And Active = 1"
            Dim activeEmployees = GetRecords("Employee", "EmployeeName", {"IdNo", "EmployeeName", "HiredDate", "ReleasedDate"}, employeeFilter)
            'Dim earningDao = New EarningDao
            'Dim earnings = earningDao.GetAll()
            Dim numberOfEmployees = Int(activeEmployees.Count() / 4)
            Dim daysInPeriod As Int16
            Dim daysOffInPeriod As Int16
            Dim seq As Integer
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
            Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
            Dim counter As Integer = 0
            progressDisplayForm.Show()
            progressDisplayForm.InitializeDisplay(numberOfEmployees)
            For i = 1 To numberOfEmployees
                empId = activeEmployees(i * 4 - 4)
                empName = activeEmployees(i * 4 - 3)
                dateHired = activeEmployees(i * 4 - 2)
                dateReleased = IIf(IsDBNull(activeEmployees(i * 4 - 1)), Nothing, activeEmployees(i * 4 - 1))
                'If empId = 498 Then
                '    Debugger.Break()
                'End If

                If _reinitialize Then
                    Dim empAttendance As AttendanceItemView
                    empAttendance = View.PayrollAttendance.Find(Function(c) c.EmployeeIdNo = empId)
                    If empAttendance Is Nothing Then
                        empFound = False
                    Else
                        empFound = True
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
                counter = counter + 1
                progressDisplayForm.UpdateProgressBar(counter)
            Next
            If _reinitialize Then
                Dim i As Int16 = 1
                For Each item In View.PayrollAttendance
                    item.Sequence = i
                    i = i + 1
                Next
            End If
            progressDisplayForm.UpdateProgressBar(counter)
            progressDisplayForm.Close()
            Messaging.Show(True, "MsgAttendanceInitializationCompleted")
        End Sub

        Public Sub InitializeOvertime()
            View.PayFrequency = GetFieldWithIdNo(View.PayCycleIdNo, "PayCycle", "PayFrequency")
            Dim employeeFilter = "PayCycleIdNo = " & View.PayCycleIdNo.ToString()
            Dim matchedEmployees = GetRecords("Employee", "EmployeeName", {"IdNo", "HiredDate", "ReleasedDate"}, employeeFilter)
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
            Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
            Dim counter As Integer = 0
            progressDisplayForm.Show()
            progressDisplayForm.InitializeDisplay(numberOfEmployees + 1)
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
                counter = counter + 1
                progressDisplayForm.UpdateProgressBar(counter)
            Next
            If _reinitialize Then
                Dim i As Int16 = 1
                For Each item In View.PayrollOvertime
                    item.Sequence = i
                    i = i + 1
                Next
            End If
            progressDisplayForm.UpdateProgressBar(counter + 1)
            progressDisplayForm.Close()
            Messaging.Show(True, "MsgOvertimeInitializationCompleted")
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
            retVal = UpdateChildData(_attendanceItemService, DtUpdateTable, DtInsertTable, passedValue, "PayrollIdNo")
            If retVal >= 0 Then
                retVal = UpdateChildData(_otWorkHourService, DtOtUpdateTable, DtOtInsertTable, passedValue, "PayrollIdNo")
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
            workRow("HoursWorked") = itemDataView.HoursWorked
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
        '    ModelOfPresenter = New ModelAccounts("Payroll")
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
        '    'Dim absencesDeductions = _deductionsDao.GetDaoRecords("DeductionType = '" & .Computed) & "' and QuantityType = '" & EnumToCode(AttendanceUnitSelection.OvertimeSpecial) & "'")
        '    'GlobalVariables.Mapper.Map(absencesDeductions, _absenceDeductions)
        '    _deductionComputationMethod = GetAppSetting($"PYCM", "Payroll", "Deduction Computation Method")

        'End Sub

        Public Sub GenerateRegularPayElements()
            _payrollIdNo = View.IdNo
            If View.PayrollAttendance.Count() = 0 And View.PayrollOvertime.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendanceOt")
            Else
                Dim payrollService As New AccountsService("Payroll")
                Dim payroll As PayrollModel = payrollService.GetRecordByIdNo(Of PayrollModel)(View.IdNo)
                View.PayFrequency = _payCycleService.GetRecordByIdNo(Of PayCycleModel)(payroll.PayCycleIdNo).PayFrequency
                Dim payrollPayElements As List(Of PayrollPayElement)
                _payFrequency = CodeToEnum(Of PayFrequencySelection)(View.PayFrequency)
                If _payFrequency = PayFrequencySelection.Monthly Then
                    _daysInTheMonth = DateTime.DaysInMonth(Year(View.EndDate), Month(View.EndDate))
                    payrollPayElements = _payrollPayElementsService.GetRecordsWithGroupIdNo(Of PayrollPayElement)(View.IdNo)
                    'GlobalVariables.Mapper.Map(payrollPayElements, _payrollPayElements)
                    If payrollPayElements.Count() = 0 Then
                        ProcessPayroll(False)
                    Else
                        If Messaging.Show(True, "AskIfRegeneratePayroll",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            ProcessPayroll(True)
                            'Dim payAbsencesDeductions = _payrollDeductionDao.GetRecordsWithGroupIdNo(payrollIdNo)
                            'ReGenerateEmployeePayroll(progressBar)
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub ProcessPayroll(ByRef regenerate As Boolean)
            Dim dtPayrollPayElementInsertTable As New DataTable
            Dim dtPayrollPayElementUpdateTable As New DataTable
            _payrollPayElements.Clear()
            CreateDataTable(dtPayrollPayElementInsertTable, {{"Amount", GetType(Decimal)},
                                                             {"PayElementIdNo", GetType(Int16)},
                                                             {"PayrollDetailIdNo", GetType(Int32)},
                                                             {"RecurringPayElementIdNo", GetType(Int32)}
                                                            })
            CreateDataTable(dtPayrollPayElementUpdateTable, {{"Amount", GetType(Decimal)},
                                             {"IdNo", GetType(Int32)},
                                             {"PayElementIdNo", GetType(Int16)},
                                             {"PayrollDetailIdNo", GetType(Int32)},
                                             {"RecurringPayElementIdNo", GetType(Int32)}
                                            })
            Dim dtPayrollDetailInsertTable As New DataTable
            Dim dtPayrollDetailUpdateTable As New DataTable
            CreateDataTable(dtPayrollDetailInsertTable, {
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
            CreateDataTable(dtPayrollDetailUpdateTable, {
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"IdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
            Dim payrollDetailsModel As List(Of PayrollDetailModel)
            payrollDetailsModel = CreatePayrollDetails()
            Dim computedEarnings As List(Of PayElement)
            computedEarnings = _payElementsService.GetDaoRecords("PayElementType = '" & _computedType & "' and Summary=0")
            GlobalVariables.Mapper.Map(computedEarnings, _computedPayElements)
            Dim globalEarnings As List(Of PayElement)
            globalEarnings = _payElementsService.GetDaoRecords("CalculationType = '" & _globalType & "' and not Summary=0")
            GlobalVariables.Mapper.Map(globalEarnings, _globalEarnings)
            Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
            Dim counter As Integer = 0
            progressDisplayForm.Show()
            progressDisplayForm.InitializeDisplay(payrollDetailsModel.Count() + 2)
            If regenerate Then
                Dim savedPayrollPayElements As List(Of PayrollPayElement) = _payrollPayElementsService.GetRecordsWithGroupIdNo(Of PayrollPayElement)(_payrollIdNo)
                GlobalVariables.Mapper.Map(savedPayrollPayElements, _savedPayrollPayElements)
            End If
            Dim otWorkHoursService As New AccountsService("OtWorkHour")
            Dim otWorkHours As List(Of OtWorkHour) = otWorkHoursService.GetRecordsWithGroupIdNo(Of OtWorkHour)(_payrollIdNo)
            GlobalVariables.Mapper.Map(otWorkHours, _otWorkHoursModel)
            Dim payrollDetailIdNo As Int32
            For Each payrollDetail In payrollDetailsModel
                If payrollDetail.IdNo = 0 Then
                    Dim dataRow As DataRow
                    dataRow = dtPayrollDetailInsertTable.NewRow()
                    dataRow("EmployeeIdNo") = payrollDetail.EmployeeIdNo
                    dataRow("PayrollIdNo") = View.IdNo
                    dtPayrollDetailInsertTable.Rows.Add(dataRow)
                Else
                    Dim dataRow As DataRow
                    dataRow = dtPayrollDetailUpdateTable.NewRow()
                    dataRow("IdNo") = payrollDetail.IdNo
                    dataRow("EmployeeIdNo") = payrollDetail.EmployeeIdNo
                    dataRow("PayrollIdNo") = payrollDetail.PayrollIdNo
                    dtPayrollDetailUpdateTable.Rows.Add(dataRow)
                End If
            Next
            _payrollDetailsService.UpdateInsertTvp(dtPayrollDetailUpdateTable, dtPayrollDetailInsertTable, View.IdNo)
            Dim payrollDetails As List(Of PayrollDetail)
            payrollDetails = _payrollDetailsService.GetRecordsWithGroupIdNo(Of PayrollDetail)(View.IdNo)
            GlobalVariables.Mapper.Map(payrollDetails, payrollDetailsModel)
            For Each payrollDetailModel In payrollDetailsModel
                Dim payrollDetail As New PayrollDetail
                GlobalVariables.Mapper.Map(payrollDetailModel, payrollDetail)
                If payrollDetail.IdNo = 0 Then
                    payrollDetailIdNo = _payrollDetailsService.AddRecord(payrollDetail)
                Else
                    payrollDetailIdNo = payrollDetail.IdNo
                End If
                GenerateRegularPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo)
                GenerateComputedPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo)
                GenerateGlobalPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo)
                GenerateRecurringPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo)
                counter = counter + 1
                progressDisplayForm.UpdateProgressBar(counter)
            Next
            If regenerate Then
                For Each item In _payrollPayElements
                    If item.IdNo = 0 Then
                        Dim dataRow As DataRow
                        dataRow = dtPayrollPayElementInsertTable.NewRow()
                        dataRow("Amount") = item.Amount
                        dataRow("PayElementIdNo") = item.PayElementIdNo
                        dataRow("PayrollDetailIdNo") = item.PayrollDetailIdNo
                        dataRow("RecurringPayElementIdNo") = item.RecurringPayElementIdNo
                        dtPayrollPayElementInsertTable.Rows.Add(dataRow)
                    Else
                        'If item.PayrollDetailIdNo = 1745 Then
                        '    Debugger.Break()
                        'End If
                        Dim dataRow As DataRow
                        dataRow = dtPayrollPayElementUpdateTable.NewRow()
                        dataRow("Amount") = item.Amount
                        dataRow("IdNo") = item.IdNo
                        dataRow("PayElementIdNo") = item.PayElementIdNo
                        dataRow("PayrollDetailIdNo") = item.PayrollDetailIdNo
                        dataRow("RecurringPayElementIdNo") = item.RecurringPayElementIdNo
                        dtPayrollPayElementUpdateTable.Rows.Add(dataRow)
                    End If
                Next
            Else
                For Each item In _payrollPayElements
                    Dim dataRow As DataRow
                    dataRow = dtPayrollPayElementInsertTable.NewRow()
                    dataRow("Amount") = item.Amount
                    dataRow("PayElementIdNo") = item.PayElementIdNo
                    dataRow("PayrollDetailIdNo") = item.PayrollDetailIdNo
                    dataRow("RecurringPayElementIdNo") = item.RecurringPayElementIdNo
                    dtPayrollPayElementInsertTable.Rows.Add(dataRow)
                Next
            End If
            counter = counter + 1
            If regenerate Then
                _payrollPayElementsService.UpdateInsertTvp(dtPayrollPayElementUpdateTable, dtPayrollPayElementInsertTable, _payrollIdNo)
                dtPayrollPayElementUpdateTable.Clear()
            Else
                _payrollPayElementsService.InsertTvp(dtPayrollPayElementInsertTable)
                dtPayrollPayElementInsertTable.Clear()
            End If
            _payrollPayElements.Clear()
            progressDisplayForm.UpdateProgressBar(counter + 1)
            progressDisplayForm.Close()
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
        End Sub

        Private Sub GenerateRegularPayElements(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32)
            Dim empPayElements As New List(Of EmployeePayElement)
            Dim employeePayElementsService As New AccountsService("EmployeePayElement")
            empPayElements = employeePayElementsService.GetRecordsWithGroupIdNo(Of EmployeePayElement)(employeeIdNo)
            Dim empPayElementsModel As New List(Of EmployeePayElementModel)
            GlobalVariables.Mapper.Map(empPayElements, empPayElementsModel)
            Dim amount As Decimal
            For Each empPayElement As EmployeePayElementModel In empPayElementsModel
                Dim payElement As New PayElementModel
                payElement = _payElementsService.GetRecordByIdNo(Of PayElementModel)(empPayElement.PayElementIdNo)
                If payElement.Active Then
                    Dim payElementModel As New PayElementModel
                    GlobalVariables.Mapper.Map(payElement, payElementModel)
                    If payElement.CalculationType = _fixedAmountType Then
                        amount = ComputePayAmount(_payFrequency, empPayElement.Amount, empPayElement.Unit)
                        If Not regenerate Then
                            AddPayElement(employeeIdNo, amount, payElement.IdNo, 0, payrollDetailIdNo, Nothing)
                        Else
                            UpdatePayElement(employeeIdNo, amount, payElement.IdNo, payrollDetailIdNo, Nothing)
                        End If
                    ElseIf payElement.CalculationType = _fixedRateType Then
                        Dim rate As Decimal = empPayElement.Rate
                        If rate <> 0 Then
                            Dim qty As Decimal
                            If payElement.QuantityType = _overtimeRegularType OrElse
                                payElement.QuantityType = _overtimeHolidayType OrElse
                                payElement.QuantityType = _overTimeSpecialType OrElse
                                payElement.QuantityType = _hoursWorkedType Then
                                qty = ComputeQuantity(empPayElement.EmployeeIdNo, payElement.QuantityType)
                            Else
                                qty = ComputeQuantity(empPayElement.EmployeeIdNo, payElement.QuantityType)
                            End If
                            amount = rate * qty
                            If Not regenerate Then
                                AddPayElement(employeeIdNo, amount, payElement.IdNo, 0, payrollDetailIdNo, Nothing)
                            Else
                                UpdatePayElement(employeeIdNo, amount, payElement.IdNo, payrollDetailIdNo, Nothing)
                            End If
                        End If
                    End If
                End If
            Next
        End Sub

        Private _recurringPayElements As New List(Of RecurringPayElement)
        Private ReadOnly _recurringPayElementService As New AccountsService("RecurringPayElement")

        Private Sub GenerateRecurringPayElements(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32)
            _recurringPayElements = _recurringPayElementService.GetDaoRecords("TotalAmount < Amount and StartDate <= '" + View.StartDate.ToString() + "' and EmployeeIdNo = " & employeeIdNo.ToString())
            If _recurringPayElements.Any Then
                Dim amount As Decimal
                For Each recurringPayElement As RecurringPayElement In _recurringPayElements
                    If recurringPayElement.TotalAmount < recurringPayElement.Amount Then
                        amount = Math.Min(recurringPayElement.Amount - recurringPayElement.TotalAmount, recurringPayElement.PeriodicPayment)
                        If Not regenerate Then
                            AddPayElement(employeeIdNo, amount, recurringPayElement.PayElementIdNo, 0, payrollDetailIdNo, recurringPayElement.IdNo)
                        Else
                            UpdatePayElement(employeeIdNo, amount, recurringPayElement.PayElementIdNo, payrollDetailIdNo, recurringPayElement.IdNo)
                        End If
                    End If
                Next
            End If
        End Sub

        Public Sub InitializePayroll(sender As Object)
            Dim payCycleRecord As PayCycleModel = _payCycleService.GetRecordByIdNo(Of PayCycleModel)(View.PayCycleIdNo)
            If payCycleRecord IsNot Nothing Then
                'View.PayFrequency = CodeToEnum(Of PayFrequencySelection)(payCycleRecord.PayFrequency)
                If AddMode Then
                    If CodeToEnum(Of PayFrequencySelection)(View.PayFrequency) = PayFrequencySelection.Monthly Then
                        InitializeMonthlyPayroll(payCycleRecord)
                    End If
                End If
            End If
        End Sub

        'Private Sub GenerateRegularDeductions(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32)
        '    Dim empDeductions As New List(Of EmployeePayElement)
        '    empDeductions = _employeePayElementsService.GetRecordsWithGroupIdNo(employeeIdNo)
        '    Dim EmpDeductionsModel As New List(Of EmployeePayElementModel)
        '    GlobalVariables.Mapper.Map(empDeductions, EmpDeductionsModel)
        '    Dim amount As Decimal
        '    For Each empDeduction As EmployeePayElementModel In EmpDeductionsModel
        '        Dim Deduction As New PayElement
        '        Dim DeductionModel As New PayElementModel
        '        'If empDeduction.EmployeeIdNo = 323 Then
        '        '    Debugger.Break()
        '        'End If
        '        Deduction = _payElementsDao.GetRecordByIdNo(empDeduction.PayElementIdNo)
        '        GlobalVariables.Mapper.Map(Deduction, DeductionModel)
        '        If Deduction.CalculationType = _fixedAmountType Then
        '            amount = ComputeFixedAmount(empDeduction.Amount, empDeduction.Unit)
        '            If Not regenerate Then
        '                AddPayElement(employeeIdNo, amount, Deduction.IdNo, 0, payrollDetailIdNo)
        '            Else
        '                UpdatePayElement(employeeIdNo, amount, Deduction.IdNo, payrollDetailIdNo)
        '            End If
        '        ElseIf Deduction.CalculationType = _fixedRateType Then
        '            Dim rate As Decimal = empDeduction.Rate
        '            If rate <> 0 Then
        '                Dim qty As Decimal
        '                If Deduction.QuantityType = _overtimeRegularType OrElse
        '                    Deduction.QuantityType = _overtimeHolidayType OrElse
        '                    Deduction.QuantityType = _overTimeSpecialType OrElse
        '                    Deduction.QuantityType = _hoursWorkedType Then
        '                    qty = ComputeQuantity(empDeduction.EmployeeIdNo, Deduction.QuantityType)
        '                Else
        '                    qty = ComputeQuantity(empDeduction.EmployeeIdNo, Deduction.QuantityType)
        '                End If
        '                amount = rate * qty
        '                If Not regenerate Then
        '                    AddPayElement(employeeIdNo, amount, Deduction.IdNo, 0, payrollDetailIdNo)
        '                Else
        '                    UpdatePayElement(employeeIdNo, amount, Deduction.IdNo, payrollDetailIdNo)
        '                End If
        '            End If
        '        End If
        '    Next
        'End Sub

        Private Sub AddPayElement(employeeIdNo As Int32, amount As Decimal, payElementIdNo As Short, payrollPayElementIdNo As Int16, payrollDetailIdNo As Int32, recurringPayElementIdNo As Int32)
            If amount <> 0 Then
                'If payElementIdNo = 32 Then
                '    Debugger.Break()
                'End If
                Dim payrollPayElement As New PayrollPayElementModel
                payrollPayElement.Amount = Math.Round(amount, 0)
                payrollPayElement.PayrollIdNo = _payrollIdNo
                payrollPayElement.PayElementIdNo = payElementIdNo
                payrollPayElement.EmployeeIdNo = employeeIdNo
                payrollPayElement.IdNo = payrollPayElementIdNo
                payrollPayElement.PayrollDetailIdNo = payrollDetailIdNo
                payrollPayElement.RecurringPayElementIdNo = recurringPayElementIdNo
                _payrollPayElements.Add(payrollPayElement)
            End If
        End Sub

        Private Sub UpdatePayElement(employeeIdNo As Int32, amount As Decimal, payElementIdNo As Int16, payrollDetailIdNo As Int32, recurringPayElementIdNo As Int32)
            If amount <> 0 Then
                Dim payrollPayElement As PayrollPayElementModel = _savedPayrollPayElements.Find(Function(value As PayrollPayElementModel)
                                                                                                    Return value.EmployeeIdNo = employeeIdNo And value.PayElementIdNo = payElementIdNo
                                                                                                End Function)

                If payrollPayElement Is Nothing Then
                    AddPayElement(employeeIdNo, amount, payElementIdNo, 0, payrollDetailIdNo, recurringPayElementIdNo)
                Else
                    AddPayElement(employeeIdNo, amount, payElementIdNo, payrollPayElement.IdNo, payrollPayElement.PayrollDetailIdNo, recurringPayElementIdNo)
                End If
            End If
        End Sub

        'Private Sub AddToGeneratedPayroll(employeeIdNo As Int32, amount As Decimal, earningIdNo As Short, earning As PayrollPayElementModel)
        '    Dim payrollPayElement As New PayrollPayElementModel
        '    payrollPayElement.Amount = Math.Round(amount, 2)
        '    payrollPayElement.PayrollIdNo = _payrollIdNo
        '    payrollPayElement.PayElementIdNo = earningIdNo
        '    payrollPayElement.EmployeeIdNo = employeeIdNo
        '    If earning IsNot Nothing Then
        '        payrollPayElement.IdNo = earning.IdNo
        '    End If
        '    _payrollPayElements.Add(payrollPayElement)
        'End Sub

        Private Sub GenerateComputedPayElements(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32)
            For Each earning As PayElementModel In _computedPayElements
                If employeeIdNo = 405 And (earning.IdNo = 51 Or earning.IdNo = 31) Then '  = 397 And earning.IdNo = 36 Then
                    Debugger.Break()
                End If
                If earning.Active Then
                    Dim amount As Decimal
                    amount = CalculateComputedPayElement(employeeIdNo, earning)
                    If Not regenerate Then
                        AddPayElement(employeeIdNo, amount, earning.IdNo, 0, payrollDetailIdNo, Nothing)
                    Else
                        UpdatePayElement(employeeIdNo, amount, earning.IdNo, payrollDetailIdNo, Nothing)
                    End If
                End If
            Next
        End Sub

        Private Sub GenerateGlobalPayElements(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32)
            For Each earning As PayElementModel In _globalEarnings
                If earning.Active Then
                    If Not regenerate Then
                        AddPayElement(employeeIdNo, earning.Rate, earning.IdNo, 0, payrollDetailIdNo, Nothing)
                    Else
                        UpdatePayElement(employeeIdNo, earning.Rate, earning.IdNo, payrollDetailIdNo, Nothing)
                    End If
                End If
            Next
        End Sub

        Private Function CalculateComputedPayElement(employeeIdNo As Int32, earning As PayElementModel) As Decimal
            Dim amount As Decimal
            Dim rate As Decimal
            If earning.CalculationType = _fixedRateType Then
                Dim payElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = earning.IdNo)
                If payElementModel IsNot Nothing Then
                    rate = ComputePayAmount(_payFrequency, payElementModel.Amount, earning.Unit)
                    Dim qty As Decimal = ComputeQuantity(employeeIdNo, earning.Unit)
                    amount = rate * qty
                Else
                    amount = 0
                End If
            ElseIf earning.CalculationType = _factorType Then
                Dim bpEarning As PayElementModel = _payElementsService.GetRecordByIdNo(Of PayElementModel)(earning.BasePaymentIdNo)
                If bpEarning.Summary Then
                    Dim bpAmount As Decimal
                    bpAmount = ComputeSummaryAmount(employeeIdNo, earning.BasePaymentIdNo)
                    rate = ComputeFactoredAmount(bpAmount, earning.FactorValue, earning.FactorType)
                    Dim qty = ComputeQuantity(employeeIdNo, earning.QuantityType)
                    amount = qty * rate
                Else
                    Dim bpPayElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = earning.BasePaymentIdNo)
                    If bpPayElementModel IsNot Nothing Then
                        Dim qty = ComputeQuantity(employeeIdNo, earning.QuantityType)
                        Dim bpAmount = ComputeFactoredAmount(bpPayElementModel.Amount, earning.FactorValue, earning.FactorType)
                        amount = qty * bpAmount
                    End If
                End If
            End If
            Return amount
        End Function

        Private Function ComputeFactoredAmount(amount As Decimal, FactorValue As Decimal, FactorType As String)
            Dim factoredAmount As Decimal
            If FactorType = _factorPercentType Then
                factoredAmount = amount * FactorValue * 0.01D
            ElseIf FactorType = _factorMultiplyType Then
                factoredAmount = amount * FactorValue
            ElseIf FactorType = _factorDivideType Then
                If FactorValue <> 0 Then
                    factoredAmount = amount / FactorValue
                End If
            End If
            Return factoredAmount
        End Function

        Private Function ComputeSummaryAmount(employeeIdNo As Int32, earningIdNo As Int16) As Decimal
            Dim summaryAmount As Decimal
            Dim payElementItems As List(Of PayElementItem) = _payElementItemsService.GetRecordsWithGroupIdNo(Of PayElementItem)(earningIdNo)
            For Each payElementItem As PayElementItem In payElementItems
                Dim payElement As PayElementModel = _payElementsService.GetRecordByIdNo(Of PayElementModel)(payElementItem.PayElementIdNo)
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

        Private Function ComputeSummaryItemAmount(amount As Decimal, FactorValue As Decimal, FactorType As String)
            Dim factoredAmount As Decimal
            If FactorType = _factorPercentType Then
                factoredAmount = amount * FactorValue * 0.01D
            ElseIf FactorType = _factorMultiplyType Then
                factoredAmount = amount * FactorValue
            ElseIf FactorType = _factorDivideType Then
                If FactorValue <> 0 Then
                    factoredAmount = amount / FactorValue
                End If
            End If
            Return factoredAmount
        End Function

        Private Function ComputeDeductionAmount(deduction As PayElement, daysAbsentWithoutPay As Decimal, basePayment As EmployeePayElement) As Decimal
            Debugger.Break()
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
            Dim payrollDetails As New List(Of PayrollDetail)
            Dim payrollDetailsModel As New List(Of PayrollDetailModel)
            Dim savedPayrollDetails As New List(Of PayrollDetail)
            Dim savedPayrollDetailsModel As New List(Of PayrollDetailModel)
            savedPayrollDetails = _payrollDetailsService.GetRecordsWithGroupIdNo(Of PayrollDetail)(_payrollIdNo)
            GlobalVariables.Mapper.Map(savedPayrollDetails, savedPayrollDetailsModel)
            savedPayrollDetails = Nothing
            If savedPayrollDetailsModel.Count() = 0 Then
                For Each employeeAttendance In View.PayrollAttendance
                    Dim payrollDetail As New PayrollDetailModel
                    payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo
                    payrollDetail.PayrollIdNo = View.IdNo
                    payrollDetailsModel.Add(payrollDetail)
                Next
            Else
                For Each employeeAttendance In View.PayrollAttendance
                    Dim payrollDetail As New PayrollDetailModel
                    payrollDetail = savedPayrollDetailsModel.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
                    If payrollDetail Is Nothing Then
                        payrollDetail = New PayrollDetailModel
                        payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo
                        payrollDetail.PayrollIdNo = View.IdNo
                    End If
                    payrollDetailsModel.Add(payrollDetail)
                Next
            End If
            For Each employeeAttendance In View.PayrollOvertime
                Dim payrollDetail As PayrollDetailModel = payrollDetailsModel.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
                If payrollDetail Is Nothing Then
                    payrollDetail = savedPayrollDetailsModel.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
                    If payrollDetail Is Nothing Then
                        payrollDetail = New PayrollDetailModel
                        payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo
                        payrollDetail.PayrollIdNo = View.IdNo
                        payrollDetailsModel.Add(payrollDetail)
                    End If
                End If
            Next
            Return payrollDetailsModel
        End Function

        'Private Function ComputePayAMount(payFrequency As PayFrequencySelection, amount As Decimal, unit As String) As Decimal
        '    Dim factor As Decimal
        '    Select Case payFrequency
        '        Case PayFrequencySelection.Monthly
        '            If unit = _monthType Then
        '                factor = 1D
        '            ElseIf unit = _semiMonthType Then
        '                factor = 2D
        '            ElseIf unit = _yearType Then
        '                factor = 1D / 12D
        '            ElseIf unit = _semiYearType Then
        '                factor = 1D / 6D
        '            ElseIf unit = _quarterType Then
        '                factor = 1D / 3D
        '            ElseIf unit = _weekType Then
        '                factor = 13D / 2D
        '            ElseIf unit = _dayType Then
        '                factor = 30D
        '            ElseIf unit = _biWeekType Then
        '                factor = 13D / 6D
        '            End If
        '        Case PayFrequencySelection.Yearly
        '            If unit = _monthType Then
        '                factor = 12D
        '            ElseIf unit = _semiMonthType Then
        '                factor = 24D
        '            ElseIf unit = _yearType Then
        '                factor = 1D
        '            ElseIf unit = _semiYearType Then
        '                factor = 2D
        '            ElseIf unit = _quarterType Then
        '                factor = 4D
        '            ElseIf unit = _weekType Then
        '                factor = 52D
        '            ElseIf unit = _dayType Then
        '                factor = 365D
        '            ElseIf unit = _biWeekType Then
        '                factor = 26D
        '            End If
        '        Case PayFrequencySelection.SemiYearly
        '            If unit = _monthType Then
        '                factor = 6D
        '            ElseIf unit = _semiMonthType Then
        '                factor = 12D
        '            ElseIf unit = _yearType Then
        '                factor = 1D / 2D
        '            ElseIf unit = _semiYearType Then
        '                factor = 1D
        '            ElseIf unit = _quarterType Then
        '                factor = 2D
        '            ElseIf unit = _weekType Then
        '                factor = 26D
        '            ElseIf unit = _dayType Then
        '                factor = 365D / 2D
        '            ElseIf unit = _biWeekType Then
        '                factor = 13D
        '            End If
        '        Case PayFrequencySelection.Quarterly
        '            If unit = _monthType Then
        '                factor = 3D
        '            ElseIf unit = _semiMonthType Then
        '                factor = 6D
        '            ElseIf unit = _yearType Then
        '                factor = 1D / 4D
        '            ElseIf unit = _semiYearType Then
        '                factor = 1D / 2D
        '            ElseIf unit = _quarterType Then
        '                factor = 1D
        '            ElseIf unit = _weekType Then
        '                factor = 13D
        '            ElseIf unit = _dayType Then
        '                factor = 365D / 4D
        '            ElseIf unit = _biWeekType Then
        '                factor = 13D / 2D
        '            End If
        '        Case PayFrequencySelection.SemiMonthly
        '            If unit = _monthType Then
        '                factor = 1D / 2D
        '            ElseIf unit = _semiMonthType Then
        '                factor = 1D
        '            ElseIf unit = _yearType Then
        '                factor = 1D / 24D
        '            ElseIf unit = _semiYearType Then
        '                factor = 1D / 12D
        '            ElseIf unit = _quarterType Then
        '                factor = 1D / 6D
        '            ElseIf unit = _weekType Then
        '                factor = 13D / 4D
        '            ElseIf unit = _dayType Then
        '                factor = 15D
        '            ElseIf unit = _biWeekType Then
        '                factor = 13D / 12D
        '            End If
        '        Case PayFrequencySelection.Weekly
        '            If unit = _monthType Then
        '                factor = 12D / 52D
        '            ElseIf unit = _semiMonthType Then
        '                factor = 24D / 52D
        '            ElseIf unit = _yearType Then
        '                factor = 1D / 52D
        '            ElseIf unit = _semiYearType Then
        '                factor = 1D / 26D
        '            ElseIf unit = _quarterType Then
        '                factor = 1D / 13D
        '            ElseIf unit = _weekType Then
        '                factor = 1D
        '            ElseIf unit = _dayType Then
        '                factor = 7D
        '            ElseIf unit = _biWeekType Then
        '                factor = 1D / 2D
        '            End If
        '        Case PayFrequencySelection.Daily
        '            If unit = _monthType Then
        '                factor = 1D / 30D
        '            ElseIf unit = _semiMonthType Then
        '                factor = 1D / 15D
        '            ElseIf unit = _yearType Then
        '                factor = 1D / 360D
        '            ElseIf unit = _semiYearType Then
        '                factor = 1D / 180D
        '            ElseIf unit = _quarterType Then
        '                factor = 1D / 90D
        '            ElseIf unit = _weekType Then
        '                factor = 1D / 7D
        '            ElseIf unit = _dayType Then
        '                factor = 1D
        '            ElseIf unit = _biWeekType Then
        '                factor = 1D / 14D
        '            End If

        '    End Select
        '    Return amount * factor
        'End Function

        Private Function ComputeQuantity(employeeIdNo As Int32, quantityType As String)
            Dim quantity As Decimal?
            If quantityType = _hoursWorkedType Then
                quantity = GetOtWorkHourValues(employeeIdNo, "HoursWorked")
            ElseIf quantityType = _daysLeaveWithPayType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysAbsentWithPay")
            ElseIf quantityType = _daysOffType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysOff")
            ElseIf quantityType = _daysPresentType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysPresent")
            ElseIf quantityType = _daysLeaveWithoutPayType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysAbsentWithoutPay")
            ElseIf quantityType = _daysPaidType Then
                Dim attendanceItem As AttendanceItemModel = _attendanceItemService.GetRecordByIdNo(Of AttendanceItemModel)(employeeIdNo)
                quantity = attendanceItem.DaysPresent + attendanceItem.DaysAbsentWithPay + attendanceItem.DaysOff
            ElseIf quantityType = _overtimeRegularType Then
                quantity = GetOtWorkHourValues(employeeIdNo, "OvertimeRegular")
            ElseIf quantityType = _overtimeHolidayType Then
                quantity = GetOtWorkHourValues(employeeIdNo, "OvertimeHoliday")
            ElseIf quantityType = _overTimeSpecialType Then
                quantity = GetOtWorkHourValues(employeeIdNo, "OvertimeSpecial")
            Else
                quantity = 1
            End If
            Return IIf(quantity Is Nothing, 0, quantity)
        End Function

        Private Function GetAttendanceValues(employeeIdNo As Int32, fieldName As String) As Decimal
            Return Service.GetFieldValue(Of Decimal)(fieldName, "AttendanceItem", "EmployeeIdNo = " & employeeIdNo.ToString() & " and PayrollIdNo = " & _payrollIdNo)
        End Function

        Private Function GetOtWorkHourValues(employeeIdNo As Int32, fieldName As String) As Decimal
            ' after getting qty need to zero out the value so that no double use of otHoursComputation
            ' because there might be multiple otcomputations. Regular OtWorkHours take precedence
            ' over computed otworkhours
            Dim qty As Decimal = 0
            Dim otWorkHourModel = _otWorkHoursModel.Find(Function(x) x.EmployeeIdNo = employeeIdNo)
            If otWorkHourModel IsNot Nothing Then
                Select Case fieldName
                    Case "HoursWorked"
                        qty = otWorkHourModel.HoursWorked
                        otWorkHourModel.HoursWorked = 0
                    Case "OvertimeRegular"
                        qty = otWorkHourModel.OvertimeRegular
                        otWorkHourModel.OvertimeRegular = 0
                    Case "OvertimeHoliday"
                        qty = otWorkHourModel.OvertimeHoliday
                        otWorkHourModel.OvertimeHoliday = 0
                    Case "OvertimeSpecial"
                        qty = otWorkHourModel.OvertimeSpecial
                        otWorkHourModel.OvertimeSpecial = 0
                End Select
            End If
            Return qty
        End Function

        'Private Sub MakePayrollOt(payrollIdNo As Short, otHours As Decimal, otUnit As String, otRate As Decimal, otEarning As Earning, employeeIdNo As Integer)
        '    Dim otAmount As Decimal = ComputeOtAmount(otEarning, otHours, otRate)
        '    AddEarning(employeeIdNo, otAmount, payrollIdNo, otEarning.IdNo)
        'End Sub

        'Private Shared Function ComputeOtAmount(otEarning As PayElement, otHours As Decimal, otRate As Decimal) As Decimal
        '    Dim otAmount As Decimal
        '    If otEarning IsNot Nothing Then
        '        otAmount = otHours * IIf(IsDBNull(otRate), 0, otRate)
        '    Else
        '        otAmount = otHours * IIf(IsDBNull(otEarning.Rate), 0, otEarning.Rate)
        '    End If
        '    Return otAmount
        'End Function

    End Class

End Namespace