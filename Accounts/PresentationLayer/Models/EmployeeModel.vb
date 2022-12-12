Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeModel
        'Implements IModelNew

        Public Property Errors As List(Of String)
        Public Property Active As Boolean
        Public Property ActualDutyHours As Decimal
        Public Property ArAccountIdNo As Int16?
        Public Property BankAccountNo As String
        Public Property Balance As Decimal
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
        Public Property PayCycleIdNo As Byte?
        Public Property PayGroupIdNo As Int16?
        Public Property PaymentMethod As Char
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
        Public Property PayFrequency As PayFrequencySelection
        Public Property RegularEmployeeDeductions As List(Of EmployeePayElementModel)
        Public Property RegularEmployeeEarnings As List(Of EmployeePayElementModel)
        Public Property EmployeeDocuments As List(Of EmployeeDocumentModel)
        Public Property EmployeePhones As List(Of EmployeePhoneModel)
        Public Property EmployeeLeaveCredits As List(Of EmployeeLeaveCreditModel)
        Public Property Picture As Image
    End Class

End Namespace