' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace BusinessLayer


    Public Class IbLabSample
        Public Property TransactionDate As Date
        Public Property IbLabSampleDetails As List(Of IbLabSampleDetail)
    End Class



    Public Class IbLabSampleDetail
        Public Property IdNo As Int32
        Public Property TransKey As Int32
        Public Property TakenDate As Date
        Public Property TakenTime As DateTime
        Public Property TakenBy As String
        Public Property Urine As Boolean
        Public Property Stool As Boolean
        Public Property Rbs As Decimal
    End Class

End Namespace