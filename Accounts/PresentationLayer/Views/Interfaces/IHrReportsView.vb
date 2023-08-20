
Imports AATM.PresentationLayer.Views

Public Interface IHrReportsView
    Inherits IView

    ReadOnly Property BeginningDate As Date?
    ReadOnly Property EndingDate As Date?
    ReadOnly Property Language As String
    ReadOnly Property EmployeeIdNo As Int32
    ReadOnly Property ReportName As String
    ReadOnly Property ReportFileName As String
    Property UserHasHrAccess As Boolean
    Property EmployeeSelectorControl As Control
    Event FormLoaded()
    Event PrintButtonClicked()

End Interface