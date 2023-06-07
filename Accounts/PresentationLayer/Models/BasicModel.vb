Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class BasicModel

        Public Property BranchIdNo As Int16
        Public Property Code As String
        Public Property Errors As List(Of String)
        Public Property IdNo As Int32
        Public Property Name As String
        Public Property NameAra As String
        Public Property Notes As String

    End Class

End Namespace