

Namespace PresentationLayer.Models.IGroup

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class PmrPatientDisplayModel

        Public Property [Token] As String
        Public Property [Status] As String
        Public Property [File_No] As String
        Public Property [Name] As String
        Public Property [Type]
        Public Property [Inv_Type]
        Public Property [CreateDate]

    End Class

End Namespace