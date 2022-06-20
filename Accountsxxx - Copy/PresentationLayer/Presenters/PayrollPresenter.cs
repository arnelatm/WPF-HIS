using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using AATM.Common.PresentationLayer.Presenters;
using AATM.Libraries.GlobalFuncNSub;
using AATM.Libraries.MessagingLibrary;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AATM.Accounts.PresentationLayer.Presenters
{
    public class PayrollPresenter<TM> : CommonPresenterNew<PresentationLayer.Views.Interfaces.IPayrollView, TM> where TM : new()
    {
        protected DataTable DtInsertTable = new DataTable();
        protected DataTable DtUpdateTable = new DataTable();
        protected DataTable DtOtInsertTable = new DataTable();
        protected DataTable DtOtUpdateTable = new DataTable();
        protected DataTable DtEarnInsertTable = new DataTable();
        protected DataTable DtEarnUpdateTable = new DataTable();
        private Accounts.ServiceLayer.ActionService.AccountsService _attendanceItemService = new Accounts.ServiceLayer.ActionService.AccountsService("AttendanceItem");
        private Accounts.ServiceLayer.ActionService.AccountsService _otWorkHourService = new Accounts.ServiceLayer.ActionService.AccountsService("OtWorkHour");
        private bool _reinitialize = false;
        private readonly object _payrollEarning;
        private readonly List<PresentationLayer.Models.PayrollPayElementModel> _payrollPayElements = new List<PresentationLayer.Models.PayrollPayElementModel>();
        private readonly List<PresentationLayer.Models.PayrollPayElementModel> _savedPayrollPayElements = new List<PresentationLayer.Models.PayrollPayElementModel>();
        private readonly List<PresentationLayer.Models.PayElementModel> _computedPayElements = new List<PresentationLayer.Models.PayElementModel>();
        private readonly List<PresentationLayer.Models.PayElementModel> _globalEarnings = new List<PresentationLayer.Models.PayElementModel>();
        private readonly List<Accounts.BusinessLayer.OtWorkHour> _otWorkHoursModel = new List<Accounts.BusinessLayer.OtWorkHour>();
        private short _daysInTheMonth;
        private readonly DateTime _endDate;
        private Accounts.PayFrequencySelection _payFrequency;
        private short _payrollIdNo;
        private readonly string _deductionComputationMethod = "1";
        private readonly DataTable _dtPayrollDetailInsertTable = new DataTable();
        private readonly DataTable _dtPayrollDetailUpdateTable = new DataTable();
        private readonly Accounts.ServiceLayer.ActionService.AccountsService _payCycleService = new Accounts.ServiceLayer.ActionService.AccountsService("PayCycle");
        private readonly Accounts.ServiceLayer.ActionService.AccountsService _payElementsService = new Accounts.ServiceLayer.ActionService.AccountsService("PayElement");
        private readonly Accounts.ServiceLayer.ActionService.AccountsService _payElementItemsService = new Accounts.ServiceLayer.ActionService.AccountsService("PayElementItem");
        private readonly Accounts.ServiceLayer.ActionService.AccountsService _payrollDetailsService = new Accounts.ServiceLayer.ActionService.AccountsService("PayrollDetail");
        private readonly Accounts.ServiceLayer.ActionService.AccountsService _payrollPayElementsService = new Accounts.ServiceLayer.ActionService.AccountsService("PayrollPayElement");
        private readonly object _computedPayElementType = GlobalFunctions.EnumToCode(Accounts.PayElementTypeSelection.Computed);
        private readonly object _regularType = GlobalFunctions.EnumToCode(Accounts.PayElementTypeSelection.Regular);
        private readonly object _globalType = GlobalFunctions.EnumToCode(Accounts.PayElementTypeSelection.Global);
        private readonly object _computedType = GlobalFunctions.EnumToCode(Accounts.PayElementTypeSelection.Computed);
        private readonly object _onDemandType = GlobalFunctions.EnumToCode(Accounts.PayElementTypeSelection.OnDemand);
        private readonly object _factorType = GlobalFunctions.EnumToCode(Accounts.CalculationTypeSelection.Factor);
        private readonly object _fixedAmountType = GlobalFunctions.EnumToCode(Accounts.CalculationTypeSelection.FixedAmount);
        private readonly object _fixedRateType = GlobalFunctions.EnumToCode(Accounts.CalculationTypeSelection.FixedRate);
        private readonly object _variableType = GlobalFunctions.EnumToCode(Accounts.CalculationTypeSelection.Variable);
        private readonly object _daysOffType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.DaysOff);
        private readonly object _daysPresentType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.DaysPresent);
        private readonly object _daysLeaveWithoutPayType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.DaysLeaveWithoutPay);
        private readonly object _daysPaidType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.DaysPaid);
        private readonly object _daysVacationType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.DaysVacationLeave);
        private readonly object _overtimeRegularType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.OvertimeRegular);
        private readonly object _overtimeHolidayType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.OvertimeHoliday);
        private readonly object _overTimeSpecialType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.OvertimeSpecial);
        private readonly object _hoursWorkedType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.HoursWorked);
        private readonly object _daysLeaveWithPayType = GlobalFunctions.EnumToCode(Accounts.QuantityTypeSelection.DaysLeaveWithPay);
        private readonly object _payElementType = GlobalFunctions.EnumToCode(Accounts.PayElementKindSelection.Earning);
        private readonly object _deductionType = GlobalFunctions.EnumToCode(Accounts.PayElementKindSelection.Deduction);
        private readonly object _factorPercentType = GlobalFunctions.EnumToCode(Accounts.FactorTypeSelection.PercentOfBasePaymentRate);
        private readonly object _factorMultiplyType = GlobalFunctions.EnumToCode(Accounts.FactorTypeSelection.MultiplyBasePaymentRate);
        private readonly object _factorDivideType = GlobalFunctions.EnumToCode(Accounts.FactorTypeSelection.DivideBasePaymentRate);
        private readonly object _serviceAccounts;
        private bool _roundToWholeNumber = true;

        public PayrollPresenter(PresentationLayer.Views.Interfaces.IPayrollView view) : base(view)
        {
            NewRecordInitialized += OnNewRecordInitialized;
            BeforeSave += OnBeforeSave;
            RecordAddedSuccessfully += SaveChildren;
            RecordUpdatedSuccessfully += SaveChildren;
            Service = new Accounts.ServiceLayer.ActionService.AccountsService("Payroll");
            TreeViewMainField = "PayrollName";
            TreeViewSecondaryField = "PayrollCode";
            TableName = "Payroll";
            SortOrderKey = "EndDate";

            // _attendanceItemService = New AccountsService("AttendanceItem", Nothing, Nothing)
            // _otWorkHourService = New AccountsService("OtWorkHour", Nothing, Nothing)

            view.InitializeAttendance += (_) => this.InitializeAttendance();
            view.InitializeOvertime += (_) => this.InitializeOvertime();
            view.GenerateRegularPayElements += (_) => this.GenerateRegularPayElements();
            CreateDataTable(ref DtInsertTable, new[] { { "DaysAbsentWithoutPay", typeof(decimal) }, { "DaysAbsentWithPay", typeof(decimal) }, { "DaysOff", typeof(decimal) }, { "DaysPresent", typeof(decimal) }, { "DaysVacationLeave", typeof(decimal) }, { "EmployeeIdNo", typeof(int) }, { "PayrollIdNo", typeof(short) }, { "Sequence", typeof(short) } });
            CreateDataTable(ref DtUpdateTable, new[] { { "DaysAbsentWithoutPay", typeof(decimal) }, { "DaysAbsentWithPay", typeof(decimal) }, { "DaysOff", typeof(decimal) }, { "DaysPresent", typeof(decimal) }, { "DaysVacationLeave", typeof(decimal) }, { "EmployeeIdNo", typeof(int) }, { "IdNo", typeof(int) }, { "PayrollIdNo", typeof(short) }, { "Sequence", typeof(short) } });
            CreateDataTable(ref DtOtInsertTable, new[] { { "EmployeeIdNo", typeof(int) }, { "HoursWorked", typeof(decimal) }, { "OvertimeHoliday", typeof(decimal) }, { "OvertimeRegular", typeof(decimal) }, { "OvertimeSpecial", typeof(decimal) }, { "PayrollIdNo", typeof(short) }, { "Sequence", typeof(short) } });
            CreateDataTable(ref DtOtUpdateTable, new[] { { "EmployeeIdNo", typeof(int) }, { "HoursWorked", typeof(decimal) }, { "IdNo", typeof(int) }, { "OvertimeHoliday", typeof(decimal) }, { "OvertimeRegular", typeof(decimal) }, { "OvertimeSpecial", typeof(decimal) }, { "PayrollIdNo", typeof(short) }, { "Sequence", typeof(short) } });

            // CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            // {"EarningIdNo", GetType(Int16)},
            // {"EmployeeIdNo", GetType(Int32)},
            // {"PayrollIdNo", GetType(Int16)}
            // })

            // CreateDataTable(DtEarnInsertTable, {{"Amount", GetType(Decimal)},
            // {"EarningIdNo", GetType(Int16)},
            // {"EmployeeIdNo", GetType(Int32)},
            // {"IdNo", GetType(Int32)},
            // {"PayrollIdNo", GetType(Int16)}
            // })

        }

        public void InitializeMonthlyPayroll(PresentationLayer.Models.PayCycleModel payCycleRecord)
        {
            if (View.StartDate == default(DateTime) & View.EndDate == default(DateTime))
            {
                if (payCycleRecord.PayCycleCode == "Month")
                {
                    int nIdNoMax;
                    PresentationLayer.Models.PayrollModel maxRecord;
                    string payMonthText = "Payroll for the Month of";
                    string PayrollText = "Payroll for the Period";
                    nIdNoMax = Conversions.ToInteger(Service.GetFieldOnMaxField("EndDate", "Payroll", "IdNo", "PayCycleIdNo = " + payCycleRecord.IdNo.ToString()));
                    maxRecord = (PresentationLayer.Models.PayrollModel)Service.GetRecordByIdNo<PresentationLayer.Models.PayrollModel>(nIdNoMax);
                    View.StartDate = maxRecord.EndDate.AddDays(1d);
                    var arabicCulture = new CultureInfo("ar-ae", false);
                    if (View.StartDate.Day == 1)
                    {
                        View.EndDate = View.StartDate.AddMonths(1).AddDays(-1);
                        View.PayrollName = payMonthText + " " + DateAndTime.MonthName(DateAndTime.Month(View.EndDate)) + " " + DateAndTime.Year(View.EndDate).ToString();
                        View.PayrollNameAra = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Messaging.TranslateCaption(payMonthText, "ar-SA"), GlobalFunctions.GetMonthNamesInCulture(ref arabicCulture)((object)(DateAndTime.Month(View.EndDate) - 1))), " "), DateAndTime.Year(View.EndDate).ToString()));
                    }
                    else
                    {
                        View.EndDate = maxRecord.EndDate.AddMonths(1);
                        View.PayrollName = PayrollText + " " + View.StartDate.ToString() + " to " + View.EndDate.ToString();
                        View.PayrollNameAra = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Messaging.TranslateCaption(PayrollText, "ar-SA") + " ", GlobalFunctions.GetMonthNamesInCulture(ref arabicCulture)((object)DateAndTime.Month(View.EndDate))), " "), DateAndTime.Year(View.EndDate).ToString()));
                    }

                    View.PayrollCode = "M" + View.EndDate.ToString("yyMM");
                }
            }
        }

        public void OnNewRecordInitialized()
        {
            int nIdNoMax;
            PresentationLayer.Models.PayrollModel maxRecord;
            string payMonthText = "Payroll for the Month of";
            string PayrollText = "Payroll for the Period";
            nIdNoMax = Conversions.ToInteger(Service.GetFieldOnMaxField("EndDate", "Payroll", "IdNo", "PayCycleIdNo = 1")); // + View.PayCycleIdNo.ToString())
            if (nIdNoMax == 0)
            {
                var now = DateAndTime.Today;
                View.EndDate = DateAndTime.DateAdd(DateInterval.Day, DateAndTime.Day(now) * -1, now);
                View.StartDate = DateAndTime.DateAdd(DateInterval.Day, (double)(DateAndTime.Day(View.EndDate) * -1 + 1), View.EndDate);
            }
            else
            {
                maxRecord = (PresentationLayer.Models.PayrollModel)Service.GetRecordByIdNo<PresentationLayer.Models.PayrollModel>(nIdNoMax);
                View.StartDate = maxRecord.EndDate.AddDays(1d);
                if (View.StartDate.Day == 1)
                {
                    View.EndDate = View.StartDate.AddMonths(1).AddDays(-1);
                }
                else
                {
                    View.EndDate = maxRecord.EndDate.AddMonths(1);
                }
            }

            View.PayCycleIdNo = 1;
            var arabicCulture = new CultureInfo("ar-ae", false);
            if (View.StartDate.Day == 1 && DateAndTime.DateAdd(DateInterval.Day, (double)(DateAndTime.Day(View.EndDate) * -1 + 1), View.EndDate) == View.StartDate)
            {
                View.PayrollName = payMonthText + " " + DateAndTime.MonthName(DateAndTime.Month(View.EndDate)) + " " + DateAndTime.Year(View.EndDate).ToString();
                View.PayrollNameAra = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.AddObject(Messaging.TranslateCaption(payMonthText, "ar-SA"), GlobalFunctions.GetMonthNamesInCulture(ref arabicCulture)((object)(DateAndTime.Month(View.EndDate) - 1))), " "), DateAndTime.Year(View.EndDate).ToString()));
            }
            else
            {
                View.PayrollName = PayrollText + " " + View.StartDate.ToString() + " to " + View.EndDate.ToString();
                View.PayrollNameAra = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Messaging.TranslateCaption(PayrollText, "ar-SA") + " ", GlobalFunctions.GetMonthNamesInCulture(ref arabicCulture)((object)DateAndTime.Month(View.EndDate))), " "), DateAndTime.Year(View.EndDate).ToString()));
            }

            View.PayrollCode = "M" + View.EndDate.ToString("yyMM");
        }

        public void OnBeforeSave()
        {
            if (!CancelSave)
            {
                object argdataViews = (object)View.PayrollAttendance;
                ViewToDataTables(ref argdataViews, ref DtInsertTable, ref DtUpdateTable, AttendanceItemFillData, AttendanceItemFilter, "IdNo");
                View.PayrollAttendance = (List<PresentationLayer.Views.AttendanceItemView>)argdataViews;
                object argdataViews1 = (object)View.PayrollOvertime;
                ViewToDataTables(ref argdataViews1, ref DtOtInsertTable, ref DtOtUpdateTable, OtWorkHourFillData, OtWorkHourFilter, "IdNo");
                View.PayrollOvertime = (List<PresentationLayer.Views.OtWorkHourView>)argdataViews1;
            }
            // For Each item In View.PayrollAttendance
            // If item.Equals(DBNull.Value) Then
            // item.Notes = ""
            // End If
            // If item.Notes Is Nothing Then
            // item.Notes = ""
            // End If
            // Next
        }

        public void InitializeAttendance()
        {
            View.PayFrequency = Conversions.ToChar(GetFieldWithIdNo((object)View.PayCycleIdNo, "PayCycle", "PayFrequency"));
            string employeeFilter = "PayCycleIdNo = " + View.PayCycleIdNo.ToString() + " And Active = 1";
            var activeEmployees = GetRecords("Employee", "EmployeeName", new[] { "IdNo", "EmployeeName", "HiredDate", "ReleasedDate" }, employeeFilter);
            // Dim earningDao = New EarningDao
            // Dim earnings = earningDao.GetAll()
            var numberOfEmployees = Conversion.Int(Operators.DivideObject(activeEmployees.Count(), 4));
            short daysInPeriod;
            short daysOffInPeriod;
            int seq;
            DateTime dateHired;
            DateTime? dateReleased;
            int empId;
            string empName;
            bool empFound = false;
            var absenceService = new Accounts.ServiceLayer.ActionService.AccountsService("EmployeeAbsence");
            object argsortKey = "IdNo";
            var absences = absenceService.GetRecordsWithGroupIdNo<EmployeeAbsenceModel>((object)View.IdNo, ref argsortKey);
            seq = View.PayrollAttendance.Count + absences.Count + 1;
            daysInPeriod = (short)(DateAndTime.DateDiff(DateInterval.Day, View.StartDate, View.EndDate) + 1L);
            daysOffInPeriod = (short)PayrollPresenter<TM>.FridaysInPeriod(View.StartDate, View.EndDate);
            if (View.PayrollAttendance.Any())
            {
                _reinitialize = false;
            }
            else
            {
                _reinitialize = true;
            }

            var progressDisplayForm = new Libraries.CBaseControlsLibrary.DisplayProgressForm();
            int counter = 0;
            progressDisplayForm.Show();
            progressDisplayForm.InitializeDisplay(Conversions.ToInteger(Operators.AddObject(numberOfEmployees, absences.Count)));
            for (int i = 1, loopTo = Conversions.ToInteger(numberOfEmployees); i <= loopTo; i++)
            {
                empId = Conversions.ToInteger(activeEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 4), 4)));
                empName = Conversions.ToString(activeEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 4), 3)));
                dateHired = Conversions.ToDate(activeEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 4), 2)));
                dateReleased = (DateTime?)Interaction.IIf(Information.IsDBNull(activeEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 4), 1))), null, activeEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 4), 1)));
                if (empId == 291)
                {
                    Debugger.Break();
                }

                PresentationLayer.Views.AttendanceItemView empAttendance;
                if (!_reinitialize)
                {
                    empAttendance = View.PayrollAttendance.Find(c => c.EmployeeIdNo == empId);
                    if (empAttendance is null)
                    {
                        empFound = false;
                        if (dateHired <= View.EndDate && (dateReleased is null || dateReleased >= View.StartDate == true || dateReleased > View.EndDate == true))
                        {
                            AddEmployeeAttendance(dateHired, dateReleased, (short)empId, empName, daysInPeriod, daysOffInPeriod, (short)seq);
                            seq = seq + 1;
                        }
                        else
                        {
                            View.PayrollAttendance.Remove(empAttendance);
                        }
                    }
                    else
                    {
                        empFound = true;
                        InitializeEmployeeAttendance(ref empAttendance, dateHired, dateReleased, daysInPeriod, daysOffInPeriod);
                    }
                }
                else if (dateHired <= View.EndDate && (dateReleased is null || dateReleased >= View.StartDate == true || dateReleased > View.EndDate == true))
                {
                    AddEmployeeAttendance(dateHired, dateReleased, (short)empId, empName, daysInPeriod, daysOffInPeriod, (short)seq);
                    seq = seq + 1;
                }
                // If dateHired <= View.EndDate AndAlso (dateReleased Is Nothing OrElse dateReleased >= View.StartDate OrElse dateReleased > View.EndDate) Then
                // UpdateEmployeeAttendance(empAttendance, dateHired, dateReleased, daysInPeriod, daysOffInPeriod)
                // If empAttendance.DaysAbsentWithoutPay <> empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysPresent - empAttendance.DaysVacationLeave Then
                // empAttendance.DaysAbsentWithoutPay = empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysPresent - empAttendance.DaysVacationLeave
                // End If
                // Else
                // If empFound Then
                // View.PayrollAttendance.Remove(empAttendance)
                // End If
                // End If
                counter = counter + 1;
                progressDisplayForm.UpdateProgressBar(counter);
            }

            if (_reinitialize)
            {
                short i = 1;
                foreach (var item in View.PayrollAttendance)
                {
                    item.Sequence = i;
                    i = (short)(i + 1);
                }
            }

            foreach (var absence in absences)
            {
                int empIdNo = absence.EmployeeIdNo;
                PresentationLayer.Views.AttendanceItemView empAttendance;
                empAttendance = View.PayrollAttendance.Find(c => c.EmployeeIdNo == empIdNo);
                if (empAttendance is object)
                {
                    empAttendance.DaysAbsentWithoutPay += Math.Round(absence.EquivalentHours / 8m, 4);
                    empAttendance.DaysPresent -= Math.Round(absence.EquivalentHours / 8m, 4);
                }

                counter = counter + 1;
                progressDisplayForm.UpdateProgressBar(counter);
            }

            progressDisplayForm.UpdateProgressBar(counter);
            progressDisplayForm.Close();
            Messaging.Show(true, "MsgAttendanceInitializationCompleted");
        }

        public void InitializeOvertime()
        {
            View.PayFrequency = Conversions.ToChar(GetFieldWithIdNo((object)View.PayCycleIdNo, "PayCycle", "PayFrequency"));
            string employeeFilter = "PayCycleIdNo = " + View.PayCycleIdNo.ToString();
            var matchedEmployees = GetRecords("Employee", "EmployeeName", new[] { "IdNo", "HiredDate", "ReleasedDate" }, employeeFilter);
            var numberOfEmployees = Conversion.Int(Operators.DivideObject(matchedEmployees.Count(), 3));
            short seq;
            DateTime dateHired;
            DateTime? dateReleased;
            int empId;
            bool empFound = false;
            seq = (short)(View.PayrollOvertime.Count + 1);
            if (View.PayrollOvertime.Any())
            {
                _reinitialize = true;
            }
            else
            {
                _reinitialize = false;
            }

            var progressDisplayForm = new Libraries.CBaseControlsLibrary.DisplayProgressForm();
            int counter = 0;
            progressDisplayForm.Show();
            progressDisplayForm.InitializeDisplay(Conversions.ToInteger(Operators.AddObject(numberOfEmployees, 1)));
            for (int i = 1, loopTo = Conversions.ToInteger(numberOfEmployees); i <= loopTo; i++)
            {
                empId = Conversions.ToInteger(matchedEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 3), 3)));
                dateHired = Conversions.ToDate(matchedEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 3), 2)));
                dateReleased = (DateTime?)Interaction.IIf(Information.IsDBNull(matchedEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 3), 1))), null, matchedEmployees(Operators.SubtractObject(Operators.MultiplyObject(i, 3), 1)));
                if (_reinitialize)
                {
                    PresentationLayer.Views.OtWorkHourView empOvertime;
                    empOvertime = View.PayrollOvertime.Find(c => c.EmployeeIdNo == empId);
                    if (empOvertime is null)
                    {
                        empFound = false;
                    }
                    else
                    {
                        empFound = true;
                        if (dateHired <= View.EndDate && (dateReleased is null || dateReleased >= View.StartDate == true || dateReleased > View.EndDate == true))
                        {
                        }
                        // retain old data
                        else
                        {
                            View.PayrollOvertime.Remove(empOvertime);
                        }
                    }
                }

                if (empFound)
                {
                    continue;
                }

                if (dateHired <= View.EndDate && (dateReleased is null || dateReleased >= View.StartDate == true || dateReleased > View.EndDate == true))
                {
                    AddEmployeeOvertime(dateHired, dateReleased, (short)empId, seq);
                    seq = (short)(seq + 1);
                }

                counter = counter + 1;
                progressDisplayForm.UpdateProgressBar(counter);
            }

            if (_reinitialize)
            {
                short i = 1;
                foreach (var item in View.PayrollOvertime)
                {
                    item.Sequence = i;
                    i = (short)(i + 1);
                }
            }

            progressDisplayForm.UpdateProgressBar(counter + 1);
            progressDisplayForm.Close();
            Messaging.Show(true, "MsgOvertimeInitializationCompleted");
        }

        public void AddEmployeeAttendance(DateTime dateHired, DateTime? dateReleased, short empId, string empName, short daysInPeriod, short daysOffInPeriod, short seq)
        {
            var empAttendance = new PresentationLayer.Views.AttendanceItemView();
            var daysOff = default(short);
            var daysTotal = default(short);
            ComputeTotalDaysNOff(ref daysTotal, ref daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod);
            empAttendance.DaysTotal = daysTotal;
            empAttendance.DaysOff = daysOff;
            empAttendance.PayrollIdNo = View.IdNo;
            empAttendance.EmployeeIdNo = empId;
            empAttendance.EmployeeName = empName;
            empAttendance.Sequence = seq;
            empAttendance.DaysAbsentWithoutPay = 0m;
            empAttendance.DaysAbsentWithPay = 0m;
            empAttendance.DaysVacationLeave = 0m;
            empAttendance.DaysPresent = daysTotal - daysOff;
            View.PayrollAttendance.Add(empAttendance);
        }

        public void AddEmployeeOvertime(DateTime dateHired, DateTime? dateReleased, short empId, short seq)
        {
            var empOvertime = new PresentationLayer.Views.OtWorkHourView();
            empOvertime.EmployeeIdNo = empId;
            empOvertime.Sequence = seq;
            View.PayrollOvertime.Add(empOvertime);
        }

        public void InitializeEmployeeAttendance(ref PresentationLayer.Views.AttendanceItemView empAttendance, DateTime dateHired, DateTime? dateReleased, short daysInPeriod, short daysOffInPeriod)
        {
            var daysOff = default(short);
            var daysTotal = default(short);
            ComputeTotalDaysNOff(ref daysTotal, ref daysOff, dateHired, dateReleased, daysInPeriod, daysOffInPeriod);
            empAttendance.DaysTotal = daysTotal;
            empAttendance.DaysOff = daysOff;
            empAttendance.DaysAbsentWithoutPay = 0m;
            empAttendance.DaysAbsentWithPay = 0m;
            // empAttendance.DaysVacationLeave = 0
            empAttendance.DaysPresent = empAttendance.DaysTotal - empAttendance.DaysOff - empAttendance.DaysAbsentWithPay - empAttendance.DaysAbsentWithoutPay - empAttendance.DaysVacationLeave;
        }

        private void ComputeTotalDaysNOff(ref short daysTotal, ref short daysOff, DateTime dateHired, DateTime? dateReleased, short daysInPeriod, short daysOffInPeriod)
        {
            DateTime eDate;
            if (dateHired <= View.StartDate && (dateReleased is null || dateReleased > View.EndDate == true))
            {
                daysOff = daysOffInPeriod;
                daysTotal = daysInPeriod;
            }
            else
            {
                if (dateReleased is null || dateReleased > View.EndDate == true)
                {
                    eDate = View.EndDate;
                }
                else
                {
                    DateTime dDate; // need to do this because Date? type is not accepted by DateAdd function
                    dDate = (DateTime)dateReleased;
                    eDate = DateAndTime.DateAdd(DateInterval.Day, -1, dDate);
                }

                daysTotal = (short)(DateAndTime.DateDiff(DateInterval.Day, dateHired, eDate) + 1L);
                daysOff = (short)FridaysInPeriod(dateHired, eDate);
            }
        }

        public void SaveChildren(ref int retVal)
        {
            int passedValue = retVal;
            ServicesLayer.Services.Service argchildDataService = (ServicesLayer.Services.Service)_attendanceItemService;
            retVal = UpdateChildData(ref argchildDataService, DtUpdateTable, DtInsertTable, passedValue, "PayrollIdNo");
            if (retVal >= 0)
            {
                ServicesLayer.Services.Service argchildDataService1 = (ServicesLayer.Services.Service)_otWorkHourService;
                retVal = UpdateChildData(ref argchildDataService1, DtOtUpdateTable, DtOtInsertTable, passedValue, "PayrollIdNo");
            }
        }

        private void AttendanceItemFillData(ref object itemDataView, ref DataRow workRow)
        {
            workRow["DaysAbsentWithoutPay"] = itemDataView.DaysAbsentWithoutPay;
            workRow["DaysAbsentWithPay"] = itemDataView.DaysAbsentWithPay;
            workRow["DaysOff"] = itemDataView.DaysOff;
            workRow["DaysPresent"] = itemDataView.DaysPresent;
            workRow["DaysVacationLeave"] = itemDataView.DaysVacationLeave;
            workRow["EmployeeIdNo"] = itemDataView.EmployeeIdNo;
            workRow["PayrollIdNo"] = (object)View.IdNo;
        }

        public bool AttendanceItemFilter(object obj)
        {
            // If (obj.Debit = 0 AndAlso obj.Credit = 0 AndAlso obj.Sequence <> 1) Then
            // Return False
            // End If
            return true;
        }

        private void OtWorkHourFillData(ref object itemDataView, ref DataRow workRow)
        {
            workRow["EmployeeIdNo"] = itemDataView.EmployeeIdNo;
            workRow["HoursWorked"] = itemDataView.HoursWorked;
            workRow["OvertimeRegular"] = itemDataView.OvertimeRegular;
            workRow["OvertimeHoliday"] = itemDataView.OvertimeHoliday;
            workRow["OvertimeSpecial"] = itemDataView.OvertimeSpecial;
            workRow["PayrollIdNo"] = (object)View.IdNo;
        }

        public bool OtWorkHourFilter(object obj)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(obj.OvertimeRegular, 0, false)) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(obj.OvertimeHoliday, 0, false)) && Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(obj.OvertimeSpecial, 0, false)))
            {
                return false;
            }

            return true;
        }

        public static int FridaysInPeriod(DateTime begDate, DateTime endDate)
        {
            var count = default(int);
            var d = begDate;
            while (d != endDate)
            {
                if (d.DayOfWeek == DayOfWeek.Friday)
                {
                    count += 1;
                }

                d = d.AddDays(1d);
            }

            return count;
        }

        // Public Sub New(view As IPayrollView)
        // MyBase.New(view)
        // TableName = "Account"
        // ModelOfPresenter = New ModelAccounts("Payroll")
        // TableName = "Payroll"
        // SortOrderKey = "IdNo"
        // OriginalModel = New PayrollModel()
        // DataModel = New PayrollModel()
        // CreateDataTable(_dtPayrollPayElementInsertTable, {{"Amount", GetType(Decimal)},
        // {"EarningIdNo", GetType(Int16)},
        // {"EmployeeIdNo", GetType(Int32)},
        // {"PayrollIdNo", GetType(Int16)}
        // })
        // CreateDataTable(_dtPayrollPayElementUpdateTable, {{"Amount", GetType(Decimal)},
        // {"EarningIdNo", GetType(Int16)},
        // {"EmployeeIdNo", GetType(Int32)},
        // {"IdNo", GetType(Int32)},
        // {"PayrollIdNo", GetType(Int16)}
        // })

        // CreateDataTable(_dtPayrollDetailInsertTable, {{"EmployeeIdNo", GetType(Int32)},
        // {"PayrollIdNo", GetType(Int16)}
        // })

        // CreateDataTable(_dtPayrollDetailUpdateTable, {{"EmployeeIdNo", GetType(Int32)},
        // {"IdNo", GetType(Int32)},
        // {"PayrollIdNo", GetType(Int16)}
        // })

        // '_absenceDeductions = New List(Of Deduction)
        // 'Dim absencesDeductions = _deductionsDao.GetDaoRecords("DeductionType = '" & .Computed) & "' and QuantityType = '" & EnumToCode(AttendanceUnitSelection.OvertimeSpecial) & "'")
        // 'GlobalVariables.Mapper.Map(absencesDeductions, _absenceDeductions)
        // _deductionComputationMethod = GetAppSetting($"PYCM", "Payroll", "Deduction Computation Method")

        // End Sub

        public void GenerateRegularPayElements()
        {
            _payrollIdNo = View.IdNo;
            if (View.PayrollAttendance.Count == 0 & View.PayrollOvertime.Count == 0)
            {
                Messaging.Show(true, "MsgEmptyEmployeeAttendanceOt");
            }
            else
            {
                var payrollService = new Accounts.ServiceLayer.ActionService.AccountsService("Payroll");
                var payroll = payrollService.GetRecordByIdNo<PayrollModel>((int)View.IdNo);
                View.PayFrequency = _payCycleService.GetRecordByIdNo<PayCycleModel>((int)payroll.PayCycleIdNo).PayFrequency;
                List<Accounts.BusinessLayer.PayrollPayElement> payrollPayElements;
                _payFrequency = CodeToEnum<PayFrequencySelection>(Conversions.ToString(View.PayFrequency));
                if (_payFrequency == Accounts.PayFrequencySelection.Monthly)
                {
                    _daysInTheMonth = (short)DateTime.DaysInMonth(DateAndTime.Year(View.EndDate), DateAndTime.Month(View.EndDate));
                    object argsortKey = null;
                    payrollPayElements = _payrollPayElementsService.GetRecordsWithGroupIdNo<PayrollPayElement>((object)View.IdNo, sortKey: ref argsortKey);
                    // GlobalVariables.Mapper.Map(payrollPayElements, _payrollPayElements)
                    if (payrollPayElements.Count == 0)
                    {
                        bool argregenerate = false;
                        ProcessPayroll(ref argregenerate);
                    }
                    else if (Messaging.Show(true, "AskIfRegeneratePayroll", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        bool argregenerate1 = true;
                        ProcessPayroll(ref argregenerate1);
                        // Dim payAbsencesDeductions = _payrollDeductionDao.GetRecordsWithGroupIdNo(payrollIdNo)
                        // ReGenerateEmployeePayroll(progressBar)
                    }
                }
            }
        }

        private void ProcessPayroll(ref bool regenerate)
        {
            var dtPayrollPayElementInsertTable = new DataTable();
            var dtPayrollPayElementUpdateTable = new DataTable();
            _payrollPayElements.Clear();
            CreateDataTable(ref dtPayrollPayElementInsertTable, new[] { { "Amount", typeof(decimal) }, { "Generated", typeof(bool) }, { "PayElementIdNo", typeof(short) }, { "PayrollDetailIdNo", typeof(int) }, { "RecurringPayElementIdNo", typeof(int) } });
            CreateDataTable(ref dtPayrollPayElementUpdateTable, new[] { { "Amount", typeof(decimal) }, { "Generated", typeof(bool) }, { "IdNo", typeof(int) }, { "PayElementIdNo", typeof(short) }, { "PayrollDetailIdNo", typeof(int) }, { "RecurringPayElementIdNo", typeof(int) } });
            var dtPayrollDetailInsertTable = new DataTable();
            var dtPayrollDetailUpdateTable = new DataTable();
            CreateDataTable(ref dtPayrollDetailInsertTable, new[] { { "BankTransfer", typeof(bool) }, { "EmployeeIdNo", typeof(int) }, { "PayrollIdNo", typeof(short) } });
            CreateDataTable(ref dtPayrollDetailUpdateTable, new[] { { "BankTransfer", typeof(bool) }, { "EmployeeIdNo", typeof(int) }, { "IdNo", typeof(int) }, { "PayrollIdNo", typeof(short) } });
            List<PresentationLayer.Models.PayrollDetailModel> payrollDetailsModel;
            payrollDetailsModel = (List<PresentationLayer.Models.PayrollDetailModel>)CreatePayrollDetails();
            List<Accounts.BusinessLayer.PayElement> computedEarnings;
            computedEarnings = (List<Accounts.BusinessLayer.PayElement>)_payElementsService.GetDaoRecords(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("PayElementType = '", _computedType), "' and Summary=0")));
            GlobalVariables.Mapper.Map(computedEarnings, _computedPayElements);
            List<Accounts.BusinessLayer.PayElement> globalEarnings;
            globalEarnings = (List<Accounts.BusinessLayer.PayElement>)_payElementsService.GetDaoRecords(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("CalculationType = '", _globalType), "' and not Summary=0")));
            GlobalVariables.Mapper.Map(globalEarnings, _globalEarnings);
            var progressDisplayForm = new Libraries.CBaseControlsLibrary.DisplayProgressForm();
            int counter = 0;
            progressDisplayForm.Show();
            progressDisplayForm.InitializeDisplay(payrollDetailsModel.Count + 2);
            if (regenerate)
            {
                object argsortKey = null;
                var savedPayrollPayElements = _payrollPayElementsService.GetRecordsWithGroupIdNo<PayrollPayElement>(_payrollIdNo, sortKey: ref argsortKey);
                GlobalVariables.Mapper.Map(savedPayrollPayElements, _savedPayrollPayElements);
            }

            var otWorkHoursService = new Accounts.ServiceLayer.ActionService.AccountsService("OtWorkHour");
            object argsortKey1 = null;
            var otWorkHours = otWorkHoursService.GetRecordsWithGroupIdNo<OtWorkHour>(_payrollIdNo, sortKey: ref argsortKey1);
            GlobalVariables.Mapper.Map(otWorkHours, _otWorkHoursModel);
            int payrollDetailIdNo;
            foreach (var payrollDetail in payrollDetailsModel)
            {
                if (payrollDetail.IdNo == 0)
                {
                    DataRow dataRow;
                    dataRow = dtPayrollDetailInsertTable.NewRow();
                    dataRow["BankTransfer"] = (object)payrollDetail.BankTransfer;
                    dataRow["EmployeeIdNo"] = (object)payrollDetail.EmployeeIdNo;
                    dataRow["PayrollIdNo"] = (object)View.IdNo;
                    dtPayrollDetailInsertTable.Rows.Add(dataRow);
                }
                else
                {
                    DataRow dataRow;
                    dataRow = dtPayrollDetailUpdateTable.NewRow();
                    dataRow["BankTransfer"] = (object)payrollDetail.BankTransfer;
                    dataRow["IdNo"] = (object)payrollDetail.IdNo;
                    dataRow["EmployeeIdNo"] = (object)payrollDetail.EmployeeIdNo;
                    dataRow["PayrollIdNo"] = (object)payrollDetail.PayrollIdNo;
                    dtPayrollDetailUpdateTable.Rows.Add(dataRow);
                }
            }

            _payrollDetailsService.UpdateInsertTvp(ref dtPayrollDetailUpdateTable, ref dtPayrollDetailInsertTable, (int)View.IdNo);
            List<Accounts.BusinessLayer.PayrollDetail> payrollDetails;
            object argsortKey2 = null;
            payrollDetails = _payrollDetailsService.GetRecordsWithGroupIdNo<PayrollDetail>((object)View.IdNo, sortKey: ref argsortKey2);
            GlobalVariables.Mapper.Map(payrollDetails, payrollDetailsModel);
            foreach (var payrollDetailModel in payrollDetailsModel)
            {
                var payrollDetail = new Accounts.BusinessLayer.PayrollDetail();
                GlobalVariables.Mapper.Map(payrollDetailModel, payrollDetail);
                if (payrollDetail.IdNo == 0)
                {
                    object argmodel = (object)payrollDetail;
                    payrollDetailIdNo = _payrollDetailsService.AddRecord(ref argmodel);
                }
                else
                {
                    payrollDetailIdNo = payrollDetail.IdNo;
                }

                this.GenerateRegularPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo);
                this.GenerateComputedPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo);
                this.GenerateGlobalPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo);
                this.GenerateRecurringPayElements(regenerate, payrollDetail.EmployeeIdNo, payrollDetailIdNo);
                counter = counter + 1;
                progressDisplayForm.UpdateProgressBar(counter);
            }

            if (regenerate)
            {
                foreach (var item in _payrollPayElements)
                {
                    DataRow dataRow;
                    if (item.IdNo == 0)
                    {
                        dataRow = dtPayrollPayElementInsertTable.NewRow();
                        dataRow["Amount"] = (object)item.Amount;
                        dataRow["Generated"] = true;
                        dataRow["PayElementIdNo"] = (object)item.PayElementIdNo;
                        dataRow["PayrollDetailIdNo"] = (object)item.PayrollDetailIdNo;
                        dataRow["RecurringPayElementIdNo"] = (object)item.RecurringPayElementIdNo;
                        dtPayrollPayElementInsertTable.Rows.Add(dataRow);
                    }
                    else
                    {
                        dataRow = dtPayrollPayElementUpdateTable.NewRow();
                        dataRow = dtPayrollPayElementUpdateTable.NewRow();
                        dataRow["Amount"] = (object)item.Amount;
                        dataRow["Generated"] = true;
                        dataRow["IdNo"] = (object)item.IdNo;
                        dataRow["PayElementIdNo"] = (object)item.PayElementIdNo;
                        dataRow["PayrollDetailIdNo"] = (object)item.PayrollDetailIdNo;
                        dataRow["RecurringPayElementIdNo"] = (object)item.RecurringPayElementIdNo;
                        dtPayrollPayElementUpdateTable.Rows.Add(dataRow);
                    }
                }

                foreach (var item in _savedPayrollPayElements)
                {
                    DataRow dataRow;
                    if (!item.Generated)
                    {
                        PresentationLayer.Models.PayrollDetailModel payrollDetail;
                        payrollDetail = payrollDetailsModel.Find(c => c.EmployeeIdNo == item.EmployeeIdNo);
                        if (payrollDetail is object)
                        {
                            dataRow = dtPayrollPayElementUpdateTable.NewRow();
                            dataRow["Amount"] = (object)item.Amount;
                            dataRow["Generated"] = false;
                            dataRow["IdNo"] = (object)item.IdNo;
                            dataRow["PayElementIdNo"] = (object)item.PayElementIdNo;
                            dataRow["PayrollDetailIdNo"] = (object)item.PayrollDetailIdNo;
                            dataRow["RecurringPayElementIdNo"] = (object)item.RecurringPayElementIdNo;
                            dtPayrollPayElementUpdateTable.Rows.Add(dataRow);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in _payrollPayElements)
                {
                    DataRow dataRow;
                    dataRow = dtPayrollPayElementInsertTable.NewRow();
                    dataRow["Amount"] = (object)item.Amount;
                    dataRow["Generated"] = true;
                    dataRow["PayElementIdNo"] = (object)item.PayElementIdNo;
                    dataRow["PayrollDetailIdNo"] = (object)item.PayrollDetailIdNo;
                    dataRow["RecurringPayElementIdNo"] = (object)item.RecurringPayElementIdNo;
                    dtPayrollPayElementInsertTable.Rows.Add(dataRow);
                }
            }

            counter = counter + 1;
            if (regenerate)
            {
                _payrollPayElementsService.UpdateInsertTvp(ref dtPayrollPayElementUpdateTable, ref dtPayrollPayElementInsertTable, _payrollIdNo);
                dtPayrollPayElementUpdateTable.Clear();
            }
            else
            {
                _payrollPayElementsService.InsertTvp(dtPayrollPayElementInsertTable);
                dtPayrollPayElementInsertTable.Clear();
            }

            _payrollPayElements.Clear();
            progressDisplayForm.UpdateProgressBar(counter + 1);
            progressDisplayForm.Close();
            Messaging.Show(true, "MsgPayrollGenerationCompleted");
        }

        private void GenerateRegularPayElements(bool regenerate, int employeeIdNo, int payrollDetailIdNo)
        {
            var empPayElements = new List<Accounts.BusinessLayer.EmployeePayElement>();
            var employeePayElementsService = new Accounts.ServiceLayer.ActionService.AccountsService("EmployeePayElement");
            object argsortKey = null;
            empPayElements = employeePayElementsService.GetRecordsWithGroupIdNo<EmployeePayElement>(employeeIdNo, sortKey: ref argsortKey);
            var empPayElementsModel = new List<PresentationLayer.Models.EmployeePayElementModel>();
            GlobalVariables.Mapper.Map(empPayElements, empPayElementsModel);
            decimal amount;
            foreach (PresentationLayer.Models.EmployeePayElementModel empPayElement in empPayElementsModel)
            {
                var payElement = new PresentationLayer.Models.PayElementModel();
                payElement = _payElementsService.GetRecordByIdNo<PayElementModel>((int)empPayElement.PayElementIdNo);
                if (payElement.Active)
                {
                    var payElementModel = new PresentationLayer.Models.PayElementModel();
                    GlobalVariables.Mapper.Map(payElement, payElementModel);
                    if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(payElement.CalculationType, _fixedAmountType, false)))
                    {
                        amount = Accounts.ServiceLayer.ActionService.AccountsModule.ComputePayAmount(_payFrequency, empPayElement.Amount, empPayElement.Unit);
                        if (!regenerate)
                        {
                            this.AddPayElement(employeeIdNo, amount, payElement.IdNo, (short)0, payrollDetailIdNo, default(int));
                        }
                        else
                        {
                            this.UpdatePayElement(employeeIdNo, amount, payElement.IdNo, payrollDetailIdNo, default(int));
                        }
                    }
                    else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(payElement.CalculationType, _fixedRateType, false)))
                    {
                        decimal rate = empPayElement.Rate;
                        if (rate != 0m)
                        {
                            decimal qty;
                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(payElement.QuantityType, _overtimeRegularType, false)) || Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(payElement.QuantityType, _overtimeHolidayType, false)) || Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(payElement.QuantityType, _overTimeSpecialType, false)) || Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(payElement.QuantityType, _hoursWorkedType, false)))
                            {
                                qty = Conversions.ToDecimal(this.ComputeQuantity(empPayElement.EmployeeIdNo, Conversions.ToString(payElement.QuantityType)));
                            }
                            else
                            {
                                qty = Conversions.ToDecimal(this.ComputeQuantity(empPayElement.EmployeeIdNo, Conversions.ToString(payElement.QuantityType)));
                            }

                            amount = rate * qty;
                            if (!regenerate)
                            {
                                this.AddPayElement(employeeIdNo, amount, payElement.IdNo, (short)0, payrollDetailIdNo, default(int));
                            }
                            else
                            {
                                this.UpdatePayElement(employeeIdNo, amount, payElement.IdNo, payrollDetailIdNo, default(int));
                            }
                        }
                    }
                }
            }
        }

        private List<Accounts.BusinessLayer.RecurringPayElement> _recurringPayElements = new List<Accounts.BusinessLayer.RecurringPayElement>();
        private readonly Accounts.ServiceLayer.ActionService.AccountsService _recurringPayElementService = new Accounts.ServiceLayer.ActionService.AccountsService("RecurringPayElement");

        private void GenerateRecurringPayElements(bool regenerate, int employeeIdNo, int payrollDetailIdNo)
        {
            _recurringPayElements = (List<Accounts.BusinessLayer.RecurringPayElement>)_recurringPayElementService.GetDaoRecords("TotalAmount < Amount and StartDate <= '" + View.StartDate.ToString() + "' and EmployeeIdNo = " + employeeIdNo.ToString());
            if (_recurringPayElements.Any())
            {
                decimal amount;
                foreach (Accounts.BusinessLayer.RecurringPayElement recurringPayElement in _recurringPayElements)
                {
                    if (recurringPayElement.TotalAmount < recurringPayElement.Amount)
                    {
                        amount = Math.Min(recurringPayElement.Amount - recurringPayElement.TotalAmount, recurringPayElement.PeriodicPayment);
                        if (!regenerate)
                        {
                            this.AddPayElement(employeeIdNo, amount, recurringPayElement.PayElementIdNo, (short)0, payrollDetailIdNo, recurringPayElement.IdNo);
                        }
                        else
                        {
                            this.UpdatePayElement(employeeIdNo, amount, recurringPayElement.PayElementIdNo, payrollDetailIdNo, recurringPayElement.IdNo);
                        }
                    }
                }
            }
        }

        public void InitializePayroll(object sender)
        {
            var payCycleRecord = _payCycleService.GetRecordByIdNo<PayCycleModel>((int)View.PayCycleIdNo);
            if (payCycleRecord is object)
            {
                // View.PayFrequency = CodeToEnum(Of PayFrequencySelection)(payCycleRecord.PayFrequency)
                if (AddMode)
                {
                    if (CodeToEnum<PayFrequencySelection>(Conversions.ToString(View.PayFrequency)) == Accounts.PayFrequencySelection.Monthly)
                    {
                        this.InitializeMonthlyPayroll(payCycleRecord);
                    }
                }
            }
        }

        // Private Sub GenerateRegularDeductions(regenerate As Boolean, employeeIdNo As Int32, payrollDetailIdNo As Int32)
        // Dim empDeductions As New List(Of EmployeePayElement)
        // empDeductions = _employeePayElementsService.GetRecordsWithGroupIdNo(employeeIdNo)
        // Dim EmpDeductionsModel As New List(Of EmployeePayElementModel)
        // GlobalVariables.Mapper.Map(empDeductions, EmpDeductionsModel)
        // Dim amount As Decimal
        // For Each empDeduction As EmployeePayElementModel In EmpDeductionsModel
        // Dim Deduction As New PayElement
        // Dim DeductionModel As New PayElementModel
        // 'If empDeduction.EmployeeIdNo = 323 Then
        // '    Debugger.Break()
        // 'End If
        // Deduction = _payElementsDao.GetRecordByIdNo(empDeduction.PayElementIdNo)
        // GlobalVariables.Mapper.Map(Deduction, DeductionModel)
        // If Deduction.CalculationType = _fixedAmountType Then
        // amount = ComputeFixedAmount(empDeduction.Amount, empDeduction.Unit)
        // If Not regenerate Then
        // AddPayElement(employeeIdNo, amount, Deduction.IdNo, 0, payrollDetailIdNo)
        // Else
        // UpdatePayElement(employeeIdNo, amount, Deduction.IdNo, payrollDetailIdNo)
        // End If
        // ElseIf Deduction.CalculationType = _fixedRateType Then
        // Dim rate As Decimal = empDeduction.Rate
        // If rate <> 0 Then
        // Dim qty As Decimal
        // If Deduction.QuantityType = _overtimeRegularType OrElse
        // Deduction.QuantityType = _overtimeHolidayType OrElse
        // Deduction.QuantityType = _overTimeSpecialType OrElse
        // Deduction.QuantityType = _hoursWorkedType Then
        // qty = ComputeQuantity(empDeduction.EmployeeIdNo, Deduction.QuantityType)
        // Else
        // qty = ComputeQuantity(empDeduction.EmployeeIdNo, Deduction.QuantityType)
        // End If
        // amount = rate * qty
        // If Not regenerate Then
        // AddPayElement(employeeIdNo, amount, Deduction.IdNo, 0, payrollDetailIdNo)
        // Else
        // UpdatePayElement(employeeIdNo, amount, Deduction.IdNo, payrollDetailIdNo)
        // End If
        // End If
        // End If
        // Next
        // End Sub

        private void AddPayElement(int employeeIdNo, decimal amount, short payElementIdNo, short payrollPayElementIdNo, int payrollDetailIdNo, int recurringPayElementIdNo)
        {
            if (amount != 0m)
            {
                // If payElementIdNo = 32 Then
                // Debugger.Break()
                // End If
                var payrollPayElement = new PresentationLayer.Models.PayrollPayElementModel();
                payrollPayElement.Amount = Math.Round(amount, 0);
                payrollPayElement.Generated = true;
                payrollPayElement.PayrollIdNo = _payrollIdNo;
                payrollPayElement.PayElementIdNo = payElementIdNo;
                payrollPayElement.EmployeeIdNo = employeeIdNo;
                payrollPayElement.IdNo = payrollPayElementIdNo;
                payrollPayElement.PayrollDetailIdNo = payrollDetailIdNo;
                payrollPayElement.RecurringPayElementIdNo = recurringPayElementIdNo;
                _payrollPayElements.Add(payrollPayElement);
            }
        }

        private void UpdatePayElement(int employeeIdNo, decimal amount, short payElementIdNo, int payrollDetailIdNo, int recurringPayElementIdNo)
        {
            if (amount != 0m)
            {
                var payrollPayElement = _savedPayrollPayElements.Find((value) => value.EmployeeIdNo == employeeIdNo & value.PayElementIdNo == payElementIdNo);
                if (payrollPayElement is null)
                {
                    AddPayElement(employeeIdNo, amount, payElementIdNo, 0, payrollDetailIdNo, recurringPayElementIdNo);
                }
                else
                {
                    this.AddPayElement(employeeIdNo, amount, payElementIdNo, (short)payrollPayElement.IdNo, payrollPayElement.PayrollDetailIdNo, recurringPayElementIdNo);
                }
            }
        }

        // Private Sub AddToGeneratedPayroll(employeeIdNo As Int32, amount As Decimal, earningIdNo As Short, earning As PayrollPayElementModel)
        // Dim payrollPayElement As New PayrollPayElementModel
        // payrollPayElement.Amount = Math.Round(amount, 2)
        // payrollPayElement.PayrollIdNo = _payrollIdNo
        // payrollPayElement.PayElementIdNo = earningIdNo
        // payrollPayElement.EmployeeIdNo = employeeIdNo
        // If earning IsNot Nothing Then
        // payrollPayElement.IdNo = earning.IdNo
        // End If
        // _payrollPayElements.Add(payrollPayElement)
        // End Sub

        private void GenerateComputedPayElements(bool regenerate, int employeeIdNo, int payrollDetailIdNo)
        {
            foreach (PresentationLayer.Models.PayElementModel earning in _computedPayElements)
            {
                if (earning.Active)
                {
                    decimal amount;
                    amount = CalculateComputedPayElement(employeeIdNo, earning);
                    if (!regenerate)
                    {
                        this.AddPayElement(employeeIdNo, amount, earning.IdNo, (short)0, payrollDetailIdNo, default(int));
                    }
                    else
                    {
                        this.UpdatePayElement(employeeIdNo, amount, earning.IdNo, payrollDetailIdNo, default(int));
                    }
                }
            }
        }

        private void GenerateGlobalPayElements(bool regenerate, int employeeIdNo, int payrollDetailIdNo)
        {
            foreach (PresentationLayer.Models.PayElementModel earning in _globalEarnings)
            {
                if (earning.Active)
                {
                    if (!regenerate)
                    {
                        this.AddPayElement(employeeIdNo, earning.Rate, earning.IdNo, (short)0, payrollDetailIdNo, default(int));
                    }
                    else
                    {
                        this.UpdatePayElement(employeeIdNo, earning.Rate, earning.IdNo, payrollDetailIdNo, default(int));
                    }
                }
            }
        }

        private decimal CalculateComputedPayElement(int employeeIdNo, PresentationLayer.Models.PayElementModel earning)
        {
            var amount = default(decimal);
            decimal rate;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(earning.CalculationType, _fixedRateType, false)))
            {
                var payElementModel = _payrollPayElements.Find((p) => p.EmployeeIdNo == employeeIdNo & p.PayElementIdNo == earning.IdNo);
                if (payElementModel is object)
                {
                    rate = Accounts.ServiceLayer.ActionService.AccountsModule.ComputePayAmount(_payFrequency, payElementModel.Amount, Conversions.ToString(earning.Unit));
                    decimal qty = Conversions.ToDecimal(ComputeQuantity(employeeIdNo, Conversions.ToString(earning.Unit)));
                    amount = rate * qty;
                }
                else
                {
                    amount = 0m;
                }
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(earning.CalculationType, _factorType, false)))
            {
                var bpEarning = _payElementsService.GetRecordByIdNo<PayElementModel>((int)earning.BasePaymentIdNo);
                if (bpEarning.Summary)
                {
                    decimal bpAmount;
                    bpAmount = ComputeSummaryAmount(employeeIdNo, (short)earning.BasePaymentIdNo);
                    rate = Conversions.ToDecimal(this.ComputeFactoredAmount(bpAmount, earning.FactorValue, earning.FactorType));
                    var qty = ComputeQuantity(employeeIdNo, Conversions.ToString(earning.QuantityType));
                    amount = Conversions.ToDecimal(Operators.MultiplyObject(qty, rate));
                    if (amount > bpAmount)
                    {
                        amount = bpAmount;
                    }
                }
                else
                {
                    var bpPayElementModel = _payrollPayElements.Find((p) => p.EmployeeIdNo == employeeIdNo & p.PayElementIdNo == earning.BasePaymentIdNo == true);
                    if (bpPayElementModel is object)
                    {
                        var qty = ComputeQuantity(employeeIdNo, Conversions.ToString(earning.QuantityType));
                        var bpAmount = this.ComputeFactoredAmount(bpPayElementModel.Amount, earning.FactorValue, earning.FactorType);
                        amount = Conversions.ToDecimal(Operators.MultiplyObject(qty, bpAmount));
                        if (amount > bpPayElementModel.Amount)
                        {
                            amount = bpPayElementModel.Amount;
                        }
                    }
                }
            }

            return amount;
        }

        private object ComputeFactoredAmount(decimal amount, decimal factorValue, string factorType)
        {
            var factoredAmount = default(decimal);
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(factorType, _factorPercentType, false)))
            {
                factoredAmount = amount * factorValue * 0.01m;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(factorType, _factorMultiplyType, false)))
            {
                factoredAmount = amount * factorValue;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(factorType, _factorDivideType, false)))
            {
                if (factorValue != 0m)
                {
                    factoredAmount = amount / factorValue;
                }
            }

            return factoredAmount;
        }

        private decimal ComputeSummaryAmount(int employeeIdNo, short earningIdNo)
        {
            var summaryAmount = default(decimal);
            object argsortKey = null;
            var payElementItems = _payElementItemsService.GetRecordsWithGroupIdNo<PayElementItem>(earningIdNo, sortKey: ref argsortKey);
            foreach (Accounts.BusinessLayer.PayElementItem payElementItem in payElementItems)
            {
                var payElement = _payElementsService.GetRecordByIdNo<PayElementModel>((int)payElementItem.PayElementIdNo);
                decimal amount = 0m;
                if (!payElement.Summary)
                {
                    PresentationLayer.Models.PayrollPayElementModel empEarning;
                    empEarning = _payrollPayElements.Find((e) => e.EmployeeIdNo == employeeIdNo & e.PayElementIdNo == payElementItem.PayElementIdNo);
                    if (empEarning is object)
                    {
                        amount = empEarning.Amount;
                    }
                }
                else
                {
                    amount = this.ComputeSummaryAmount(employeeIdNo, payElementItem.PayElementIdNo);
                }

                summaryAmount = Conversions.ToDecimal(summaryAmount + this.ComputeSummaryItemAmount(amount, payElementItem.FactorValue, payElementItem.FactorType));
            }

            return summaryAmount;
        }

        private object ComputeSummaryItemAmount(decimal amount, decimal factorValue, string factorType)
        {
            var factoredAmount = default(decimal);
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(factorType, _factorPercentType, false)))
            {
                factoredAmount = amount * factorValue * 0.01m;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(factorType, _factorMultiplyType, false)))
            {
                factoredAmount = amount * factorValue;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(factorType, _factorDivideType, false)))
            {
                if (factorValue != 0m)
                {
                    factoredAmount = amount / factorValue;
                }
            }

            return factoredAmount;
        }

        private decimal ComputeDeductionAmount(Accounts.BusinessLayer.PayElement deduction, decimal daysAbsentWithoutPay, Accounts.BusinessLayer.EmployeePayElement basePayment)
        {
            Debugger.Break();
            decimal daysToCompute;
            var amount = default(decimal);
            if (_deductionComputationMethod == "DaysInMonth")
            {
                daysToCompute = daysAbsentWithoutPay;
                amount = Math.Round(basePayment.Amount / (decimal)_daysInTheMonth * daysToCompute, 2);
            }
            else if (_deductionComputationMethod == "30Days")
            {
                if (daysAbsentWithoutPay <= 15m)
                {
                    daysToCompute = daysAbsentWithoutPay;
                }
                else
                {
                    daysToCompute = 30m - (DateTime.DaysInMonth(DateAndTime.Year(_endDate), DateAndTime.Month(_endDate)) - daysAbsentWithoutPay);
                }

                amount = Math.Round(basePayment.Amount / 30m * daysToCompute, 2);
            }

            return amount;
        }

        private object CreatePayrollDetails()
        {
            var payrollDetail = new PresentationLayer.Models.PayrollDetailModel();
            var payrollDetailsModel = new List<PresentationLayer.Models.PayrollDetailModel>();
            var savedPayrollDetails = new List<Accounts.BusinessLayer.PayrollDetail>();
            var savedPayrollDetailsModel = new List<PresentationLayer.Models.PayrollDetailModel>();
            object argsortKey = null;
            savedPayrollDetails = _payrollDetailsService.GetRecordsWithGroupIdNo<PayrollDetail>(_payrollIdNo, sortKey: ref argsortKey);
            GlobalVariables.Mapper.Map(savedPayrollDetails, savedPayrollDetailsModel);
            savedPayrollDetails = null;
            if (savedPayrollDetailsModel.Count == 0)
            {
                foreach (var employeeAttendance in View.PayrollAttendance)
                {
                    payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo;
                    payrollDetail.PayrollIdNo = View.IdNo;
                    if ((payrollDetail.SponsorType ?? "") != (GlobalFunctions.EnumToCode(Accounts.SponsorTypeSelection.Others) ?? "") & (payrollDetail.SponsorType ?? "") != (GlobalFunctions.EnumToCode(Accounts.SponsorTypeSelection.Sponsor) ?? "") & (payrollDetail.PaymentMethod ?? "") == (GlobalFunctions.EnumToCode(Accounts.PayrollPaymentMethodSelection.BankTransfer) ?? ""))
                    {
                        payrollDetail.BankTransfer = true;
                    }
                    else
                    {
                        payrollDetail.BankTransfer = false;
                    }

                    payrollDetailsModel.Add(payrollDetail);
                }
            }
            else
            {
                foreach (var employeeAttendance in View.PayrollAttendance)
                {
                    payrollDetail = savedPayrollDetailsModel.Find((pd) => pd.EmployeeIdNo == employeeAttendance.EmployeeIdNo);
                    if (payrollDetail is null)
                    {
                        payrollDetail = new PresentationLayer.Models.PayrollDetailModel();
                        payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo;
                        payrollDetail.PayrollIdNo = View.IdNo;
                    }

                    if ((payrollDetail.SponsorType ?? "") != (GlobalFunctions.EnumToCode(Accounts.SponsorTypeSelection.Others) ?? "") & (payrollDetail.SponsorType ?? "") != (GlobalFunctions.EnumToCode(Accounts.SponsorTypeSelection.Sponsor) ?? "") & (payrollDetail.PaymentMethod ?? "") == (GlobalFunctions.EnumToCode(Accounts.PayrollPaymentMethodSelection.BankTransfer) ?? ""))
                    {
                        payrollDetail.BankTransfer = true;
                    }
                    else
                    {
                        payrollDetail.BankTransfer = false;
                    }

                    payrollDetailsModel.Add(payrollDetail);
                }
            }

            foreach (var employeeAttendance in View.PayrollOvertime)
            {
                payrollDetail = payrollDetailsModel.Find((pd) => pd.EmployeeIdNo == employeeAttendance.EmployeeIdNo);
                if (payrollDetail is null)
                {
                    payrollDetail = savedPayrollDetailsModel.Find((pd) => pd.EmployeeIdNo == employeeAttendance.EmployeeIdNo);
                    if (payrollDetail is null)
                    {
                        payrollDetail = new PresentationLayer.Models.PayrollDetailModel();
                        payrollDetail.EmployeeIdNo = employeeAttendance.EmployeeIdNo;
                        payrollDetail.PayrollIdNo = View.IdNo;
                        payrollDetailsModel.Add(payrollDetail);
                    }
                }
            }

            return payrollDetailsModel;
        }

        // Private Function ComputePayAMount(payFrequency As PayFrequencySelection, amount As Decimal, unit As String) As Decimal
        // Dim factor As Decimal
        // Select Case payFrequency
        // Case PayFrequencySelection.Monthly
        // If unit = _monthType Then
        // factor = 1D
        // ElseIf unit = _semiMonthType Then
        // factor = 2D
        // ElseIf unit = _yearType Then
        // factor = 1D / 12D
        // ElseIf unit = _semiYearType Then
        // factor = 1D / 6D
        // ElseIf unit = _quarterType Then
        // factor = 1D / 3D
        // ElseIf unit = _weekType Then
        // factor = 13D / 2D
        // ElseIf unit = _dayType Then
        // factor = 30D
        // ElseIf unit = _biWeekType Then
        // factor = 13D / 6D
        // End If
        // Case PayFrequencySelection.Yearly
        // If unit = _monthType Then
        // factor = 12D
        // ElseIf unit = _semiMonthType Then
        // factor = 24D
        // ElseIf unit = _yearType Then
        // factor = 1D
        // ElseIf unit = _semiYearType Then
        // factor = 2D
        // ElseIf unit = _quarterType Then
        // factor = 4D
        // ElseIf unit = _weekType Then
        // factor = 52D
        // ElseIf unit = _dayType Then
        // factor = 365D
        // ElseIf unit = _biWeekType Then
        // factor = 26D
        // End If
        // Case PayFrequencySelection.SemiYearly
        // If unit = _monthType Then
        // factor = 6D
        // ElseIf unit = _semiMonthType Then
        // factor = 12D
        // ElseIf unit = _yearType Then
        // factor = 1D / 2D
        // ElseIf unit = _semiYearType Then
        // factor = 1D
        // ElseIf unit = _quarterType Then
        // factor = 2D
        // ElseIf unit = _weekType Then
        // factor = 26D
        // ElseIf unit = _dayType Then
        // factor = 365D / 2D
        // ElseIf unit = _biWeekType Then
        // factor = 13D
        // End If
        // Case PayFrequencySelection.Quarterly
        // If unit = _monthType Then
        // factor = 3D
        // ElseIf unit = _semiMonthType Then
        // factor = 6D
        // ElseIf unit = _yearType Then
        // factor = 1D / 4D
        // ElseIf unit = _semiYearType Then
        // factor = 1D / 2D
        // ElseIf unit = _quarterType Then
        // factor = 1D
        // ElseIf unit = _weekType Then
        // factor = 13D
        // ElseIf unit = _dayType Then
        // factor = 365D / 4D
        // ElseIf unit = _biWeekType Then
        // factor = 13D / 2D
        // End If
        // Case PayFrequencySelection.SemiMonthly
        // If unit = _monthType Then
        // factor = 1D / 2D
        // ElseIf unit = _semiMonthType Then
        // factor = 1D
        // ElseIf unit = _yearType Then
        // factor = 1D / 24D
        // ElseIf unit = _semiYearType Then
        // factor = 1D / 12D
        // ElseIf unit = _quarterType Then
        // factor = 1D / 6D
        // ElseIf unit = _weekType Then
        // factor = 13D / 4D
        // ElseIf unit = _dayType Then
        // factor = 15D
        // ElseIf unit = _biWeekType Then
        // factor = 13D / 12D
        // End If
        // Case PayFrequencySelection.Weekly
        // If unit = _monthType Then
        // factor = 12D / 52D
        // ElseIf unit = _semiMonthType Then
        // factor = 24D / 52D
        // ElseIf unit = _yearType Then
        // factor = 1D / 52D
        // ElseIf unit = _semiYearType Then
        // factor = 1D / 26D
        // ElseIf unit = _quarterType Then
        // factor = 1D / 13D
        // ElseIf unit = _weekType Then
        // factor = 1D
        // ElseIf unit = _dayType Then
        // factor = 7D
        // ElseIf unit = _biWeekType Then
        // factor = 1D / 2D
        // End If
        // Case PayFrequencySelection.Daily
        // If unit = _monthType Then
        // factor = 1D / 30D
        // ElseIf unit = _semiMonthType Then
        // factor = 1D / 15D
        // ElseIf unit = _yearType Then
        // factor = 1D / 360D
        // ElseIf unit = _semiYearType Then
        // factor = 1D / 180D
        // ElseIf unit = _quarterType Then
        // factor = 1D / 90D
        // ElseIf unit = _weekType Then
        // factor = 1D / 7D
        // ElseIf unit = _dayType Then
        // factor = 1D
        // ElseIf unit = _biWeekType Then
        // factor = 1D / 14D
        // End If

        // End Select
        // Return amount * factor
        // End Function

        private object ComputeQuantity(int employeeIdNo, string quantityType)
        {
            decimal? quantity;
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _hoursWorkedType, false)))
            {
                quantity = GetOtWorkHourValues(employeeIdNo, "HoursWorked");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _daysLeaveWithPayType, false)))
            {
                quantity = GetAttendanceValues(employeeIdNo, "DaysAbsentWithPay");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _daysOffType, false)))
            {
                quantity = GetAttendanceValues(employeeIdNo, "DaysOff");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _daysPresentType, false)))
            {
                quantity = GetAttendanceValues(employeeIdNo, "DaysPresent");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _daysLeaveWithoutPayType, false)))
            {
                quantity = GetAttendanceValues(employeeIdNo, "DaysAbsentWithoutPay");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _daysVacationType, false)))
            {
                quantity = GetAttendanceValues(employeeIdNo, "DaysVacationLeave");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _daysPaidType, false)))
            {
                var attendanceItem = _attendanceItemService.GetRecordByIdNo<AttendanceItemModel>(employeeIdNo);
                quantity = attendanceItem.DaysPresent + attendanceItem.DaysAbsentWithPay + attendanceItem.DaysOff + attendanceItem.DaysVacationLeave;
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _overtimeRegularType, false)))
            {
                quantity = GetOtWorkHourValues(employeeIdNo, "OvertimeRegular");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _overtimeHolidayType, false)))
            {
                quantity = GetOtWorkHourValues(employeeIdNo, "OvertimeHoliday");
            }
            else if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(quantityType, _overTimeSpecialType, false)))
            {
                quantity = GetOtWorkHourValues(employeeIdNo, "OvertimeSpecial");
            }
            else
            {
                quantity = 1;
            }

            return Interaction.IIf(quantity is null, 0, quantity);
        }

        private decimal GetAttendanceValues(int employeeIdNo, string fieldName)
        {
            return Conversions.ToDecimal(Service.GetFieldValue<decimal>(fieldName, "AttendanceItem", "EmployeeIdNo = " + employeeIdNo.ToString() + " and PayrollIdNo = " + _payrollIdNo));
        }

        private decimal GetOtWorkHourValues(int employeeIdNo, string fieldName)
        {
            // after getting qty need to zero out the value so that no double use of otHoursComputation
            // because there might be multiple otcomputations. Regular OtWorkHours take precedence
            // over computed otworkhours
            decimal qty = 0m;
            var otWorkHourModel = _otWorkHoursModel.Find(x => x.EmployeeIdNo == employeeIdNo);
            if (otWorkHourModel is object)
            {
                switch (fieldName ?? "")
                {
                    case "HoursWorked":
                        {
                            qty = otWorkHourModel.HoursWorked;
                            otWorkHourModel.HoursWorked = 0m;
                            break;
                        }

                    case "OvertimeRegular":
                        {
                            qty = otWorkHourModel.OvertimeRegular;
                            otWorkHourModel.OvertimeRegular = 0m;
                            break;
                        }

                    case "OvertimeHoliday":
                        {
                            qty = otWorkHourModel.OvertimeHoliday;
                            otWorkHourModel.OvertimeHoliday = 0m;
                            break;
                        }

                    case "OvertimeSpecial":
                        {
                            qty = otWorkHourModel.OvertimeSpecial;
                            otWorkHourModel.OvertimeSpecial = 0m;
                            break;
                        }
                }
            }

            return qty;
        }

        // Private Sub MakePayrollOt(payrollIdNo As Short, otHours As Decimal, otUnit As String, otRate As Decimal, otEarning As Earning, employeeIdNo As Integer)
        // Dim otAmount As Decimal = ComputeOtAmount(otEarning, otHours, otRate)
        // AddEarning(employeeIdNo, otAmount, payrollIdNo, otEarning.IdNo)
        // End Sub

        // Private Shared Function ComputeOtAmount(otEarning As PayElement, otHours As Decimal, otRate As Decimal) As Decimal
        // Dim otAmount As Decimal
        // If otEarning IsNot Nothing Then
        // otAmount = otHours * IIf(IsDBNull(otRate), 0, otRate)
        // Else
        // otAmount = otHours * IIf(IsDBNull(otEarning.Rate), 0, otEarning.Rate)
        // End If
        // Return otAmount
        // End Function

    }
}