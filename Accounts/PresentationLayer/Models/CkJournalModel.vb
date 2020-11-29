Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class CkJournalModel
        Inherits DisbursementJournalModel

        Public Property CheckDate As Date?
        Public Property CheckNumber As String

    End Class

End Namespace