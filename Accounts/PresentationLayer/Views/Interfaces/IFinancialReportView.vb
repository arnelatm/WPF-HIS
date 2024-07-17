Imports AATM.PresentationLayer.Views

Public Interface IFinancialReportView
    Inherits IViewNew

    ReadOnly Property BeginningDate As Date?
    ReadOnly Property EndingDate As Date?
    ReadOnly Property Period As String
    Property ZeroBalanceChecked As Boolean
    Property WithZeroBalanceQuery As Boolean
    Property ReportCode As String
    Property Title As String
    Event PrintButtonClicked()
    Event ReportLoaded()
End Interface

