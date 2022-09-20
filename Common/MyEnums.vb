Imports AATM.Libraries.GlobalFuncNSub

Public Enum YearMonthDaySelection
    <EnumCode("")> NotSpecified
    <EnumCode("Y")> Year
    <EnumCode("M")> Month
    <EnumCode("D")> Day
End Enum

Public Enum BloodTypeSelection
    <EnumCode("O-")> [ONegative]
    <EnumCode("O+")> [OPositive]
    <EnumCode("A-")> [ANegative]
    <EnumCode("A+")> [APositive]
    <EnumCode("B-")> [BNegative]
    <EnumCode("B+")> [BPositive]
    <EnumCode("AB-")> [ABNegative]
    <EnumCode("AB+")> [ABPositive]
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

Public Enum ImageTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("J")> Jpg
    <EnumCode("P")> Pdf
    <EnumCode("B")> Bmp
End Enum

Public Enum RevCostTypeSelection
    <EnumCode("")> NotSpecified
    <EnumCode("R")> Revenue
    <EnumCode("C")> Cost
    <EnumCode("B")> RevenueAndCost
End Enum

Public Enum BloodType
    <EnumCode("")> NotSpecified
    <EnumCode("R")> Revenue
    <EnumCode("C")> Cost
    <EnumCode("B")> RevenueAndCost
End Enum


'Public Enum eTimeAMPM
'    <EnumCode("0")> am
'    <EnumCode("1")> pm
'End Enum