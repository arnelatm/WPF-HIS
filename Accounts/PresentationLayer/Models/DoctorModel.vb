Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DoctorModel

        Public Property DoctorCode As String
        Public Property DoctorName As String
        Public Property DoctorNameAra As String
        Public Property DateCreated As DateTime?
        Public Property EmployeeIdNo As Int32
        Public Property IdNo As Int32
        Public Property SpecialtyIdNo As Int32
    End Class

End Namespace