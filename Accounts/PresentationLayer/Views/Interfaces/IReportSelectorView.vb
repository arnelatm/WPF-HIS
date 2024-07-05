Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportSelectorView
        Inherits IViewNew
        'Inherits IReportViewNew

        Property ReportList As List(Of IReportView)
        Property ReportGroupList As List(Of IReportGroupView)
        Property ReportFileName As String

        Event ReportDoubleClickEvent(reportIdNo As Int16)
        Event ReportGroupClickEvent(reportGroupIdNo As Int16)

    End Interface

End Namespace