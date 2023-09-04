Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportView
        Inherits IView

        Property Active As Boolean
        Property BranchIdNo As Int16
        Property DatabaseName As String
        Property DateCreated As DateTime
        Property IdNo As Int16
        Property PrintJobIdNo As Int16
        Property QueryForm As String
        Property QueryFormParameters As String
        Property QueryParameters As String
        Property ReportCode As String
        Property ReportFileName As String
        Property ReportGroup As String
        Property ReportName As String
        Property ReportNameAra As String
        Property ReportTitle As String
        Property ReportTitleAra As String

    End Interface

End Namespace