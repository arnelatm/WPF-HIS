' <summary>
'     The Model in MVP design pattern.
'     Implements IModel and communicates with WCF Service.
' </summary>
Namespace PresentationLayer.Models

    Public Class BranchModel
        Inherits CommonModel

        Public Property BranchCode As String
        Public Property BranchName As String
        Public Property BranchNameAra As String
        Public Property Notes As String
    End Class

End Namespace