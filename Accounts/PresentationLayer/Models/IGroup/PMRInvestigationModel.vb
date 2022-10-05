

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PmrInvestigationModel

        Public Property DoctorID As String
        Public Property DoctorName As String
        Public Property TransactionDate As String
        Public Property PmrPatientDisplay As List(Of AATM.Accounts.BusinessLayer.PmrPatientDisplay)

    End Class

End Namespace