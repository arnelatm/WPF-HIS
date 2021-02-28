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

        Private ReadOnly _absenceDeductions As List(Of Deduction)
        Private ReadOnly _deductionsDao = New DeductionDao
        Private ReadOnly _earningsDao = New EarningDao
        Private ReadOnly _employeeDeductionDao = New EmployeeDeductionDao
        Private ReadOnly _employeeEarningDao = New EmployeeEarningDao
        Private ReadOnly _factor = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _factoredDeduction = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _fixedAmount = EnumToCode(CalculationTypeSelection.FixedAmount)
        Private ReadOnly _fixedRate = EnumToCode(CalculationTypeSelection.FixedRate)
        Private ReadOnly _global = EnumToCode(CalculationTypeSelection.Global)
        Private ReadOnly _overtimeHoursRegular = EnumToCode(PayRateUnitSelection.OvertimeHoursRegular)
        Private ReadOnly _overtimeHoursSpecial = EnumToCode(PayRateUnitSelection.OvertimeHoursSpecial)
        Private ReadOnly _regularDeductionType = EnumToCode(DeductionTypeSelection.Regular)
        Private ReadOnly _absencesDeductionType = EnumToCode(DeductionTypeSelection.AbsencesDeduction)
        Private ReadOnly _regularEarning = EnumToCode(EarningTypeSelection.Regular)

        Private ReadOnly _absencesDeduction = EnumToCode(CalculationTypeSelection.DaysAbsent)
        Private ReadOnly _variable = EnumToCode(CalculationTypeSelection.Variable)
        Private _dtDeductionInsertTable As New DataTable
        Private _dtDeductionUpdateTable As New DataTable
        Private _dtEarningInsertTable As New DataTable
        Private _dtEarningUpdateTable As New DataTable
        Private _endDate As Date
        Private _multiplier As New DataTable ' used for calculation of expression
        Private _deductionComputationMethod As String = "1"
        Private _daysInTheMonth As Int16
        Private _payCycle As PayCycle

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

            _absenceDeductions = New List(Of Deduction)
            Dim absencesDeductions = _deductionsDao.GetRecords("DeductionType = '" & EnumToCode(DeductionTypeSelection.AbsencesDeduction) & "'")
            GlobalVariables.Mapper.Map(absencesDeductions, _absenceDeductions)

            _deductionComputationMethod = GetAppSetting($"PYCM", "Payroll", "Deduction Computation Method")

        End Sub

        Public Sub GeneratePayroll(ByVal payrollIdNo As Int16, ByVal startDate As Date, ByVal endDate As Date, ByRef progressBar As ProgressBar)
            Dim attendance As List(Of AttendanceItem)
            Dim attendanceItemDao = New AttendanceItemDao
            attendance = attendanceItemDao.GetRecordsWithGroupIdNo(payrollIdNo)
            If attendance.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendance")
            Else
                Dim payrollDeductionDao = New PayrollDeductionDao
                Dim payrollEarningDao = New PayrollEarningDao
                Dim payEarnings As List(Of PayrollEarning)
                Dim payDeductions As List(Of PayrollDeduction)
                Dim payCycleIdNo = GetFieldWithIdNo(payrollIdNo, "Payroll", "PayCycleIdNo")
                Dim payFrequency = GetFieldWithIdNo(payCycleIdNo, "PayCycle", "PayFrequency")
                If payFrequency = EnumToCode(PayFrequencySelection.Monthly) Then
                    _endDate = endDate
                    _daysInTheMonth = DateTime.DaysInMonth(Year(endDate), Month(endDate))
                    payDeductions = payrollDeductionDao.GetRecordsWithGroupIdNo(payrollIdNo)
                    payEarnings = payrollEarningDao.GetRecordsWithGroupIdNo(payrollIdNo)
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
            End If
        End Sub

        Private Sub AddDeduction(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, deductionIdNo As Short)
            Dim insertDataRow As DataRow
            insertDataRow = _dtDeductionInsertTable.NewRow()
            insertDataRow("Amount") = Math.Round(amount, 2)
            insertDataRow("DeductionIdNo") = deductionIdNo
            insertDataRow("EmployeeIdNo") = employeeIdNo
            insertDataRow("PayrollIdNo") = payrollIdNo
            _dtDeductionInsertTable.Rows.Add(insertDataRow)
        End Sub

        Private Sub AddEarning(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, earningIdNo As Short)
            Dim insertDataRow As DataRow
            insertDataRow = _dtEarningInsertTable.NewRow()
            insertDataRow("Amount") = Math.Round(amount, 2)
            insertDataRow("EarningIdNo") = earningIdNo
            insertDataRow("EmployeeIdNo") = employeeIdNo
            insertDataRow("PayrollIdNo") = payrollIdNo
            _dtEarningInsertTable.Rows.Add(insertDataRow)
        End Sub

        Private Sub AddNComputeDeduction(employeeAttendance As AttendanceItem, daysAbsentWithoutPay As Decimal, deduction As Deduction, payrollIdNo As Short)
            Dim amount As Decimal
            If deduction.CalculationType = _fixedAmount Then
                amount = deduction.Rate
            ElseIf deduction.CalculationType = _fixedRate Then
                amount = deduction.Rate * daysAbsentWithoutPay
            ElseIf deduction.CalculationType = _factor Then
                Dim idNo As Int16
                idNo = _employeeEarningDao.GetFieldValue(Of Int32)("IdNo", "EmployeeEarning", "EmployeeIdNo = " & employeeAttendance.EmployeeIdNo & " and EarningIdNo = " & deduction.BasePaymentIdNo)
                If idNo <> 0 Then
                    Dim basePayment As List(Of EmployeeEarning) = _employeeEarningDao.GetRecordByIdNo(idNo)
                    If daysAbsentWithoutPay > 0D Then
                        Dim daysToCompute As Decimal
                        amount = ComputeDeductionAmount(deduction, daysAbsentWithoutPay, basePayment)
                    Else
                        amount = 0
                    End If
                Else
                    amount = 0
                End If
            End If
            If amount <> 0 Then
                AddDeduction(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, deduction.IdNo)
            End If
        End Sub

        Private Function ComputeDeductionAmount(deduction As Deduction, daysAbsentWithoutPay As Decimal, basePayment As List(Of EmployeeEarning)) As Decimal
            Dim daysToCompute As Decimal
            Dim amount As Decimal
            If deduction.DeductionType = EnumToCode(DeductionTypeSelection.AbsencesDeduction) Then
                If _deductionComputationMethod = "DaysInMonth" Then
                    daysToCompute = daysAbsentWithoutPay
                    amount = Math.Round(basePayment(0).Amount / _daysInTheMonth * daysToCompute, 2)
                ElseIf _deductionComputationMethod = "30Days" Then
                    If daysAbsentWithoutPay <= 15D Then
                        daysToCompute = daysAbsentWithoutPay
                    Else
                        daysToCompute = 30D - (CDec(DateTime.DaysInMonth(Year(_endDate), Month(_endDate))) - daysAbsentWithoutPay)
                    End If
                    amount = Math.Round(basePayment(0).Amount / 30D * daysToCompute, 2)
                Else
                    Dim multiplier As Decimal
                    multiplier = CType(_multiplier.Compute(deduction.Multiplier, 0), Decimal)
                    If deduction.MultiplierType = EnumToCode(MultiplierTypeSelection.PercentOfBasePaymentRate) Then
                        amount = Math.Round(basePayment(0).Amount * multiplier / 100 * daysToCompute, 2)
                    Else
                        amount = Math.Round(basePayment(0).Amount * multiplier * daysToCompute, 2)
                    End If
                End If
            Else
                Dim multiplier As Decimal
                daysToCompute = daysAbsentWithoutPay
                amount = Math.Round(basePayment(0).Amount / 30D * daysToCompute, 2)
                multiplier = CType(_multiplier.Compute(deduction.Multiplier, 0), Decimal)
                If deduction.MultiplierType = EnumToCode(MultiplierTypeSelection.PercentOfBasePaymentRate) Then
                    amount = Math.Round(basePayment(0).Amount * multiplier / 100 * daysToCompute, 2)
                Else
                    amount = Math.Round(basePayment(0).Amount * multiplier * daysToCompute, 2)
                End If
            End If
            Return amount
        End Function

        Private Function ComputeEarningAmount(empEarning As EmployeeEarning, earning As Earning, employeeAttendance As AttendanceItem) As Decimal
            Dim amount As Decimal
            If earning.CalculationType = _fixedAmount Then
                amount = empEarning.Amount
            ElseIf earning.CalculationType = _fixedRate Then
                If earning.Unit = _overtimeHoursRegular Then
                    amount = empEarning.Rate * employeeAttendance.Overtime1
                ElseIf earning.Unit = _overtimeHoursSpecial Then
                    amount = empEarning.Rate * employeeAttendance.Overtime2
                End If
            ElseIf earning.CalculationType = _factor Then
                'If earning.Unit = _overtimeHours1 Then
                '    amount = empEarning.Rate * employeeAttendance.Overtime1
                'ElseIf earning.Unit = _overtimeHours2 Then
                '    amount = empEarning.Rate * employeeAttendance.Overtime2
                'End If
                amount = 0
            Else
                amount = 0
            End If
            Return amount
        End Function

        Private Sub GenerateAbsencesDeductions(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim daysAbsentWithoutPay = employeeAttendance.DaysAbsentWithoutPay
            If daysAbsentWithoutPay <> 0 Then
                ']Dim empDeductions As List(Of EmployeeDeduction) = _employeeDeductionDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
                For Each deduction In _absenceDeductions
                    AddNComputeDeduction(employeeAttendance, daysAbsentWithoutPay, deduction, payrollIdNo)
                Next
            End If
        End Sub

        Private Sub GenerateDeductions(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim amount As Decimal
            Dim empDeductions As List(Of EmployeeDeduction) = _employeeDeductionDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                If deduction.DeductionType = _regularDeductionType Then
                    If deduction.CalculationType = _fixedAmount Then
                        amount = empDeduction.Amount
                        AddDeduction(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, deduction.IdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub GenerateEarnings(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
            GenerateRegularEarnings(employeeAttendance, payrollIdNo)
            'GenerateOvertime(employeeAttendance, payrollIdNo)
        End Sub

        Private Sub GenerateEmployeePayroll(ByVal payrollIdNo As Short, ByRef attendance As List(Of AttendanceItem), ByRef progressBar As ProgressBar)
            Dim payrollEarningDao = New PayrollEarningDao
            Dim payrollDeductionDao = New PayrollDeductionDao
            _dtEarningInsertTable.Clear()
            _dtDeductionInsertTable.Clear()
            progressBar.Value = 0
            progressBar.Maximum = attendance.Count() + 2
            progressBar.Visible = True
            Dim counter = 1
            For Each employeeAttendance In attendance
                GenerateEarnings(employeeAttendance, payrollIdNo)
                GenerateDeductions(employeeAttendance, payrollIdNo)
                GenerateAbsencesDeductions(employeeAttendance, payrollIdNo)
                progressBar.Value = progressBar.Value + 1
            Next
            payrollEarningDao.InsertTvp(_dtEarningInsertTable)
            payrollDeductionDao.InsertTvp(_dtDeductionInsertTable)
            progressBar.Value = progressBar.Value + 2
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
            progressBar.Visible = False
        End Sub

        'Private Sub GenerateOvertime(employeeAttendance As AttendanceItem, payrollIdNo As Short)
        '    'Dim overtime As List(Of Earning) = _earningsDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
        '    'Dim amount As Decimal
        '    'For Each empEarning In empEarnings
        '    '    Dim earning As Earning
        '    '    earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
        '    '    If earning.EarningType = _regularEarning Then
        '    '        amount = ComputeEarningAmount(empEarning, earning, employeeAttendance)
        '    '        AddEarning(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, earning.IdNo)
        '    '    End If
        '    'Next
        'End Sub

        Private Sub GenerateRegularEarnings(employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim empEarnings As List(Of EmployeeEarning) = _employeeEarningDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
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
            empDeductions = _employeeDeductionDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                If deduction.DeductionType = _regularDeductionType Then
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
            empEarnings = _employeeEarningDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
            For Each empEarning In empEarnings
                Dim earning As Earning
                earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
                If earning.EarningType = _regularEarning Then
                    If earning.CalculationType = _fixedAmount Then
                        amount = empEarning.Amount
                    ElseIf earning.CalculationType = _fixedRate Then
                        If earning.Unit = _overtimeHoursRegular Then

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