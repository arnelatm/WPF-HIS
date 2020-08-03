Imports System.ComponentModel
Imports AATM.Libraries.GlobalFuncNSub

'<TypeConverter(GetType(LocalizedEnumConverter))>
'Public Enum RevCostCenterTypeSelection
'    <EnumCode("D")> Direct
'    <EnumCode("S")> [Shared]
'End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum YesNoSelection
    No = False
    Yes = True
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum MaleFemaleSelection
    None
    Male
    Female
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum YearMonthDaySelection
    None
    Year
    Month
    Day
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum DocumentTypeSelection
    None
    Employee
    Establishment
    Supplier
    Client
    Patient
    Others
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum PayeeTypeSelection
    None
    Employee
    Customer
    Supplier
    Others
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum ImageTypeSelection
    None
    Jpg
    Pdf
    Bmp
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum PaymentMethodSelection
    None
    Cash
    Check
    CreditCard
    BankTransfer
    DebitCard
    MobileTransfer
    WireTransfer
    Paypal
    BitCoin
    Mixed
    Others
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum AccountStatusSelection
    Open
    ExceededCreditLimit
    OnHold
    CashOnly
    Prospect
    NewAccount
    SeeNote
End Enum

'<TypeConverter(GetType(LocalizedEnumConverter))>
'Public Enum AccountGroupSelection
'    None
'    Asset
'    Liability
'    Equity
'    RevExpSummary
'    Revenue
'    Expense
'End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum DebitCreditSelection
    None
    Debit
    Credit
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum DataTypeSelection
    BooleanType = 0
    ByteType = 1
    CharType = 2
    DateType = 3
    DecimalType = 4
    DoubleType = 5
    IntegerType = 6
    LongType = 7
    ObjectType = 8
    SByteType = 9
    ShortType = 10
    SingleType = 11
    StringType = 12
    UIntegerType = 13
    ULongType = 14
    UserDefinedType = 15
    UShortType = 16
End Enum

<TypeConverter(GetType(LocalizedEnumConverter))>
Public Enum RcTypeSelection
    <EnumCode("")> None
    <EnumCode("R")> Revenue
    <EnumCode("C")> Cost
    <EnumCode("B")> RevenueAndCost
End Enum

