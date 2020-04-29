Namespace PresentationLayer.Models
    Public Class SecurityGroupModel
        Inherits CommonModel

        Public Property ParentIdNo As Int32?
        Public Property SecurityGroupCode As String
        Public Property SecurityGroupName As String
        Public Property SecurityGroupNameAra As String
        Public Property Notes As String
        Public Property GroupAccesses As List(Of GroupAccessModel)

    End Class
End NameSpace