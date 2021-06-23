Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeView
        Inherits IView
        Property Active As Boolean
        Property BankAccountNo As String
        Property BankIdNo As Int16?
        Property Balance As Decimal
        Property BirthDate As Date?
        Property CountryCode As String
        Property DepartmentIdNo As Int16?
        Property DesignationIdNo As Int16?
        Property District As String
        Property DutyHours As Decimal
        Property Email As String
        Property EmployeeCode As String
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property Gender As String
        Property HiredDate As Date?
        Property Iban As String
        Property IdNo As Int32
        Property MaritalStatus As String
        Property NationalIdNo As String
        Property NationalityCode As String
        Property Notes As String
        Property OpeningBalance As Decimal
        Property PayCycleIdNo As Int16?
        Property PayGroupIdNo As Int16?
        Property PaymentMethod As Char
        Property PoBox As String
        Property ProvinceState As String
        Property ReleasedDate As Date?
        Property ReligionIdNo As Int16?
        Property Street As String
        Property Title As String
        Property TownCity As String
        Property ZipCode As String
        Property RegularEmployeeDeductions As List(Of EmployeePayElementView)
        Property RegularEmployeeEarnings As List(Of EmployeePayElementView)
        Property EmployeePhones As List(Of EmployeePhoneView)

    End Interface

End Namespace