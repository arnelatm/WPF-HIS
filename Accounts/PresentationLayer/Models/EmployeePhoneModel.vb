Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeePhoneModel
        Public Property AreaCode As String
        Public Property EmployeeIdNo As Int32
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property InternationalCode As String
        Public Property PhoneNumber As String
        Public Property PhoneTypeIdNo As Int16
        Public Property Sequence As Int16

    End Class

End Namespace