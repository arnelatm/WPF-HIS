Namespace PresentationLayer.Views
    Public Class GroupAccessView
        Implements IGroupAccessView

        Public Property IdNo As Integer Implements IGroupAccessView.IdNo

        Public Property SecurityGroupIdNo As Integer Implements IGroupAccessView.SecurityGroupIdNo

        Public Property SecurityObjectIdNo As Integer Implements IGroupAccessView.SecurityObjectIdNo

        Public Property Visible As Boolean Implements IGroupAccessView.Visible

        Public Property Editable As Boolean Implements IGroupAccessView.Editable

        Public Property SecurityObjectName As String Implements IGroupAccessView.SecurityObjectName

        Public Property Errors As List(Of String) Implements IGroupAccessView.Errors
    End Class
End Namespace