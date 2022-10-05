' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.Accounts.BusinessLayer

Namespace BusinessLayer

    Public Class PmrInvestigation
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
        End Sub

        Property DoctorID As String
        Property DoctorName As String
        Property TransactionDate As Date
        Property PmrPatientsDisplay As List(Of PmrPatientDisplay)

    End Class

End Namespace