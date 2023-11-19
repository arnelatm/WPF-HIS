' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Imports AATM.BusinessLayer

Namespace BusinessLayer


    Public Class ClinicLabSample
        Inherits AATM.BusinessLayer.BusinessObject
        Public Property TransactionDate As Date
        Public Property ClinicLabSampleDetails As List(Of ClinicLabSampleDetail)
    End Class



    Public Class ClinicLabSampleDetail
        Inherits BusinessObject

        Public Sub New()

        End Sub

        Public Property Age As Decimal
        Public Property IdNo As Int32
        Public Property IqamaNo As String
        Public Property LabNo As String
        Public Property DoctorName As String
        Public Property PatientName As String
        Public Property RegistrationNo As String
        Public Property Sequence As Int32
        Public Property TransKey As Int32
        Public Property TakenDate As Date
        Public Property TakenTime As String
        Public Property TakenBy As String
        Public Property TestName As String
    End Class

End Namespace