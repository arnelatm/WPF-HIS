Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeDocumentView
        Inherits IView
        Property DocumentIdNo As Int16
        Property DocumentImage As Int32
        Property DocumentNumber As String
        Property EmployeeIdNo As Int32
        Property ExpiryDate As Date?
        Property IdNo As Int32
        Property IssueDate As Date?
        Property Sequence As Int16
    End Interface

End Namespace