Namespace PresentationLayer.Views
    Public Interface IGroupAccessView

        Property IdNo As Int32
        Property SecurityGroupIdNo As Int32
        Property SecurityObjectIdNo As Int32
        Property Visible As Boolean
        Property Editable As Boolean
        Property SecurityObjectName() As String
        Property Errors As List(Of String)

    End Interface
End NameSpace