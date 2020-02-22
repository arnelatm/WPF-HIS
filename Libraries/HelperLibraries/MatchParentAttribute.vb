<AttributeUsage(AttributeTargets.[Property])>
Public Class MatchParentAttribute
    Inherits Attribute

    Public ReadOnly ParentPropertyName As String

    Public Sub New(ByVal pParentPropertyName As String)
        ParentPropertyName = pParentPropertyName
    End Sub

End Class