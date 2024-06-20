Imports AATM.Accounts.BusinessLayer

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PatientModel
        Public Property RegistrationNo As Int32
        Public Property Series As String
        Public Property PatientNameEnglish As String
        Public Property Sex As String
    End Class

    Public Class PatientPrescriptionModel
        Inherits PatientModel
        Public Property PrescriptionDetail As List(Of PrescriptionModel)

    End Class

    Public Class PrescriptionModel

        Public Property ItemNameEnglish As String
        Public Property DosageEnglish As String
        Public Property Duration As String

    End Class

End Namespace