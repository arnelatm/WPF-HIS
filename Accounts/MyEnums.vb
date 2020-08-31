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


Public Enum PaymentTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("A")> AccountsPayable
    <EnumCode("E")> Employee
    <EnumCode("R")> CustomerRefund
    <EnumCode("S")> Supplier
    <EnumCode("O")> Others
End Enum


Public Enum ReceiptTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("A")> AccountsReceivable
    <EnumCode("E")> Employee
    <EnumCode("R")> SupplierRefund
    <EnumCode("C")> Customer
    <EnumCode("O")> Others
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


Public Enum ImageTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("J")> Jpg
    <EnumCode("P")> Pdf
    <EnumCode("B")> Bmp
End Enum


Public Enum MaleFemaleSelection
    <EnumCode("")> NotSpecified
    <EnumCode("M")> Male
    <EnumCode("F")> Female
End Enum


Public Enum MaritalStatusSelection
    <EnumCode("")> NotSpecified
    <EnumCode("S")> [Single]
    <EnumCode("M")> Married
    <EnumCode("W")> Widowed
    <EnumCode("D")> Divorced
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


Public Enum YearMonthDaySelection
    <EnumCode("")> NotSpecified
    <EnumCode("Y")> Year
    <EnumCode("M")> Month
    <EnumCode("D")> Day
End Enum


Public Enum YesNoSelection
    <EnumCode("N")> No = False
    <EnumCode("Y")> Yes = True
End Enum

