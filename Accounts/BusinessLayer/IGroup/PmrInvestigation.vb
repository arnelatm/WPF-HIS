' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field


Namespace BusinessLayer.IGroup

    Public Class PmrInvestigation
        Property RegistrationNo As Int32
        Property Series As String
        Property PatientName As String
        Property Gender As String
        Property LabInvoiceDetails As List(Of Lab_InvoiceDetails)
    End Class

End Namespace