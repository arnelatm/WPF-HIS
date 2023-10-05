Imports AATM.Libraries.GlobalFuncNSub

Public Enum AccountGroupSelection
    <EnumCode(" ")> None
    <EnumCode("A")> Asset
    <EnumCode("L")> Liability
    <EnumCode("E")> Equity
    <EnumCode("S")> RevExpSummary
    <EnumCode("R")> Revenue
    <EnumCode("X")> Expense
End Enum

Public Enum AccountStatusSelection
    <EnumCode("O")> Open
    <EnumCode("E")> ExceededCreditLimit
    <EnumCode("H")> OnHold
    <EnumCode("C")> CashOnly
    <EnumCode("P")> Prospect
    <EnumCode("N")> NewAccount
    <EnumCode("S")> SeeNote
End Enum

Public Enum CalculationTypeSelection

    <EnumCode("A")> FixedAmount
    <EnumCode("F")> Factor
    <EnumCode("R")> FixedRate
    <EnumCode("V")> Variable
    <EnumCode("T")> Table
    '<EnumCode("G")> [Global]
    '<EnumCode("A")> FixedAmount
End Enum

'Public Enum PayRateTypeSelection
'    <EnumCode("H")> Hour
'    <EnumCode("D")> Day
'    <EnumCode("W")> Week
'    <EnumCode("B")> BiWeekly
'    <EnumCode("M")> Month
'    <EnumCode("Q")> Quarterly
'    <EnumCode("R")> SemiMonthly
'    <EnumCode("Y")> Yearly
'    <EnumCode("F")> FixedAmount
'End Enum

Public Enum DatabaseTableSelection
    <EnumCode("ACC")> Account
    <EnumCode("BNK")> Bank
    <EnumCode("BRN")> Branch
    <EnumCode("CNT")> Country
    <EnumCode("CUS")> Customer
    <EnumCode("DEP")> Department
    <EnumCode("DIS")> DistributionScheme
    <EnumCode("DOC")> Document
    <EnumCode("DSG")> Designation
    <EnumCode("EMP")> Employee
    <EnumCode("ERN")> Earning
    <EnumCode("PAT")> Patient
    <EnumCode("PHN")> Phone
    <EnumCode("PRC")> ProductCategory
    <EnumCode("PYT")> PaymentType
    <EnumCode("RVC")> RevCostCenter
    <EnumCode("SCG")> SecurityGroup
    <EnumCode("SCO")> SecurityObject
    <EnumCode("SUP")> Supplier
    <EnumCode("USR")> User
    <EnumCode("WRH")> Warehouse
End Enum

Public Enum ApplicationSettingCodeSelection
    <EnumCode("BWSL")> BranchWithSales
    <EnumCode("USDW")> UserDefaultWarehouse
End Enum


Public Enum DebitCreditSelection
    <EnumCode("")> NotSpecified
    <EnumCode("D")> Debit
    <EnumCode("C")> Credit
End Enum

Public Enum DocumentTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("E")> Employee
    <EnumCode("T")> Establishment
    <EnumCode("S")> Supplier
    <EnumCode("C")> Customer
    <EnumCode("P")> Patient
    <EnumCode("O")> Others
End Enum

Public Enum ImageTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("J")> JPG
    <EnumCode("P")> PDF
End Enum

'Public Enum DeductionTypeSelection
'    <EnumCode("R")> Regular
'    <EnumCode("C")> Computed
'    <EnumCode("D")> OnDemand
'    <EnumCode("G")> [Global]
'    '<EnumCode("N")> AsNeeded
'    '<EnumCode("G")> Garnishments
'    '<EnumCode("V")> Voluntary
'    '<EnumCode("F")> Fines
'    '<EnumCode("S")> SalaryLoans
'    '<EnumCode("O")> Others
'    '<EnumCode("P")> Pension
'    '<EnumCode("T")> IncomeTax
'End Enum

'Public Enum DeductOnSelection
'    <EnumCode("")> NotSpecified
'    <EnumCode("B")> BaseEarning
'    <EnumCode("G")> GrossEarning
'    <EnumCode("N")> NetPay
'    '<EnumCode("B")> BeforeTax
'    '<EnumCode("A")> AfterTax
'End Enum

Public Enum DeductionComputation
    <EnumCode("")> NotSpecified
    <EnumCode("F")> FixedAmount
    <EnumCode("P")> FixedPercentage
    <EnumCode("T")> TabledBased
End Enum

Public Enum PayTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("1")> CheckPayment
    <EnumCode("2")> BankTransfer
    <EnumCode("3")> Others
End Enum

'Public Enum EarningTypeSelection
'    <EnumCode("R")> Regular
'    <EnumCode("C")> Computed
'    <EnumCode("D")> OnDemand
'    <EnumCode("G")> [Global]
'    '<EnumCode("O")> OvertimeRegular
'    '<EnumCode("V")> OvertimeHoliday
'    '<EnumCode("T")> OvertimeSpecial
'    '<EnumCode("S")> SickPay
'    '<EnumCode("V")> VacationPay
'    '<EnumCode("H")> HolidayPay
'    '<EnumCode("B")> Bonus
'    '<EnumCode("C")> Commission
'    '<EnumCode("E")> Expenses
'    '<EnumCode("D")> Redundancy
'    '<EnumCode("M")> Miscellaneous
'    '<EnumCode("A")> AsNeeded
'    '<EnumCode("Y")> Summary
'End Enum

