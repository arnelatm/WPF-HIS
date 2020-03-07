' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Branch
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            If GetRules().Count() = 0 Then
                ' establish business rules
                AddRule(New ValidateRequired("BranchName"))
            End If
        End Sub

        Public Property IdNo As Integer
        Public Property BranchCode As String
        Public Property BranchName As String
        Public Property BranchNameAra As String
        Public Property Notes As String
    End Class
End Namespace