Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IContactDateRangeView

        Inherits IDateRangeView

        ReadOnly Property IdNo As Int32
        Property PersonSelectorControl As Control
        Property PersonSelectorLabel As String
        Property ContactDataSource As Object
        Event ContactDateRangeFormLoaded()

    End Interface

    Public Interface IDateRangeView
        Inherits IView

        Property BeginningDate As Date?
        Property EndingDate As Date?
        ReadOnly Property Language As String
        ReadOnly Property ReportCode As String
        Property UserHasAccess As Boolean
        Property Title As String
        Property NoContact As Boolean
        Event FormLoaded()
        Event PrintButtonClicked()

    End Interface

    Public Interface IDateTimeRangeView
        Inherits IView

        Property BeginningDate As DateTime?
        Property EndingDate As DateTime?
        ReadOnly Property Language As String
        ReadOnly Property ReportCode As String
        Property UserHasAccess As Boolean
        Property Title As String
        Property NoContact As Boolean
        Event FormLoaded()
        Event PrintButtonClicked()

    End Interface

    Public Interface IContactDateTimeRangeView

        Inherits IDateTimeRangeView

        ReadOnly Property IdNo As Int32
        Property PersonSelectorControl As Control
        Property PersonSelectorLabel As String
        Property ContactDataSource As Object
        Event ContactDateRangeFormLoaded()

    End Interface

End Namespace