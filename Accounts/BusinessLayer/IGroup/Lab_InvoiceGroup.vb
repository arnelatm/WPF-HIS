' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer

    Public Class Lab_InvoiceGroup
        Property IdNo As Int32
        Property InvoiceNo As Decimal
        Property InvoiceType As String
        Property InvoiceDate As Date
        Property PatientNameEnglish As String
        Property AgeYMD As String
        Property Age As Int16
        Property Sex As String
        Property RegistrationNo As Decimal
        Property SampleNo As String
        Property Status As Int32
        Property Remarks As String
        Property LabInvoiceDetails As List(Of Lab_InvoiceDetails)
    End Class

    Public Class Lab_InvoiceDetails
        Property Group_Key As Decimal
        Property SlNo As Decimal
        Property Diagnosis1 As String
        Property Result1 As String
        Property Suffix1 As String
    End Class

End Namespace