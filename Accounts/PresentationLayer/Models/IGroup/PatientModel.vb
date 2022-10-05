Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PatientModel
        Property RegistrationNo As Int32
        Property Series As String
        Property PatientNameEnglish As String
        Property Sex As String
    End Class

End Namespace