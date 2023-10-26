' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace PresentationLayer.Models


    Public Class IbLabSampleModel
        Property TransactionDate As Date
        Property IbLabSampleDetails As List(Of IbLabSampleDetailModel)
    End Class



    Public Class IbLabSampleDetailModel

        Public Property Age As Decimal
        Public Property IdNo As Int32
        Public Property IqamaNo As String
        Public Property LabNo As String
        Public Property Nationality As String
        Public Property PatientName As String
        Public Property Rbs As Decimal
        Public Property Sequence As Int32
        Public Property Stool As Boolean
        Public Property TakenBy As String
        Public Property TakenDate As Date
        Public Property TakenTime As String
        Public Property Urine As Boolean
    End Class

End Namespace