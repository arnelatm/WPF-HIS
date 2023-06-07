' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Basic
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            If GetRules().Count() = 0 Then
                AddRule(New ValidateRequired("Name"))
                AddRule(New ValidateRequired("Code"))
            End If
            'Dim user As Object = New ExpandoObject()
            'user.Add("IdNo", 0I)
            'user.Add("Age",25)
            'user.Add("Married",True)
            'user.Name = "John Doe"
            'user.Age = 42
            'user.Code = {"a","b"}

        End Sub

        Public Property IdNo As Int32
        Public Property Name As String
        Public Property NameAra As String
        Public Property Code As String
        Public Property BranchIdNo As Int16
        'Public Property Notes As String

    End Class

End Namespace