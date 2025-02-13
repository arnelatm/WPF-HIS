' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Imports AATM.BusinessLayer

Namespace BusinessLayer


    Public Class LabReportStatus
        Inherits AATM.BusinessLayer.BusinessObject

        Public Property Age As String
        Public Property RequestedBy As String
        Public Property PatientName As String
        Public Property PatientNameMRN As String
        Public Property Gender As String
        Public Property InvoiceNo As Int32
        Public Property MRN As Int32
        Public Property Nationality As String
        Public Property Completed As Boolean?
        Public Property CollectedBy As String
        Public Property CollectedDateTime As DateTime?
        Public Property ProcessedBy As String
        Public Property ProcessedDateTime As DateTime?
        Public Property RequestedDateTime As String
        Public Property SampleNo As Int32
        Public Property ValidatedBy As String
        Public Property ValidatedDateTime As DateTime?


    End Class



    Public Class LabReportStatusDetail
        Inherits BusinessObject

        Public Sub New()

        End Sub

        Public Property IdNo As Int32
        Public Property Seq As Int32
        Public Property ItemCode As String
        Public Property ItemName As String
        Public Property Note As String

    End Class

End Namespace