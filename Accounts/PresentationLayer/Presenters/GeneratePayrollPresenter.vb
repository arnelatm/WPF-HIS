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
        Private ReadOnly _regularEarning = EnumToCode(EarningTypeSelection.Regular)
        Private ReadOnly _fixedAmount = EnumToCode(CalculationTypeSelection.FixedAmount)
        Private ReadOnly _fixedRate = EnumToCode(CalculationTypeSelection.FixedRate)
        Private ReadOnly _factor = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _variable = EnumToCode(CalculationTypeSelection.Variable)
        Private ReadOnly _global = EnumToCode(CalculationTypeSelection.Global)
        Private ReadOnly _regularDeduction = EnumToCode(DeductionTypeSelection.Regular)
        Private ReadOnly _factoredDeduction = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _overtimeHours = EnumToCode(PayRateUnitSelection.OvertimeHours)

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

        Private Sub AddDeduction(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, deductionIdNo As Short)
            Dim insertDataRow As DataRow
            insertDataRow = _dtDeductionInsertTable.NewRow()
            insertDataRow("Amount") = amount
            insertDataRow("DeductionIdNo") = deductionIdNo
            insertDataRow("EmployeeIdNo") = employeeIdNo
            insertDataRow("PayrollIdNo") = payrollIdNo
            _dtDeductionInsertTable.Rows.Add(insertDataRow)
        End Sub

        Private Sub AddEarning(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, earningIdNo As Short)
            Dim insertDataRow As DataRow
            insertDataRow = _dtEarningInsertTable.NewRow()
            insertDataRow("Amount") = amount
            insertDataRow("EarningIdNo") = earningIdNo
            insertDataRow("EmployeeIdNo") = employeeIdNo
            insertDataRow("PayrollIdNo") = payrollIdNo
            _dtEarningInsertTable.Rows.Add(insertDataRow)
        End Sub

        Private Sub GenerateDeductions(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim deductionsDao = New DeductionDao
            Dim amount As Decimal
            Dim empDeductions As List(Of EmployeeDeduction) = _employeeDeductionDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                If deduction.DeductionType = _regularDeduction Then
                    If deduction.CalculationType = _fixedAmount Then
                        amount = empDeduction.Amount
                        AddDeduction(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, deduction.IdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub GenerateEarnings(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
            GenerateRegularEarnings(employeeAttendance, payrollIdNo)
            GenerateOvertime(employeeAttendance, payrollIdNo)
        End Sub

        Private Sub GenerateRegularEarnings(employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim empEarnings As List(Of EmployeeEarning) = _employeeEarningDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            Dim amount As Decimal
            For Each empEarning In empEarnings
                Dim earning As Earning
                earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
                If earning.EarningType = _regularEarning Then
                    amount = ComputeEarningAmount(empEarning, earning, employeeAttendance)
                    AddEarning(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, earning.IdNo)
                End If
            Next
        End Sub

        Private Sub GenerateOvertime(employeeAttendance As AttendanceItem, payrollIdNo As Short)
            'Dim overtime As List(Of Earning) = _earningsDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            'Dim amount As Decimal
            'For Each empEarning In empEarnings
            '    Dim earning As Earning
            '    earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
            '    If earning.EarningType = _regularEarning Then
            '        amount = ComputeEarningAmount(empEarning, earning, employeeAttendance)
            '        AddEarning(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, earning.IdNo)
            '    End If
            'Next
        End Sub

        Private Function ComputeEarningAmount(empEarning As EmployeeEarning, earning As Earning, employeeAttendance As AttendanceItem) As Decimal
            Dim amount As Decimal
            If earning.CalculationType = _fixedAmount Then
                amount = empEarning.Amount
            ElseIf earning.CalculationType = _fixedRate Then
                If earning.Unit = _overtimeHours Then
                    amount = empEarning.Amount * employeeAttendance.Overtime
                End If
            End If
            Return amount
        End Function

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

        Private Sub MakeDeductions(employeeIdNo As Int32, amount As Decimal, empDeduction As EmployeeDeduction, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
            Dim deduction As PayrollDeduction = payDeductions.Find(Function(value As PayrollDeduction)
                                                                       Return value.EmployeeIdNo = empDeduction.EmployeeIdNo And value.DeductionIdNo = empDeduction.DeductionIdNo
                                                                   End Function)
            If deduction Is Nothing Then
                AddDeduction(employeeIdNo, amount, payrollIdNo, empDeduction.DeductionIdNo)
            Else
                UpdateDeduction(amount, deduction)
            End If
        End Sub

        Private Sub MakeEarnings(employeeIdNo As Int32, amount As Decimal, empEarning As EmployeeEarning, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
            Dim earning As PayrollEarning = payEarnings.Find(Function(value As PayrollEarning)
                                                                 Return value.EmployeeIdNo = empEarning.EmployeeIdNo And value.EarningIdNo = empEarning.EarningIdNo
                                                             End Function)
            If earning Is Nothing Then
                AddEarning(employeeIdNo, amount, payrollIdNo, empEarning.EarningIdNo)
            Else
                UpdateEarning(amount, earning)
            End If
        End Sub

        Private Sub ReGenerateDeduction(ByRef employeeAttendance As AttendanceItem, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
            Dim empDeductions As List(Of EmployeeDeduction)
            Dim amount As Decimal
            empDeductions = _employeeDeductionDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                If deduction.DeductionType = _regularDeduction Then
                    'If deduction.CalculationType = factoredDeduction Then
                    '    If deduction.
                    'ElseIf deduction.CalculationType = fixedDeduction Then
                    '    MakeDeductions(employeeAttendance, empDeduction, payDeductions, payrollIdNo)
                    '    End If
                    'End If
                End If
                MakeDeductions(employeeAttendance.EmployeeIdNo, amount, empDeduction, payDeductions, payrollIdNo)
            Next
        End Sub

        Private Sub ReGenerateEarning(ByRef employeeAttendance As AttendanceItem, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
            Dim empEarnings As List(Of EmployeeEarning)
            Dim amount As Decimal
            empEarnings = _employeeEarningDao.GetRecordsWithIdNo(employeeAttendance.EmployeeIdNo)
            For Each empEarning In empEarnings
                Dim earning As Earning
                earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
                If earning.EarningType = _regularEarning Then
                    If earning.CalculationType = _fixedAmount Then
                        amount = empEarning.Amount
                    ElseIf earning.CalculationType = _fixedRate Then
                        If earning.Unit = _overtimeHours Then

                        End If

                    End If
                    MakeEarnings(employeeAttendance.EmployeeIdNo, amount, empEarning, payEarnings, payrollIdNo)
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

        Private Sub UpdateDeduction(amount As Decimal, deduction As PayrollDeduction)
            If amount <> 0 Then
                Dim updateDataRow As DataRow
                updateDataRow = _dtDeductionUpdateTable.NewRow()
                updateDataRow("Amount") = amount
                updateDataRow("DeductionIdNo") = deduction.DeductionIdNo
                updateDataRow("EmployeeIdNo") = deduction.EmployeeIdNo
                updateDataRow("IdNo") = deduction.IdNo
                updateDataRow("PayrollIdNo") = deduction.PayrollIdNo
                _dtDeductionUpdateTable.Rows.Add(updateDataRow)
            End If
        End Sub

        Private Sub UpdateEarning(amount As Decimal, earning As PayrollEarning)
            If amount <> 0 Then
                Dim updateDataRow As DataRow
                updateDataRow = _dtEarningUpdateTable.NewRow()
                updateDataRow("Amount") = amount
                updateDataRow("EarningIdNo") = earning.IdNo
                updateDataRow("EmployeeIdNo") = earning.EmployeeIdNo
                updateDataRow("IdNo") = earning.IdNo
                updateDataRow("PayrollIdNo") = earning.PayrollIdNo
                _dtEarningUpdateTable.Rows.Add(updateDataRow)
            End If
        End Sub

    End Class

End Namespace