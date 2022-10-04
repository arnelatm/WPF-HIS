' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Namespace BusinessLayer

    Public Class PmrInvestigation
        Inherits AATM.BusinessLayer.BusinessObject

        Property DoctorID As String
        Property DoctorName As String
        Property TransactionDate As String
        Property PmrPatientDisplay As List(Of PmrPatientDisplay)

    End Class

End Namespace