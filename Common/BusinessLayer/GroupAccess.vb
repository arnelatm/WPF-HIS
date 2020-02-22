' GroupAccess business object
' ** Enterprise Design Pattern: Domain Model, Identity Field, Foreign Key Mapping.
Namespace BusinessLayer

    Public Class GroupAccess
        Inherits AATM.BusinessLayer.BusinessObject

        ' ** Enterprise Design Pattern: Identity field pattern
        Public Sub New()
            ' establish business rules
        End Sub

        Public Property IdNo As Nullable(Of Integer)
        Public Property SecurityGroupIdNo As Nullable(Of Integer)
        Public Property SecurityObjectIdNo As Nullable(Of Integer)
        Public Property SecurityObjectName As String
        Public Property Visible As Boolean
        Public Property Selectable As Boolean
        Public Property Viewable As Boolean
        Public Property Editable As Boolean
        ' ** Enterprise Design Pattern: Foreign Key Mapping. SecurityGroup is the parent
    End Class
End NameSpace