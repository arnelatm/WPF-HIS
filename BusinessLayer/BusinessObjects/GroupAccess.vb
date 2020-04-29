' GroupAccess business object
' ** Enterprise Design Pattern: Domain Model, Identity Field, Foreign Key Mapping.
Namespace BusinessObjects

    Public Class GroupAccess
        Inherits BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property IdNo As Nullable(Of Int32)
        Public Property SecurityGroupIdNo As Nullable(Of Int32)
        Public Property SecurityObjectIdNo As Nullable(Of Int32)
        Public Property SecurityObjectName As String
        Public Property Visible As Boolean

        'Public Property Selectable As Boolean
        'Public Property Viewable As Boolean
        Public Property Editable As Boolean

        ' ** Enterprise Design Pattern: Foreign Key Mapping. SecurityGroup is the parent
    End Class

End Namespace