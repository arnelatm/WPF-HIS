Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class PayPeriodPresenter
        Inherits AccountsPresenter(Of IPayPeriodView, PayPeriodModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private _attendanceItemModel

        Public Sub New(view As IPayPeriodView)
            MyBase.New(view)
            InitializerWithTv("PayPeriod")
            Ea = New EventAggregator()
            Ea.SubscribeEvent(Me)
            _attendanceItemModel = New ModelAccounts("AttendanceItem", Nothing, Nothing)

            CreateDataTable(DtInsertTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"PayPeriodIdNo", GetType(Int32)},
                                            {"Sequence", GetType(Int16)}
                                           })

            CreateDataTable(DtUpdateTable, {{"DaysAbsentWithoutPay", GetType(Decimal)},
                                            {"DaysAbsentWithPay", GetType(Decimal)},
                                            {"DaysOff", GetType(Decimal)},
                                            {"DaysPresent", GetType(Decimal)},
                                            {"EmployeeIdNo", GetType(Int32)},
                                            {"IdNo", GetType(Int32)},
                                            {"PayPeriodIdNo", GetType(Int32)},
                                            {"Sequence", GetType(Int16)}
                                           })

        End Sub

        Public Sub InitializeMonthlyPayroll(payCycleRecord As PayCycle)
            If View.StartDate = Nothing And View.EndDate = Nothing Then
                Dim nIdNoMax As Int32
                Dim maxRecord As PayPeriodModel
                Dim payMonthText As String = "Payroll for the Month of"
                Dim payPeriodText As String = "Payroll for the Period"
                nIdNoMax = ModelPresenter.GetMaxValueFiltered("EndDate", "PayPeriod", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString())
                maxRecord = ModelPresenter.GetRecordById(Of PayPeriodModel)(nIdNoMax)
                View.StartDate = maxRecord.EndDate.AddDays(1)
                Dim arabicCulture As New CultureInfo("ar-ae", False)
                If View.StartDate.Day = 1 Then
                    View.EndDate = View.StartDate.AddMonths(1).AddDays(-1)
                    View.PayPeriodName = payMonthText & " " & MonthName(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                    View.PayPeriodNameAra = Messaging.TranslateCaption(payMonthText, "ar-SA") + GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate) - 1) & " " & Year(View.EndDate).ToString()
                Else
                    View.EndDate = maxRecord.EndDate.AddMonths(1)
                    View.PayPeriodName = payPeriodText & " " & View.StartDate.ToString() & " to " & View.EndDate.ToString()
                    View.PayPeriodNameAra = Messaging.TranslateCaption(payPeriodText, "ar-SA") & " " & GetMonthNamesInCulture(arabicCulture)(Month(View.EndDate)) & " " & Year(View.EndDate).ToString()
                End If
                View.PayPeriodCode = "M" + View.EndDate.ToString("yyMM")
            End If
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.PayPeriodAttendance, DtInsertTable, DtUpdateTable, AddressOf AttendanceItemFillData, AddressOf AttendanceItemFilter)
            End If
            'For Each item In View.PayPeriodAttendance
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
            Dim employeeFilter = "Active = 1 and PayCycleIdNo = " & View.PayCycleIdNo.ToString()
            Dim activeEmployees = GetFilteredRecords("Employee", "EmployeeName", employeeFilter, {"IdNo", "EmployeeName"})
            'Dim earningDao = New EarningDao
            'Dim earnings = earningDao.GetAll()
            Dim NumberOfEmployees = Int(activeEmployees.Count() / 2)
            Dim numberOfDays As Long
            Dim daysOff As Int16
            numberOfDays = DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1
            daysOff = FridaysInPeriod(View.StartDate, View.EndDate)
            For i = 1 To NumberOfEmployees
                'Dim empEarnings As List(Of EmployeeEarning) = earningDao.GetRecordsWithIdNo(emp, "sequence")
                'Dim filter As String
                'filter = "EmployeeIdNo = " & emp.ToString()
                'Dim employeeEarnings = PresenterObj.GetFilteredRecords("EmployeeEarning", "", filter, {"EarningIdNo", "Amount"})
                Dim empAttendance As New AttendanceItemView
                empAttendance.PayPeriodIdNo = View.IdNo
                empAttendance.DaysPresent = numberOfDays - daysOff
                empAttendance.DaysOff = daysOff
                empAttendance.EmployeeIdNo = activeEmployees(i * 2 - 2)
                empAttendance.EmployeeName = activeEmployees(i * 2 - 1)
                empAttendance.Sequence = i
                empAttendance.DaysTotal = numberOfDays
                View.PayPeriodAttendance.Add(empAttendance)
                'For Each employeeEarning In employeeEarnings

                'Next
            Next
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

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_attendanceItemModel, DtUpdateTable, DtInsertTable, passedValue, "PayPeriodIdNo")
        End Sub

        Private Sub AttendanceItemFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("DaysAbsentWithoutPay") = itemDataView.DaysAbsentWithoutPay
            workRow("DaysAbsentWithPay") = itemDataView.DaysAbsentWithPay
            workRow("DaysOff") = itemDataView.DaysOff
            workRow("DaysPresent") = itemDataView.DaysPresent
            workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
            workRow("PayPeriodIdNo") = View.IdNo
        End Sub

        Public Function AttendanceItemFilter(ByVal obj As Object) As Boolean
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