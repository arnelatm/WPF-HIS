Imports AATM.PresentationLayer.Views

Public Interface IFinancialReportView
    Inherits IView

    ReadOnly Property BeginningDate As Date?
    ReadOnly Property EndingDate As Date?
    ReadOnly Property Language As String
    ReadOnly Property Period As String
    Property ZeroBalanceChecked As Boolean
    Property WithZeroBalanceQuery As Boolean
    Property ReportCode As String
    Property Title As String
    Event PrintButtonClicked()
    Event ReportLoaded()
End Interface
