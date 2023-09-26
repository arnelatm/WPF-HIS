' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class DocumentDetail
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If GetRules().Count() = 0 Then
            '    AddRule(New ValidateRequired("DocumentNumber"))
            'End If
        End Sub

        Public Property Active As Boolean
        Public Property BranchIdNo As Int16
        Public Property DataImageIdNo As Int32
        Public Property DocumentIdNo As Int16
        Public Property DocumentNumber As String
        Public Property ContactIdNo As Int32
        Public Property ExpiryDate As Date?
        Public Property IdNo As Int32
        Public Property IssueDate As Date?
        Public Property UserIdNo As Int16
        Public Property DateCreated As Date
        Public Property Picture As Image

    End Class

End Namespace