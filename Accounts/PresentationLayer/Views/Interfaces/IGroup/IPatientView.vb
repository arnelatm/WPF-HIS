Imports AATM.Accounts.BusinessLayer
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IPatientView
        Inherits IView

        Property RegistrationNo As Int32
        Property Series As String
        Property PatientNameEnglish As String
        Property Gender As String
        Property Age As String
        Property AgeYMD As String

    End Interface

    Public Interface IPatientPrescriptionView
        Inherits IPatientView
        Property PrescriptionDetail As List(Of Prescription)

    End Interface

    Public Interface Prescription

        Property ItemNameEnglish As String
        Property DosageEnglish As String
        Property Duration As String

    End Interface

End Namespace