Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer


' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

    Public Class Employee
        Inherits AATM.BusinessLayer.BusinessObject
        Protected Presenter As Object
        Protected TargetIdNo As Int32

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New(createRules As Boolean, ByRef presenterObj As Object)
            ' establish business rules
            Presenter = presenterObj
            If createRules Then
                AddRule(New ValidateRequired("EmployeeName"))
                AddRule(New ValidateRequired("EmployeeNameAra"))
                AddRule(New ValidateRequired("EmployeeCode"))
                AddRule(New ValidateEmail("Email"))
                AddRule(New ValidateUnique("EmployeeCode", presenter))
                AddRule(New ValidateUnique("EmployeeName", presenter))
            End If
        End Sub
        
        Public Property IdNo As Integer
        Public Property EmployeeCode As String
        Public Title As String
        Public Property EmployeeName As String
        Public Property EmployeeNameAra As String
        Public Property Gender As String
        Public Property BirthDate As Date?
        Public Property MaritalStatus As String
        Public Property NationalityCode As String
        Public Property ReligionIdNo As Int16
        Public Property NationalIdNo As String

        'Public Property ContactPerson As String
        'Public Property ContactDesignation As String
        Public Property Street As String

        Public Property District As String
        Public Property PoBox As String
        Public Property ZipCode As String
        Public Property TownCity As String
        Public Property ProvinceState As String
        Public Property CountryCode As String

        'Public Property PoBox As String
        'Public Property ZipCode As String
        Public Property Phone1 As String

        Public Property Phone2 As String

        'Public Property Mobile As String
        'Public Property Fax As String
        Public Property Email As String

        Public Property DepartmentIdNo As Int16
        Public Property DesignationIdNo As Int16
        Public Property HiredDate As Date?
        Public Property ReleasedDate As Date?

        'Public Property Website As String
        'Public Property VatNumber As String
        'Public Property CrNumber As String
        'Public Property AccountStatus As String
        Public Property ArAccountIdNo As Int32

        'Public Property RevAccountIdNo As Int32
        'Public Property CreditLimit As Single
        'Public Property SettlementDueDays As Int16
        'Public Property SettlementDiscount As Decimal
        'Public Property PaymentDueDays As Int16
        'Public Property DateAccountOpen As Date?
        Public Property BankIdNo As Int16

        Public Property BankAccountNo As String
        Public Property Iban As String

        'Public Property PaymentMethod As String
        Public Property Notes As String

        Public Property OpeningBalance As Decimal
        Public Property Balance As Decimal

        'Public Property DiscountSchemeIdNo As Int16
        Public Property Active As Boolean

    End Class
End NameSpace