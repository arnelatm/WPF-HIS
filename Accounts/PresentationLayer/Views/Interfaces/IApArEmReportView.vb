Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IApArEmReportView
        Inherits IViewNew

        Property BeginningDate As Date?
        Property EndingDate As Date?
        'ReadOnly Property CultureInfoString As String
        ReadOnly Property IdNo As Int32
        ReadOnly Property ReportCode As String
        Property Title As String
        Property UserHasAccess As Boolean
        Property PersonSelectorControl As Control
        Property PersonSelectorLabel As String
        Property NoDates As Boolean
        Property IdNoData As DataTable
        Event ReportLoaded()
        Event PrintButtonClicked()

    End Interface

    Public Interface IAccountSelector
        Inherits IViewNew

        ReadOnly Property Language As String
        ReadOnly Property IdNo As Int32
        ReadOnly Property ReportCode As String
        Property Title As String
        Property UserHasAccess As Boolean
        Property AccountSelectorControl As Control
        Property IdNoData As DataTable
        Event PostButtonClicked(idNo As Int16)

    End Interface
    Public Interface IReportFormView
        Inherits IViewNew

    End Interface


End Namespace