' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class EmployeeDocument
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            'If GetRules().Count() = 0 Then
            '    AddRule(New ValidateRequired("DocumentNumber"))
            'End If
        End Sub

        Public Property DataImageIdNo As Int32
        Public Property DocumentIdNo As Int16
        Public Property DocumentNumber As String
        Public Property EmployeeIdNo As Int32
        Public Property ExpiryDate As Date?
        Public Property IdNo As Int32
        Public Property IssueDate As Date?
        Public Property Sequence As Int16

    End Class

End Namespace