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

        Public Property IdNo As Int16
        Public Property EmployeeIdNo As Int16
        Public Property DocumentIdNo As Int16
        Public Property DocumentNumber As Int16
        Public Property ExpiryDate As Date?
        Public Property IssueDate As Date?
        Public Property Number As String
        Public Property Notes As String
        Public Property Image As Image
        Public Property Sequence As Int16
    End Class

End Namespace