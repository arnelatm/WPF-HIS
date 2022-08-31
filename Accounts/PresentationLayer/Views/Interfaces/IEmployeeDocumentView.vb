Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeDocumentView
        Inherits IView

        Property Changed As Boolean
        Property DataImageIdNo As Int32
        Property DocumentIdNo As Int16
        Property DocumentNumber As String
        Property EmployeeIdNo As Int32
        Property ExpiryDate As Date?
        Property IdNo As Int32
        Property ImageFileName As String
        Property IssueDate As Date?
        Property Sequence As Int16
    End Interface

End Namespace