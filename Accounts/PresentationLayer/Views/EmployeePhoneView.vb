Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeePhoneView
        Implements IEmployeePhoneView, ISelfDuplicating

        Public Property AreaCode As String Implements IEmployeePhoneView.AreaCode
        Public Property CountryTelIdNo As Int16 Implements IEmployeePhoneView.CountryTelIdNo
        Public Property EmployeeIdNo As Int32 Implements IEmployeePhoneView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property FullPhone As String Implements IEmployeePhoneView.FullPhone
        Public Property FullPhoneAra As String Implements IEmployeePhoneView.FullPhoneAra
        Public Property IdNo As Int32 Implements IEmployeePhoneView.IdNo
        Public Property PhoneNumber As String Implements IEmployeePhoneView.PhoneNumber

        Public Property Sequence As Int16 Implements IEmployeePhoneView.Sequence

        Public Property PhoneTypeIdNo As Short Implements IEmployeePhoneView.PhoneTypeIdNo

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New EmployeePhoneView
        End Function

    End Class

End Namespace