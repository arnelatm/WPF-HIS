Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDocumentView
        Inherits IView
        Property IdNo As Int16
        Property DocumentCode As String
        Property DocumentName As String
        Property DocumentNameAra As String
        Property DocumentType As String
        Property ImageType As String
        Property NeedsExpiryDate As Boolean
        Property NeedsIssueDate As Boolean
        Property NeedsNumber As Boolean
        Property Notes As String
    End Interface

End Namespace