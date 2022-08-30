Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeDocumentModel
        Public Property DataImageIdNo As Int32
        Public Property DocumentIdNo As Int16
        Public Property DocumentNumber As String
        Public Property EmployeeIdNo As Int32
        Public Property ExpiryDate As Date?
        Public Property IdNo As Int32
        Public Property ImageFileName As String
        Public Property IssueDate As Date?
        Public Property Sequence As Int16
    End Class

End Namespace