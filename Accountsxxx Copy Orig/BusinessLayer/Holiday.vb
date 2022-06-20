' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Holiday
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("LeaveIdNo"))
                AddRule(New ValidateRequired("DateEnd"))
                AddRule(New ValidateRequired("DateStart"))
            End If
        End Sub

        Property DateCreated As DateTime?
        Property DateEnd As Date
        Property DateStart As Date
        Property EnteredBy As Int32
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        'Property PayrollCode As String
        'Property PayrollEndDate As Date
        'Property PayrollIdNo As Int32
        'Property PayrollName As String
        'Property PayrollStartDate As Date

    End Class

End Namespace