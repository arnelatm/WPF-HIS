Imports AATM.BusinessLayer

Namespace BusinessLayer

    Public Class MedicalFitnessReport
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property InvoiceNo As Int32
        Public Property MedicalReportFormatIdNo As Int32
        Public Property ReportFormat As String
        Public Property InvoiceDate As Date?
        Public Property FileNo As Int32?
        Public Property PatientName As String
        Public Property CompanyName As String
        Public Property PassportNo As String
        Public Property Gender As String
        Public Property Age As String
        Public Property Nationality As String
        Public Property IdentityNo As String
        Public Property DoctorName As String
        Public Property BloodType As String
        Public Property ExamTemperature As String
        Public Property ExamBloodPressure As String
        Public Property ExamPulse As String
        Public Property ExamRespiratorySystem As String
        Public Property ExamCardiovascularSystem As String
        Public Property ExamNervousSystem As String
        Public Property ExamAbdomen As String
        Public Property ExamWeight As String
        Public Property ExamHeight As String
        Public Property ExamExtremities As String
        Public Property ExamChestXRay As String
        Public Property ExamRightEye As String
        Public Property ExamLeftEye As String
        Public Property ExamRightEar As String
        Public Property ExamLeftEar As String
        Public Property FinalResultStatus As String
        Public Property Remarks As String
        Public Property Details As List(Of MedicalFitnessReportTestResult)

    End Class

    Public Class MedicalFitnessReportInvoiceSearchResult
        Inherits BusinessObject

        Public Property InvoiceNo As Int32
        Public Property InvoiceDate As Date?
        Public Property FileNo As String
        Public Property PatientName As String
        Public Property IdentityNo As String

    End Class

    Public Class MedicalFitnessReportTestResult
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property MedicalFitnessReportIdNo As Int32
        Public Property SectionCode As String
        Public Property TestCode As String
        Public Property TestNameEnglish As String
        Public Property TestNameArabic As String
        Public Property Sequence As Int32
        Public Property InputMode As String
        Public Property IsRequired As Boolean

        Public Property DisplayOrder As Int32
            Get
                Return Sequence
            End Get
            Set(value As Int32)
                Sequence = value
            End Set
        End Property

        Public Property ResultStatus As String
        Public Property ResultText As String
        Public Property LabResult As String
        Public Property LabReferenceValue As String
        Public Property LabUnit As String
        Public Property LabAssessment As String
        Public Property ResultStatusSource As String
        Public Property Remarks As String

    End Class

    Public Class MedicalFitnessReportLabTemplate
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property TestCode As String
        ' The existing TestNameEnglish column stores the Kizen source name.
        ' This property is a UI/read-model alias and is not a database column.
        Public Property KizenTestNameEnglish As String
        Public Property EnglishNameOverride As String
        Public Property ArabicNameOverride As String
        Public Property TestNameEnglish As String
        Public Property TestNameArabic As String
        Public Property DisplayOrder As Int32
        Public Property CopyResultToEntry As Boolean
        Public Property Active As Boolean

    End Class

    Public Class MedicalFitnessReportKizenLabItem
        Inherits BusinessObject

        Public Property Code As String
        Public Property Name As String

        Public ReadOnly Property DisplayText As String
            Get
                Return String.Format("{0} - {1}", Code, Name)
            End Get
        End Property

    End Class

    Public Class MedicalFitnessReportLabAnalysis
        Inherits BusinessObject

        Public Property TestCode As String
        Public Property TestNameEnglish As String
        Public Property ResultValue As String
        Public Property ReferenceValue As String
        Public Property Unit As String

    End Class

    Public Class MedicalFitnessReportExamTemplate
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property SectionCode As String
        Public Property TestCode As String
        Public Property TestNameEnglish As String
        Public Property TestNameArabic As String
        Public Property Unit As String
        Public Property DefaultValue As String
        Public Property DisplayOrder As Int32
        Public Property InputMode As String
        Public Property IsRequired As Boolean
        Public Property Active As Boolean

    End Class

    Public Class MedicalFitnessReportFormat
        Inherits BusinessObject

        Public Property MRIdNo As Int32
        Public Property FormatCode As String
        Public Property TitleEnglish As String
        Public Property TitleArabic As String
        Public Property CrystalReportFileName As String
        Public Property Active As Boolean
        Public Property DisplayOrder As Int32
        Public Property IsDefault As Boolean

    End Class

    Public Class MedicalFitnessReportFormatItem
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property MRIdNo As Int32
        Public Property ExamTemplateIdNo As Int32
        Public Property SectionCode As String
        Public Property TestCode As String
        Public Property TestNameEnglish As String
        Public Property TestNameArabic As String
        Public Property Unit As String
        Public Property DefaultValue As String
        Public Property DisplayOrder As Int32
        Public Property InputMode As String
        Public Property IsRequired As Boolean
        Public Property Active As Boolean

    End Class

    Public Class MedicalFitnessReportFormatAssignment
        Inherits BusinessObject

        Public Property IdNo As Int32
        Public Property CompanyName As String
        Public Property MRIdNo As Int32
        Public Property FormatTitle As String
        Public Property Active As Boolean

    End Class

    Public Class MedicalFitnessGroupedLabResult
        Inherits BusinessObject

        Public Property Sequence As Int32
        Public Property GroupName As String
        Public Property TestCode As String
        Public Property TestName As String
        Public Property ResultValue As String
        Public Property ReferenceValue As String
        Public Property Unit As String

    End Class

End Namespace
