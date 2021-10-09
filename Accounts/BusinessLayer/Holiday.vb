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
                AddRule(New ValidateRequired("Description"))
                AddRule(New ValidateRequired("DateEnd"))
                AddRule(New ValidateRequired("DateStart"))
            End If
        End Sub

        Property DateCreated As DateTime?
        Property DateEnd As Date
        Property DateStart As Date
        Property Description As String
        Property IdNo As Int32
        Property LeaveIdNo As Int16
        Property PayrollIdNo As Int32

    End Class

End Namespace