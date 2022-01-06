Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportSelectorView
        Inherits IView
        
        Property IdNo As Int16
        Property QueryForm As String
        Property ReportCode As String
        Property ReportFileName As String
        Property ReportName As String
        Property ReportNameAra As String
        Property ReportTitle As String
        Property ReportTitleAra As String        
        Property ReportList As List(Of IReportView)
        Event ReportDoubleClickEvent(IdNo As Int16)
    End Interface

End Namespace