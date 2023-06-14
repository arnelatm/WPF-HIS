Imports AATM.PresentationLayer.Views

Public Interface IPrintReportView
    Inherits AATM.PresentationLayer.Views.IView

    Event PrintReport(reportFileName As String, pDatabaseConnectionName As String, args As Object, copies As Integer)

End Interface

Public Interface IPrintReport

    Event PrintReport(reportFileName As String, pDatabaseConnectionName As String, args As Object, copies As Integer)

End Interface