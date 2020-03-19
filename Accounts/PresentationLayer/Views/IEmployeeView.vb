Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Interface IEmployeeView
        Inherits IView
        Property IdNo As Integer
        Property EmployeeCode As String
        Property Title As String
        Property EmployeeName As String
        Property EmployeeNameAra As String
        Property Gender As String
        Property BirthDate As Date?
        Property MaritalStatus As String
        Property NationalityCode As String
        Property ReligionIdNo As Int16
        Property NationalIdNo As String
        Property Street As String
        Property District As String
        Property TownCity As String
        Property ProvinceState As String
        Property CountryCode As String
        Property PoBox As String
        Property ZipCode As String
        Property Phone1 As String
        Property Phone2 As String
        Property Email As String
        Property DepartmentIdNo As Int16
        Property DesignationIdNo As Int16
        Property HiredDate As Date?
        Property ReleasedDate As Date?
        Property ArAccountIdNo As Int32
        Property BankIdNo As Int16
        Property BankAccountNo As String
        Property Iban As String
        Property Notes As String
        Property OpeningBalance As Decimal
        Property Balance As Decimal
        Property Active As Boolean

    End Interface

End Namespace