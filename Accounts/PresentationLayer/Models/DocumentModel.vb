Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DocumentModel

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property DocumentCode As String
        Public Property DocumentName As String
        Public Property DocumentNameAra As String
        Public Property DocumentType As String
        Public Property ImageType As String
        Public Property NeedsExpiryDate As Boolean
        Public Property NeedsIssueDate As Boolean
        Public Property NeedsNumber As Boolean
        Public Property Notes As String
    End Class

End Namespace