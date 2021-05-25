Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeePhoneView
        Implements IEmployeePhoneView

        Private _fullPhone As String

        Public Property AreaCode As String Implements IEmployeePhoneView.AreaCode

        Public Property CountryTelIdNo As Int16 Implements IEmployeePhoneView.CountryTelIdNo
        Public Property CountryTelCode As String Implements IEmployeePhoneView.CountryTelCode
        Public Property EmployeeIdNo As Int32 Implements IEmployeePhoneView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IView.Errors

        Public Property FullPhone As String Implements IEmployeePhoneView.FullPhone
            Get
                Return PhoneTypeName + " " + IIf(CountryTelCode = "", "", "+" + CountryTelCode) + " (" + AreaCode + ") " + PhoneNumber
            End Get
            Set(value As String)
                _fullPhone = value
            End Set
        End Property

        Public Property FullPhoneAra As String Implements IEmployeePhoneView.FullPhoneAra
            Get
                Return PhoneTypeNameAra + " " + CountryTelCode + " (" + AreaCode + ") " + PhoneNumber
            End Get
            Set(value As String)
                _fullPhone = value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IEmployeePhoneView.IdNo
        Public Property PhoneNumber As String Implements IEmployeePhoneView.PhoneNumber

        Public Property Sequence As Int16 Implements IEmployeePhoneView.Sequence

        Public Property PhoneTypeIdNo As Int16 Implements IEmployeePhoneView.PhoneTypeIdNo
        Public Property PhoneTypeName As String Implements IEmployeePhoneView.PhoneTypeName
        Public Property PhoneTypeNameAra As String Implements IEmployeePhoneView.PhoneTypeNameAra

    End Class

End Namespace