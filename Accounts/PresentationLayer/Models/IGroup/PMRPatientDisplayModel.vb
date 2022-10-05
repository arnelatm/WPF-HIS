Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PmrPatientDisplayModel

        Public Property [CreateDate] As DateTime
        Public Property [Name] As String
        Public Property [Status] As Boolean
        Public Property [Token] As String
        Public Property PType As String
        Public Property FileNo As String
        Public Property InvType As String

    End Class

End Namespace