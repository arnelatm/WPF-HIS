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

        Private _dtDeductionInsertTable As New DataTable
        Private _dtDeductionUpdateTable As New DataTable
        Private _dtEarningInsertTable As New DataTable
        Private _dtEarningUpdateTable As New DataTable
        Private ReadOnly _deductionsDao = New DeductionDao
        Private ReadOnly _employeeDeductionDao = New EmployeeDeductionDao
        Private ReadOnly _employeeEarningDao = New EmployeeEarningDao
        Private ReadOnly _earningsDao = New EarningDao

        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Account"
            ModelPresenter = New ModelAccounts("Payroll")
            TableName = "Payroll"
            SortOrderKey = "IdNo"
            OriginalModel = New PayrollModel()
            DataModel = New PayrollModel()
            CreateDataTable(_dtEarningInsertTable, {{"Amount", GetType(Decimal)},
                                             {"EarningIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
            CreateDataTable(_dtEarningUpdateTable, {{"Amount", GetType(Decimal)},
                                             {"EarningIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"IdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
            CreateDataTable(_dtDeductionInsertTable, {{"Amount", GetType(Decimal)},
                                                    {"DeductionIdNo", GetType(Int16)},
                                                    {"EmployeeIdNo", GetType(Int32)},
                                                    {"PayrollIdNo", GetType(Int16)}
                                                   })
            CreateDataTable(_dtDeductionUpdateTable, {{"Amount", GetType(Decimal)},
                                                    {"DeductionIdNo", GetType(Int16)},
                                                    {"EmployeeIdNo", GetType(Int32)},
                                                    {"IdNo", GetType(Int32)},
                                                    {"PayrollIdNo", GetType(Int16)}
                                                   })
        End Sub

        Public Sub GeneratePayroll(ByVal payrollIdNo As Int16, ByVal startDate As Date, ByVal endDate As Date, ByRef progressBar As ProgressBar)
            Dim attendance As List(Of AttendanceItem)
            Dim attendanceItemDao = New AttendanceItemDao
            attendance = attendanceItemDao.GetRecordsWithIdNo(payrollIdNo)
            If attendance.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendance")
            Else
                Dim payrollDeductionDao = New PayrollDeductionDao
                Dim payrollEarningDao = New PayrollEarningDao
                Dim payEarnings As List(Of PayrollEarning)
                Dim payDeductions As List(Of PayrollDeduction)
                payDeductions = payrollDeductionDao.GetRecordsWithIdNo(payrollIdNo)
                payEarnings = payrollEarningDao.GetRecordsWithIdNo(payrollIdNo)
                If payEarnings.Count() = 0 Then
                    GenerateEmployeePayroll(payrollIdNo, attendance, progressBar)
                Else
                    If Messaging.Show(True, "AskIfRegeneratePayroll",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        ReGenerateEmployeePayroll(payEarnings, payDeductions, payrollIdNo, attendance, progressBar)
                    End If
                End If
            End If
        End Sub

        Private Sub AddDeduction(employeeAttendance As AttendanceItem, empDeduction As EmployeeDeduction, payrollIdNo As Short)
            Dim insertDataRow As DataRow
            insertDataRow = _dtDeductionInsertTable.NewRow()
            insertDataRow("Amount") = empDeduction.Amount
            insertDataRow("DeductionIdNo") = empDeduction.DeductionIdNo
            insertDataRow("EmployeeIdNo") = employeeAttendance.EmployeeIdNo
            insertDataRow("PayrollIdNo") = payrollIdNo
            _dtDeductionInsertTable.Rows.Add(insertDataRow)
        End Sub

        Private Sub AddEarning(employeeAttendance As AttendanceItem, empEarning As EmployeeEarning, payrollIdNo As Short)
            Dim insertDataRow As DataRow
            insertDataRow = _dtEarningInsertTable.NewRow()
            insertDataRow("Amount") = empEarning.Amount
            insertDataRow("EarningIdNo") = empEarning.EarningIdNo
            insertDataRow("EmployeeIdNo") = employeeAttendance.EmployeeIdNo
            insertDataRow("PayrollIdNo") = payrollIdNo
            _dtEarningInsertTable.Rows.Add(insertDataRow)
        End Sub

        Private Sub GenerateDeductions(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim empDeductions As List(Of EmployeeDeduction)
            Dim deductionsDao = New DeductionDao
            Dim regularDeduction = EnumToCode(DeductionTypeSelection.Regular)
            Dim fixedDeduction = EnumToCode(CalculationTypeSelection.Fixed)
            Dim factoredDeduction = EnumToCode(CalculationTypeSelection.Factor)
            empDeductions = New List(Of EmployeeDeduction)
            empDeductions = _employeeDeductionDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                If deduction.DeductionType = regularDeduction Then
                    If deduction.CalculationType = fixedDeduction Then
                        AddDeduction(employeeAttendance, empDeduction, payrollIdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub GenerateEarnings(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim empEarnings As List(Of EmployeeEarning)
            Dim earningsDao = New EarningDao
            Dim employeeEarningDao = New EmployeeEarningDao
            Dim regularEarning = EnumToCode(EarningTypeSelection.Regular)
            Dim fixedEarning = EnumToCode(CalculationTypeSelection.Fixed)
            Dim factoredEarning = EnumToCode(CalculationTypeSelection.Factor)
            empEarnings = New List(Of EmployeeEarning)
            empEarnings = employeeEarningDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            For Each empEarning In empEarnings
                Dim earning As Earning
                earning = earningsDao.GetRecordById(empEarning.EarningIdNo)
                If earning.EarningType = regularEarning Then
                    If earning.CalculationType = fixedEarning Then
                        AddEarning(employeeAttendance, empEarning, payrollIdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub GenerateEmployeePayroll(ByVal payrollIdNo As Short, ByRef attendance As List(Of AttendanceItem), ByRef progressBar As ProgressBar)
            Dim payrollEarningDao = New PayrollEarningDao
            _dtEarningInsertTable.Clear()
            _dtDeductionInsertTable.Clear()
            progressBar.Value = 0
            progressBar.Maximum = attendance.Count() + 2
            progressBar.Visible = True
            Dim counter = 1
            For Each employeeAttendance In attendance
                GenerateEarnings(employeeAttendance, payrollIdNo)
                GenerateDeductions(employeeAttendance, payrollIdNo)
                progressBar.Value = progressBar.Value + 1
            Next
            payrollEarningDao.InsertTvp(_dtEarningInsertTable)
            progressBar.Value = progressBar.Value + 2
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
            progressBar.Visible = False
        End Sub

        Private Sub MakeDeductions(employeeAttendance As AttendanceItem, empDeduction As EmployeeDeduction, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
            Dim deduct As PayrollDeduction = payDeductions.Find(Function(value As PayrollDeduction)
                                                                    Return value.EmployeeIdNo = empDeduction.EmployeeIdNo And value.DeductionIdNo = empDeduction.DeductionIdNo
                                                                End Function)
            If deduct Is Nothing Then
                AddDeduction(employeeAttendance, empDeduction, payrollIdNo)
            Else
                UpdateDeduction(empDeduction, deduct, payrollIdNo)
            End If
        End Sub

        Private Sub MakeEarnings(employeeAttendance As AttendanceItem, empEarning As EmployeeEarning, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
            Dim earn As PayrollEarning = payEarnings.Find(Function(value As PayrollEarning)
                                                              Return value.EmployeeIdNo = empEarning.EmployeeIdNo And value.EarningIdNo = empEarning.EarningIdNo
                                                          End Function)
            If earn Is Nothing Then
                AddEarning(employeeAttendance, empEarning, payrollIdNo)
            Else
                UpdateEarning(empEarning, earn, payrollIdNo)
            End If
        End Sub

        Private Sub ReGenerateDeduction(ByRef employeeAttendance As AttendanceItem, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
            Dim empDeductions As List(Of EmployeeDeduction)
            Dim regularDeduction = EnumToCode(DeductionTypeSelection.Regular)
            Dim factoredDeduction = EnumToCode(CalculationTypeSelection.Factor)
            Dim fixedDeduction = EnumToCode(CalculationTypeSelection.Fixed)
            Dim earningAdjustment = EnumToCode(DeductionTypeSelection.EarningsAdjustment)
            empDeductions = _employeeDeductionDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                'If deduction.DeductionType = regularDeduction Then
                '    If deduction.CalculationType = factoredDeduction Then
                '        If deduction.
                '    ElseIf deduction.CalculationType = fixedDeduction Then
                '        MakeDeductions(employeeAttendance, empDeduction, payDeductions, payrollIdNo)
                '        End If
                '    End If
            Next
        End Sub

        Private Sub ReGenerateEarning(ByRef employeeAttendance As AttendanceItem, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
            Dim empEarnings As List(Of EmployeeEarning)
            Dim regularEarning = EnumToCode(EarningTypeSelection.Regular)
            Dim fixedEarning = EnumToCode(CalculationTypeSelection.Fixed)
            empEarnings = _employeeEarningDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            For Each empEarning In empEarnings
                Dim earning As Earning
                earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
                If earning.EarningType = regularEarning Then
                    If earning.CalculationType = fixedEarning Then
                        MakeEarnings(employeeAttendance, empEarning, payEarnings, payrollIdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub ReGenerateEmployeePayroll(ByRef payEarnings As List(Of PayrollEarning), ByRef payDeductions As List(Of PayrollDeduction), ByVal payrollIdNo As Short, ByRef attendance As List(Of AttendanceItem), ByRef progressBar As ProgressBar)
            Dim payrollDeductionDao = New PayrollDeductionDao
            Dim payrollEarningDao = New PayrollEarningDao
            _dtEarningInsertTable.Clear()
            _dtEarningUpdateTable.Clear()
            progressBar.Value = 0
            progressBar.Maximum = attendance.Count() + 2
            progressBar.Visible = True
            Dim counter = 1
            For Each employeeAttendance In attendance
                ReGenerateEarning(employeeAttendance, payEarnings, payrollIdNo)
                ReGenerateDeduction(employeeAttendance, payDeductions, payrollIdNo)
                progressBar.Value = progressBar.Value + 1
            Next
            payrollDeductionDao.UpdateInsertTvp(_dtDeductionUpdateTable, _dtDeductionInsertTable, payrollIdNo)
            payrollEarningDao.UpdateInsertTvp(_dtEarningUpdateTable, _dtEarningInsertTable, payrollIdNo)
            progressBar.Value = progressBar.Value + 2
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
            progressBar.Visible = False
        End Sub

        Private Sub UpdateDeduction(empDeduction As EmployeeDeduction, earn As PayrollDeduction, payrollIdNo As Short)
            Dim updateDataRow As DataRow
            updateDataRow = _dtDeductionUpdateTable.NewRow()
            updateDataRow("Amount") = empDeduction.Amount
            updateDataRow("DeductionIdNo") = empDeduction.DeductionIdNo
            updateDataRow("EmployeeIdNo") = empDeduction.EmployeeIdNo
            updateDataRow("IdNo") = earn.IdNo
            updateDataRow("PayrollIdNo") = payrollIdNo
            _dtDeductionUpdateTable.Rows.Add(updateDataRow)
        End Sub

        Private Sub UpdateEarning(empEarning As EmployeeEarning, earn As PayrollEarning, payrollIdNo As Short)
            Dim updateDataRow As DataRow
            updateDataRow = _dtEarningUpdateTable.NewRow()
            updateDataRow("Amount") = empEarning.Amount
            updateDataRow("EarningIdNo") = empEarning.EarningIdNo
            updateDataRow("EmployeeIdNo") = empEarning.EmployeeIdNo
            updateDataRow("IdNo") = earn.IdNo
            updateDataRow("PayrollIdNo") = payrollIdNo
            _dtEarningUpdateTable.Rows.Add(updateDataRow)
        End Sub

    End Class

End Namespace