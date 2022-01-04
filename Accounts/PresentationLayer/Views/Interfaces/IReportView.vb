Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportView
        Inherits IView
        Property IdNo As Int16
        Property QueryForm As String
        Property ReportCode As String
        Property ReportName As String
        Property ReportNameAra As String
        Property ReportTitle As String
        Property ReportTitleAra As String
    End Interface

End Namespace