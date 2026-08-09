Imports AATM.BusinessLayer

Namespace BusinessLayer

    Public Class MedicalFitnessReport
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property InvoiceNo As Int32
        Public Property InvoiceDate As Date?
        Public Property FileNo As Int32?
        Public Property PatientName As String
        Public Property Gender As String
        Public Property Age As String
        Public Property Nationality As String
        Public Property IdentityNo As String
        Public Property DoctorName As String
        Public Property BloodType As String
        Public Property FinalResultStatus As String
        Public Property Remarks As String
        Public Property Details As List(Of MedicalFitnessReportTestResult)

    End Class

    Public Class MedicalFitnessReportTestResult
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property MedicalFitnessReportIdNo As Int32
        Public Property SectionCode As String
        Public Property TestCode As String
        Public Property TestNameEnglish As String
        Public Property TestNameArabic As String
        Public Property DisplayOrder As Int32
        Public Property ResultStatus As String
        Public Property ResultText As String
        Public Property Remarks As String

    End Class

    Public Class MedicalFitnessReportLabTemplate
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property TestCode As String
        Public Property TestNameEnglish As String
        Public Property TestNameArabic As String
        Public Property DisplayOrder As Int32
        Public Property Active As Boolean

    End Class

    Public Class MedicalFitnessReportLabAnalysis
        Inherits BusinessObject

        Public Property TestCode As String
        Public Property TestNameEnglish As String

    End Class

End Namespace
