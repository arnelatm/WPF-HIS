Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces.IGroup

    Public Interface IPatientView
        Inherits IView

        Property RegistrationNo As Int32
        Property Series As String
        Property PatientNameEnglish As String
        Property Gender As String

    End Interface

End Namespace