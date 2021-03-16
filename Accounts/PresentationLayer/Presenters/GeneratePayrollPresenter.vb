Imports System.Dynamic
Imports System.Web.UI.WebControls.Expressions
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
        Private ReadOnly _payrollDeductionDao = New PayrollDeductionDao
        Private ReadOnly _payrollEarningDao = New PayrollEarningDao
        Private ReadOnly _earningSummaryDao = New EarningSummaryDao
        Private ReadOnly _factor = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _factoredDeduction = EnumToCode(CalculationTypeSelection.Factor)

        'Private ReadOnly _fixedAmount = EnumToCode(CalculationTypeSelection.FixedAmount)
        Private ReadOnly _fixedRate = EnumToCode(CalculationTypeSelection.FixedRate)

        'Private ReadOnly _global = EnumToCode(CalculationTypeSelection.Global)
        Private ReadOnly _overtimeHoursRegular = EnumToCode(AttendanceUnitSelection.OvertimeRegular)

        Private ReadOnly _overtimeHoursSpecial = EnumToCode(AttendanceUnitSelection.OvertimeSpecial)
        Private ReadOnly _overtimeHoursHoliday = EnumToCode(AttendanceUnitSelection.OvertimeHoliday)
        Private ReadOnly _regularDeductionType = EnumToCode(DeductionTypeSelection.Regular)
        Private ReadOnly _absencesDeductionType = EnumToCode(DeductionTypeSelection.Computed)
        Private ReadOnly _regularEarning = EnumToCode(EarningTypeSelection.Regular)
        Private ReadOnly _computedEarning = EnumToCode(EarningTypeSelection.Computed)
        Private ReadOnly _absencesDeduction = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _variable = EnumToCode(CalculationTypeSelection.Variable)
        Private ReadOnly _dtDeductionInsertTable As New DataTable
        Private ReadOnly _dtDeductionUpdateTable As New DataTable
        Private ReadOnly _dtEarningInsertTable As New DataTable
        Private ReadOnly _dtEarningUpdateTable As New DataTable
        Private _endDate As Date
        Private ReadOnly _multiplier As New DataTable ' used for calculation of expression
        Private ReadOnly _deductionComputationMethod As String = "1"
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
            Dim absencesDeductions = _deductionsDao.GetRecords("DeductionType = '" & EnumToCode(DeductionTypeSelection.Computed) & "' and UnitAttendance = '" & AttendanceUnitSelection.OvertimeSpecial)
            GlobalVariables.Mapper.Map(absencesDeductions, _absenceDeductions)

            _deductionComputationMethod = GetAppSetting($"PYCM", "Payroll", "Deduction Computation Method")

        End Sub

        Public Sub GeneratePayroll(ByVal payrollIdNo As Int16, ByVal startDate As Date, ByVal endDate As Date, ByRef progressBar As ProgressBar)
            Dim attendance As List(Of AttendanceItem)
            Dim attendanceItemDao = New AttendanceItemDao
            Dim overtime As List(Of OvertimeItem)
            Dim overtimeItemDao = New OvertimeItemDao
            overtime = overtimeItemDao.GetRecordsWithGroupIdNo(payrollIdNo)
            attendance = attendanceItemDao.GetRecordsWithGroupIdNo(payrollIdNo)
            If attendance.Count() = 0 And overtime.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendanceOt")
            Else
                Dim payEarnings As List(Of PayrollEarning)
                Dim payDeductions As List(Of PayrollDeduction)
                Dim payCycleIdNo = GetFieldWithIdNo(payrollIdNo, "Payroll", "PayCycleIdNo")
                Dim payFrequency = GetFieldWithIdNo(payCycleIdNo, "PayCycle", "PayFrequency")
                If payFrequency = EnumToCode(PayFrequencySelection.Monthly) Then
                    _endDate = endDate
                    _daysInTheMonth = DateTime.DaysInMonth(Year(endDate), Month(endDate))
                    payDeductions = _payrollDeductionDao.GetRecordsWithGroupIdNo(payrollIdNo)
                    payEarnings = _payrollEarningDao.GetRecordsWithGroupIdNo(payrollIdNo)
                    If payEarnings.Count() = 0 And payDeductions.Count() = 0 Then
                        GenerateEmployeePayroll(payrollIdNo, attendance, overtime, progressBar)
                    Else
                        If Messaging.Show(True, "AskIfRegeneratePayroll",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            Dim payAbsencesDeductions = _payrollDeductionDao.GetRecordsWithGroupIdNo(payrollIdNo)
                            ReGenerateEmployeePayroll(payEarnings, payDeductions, payrollIdNo, attendance, overtime, progressBar)
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub AddDeduction(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, deductionIdNo As Short)
            If amount <> 0 Then
                Dim insertDataRow As DataRow
                insertDataRow = _dtDeductionInsertTable.NewRow()
                insertDataRow("Amount") = Math.Round(amount, 2)
                insertDataRow("DeductionIdNo") = deductionIdNo
                insertDataRow("EmployeeIdNo") = employeeIdNo
                insertDataRow("PayrollIdNo") = payrollIdNo
                _dtDeductionInsertTable.Rows.Add(insertDataRow)
            End If
        End Sub

        Private Sub AddEarning(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, earningIdNo As Short)
            If amount <> 0 Then
                Dim insertDataRow As DataRow
                insertDataRow = _dtEarningInsertTable.NewRow()
                insertDataRow("Amount") = Math.Round(amount, 2)
                'If earningIdNo = 18 Or earningIdNo = 2 Then
                '    Debugger.Break()
                'End If
                insertDataRow("EarningIdNo") = earningIdNo
                insertDataRow("EmployeeIdNo") = employeeIdNo
                insertDataRow("PayrollIdNo") = payrollIdNo
                _dtEarningInsertTable.Rows.Add(insertDataRow)
            End If
        End Sub

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

        'Private Function ComputeDeductionAmount(deduction As Deduction, daysAbsentWithoutPay As Decimal, basePayment As List(Of EmployeeEarning)) As Decimal
        '    Dim daysToCompute As Decimal
        '    Dim amount As Decimal
        '    If deduction.DeductionType = EnumToCode(DeductionTypeSelection.AbsencesDeduction) Then
        '        If _deductionComputationMethod = "DaysInMonth" Then
        '            daysToCompute = daysAbsentWithoutPay
        '            amount = Math.Round(basePayment(0).Amount / _daysInTheMonth * daysToCompute, 2)
        '        ElseIf _deductionComputationMethod = "30Days" Then
        '            If daysAbsentWithoutPay <= 15D Then
        '                daysToCompute = daysAbsentWithoutPay
        '            Else
        '                daysToCompute = 30D - (CDec(DateTime.DaysInMonth(Year(_endDate), Month(_endDate))) - daysAbsentWithoutPay)
        '            End If
        '            amount = Math.Round(basePayment(0).Amount / 30D * daysToCompute, 2)
        '        Else
        '            Dim FactorValue As Decimal
        '            FactorValue = CType(_multiplier.Compute(deduction.FactorValue, 0), Decimal)
        '            If deduction.FactorType = EnumToCode(FactorTypeSelection.PercentOfBasePaymentRate) Then
        '                amount = Math.Round(basePayment(0).Amount * FactorValue / 100 * daysToCompute, 2)
        '            Else
        '                amount = Math.Round(basePayment(0).Amount * FactorValue * daysToCompute, 2)
        '            End If
        '        End If
        '    Else
        '        Dim FactorValue As Decimal
        '        daysToCompute = daysAbsentWithoutPay
        '        'amount = Math.Round(basePayment(0).Amount / 30D * daysToCompute, 2)
        '        FactorValue = CType(_multiplier.Compute(deduction.FactorValue, 0), Decimal)
        '        If deduction.FactorType = EnumToCode(FactorTypeSelection.PercentOfBasePaymentRate) Then
        '            amount = Math.Round(basePayment(0).Amount * FactorValue / 100 * daysToCompute, 2)
        '        Else
        '            amount = Math.Round(basePayment(0).Amount * FactorValue * daysToCompute, 2)
        '        End If
        '    End If
        '    Return amount
        'End Function

        Private Function ComputeEarningAmount(empEarning As EmployeeEarning, earning As Earning) As Decimal
            Dim amount As Decimal
            If earning.CalculationType = _fixedRate Then
                amount = empEarning.Rate
                'ElseIf earning.CalculationType = _fixedRate Then
                '    If earning.Unit = _overtimeHoursRegular Then
                '    amount = empEarning.Rate '* employeeAttendance.Overtime1
                'ElseIf earning.Unit = _overtimeHoursSpecial Then
                '    amount = empEarning.Rate '* employeeAttendance.Overtime2
                'End If
            ElseIf earning.CalculationType = _factor Then
                If Not earning.Summary Then
                    ' factored item is not a summary earning (meaning not computed)
                    Dim ee As EmployeeEarning = _employeeEarningDao.GetRecordById(earning.BasePaymentIdNo)
                    amount = ComputeFactoredAmount(ee.Amount, earning.FactorValue, earning.FactorType)
                Else
                    ' factored item is a computed value
                    If earning.BasePaymentIdNo <> 0 Then
                        ' get the earning for the given basePaymentIdNo
                        Dim bpEarning As Earning = _earningsDao.GetRecordById(earning.BasePaymentIdNo)
                        ' get employee earning for the said item
                        Dim bpEarningSummary As New List(Of EarningSummary)
                        bpEarningSummary = _earningSummaryDao.GetRecordsWithGroupIdNo(bpEarning.IdNo)
                        For Each e In bpEarningSummary
                            Dim ee As EmployeeEarning
                            ee = _employeeEarningDao.GetRecordById(e.EarningIdNo)
                            amount += ee.Amount * e.FactorValue
                        Next
                        amount = ComputeFactoredAmount(amount, earning.FactorValue, earning.FactorType)
                    Else
                        amount = 0
                    End If
                End If
            End If
            Return amount
        End Function

        Private Function CalculateComputedEarning(employeeIdNo As Int32, earning As Earning) As Decimal
            Dim amount As Decimal
            If earning.CalculationType = _fixedRate Then
                amount = earning.Rate
            ElseIf earning.CalculationType = _factor Then
                If Not earning.Summary Then
                    ' factored item is not a summary earning (meaning not computed)
                    'Dim ee As EmployeeEarning = _employeeEarningDao.GetRecord("EmployeeIdNo = " & employeeIdNo.ToString())
                    'If ee IsNot Nothing Then
                    Dim bpEarning = _earningsDao.GetRecordById(earning.BasePaymentIdNo)
                    If bpEarning.Summary Then
                        Dim earningsSummary = _earningSummaryDao.GetRecordsWithGroupIdNo(earning.BasePaymentIdNo)
                        'For Each earningSummaryItem In earningSummary
                        Dim summaryAmount = ComputeSummaryAmount(employeeIdNo, earningsSummary)
                        amount = ComputeFactoredAmount(summaryAmount, earning.FactorValue, earning.FactorType)
                        'Next
                    Else
                        'amount = ComputeFactoredAmount(ee.Amount, earning.FactorValue, earning.FactorType)
                    End If
                    'End If
                Else
                    '' factored item is a computed value
                    'If earning.BasePaymentIdNo <> 0 Then`
                    '    ' get the earning for the given basePaymentIdNo
                    '    Dim bpEarning As Earning = _earningsDao.GetRecordById(earning.BasePaymentIdNo)
                    '' get employee earning for the said item
                    'Dim bpEarningSummary As New List(Of EarningSummary)
                    'bpEarningSummary = _earningSummaryDao.GetRecordsWithGroupIdNo(bpEarning.IdNo)
                    'For Each e In bpEarningSummary
                    '    Dim ee As EmployeeEarning
                    '    ee = _employeeEarningDao.GetRecordById(e.EarningIdNo)
                    '    amount += ee.Amount * e.FactorValue
                    'Next
                    'amount = ComputeFactoredAmount(amount, earning.FactorValue, earning.FactorType)
                    'Else
                    'amount = 0
                End If
            End If
            Return amount
        End Function

        Private Shared Function ComputeFactoredAmount(amount As Decimal, FactorValue As Decimal, FactorType as String)
            Dim factoredAmount As Decimal
            If FactorType = EnumToCode(FactorTypeSelection.PercentOfBasePaymentRate) Then
                factoredAmount = amount * FactorValue * 0.01D
            Else
                factoredAmount = amount * FactorValue
            End If
            Return factoredAmount
        End Function

        Private Function ComputeSummaryAmount(employeeIdNo As Int32, earningsSummary As List(Of EarningSummary)) As Decimal
            Dim summaryAmount As Decimal
            'Dim earningsSummary As List(Of EarningSummary) = _earningSummaryDao.GetRecordsWithGroupIdNo(earningSummaryItem.IdNo)
            For Each earningSummaryItem In earningsSummary
                Dim idNo As Int16
                idNo = earningSummaryItem.EarningIdNo
                Dim empEarning As EmployeeEarning
                empEarning = _employeeEarningDao.GetRecord("EmployeeIdNo = " & employeeIdNo.ToString() & " And earningIdNo = " & idNo.ToString())
                If empEarning IsNot Nothing Then
                    Dim earnAmount As Decimal
                    Dim earning As Earning
                    earning = _earningsDao.GetRecordById(idNo)
                    earnAmount = ComputeEarningAmount(empEarning, earning)
                    If earnAmount <> 0 Then
                        summaryAmount = summaryAmount + earningSummaryItem.FactorValue * earnAmount
                    End If
                End If
            Next
            Return summaryAmount
        End Function

        Private Sub GenerateAbsencesDeductions(employeeIdNo As Int32, payrollIdNo As Short, daysAbsentWithoutPay As Decimal)
            If daysAbsentWithoutPay <> 0 Then
                For Each deduction In _absenceDeductions
                    AddNComputeAbsenceDeduction(employeeIdNo, daysAbsentWithoutPay, deduction, payrollIdNo)
                Next
            End If
        End Sub

        Private Sub ReGenerateAbsencesDeductions(employeeIdNo As Int32, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short, daysAbsentWithoutPay As Decimal)
            If daysAbsentWithoutPay <> 0 Then
                For Each deduction In _absenceDeductions
                    MakeAbsencesDeduction(employeeIdNo, daysAbsentWithoutPay, payDeductions, deduction, payrollIdNo)
                Next
            End If
        End Sub

        Private Sub AddNComputeAbsenceDeduction(employeeIdNo As Int32, daysAbsentWithoutPay As Decimal, deduction As Deduction, payrollIdNo As Short)
            Dim amount As Decimal
            If daysAbsentWithoutPay > 0D Then
                Dim basePayment As Object = _employeeEarningDao.GetRecord("EmployeeIdNo = " & employeeIdNo & " And EarningIdNo = " & deduction.BasePaymentIdNo)
                If basePayment IsNot Nothing Then
                    amount = ComputeDeductionAmount(deduction, daysAbsentWithoutPay, basePayment)
                Else
                    amount = 0
                End If
            Else
                amount = 0
            End If
            If amount <> 0 Then
                AddDeduction(employeeIdNo, amount, payrollIdNo, deduction.IdNo)
            End If
        End Sub

        Private Sub MakeAbsencesDeduction(employeeIdNo As Int32, daysAbsentWithoutPay As Decimal, payDeductions As List(Of PayrollDeduction), deduction As Deduction, payrollIdNo As Short)
            Dim amount As Decimal
            If daysAbsentWithoutPay > 0D Then
                Dim basePayment As EmployeeEarning = _employeeEarningDao.GetRecord("EmployeeIdNo = " & employeeIdNo & " And EarningIdNo = " & deduction.BasePaymentIdNo)
                If basePayment IsNot Nothing Then
                    amount = ComputeDeductionAmount(deduction, daysAbsentWithoutPay, basePayment)
                Else
                    amount = 0
                End If
            Else
                amount = 0
            End If
            If amount <> 0 Then
                MakeDeductions(employeeIdNo, amount, deduction.IdNo, payDeductions, payrollIdNo)
            End If
        End Sub

        Private Sub GenerateRegularDeductions(ByRef employeeIdNo As Int32, payrollIdNo As Short)
            Dim amount As Decimal
            Dim empDeductions As List(Of EmployeeDeduction) = _employeeDeductionDao.GetRecordsWithGroupIdNo(employeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                If deduction.DeductionType = _regularDeductionType Then
                    If deduction.CalculationType = _fixedRate Then
                        amount = empDeduction.Amount
                        AddDeduction(employeeIdNo, amount, payrollIdNo, deduction.IdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub ReGenerateRegularDeduction(ByRef employeeAttendance As AttendanceItem, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
            Dim amount As Decimal
            Dim empDeductions As List(Of EmployeeDeduction) = _employeeDeductionDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
            For Each empDeduction In empDeductions
                Dim deduction As Deduction
                deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
                If deduction.DeductionType = _regularDeductionType Then
                    If deduction.CalculationType = _fixedRate Then
                        amount = empDeduction.Amount
                        MakeDeductions(employeeAttendance.EmployeeIdNo, amount, empDeduction.DeductionIdNo, payDeductions, payrollIdNo)
                    End If
                End If
            Next
        End Sub

        'Private Sub GenerateEarnings(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
        '    GenerateRegularEarnings(employeeAttendance, payrollIdNo)
        'End Sub

        Private Sub GenerateEmployeePayroll(ByVal payrollIdNo As Short, ByRef attendance As List(Of AttendanceItem), ByRef overtime As List(Of OvertimeItem), ByRef progressBar As ProgressBar)
            _dtEarningInsertTable.Clear()
            _dtDeductionInsertTable.Clear()
            progressBar.Value = 0
            progressBar.Maximum = attendance.Count() + 2 + overtime.Count()
            progressBar.Visible = True
            For Each employeeAttendance In attendance
                'If employeeAttendance.EmployeeIdNo = 1 Then
                '    Debugger.Break()
                'End If
                GenerateRegularEarnings(employeeAttendance, payrollIdNo)
                GenerateRegularDeductions(employeeAttendance.EmployeeIdNo, payrollIdNo)
                GenerateAbsencesDeductions(employeeAttendance.EmployeeIdNo, payrollIdNo, employeeAttendance.DaysAbsentWithoutPay)
                progressBar.Value = progressBar.Value + 1
            Next
            GenerateOvertime(False, payrollIdNo, overtime, progressBar)
            _payrollEarningDao.InsertTvp(_dtEarningInsertTable)
            progressBar.Value = progressBar.Value + 1
            _payrollDeductionDao.InsertTvp(_dtDeductionInsertTable)
            progressBar.Value = progressBar.Value + 1
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
            progressBar.Visible = False
        End Sub

        Private Sub ReGenerateEmployeePayroll(ByRef payEarnings As List(Of PayrollEarning), ByRef payDeductions As List(Of PayrollDeduction), ByVal payrollIdNo As Short, ByRef attendance As List(Of AttendanceItem), ByRef overtime As List(Of OvertimeItem), ByRef progressBar As ProgressBar)
            _dtEarningInsertTable.Clear()
            _dtEarningUpdateTable.Clear()
            progressBar.Value = 0
            progressBar.Maximum = attendance.Count() + overtime.Count() + 2
            progressBar.Visible = True

            For Each employeeAttendance In attendance
                ReGenerateRegularEarning(employeeAttendance, payEarnings, payrollIdNo)
                ReGenerateRegularDeduction(employeeAttendance, payDeductions, payrollIdNo)
                ReGenerateAbsencesDeductions(employeeAttendance.EmployeeIdNo, payDeductions, payrollIdNo, employeeAttendance.DaysAbsentWithoutPay)
                progressBar.Value = progressBar.Value + 1
            Next
            GenerateOvertime(True, payrollIdNo, overtime, progressBar)
            _payrollDeductionDao.UpdateInsertTvp(_dtDeductionUpdateTable, _dtDeductionInsertTable, payrollIdNo)
            progressBar.Value = progressBar.Value + 1
            _payrollEarningDao.UpdateInsertTvp(_dtEarningUpdateTable, _dtEarningInsertTable, payrollIdNo)
            progressBar.Value = progressBar.Value + 1
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
            progressBar.Visible = False
        End Sub

        Private Sub GenerateRegularEarnings(employeeAttendance As AttendanceItem, payrollIdNo As Short)
            Dim empEarnings As List(Of EmployeeEarning) = _employeeEarningDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
            Dim amount As Decimal
            'create regular earnings first
            For Each empEarning In empEarnings
                Dim earning As Earning
                earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
                If earning.EarningType = _regularEarning Then
                    amount = ComputeEarningAmount(empEarning, earning)
                    AddEarning(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, earning.IdNo)
                End If
            Next
            'secondly create computed earnings for regular earnings only
            Dim allEarnings As List(Of Earning)
            allEarnings = _earningsDao.GetRecords("EarningType='" & EnumToCode(EarningTypeSelection.Computed) & "'")
            For Each earning As Earning In allEarnings
                amount = CalculateComputedEarning(employeeAttendance.EmployeeIdNo, earning)
                AddEarning(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, earning.IdNo)
            Next
        End Sub

        Private Sub ReGenerateRegularEarning(ByRef employeeAttendance As AttendanceItem, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
            Dim empEarnings As List(Of EmployeeEarning)
            Dim amount As Decimal
            empEarnings = _employeeEarningDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
            For Each empEarning In empEarnings
                Dim earning As Earning
                earning = _earningsDao.GetRecordById(empEarning.EarningIdNo)
                If earning.EarningType = _regularEarning Then
                    If earning.CalculationType = _fixedRate Then
                        amount = ComputeEarningAmount(empEarning, earning)
                    Else
                        amount = 0
                    End If
                    'If employeeAttendance.EmployeeIdNo = 1 Then
                    '    Debugger.Break()
                    'End If
                    MakeEarnings(employeeAttendance.EmployeeIdNo, amount, empEarning.EarningIdNo, payEarnings, payrollIdNo)
                End If
            Next
            'secondly create computed earnings for regular earnings only
            Dim allSummaryEarnings As List(Of Earning)
            allSummaryEarnings = _earningsDao.GetRecords("EarningType='" & EnumToCode(EarningTypeSelection.Computed) & "'")
            Dim employeeEarning As EmployeeEarning
            For Each earning As Earning In allSummaryEarnings
                employeeEarning = _employeeEarningDao.GetRecord("EmployeeIdNo = " & employeeAttendance.EmployeeIdNo & " and EarningIdNo = " & earning.IdNo.ToString())
                amount = CalculateComputedEarning(employeeAttendance.EmployeeIdNo, earning)
                If amount <> 0 Then
                    MakeEarnings(employeeAttendance.EmployeeIdNo, amount, earning.IdNo, payEarnings, payrollIdNo)
                End If
            Next
        End Sub

        'Private Sub GenerateOvertime(payrollIdNo As Short, overtime As List(Of OvertimeItem), ByRef progressBar As ProgressBar)
        '    Dim employeeDao = New EmployeeDao
        '    Dim otAmount As Decimal = 0
        '    Dim otRegularUnit = EnumToCode(PayRateUnitSelection.OvertimeHoursRegular)
        '    Dim otHolidayUnit = EnumToCode(PayRateUnitSelection.OvertimeHoursHoliday)
        '    Dim otSpecialUnit = EnumToCode(PayRateUnitSelection.OvertimeHoursSpecial)
        '    Dim otEarnings = _earningsDao.GetRecordsByField("EarningType = '" & EnumToCode(EarningTypeSelection.Overtime) & "' AND " &
        '                                             "CalculationType = '" & EnumToCode(CalculationTypeSelection.FixedRate) & "' AND " &

        '                                             "(Unit = '" & otRegularUnit & "' or " &
        '                                             "Unit = '" & otHolidayUnit & "' or " &
        '                                             "Unit = '" & otSpecialUnit & "')")
        '    If overtime.Count() <> 0 Then
        '        For Each item In overtime
        '            If item.OvertimeRegular <> 0 Or item.OvertimeHoliday <> 0 Or item.OvertimeSpecial Then
        '                Dim employeeIdNo = item.EmployeeIdNo
        '                Dim emp As Object
        '                emp = employeeDao.GetRecordFieldsFiltered("Employee", "OtRateRegular,OtRateHoliday,OtRateSpecial", "IdNo = " & employeeIdNo)
        '                If emp IsNot Nothing Then
        '                    Dim empOtRegularRate As Decimal = IIf(IsDBNull(emp.OtRateRegular), 0, emp.OtRateRegular)
        '                    Dim empOtHolidayRate As Decimal = IIf(IsDBNull(emp.otRateHoliday), 0, emp.otRateHoliday)
        '                    Dim empOtSpecialRate As Decimal = IIf(IsDBNull(emp.OtRateSpecial), 0, emp.otRateSpecial)
        '                    If item.OvertimeRegular <> 0 Then
        '                        MakePayrollOt(payrollIdNo, item.OvertimeRegular, otRegularUnit, empOtRegularRate, otEarnings, employeeIdNo)
        '                    End If
        '                    If item.OvertimeHoliday <> 0 Then
        '                        MakePayrollOt(payrollIdNo, item.OvertimeHoliday, otHolidayUnit, empOtHolidayRate, otEarnings, employeeIdNo)
        '                    End If
        '                    If item.OvertimeSpecial <> 0 Then
        '                        MakePayrollOt(payrollIdNo, item.OvertimeSpecial, otSpecialUnit, empOtSpecialRate, otEarnings, employeeIdNo)
        '                    End If
        '                End If
        '            End If
        '            progressBar.Value = progressBar.Value + 1
        '        Next
        '    End If
        'End Sub

        Private Sub GenerateOvertime(regenerate As Boolean, payrollIdNo As Short, overtime As List(Of OvertimeItem), ByRef progressBar As ProgressBar)
            Dim employeeDao = New EmployeeDao
            Dim otAmount As Decimal = 0
            Dim otRegularUnit = EnumToCode(AttendanceUnitSelection.OvertimeRegular)
            Dim otHolidayUnit = EnumToCode(AttendanceUnitSelection.OvertimeHoliday)
            Dim otSpecialUnit = EnumToCode(AttendanceUnitSelection.OvertimeSpecial)
            Dim otRegularEarning As Earning = _earningsDao.GetRecordByIdNo(1) '("EarningType = '" & EnumToCode(EarningTypeSelection.Computed) & "' and cboUnit")
            Dim otHolidayEarning As Earning = _earningsDao.GetRecordByIdNo(2) '("EarningType = '" & EnumToCode(EarningTypeSelection.OvertimeHoliday) & "'")
            Dim otSpecialEarning As Earning = _earningsDao.GetRecordByIdNo(3) '("EarningType = '" & EnumToCode(EarningTypeSelection.OvertimeSpecial) & "'")
            Dim payrollEarnings As New List(Of PayrollEarning)
            If regenerate Then
                Dim curRPayEarnings As New List(Of PayrollEarning)
                Dim curHPayEarnings As New List(Of PayrollEarning)
                Dim curSPayEarnings As New List(Of PayrollEarning)
                curRPayEarnings = _payrollEarningDao.GetRecords("EarningIdNo = '" & otRegularEarning.IdNo.ToString() & "' and PayrollIdNo = '" & payrollIdNo.ToString() & "'")
                curHPayEarnings = _payrollEarningDao.GetRecords("EarningIdNo = '" & otHolidayEarning.IdNo.ToString() & "' and PayrollIdNo = '" & payrollIdNo.ToString() & "'")
                curSPayEarnings = _payrollEarningDao.GetRecords("EarningIdNo = '" & otSpecialEarning.IdNo.ToString() & "' and PayrollIdNo = '" & payrollIdNo.ToString() & "'")
                If curRPayEarnings IsNot Nothing Then
                    payrollEarnings.AddRange(curRPayEarnings)
                End If
                If curHPayEarnings IsNot Nothing Then
                    payrollEarnings.AddRange(curHPayEarnings)
                End If
                If curSPayEarnings IsNot Nothing Then
                    payrollEarnings.AddRange(curSPayEarnings)
                End If
            End If
            If overtime.Count() <> 0 Then
                For Each item In overtime
                    If item.OvertimeRegular <> 0 Or item.OvertimeHoliday <> 0 Or item.OvertimeSpecial Then
                        Dim employeeIdNo = item.EmployeeIdNo
                        Dim emp As Object
                        emp = employeeDao.GetRecordFieldsFiltered("Employee", "OtRateRegular,OtRateHoliday,OtRateSpecial", "IdNo = " & employeeIdNo)
                        If emp IsNot Nothing Then
                            Dim empOtRegularRate As Decimal = IIf(IsDBNull(emp.OtRateRegular), 0, emp.OtRateRegular)
                            Dim empOtHolidayRate As Decimal = IIf(IsDBNull(emp.otRateHoliday), 0, emp.otRateHoliday)
                            Dim empOtSpecialRate As Decimal = IIf(IsDBNull(emp.OtRateSpecial), 0, emp.otRateSpecial)
                            If regenerate Then
                                If item.OvertimeRegular <> 0 Then
                                    ReMakePayrollOt(payrollEarnings, payrollIdNo, item.OvertimeRegular, otRegularUnit, empOtRegularRate, otRegularEarning, employeeIdNo)
                                End If
                                If item.OvertimeHoliday <> 0 Then
                                    ReMakePayrollOt(payrollEarnings, payrollIdNo, item.OvertimeHoliday, otHolidayUnit, empOtHolidayRate, otHolidayEarning, employeeIdNo)
                                End If
                                If item.OvertimeSpecial <> 0 Then
                                    ReMakePayrollOt(payrollEarnings, payrollIdNo, item.OvertimeSpecial, otSpecialUnit, empOtSpecialRate, otSpecialEarning, employeeIdNo)
                                End If
                            Else
                                If item.OvertimeRegular <> 0 Then
                                    MakePayrollOt(payrollIdNo, item.OvertimeRegular, otRegularUnit, empOtRegularRate, otRegularEarning, employeeIdNo)
                                End If
                                If item.OvertimeHoliday <> 0 Then
                                    MakePayrollOt(payrollIdNo, item.OvertimeHoliday, otHolidayUnit, empOtHolidayRate, otHolidayEarning, employeeIdNo)
                                End If
                                If item.OvertimeSpecial <> 0 Then
                                    MakePayrollOt(payrollIdNo, item.OvertimeSpecial, otSpecialUnit, empOtSpecialRate, otSpecialEarning, employeeIdNo)
                                End If
                            End If
                        End If
                    End If
                    progressBar.Value = progressBar.Value + 1
                Next
            End If
        End Sub

        Private Sub MakePayrollOt(payrollIdNo As Short, otHours As Decimal, otUnit As String, otRate As Decimal, otEarning As Earning, employeeIdNo As Integer)
            Dim otAmount As Decimal = ComputeOtAmount(otEarning, otHours, otRate)
            AddEarning(employeeIdNo, otAmount, payrollIdNo, otEarning.IdNo)
        End Sub

        Private Sub ReMakePayrollOt(payEarnings As List(Of PayrollEarning), payrollIdNo As Short, otHours As Decimal, otUnit As String, otRate As Decimal, otEarning As Earning, employeeIdNo As Integer)
            Dim otAmount As Decimal = ComputeOtAmount(otEarning, otHours, otRate)
            Dim payrollEarning As PayrollEarning = payEarnings.Find(Function(value As PayrollEarning)
                                                                        Return value.EmployeeIdNo = employeeIdNo And value.EarningIdNo = otEarning.IdNo
                                                                    End Function)
            If payrollEarning Is Nothing Then
                AddEarning(employeeIdNo, otAmount, payrollIdNo, otEarning.IdNo)
            Else
                UpdateEarning(otAmount, payrollEarning)
            End If
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

        Private Sub MakeDeductions(employeeIdNo As Int32, amount As Decimal, deductionIdNo As Int16, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
            If amount <> 0 Then
                Dim deduction As PayrollDeduction = payDeductions.Find(Function(value As PayrollDeduction)
                                                                           Return value.EmployeeIdNo = employeeIdNo And value.DeductionIdNo = deductionIdNo
                                                                       End Function)
                If deduction Is Nothing Then
                    AddDeduction(employeeIdNo, amount, payrollIdNo, deductionIdNo)
                Else
                    UpdateDeduction(amount, deduction)
                End If
            End If
        End Sub

        Private Sub MakeEarnings(employeeIdNo As Int32, amount As Decimal, earningIdNo As Int16, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
            If amount <> 0 Then
                Dim earning As PayrollEarning = payEarnings.Find(Function(value As PayrollEarning)
                                                                     Return value.EmployeeIdNo = employeeIdNo And value.EarningIdNo = earningIdNo
                                                                 End Function)
                If earning Is Nothing Then
                    AddEarning(employeeIdNo, amount, payrollIdNo, earningIdNo)
                Else
                    UpdateEarning(amount, earning)
                End If
            End If
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
                If earning.EarningIdNo = 138 Then
                    Debugger.Break()
                End If
                updateDataRow("EarningIdNo") = earning.EarningIdNo
                updateDataRow("EmployeeIdNo") = earning.EmployeeIdNo
                updateDataRow("IdNo") = earning.IdNo
                updateDataRow("PayrollIdNo") = earning.PayrollIdNo
                _dtEarningUpdateTable.Rows.Add(updateDataRow)
            End If
        End Sub

    End Class

End Namespace