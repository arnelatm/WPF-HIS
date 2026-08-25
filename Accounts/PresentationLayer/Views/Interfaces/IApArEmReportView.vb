Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IApArEmReportView
        Inherits IView

        Property BeginningDate As Date?
        Property EndingDate As Date?
        ReadOnly Property Language As String
        ReadOnly Property IdNo As Int32
        ReadOnly Property ReportCode As String
        Property Title As String
        Property UserHasAccess As Boolean
        Property PersonSelectorControl As Control
        Property PersonSelectorLabel As String
        Property NoDates As Boolean
        Event ReportLoaded()
        Event PrintButtonClicked()
        Event LanguageChanged()

    End Interface

End Namespace
