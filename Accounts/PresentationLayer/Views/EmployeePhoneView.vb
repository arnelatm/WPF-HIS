Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views

    Public Class EmployeePhoneView
        Implements IEmployeePhoneView, ISelfDuplicating

        Public Property AreaCode As String Implements IEmployeePhoneView.AreaCode
        Public Property CountryTelCode As String Implements IEmployeePhoneView.CountryTelCode
        Public Property EmployeeIdNo As Int32 Implements IEmployeePhoneView.EmployeeIdNo
        Public Property Errors As List(Of String) Implements IView.Errors
        Public Property IdNo As Int32 Implements IEmployeePhoneView.IdNo
        Public Property PhoneNumber As String Implements IEmployeePhoneView.PhoneNumber
        Public Property PhoneTypeIdNo As Int16 Implements IEmployeePhoneView.PhoneTypeIdNo
        Public Property Sequence As Int16 Implements IEmployeePhoneView.Sequence

        Public Function BlankCopy() As Object Implements ISelfDuplicating.BlankCopy
            Return New EmployeePhoneView
        End Function

    End Class

End Namespace