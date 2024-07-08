Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportSelectorView
        Inherits IViewNew

        Property ReportList As List(Of IReportView)
        Property ReportGroupList As List(Of IReportGroupView)
        Property ReportFileName As String

        Event PrintReportEvent(reportIdNo As Int16)
        Event SelectedReportGroupChangedEvent(ByRef bsReportGroupList As BindingSource, ByRef bsReportList As BindingSource)
        'Event ReportGroupBindingEvent(sender As Object)
        'Event ReportListBindingEvent(sender As Object)
    End Interface

End Namespace