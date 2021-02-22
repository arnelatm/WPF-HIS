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

    Public Class PayrollDetailPresenter
        Inherits AccountsPresenter(Of IPayrollDetailView, PayrollDetailModel)

        'Protected DtInsertTable As New DataTable
        'Protected DtUpdateTable As New DataTable
        'Protected DtEarnInsertTable As New DataTable
        'Protected DtEarnUpdateTable As New DataTable
        Private _attendanceItemModel
        Private _reinitialize As Boolean = False
        Private _PayrollDetailEarning

        Public Sub New(view As IPayrollDetailView)
            MyBase.New(view)
            TreeViewMainField = "EmployeeName"
            TreeViewSecondaryField = "EmployeeCode"
            TableName = "PayrollDetail_View"
            SortOrderKey = "EmployeeName"
            ModelPresenter = New ModelAccounts("PayrollDetail")
            OriginalModel = New PayrollDetailModel
            DataModel = New PayrollDetailModel
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            _attendanceItemModel = New ModelAccounts("AttendanceItem", Nothing, Nothing)


            'CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            '                                {"EarningIdNo", GetType(Int16)},
            '                                {"EmployeeIdNo", GetType(Int32)},
            '                                {"PayrollDetailIdNo", GetType(Int32)}
            '                               })

            'CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            '                                {"EarningIdNo", GetType(Int16)},
            '                                {"EmployeeIdNo", GetType(Int32)},
            '                                {"IdNo", GetType(Int32)},
            '                                {"PayrollDetailIdNo", GetType(Int32)}
            '                               })

        End Sub

        'Public Sub InitializeMonthlyPayrollDetail(payCycleRecord As PayCycle)
        '    If View.StartDate = Nothing And View.EndDate = Nothing Then
        '        Dim nIdNoMax As Int32
        '        Dim maxRecord As PayrollDetailModel
        '        Dim payMonthText As String = "PayrollDetail for the Month of"
        '        Dim PayrollDetailText As String = "PayrollDetail for the Period"
        '        nIdNoMax = ModelPresenter.GetMaxValueFiltered("EndDate", "PayrollDetail", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
        '        maxRecord = ModelPresenter.GetRecordById(Of PayrollDetailModel)(nIdNoMax)
        '        View.StartDate = maxRecord.EndDate.AddDays(1)
        '        Dim arabicCulture As New CultureInfo("ar-ae", False)
        '        If View.StartDate.Day = 1 Then
        '            View.EndDate = View.StartDate.AddMonths(1).AddDays(-1)
        '            View.PayrollDetailName = payMonthText & " " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
        '            View.PayrollDetailNameAra = Messaging.TranslateCaption(payMonthText, "ar-SA") + GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate) - 1) & " " & Year(View.EndDate).ToString()
        '        Else
        '            View.EndDate = maxRecord.EndDate.AddMonths(1)
        '            View.PayrollDetailName = PayrollDetailText & " " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
        '            View.PayrollDetailNameAra = Messaging.TranslateCaption(PayrollDetailText, "ar-SA") & " " & GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
        '        End If
        '        View.PayrollDetailCode = "M" + View.EndDate.ToString("yyMM")
        '    End If
        'End Sub

        'Public Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If Not CancelSave Then
        '        ViewToDataTables(View.PayrollDetailAttendance, DtInsertTable, DtUpdateTable, AddressOf AttendanceItemFillData, AddressOf AttendanceItemFilter, "IdNo", "")
        '    End If
        '    'For Each item In View.PayrollDetailAttendance
        '    '    If item.Equals(DBNull.Value) Then
        '    '        item.Notes = ""
        '    '    End If
        '    '    If item.Notes Is Nothing Then
        '    '        item.Notes = ""
        '    '    End If
        '    'Next
        'End Sub

        'Public Sub InitializeAttendance()
        '    'Dim payFrequency = GetFieldWithIdNo(View.PayCycleIdNo, "PayCycle", "PayFrequency")
        '    'Dim employeeFilter = "PayCycleIdNo = " & View.PayCycleIdNo.ToString()
        '    'Dim activeEmployees = GetFilteredRecords("Employee", "EmployeeName", employeeFilter, {"IdNo", "EmployeeName", "HiredDate", "ReleasedDate"})
        '    ''Dim earningDao = New EarningDao
        '    ''Dim earnings = earningDao.GetAll()
        '    'Dim numberOfEmployees = Int(activeEmployees.Count() / 4)
        '    'Dim daysInPeriod As Int16
        '    'Dim daysOffInPeriod As Int16
        '    'Dim seq As Int16
        '    'Dim dateHired As Date
        '    'Dim dateReleased As Date?
        '    'Dim empId As Int32
        '    'Dim empName As String
        '    'Dim empFound As Boolean = False
        '    'seq = View.PayrollDetailAttendance.Count() + 1
        '    'daysInPeriod = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
        '    'daysOffInPeriod = FridaysInPeriod(View.StartDate, View.EndDate)
        '    'If View.PayrollDetailAttendance.Any() Then
        '    '    _reinitialize = True
        '    'Else
        '    '    _reinitialize = False
        '    'End If
        '    'For i = 1 To numberOfEmployees
        '    '    'Dim empEarnings As List(Of EmployeeEarning) = earningDao.GetRecordsWithIdNo(emp, "sequence")
        '    '    'Dim filter As String
        '    '    'filter = "EmployeeIdNo = " & emp.ToString()
        '    '    'Dim employeeEarnings = PresenterObj.GetFilteredRecords("EmployeeEarning", "", filter, {"EarningIdNo", "Amount"})

        '    '    empId = activeEmployees(i * 4 - 4)
        '    '    empName = activeEmployees(i * 4 - 3)
        '    '    dateHired = activeEmployees(i * 4 - 2)
        '    '    dateReleased = IIf(IsDBNull(activeEmployees(i * 4 - 1)), Nothing, activeEmployees(i * 4 - 1))

        '    '    If _reinitialize Then
        '    '        Dim empAttendance As AttendanceItemView
        '    '        empAttendance = View.PayrollDetailAttendance.Find(Function(c) c.EmployeeIdNo = empId)
        '    '        If empAttendance Is Nothing Then
        '    '            empFound = False
        '    '        Else
        '    '            empFound = True
        '    '            'empAttendance.DaysTotal = DateDiff(DateInterval.Day, dateHired, eDate) + 1
        '    '            'empAttendance.DaysOff = FridaysInPeriod(dateHired, eDate)
        '    '            If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
        '    '                UpdateEmployeeAttendance(empAttendance, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
        '    '                If empAttendance.DaysAbsentWithoutPay <> empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysPresent Then
        '    '                    empAttendance.DaysAbsentWithoutPay = empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysPresent
        '    '                End If
        '    '            Else
        '    '                View.PayrollDetailAttendance.Remove(empAttendance)
        '    '            End If
        '    '        End If
        '    '    End If
        '    '    If empFound Then
        '    '        Continue For
        '    '    End If

        '    '    If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
        '    '        AddEmployeeAttendance(dateHired, dateReleased, empId, empName, daysInPeriod, daysOffInPeriod, seq)
        '    '        seq = seq + 1
        '    '    End If
        '    '    'For Each employeeEarning In employeeEarnings

        '    '    'Next
        '    'Next
        '    'If _reinitialize Then
        '    '    Dim i As Int16 = 1
        '    '    For Each item In View.PayrollDetailAttendance
        '    '        item.Sequence = i
        '    '        i = i + 1
        '    '    Next
        '    'End If
        '    'For i = 1 To Int(Data.Count / 3)
        '    '    Dim tData As New ActiveEmployee
        '    '    tData.IdNo = Data(i * 3 - 3)
        '    '    If Data(i * 3 - 1) Is DBNull.Value Then
        '    '        tData.PayGroupIdNo = 0
        '    '    Else
        '    '        tData.PayGroupIdNo = Data(i * 3 - 1)
        '    '    End If
        '    '    lEmployeePayGroups.Add(tData)
        '    'Next
        '    'For Each employee In lEmployeePayGroups
        '    '    If employee.PayGroupIdNo = node.Tag Then
        '    '        node.Nodes.Add(New TreeNode With {.Text = employee.Name,
        '    '                                   .Tag = employee.IdNo,
        '    '                                   .Name = employee.Name
        '    '                                 }
        '    '              )
        '    '    End If
        '    'Next employee
        'End Sub

        'Public Sub AddEmployeeAttendance(ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal empId As Int16, ByVal empName As String, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16, ByVal seq As Int16)
        '    'Dim empAttendance As New AttendanceItemView
        '    'Dim daysOff As Int16
        '    'Dim daysTotal As Int16
        '    'ComputeTotalDaysNOff(daysTotal, daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
        '    'empAttendance.DaysTotal = daysTotal
        '    'empAttendance.DaysOff = daysOff
        '    'empAttendance.DaysPresent = daysTotal - daysOff
        '    'empAttendance.PayrollDetailIdNo = View.IdNo
        '    'empAttendance.EmployeeIdNo = empId
        '    'empAttendance.EmployeeName = empName
        '    'empAttendance.Sequence = seq
        '    'View.PayrollDetailAttendance.Add(empAttendance)
        'End Sub

        'Public Sub UpdateEmployeeAttendance(ByRef empAttendance As AttendanceItemView, ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16)
        '    Dim daysOff As Int16
        '    Dim daysTotal As Int16
        '    ComputeTotalDaysNOff(daysTotal, daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
        '    empAttendance.DaysTotal = daysTotal
        '    empAttendance.DaysOff = daysOff
        'End Sub

        'Private Sub ComputeTotalDaysNOff(ByRef daysTotal As Int16, ByRef daysOff As Int16, ByVal dateHired As Date, ByVal dateReleased As Date?, ByVal daysInPeriod As Int16, ByVal daysOffInPeriod As Int16)
        '    Dim eDate As Date
        '    If dateHired <= View.StartDate AndAlso (dateReleased Is Nothing OrElse dateReleased > View.EndDate) Then
        '        daysOff = daysOffInPeriod
        '        daysTotal = daysInPeriod
        '    Else
        '        If dateReleased Is Nothing OrElse dateReleased > View.EndDate Then
        '            eDate = View.EndDate
        '        Else
        '            Dim dDate As Date ' need to do this because Date? type is not accepted by DateAdd function
        '            dDate = dateReleased
        '            eDate = DateAndTime.DateAdd(DateInterval.Day, -1, dDate)
        '        End If
        '        daysTotal = DateDiff(DateInterval.Day, dateHired, eDate) + 1
        '        daysOff = FridaysInPeriod(dateHired, eDate)
        '    End If
        'End Sub

        'Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
        '    Dim passedValue As Integer = retVal
        '    retVal = UpdateChildData(_attendanceItemModel, DtUpdateTable, DtInsertTable, passedValue, "PayrollDetailIdNo")
        'End Sub

        'Private Sub AttendanceItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
        '    workRow("DaysAbsentWithoutPay") = itemDataView.DaysAbsentWithoutPay
        '    workRow("DaysAbsentWithPay") = itemDataView.DaysAbsentWithPay
        '    workRow("DaysOff") = itemDataView.DaysOff
        '    workRow("DaysPresent") = itemDataView.DaysPresent
        '    workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
        '    workRow("Overtime") = itemDataView.Overtime
        '    workRow("PayrollDetailIdNo") = View.IdNo
        'End Sub

        'Public Function AttendanceItemFilter(ByVal obj As Object) As Boolean
        '    'If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
        '    '    Return False
        '    'End If
        '    Return True
        'End Function

        'Public Shared Function FridaysInPeriod(ByVal begDate As Date, endDate As Date) As Integer
        '    Dim count As Integer
        '    Dim d As DateTime = begDate
        '    Do Until d = endDate
        '        If d.DayOfWeek = DayOfWeek.Friday Then
        '            count += 1
        '        End If
        '        d = d.AddDays(1)
        '    Loop
        '    Return count
        'End Function

    End Class

End Namespace