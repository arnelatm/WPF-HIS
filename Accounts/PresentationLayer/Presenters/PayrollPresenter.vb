Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayrollPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPayrollView, TM)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Protected DtOtInsertTable As New DataTable
        Protected DtOtUpdateTable As New DataTable
        Protected DtEarnInsertTable As New DataTable
        Protected DtEarnUpdateTable As New DataTable
        Private _attendanceItemService As New AccountsService("AttendanceItem")
        Private _otWorkHourService As New AccountsService("OtWorkHour")
        Private _reinitialize As Boolean = False
        Private _payrollPayElements As List(Of PayrollPayElementModel)
        Private _payrollDetailsModel As List(Of PayrollDetailModel)
        Private _savedPayrollPayElements As List(Of PayrollPayElementModel)
        Private ReadOnly _payrollEarning
        Private _computedPayElements As New List(Of PayElementModel)
        Private _globalEarnings As New List(Of PayElementModel)
        Private _otWorkHoursModel As New List(Of OtWorkHourModel)

        Private _daysInTheMonth As Int16
        Private ReadOnly _endDate As Date
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
        Private ReadOnly _calcTypeFactor = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _calcTypeFixedAmount = EnumToCode(CalculationTypeSelection.FixedAmount)
        Private ReadOnly _calcTypeFixedRate = EnumToCode(CalculationTypeSelection.FixedRate)
        Private ReadOnly _calcTypeVariable = EnumToCode(CalculationTypeSelection.Variable)
        Private ReadOnly _daysOffType = EnumToCode(QuantityTypeSelection.DaysOff)
        Private ReadOnly _daysPresentType = EnumToCode(QuantityTypeSelection.DaysPresent)
        Private ReadOnly _daysLeaveWithoutPayType = EnumToCode(QuantityTypeSelection.DaysLeaveWithoutPay)
        Private ReadOnly _daysPaidType = EnumToCode(QuantityTypeSelection.DaysPaid)
        Private ReadOnly _daysVacationType = EnumToCode(QuantityTypeSelection.DaysVacationLeave)
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
        Private ReadOnly _factorComplementDutyHoursRatio = EnumToCode(FactorTypeSelection.MultiplyComplementOfDutyRatio)
        Private ReadOnly _serviceAccounts
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
            AddHandler view.ClearAllEmployee, AddressOf OnClearAllEmployeeId
            AddHandler view.PayCycleChanged, AddressOf OnPayCycleChanged

            CreateDataTable(DtInsertTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"DaysTotal", GetType(Decimal)},
                                            {"DaysVacationLeave", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"PayrollIdNo", GetType(Int16)},
                                            {"Sequence", GetType(Int16)}
                                           })

            CreateDataTable(DtUpdateTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"DaysTotal", GetType(Decimal)},
                                            {"DaysVacationLeave", GetType(Decimal)},
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

        Private Sub OnPayCycleChanged(sender As Object)
            View.PayFrequency = Service.GetField(Of String, Int16)(View.PayCycleIdNo, "PayCycle", "IdNo", "PayFrequency")
        End Sub

        Public Overrides Function IsOkToEditRecord() As Boolean
            Dim retVal As Boolean = True
            If View.Posted Then
                Messaging.Show(True, "MsgChangePostedRecordNotAllowed")
                retVal = False
            End If
            Return retVal
        End Function

        Public Sub InitializeMonthlyPayroll(payCycleRecord As PayCycleModel)
            If View.StartDate Is Nothing And View.EndDate Is Nothing Then
                If payCycleRecord.PayCycleCode = "Month" Then
                    Dim nIdNoMax As Int32
                    Dim maxRecord As PayrollModel
                    Dim payMonthText As String = "Payroll for the Month of"
                    Dim PayrollText As String = "Payroll for the Period"
                    nIdNoMax = Service.GetFieldOnMaxField("EndDate", "Payroll", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
                    maxRecord = Service.GetRecordByIdNo(Of PayrollModel)(nIdNoMax)
                    View.StartDate = maxRecord.EndDate.AddDays(1)
                    Dim arabicCulture As New CultureInfo("ar-ae", False)
                    Dim dStartDate As Date = View.StartDate
                    If dStartDate.Day = 1 Then
                        View.EndDate = dStartDate.AddMonths(1).AddDays(-1)
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

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"PayCycle", "PayCycleIdNo", Nothing, Nothing}})
            MakeVarDataSources({New Object() {"Employee", "Employees", Nothing, Nothing}})
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            Dim nIdNoMax As Int32
            Dim maxRecord As PayrollModel
            Dim payMonthText As String = "Payroll for the Month of"
            Dim PayrollText As String = "Payroll for the Period"
            nIdNoMax = Service.GetFieldOnMaxField("EndDate", "Payroll", "IdNo", "PayCycleIdNo = 1") ' + View.PayCycleIdNo.ToString())
            If nIdNoMax = 0 Then
                Dim now As Date = Today()
                View.EndDate = DateAdd(DateInterval.Day, now.Day * -1, now)
                View.StartDate = DateAdd(DateInterval.Day, View.EndDate.Value.Day * -1 + 1, View.EndDate.Value.Day)
            Else
                maxRecord = Service.GetRecordByIdNo(Of PayrollModel)(nIdNoMax)
                View.StartDate = maxRecord.EndDate.AddDays(1)
                Dim dDate As Date = View.StartDate
                If dDate.Day = 1 Then
                    View.EndDate = dDate.AddMonths(1).AddDays(-1)
                Else
                    View.EndDate = maxRecord.EndDate.AddMonths(1)
                End If
            End If
            View.PayCycleIdNo = 1
            Dim arabicCulture As New CultureInfo("ar-ae", False)
            If View.StartDate.Value.Day = 1 AndAlso AsMonthEndDate(View.StartDate) = View.EndDate Then
                View.PayrollName = payMonthText & " " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                View.PayrollNameAra = Messaging.TranslateCaption(payMonthText, "ar-SA") + GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate) - 1) & " " & Year(View.EndDate).ToString()
            Else
                View.PayrollName = PayrollText & " " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
                View.PayrollNameAra = Messaging.TranslateCaption(PayrollText, "ar-SA") & " " & GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
            End If
            View.PayrollCode = "M" + CDate(View.EndDate).ToString("yyMM")
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                CustomObjToDataTables(View.PayrollAttendance, DtInsertTable, DtUpdateTable, AddressOf AttendanceItemFillData, AddressOf AttendanceItemFilter, "IdNo")
                CustomObjToDataTables(View.PayrollOvertime, DtOtInsertTable, DtOtUpdateTable, AddressOf OtWorkHourFillData, AddressOf OtWorkHourFilter, "IdNo")
            End If
        End Sub

        Public Sub InitializeAttendance()
            View.PayFrequency = GetFieldWithIdNo(View.PayCycleIdNo, "PayCycle", "PayFrequency")
            Dim employeeFilter = "PayCycleIdNo = " & View.PayCycleIdNo.ToString() ' & " And Active = 1"
            Dim employees = GetRecords("Employee", "EmployeeName", {"IdNo", "EmployeeName", "HiredDate", "ReleasedDate", "DutyHours", "ActualDutyHours"}, employeeFilter)
            Dim numberOfEmployees = Int(employees.Count() / 6)
            Dim daysInPeriod As Long
            Dim daysOffInPeriod As Long
            Dim seq As Integer
            Dim dateHired As Date
            Dim dateReleased As Date?
            Dim dutyHours As Int32
            Dim actualDutyHours As Int32
            Dim empId As Int32
            Dim empName As String
            Dim empFound As Boolean = False
            Dim absenceService As New AccountsService("EmployeeAbsence")
            Dim absences As List(Of EmployeeAbsenceModel) = absenceService.GetRecordsWithGroupIdNo(Of EmployeeAbsenceModel)(View.IdNo, "IdNo")
            'seq = View.PayrollAttendance.Count() + absences.Count() + 1
            daysInPeriod = DateDiff(DateInterval.Day, Convert.ToDateTime(View.StartDate), Convert.ToDateTime(View.EndDate)) + 1
            daysOffInPeriod = ComputeDaysOff(View.StartDate, View.EndDate)
            If View.PayrollAttendance.Any() Then
                _reinitialize = True
            Else
                _reinitialize = False
            End If
            Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
            Dim counter As Integer = 0
            progressDisplayForm.Show()
            progressDisplayForm.InitializeDisplay(numberOfEmployees + absences.Count)
            seq = 1
            If _reinitialize Then
                Dim currentEmpAttendance As New List(Of AttendanceItemView)
                GlobalVariables.Mapper.Map(View.PayrollAttendance, currentEmpAttendance)
                Dim i As Int16 = 1
                seq = 1
                View.PayrollAttendance.Clear()
                For i = 1 To numberOfEmployees
                    empId = employees(i * 6 - 6)
                    empName = employees(i * 6 - 5)
                    dateHired = employees(i * 6 - 4)
                    dateReleased = IIf(IsDBNull(employees(i * 6 - 3)), Nothing, employees(i * 6 - 3))
                    dutyHours = employees(i * 6 - 2)
                    actualDutyHours = employees(i * 6 - 1)
                    If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased > View.StartDate) Then
                        Dim empAttendance As AttendanceItemView
                        empAttendance = currentEmpAttendance.Find(Function(c) c.EmployeeIdNo = empId)
                        If empAttendance IsNot Nothing Then
                            If empAttendance.Selected Then
                                UpdateEmployeeAttendance(empAttendance, dateHired, dateReleased, empId, empName, daysInPeriod, daysOffInPeriod, seq)
                            Else
                                View.PayrollAttendance.Add(empAttendance)
                            End If
                        Else
                            AddEmployeeAttendance(dateHired, dateReleased, empId, empName, daysInPeriod, daysOffInPeriod, seq)
                        End If
                        seq = seq + 1
                    Else
                        '    Ignore these records they will be deleted
                        '    Dim empAttendance As AttendanceItemView
                        '    empAttendance = View.PayrollAttendance.Find(Function(c) c.EmployeeIdNo = empId)
                        '    If empAttendance IsNot Nothing Then
                        '        View.PayrollAttendance.Remove(empAttendance)
                        '    End If
                    End If
                    counter = counter + 1
                    progressDisplayForm.UpdateProgressBar(counter)
                Next
                View.PayrollAttendance.Sort(Function(p1, p2) p1.EmployeeName.CompareTo(p2.EmployeeName))
                i = 1
                For Each item In View.PayrollAttendance
                    item.Sequence = i
                    i = i + 1
                Next
            Else
                For i = 1 To numberOfEmployees
                    empId = employees(i * 6 - 6)
                    empName = employees(i * 6 - 5)
                    dateHired = employees(i * 6 - 4)
                    dateReleased = IIf(IsDBNull(employees(i * 6 - 3)), Nothing, employees(i * 6 - 3))
                    dutyHours = employees(i * 6 - 2)
                    actualDutyHours = employees(i * 6 - 1)
                    If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
                        AddEmployeeAttendance(dateHired, dateReleased, empId, empName, daysInPeriod, daysOffInPeriod, seq)
                        seq = seq + 1
                    End If
                    counter = counter + 1
                    progressDisplayForm.UpdateProgressBar(counter)
                Next
            End If
            For Each absence In absences
                Dim empIdNo = absence.EmployeeIdNo
                Dim empAttendance As AttendanceItemView
                empAttendance = View.PayrollAttendance.Find(Function(c) c.EmployeeIdNo = empIdNo)
                If empAttendance IsNot Nothing Then
                    empAttendance.DaysAbsentWithoutPay += Math.Round(absence.EquivalentHours / dutyHours * actualDutyHours, 4)
                    empAttendance.DaysPresent -= Math.Round(absence.EquivalentHours / dutyHours * actualDutyHours, 4)
                End If
                counter = counter + 1
                progressDisplayForm.UpdateProgressBar(counter)
            Next
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
            empAttendance.PayrollIdNo = View.IdNo
            empAttendance.EmployeeIdNo = empId
            empAttendance.EmployeeName = empName
            empAttendance.Sequence = seq
            'If empId = 232 Then
            '    Debugger.Break()
            'End If
            If dateHired <= View.StartDate AndAlso (dateReleased Is Nothing OrElse dateReleased > View.EndDate) Then
                empAttendance.DaysAbsentWithoutPay = 0
                empAttendance.DaysAbsentWithPay = 0
                empAttendance.DaysVacationLeave = 0
                empAttendance.DaysPresent = daysTotal - daysOff
            Else
                If dateReleased Is Nothing OrElse dateReleased > View.EndDate Then
                    Dim sDate As Date
                    sDate = View.StartDate
                    empAttendance.DaysAbsentWithoutPay = DateDiff(DateInterval.Day, sDate, dateHired)
                    empAttendance.DaysAbsentWithPay = 0
                    empAttendance.DaysVacationLeave = 0
                    empAttendance.DaysPresent = daysTotal - empAttendance.DaysAbsentWithoutPay - daysOff
                Else
                    Dim rDate As Date ' need to do this because Date? type is not accepted by DateAdd function
                    Dim eDate As Date
                    rDate = dateReleased
                    eDate = View.EndDate
                    empAttendance.DaysAbsentWithoutPay = DateDiff(DateInterval.Day, rDate, eDate) + 1
                    empAttendance.DaysAbsentWithPay = 0
                    empAttendance.DaysVacationLeave = 0
                    empAttendance.DaysPresent = daysTotal - empAttendance.DaysAbsentWithoutPay - daysOff
                End If
            End If
            View.PayrollAttendance.Add(empAttendance)
        End Sub

        Public Sub UpdateEmployeeAttendance(ByVal empAttendance As AttendanceItemView, ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal empId As Int16, ByVal empName As String, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16, ByVal seq As Int16)
            Dim daysOff As Int16
            Dim daysTotal As Int16
            ComputeTotalDaysNOff(daysTotal, daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
            empAttendance.DaysTotal = daysTotal
            empAttendance.DaysOff = daysOff
            empAttendance.PayrollIdNo = View.IdNo
            empAttendance.EmployeeIdNo = empId
            empAttendance.EmployeeName = empName
            empAttendance.Sequence = seq

            If dateHired <= View.StartDate AndAlso (dateReleased Is Nothing OrElse dateReleased > View.EndDate) Then
                empAttendance.DaysAbsentWithoutPay = 0
                empAttendance.DaysAbsentWithPay = 0
                empAttendance.DaysVacationLeave = 0
                empAttendance.DaysPresent = daysTotal - daysOff
            Else
                If dateReleased Is Nothing OrElse dateReleased > View.EndDate Then
                    Dim sDate As Date
                    sDate = View.StartDate
                    empAttendance.DaysAbsentWithoutPay = DateDiff(DateInterval.Day, sDate, dateHired)
                    empAttendance.DaysAbsentWithPay = 0
                    empAttendance.DaysVacationLeave = 0
                    empAttendance.DaysPresent = daysTotal - empAttendance.DaysAbsentWithoutPay - daysOff
                Else
                    Dim rDate As Date ' need to do this because Date? type is not accepted by DateAdd function
                    Dim eDate As Date
                    rDate = dateReleased
                    eDate = View.EndDate
                    empAttendance.DaysAbsentWithoutPay = DateDiff(DateInterval.Day, rDate, eDate) + 1
                    empAttendance.DaysAbsentWithPay = 0
                    empAttendance.DaysVacationLeave = 0
                    empAttendance.DaysPresent = daysTotal - empAttendance.DaysAbsentWithoutPay - daysOff
                End If
            End If
            View.PayrollAttendance.Add(empAttendance)
        End Sub

        Public Sub AddEmployeeOvertime(ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal empId As Int16, ByVal seq As Int16)
            Dim empOvertime As New OtWorkHourView
            empOvertime.EmployeeIdNo = empId
            empOvertime.Sequence = seq
            View.PayrollOvertime.Add(empOvertime)
        End Sub

        'Public Sub InitializeEmployeeAttendance(ByRef empAttendance As AttendanceItemView, ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16)
        '    Dim daysOff As Int16
        '    Dim daysTotal As Int16
        '    ComputeTotalDaysNOff(daysTotal, daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
        '    empAttendance.DaysTotal = daysTotal
        '    empAttendance.DaysOff = daysOff
        '    empAttendance.DaysAbsentWithoutPay = 0
        '    empAttendance.DaysAbsentWithPay = 0
        '    'empAttendance.DaysVacationLeave = 0
        '    empAttendance.DaysPresent = empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysAbsentWithoutPay - empAttendance.DaysVacationLeave
        'End Sub

        Private Sub ComputeTotalDaysNOff(ByRef daysTotal As Int16, ByRef daysOff As Int16, ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16)
            Dim eDate As Date
            If dateHired <= View.StartDate AndAlso (dateReleased Is Nothing OrElse dateReleased > View.EndDate) Then
                daysOff = daysOffInPeriod
                daysTotal = daysInPeriod
            Else
                If dateReleased Is Nothing OrElse dateReleased > View.EndDate Then
                    eDate = View.EndDate
                    daysTotal = DateDiff(DateInterval.Day, dateHired, eDate) + 1
                    daysOff = ComputeDaysOff(dateHired, eDate)
                Else
                    Dim rDate As Date ' need to do this because Date? type is not accepted by DateAdd function
                    Dim sDate As Date
                    sDate = View.StartDate
                    rDate = dateReleased
                    daysTotal = daysInPeriod
                    daysOff = ComputeDaysOff(sDate, rDate)
                End If
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
            workRow("DaysTotal") = itemDataView.DaysTotal
            workRow("DaysVacationLeave") = itemDataView.DaysVacationLeave
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

        Public Shared Function ComputeDaysOff(ByVal begDate As Date, endDate As Date) As Integer
            Dim count As Integer
            Dim d As DateTime = begDate
            Do Until d = endDate
                ' for now assume everyone has Days off on Friday
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
            'If ChangesMade() Then
            '    Messaging.Show(True,"MsgSaveFirstBeforeGeneration")
            'Else
            _payrollIdNo = View.IdNo
            If View.PayrollAttendance.Count() = 0 And View.PayrollOvertime.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendanceOt")
            Else
                Dim payrollService As New AccountsService("Payroll")
                Dim payroll As PayrollModel = payrollService.GetRecordByIdNo(Of PayrollModel)(View.IdNo)
                'View.PayFrequency = _payCycleService.GetRecordByIdNo(Of PayCycleModel)(payroll.PayCycleIdNo).PayFrequency
                Dim payrollPayElements As List(Of PayrollPayElementModel)
                _payFrequency = CodeToEnum(Of PayFrequencySelection)(View.PayFrequency)
                If _payFrequency = PayFrequencySelection.Monthly Then
                    _daysInTheMonth = DateTime.DaysInMonth(Year(View.EndDate), Month(View.EndDate))
                    payrollPayElements = _payrollPayElementsService.GetRecordsWithGroupIdNo(Of PayrollPayElementModel)(View.IdNo)
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
            'End If
        End Sub

        Private Sub ProcessPayroll(ByRef regenerate As Boolean)
            Dim dtPayrollPayElementInsertTable As New DataTable
            Dim dtPayrollPayElementUpdateTable As New DataTable
            _payrollPayElements = New List(Of PayrollPayElementModel)
            CreateDataTable(dtPayrollPayElementInsertTable, {{"Amount", GetType(Decimal)},
                                                             {"Generated", GetType(Boolean)},
                                                             {"PayElementIdNo", GetType(Int16)},
                                                             {"PayrollDetailIdNo", GetType(Int32)},
                                                             {"RecurringPayElementIdNo", GetType(Int32)}
                                                            })
            CreateDataTable(dtPayrollPayElementUpdateTable, {{"Amount", GetType(Decimal)},
                                             {"Generated", GetType(Boolean)},
                                             {"IdNo", GetType(Int32)},
                                             {"PayElementIdNo", GetType(Int16)},
                                             {"PayrollDetailIdNo", GetType(Int32)},
                                             {"RecurringPayElementIdNo", GetType(Int32)}
                                            })

            _payrollDetailsModel = New List(Of PayrollDetailModel)
            CreatePayrollDetails()
            Dim counter As Integer = 0
            Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
            progressDisplayForm.Show()
            progressDisplayForm.InitializeDisplay(_payrollDetailsModel.Count() + 2)
            If regenerate Then
                _savedPayrollPayElements = _payrollPayElementsService.GetRecordsWithGroupIdNo(Of PayrollPayElementModel)(_payrollIdNo)
                Dim payrollDetailIdNo As Int32
                For Each payrollDetailModel In _payrollDetailsModel
                    If payrollDetailModel.Selected Then
                        If payrollDetailModel.IdNo = 0 Then
                            payrollDetailIdNo = _payrollDetailsService.AddRecord(payrollDetailModel)
                        Else
                            payrollDetailIdNo = payrollDetailModel.IdNo
                        End If
                        CreatePayrollPayElements(payrollDetailModel, regenerate, payrollDetailIdNo)
                    End If
                    counter = counter + 1
                    progressDisplayForm.UpdateProgressBar(counter)
                Next
                For Each item In _savedPayrollPayElements
                    'Dim dataRow As DataRow
                    Dim payrollAttendance As AttendanceItemView
                    payrollAttendance = View.PayrollAttendance.Find(Function(c) c.EmployeeIdNo = item.EmployeeIdNo)
                    If payrollAttendance Is Nothing Then
                        _payrollPayElements.Add(item)
                    Else
                        If payrollAttendance.Selected Then
                            If item.Generated Then
                                ' ignore these records they have already been regenerated
                            Else
                                _payrollPayElements.Add(item)
                            End If
                        Else
                            _payrollPayElements.Add(item)
                        End If
                    End If
                Next
                For Each item In _payrollPayElements
                    Dim dataRow As DataRow
                    If item.IdNo = 0 Then
                        dataRow = dtPayrollPayElementInsertTable.NewRow()
                    Else
                        dataRow = dtPayrollPayElementUpdateTable.NewRow()
                        dataRow("IdNo") = item.IdNo
                    End If
                    dataRow("Amount") = item.Amount
                    dataRow("Generated") = item.Generated
                    dataRow("PayElementIdNo") = item.PayElementIdNo
                    dataRow("PayrollDetailIdNo") = item.PayrollDetailIdNo
                    dataRow("RecurringPayElementIdNo") = item.RecurringPayElementIdNo
                    If item.IdNo = 0 Then
                        dtPayrollPayElementInsertTable.Rows.Add(dataRow)
                    Else
                        dtPayrollPayElementUpdateTable.Rows.Add(dataRow)
                    End If
                Next
            Else
                ' payrolldetails already saved and generated
                ' so re-read the saved data because we need their linked idno for the
                ' payrollpayelementdetails
                _payrollDetailsModel = _payrollDetailsService.GetRecordsWithGroupIdNo(Of PayrollDetailModel)(_payrollIdNo)
                For Each payrollDetailModel In _payrollDetailsModel
                    CreatePayrollPayElements(payrollDetailModel, regenerate, payrollDetailModel.IdNo)
                    counter = counter + 1
                    progressDisplayForm.UpdateProgressBar(counter)
                Next
                For Each item In _payrollPayElements
                    Dim dataRow As DataRow
                    dataRow = dtPayrollPayElementInsertTable.NewRow()
                    dataRow("Amount") = item.Amount
                    dataRow("Generated") = True
                    dataRow("PayElementIdNo") = item.PayElementIdNo
                    dataRow("PayrollDetailIdNo") = item.PayrollDetailIdNo
                    dataRow("RecurringPayElementIdNo") = item.RecurringPayElementIdNo
                    dtPayrollPayElementInsertTable.Rows.Add(dataRow)
                Next
            End If
            counter = counter + 1
            If regenerate Then
                _payrollPayElementsService.UpdateInsertTvp(dtPayrollPayElementUpdateTable, dtPayrollPayElementInsertTable, _payrollIdNo)
            Else
                _payrollPayElementsService.InsertTvp(dtPayrollPayElementInsertTable)
            End If
            dtPayrollPayElementUpdateTable.Clear()
            dtPayrollPayElementInsertTable.Clear()
            _payrollPayElements.Clear()
            progressDisplayForm.UpdateProgressBar(counter + 1)
            progressDisplayForm.Close()
            'Messaging.Show(True, "MsgPayrollGenerationCompleted")
            Beep()
        End Sub

        Private Sub CreatePayrollPayElements(payrollDetail As PayrollDetailModel, regenerate As Boolean, payrollDetailIdNo As Integer)
            Dim dutyHoursRatio As Decimal = GetEmployeeDutyHoursRatio(payrollDetail.EmployeeIdNo)
            GenerateRegularPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo, dutyHoursRatio)
            GenerateComputedPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo, dutyHoursRatio)
            GenerateGlobalPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo)
            GenerateRecurringPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo)
        End Sub

        Private Sub GenerateRegularPayElements(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32, dutyHoursRatio As Decimal)
            Dim empPayElementsModel As New List(Of EmployeePayElementModel)
            Dim employeePayElementsService As New AccountsService("EmployeePayElement")
            empPayElementsModel = employeePayElementsService.GetRecordsWithGroupIdNo(Of EmployeePayElementModel)(employeeIdNo)
            'Dim empPayElementsModel As New List(Of EmployeePayElementModel)
            'GlobalVariables.Mapper.Map(empPayElements, empPayElementsModel)
            Dim amount As Decimal
            For Each empPayElement As EmployeePayElementModel In empPayElementsModel
                Dim payElement As New PayElementModel
                payElement = _payElementsService.GetRecordByIdNo(Of PayElementModel)(empPayElement.PayElementIdNo)
                'Dim payElementModel As New PayElementModel
                'GlobalVariables.Mapper.Map(payElement, payElementModel)
                If payElement.CalculationType = _calcTypeFixedAmount Then
                    amount = ComputePayAmount(_payFrequency, empPayElement.Amount, empPayElement.Unit)
                    If Not regenerate Then
                        AddPayElement(employeeIdNo, amount, payElement.IdNo, 0, payrollDetailIdNo, Nothing)
                    Else
                        UpdatePayElement(employeeIdNo, amount, payElement.IdNo, payrollDetailIdNo, Nothing)
                    End If
                ElseIf payElement.CalculationType = _calcTypeFixedRate Then
                    Dim rate As Decimal = empPayElement.Rate
                    If rate <> 0 Then
                        Dim qty As Decimal
                        If payElement.QuantityType = _overtimeRegularType OrElse
                            payElement.QuantityType = _overtimeHolidayType OrElse
                            payElement.QuantityType = _overTimeSpecialType OrElse
                            payElement.QuantityType = _hoursWorkedType Then
                            qty = ComputeQuantity(empPayElement.EmployeeIdNo, payElement.QuantityType)
                        ElseIf payElement.QuantityType = _daysLeaveWithoutPayType OrElse
                            payElement.QuantityType = _daysLeaveWithPayType OrElse
                            payElement.QuantityType = _daysOffType OrElse
                            payElement.QuantityType = _daysPaidType OrElse
                            payElement.QuantityType = _daysVacationType Then
                            qty = ComputeQuantity(empPayElement.EmployeeIdNo, payElement.QuantityType, dutyHoursRatio)
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
            Next
        End Sub

        Private _recurringPayElements As New List(Of RecurringPayElementModel)
        Private ReadOnly _recurringPayElementService As New AccountsService("RecurringPayElement")

        Private Sub GenerateRecurringPayElements(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32)
            _recurringPayElements = _recurringPayElementService.GetDaoRecords(Of RecurringPayElementModel)("TotalAmount < LimitAmount and StartDate <= '" + View.StartDate.ToString() + "' and EmployeeIdNo = " & employeeIdNo.ToString() + " and active = 1")
            If _recurringPayElements.Any Then
                Dim amount As Decimal
                For Each recurringPayElement As RecurringPayElementModel In _recurringPayElements
                    Dim currentAmount As Decimal = 0
                    If regenerate Then
                        Dim payrollPayElement As PayrollPayElementModel = _savedPayrollPayElements.Find(Function(value As PayrollPayElementModel)
                                                                                                            Return value.EmployeeIdNo = employeeIdNo And value.RecurringPayElementIdNo = recurringPayElement.IdNo
                                                                                                        End Function)
                        If payrollPayElement IsNot Nothing Then
                            currentAmount = payrollPayElement.Amount
                        End If

                    End If
                    Select Case recurringPayElement.RecurType
                        Case EnumToCode(RecurTypeSelection.UpToLimitAmount)
                            If (recurringPayElement.TotalAmount - currentAmount) < recurringPayElement.LimitAmount Then
                                amount = Math.Min(recurringPayElement.LimitAmount - (recurringPayElement.TotalAmount - currentAmount), recurringPayElement.PeriodicAmount)
                                If Not regenerate Then
                                    AddPayElement(employeeIdNo, amount, recurringPayElement.PayElementIdNo, 0, payrollDetailIdNo, recurringPayElement.IdNo)
                                Else
                                    UpdatePayElement(employeeIdNo, amount, recurringPayElement.PayElementIdNo, payrollDetailIdNo, recurringPayElement.IdNo)
                                End If
                            End If
                        Case EnumToCode(RecurTypeSelection.UpToEndDate)
                            If recurringPayElement.EndDate <= View.EndDate Then
                                If Not regenerate Then
                                    AddPayElement(employeeIdNo, recurringPayElement.PeriodicAmount, recurringPayElement.PayElementIdNo, 0, payrollDetailIdNo, recurringPayElement.IdNo)
                                Else
                                    UpdatePayElement(employeeIdNo, recurringPayElement.PeriodicAmount, recurringPayElement.PayElementIdNo, payrollDetailIdNo, recurringPayElement.IdNo)
                                End If
                            End If
                        Case EnumToCode(RecurTypeSelection.WhileActive)
                            If Not regenerate Then
                                AddPayElement(employeeIdNo, recurringPayElement.PeriodicAmount, recurringPayElement.PayElementIdNo, 0, payrollDetailIdNo, recurringPayElement.IdNo)
                            Else
                                UpdatePayElement(employeeIdNo, recurringPayElement.PeriodicAmount, recurringPayElement.PayElementIdNo, payrollDetailIdNo, recurringPayElement.IdNo)
                            End If
                    End Select

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
                payrollPayElement.Generated = True
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

        Private Sub GenerateComputedPayElements(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32, dutyHoursRatio As Decimal)
            For Each earning As PayElementModel In _computedPayElements
                If earning.Active Then
                    Dim amount As Decimal
                    'If earning.PayElementCode = "VPD" Then
                    '    Debugger.Break()
                    'End If

                    amount = CalculateComputedPayElement(employeeIdNo, earning, dutyHoursRatio)
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

        Private Function CalculateComputedPayElement(employeeIdNo As Int32, payElement As PayElementModel, dutyHoursRatio As Decimal) As Decimal
            Dim amount As Decimal
            Dim rate As Decimal
            If payElement.CalculationType = _calcTypeFixedRate Then
                Dim payElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = payElement.IdNo)
                If payElementModel IsNot Nothing Then
                    rate = ComputePayAmount(_payFrequency, payElementModel.Amount, payElement.Unit)
                    Dim qty As Decimal = ComputeQuantity(employeeIdNo, payElement.Unit)
                    amount = rate * qty
                Else
                    amount = 0
                End If
            ElseIf payElement.CalculationType = _calcTypeFactor Then
                Dim bpEarning As PayElementModel = _payElementsService.GetRecordByIdNo(Of PayElementModel)(payElement.BasePaymentIdNo)
                If bpEarning.Summary Then
                    Dim bpAmount As Decimal
                    bpAmount = ComputeSummaryAmount(employeeIdNo, payElement.BasePaymentIdNo)
                    rate = ComputeFactoredAmount(employeeIdNo, bpAmount, payElement.FactorValue, payElement.FactorType, dutyHoursRatio)
                    Dim qty = ComputeQuantity(employeeIdNo, payElement.QuantityType, dutyHoursRatio)
                    amount = qty * rate
                    If amount > bpAmount Then
                        amount = bpAmount
                    End If
                Else
                    Dim bpPayElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = payElement.BasePaymentIdNo)
                    If bpPayElementModel IsNot Nothing Then

                        Dim qty = ComputeQuantity(employeeIdNo, payElement.QuantityType)
                        Dim bpAmount = ComputeFactoredAmount(employeeIdNo, bpPayElementModel.Amount, payElement.FactorValue, payElement.FactorType, dutyHoursRatio)
                        amount = qty * bpAmount
                        If amount > bpPayElementModel.Amount Then
                            amount = bpPayElementModel.Amount
                        End If

                    End If
                End If
            End If
            Return amount
        End Function

        Private Function ComputeFactoredAmount(employeeIdNo As Int32, amount As Decimal, factorValue As Decimal, factorType As String, dutyHoursRatio As Decimal)
            Dim factoredAmount As Decimal
            If factorType = _factorPercentType Then
                factoredAmount = amount * factorValue * 0.01D
            ElseIf factorType = _factorMultiplyType Then
                factoredAmount = amount * factorValue
            ElseIf factorType = _factorDivideType Then
                If factorValue <> 0 Then
                    factoredAmount = amount / factorValue
                End If
            ElseIf factorType = _factorComplementDutyHoursRatio Then
                factoredAmount = amount * (1 - dutyHoursRatio)
            End If
            Return factoredAmount
        End Function

        Private Function GetEmployeeDutyHoursRatio(employeeIdNo As Int32)
            Dim employee As Object = Service.GetFieldsWithIdNo(employeeIdNo, "Employee", "DutyHours,ActualDutyHours")
            Return employee.ActualDutyHours / employee.DutyHours
        End Function

        Private Function ComputeSummaryAmount(employeeIdNo As Int32, earningIdNo As Int16) As Decimal
            Dim summaryAmount As Decimal
            Dim payElementItems As List(Of PayElementItemModel) = _payElementItemsService.GetRecordsWithGroupIdNo(Of PayElementItemModel)(earningIdNo)
            For Each payElementItem As PayElementItemModel In payElementItems
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

        Private Function ComputeSummaryItemAmount(amount As Decimal, factorValue As Decimal, factorType As String)
            Dim factoredAmount As Decimal
            If factorType = _factorPercentType Then
                factoredAmount = amount * factorValue * 0.01D
            ElseIf factorType = _factorMultiplyType Then
                factoredAmount = amount * factorValue
            ElseIf factorType = _factorDivideType Then
                If factorValue <> 0 Then
                    factoredAmount = amount / factorValue
                End If
            End If
            Return factoredAmount
        End Function

        'Private Function ComputeDeductionAmount(deduction As PayElementModel, daysAbsentWithoutPay As Decimal, basePayment As EmployeePayElementModel) As Decimal
        '    'Debugger.Break()
        '    Dim daysToCompute As Decimal
        '    Dim amount As Decimal
        '    If _deductionComputationMethod = "DaysInMonth" Then
        '        daysToCompute = daysAbsentWithoutPay
        '        amount = Math.Round(basePayment.Amount / _daysInTheMonth * daysToCompute, 2)
        '    ElseIf _deductionComputationMethod = "30Days" Then
        '        If daysAbsentWithoutPay <= 15D Then
        '            daysToCompute = daysAbsentWithoutPay
        '        Else
        '            daysToCompute = 30D - (CDec(DateTime.DaysInMonth(Year(_endDate), Month(_endDate))) - daysAbsentWithoutPay)
        '        End If
        '        amount = Math.Round(basePayment.Amount / 30D * daysToCompute, 2)
        '    End If
        '    Return amount
        'End Function

        Private Sub CreatePayrollDetails()
            Dim savedPayrollDetail As New PayrollDetailModel
            Dim savedPayrollDetails As New List(Of PayrollDetailModel)
            'Dim savedPayrollDetailsModel As New List(Of PayrollDetailModel)
            savedPayrollDetails = _payrollDetailsService.GetRecordsWithGroupIdNo(Of PayrollDetailModel)(_payrollIdNo)
            Dim employee As Object
            'GlobalVariables.Mapper.Map(savedPayrollDetails, savedPayrollDetailsModel)
            If savedPayrollDetails.Count() = 0 Then
                For Each currentPayrollAttendance In View.PayrollAttendance
                    Dim newPayrollDetail As New PayrollDetailModel
                    newPayrollDetail.EmployeeIdNo = currentPayrollAttendance.EmployeeIdNo
                    newPayrollDetail.PayrollIdNo = View.IdNo
                    employee = Service.GetFieldsWithIdNo(currentPayrollAttendance.EmployeeIdNo, "Employee", "SponsorType,PaymentMethod")
                    If employee.SponsorType <> EnumToCode(SponsorTypeSelection.Others) And employee.SponsorType <> EnumToCode(SponsorTypeSelection.Sponsor) And employee.PaymentMethod = EnumToCode(PayrollPaymentMethodSelection.BankTransfer) Then
                        newPayrollDetail.BankTransfer = True
                    Else
                        newPayrollDetail.BankTransfer = False
                    End If
                    newPayrollDetail.Selected = True
                    _payrollDetailsModel.Add(newPayrollDetail)
                Next
            Else
                For Each currentPayrollAttendance In View.PayrollAttendance
                    ' add only selected records and re-process information
                    Dim newPayrollDetail As New PayrollDetailModel
                    newPayrollDetail.EmployeeIdNo = currentPayrollAttendance.EmployeeIdNo
                    savedPayrollDetail = savedPayrollDetails.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = currentPayrollAttendance.EmployeeIdNo)
                    If savedPayrollDetail IsNot Nothing Then
                        newPayrollDetail.IdNo = savedPayrollDetail.IdNo
                        newPayrollDetail.BankTransfer = savedPayrollDetail.BankTransfer
                    End If
                    employee = Service.GetFieldsWithIdNo(currentPayrollAttendance.EmployeeIdNo, "Employee", "SponsorType,PaymentMethod")
                    'If employee.SponsorType <> EnumToCode(SponsorTypeSelection.Others) And employee.SponsorType <> EnumToCode(SponsorTypeSelection.Sponsor) And employee.PaymentMethod = EnumToCode(PayrollPaymentMethodSelection.BankTransfer) Then
                    '    newPayrollDetail.BankTransfer = True
                    'Else
                    '    newPayrollDetail.BankTransfer = False
                    'End If
                    newPayrollDetail.Selected = currentPayrollAttendance.Selected
                    _payrollDetailsModel.Add(newPayrollDetail)
                Next
                'For Each item In savedPayrollDetails
                '    ' add non selected records as-is, selected records are already added above
                '    Dim newPayrollDetail As New PayrollDetailModel
                '    newPayrollDetail = _payrollDetailsModel.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = item.EmployeeIdNo)
                '    If newPayrollDetail Is Nothing Then
                '        ' item not yet in the 'selected' records, add it
                '        _payrollDetailsModel.Add(item)
                '    Else
                '        Dim x = 1
                '        ' already added, just ignore them
                '    End If
                'Next
            End If
            For Each employeeAttendance In View.PayrollOvertime
                savedPayrollDetail = _payrollDetailsModel.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
                If savedPayrollDetail Is Nothing Then
                    savedPayrollDetail = savedPayrollDetails.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
                    If savedPayrollDetail Is Nothing Then
                        savedPayrollDetail = New PayrollDetailModel
                        savedPayrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo
                        savedPayrollDetail.PayrollIdNo = View.IdNo
                        _payrollDetailsModel.Add(savedPayrollDetail)
                    End If
                End If
            Next

            _computedPayElements = _payElementsService.GetDaoRecords(Of PayElementModel)("PayElementType = '" & _computedType & "' and Summary=0")
            _globalEarnings = _payElementsService.GetDaoRecords(Of PayElementModel)("CalculationType = '" & _globalType & "' and not Summary=0")
            Dim otWorkHoursService As New AccountsService("OtWorkHour")
            _otWorkHoursModel = otWorkHoursService.GetRecordsWithGroupIdNo(Of OtWorkHourModel)(_payrollIdNo)
            Dim dtPayrollDetailInsertTable As New DataTable
            Dim dtPayrollDetailUpdateTable As New DataTable
            CreateDataTable(dtPayrollDetailInsertTable, {
                                             {"BankTransfer", GetType(Boolean)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
            CreateDataTable(dtPayrollDetailUpdateTable, {
                                             {"BankTransfer", GetType(Boolean)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"IdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })

            For Each item As PayrollDetailModel In _payrollDetailsModel
                If item.IdNo = 0 Then
                    Dim dataRow As DataRow
                    dataRow = dtPayrollDetailInsertTable.NewRow()
                    dataRow("BankTransfer") = item.BankTransfer
                    dataRow("EmployeeIdNo") = item.EmployeeIdNo
                    dataRow("PayrollIdNo") = View.IdNo
                    dtPayrollDetailInsertTable.Rows.Add(dataRow)
                Else
                    Dim dataRow As DataRow
                    dataRow = dtPayrollDetailUpdateTable.NewRow()
                    dataRow("BankTransfer") = item.BankTransfer
                    dataRow("IdNo") = item.IdNo
                    dataRow("EmployeeIdNo") = item.EmployeeIdNo
                    dataRow("PayrollIdNo") = item.PayrollIdNo
                    dtPayrollDetailUpdateTable.Rows.Add(dataRow)
                End If
            Next
            _payrollDetailsService.UpdateInsertTvp(dtPayrollDetailUpdateTable, dtPayrollDetailInsertTable, View.IdNo)
        End Sub

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

        Private Function ComputeQuantity(employeeIdNo As Int32, quantityType As String, Optional dutyRatio As Decimal = 1)
            Dim quantity As Decimal?
            If quantityType = _hoursWorkedType Then
                quantity = GetOtWorkHourValues(employeeIdNo, "HoursWorked")
            ElseIf quantityType = _daysLeaveWithPayType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysAbsentWithPay") * dutyRatio
            ElseIf quantityType = _daysOffType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysOff") * dutyRatio
            ElseIf quantityType = _daysPresentType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysPresent") * dutyRatio
            ElseIf quantityType = _daysLeaveWithoutPayType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysAbsentWithoutPay") * dutyRatio
            ElseIf quantityType = _daysVacationType Then
                quantity = GetAttendanceValues(employeeIdNo, "DaysVacationLeave") * dutyRatio
            ElseIf quantityType = _daysPaidType Then
                Dim attendanceItem As AttendanceItemModel = _attendanceItemService.GetRecordByIdNo(Of AttendanceItemModel)(employeeIdNo)
                quantity = (attendanceItem.DaysPresent + attendanceItem.DaysAbsentWithPay + attendanceItem.DaysOff + attendanceItem.DaysVacationLeave) * dutyRatio
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

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int16)(View.IdNo, "AttendanceItem", "PayrollIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "EmployeeAbsence", "PayrollIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "OtWorkHour", "PayrollIdNo") Then
                Return True
            ElseIf CheckDependentRecords(View.IdNo, "PayrollDetail", "PayrollIdNo") Then
                Return True
            End If
            Return False
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

        Protected Overrides Function IsBizDataValid() As Boolean
            Dim retValue = True
            If MyBase.IsBizDataValid() Then
                For Each item In View.PayrollAttendance
                    If item.DaysPresent < 0 Then
                        'Messaging.Show("MsgNegativeDaysPresent")
                        Messaging.ShowPmMessage(True, "MsgNegativeDaysPresent", {"lineNumber", item.Sequence.ToString()})
                        retValue = False
                        Exit For
                    End If
                Next
            End If
            Return retValue
        End Function

        Private Sub OnClearAllEmployeeId(ByVal bsData As BindingSource, clear As Boolean)
            For Each item In bsData
                item.Selected = clear
            Next item
        End Sub

        Public Sub PostPayroll()
            _payrollIdNo = View.IdNo
            If View.PayrollAttendance.Count() = 0 And View.PayrollOvertime.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendanceOt")
            Else
                Dim payelementsModel As New List(Of PayElementModel)
                payelementsModel = _payElementsService.GetDaoRecords()
                Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
                Dim counter As Integer = 0
                _savedPayrollPayElements = _payrollPayElementsService.GetRecordsWithGroupIdNo(Of PayrollPayElementModel)(_payrollIdNo)
                progressDisplayForm.Show()
                progressDisplayForm.InitializeDisplay(_savedPayrollPayElements.Count())
                'Dim payrollDetailIdNo As Int32
                'Dim payElementIdNo As Int16
                'For Each payrollPayElement In _savedPayrollPayElements
                '    payElementIdNo = payrollPayElement.PayElementIdNo

                '    If PayrollDetailModel.IdNo = 0 Then
                '        payrollDetailIdNo = _payrollDetailsService.AddRecord(PayrollDetailModel)
                '    Else
                '        payrollDetailIdNo = PayrollDetailModel.IdNo
                '    End If
                '    CreatePayrollPayElements(PayrollDetailModel, regenerate, payrollDetailIdNo)
                '    counter = counter + 1
                '    progressDisplayForm.UpdateProgressBar(counter)
                'Next

                'Dim counter As Integer = 0
                'Dim progressDisplayForm = New CBaseControlsLibrary.DisplayProgressForm
                'progressDisplayForm.Show()
                'progressDisplayForm.InitializeDisplay(_payrollDetailsModel.Count() + 2)
                'If regenerate Then
                '    _savedPayrollPayElements = _payrollPayElementsService.GetRecordsWithGroupIdNo(Of PayrollPayElementModel)(_payrollIdNo)
                '    Dim payrollDetailIdNo As Int32
                '    For Each payrollDetailModel In _payrollDetailsModel
                '        If payrollDetailModel.Selected Then
                '            If payrollDetailModel.IdNo = 0 Then
                '                payrollDetailIdNo = _payrollDetailsService.AddRecord(payrollDetailModel)
                '            Else
                '                payrollDetailIdNo = payrollDetailModel.IdNo
                '            End If
                '            CreatePayrollPayElements(payrollDetailModel, regenerate, payrollDetailIdNo)
                '        End If
                '        counter = counter + 1
                '        progressDisplayForm.UpdateProgressBar(counter)
                '    Next
                '    For Each item In _savedPayrollPayElements
                '        'Dim dataRow As DataRow
                '        Dim payrollAttendance As AttendanceItemView
                '        payrollAttendance = View.PayrollAttendance.Find(Function(c) c.EmployeeIdNo = item.EmployeeIdNo)
                '        If payrollAttendance Is Nothing Then
                '            _payrollPayElements.Add(item)
                '        Else
                '            If payrollAttendance.Selected Then
                '                If item.Generated Then
                '                    ' ignore these records they have already been regenerated
                '                Else
                '                    _payrollPayElements.Add(item)
                '                End If
                '            Else
                '                _payrollPayElements.Add(item)
                '            End If
                '        End If
                '    Next
                '    For Each item In _payrollPayElements
                '        Dim dataRow As DataRow
                '        If item.IdNo = 0 Then
                '            dataRow = dtGeneralJournalItem.NewRow()
                '        Else
                '            dataRow = dtPayrollPayElementUpdateTable.NewRow()
                '            dataRow("IdNo") = item.IdNo
                '        End If
                '        dataRow("Amount") = item.Amount
                '        dataRow("Generated") = item.Generated
                '        dataRow("PayElementIdNo") = item.PayElementIdNo
                '        dataRow("PayrollDetailIdNo") = item.PayrollDetailIdNo
                '        dataRow("RecurringPayElementIdNo") = item.RecurringPayElementIdNo
                '        If item.IdNo = 0 Then
                '            dtGeneralJournalItem.Rows.Add(dataRow)
                '        Else
                '            dtPayrollPayElementUpdateTable.Rows.Add(dataRow)
                '        End If
                '    Next
                'Else
                '    ' payrolldetails already saved and generated
                '    ' so re-read the saved data because we need their linked idno for the
                '    ' payrollpayelementdetails
                '    _payrollDetailsModel = _payrollDetailsService.GetRecordsWithGroupIdNo(Of PayrollDetailModel)(_payrollIdNo)
                '    For Each payrollDetailModel In _payrollDetailsModel
                '        CreatePayrollPayElements(payrollDetailModel, regenerate, payrollDetailModel.IdNo)
                '        counter = counter + 1
                '        progressDisplayForm.UpdateProgressBar(counter)
                '    Next
                '    For Each item In _payrollPayElements
                '        Dim dataRow As DataRow
                '        dataRow = dtGeneralJournalItem.NewRow()
                '        dataRow("Amount") = item.Amount
                '        dataRow("Generated") = True
                '        dataRow("PayElementIdNo") = item.PayElementIdNo
                '        dataRow("PayrollDetailIdNo") = item.PayrollDetailIdNo
                '        dataRow("RecurringPayElementIdNo") = item.RecurringPayElementIdNo
                '        dtGeneralJournalItem.Rows.Add(dataRow)
                '    Next
                'End If
                'counter = counter + 1
                'If regenerate Then
                '    _payrollPayElementsService.UpdateInsertTvp(dtPayrollPayElementUpdateTable, dtGeneralJournalItem, _payrollIdNo)
                'Else
                '    _payrollPayElementsService.InsertTvp(dtGeneralJournalItem)
                'End If
                'dtPayrollPayElementUpdateTable.Clear()
                'dtGeneralJournalItem.Clear()
                '_payrollPayElements.Clear()
                'progressDisplayForm.UpdateProgressBar(counter + 1)
                'progressDisplayForm.Close()
                ''Messaging.Show(True, "MsgPayrollGenerationCompleted")
                'Beep()
            End If
            'End If
        End Sub

    End Class

End Namespace