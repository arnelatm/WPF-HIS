Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class DocumentDetailModel

        Public Property Active As Boolean
        Public Property Changed As Boolean
        Public Property DataImageIdNo As Int32
        Public Property DocumentIdNo As Int16
        Public Property DocumentNumber As String
        Public Property ContactIdNo As Int32
        Public Property ExpiryDate As Date?
        Public Property IdNo As Int32
        Public Property ImageFileName As String
        Public Property IssueDate As Date?
        Public Property DateCreated As Date
        Public Property UserIdNo As Int16
        Public Property Picture As Image
    End Class

End Namespace