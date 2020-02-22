

' <summary>
'     The Model in MVP design pattern.
'     Implements IModel and communicates with WCF Service.
' </summary>
Namespace PresentationLayer.Models
    Public Class BranchModel
        Public Property IdNo As Integer
        Public Property BranchCode As String
        Public Property BranchName As String
        Public Property BranchNameAra As String
        Public Property Notes As String
    End Class
End NameSpace