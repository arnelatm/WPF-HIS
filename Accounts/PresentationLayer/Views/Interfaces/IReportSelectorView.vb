Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportSelectorView
        Inherits IReportView

        Property ReportList As List(Of IReportView)
        Property ReportGroupList As List(Of IReportGroupView)

        Event ReportDoubleClickEvent(reportIdNo As Int16)
        Event ReportGroupDoubleClickEvent(reportGroupIdNo As Int16)

    End Interface

End Namespace