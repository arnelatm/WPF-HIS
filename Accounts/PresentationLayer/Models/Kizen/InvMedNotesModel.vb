' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Namespace PresentationLayer.Models


    Public Class InvMedNotesModel
        Public Property InvoiceDate As Date
        Public Property PatientName As String
        Public Property Gender As String
        Public Property Age As String
        Public Property InvoiceNo As Int32
        Public Property DoctorName As String
        Public Property InvMedNotesDetails As List(Of InvMedNotesDetailModel)
    End Class

    Public Class InvMedNotesDetailModel

        Public Property IdNo As Int32
        Public Property Seq As Int32
        Public Property ItemCode As String
        Public Property ItemName As String
        Public Property Notes As String

    End Class

End Namespace