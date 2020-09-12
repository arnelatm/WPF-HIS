Imports System.ComponentModel
Imports System.Runtime.CompilerServices
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

Public Enum DatabaseTableSelection
    <EnumCode("BN")> Bank
    <EnumCode("BR")> Branch
    <EnumCode("CC")> CashCode
    <EnumCode("CH")> Chart
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
    <EnumCode("H")> Hourly
    <EnumCode("P")> Periodic
    <EnumCode("O")> Others
End Enum

Public Enum EarningTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("R")> Regular
    <EnumCode("H")> Hourly
    <EnumCode("P")> Periodic
    <EnumCode("O")> Others
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

Public Enum PaySalariedOrHourlySelection
    <EnumCode("")> NotSpecified
    <EnumCode("S")> Salaried
    <EnumCode("H")> Hourly
End Enum

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

Public Enum PayRateTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("M")> Monthly
    <EnumCode("H")> Hourly
    <EnumCode("D")> Daily
    <EnumCode("W")> Weekly
End Enum

Public Enum ReceiptTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("A")> AccountsReceivable
    <EnumCode("E")> Employee
    <EnumCode("R")> SupplierRefund
    <EnumCode("C")> Customer
    <EnumCode("O")> Others
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