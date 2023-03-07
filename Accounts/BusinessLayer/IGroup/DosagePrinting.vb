' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DosagePrinting
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                'AddRule(New ValidateRequired("GTin"))
                'AddRule(New ValidateRequired("Expiry"))
                'AddRule(New ValidateRequired("SerializationNo"))
                'AddRule(New ValidateRequired("BatchNo"))
            End If

        End Sub

        Public Property Dosage As String
        Public Property DosageUnit As String
        Public Property Route As String
        Public Property Direction As String
        Public Property Frequency As String
        Public Property FrequencyTiming As String
        Public Property Duration As String
        Public Property DurationUnit As String

    End Class

End Namespace