Public Enum PayElementKindSelection
    <EnumCode("E")> Earning
    <EnumCode("D")> Deduction
    '<EnumCode("O")> OvertimeRegular
    '<EnumCode("V")> OvertimeHoliday
    '<EnumCode("T")> OvertimeSpecial
    '<EnumCode("S")> SickPay
    '<EnumCode("V")> VacationPay
    '<EnumCode("H")> HolidayPay
    '<EnumCode("B")> Bonus
    '<EnumCode("C")> Commission
    '<EnumCode("E")> Expenses
    '<EnumCode("D")> Redundancy
    '<EnumCode("M")> Miscellaneous
    '<EnumCode("A")> AsNeeded
    '<EnumCode("Y")> Summary
End Enum

Public Enum PayElementTypeSelection
    <EnumCode("R")> Regular
    <EnumCode("C")> Computed
    <EnumCode("O")> OnDemand
    <EnumCode("G")> [Global]
    '<EnumCode("O")> OvertimeRegular
    '<EnumCode("V")> OvertimeHoliday
    '<EnumCode("T")> OvertimeSpecial
    '<EnumCode("S")> SickPay
    '<EnumCode("V")> VacationPay
    '<EnumCode("H")> HolidayPay
    '<EnumCode("B")> Bonus
    '<EnumCode("C")> Commission
    '<EnumCode("E")> Expenses
    '<EnumCode("D")> Redundancy
    '<EnumCode("M")> Miscellaneous
    '<EnumCode("A")> AsNeeded
    '<EnumCode("Y")> Summary
End Enum

Public Enum EmployeeActionSelection
    <EnumCode("HR")> Hire
    <EnumCode("PR")> Promote
    <EnumCode("DE")> Demote
    <EnumCode("RH")> Rehire
    <EnumCode("SC")> SalaryChange
    <EnumCode("AR")> AwardRecognition
    <EnumCode("SU")> Suspend
    <EnumCode("WR")> Warning
    <EnumCode("TE")> Terminate
    <EnumCode("RS")> Resign
End Enum

Public Enum FactorTypeSelection
    <EnumCode("M")> MultiplyBasePaymentRate
    <EnumCode("P")> PercentOfBasePaymentRate
    <EnumCode("D")> DivideBasePaymentRate
    <EnumCode("H")> MultiplyComplementOfDutyRatio
End Enum

'Public Enum FactorTypeSelection
'    MultiplyBasePaymentRate
'    PercentOfBasePaymentRate
'    DivideBasePaymentRate
'End Enum

Public Enum PayeeTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("E")> Employee
    <EnumCode("C")> Customer
    <EnumCode("S")> Supplier
    <EnumCode("O")> Others
End Enum

Public Enum PaymentMethodSelection
    <EnumCode("NO")> NotSpecified
    <EnumCode("CS")> Cash
    <EnumCode("CK")> Check
    <EnumCode("CC")> CreditCard
    <EnumCode("BT")> BankTransfer
    <EnumCode("DC")> DebitCard
    <EnumCode("MT")> MobileTransfer
    <EnumCode("WT")> WireTransfer
    <EnumCode("PP")> Paypal
    <EnumCode("BC")> BitCoin
    <EnumCode("MX")> Mixed
    <EnumCode("OT")> Others
End Enum

Public Enum PaymentTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("A")> AccountsPayable
    <EnumCode("E")> Employee
    <EnumCode("R")> CustomerRefund
    <EnumCode("S")> Supplier
    <EnumCode("O")> Others
End Enum

'Public Enum PaySalariedOrHourlySelection
'    <EnumCode("")> NotSpecified
'    <EnumCode("S")> Salaried
'    <EnumCode("H")> Hourly
'End Enum

Public Enum PayFrequencySelection
    <EnumCode("")> NotSpecified
    <EnumCode("M")> Monthly
    <EnumCode("W")> Weekly
    <EnumCode("B")> BiWeekly
    <EnumCode("S")> SemiMonthly
    <EnumCode("Q")> Quarterly
    <EnumCode("I")> BiYearly
    <EnumCode("Y")> Yearly
    <EnumCode("R")> SemiYearly
    <EnumCode("D")> Daily
    <EnumCode("A")> AsNeeded
End Enum

Public Enum PayRateUnitSelection
    <EnumCode("H")> Hour
    <EnumCode("D")> Day
    <EnumCode("W")> Week
    <EnumCode("B")> BiWeek
    <EnumCode("S")> SemiMonth
    <EnumCode("M")> Month
    <EnumCode("Q")> Quarter
    <EnumCode("R")> SemiYear
    <EnumCode("Y")> Year
End Enum

Public Enum PayrollPaymentMethodSelection
    <EnumCode("B")> BankTransfer
    <EnumCode("C")> Cash
    <EnumCode("K")> Check
End Enum

