' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports AATM.BusinessLayer.BusinessRules

Namespace BusinessLayer

    Public Class Document
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
            AddRule(New ValidateRequired("DocumentName"))
            'AddRule(New ValidateRequired("DocumentCode"))
        End Sub

        Public Property IdNo As Int16
        Public Property DocumentCode As String
        Public Property DocumentName As String
        Public Property DocumentNameAra As String
        Public Property DocumentType As String
        Public Property ImageType As String
        Public Property NeedsExpiryDate As Boolean
        Public Property NeedsIssueDate As Boolean
        Public Property NeedsNumber As Boolean
        Public Property Notes As String
    End Class

End Namespace