Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeModel
        Public Property Errors As List(Of String)
        Public Property Active As Boolean
        Public Property ArAccountIdNo As Int16?
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
        Public Property EmployeeDeductions As List(Of EmployeeDeductionModel)
        Public Property EmployeeEarnings As List(Of EmployeeEarningModel)
        Public Property EmployeePhones As List(Of EmployeePhoneModel)
    End Class

End Namespace