Imports AATM.BusinessLayer.BusinessRules

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
                AddRule(New ValidateRequired("HiredDate"))
                'AddRule(New ValidateRequired("EmployeeCode"))
                'AddRule(New ValidateRequired("PaymentMethod"))
                AddRule(New ValidateEmail("Email"))
                'AddRule(New ValidateIfRequired("BankIdNo", "PaymentMethod", ValidationOperator.Equal, ValidationDataType.String, GlobalFunctions.EnumToCode(PayrollPaymentMethodSelection.BankTransfer)))
                'AddRule(New ValidateIfRequired("Iban", "PaymentMethod", ValidationOperator.Equal, ValidationDataType.String, GlobalFunctions.EnumToCode(PayrollPaymentMethodSelection.BankTransfer)))
            End If
        End Sub

        Public Property Active As Boolean
        Public Property ArAccountIdNo As Int16?
        Public Property Balance As Decimal
        Public Property BankAccountNo As String
        Public Property BankIdNo As Int16?
        Public Property BirthDate As Date?
        Public Property BloodType As String
        Public Property CountryCode As String
        Public Property DepartmentIdNo As Int16?
        Public Property DesignationIdNo As Int16?
        Public Property District As String
        Public Property DutyHours As Decimal
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
        Public Property PayCycleIdNo As Int16?
        Public Property PayGroupIdNo As Int16?
        Public Property PaymentMethod As Char
        Public Property PayRateAmount As Decimal
        Public Property PayRateType As Char
        Public Property Phone1 As String
        Public Property Phone2 As String
        Public Property PoBox As String
        Public Property ProvinceState As String
        Public Property ReleasedDate As Date?
        Public Property ReligionIdNo As Int16?
        Public Property SponsorType As Char
        Public Property Street As String
        Public Property Supervisor As Boolean
        Public Property SupervisorIdNo As Int32
        Public Property Title As String
        Public Property TownCity As String
        Public Property ZipCode As String
        Public Property RegularEmployeeDeductions As List(Of EmployeePayElement)
        Public Property RegularEmployeeEarnings As List(Of EmployeePayElement)
        Public Property EmployeePhones As List(Of EmployeePhone)
        Public Property EmployeeLeaveCredits As List(Of EmployeeLeaveCredit)
        Public Property PayFrequency As PayFrequencySelection
        Public Property Picture As Image

    End Class

End Namespace