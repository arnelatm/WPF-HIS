Imports System.Dynamic
Imports System.Web.UI.WebControls.Expressions
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class GeneratePayrollPresenter
        Inherits AccountsPresenter(Of IPayrollView, PayrollModel)

        'Private ReadOnly _absenceDeductions As List(Of Deduction)
        Private _attendance As List(Of AttendanceItemModel)

        Private _otWorkHours As List(Of OtWorkHourModel)
        Private _payrollPayElements As List(Of PayrollPayElementModel)
        Private _savedPayrollPayElements As List(Of PayrollPayElementModel)
        Private _computedEarnings As List(Of PayElementModel)
        Private _globalEarnings As List(Of PayElementModel)

        Private _daysInTheMonth As Int16
        Private _endDate As Date
        Private _payFrequency As PayFrequencySelection
        Private _payrollIdNo As Int16

        Private ReadOnly _deductionComputationMethod As String = "1"
        Private ReadOnly _dtPayrollDetailInsertTable As New DataTable
        Private ReadOnly _dtPayrollDetailUpdateTable As New DataTable
        Private ReadOnly _dtPayrollPayElementInsertTable As New DataTable
        Private ReadOnly _dtPayrollPayElementUpdateTable As New DataTable

        'Private ReadOnly _deductionsDao = New DeductionDao
        'Private ReadOnly _earningSummaryDao = New EarningSummaryDao
        'Private ReadOnly _employeePayElementDao = New EmployeePayElementDao
        'Private ReadOnly _payrollDeductionDao = New PayrollDeductionDao
        'Private ReadOnly _payrollPayElementDao = New PayrollPayElementDao
        Private ReadOnly _attendanceItemDao = New AttendanceItemDao

        Private ReadOnly _employeeEarningsDao = New EmployeeEarningDao
        Private ReadOnly _otWorkHoursDao = New OtWorkHourDao
        Private ReadOnly _payCycleDao = New PayCycleDao
        Private ReadOnly _payElementDao = New PayElementDao
        Private ReadOnly _payElementItemsDao = New PayElementDao
        Private ReadOnly _payrollDao = New PayrollDao
        Private ReadOnly _payrollDetailsDao = New PayrollDetailDao
        Private ReadOnly _payrollPayElementsDao = New PayrollPayElementDao

        'Private ReadOnly _regularDeductionType = EnumToCode(DeductionTypeSelection.Regular)
        'Private ReadOnly _absencesDeduction = EnumToCode(CalculationTypeSelection.Factor)
        'Private ReadOnly _absencesDeductionType = EnumToCode(DeductionTypeSelection.Computed)
        'Private ReadOnly _factoredDeduction = EnumToCode(CalculationTypeSelection.Factor)
        'Private ReadOnly _fixedAmount = EnumToCode(CalculationTypeSelection.FixedAmount)
        'Private ReadOnly _global = EnumToCode(CalculationTypeSelection.Global)
        Private ReadOnly _computedEarningType = EnumToCode(EarningTypeSelection.Computed)

        Private ReadOnly _factorType = EnumToCode(CalculationTypeSelection.Factor)
        Private ReadOnly _fixedRateType = EnumToCode(CalculationTypeSelection.FixedRate)
        Private ReadOnly _overtimeHoursHolidayType = EnumToCode(AttendanceUnitSelection.OvertimeHoliday)
        Private ReadOnly _overtimeHoursRegularType = EnumToCode(AttendanceUnitSelection.OvertimeRegular)
        Private ReadOnly _overtimeHoursSpecialType = EnumToCode(AttendanceUnitSelection.OvertimeSpecial)
        Private ReadOnly _regularPayElement = EnumToCode(EarningTypeSelection.Regular)
        Private ReadOnly _variable = EnumToCode(CalculationTypeSelection.Variable)

        Public Sub New(view As IPayrollView)
            MyBase.New(view)
            Dim _payCycleIdNo As Int16 = _payrollDao.GetRecordByIdNo(view.IdNo).PayCycleIdNo
            _payFrequency = CodeToEnum(Of PayFrequencySelection)(_payCycleDao.GetRecordByIdNo(_payCycleIdNo))
            TableName = "Account"
            ModelPresenter = New ModelAccounts("Payroll")
            TableName = "Payroll"
            SortOrderKey = "IdNo"
            OriginalModel = New PayrollModel()
            DataModel = New PayrollModel()
            CreateDataTable(_dtPayrollPayElementInsertTable, {{"Amount", GetType(Decimal)},
                                             {"EarningIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })
            CreateDataTable(_dtPayrollPayElementUpdateTable, {{"Amount", GetType(Decimal)},
                                             {"EarningIdNo", GetType(Int16)},
                                             {"EmployeeIdNo", GetType(Int32)},
                                             {"IdNo", GetType(Int32)},
                                             {"PayrollIdNo", GetType(Int16)}
                                            })

            CreateDataTable(_dtPayrollDetailInsertTable, {{"EmployeeIdNo", GetType(Int32)},
                                                          {"PayrollIdNo", GetType(Int16)}
                                                         })

            CreateDataTable(_dtPayrollDetailUpdateTable, {{"EmployeeIdNo", GetType(Int32)},
                                                          {"IdNo", GetType(Int32)},
                                                          {"PayrollIdNo", GetType(Int16)}
                                                         })

            '_absenceDeductions = New List(Of Deduction)
            'Dim absencesDeductions = _deductionsDao.GetRecords("DeductionType = '" & EnumToCode(DeductionTypeSelection.Computed) & "' and QuantityType = '" & EnumToCode(AttendanceUnitSelection.OvertimeSpecial) & "'")
            'GlobalVariables.Mapper.Map(absencesDeductions, _absenceDeductions)
            _deductionComputationMethod = GetAppSetting($"PYCM", "Payroll", "Deduction Computation Method")

        End Sub

        Public Sub GeneratePayroll(ByVal payrollIdNo As Int16, ByVal startDate As Date, ByVal endDate As Date, ByRef progressBar As ProgressBar)
            Dim attendance As List(Of AttendanceItem)
            Dim otWorkHours As List(Of OtWorkHour)
            attendance = _attendanceItemDao.GetRecordsWithGroupIdNo(payrollIdNo)
            otWorkHours = _otWorkHoursDao.GetRecordsWithGroupIdNo(payrollIdNo)
            GlobalVariables.Mapper.Map(attendance, _attendance)
            GlobalVariables.Mapper.Map(otWorkHours, _otWorkHours)
            _otWorkHours = _otWorkHoursDao.GetRecordsWithGroupIdNo(payrollIdNo)
            _payrollIdNo = payrollIdNo
            If _attendance.Count() = 0 And _otWorkHours.Count() = 0 Then
                Messaging.Show(True, "MsgEmptyEmployeeAttendanceOt")
            Else
                Dim payrollPayElements As List(Of PayrollPayElement)
                Dim payCycleIdNo = GetFieldWithIdNo(payrollIdNo, "Payroll", "PayCycleIdNo")
                Dim payFrequency = GetFieldWithIdNo(payCycleIdNo, "PayCycle", "PayFrequency")
                If payFrequency = EnumToCode(PayFrequencySelection.Monthly) Then
                    _endDate = endDate
                    _daysInTheMonth = DateTime.DaysInMonth(Year(endDate), Month(endDate))
                    payrollPayElements = _payrollPayElementsDao.GetRecordsWithGroupIdNo(payrollIdNo)
                    If payrollPayElements.Count() = 0 Then
                        GenerateEmployeePayroll(False, progressBar)
                    Else
                        If Messaging.Show(True, "AskIfRegeneratePayroll",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                            GenerateEmployeePayroll(True, progressBar)
                            'Dim payAbsencesDeductions = _payrollDeductionDao.GetRecordsWithGroupIdNo(payrollIdNo)
                            'ReGenerateEmployeePayroll(progressBar)
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub GenerateEmployeePayroll(ByRef regenerate As Boolean, progressBar As ProgressBar)
            _dtPayrollPayElementInsertTable.Clear()
            _dtPayrollDetailInsertTable.Clear()
            Dim payrollDetails As List(Of PayrollDetailModel)
            payrollDetails = CreatePayrollDetails()
            _computedEarnings = _payElementDao.GetRecords("PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) &
                                                          "' and CalculationType = '" & EnumToCode(PayElementTypeSelection.Computed) &
                                                          "' and not Summary")
            _globalEarnings = _payElementDao.GetRecords("PayElementKind = '" & EnumToCode(PayElementKindSelection.Earning) &
                                                        "' and CalculationType = '" & EnumToCode(PayElementTypeSelection.Global) &
                                                        "' and not Summary")
            progressBar.Value = 0
            progressBar.Maximum = payrollDetails.Count() + 2
            progressBar.Visible = True
            If regenerate Then
                _savedPayrollPayElements = _payrollPayElementsDao.GetRecordsWithGroupIdNo(_payrollIdNo)
            End If
            For Each payrollDetail In payrollDetails
                GenerateRegularEarnings(regenerate, payrollDetail.IdNo)
                GenerateComputedEarnings(regenerate, payrollDetail.IdNo)
                GenerateGlobalEarnings(regenerate, payrollDetail.IdNo)
            Next

            'GenerateRegularDeductions(attendance.EmployeeIdNo, payrollIdNo)
            'GenerateAbsencesDeductions(employeeAttendance.EmployeeIdNo, payrollIdNo, employeeAttendance.DaysAbsentWithoutPay)
            'progressBar.Value = progressBar.Value + 1

            '_payrollPayElementDao.InsertTvp(_dtPayrollPayElementInsertTable)
            'progressBar.Value = progressBar.Value + 1
            '_payrollDeductionDao.InsertTvp(_dtDeductionInsertTable)
            progressBar.Value = progressBar.Value + 1
            Messaging.Show(True, "MsgPayrollGenerationCompleted")
            progressBar.Visible = False
        End Sub

        Private Sub GenerateRegularEarnings(regenerate As Boolean, employeeIdNo As Int32)
            Dim empEarnings As List(Of EmployeeEarningModel) = _employeeEarningsDao.GetRecordsWithGroupIdNo(employeeIdNo)
            Dim amount As Decimal
            For Each empEarning In empEarnings
                Dim earning As PayElementModel
                earning = _payElementDao.GetRecordById(empEarning.EarningIdNo)
                If earning.CalculationType = EnumToCode(CalculationTypeSelection.FixedAmount) Then
                    amount = ComputeFixedAmountEarning(empEarning, earning)
                    If Not regenerate Then
                        AddEarning(employeeIdNo, amount, earning.IdNo, 0)
                    Else
                        MakeEarning(employeeIdNo, amount, earning.IdNo)
                    End If
                ElseIf earning.CalculationType = EnumToCode(CalculationTypeSelection.FixedRate) Then
                    amount = ComputeFixedAmountEarning(empEarning, earning)
                    Dim qty As Decimal = ComputeQuantity(empEarning, earning)
                    If Not regenerate Then
                        AddEarning(employeeIdNo, amount, earning.IdNo, 0)
                    Else
                        MakeEarning(employeeIdNo, amount, earning.IdNo)
                    End If
                End If
            Next
        End Sub

        Private Sub AddEarning(employeeIdNo As Int32, amount As Decimal, earningIdNo As Short, payrollPayEarningIdNo As Int16)
            If amount <> 0 Then
                Dim payrollPayElement As New PayrollPayElementModel
                payrollPayElement.Amount = Math.Round(amount, 2)
                payrollPayElement.PayrollIdNo = _payrollIdNo
                payrollPayElement.PayElementIdNo = earningIdNo
                payrollPayElement.EmployeeIdNo = employeeIdNo
                payrollPayElement.IdNo = payrollPayEarningIdNo
                _payrollPayElements.Add(payrollPayElement)
            End If
        End Sub

        Private Sub MakeEarning(employeeIdNo As Int32, amount As Decimal, earningIdNo As Int16)
            If amount <> 0 Then
                Dim earning As PayrollPayElementModel = _payrollPayElements.Find(Function(value As PayrollPayElementModel)
                                                                                     Return value.EmployeeIdNo = employeeIdNo And value.PayElementIdNo = earningIdNo
                                                                                 End Function)
                If earning Is Nothing Then
                    AddEarning(employeeIdNo, amount, earningIdNo, 0)
                Else
                    AddEarning(employeeIdNo, amount, earning.IdNo, earning.IdNo)
                End If
            End If
        End Sub

        Private Sub AddToGeneratedPayroll(employeeIdNo As Int32, amount As Decimal, earningIdNo As Short, earning As PayrollPayElementModel)
            Dim payrollPayElement As New PayrollPayElementModel
            payrollPayElement.Amount = Math.Round(amount, 2)
            payrollPayElement.PayrollIdNo = _payrollIdNo
            payrollPayElement.PayElementIdNo = earningIdNo
            payrollPayElement.EmployeeIdNo = employeeIdNo
            If earning IsNot Nothing Then
                payrollPayElement.IdNo = earning.IdNo
            End If
            _payrollPayElements.Add(payrollPayElement)
        End Sub

        Private Sub GenerateComputedEarnings(regenerate As Boolean, employeeIdNo As Int32)
            For Each earning As PayElementModel In _computedEarnings
                Dim amount As Decimal
                amount = CalculateComputedEarning(employeeIdNo, earning)
                If Not regenerate Then
                    AddEarning(employeeIdNo, amount, earning.IdNo, 0)
                Else
                    MakeEarning(employeeIdNo, amount, earning.IdNo)
                End If
            Next
        End Sub

        Private Sub GenerateGlobalEarnings(regenerate As Boolean, employeeIdNo As Int32)
            For Each earning As PayElementModel In _globalEarnings
                If Not regenerate Then
                    AddEarning(employeeIdNo, earning.Rate, earning.IdNo, 0)
                Else
                    MakeEarning(employeeIdNo, earning.Rate, earning.IdNo)
                End If
            Next
        End Sub

        Private Function CalculateComputedEarning(employeeIdNo As Int32, earning As PayElementModel) As Decimal
            Dim amount As Decimal
            Dim bpEarning = _payElementDao.GetRecordById(earning.BasePaymentIdNo)
            If bpEarning.Summary Then
                amount = ComputeSummaryAmount(employeeIdNo, earning.BasePaymentIdNo)
            Else
                Dim bpPayElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = earning.IdNo)
                If bpPayElementModel IsNot Nothing Then
                    amount = ComputeFactoredAmount(bpPayElementModel.Amount, earning.FactorValue, earning.FactorType)
                End If
            End If
            Return amount
        End Function

        'Private Function CalculateGlobalEarning(employeeIdNo As Int32, earning As PayElementModel) As Decimal
        '    Dim amount As Decimal
        '    Dim gEarning = _payElementDao.GetRecordById(earning.IdNo)
        '    If bpEarning.Summary Then
        '        amount = ComputeSummaryAmount(employeeIdNo, earning.BasePaymentIdNo)
        '    Else
        '        Dim bpPayElementModel As PayrollPayElementModel = _payrollPayElements.Find(Function(p As PayrollPayElementModel) p.EmployeeIdNo = employeeIdNo And p.PayElementIdNo = earning.IdNo)
        '        If bpPayElementModel IsNot Nothing Then
        '            amount = ComputeFactoredAmount(bpPayElementModel.Amount, earning.FactorValue, earning.FactorType)
        '        End If
        '    End If
        '    Return amount
        'End Function

        'Private Sub AddDeduction(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, deductionIdNo As Short)
        '    If amount <> 0 Then
        '        Dim insertDataRow As DataRow
        '        insertDataRow = _dtDeductionInsertTable.NewRow()
        '        insertDataRow("Amount") = Math.Round(amount, 2)
        '        insertDataRow("DeductionIdNo") = deductionIdNo
        '        insertDataRow("EmployeeIdNo") = employeeIdNo
        '        insertDataRow("PayrollIdNo") = payrollIdNo
        '        _dtDeductionInsertTable.Rows.Add(insertDataRow)
        '    End If
        'End Sub

        Private Shared Function ComputeFactoredAmount(amount As Decimal, FactorValue As Decimal, FactorType As String)
            Dim factoredAmount As Decimal
            If FactorType = EnumToCode(FactorTypeSelection.PercentOfBasePaymentRate) Then
                factoredAmount = amount * FactorValue * 0.01D
            ElseIf FactorType = EnumToCode(FactorTypeSelection.MultiplyBasePaymentRate) Then
                factoredAmount = amount * FactorValue
            ElseIf FactorType = EnumToCode(FactorTypeSelection.DivideBasePaymentRate) Then
                If FactorValue <> 0 Then
                    factoredAmount = amount / FactorValue
                End If
            End If
            Return factoredAmount
        End Function

        Private Function ComputeSummaryAmount(employeeIdNo As Int32, earningIdNo As Int16) As Decimal
            Dim summaryAmount As Decimal
            Dim payElementItems As List(Of PayElementItem) = _payElementItemsDao.GetRecordsWithGroupIdNo(earningIdNo)
            For Each payElementItem As PayElementItem In payElementItems
                Dim payElement As PayElement = _payElementDao.GetRecordWithIdNo(payElementItem.PayElementIdNo)
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
                summaryAmount += ComputeFactoredAmount(amount, payElementItem.FactorValue, payElement.FactorType)
            Next
            Return summaryAmount
        End Function

        'Private Sub AddEarning(employeeIdNo As Int32, amount As Decimal, payrollIdNo As Short, earningIdNo As Short)
        '    If amount <> 0 Then
        '        Dim payrollPayElement As New PayElementModel
        '        Dim insertDataRow As DataRow
        '        insertDataRow = _dtPayrollPayElementInsertTable.NewRow()
        '        insertDataRow("Amount") = Math.Round(amount, 2)
        '        insertDataRow("EarningIdNo") = earningIdNo
        '        insertDataRow("PayrollPayDetailIdNo") = employeeIdNo
        '        insertDataRow("PayrollIdNo") = payrollIdNo
        '        _dtPayrollPayElementInsertTable.Rows.Add(insertDataRow)
        '    End If
        'End Sub

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

        Private Function ComputeFixedAmountEarning(empEarning As EmployeeEarningModel, earning As PayElementModel) As Decimal
            Dim amount As Decimal = empEarning.Amount
            Dim factor As Decimal
            Select Case _payFrequency
                Case PayFrequencySelection.Monthly
                    If empEarning.Unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 1D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 12D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 6D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 3D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 13D / 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 30D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D / 6D
                    End If
                Case PayFrequencySelection.Yearly
                    If empEarning.Unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 12D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 24D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 4D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 52D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 365D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 26D
                    End If
                Case PayFrequencySelection.SemiYearly
                    If empEarning.Unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 6D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 12D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 26D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 365D / 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D
                    End If
                Case PayFrequencySelection.Quarterly
                    If empEarning.Unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 3D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 6D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 4D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 13D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 365D / 4D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D / 2D
                    End If
                Case PayFrequencySelection.SemiMonthly
                    If empEarning.Unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 1D / 2D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 1D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 24D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 12D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 6D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 13D / 4D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 15D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 13D / 12D
                    End If
                Case PayFrequencySelection.Weekly
                    If empEarning.Unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 12D / 52D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 24D / 52D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 52D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 26D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 13D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 1D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 7D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 1D / 2D
                    End If
                Case PayFrequencySelection.Daily
                    If empEarning.Unit = EnumToCode(PayRateUnitSelection.Month) Then
                        factor = 1D / 30D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiMonth) Then
                        factor = 1D / 15D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Year) Then
                        factor = 1D / 360D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.SemiYear) Then
                        factor = 1D / 180D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Quarter) Then
                        factor = 1D / 90D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Week) Then
                        factor = 1D / 7D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.Day) Then
                        factor = 1D
                    ElseIf empEarning.Unit = EnumToCode(PayRateUnitSelection.BiWeek) Then
                        factor = 1D / 14D
                    End If

            End Select
            Return amount * factor
        End Function

        'Private Function ComputeEarning()

        '    'ElseIf earning.CalculationType = _fixedRate Then
        '    '    If earning.Unit = _overtimeHoursRegular Then
        '    '    amount = empEarning.Rate '* employeeAttendance.Overtime1
        '    'ElseIf earning.Unit = _overtimeHoursSpecial Then
        '    '    amount = empEarning.Rate '* employeeAttendance.Overtime2
        '    'End If
        '    ElseIf Earning.CalculationType = _factorType Then
        '    If Not Earning.Summary Then
        '        ' factored item is not a summary earning (meaning not computed)
        '        Dim ee As EmployeeEarning = _employeePayElementDao.GetRecordById(Earning.BasePaymentIdNo)
        '        amount = ComputeFactoredAmount(ee.Amount, Earning.FactorValue, Earning.FactorType)
        '    Else
        '        ' factored item is a computed value
        '        If Earning.BasePaymentIdNo <> 0 Then
        '            ' get the earning for the given basePaymentIdNo
        '            Dim bpEarning As Earning = _payElementDao.GetRecordById(Earning.BasePaymentIdNo)
        '            ' get employee earning for the said item
        '            Dim bpEarningSummary As New List(Of EarningSummary)
        '            bpEarningSummary = _earningSummaryDao.GetRecordsWithGroupIdNo(bpEarning.IdNo)
        '            For Each e In bpEarningSummary
        '                Dim ee As EmployeeEarning
        '                ee = _employeePayElementDao.GetRecordById(e.EarningIdNo)
        '                amount += ee.Amount * e.FactorValue
        '            Next
        '            amount = ComputeFactoredAmount(amount, Earning.FactorValue, Earning.FactorType)
        '        Else
        '            amount = 0
        '        End If
        '    End If
        '    Return amount
        'End Function

        'Private Sub GenerateAbsencesDeductions(employeeIdNo As Int32, payrollIdNo As Short, daysAbsentWithoutPay As Decimal)
        '    If daysAbsentWithoutPay <> 0 Then
        '        For Each deduction In _absenceDeductions
        '            AddNComputeAbsenceDeduction(employeeIdNo, daysAbsentWithoutPay, deduction, payrollIdNo)
        '        Next
        '    End If
        'End Sub

        'Private Sub ReGenerateAbsencesDeductions(employeeIdNo As Int32, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short, daysAbsentWithoutPay As Decimal)
        '    If daysAbsentWithoutPay <> 0 Then
        '        For Each deduction In _absenceDeductions
        '            MakeAbsencesDeduction(employeeIdNo, daysAbsentWithoutPay, payDeductions, deduction, payrollIdNo)
        '        Next
        '    End If
        'End Sub

        'Private Sub AddNComputeAbsenceDeduction(employeeIdNo As Int32, daysAbsentWithoutPay As Decimal, deduction As Deduction, payrollIdNo As Short)
        '    Dim amount As Decimal
        '    If daysAbsentWithoutPay > 0D Then
        '        Dim basePayment As Object = _employeePayElementDao.GetRecord("EmployeeIdNo = " & employeeIdNo & " And EarningIdNo = " & deduction.BasePaymentIdNo)
        '        If basePayment IsNot Nothing Then
        '            amount = ComputeDeductionAmount(deduction, daysAbsentWithoutPay, basePayment)
        '        Else
        '            amount = 0
        '        End If
        '    Else
        '        amount = 0
        '    End If
        '    If amount <> 0 Then
        '        AddDeduction(employeeIdNo, amount, payrollIdNo, deduction.IdNo)
        '    End If
        'End Sub

        'Private Sub MakeAbsencesDeduction(employeeIdNo As Int32, daysAbsentWithoutPay As Decimal, payDeductions As List(Of PayrollDeduction), deduction As Deduction, payrollIdNo As Short)
        '    Dim amount As Decimal
        '    If daysAbsentWithoutPay > 0D Then
        '        Dim basePayment As EmployeeEarning = _employeePayElementDao.GetRecord("EmployeeIdNo = " & employeeIdNo & " And EarningIdNo = " & deduction.BasePaymentIdNo)
        '        If basePayment IsNot Nothing Then
        '            amount = ComputeDeductionAmount(deduction, daysAbsentWithoutPay, basePayment)
        '        Else
        '            amount = 0
        '        End If
        '    Else
        '        amount = 0
        '    End If
        '    If amount <> 0 Then
        '        MakeDeductions(employeeIdNo, amount, deduction.IdNo, payDeductions, payrollIdNo)
        '    End If
        'End Sub

        'Private Sub GenerateRegularDeductions(ByRef employeeIdNo As Int32, payrollIdNo As Short)
        '    Dim amount As Decimal
        '    Dim empDeductions As List(Of EmployeeDeduction) = _employeeDeductionDao.GetRecordsWithGroupIdNo(employeeIdNo)
        '    For Each empDeduction In empDeductions
        '        Dim deduction As Deduction
        '        deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
        '        If deduction.DeductionType = _regularDeductionType Then
        '            If deduction.CalculationType = _fixedRateType Then
        '                amount = empDeduction.Amount
        '                AddDeduction(employeeIdNo, amount, payrollIdNo, deduction.IdNo)
        '            End If
        '        End If
        '    Next
        'End Sub

        'Private Sub ReGenerateRegularDeduction(ByRef employeeAttendance As AttendanceItem, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
        '    Dim amount As Decimal
        '    Dim empDeductions As List(Of EmployeeDeduction) = _employeeDeductionDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
        '    For Each empDeduction In empDeductions
        '        Dim deduction As Deduction
        '        deduction = _deductionsDao.GetRecordById(empDeduction.DeductionIdNo)
        '        If deduction.DeductionType = _regularDeductionType Then
        '            If deduction.CalculationType = _fixedRateType Then
        '                amount = empDeduction.Amount
        '                MakeDeductions(employeeAttendance.EmployeeIdNo, amount, empDeduction.DeductionIdNo, payDeductions, payrollIdNo)
        '            End If
        '        End If
        '    Next
        'End Sub

        'Private Sub GenerateEarnings(ByRef employeeAttendance As AttendanceItem, payrollIdNo As Short)
        '    GenerateRegularEarnings(employeeAttendance, payrollIdNo)
        'End Sub

        Private Function CreatePayrollDetails()
            Dim payrollDetails As New List(Of PayrollDetailModel)
            For Each employeeAttendance In _attendance
                Dim payrollDetail As New PayrollDetailModel
                payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo
                payrollDetail.PayrollIdNo = _payrollIdNo
                payrollDetails.Add(payrollDetail)
            Next
            For Each employeeAttendance In _otWorkHours
                Dim payrollDetail = payrollDetails.Find(Function(pd As PayrollDetailModel) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
                If payrollDetail Is Nothing Then
                    payrollDetails.Add(payrollDetail)
                End If
            Next
            Return payrollDetails
        End Function

        'Private Shared Function CreatePayrollDetails(payrollIdNo As Short, attendance As List(Of AttendanceItem), otWorkHour As List(Of OtWorkHour))
        '    Dim payrollDetails As New List(Of PayrollDetail)
        '    For Each employeeAttendance In attendance
        '        Dim payrollDetail As New PayrollDetail
        '        payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo
        '        payrollDetail.PayrollIdNo = payrollIdNo
        '        payrollDetails.Add(payrollDetail)
        '    Next
        '    For Each employeeAttendance In otWorkHour
        '        Dim payrollDetail = payrollDetails.Find(Function(pd As PayrollDetail) pd.EmployeeIdNo = employeeAttendance.EmployeeIdNo)
        '        If payrollDetail Is Nothing Then
        '            payrollDetails.Add(payrollDetail)
        '        End If
        '    Next
        '    Return payrollDetails
        'End Function

        'Private Sub ReGenerateEmployeePayroll(ByRef payEarnings As List(Of PayrollEarning), ByRef payDeductions As List(Of PayrollDeduction), ByVal payrollIdNo As Short, ByRef attendance As List(Of AttendanceItem), ByRef overtime As List(Of OtWorkHour), ByRef progressBar As ProgressBar)
        '    _dtPayrollPayElementInsertTable.Clear()
        '    _dtPayrollPayElementUpdateTable.Clear()
        '    progressBar.Value = 0
        '    progressBar.Maximum = attendance.Count() + overtime.Count() + 2
        '    progressBar.Visible = True

        '    For Each employeeAttendance In attendance
        '        ReGenerateRegularEarning(employeeAttendance, payEarnings, payrollIdNo)
        '        ReGenerateRegularDeduction(employeeAttendance, payDeductions, payrollIdNo)
        '        ReGenerateAbsencesDeductions(employeeAttendance.EmployeeIdNo, payDeductions, payrollIdNo, employeeAttendance.DaysAbsentWithoutPay)
        '        progressBar.Value = progressBar.Value + 1
        '    Next
        '    GenerateOvertime(True, payrollIdNo, overtime, progressBar)
        '    _payrollDeductionDao.UpdateInsertTvp(_dtDeductionUpdateTable, _dtDeductionInsertTable, payrollIdNo)
        '    progressBar.Value = progressBar.Value + 1
        '    _payrollPayElementDao.UpdateInsertTvp(_dtPayrollPayElementUpdateTable, _dtPayrollPayElementInsertTable, payrollIdNo)
        '    progressBar.Value = progressBar.Value + 1
        '    Messaging.Show(True, "MsgPayrollGenerationCompleted")
        '    progressBar.Visible = False
        'End Sub

        Private Function ComputeQuantity(empEarning As EmployeeEarningModel, earning As PayElementModel)
            Dim quantity As Decimal
            If earning.QuantityType = EnumToCode(QuantityTypeSelection.HoursWorked) Then
                quantity = _otWorkHoursDao.GetRecord("EmployeeIdNo = " & empEarning.EmployeeIdNo.ToString() & " PayrollIdNo = " & _payrollIdNo)
            End If
            Return quantity
        End Function

        'Private Sub GenerateRegularEarnings(employeeAttendance As AttendanceItem, payrollIdNo As Short)
        '    Dim empEarnings As List(Of EmployeeEarning) = _employeePayElementDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
        '    Dim amount As Decimal
        '    'create regular earnings first
        '    For Each empEarning In empEarnings
        '        Dim earning As Earning
        '        earning = _payElementDao.GetRecordById(empEarning.EarningIdNo)
        '        If earning.EarningType = _regularEarning Then
        '            amount = ComputeEarningAmount(empEarning, earning)
        '            AddEarning(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, earning.IdNo)
        '        End If
        '    Next
        '    'secondly create computed earnings for regular earnings only
        '    Dim allEarnings As List(Of Earning)
        '    allEarnings = _payElementDao.GetRecords("EarningType='" & EnumToCode(EarningTypeSelection.Computed) & "'")
        '    For Each earning As Earning In allEarnings
        '        amount = CalculateComputedEarning(employeeAttendance.EmployeeIdNo, earning)
        '        AddEarning(employeeAttendance.EmployeeIdNo, amount, payrollIdNo, earning.IdNo)
        '    Next
        'End Sub

        'Private Sub ReGenerateRegularEarning(ByRef employeeAttendance As AttendanceItem, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
        '    Dim empEarnings As List(Of EmployeeEarning)
        '    Dim amount As Decimal
        '    empEarnings = _employeePayElementDao.GetRecordsWithGroupIdNo(employeeAttendance.EmployeeIdNo)
        '    For Each empEarning In empEarnings
        '        Dim earning As Earning
        '        earning = _payElementDao.GetRecordById(empEarning.EarningIdNo)
        '        If earning.EarningType = _regularEarning Then
        '            If earning.CalculationType = _fixedRateType Then
        '                amount = ComputeEarningAmount(empEarning, earning)
        '            Else
        '                amount = 0
        '            End If
        '            'If employeeAttendance.EmployeeIdNo = 1 Then
        '            '    Debugger.Break()
        '            'End If
        '            MakeEarnings(employeeAttendance.EmployeeIdNo, amount, empEarning.EarningIdNo, payEarnings, payrollIdNo)
        '        End If
        '    Next
        '    'secondly create computed earnings for regular earnings only
        '    Dim allSummaryEarnings As List(Of Earning)
        '    allSummaryEarnings = _payElementDao.GetRecords("EarningType='" & EnumToCode(EarningTypeSelection.Computed) & "'")
        '    Dim employeeEarning As EmployeeEarning
        '    For Each earning As Earning In allSummaryEarnings
        '        employeeEarning = _employeePayElementDao.GetRecord("EmployeeIdNo = " & employeeAttendance.EmployeeIdNo & " and EarningIdNo = " & earning.IdNo.ToString())
        '        amount = CalculateComputedEarning(employeeAttendance.EmployeeIdNo, earning)
        '        If amount <> 0 Then
        '            MakeEarnings(employeeAttendance.EmployeeIdNo, amount, earning.IdNo, payEarnings, payrollIdNo)
        '        End If
        '    Next
        'End Sub

        'Private Sub GenerateOvertime(payrollIdNo As Short, overtime As List(Of OtWorkHour), ByRef progressBar As ProgressBar)
        '    Dim employeeDao = New EmployeeDao
        '    Dim otAmount As Decimal = 0
        '    Dim otRegularUnit = EnumToCode(PayRateUnitSelection.OvertimeHoursRegular)
        '    Dim otHolidayUnit = EnumToCode(PayRateUnitSelection.OvertimeHoursHoliday)
        '    Dim otSpecialUnit = EnumToCode(PayRateUnitSelection.OvertimeHoursSpecial)
        '    Dim otEarnings = _payElementDao.GetRecordsByField("EarningType = '" & EnumToCode(EarningTypeSelection.Overtime) & "' AND " &
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

        'Private Sub GenerateOvertime(regenerate As Boolean, employeeIdNo As Int32, payrollIdNo As Short, overtime As List(Of OtWorkHourModel), ByRef progressBar As ProgressBar)
        '    Dim employeeDao = New EmployeeDao
        '    Dim otAmount As Decimal = 0
        '    Dim otRegularUnit = EnumToCode(AttendanceUnitSelection.OvertimeRegular)
        '    Dim otHolidayUnit = EnumToCode(AttendanceUnitSelection.OvertimeHoliday)
        '    Dim otSpecialUnit = EnumToCode(AttendanceUnitSelection.OvertimeSpecial)
        '    Dim otRegularEarning As Earning = _payElementDao.GetRecordByIdNo(1) '("EarningType = '" & EnumToCode(EarningTypeSelection.Computed) & "' and cboUnit")
        '    Dim otHolidayEarning As Earning = _payElementDao.GetRecordByIdNo(2) '("EarningType = '" & EnumToCode(EarningTypeSelection.OvertimeHoliday) & "'")
        '    Dim otSpecialEarning As Earning = _payElementDao.GetRecordByIdNo(3) '("EarningType = '" & EnumToCode(EarningTypeSelection.OvertimeSpecial) & "'")
        '    Dim payrollEarnings As New List(Of PayrollEarning)
        '    If regenerate Then
        '        Dim curRPayEarnings As New List(Of PayrollEarning)
        '        Dim curHPayEarnings As New List(Of PayrollEarning)
        '        Dim curSPayEarnings As New List(Of PayrollEarning)
        '        curRPayEarnings = _payrollPayElementDao.GetRecords("EarningIdNo = '" & otRegularEarning.IdNo.ToString() & "' and PayrollIdNo = '" & payrollIdNo.ToString() & "'")
        '        curHPayEarnings = _payrollPayElementDao.GetRecords("EarningIdNo = '" & otHolidayEarning.IdNo.ToString() & "' and PayrollIdNo = '" & payrollIdNo.ToString() & "'")
        '        curSPayEarnings = _payrollPayElementDao.GetRecords("EarningIdNo = '" & otSpecialEarning.IdNo.ToString() & "' and PayrollIdNo = '" & payrollIdNo.ToString() & "'")
        '        If curRPayEarnings IsNot Nothing Then
        '            payrollEarnings.AddRange(curRPayEarnings)
        '        End If
        '        If curHPayEarnings IsNot Nothing Then
        '            payrollEarnings.AddRange(curHPayEarnings)
        '        End If
        '        If curSPayEarnings IsNot Nothing Then
        '            payrollEarnings.AddRange(curSPayEarnings)
        '        End If
        '    End If
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
        '                    If regenerate Then
        '                        If item.OvertimeRegular <> 0 Then
        '                            ReMakePayrollOt(payrollEarnings, payrollIdNo, item.OvertimeRegular, otRegularUnit, empOtRegularRate, otRegularEarning, employeeIdNo)
        '                        End If
        '                        If item.OvertimeHoliday <> 0 Then
        '                            ReMakePayrollOt(payrollEarnings, payrollIdNo, item.OvertimeHoliday, otHolidayUnit, empOtHolidayRate, otHolidayEarning, employeeIdNo)
        '                        End If
        '                        If item.OvertimeSpecial <> 0 Then
        '                            ReMakePayrollOt(payrollEarnings, payrollIdNo, item.OvertimeSpecial, otSpecialUnit, empOtSpecialRate, otSpecialEarning, employeeIdNo)
        '                        End If
        '                    Else
        '                        If item.OvertimeRegular <> 0 Then
        '                            MakePayrollOt(payrollIdNo, item.OvertimeRegular, otRegularUnit, empOtRegularRate, otRegularEarning, employeeIdNo)
        '                        End If
        '                        If item.OvertimeHoliday <> 0 Then
        '                            MakePayrollOt(payrollIdNo, item.OvertimeHoliday, otHolidayUnit, empOtHolidayRate, otHolidayEarning, employeeIdNo)
        '                        End If
        '                        If item.OvertimeSpecial <> 0 Then
        '                            MakePayrollOt(payrollIdNo, item.OvertimeSpecial, otSpecialUnit, empOtSpecialRate, otSpecialEarning, employeeIdNo)
        '                        End If
        '                    End If
        '                End If
        '            End If
        '            progressBar.Value = progressBar.Value + 1
        '        Next
        '    End If
        'End Sub

        Private Sub MakePayrollOt(payrollIdNo As Short, otHours As Decimal, otUnit As String, otRate As Decimal, otEarning As Earning, employeeIdNo As Integer)
            Dim otAmount As Decimal = ComputeOtAmount(otEarning, otHours, otRate)
            AddEarning(employeeIdNo, otAmount, payrollIdNo, otEarning.IdNo)
        End Sub

        'Private Sub ReMakePayrollOt(payEarnings As List(Of PayrollEarning), payrollIdNo As Short, otHours As Decimal, otUnit As String, otRate As Decimal, otEarning As Earning, employeeIdNo As Integer)
        '    Dim otAmount As Decimal = ComputeOtAmount(otEarning, otHours, otRate)
        '    Dim payrollEarning As PayrollEarning = payEarnings.Find(Function(value As PayrollEarning)
        '                                                                Return value.EmployeeIdNo = employeeIdNo And value.EarningIdNo = otEarning.IdNo
        '                                                            End Function)
        '    If payrollEarning Is Nothing Then
        '        AddEarning(employeeIdNo, otAmount, payrollIdNo, otEarning.IdNo)
        '    Else
        '        UpdateEarning(otAmount, payrollEarning)
        '    End If
        'End Sub

        Private Shared Function ComputeOtAmount(otEarning As Earning, otHours As Decimal, otRate As Decimal) As Decimal
            Dim otAmount As Decimal
            If otEarning IsNot Nothing Then
                otAmount = otHours * IIf(IsDBNull(otRate), 0, otRate)
            Else
                otAmount = otHours * IIf(IsDBNull(otEarning.Rate), 0, otEarning.Rate)
            End If
            Return otAmount
        End Function

        'Private Sub MakeDeductions(employeeIdNo As Int32, amount As Decimal, deductionIdNo As Int16, payDeductions As List(Of PayrollDeduction), payrollIdNo As Short)
        '    If amount <> 0 Then
        '        Dim deduction As PayrollDeduction = payDeductions.Find(Function(value As PayrollDeduction)
        '                                                                   Return value.EmployeeIdNo = employeeIdNo And value.DeductionIdNo = deductionIdNo
        '                                                               End Function)
        '        If deduction Is Nothing Then
        '            AddDeduction(employeeIdNo, amount, payrollIdNo, deductionIdNo)
        '        Else
        '            UpdateDeduction(amount, deduction)
        '        End If
        '    End If
        'End Sub

        'Private Sub MakeEarnings(employeeIdNo As Int32, amount As Decimal, earningIdNo As Int16, payEarnings As List(Of PayrollEarning), payrollIdNo As Short)
        '    If amount <> 0 Then
        '        Dim earning As PayrollEarning = payEarnings.Find(Function(value As PayrollEarning)
        '                                                             Return value.EmployeeIdNo = employeeIdNo And value.EarningIdNo = earningIdNo
        '                                                         End Function)
        '        If earning Is Nothing Then
        '            AddEarning(employeeIdNo, amount, payrollIdNo, earningIdNo)
        '        Else
        '            UpdateEarning(amount, earning)
        '        End If
        '    End If
        'End Sub

        'Private Sub UpdateDeduction(amount As Decimal, deduction As PayrollDeduction)
        '    If amount <> 0 Then
        '        Dim updateDataRow As DataRow
        '        updateDataRow = _dtDeductionUpdateTable.NewRow()
        '        updateDataRow("Amount") = amount
        '        updateDataRow("DeductionIdNo") = deduction.DeductionIdNo
        '        updateDataRow("EmployeeIdNo") = deduction.EmployeeIdNo
        '        updateDataRow("IdNo") = deduction.IdNo
        '        updateDataRow("PayrollIdNo") = deduction.PayrollIdNo
        '        _dtDeductionUpdateTable.Rows.Add(updateDataRow)
        '    End If
        'End Sub

    End Class

End Namespace