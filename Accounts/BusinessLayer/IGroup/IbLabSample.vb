' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Imports AATM.BusinessLayer

Namespace BusinessLayer


    Public Class IbLabSample
        Inherits AATM.BusinessLayer.BusinessObject
        Public Property TransactionDate As Date
        Public Property IbLabSampleDetails As List(Of IbLabSampleDetail)
    End Class



    Public Class IbLabSampleDetail
        Inherits BusinessObject

        Public Sub New()

        End Sub

        Public Property Age As Decimal
        Public Property IdNo As Int32
        Public Property IqamaNo As String
        Public Property LabNo As String
        Public Property Nationality As String
        Public Property PatientName As String
        Public Property Sequence As Int32
        Public Property TransKey As Int32
        Public Property TakenDate As Date
        Public Property TakenTime As String
        Public Property TakenBy As String
        Public Property Urine As Boolean
        Public Property Stool As Boolean
        Public Property Rbs As Decimal
    End Class

End Namespace