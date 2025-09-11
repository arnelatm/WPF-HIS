Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDocumentDetailView
        Inherits IView

        Property Active As Boolean
        Property BranchIdNo As Int16
        Property BranchName As String
        Property ContactType As String
        Property DataImageIdNo As Int32
        Property DocumentIdNo As Int16
        Property DocumentNumber As String
        Property ContactIdNo As Int32
        Property ExpiryDate As Date?
        Property IdNo As Int32
        Property IssueDate As Date?
        Property DateCreated As Date
        Property UserIdNo As Int16
        Property UserName As String
        Property ContactIdControl As Control
        Property ContactIdDataName As String
        Property ShowContactIdSelector As Boolean
        Property ContactDescription As String
        Property ImageFileName As String
        Property Changed As Boolean
        Property Picture As Image
        Event AddNewDocumentType()
        Event DocumentTypeChanged()
        Event LookupNeedsUpdate()
        Event FilterRecords()
    End Interface

End Namespace