Public Module Adapter

    Public Function MaleFemaleToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = MaleFemaleSelection.None
            Case "M"
                retValue = MaleFemaleSelection.Male
            Case "F"
                retValue = MaleFemaleSelection.Female
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
            Case MaleFemaleSelection.None
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

    Public Function DebitCreditToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = DebitCreditSelection.None
            Case "D"
                retValue = DebitCreditSelection.Debit
            Case "C"
                retValue = DebitCreditSelection.Credit
            Case Else
                retValue = DebitCreditSelection.None
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
            Case DebitCreditSelection.None
                retValue = Nothing
            Case Else
                retValue = Nothing
        End Select
        Return retValue
    End Function

    Public Function RCTypeToEnum(value As String) As Int16
        Dim retValue As Int16
        Select Case value
            Case Nothing
                retValue = RcTypeSelection.Cost
            Case "R"
                retValue = RcTypeSelection.Revenue
            Case "C"
                retValue = RcTypeSelection.Cost
            Case "B"
                retValue = RcTypeSelection.RevenueAndCost
            Case Else
                retValue = RcTypeSelection.RevenueAndCost
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

    Public Function EnumToYesNo(value As String) As Boolean
        Dim retValue As String
        If value = "Yes" Then
            retValue = True
        Else
            retValue = False
        End If
        Return retValue
    End Function

    Public Function YesNoToEnum(value As Boolean) As String
        Dim retValue As String
        If value Then
            retValue = "Yes"
        Else
            retValue = "No"
        End If
        Return retValue
    End Function

    Public Function YearMonthDayToEnum(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = YearMonthDaySelection.None
            Case "D"
                retValue = YearMonthDaySelection.Day
            Case "M"
                retValue = YearMonthDaySelection.Month
            Case "Y"
                retValue = YearMonthDaySelection.Year
            Case Else
                retValue = YearMonthDaySelection.None
        End Select
        Return retValue
    End Function

    Public Function EnumToYearMonthDay(value As String)
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case YearMonthDaySelection.None
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

    Public Function EnumToDocumentType(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case DocumentTypeSelection.None
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

    Public Function DocumentTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = ImageTypeSelection.None
            Case "J"
                retValue = ImageTypeSelection.Jpg
            Case "P"
                retValue = ImageTypeSelection.Pdf
            Case "B"
                retValue = ImageTypeSelection.Bmp
            Case Else
                retValue = ImageTypeSelection.None
        End Select
        Return retValue
    End Function

    Public Function EnumToImageType(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case ImageTypeSelection.None
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

    Public Function ImageTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = ImageTypeSelection.None
            Case "J"
                retValue = ImageTypeSelection.Jpg
            Case "P"
                retValue = ImageTypeSelection.Pdf
            Case "B"
                retValue = ImageTypeSelection.Bmp
            Case Else
                retValue = ImageTypeSelection.None
        End Select
        Return retValue
    End Function

    'Public Function AccountGroupToEnum(value As String) As String
    '    Dim retValue As String
    '    Select Case value
    '        Case Nothing
    '            retValue = AccountGroupSelection.None
    '        Case "A"
    '            retValue = AccountGroupSelection.Asset
    '        Case "L"
    '            retValue = AccountGroupSelection.Liability
    '        Case "C"
    '            retValue = AccountGroupSelection.Capital
    '        Case "R"
    '            retValue = AccountGroupSelection.Revenue
    '        Case "E"
    '            retValue = AccountGroupSelection.Expense
    '        Case Else
    '            retValue = AccountGroupSelection.None
    '    End Select
    '    Return retValue
    'End Function

    'Public Function EnumToAccountGroup(value As String) As String
    '    Dim retValue As String
    '    Select Case value
    '        Case Nothing
    '            retValue = Nothing
    '        Case AccountGroupSelection.None
    '            retValue = Nothing
    '        Case AccountGroupSelection.Asset
    '            retValue = "A"
    '        Case AccountGroupSelection.Liability
    '            retValue = "L"
    '        Case AccountGroupSelection.Equity
    '            retValue = "E"
    '        Case AccountGroupSelection.RevExpSummary
    '            retValue = "S"
    '        Case AccountGroupSelection.Revenue
    '            retValue = "R"
    '        Case AccountGroupSelection.Expense
    '            retValue = "E"
    '        Case Else
    '            retValue = Nothing
    '    End Select
    '    Return retValue
    'End Function

    Public Function PayeeTypeToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = PayeeTypeSelection.None
            Case "E"
                retValue = PayeeTypeSelection.Employee
            Case "C"
                retValue = PayeeTypeSelection.Customer
            Case "S"
                retValue = PayeeTypeSelection.Supplier
            Case "4"
                retValue = PayeeTypeSelection.Others
            Case Else
                retValue = PayeeTypeSelection.None
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

    Public Function PaymentMethodToEnum(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = PaymentMethodSelection.None
            Case "CS"
                retValue = PaymentMethodSelection.Cash
            Case "CK"
                retValue = PaymentMethodSelection.Check
            Case "CC"
                retValue = PaymentMethodSelection.CreditCard
            Case "BT"
                retValue = PaymentMethodSelection.BankTransfer
            Case "DC"
                retValue = PaymentMethodSelection.DebitCard
            Case "MT"
                retValue = PaymentMethodSelection.MobileTransfer
            Case "WT"
                retValue = PaymentMethodSelection.WireTransfer
            Case "PP"
                retValue = PaymentMethodSelection.Paypal
            Case "BC"
                retValue = PaymentMethodSelection.BitCoin
            Case "MX"
                retValue = PaymentMethodSelection.Mixed
            Case "OT"
                retValue = PaymentMethodSelection.Others
            Case Else
                retValue = PaymentMethodSelection.None
        End Select
        Return retValue
    End Function

    Public Function EnumToPaymentMethod(value As String) As String
        Dim retValue As String
        Select Case value
            Case Nothing
                retValue = Nothing
            Case PaymentMethodSelection.None
                retValue = Nothing
            Case PaymentMethodSelection.Cash
                retValue = "CS"
            Case PaymentMethodSelection.Check
                retValue = "CK"
            Case PaymentMethodSelection.CreditCard
                retValue = "CC"
            Case PaymentMethodSelection.BankTransfer
                retValue = "BT"
            Case PaymentMethodSelection.DebitCard
                retValue = "DC"
            Case PaymentMethodSelection.MobileTransfer
                retValue = "MT"
            Case PaymentMethodSelection.WireTransfer
                retValue = "WT"
            Case PaymentMethodSelection.Paypal
                retValue = "PP"
            Case PaymentMethodSelection.BitCoin
                retValue = "BC"
            Case PaymentMethodSelection.Mixed
                retValue = "MX"
            Case PaymentMethodSelection.Others
                retValue = "OT"
            Case Else
                retValue = Nothing
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

End Module