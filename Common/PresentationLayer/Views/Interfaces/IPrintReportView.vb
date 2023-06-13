Imports AATM.PresentationLayer.Views

Public Interface IPrintReportView
    Inherits IView

    Event OnPrintReport(reportFileName As String, pDatabaseConnectionName As String, args As Object, copies As Integer)

End Interface
