' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Accounts.BusinessLayer

Namespace BusinessLayer

    Public Class PmrInvestigation
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
        End Sub

        Property DoctorCode As String
        Property DoctorName As String
        Property TransactionDate As Date?
        Property DoctorsPatients As List(Of DoctorsPatient)

    End Class

    Public Class DoctorsPrescription
        Inherits PmrInvestigation

        Property PrescriptionDetails As List(Of PrescriptionItem)

    End Class

End Namespace