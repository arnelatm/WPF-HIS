Imports AATM.PresentationLayer.Views

Public Interface IPrintReportView
    Inherits AATM.PresentationLayer.Views.IView

    Event PrintReport(reportFileName As String, pDatabaseConnectionName As String, args As Object, copies As Integer)
    'Event GetLanguageAndCo(ByVal sender As Object, ByVal formCulture As String, ByRef language As String, ByRef establishmentName As String, ByRef reportTitle As String)
    'Event GetLanguageAndCo(ByRef language As String, ByRef establishmentName As String)
    'Event GetStandardData()

End Interface


Public Interface IReportPrinterView
    Inherits AATM.PresentationLayer.Views.IView

    Property FileName As String
    Property ReportTitle As String
    Property FormCultureLanguage As String
    Property Args As Object()
    Property DataBaseConnectionName As String
    Property Copies As Int32

    Event PrintReport(ByVal sender As IReportPrinterView)
    'Event PrintReport(ByVal sender As IPrintReportView)
    'Event GetLanguageAndCo(ByRef language As String, ByRef establishmentName As String)
    'Event GetStandardData()

End Interface

Public Interface IPrintReport

    Event PrintReportNew(reportFileName As String, pDatabaseConnectionName As String, args As Object, copies As Integer)

End Interface