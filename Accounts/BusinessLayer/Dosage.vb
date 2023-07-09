' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Dosage
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

        Public Property IdNo As Int32
        Public Property DosageCode As String
        Public Property DosageName As String
        Public Property DosageNameAra As String
        Public Property Route As Int32
        Public Property Direction As Int32
        Public Property Frequency As Int32
        Public Property FrequencyTiming As Int32

    End Class

    Public Class DosagePrinting
        Inherits Dosage

        Public Property Age As Int16
        Public Property AgeDMY As String
        Public Property Dose As Decimal
        Public Property DoseUnit As Int16
        Public Property Duration As Decimal
        Public Property DurationUnit As Int16
        Public Property FileNo As Int32
        Public Property Gender As String
        Public Property PatientName As String


    End Class
End Namespace