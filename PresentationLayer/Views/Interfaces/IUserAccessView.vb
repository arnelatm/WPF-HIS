Namespace Interfaces

    Public Interface IUserAccessView

        Property Editable As Boolean
        Property Errors As List(Of String)
        Property IdNo As Int32
        Property SecurityObjectIdNo As Int32
        Property SecurityObjectName() As String
        Property UserIdNo As Int16
        Property Visible As Boolean

    End Interface

End Namespace