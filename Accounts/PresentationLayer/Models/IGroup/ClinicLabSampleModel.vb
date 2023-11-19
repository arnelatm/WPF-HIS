' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace PresentationLayer.Models


    Public Class ClinicLabSampleModel
        Property TransactionDate As Date
        Property ClinicLabSampleDetails As List(Of ClinicLabSampleDetailModel)
    End Class



    Public Class ClinicLabSampleDetailModel

        Public Property Age As Decimal
        Public Property IdNo As Int32
        Public Property IqamaNo As String
        Public Property LabNo As String
        Public Property Nationality As String
        Public Property PatientName As String
        Public Property RegistrationNo As String
        Public Property Sequence As Int32
        Public Property TakenBy As String
        Public Property TakenDate As Date
        Public Property TakenTime As String
        Public Property TestName As String
    End Class

End Namespace
