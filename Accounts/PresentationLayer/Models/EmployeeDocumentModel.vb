Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class EmployeeDocumentModel
        Public Property IdNo As Int16
        Public Property EmployeeIdNo As Int32
        Public Property DocumentIdNo As Int16
        Public Property DocumentNumber As Int16
        Public Property ExpiryDate As Date?
        Public Property IssueDate As Date?
        Public Property Number As String
        Public Property Notes As String
        Public Property DocumentImage As Int32
        Public Property Sequence As Int16
    End Class

End Namespace