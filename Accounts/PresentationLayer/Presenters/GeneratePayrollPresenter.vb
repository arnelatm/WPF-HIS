Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class GeneratePayrollPresenter
        Inherits AccountsPresenter(Of IView, PayrollModel)

        Private _dtInsertTable As New DataTable
        Private _dtUpdateTable As New DataTable

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            ModelPresenter = New ModelAccounts("Payroll")
            TableName = "Payroll"
            SortOrderKey = "IdNo"
            OriginalModel = New PayrollModel()
            DataModel = New PayrollModel()
            CreateDataTable(_dtInsertTable, {{"Amount", GetType(Decimal)},
                                             {"EarningIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
            CreateDataTable(_dtUpdateTable, {{"Amount", GetType(Decimal)},
                                             {"EarningIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"IdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
        End Sub

        Public Sub GenerateEarnings(ByVal payrollIdNo As Int16, ByVal startDate As Date, ByVal endDate As Date)
            Dim attendance As List(Of AttendanceItem)
            Dim attendanceItemDao = New AttendanceItemDao
            attendance = attendanceItemDao.GetRecordsWithIdNo(payrollIdNo)
            If attendance.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendance")
            Else
                Dim payrollEarningDao = New PayrollEarningDao
                Dim payEarnings As New List(Of PayrollEarning)
                payEarnings = payrollEarningDao.GetRecordsWithIdNo(payrollIdNo)
                If payEarnings.Count() = 0 Then
                    GenerateEmployeeEarnings(payrollIdNo, attendance)
                Else
                    If Messaging.Show(True, "AskIfRegeneratePayroll",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        ReGenerateEmployeeEarnings(payEarnings, payrollIdNo, attendance)
                    End If
                End If
            End If
        End Sub

        Private Sub ReGenerateEmployeeEarnings(ByRef payEarnings As List(Of PayrollEarning), payrollIdNo As Short, attendance As List(Of AttendanceItem))
            Dim payrollEarningDao = New PayrollEarningDao
            Dim employeeEarningDao = New EmployeeEarningDao
            Dim earningsDao = New EarningDao
            Dim nPaidDays As Decimal
            Dim empEarnings As List(Of EmployeeEarning)
            Dim regularEarning = EnumToCode(EarningTypeSelection.Regular)
            Dim fixedEarning = EnumToCode(CalculationTypeSelection.Fixed)
            Dim insertDataRow As DataRow = Nothing
            Dim updateDataRow As DataRow = Nothing
            _dtInsertTable.Clear()
            _dtUpdateTable.Clear()
            For Each employeeAttendance In attendance
                'Dim earning As New PayrollEarning
                nPaidDays = employeeAttendance.DaysPresent + employeeAttendance.DaysAbsentWithPay + employeeAttendance.DaysOff
                empEarnings = New List(Of EmployeeEarning)
                empEarnings = employeeEarningDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
                For Each empEarning In empEarnings
                    Dim earning As Earning
                    earning = earningsDao.GetRecordById(empEarning.EarningIdNo)
                    If empEarning.EmployeeIdNo = 1 Then
                        Debugger.Break()
                    End If
                    If earning.EarningType = regularEarning Then
                        If earning.CalculationType = fixedEarning Then
                            Dim earn As PayrollEarning = payEarnings.Find(Function(value As PayrollEarning)
                                                                              Return value.EmployeeIdNo = empEarning.EmployeeIdNo And value.EarningIdNo = empEarning.EarningIdNo
                                                                          End Function)
                            If earn Is Nothing Then
                                insertDataRow = _dtInsertTable.NewRow()
                                insertDataRow("Amount") = empEarning.Amount
                                insertDataRow("EarningIdNo") = empEarning.EarningIdNo
                                insertDataRow("EmployeeIdNo") = employeeAttendance.EmployeeIdNo
                                insertDataRow("PayrollIdNo") = payrollIdNo
                                _dtInsertTable.Rows.Add(insertDataRow)
                            Else
                                updateDataRow = _dtUpdateTable.NewRow()
                                updateDataRow("Amount") = empEarning.Amount
                                updateDataRow("EarningIdNo") = empEarning.EarningIdNo
                                updateDataRow("EmployeeIdNo") = empEarning.EmployeeIdNo
                                updateDataRow("IdNo") = earn.IdNo
                                updateDataRow("PayrollIdNo") = payrollIdNo
                                _dtUpdateTable.Rows.Add(updateDataRow)
                            End If

                        End If
                    End If
                Next
            Next
            payrollEarningDao.DelUpdateTvp(_dtUpdateTable, payrollIdNo)
            payrollEarningDao.InsertTvp(_dtInsertTable)
        End Sub

        Private Sub GenerateEmployeeEarnings(payrollIdNo As Short, attendance As List(Of AttendanceItem))
            Dim payrollEarningDao = New PayrollEarningDao
            Dim employeeEarningDao = New EmployeeEarningDao
            Dim earningsDao = New EarningDao
            Dim nPaidDays As Decimal
            Dim empEarnings As List(Of EmployeeEarning)
            Dim regularEarning = EnumToCode(EarningTypeSelection.Regular)
            Dim fixedEarning = EnumToCode(CalculationTypeSelection.Fixed)
            Dim workRow As DataRow = Nothing
            _dtInsertTable.Clear()
            For Each employeeAttendance In attendance
                'Dim earning As New PayrollEarning
                nPaidDays = employeeAttendance.DaysPresent + employeeAttendance.DaysAbsentWithPay + employeeAttendance.DaysOff
                empEarnings = New List(Of EmployeeEarning)
                empEarnings = employeeEarningDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
                For Each empEarning In empEarnings
                    Dim earning As Earning
                    earning = earningsDao.GetRecordById(empEarning.EarningIdNo)
                    If earning.EarningType = regularEarning Then
                        If earning.CalculationType = fixedEarning Then
                            workRow = _dtInsertTable.NewRow()
                            workRow("Amount") = empEarning.Amount
                            workRow("EarningIdNo") = empEarning.EarningIdNo
                            workRow("EmployeeIdNo") = employeeAttendance.EmployeeIdNo
                            workRow("PayrollIdNo") = payrollIdNo
                            _dtInsertTable.Rows.Add(workRow)
                        End If
                    End If
                Next
            Next
            payrollEarningDao.InsertTvp(_dtInsertTable)
        End Sub

        'Public Function PayrollEarningFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
        '    workRow("Amount") = itemDataView.Amount
        '    workRow("EarningIdNo") = itemDataView.EarningIdNo
        '    workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
        '    workRow("PayrollIdNo") = itemDataView.PayrollIdNo
        '    Return True
        'End Function

        'Public Function PayrollEarningFilter(ByVal obj As Object) As Boolean
        '    'If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
        '    '    Return False
        '    'End If
        '    Return True
        'End Function

    End Class

End Namespace