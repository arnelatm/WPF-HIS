' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace PresentationLayer.Models


    Public Class IbLabSampleModel
        Property TransactionDate As Date
        Property IbLabSampleDetails As List(Of IbLabSampleDetailModel)
    End Class



    Public Class IbLabSampleDetailModel
        Property IdNo As Int32
        Property TransKey As Int32
        Property TakenDate As Date
        Property TakenTime As DateTime
        Property TakenBy As String
        Property Urine As Boolean
        Property Stool As Boolean
        Property Rbs As Decimal
    End Class

End Namespace