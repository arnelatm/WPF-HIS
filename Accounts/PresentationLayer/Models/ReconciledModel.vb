Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ReconciledModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Integer
        Public Property JournalCode As String
        Public Property JournalItemIdNo As Int32
        Public Property ReconciliationIdNo As Integer

    End Class

End Namespace