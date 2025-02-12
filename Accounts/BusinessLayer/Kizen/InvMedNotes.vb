' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field

Imports AATM.BusinessLayer

Namespace BusinessLayer


    Public Class InvMedNotes
        Inherits AATM.BusinessLayer.BusinessObject

        Public Property Age As String
        Public Property DoctorName As String
        Public Property InvoiceDate As Date
        Public Property PatientName As String
        Public Property Gender As String
        Public Property InvoiceNo As Int32
        Public Property MRN As Int32
        Public Property Nationality As String
        Public Property InvMedNotesDetails As List(Of InvMedNotesDetail)

    End Class



    Public Class InvMedNotesDetail
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