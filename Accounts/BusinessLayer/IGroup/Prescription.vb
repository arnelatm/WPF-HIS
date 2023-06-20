Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Prescription
        Inherits AATM.BusinessLayer.BusinessObject

        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                'AddRule(New ValidateRequired("GTin"))
                'AddRule(New ValidateRequired("Expiry"))
                'AddRule(New ValidateRequired("SerializationNo"))
                'AddRule(New ValidateRequired("BatchNo"))
            End If

        End Sub

        Public Property Age As String
        Public Property AgeYmd As String
        Public Property DoctorCode As String
        Public Property DoctorName As String
        Public Property FileNo As Integer
        Public Property Gender As String
        Public Property PatientName As String
        Public Property Series As String
        Public Property TransDate As String
        Public Property TransKey As Integer
        Public Property PrescriptionDetails As List(Of PrescriptionDetail)

    End Class

End Namespace