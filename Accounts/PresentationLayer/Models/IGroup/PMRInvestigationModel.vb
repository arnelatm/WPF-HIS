

Namespace PresentationLayer.Models.IGroup

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PmrInvestigationModel
        Property RegistrationNo As Int32
        Property Series As String
        Property PatientName As String
        Property Gender As String
    End Class

End Namespace