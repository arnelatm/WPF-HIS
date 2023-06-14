Imports AATM.Accounts.BusinessLayer

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

    Public Class PatientPrescriptionModel
        Inherits PatientModel
        Property PrescriptionDetail As List(Of PrescriptionModel)

    End Class

    Public Class PrescriptionModel

        Property ItemNameEnglish As String
        Property DosageEnglish As String
        Property Duration As String

    End Class

End Namespace