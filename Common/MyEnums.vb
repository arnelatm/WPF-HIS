Imports System.ComponentModel
Imports AATM.Libraries.GlobalFuncNSub

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

Public Enum DataTypeSelection
    BooleanType = 0
    ByteType = 1
    Accountype = 2
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