Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeDocumentView
        Inherits IView
        Property IdNo As Int16
        Property EmployeeIdNo As Int16
        Property DocumentIdNo As Int16
        Property ExpiryDate As Date?
        Property IssueDate As Date?
        Property Number As String
        Property Notes As String
        Property Image As Image
    End Interface

End Namespace