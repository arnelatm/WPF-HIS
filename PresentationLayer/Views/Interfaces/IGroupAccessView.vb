Namespace Interfaces

    Public Interface IGroupAccessView
        Inherits IView

        Property IdNo As Int32
        Property SecurityGroupIdNo As Int16
        Property SecurityObjectIdNo As Int32
        Property Visible As Boolean
        Property Editable As Boolean
        Property SecurityObjectName() As String

    End Interface

End Namespace