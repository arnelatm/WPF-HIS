Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class JournalPrefixModel
        Public Property JournalCode As String
        Public Property JournalName As String
        Public Property IdNo As Int16
        Public Property JournalNameAra As String
        Public Property JournalCodeAra As String

    End Class

End Namespace