Imports AATM.Accounts.BusinessLayer

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PmrInvestigationModel

        Public Property DoctorCode As String
        Public Property DoctorName As String
        Public Property TransactionDate As Date?
        Public Property DoctorsPatients As List(Of DoctorsPatientModel)

    End Class

    Public Class DoctorsPrescriptionModel

        Public Property DoctorCode As String
        Public Property DoctorName As String
        Public Property TransactionDate As Date?
        Public Property DoctorsPatients As List(Of DoctorsPatientModel)
        Public Property PrescriptionDetails As List(Of PrescriptionDetail)

    End Class

End Namespace