Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.BusinessLayer.BusinessRules
Imports AATM.Libraries.GlobalFuncNSub

Namespace BusinessLayer

    ' Category business object
    ' ** Enterprise Design Pattern: Domain Model, Identity Field

    Public Class Employee
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("EmployeeName"))
                AddRule(New ValidateRequired("EmployeeNameAra"))
                AddRule(New ValidateRequired("EmployeeCode"))
                AddRule(New ValidateRequired("PaymentMethod"))
                AddRule(New ValidateRequired("PayFrequency"))
                AddRule(New ValidateRequired("NationalIdNo"))
                AddRule(New ValidateEmail("Email"))
                AddRule(New ValidateIfRequired("BankIdNo", "PaymentMethod", ValidationOperator.Equal, ValidationDataType.String, GlobalFunctions.GetEnumCode(PayrollPaymentMethodSelection.BankTransfer)))
                AddRule(New ValidateIfRequired("Iban", "PaymentMethod", ValidationOperator.Equal, ValidationDataType.String, GlobalFunctions.GetEnumCode(PayrollPaymentMethodSelection.BankTransfer)))
                'AddRule(New ValidateUnique("EmployeeName"))
            End If
        End Sub

        Public Property Active As Boolean
        Public Property ArAccountIdNo As Int16?
        Public Property Balance As Decimal
        Public Property BankAccountNo As String
        Public Property BankIdNo As Int16?
        Public Property BirthDate As Date?
        Public Property CountryCode As String
        Public Property DepartmentIdNo As Int16?
        Public Property DesignationIdNo As Int16?
        Public Property District As String
        Public Property Email As String
        Public Property EmployeeCode As String
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property Gender As String
        Public Property HiredDate As Date?
        Public Property Iban As String
        Public Property IdNo As Int32
        Public Property MaritalStatus As String
        Public Property NationalIdNo As String
        Public Property NationalityCode As String
        Public Property Notes As String
        Public Property OpeningBalance As Decimal
        Public Property PayFrequency As Char
        Public Property PaymentMethod As Char

        'Public Property PaySalariedOrHourly As Char
        Public Property PayRateAmount As Decimal

        Public Property PayRateType As Char
        Public Property Phone1 As String
        Public Property Phone2 As String
        Public Property PoBox As String
        Public Property ProvinceState As String
        Public Property ReleasedDate As Date?
        Public Property ReligionIdNo As Byte?
        Public Property Street As String
        Public Property Title As String
        Public Property TownCity As String
        Public Property ZipCode As String
        Public Property EmployeeDeductions As List(Of EmployeeDeduction)
        Public Property EmployeeEarnings As List(Of EmployeeEarning)
        Public Property EmployeePhones As List(Of EmployeePhone)

    End Class

End Namespace