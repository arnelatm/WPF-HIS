Namespace Interfaces

    Public Interface IUserAccessView

        Property IdNo As Int32
        Property UserIdNo As Int16
        Property SecurityObjectIdNo As Int32
        Property Visible As Boolean
        Property Editable As Boolean
        Property SecurityObjectName() As String
        Property Errors As List(Of String)

    End Interface

End Namespace