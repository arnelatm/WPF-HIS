
Imports AATM.PresentationLayer.Views

Public Interface IBalanceSheetView
    Inherits IView

    ReadOnly Property BeginningDate As Date?
    ReadOnly Property EndingDate As Date?
    ReadOnly Property Language As String
    ReadOnly Property Period As String
    Event PrintButtonClicked()

End Interface