Public Module Adapter

    Public Function AccountGroupToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = AccountGroupSelection.None
            Case "A"
                retValue = AccountGroupSelection.Asset
            Case "L"
                retValue = AccountGroupSelection.Liability
            Case "E"
                retValue = AccountGroupSelection.Equity
            Case "S"
                retValue = AccountGroupSelection.RevExpSummary
            Case "R"
                retValue = AccountGroupSelection.Revenue
            Case "X"
                retValue = AccountGroupSelection.Expense
            Case Else
                retValue = AccountGroupSelection.None
        End Select
        Return retValue
    End Function

    Public Function AccountStatusToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = AccountStatusSelection.Open
            Case "O"
                retValue = AccountStatusSelection.Open
            Case "E"
                retValue = AccountStatusSelection.ExceededCreditLimit
            Case "H"
                retValue = AccountStatusSelection.OnHold
            Case "C"
                retValue = AccountStatusSelection.CashOnly
            Case "P"
                retValue = AccountStatusSelection.Prospect
            Case "N"
                retValue = AccountStatusSelection.NewAccount
            Case "S"
                retValue = AccountStatusSelection.SeeNote
            Case Else
                retValue = AccountStatusSelection.Open
        End Select
        Return retValue
    End Function

    Public Function DebitCreditToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = DebitCreditSelection.NotSpecified
            Case "D"
                retValue = DebitCreditSelection.Debit
            Case "C"
                retValue = DebitCreditSelection.Credit
            Case Else
                retValue = DebitCreditSelection.NotSpecified
        End Select
        Return retValue
    End Function

    Public Function DocumentTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = ImageTypeSelection.NotSpecified
            Case "J"
                retValue = ImageTypeSelection.Jpg
            Case "P"
                retValue = ImageTypeSelection.Pdf
            Case "B"
                retValue = ImageTypeSelection.Bmp
            Case Else
                retValue = ImageTypeSelection.NotSpecified
        End Select
        Return retValue
    End Function

    Public Function EnumToAccountGroup(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = " "
            Case AccountGroupSelection.None
                retValue = " "
            Case AccountGroupSelection.Asset
                retValue = "A"
            Case AccountGroupSelection.Liability
                retValue = "L"
            Case AccountGroupSelection.Equity
                retValue = "E"
            Case AccountGroupSelection.RevExpSummary
                retValue = "S"
            Case AccountGroupSelection.Revenue
                retValue = "R"
            Case AccountGroupSelection.Expense
                retValue = "X"
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function EnumToAccountStatus(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = "O"
            Case AccountStatusSelection.Open
                retValue = "O"
            Case AccountStatusSelection.ExceededCreditLimit
                retValue = "E"
            Case AccountStatusSelection.OnHold
                retValue = "H"
            Case AccountStatusSelection.CashOnly
                retValue = "C"
            Case AccountStatusSelection.Prospect
                retValue = "P"
            Case AccountStatusSelection.NewAccount
                retValue = "N"
            Case AccountStatusSelection.SeeNote
                retValue = "S"
            Case Else
                retValue = "O"
        End Select
        Return retValue
    End Function

    Public Function EnumToDebitCredit(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case DebitCreditSelection.Debit
                retValue = "D"
            Case DebitCreditSelection.Credit
                retValue = "C"
            Case DebitCreditSelection.NotSpecified
                retValue = Nothing
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function EnumToDocumentType(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case DocumentTypeSelection.NotSpecified
                retValue = Nothing
            Case DocumentTypeSelection.Employee
                retValue = "E"
            Case DocumentTypeSelection.Client
                retValue = "C"
            Case DocumentTypeSelection.Supplier
                retValue = "S"
            Case DocumentTypeSelection.Patient
                retValue = "P"
            Case DocumentTypeSelection.Establishment
                retValue = "T"
            Case DocumentTypeSelection.Others
                retValue = "O"
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function EnumToImageType(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case ImageTypeSelection.NotSpecified
                retValue = Nothing
            Case ImageTypeSelection.Jpg
                retValue = "J"
            Case ImageTypeSelection.Pdf
                retValue = "P"
            Case ImageTypeSelection.Bmp
                retValue = "B"
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function EnumToMaleFemale(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case MaleFemaleSelection.NotSpecified
                retValue = Nothing
            Case MaleFemaleSelection.Male
                retValue = "M"
            Case MaleFemaleSelection.Female
                retValue = "F"
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function EnumToMaritalStatus(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case MaritalStatusSelection.NotSpecified
                retValue = Nothing
            Case MaritalStatusSelection.Single
                retValue = "S"
            Case MaritalStatusSelection.Married
                retValue = "M"
            Case MaritalStatusSelection.Widowed
                retValue = "W"
            Case MaritalStatusSelection.Divorced
                retValue = "D"
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    'Public Function EnumToPayeeType(value As String) As String
    '    Dim retValue As String
    '    Select Case value
    '        Case Nothing
    '            retValue = Nothing
    '        Case PayeeTypeSelection.None
    '            retValue = Nothing
    '        Case PayeeTypeSelection.Employee
    '            retValue = "E"
    '        Case PayeeTypeSelection.Customer
    '            retValue = "C"
    '        Case PayeeTypeSelection.Supplier
    '            retValue = "S"
    '        Case PayeeTypeSelection.Others
    '            retValue = "O"
    '        Case Else
    '            retValue = Nothing
    '    End Select
    '    Return retValue
    'End Function

    'Public Function EnumToReceiptType(value As String) As String
    '    Dim retValue As String
    '    Select Case value
    '        Case Nothing
    '            retValue = "A"
    '        Case ReceiptTypeSelection.AccountsReceivable
    '            retValue = "A"
    '        Case ReceiptTypeSelection.SupplierRefund
    '            retValue = "R"
    '        Case ReceiptTypeSelection.Employee
    '            retValue = "E"
    '        Case ReceiptTypeSelection.Customer
    '            retValue = "C"
    '        Case ReceiptTypeSelection.Others
    '            retValue = "O"
    '        Case Else
    '            retValue = "A"
    '    End Select
    '    Return retValue
    'End Function

    Public Function EnumToSpecialAccount(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = ""
            Case SpecialAccountSelection.PettyCashAccount
                retValue = "PC"
            Case SpecialAccountSelection.AccountsPayable
                retValue = "AP"
            Case SpecialAccountSelection.AccountsPayableDiscount
                retValue = "PD"
            Case SpecialAccountSelection.AccountsReceivable
                retValue = "AR"
            Case SpecialAccountSelection.AccountsReceivableDiscount
                retValue = "RD"
            Case SpecialAccountSelection.Bank
                retValue = "BA"
            Case SpecialAccountSelection.Cash
                retValue = "CS"
            Case SpecialAccountSelection.CheckingAccount
                retValue = "CK"
            Case SpecialAccountSelection.CurrentEarning
                retValue = "CE"
            Case SpecialAccountSelection.EmployeeLoan
                retValue = "EL"
            Case SpecialAccountSelection.Sales
                retValue = "SL"
            Case SpecialAccountSelection.None
                retValue = ""
            Case SpecialAccountSelection.VatInput
                retValue = "VI"
            Case SpecialAccountSelection.VatOutput
                retValue = "VO"
            Case SpecialAccountSelection.AdvancesToSupplier
                retValue = "AS"
            Case SpecialAccountSelection.CustomerAdvances
                retValue = "AC"
            Case SpecialAccountSelection.BeginningInventory
                retValue = "BI"
            Case SpecialAccountSelection.EndingInventory
                retValue = "EI"
            Case Else
                retValue = ""
        End Select
        Return retValue
    End Function

    Public Function EnumToTransactionType(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case TransactionTypeSelection.NotSpecified
                retValue = Nothing
            Case TransactionTypeSelection.Invoice
                retValue = "I"
            Case TransactionTypeSelection.Debit
                retValue = "D"
            Case TransactionTypeSelection.Credit
                retValue = "C"
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function EnumToYearMonthDay(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case YearMonthDaySelection.NotSpecified
                retValue = Nothing
            Case YearMonthDaySelection.Day
                retValue = "D"
            Case YearMonthDaySelection.Month
                retValue = "M"
            Case YearMonthDaySelection.Year
                retValue = "Y"
            Case Else
                retValue = "Y"
        End Select
        Return retValue
    End Function

    Public Function EnumToYesNo(value As String) As Boolean
        Dim retValue As String
        If value = "Yes" Then
            retValue = True
        Else
            retValue = False
        End If
        Return retValue
    End Function

    <Extension()>
    Public Function GetEnumDescription(ByVal enumConstant As [Enum]) As String
        Dim attr() As DescriptionAttribute = DirectCast(enumConstant.GetType().GetField(enumConstant.ToString()).GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        Return If(attr.Length > 0, attr(0).Description, enumConstant.ToString)
    End Function

    Public Function ImageTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = ImageTypeSelection.NotSpecified
            Case "J"
                retValue = ImageTypeSelection.Jpg
            Case "P"
                retValue = ImageTypeSelection.Pdf
            Case "B"
                retValue = ImageTypeSelection.Bmp
            Case Else
                retValue = ImageTypeSelection.NotSpecified
        End Select
        Return retValue
    End Function

    Public Function MaleFemaleToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = MaleFemaleSelection.NotSpecified
            Case "M"
                retValue = MaleFemaleSelection.Male
            Case "F"
                retValue = MaleFemaleSelection.Female
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function MaritalStatusToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = MaritalStatusSelection.NotSpecified
            Case "S"
                retValue = MaritalStatusSelection.Single
            Case "M"
                retValue = MaritalStatusSelection.Married
            Case "W"
                retValue = MaritalStatusSelection.Widowed
            Case "D"
                retValue = MaritalStatusSelection.Divorced
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    'Public Function ActiveSelectionToEnum(value As String)
    '    Dim retValue As String
    '    If String.IsNullOrWhiteSpace(Value) Then
    '        retValue = "0"
    '    ElseIf Value = "N" Then
    '        retValue = "0"
    '    ElseIf Value = "Y" Then
    '        retValue = "1"
    '    Else
    '        retValue = "0"
    '    End If
    '    Return retValue
    'End Function

    Public Function PayeeTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = PayeeTypeSelection.NotSpecified
            Case "E"
                retValue = PayeeTypeSelection.Employee
            Case "C"
                retValue = PayeeTypeSelection.Customer
            Case "S"
                retValue = PayeeTypeSelection.Supplier
            Case "O"
                retValue = PayeeTypeSelection.Others
            Case Else
                retValue = PayeeTypeSelection.NotSpecified
        End Select
        Return retValue
    End Function

    Public Function PaymentMethodToEnum(value As [Enum]) As String
        Dim retValue As String
        retValue = value.GetEnumDescription()
        Return retValue
    End Function

    Public Function PaymentTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = PaymentTypeSelection.NotSpecified
            Case "A"
                retValue = PaymentTypeSelection.AccountsPayable
            Case "E"
                retValue = PaymentTypeSelection.Employee
            Case "R"
                retValue = PaymentTypeSelection.CustomerRefund
            Case "S"
                retValue = PaymentTypeSelection.Supplier
            Case "O"
                retValue = PaymentTypeSelection.Others
            Case Else
                retValue = PaymentTypeSelection.NotSpecified
        End Select
        Return retValue
    End Function

    Public Function ReceiptTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = ReceiptTypeSelection.AccountsReceivable
            Case "A"
                retValue = ReceiptTypeSelection.AccountsReceivable
            Case "R"
                retValue = ReceiptTypeSelection.SupplierRefund
            Case "E"
                retValue = ReceiptTypeSelection.Employee
            Case "C"
                retValue = ReceiptTypeSelection.Customer
            Case "O"
                retValue = ReceiptTypeSelection.Others
            Case Else
                retValue = ReceiptTypeSelection.AccountsReceivable
        End Select
        Return retValue
    End Function

    Public Function SpecialAccountToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = SpecialAccountSelection.None
            Case "PC"
                retValue = SpecialAccountSelection.PettyCashAccount
            Case "AP"
                retValue = SpecialAccountSelection.AccountsPayable
            Case "AR"
                retValue = SpecialAccountSelection.AccountsReceivable
            Case "CS"
                retValue = SpecialAccountSelection.Cash
            Case "SL"
                retValue = SpecialAccountSelection.Sales
            Case "CE"
                retValue = SpecialAccountSelection.CurrentEarning
            Case "CK"
                retValue = SpecialAccountSelection.CheckingAccount
            Case "BA"
                retValue = SpecialAccountSelection.Bank
            Case "VI"
                retValue = SpecialAccountSelection.VatInput
            Case "VO"
                retValue = SpecialAccountSelection.VatOutput
            Case "PD"
                retValue = SpecialAccountSelection.AccountsPayableDiscount
            Case "RD"
                retValue = SpecialAccountSelection.AccountsReceivableDiscount
            Case "CA"
                retValue = SpecialAccountSelection.CustomerAdvances
            Case "AS"
                retValue = SpecialAccountSelection.AdvancesToSupplier
            Case Else
                retValue = SpecialAccountSelection.None
        End Select
        Return retValue
    End Function

    Public Function TransactionTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = TransactionTypeSelection.NotSpecified
            Case "I"
                retValue = TransactionTypeSelection.Invoice
            Case "D"
                retValue = TransactionTypeSelection.Debit
            Case "C"
                retValue = TransactionTypeSelection.Credit
            Case Else
                retValue = TransactionTypeSelection.NotSpecified
        End Select
        Return retValue
    End Function

    Public Function YearMonthDayToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = YearMonthDaySelection.NotSpecified
            Case "D"
                retValue = YearMonthDaySelection.Day
            Case "M"
                retValue = YearMonthDaySelection.Month
            Case "Y"
                retValue = YearMonthDaySelection.Year
            Case Else
                retValue = YearMonthDaySelection.NotSpecified
        End Select
        Return retValue
    End Function

    'Public Function EnumToActiveSelection(value As String)
    '    Dim retValue As String
    '    If String.IsNullOrWhiteSpace(Value) Then
    '        retValue = "N"
    '    ElseIf Value = "0" Then
    '        retValue = "N"
    '    ElseIf Value = "1" Then
    '        retValue = "Y"
    '    Else
    '        retValue = "N"
    '    End If
    '    Return retValue
    'End Function
    Public Function YesNoToEnum(value As Boolean) As String
        Dim retValue As String
        If value Then
            retValue = "Yes"
        Else
            retValue = "No"
        End If
        Return retValue
    End Function

    Public Enum MoveDirection
        [First]
        [Previous]
        [Next]
        [Last]
    End Enum

    'Public Function PayeeTypeToEnum(value As String) As String
    '    Dim retValue As String
    '    Select Case value
    '        Case Nothing
    '            retValue = Nothing
    '        Case "S"
    '            retValue = PayeeTypeSelection.
    '        Case "C"
    '            retValue = PayeeTypeSelection.CustomerRefunds
    '        Case "E"
    '            retValue = PayeeTypeSelection.EmployeeLoans
    '        Case "O"
    '            retValue = PayeeTypeSelection.Others
    '        Case Else
    '            retValue = PayeeTypeSelection.AccountsPayable
    '    End Select
    '    Return retValue
    'End Function

    'Public Function EnumToPayeeType(value As String) As String
    '    Dim retValue As String
    '    Select Case value
    '        Case Nothing
    '            retValue = ""
    '        Case PayeeTypeSelection.AccountsPayable
    '            retValue = "A"
    '        Case PayeeTypeSelection.CustomerRefunds
    '            retValue = "C"
    '        Case PayeeTypeSelection.EmployeeLoans
    '            retValue = "E"
    '        Case PayeeTypeSelection.Others
    '            retValue = "O"
    '        Case Else
    '            retValue = "A"
    '    End Select
    '    Return retValue
    'End Function
End Module

Public Class DescriptionAttributes(Of T)
    Protected Attributes As New List(Of DescriptionAttribute)()

    Public Sub New()
        RetrieveAttributes()
        Descriptions = Attributes.[Select](Function(x) x.Description).ToList()
    End Sub

    Public Property Descriptions As List(Of String)

    Private Sub RetrieveAttributes()
        For Each attribute As DescriptionAttribute In GetType(T).GetMembers().SelectMany(Function(member) member.GetCustomAttributes(GetType(DescriptionAttribute), True).Cast(Of DescriptionAttribute)())
            Attributes.Add(attribute)
        Next
    End Sub

End Class