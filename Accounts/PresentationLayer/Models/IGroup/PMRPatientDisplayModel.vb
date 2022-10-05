

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PmrPatientDisplayModel

        Public Property [Token] As String
        Public Property [Status] As String
        Public Property [File_No] As String
        Public Property [Name] As String
        Public Property [Type] As String
        Public Property [Inv_Type] As String
        Public Property [CreateDate] As DateTime

    End Class

End Namespace