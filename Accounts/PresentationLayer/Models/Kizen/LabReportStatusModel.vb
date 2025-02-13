' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace PresentationLayer.Models


    Public Class LabReportStatusModel
        Public Property Age As String
        Public Property DoctorName As String
        Public Property InvoiceDate As Date
        Public Property PatientName As String
        Public Property Gender As String
        Public Property InvoiceNo As Int32
        Public Property MRN As Int32
        Public Property Nationality As String
        Public Property CollectedBy As String
        Public Property CollectedDateTime As DateTime
        Public Property Completed As Boolean?
        Public Property ProcessedBy As String
        Public Property ProcessedDateTime As DateTime
        Public Property ValidatedBy As String
        Public Property ValidatedDateTime As DateTime
    End Class

End Namespace