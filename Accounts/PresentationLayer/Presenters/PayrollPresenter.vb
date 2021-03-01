Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
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
        Private _overtimeItemModel
        Private _reinitialize As Boolean = False
        Private _payrollEarning

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
            _overtimeItemModel = New ModelAccounts("OvertimeItem", Nothing, Nothing)

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
            If View.StartDate = Nothing And View.EndDate = Nothing Then
                If payCycleRecord.PayCycleCode = "Month" Then
                    Dim nIdNoMax As Int32
                    Dim maxRecord As PayrollModel
                    Dim payMonthText As String = "Payroll for the Month of"
                    Dim PayrollText As String = "Payroll for the Period"
                    nIdNoMax = ModelPresenter.GetMaxValueFiltered("EndDate", "Payroll", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
                    maxRecord = ModelPresenter.GetRecordById(Of PayrollModel)(nIdNoMax)
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
            '    maxRecord = ModelPresenter.GetRecordById(Of PayrollModel)(nIdNoMax)
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
                ViewToDataTables(View.PayrollOvertime, DtOtInsertTable, DtOtUpdateTable, AddressOf OvertimeItemFillData, AddressOf OvertimeItemFilter, "IdNo", "")
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
                    Dim empOvertime As OvertimeItemView
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
            Dim empOvertime As New OvertimeItemView
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

        Private Sub OvertimeItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
            workRow("OvertimeRegular") = itemDataView.OvertimeRegular
            workRow("OvertimeHoliday") = itemDataView.OvertimeHoliday
            workRow("OvertimeSpecial") = itemDataView.OvertimeSpecial
            workRow("PayrollIdNo") = View.IdNo
        End Sub

        Public Function OvertimeItemFilter(ByVal obj As Object) As Boolean
            'If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
            '    Return False
            'End If
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

    End Class

End Namespace