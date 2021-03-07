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
    <EnumCode("G")> [Global]
    <EnumCode("T")> Table
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
    <EnumCode("BN")> Bank
    <EnumCode("BR")> Branch
    <EnumCode("PY")> PaymentType
    <EnumCode("CH")> Account
    <EnumCode("CT")> Country
    <EnumCode("CU")> Customer
    <EnumCode("DP")> Department
    <EnumCode("DG")> Designation
    <EnumCode("DS")> DistributionScheme
    <EnumCode("DC")> Document
    <EnumCode("EM")> Employee
    <EnumCode("FB")> Earning
    <EnumCode("PT")> Patient
    <EnumCode("PH")> Phone
    <EnumCode("PC")> ProductCategory
    <EnumCode("RC")> RevCostCenter
    <EnumCode("SG")> SecurityGroup
    <EnumCode("SO")> SecurityObject
    <EnumCode("SP")> Supplier
    <EnumCode("US")> User
End Enum

Public Enum DebitCreditSelection
    <EnumCode("")> NotSpecified
    <EnumCode("D")> Debit
    <EnumCode("C")> Credit
End Enum

Public Enum DocumentTypeSelection
    NotSpecified
    Employee
    Establishment
    Supplier
    Client
    Patient
    Others
End Enum

Public Enum DeductionTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("R")> Regular
    <EnumCode("A")> AbsencesDeduction
    <EnumCode("N")> AsNeeded
    <EnumCode("G")> Garnishments
    <EnumCode("V")> Voluntary
    <EnumCode("F")> Fines
    <EnumCode("S")> SalaryLoans
    <EnumCode("O")> Others
    <EnumCode("P")> Pension
    '<EnumCode("T")> IncomeTax
End Enum

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

Public Enum EarningTypeSelection
    <EnumCode("R")> Regular
    <EnumCode("O")> Overtime
    <EnumCode("S")> SickPay
    <EnumCode("V")> VacationPay
    <EnumCode("H")> HolidayPay
    <EnumCode("B")> Bonus
    <EnumCode("C")> Commission
    <EnumCode("E")> Expenses
    <EnumCode("D")> Redundancy
    <EnumCode("M")> Miscellaneous
    <EnumCode("A")> AsNeeded
    <EnumCode("Y")> Summary
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

Public Enum MultiplierTypeSelection
    <EnumCode("X")> TimesBasePaymentRate
    <EnumCode("P")> PercentOfBasePaymentRate
End Enum

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
    <EnumCode("U")> Unit
    <EnumCode("A")> AbsencesWithoutPay
    <EnumCode("O")> OvertimeHoursRegular
    <EnumCode("T")> OvertimeHoursSpecial
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

Public Enum QuantityTypeSelection
    <EnumCode("F")> Fixed
    <EnumCode("V")> Variable
    <EnumCode("A")> AbsencesWithoutPay
    <EnumCode("D")> DaysPresent
    <EnumCode("O")> OvertimeRegular
    <EnumCode("H")> OvertimeHoliday
    <EnumCode("S")> OvertimeSpecial
    <EnumCode("L")> LeavesWithPay
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
    <EnumCode("VI")> VatInput
    <EnumCode("VO")> VatOutput
End Enum

Public Enum TransactionTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("I")> Invoice
    <EnumCode("D")> Debit
    <EnumCode("C")> Credit
End Enum