Public Enum ReceiptTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("A")> AccountsReceivable
    <EnumCode("E")> Employee
    <EnumCode("R")> SupplierRefund
    <EnumCode("C")> Customer
    <EnumCode("O")> Others
End Enum

'Public Enum QuantityTypeSelection
'    <EnumCode("F")> Fixed
'    <EnumCode("V")> Variable
'    <EnumCode("A")> AbsencesWithoutPay
'    <EnumCode("D")> DaysPresent
'    <EnumCode("O")> OvertimeRegular
'    <EnumCode("H")> OvertimeHoliday
'    <EnumCode("S")> OvertimeSpecial
'    <EnumCode("L")> LeavesWithPay
'End Enum

Public Enum AttendanceUnitSelection
    <EnumCode("P")> PresentAttendance
    <EnumCode("L")> PaidLeaveAbsences
    <EnumCode("U")> UnpaidLeaveAbsences
    <EnumCode("F")> PaidOff
    <EnumCode("T")> PaidTotal
    <EnumCode("O")> OvertimeRegular
    <EnumCode("H")> OvertimeHoliday
    <EnumCode("S")> OvertimeSpecial
End Enum

Public Enum QuantityTypeSelection
    <EnumCode("W")> DaysLeaveWithoutPay
    <EnumCode("F")> DaysOff
    <EnumCode("D")> DaysPaid
    <EnumCode("P")> DaysPresent
    <EnumCode("L")> DaysLeaveWithPay
    <EnumCode("N")> NotNeeded
    <EnumCode("H")> HoursWorked
    <EnumCode("O")> OvertimeRegular
    <EnumCode("T")> OvertimeHoliday
    <EnumCode("S")> OvertimeSpecial
    <EnumCode("V")> Variable
    <EnumCode("X")> DaysVacationLeave
End Enum

Public Enum SpecialAccountSelection
    <EnumCode("")> None
    <EnumCode("AP")> AccountsPayable
    <EnumCode("PD")> AccountsPayableDiscount
    <EnumCode("AR")> AccountsReceivable
    <EnumCode("AS")> AdvancesToSupplier
    <EnumCode("BA")> Bank
    <EnumCode("BI")> BeginningInventory
    <EnumCode("CA")> CustomerAdvances
    <EnumCode("CE")> CurrentEarning
    <EnumCode("CS")> Cash
    <EnumCode("CK")> CheckingAccount
    <EnumCode("EL")> EmployeeLoan
    <EnumCode("EI")> EndingInventory
    <EnumCode("SL")> Sales
    <EnumCode("RD")> AccountsReceivableDiscount
    <EnumCode("PC")> PettyCashAccount
    <EnumCode("PD")> PurchaseDiscount
    <EnumCode("VI")> VatInput
    <EnumCode("VO")> VatOutput
End Enum

Public Enum TransactionTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("I")> Invoice
    <EnumCode("D")> Debit
    <EnumCode("C")> Credit
End Enum

Public Enum LeaveStatusSelection
    <EnumCode("")> NotSpecified
    <EnumCode("0")> Submitted
    <EnumCode("1")> Cancelled
    <EnumCode("2")> SupervisorApproved
    <EnumCode("3")> Disapproved
    <EnumCode("4")> Approved
    <EnumCode("5")> Used
End Enum

Public Enum SupervisorApprovalSelection
    <EnumCode("2")> SupervisorApproved
    <EnumCode("3")> Disapproved
End Enum

Public Enum LeaveApprovalSelection
    <EnumCode("3")> Disapproved
    <EnumCode("4")> Approved
End Enum

Public Enum SponsorTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("1")> Sponsored
    <EnumCode("2")> Citizen
    <EnumCode("3")> Sponsor
    <EnumCode("4")> Others
End Enum

Public Enum InventoryActionSelection
    <EnumCode("")> NotSpecified
    <EnumCode("A")> Add
    <EnumCode("D")> Deduct
    <EnumCode("T")> Transfer
    <EnumCode("R")> Request
End Enum
Public Enum AbsenceTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("1")> Absent
    <EnumCode("2")> Late
End Enum

Public Enum LeaveCycleSelection
    <EnumCode("")> NotSpecified
    <EnumCode("1")> ResetsYearly
    <EnumCode("2")> OnceOnly
    <EnumCode("3")> AsNeeded
End Enum

Public Enum RecurTypeSelection

    <EnumCode("A")> WhileActive
    <EnumCode("L")> UpToLimitAmount
    <EnumCode("D")> UpToEndDate

End Enum

Public Enum SearchModeEnum
    [TextBox]
    [Date]
    [ComboBox]
    [CheckBox]
End Enum

Public Enum SearchPlaceEnum
    [StartOfField]
    [AnywhereOnField]
    [ExactValue]
End Enum

Public Enum DataTypeEnum
    [String]
    [Date]
    [DateTime]
    [Integer]
    [Decimal]
    [Boolean]
End Enum

Public Enum AppSettingGroupSelector
    UserDefaultWarehouse = 1
    SecurityGroupDefaultBranch = 2
    SecurityGroupDefaultInventoryWarehouse = 3
    UserManagedWarehouse = 4
End Enum

