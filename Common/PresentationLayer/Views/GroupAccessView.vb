Namespace PresentationLayer.Views
    Public Class GroupAccessView
        Implements IGroupAccessView

        Public Property IdNo As Int32 Implements IGroupAccessView.IdNo

        Public Property SecurityGroupIdNo As Int32 Implements IGroupAccessView.SecurityGroupIdNo

        Public Property SecurityObjectIdNo As Int32 Implements IGroupAccessView.SecurityObjectIdNo

        Public Property Visible As Boolean Implements IGroupAccessView.Visible

        Public Property Editable As Boolean Implements IGroupAccessView.Editable

        Public Property SecurityObjectName As String Implements IGroupAccessView.SecurityObjectName

        Public Property Errors As List(Of String) Implements IGroupAccessView.Errors
    End Class
End Namespace