Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportSelectorView
        Inherits IViewNew

        Property ReportList As List(Of IReportView)
        Property ReportGroupList As List(Of IReportGroupView)
        Property ReportFileName As String

        Event PrintReportEvent(bsReportList As BindingSource)
        Event SelectedReportGroupChangedEvent(ByRef bsReportGroupList As BindingSource, ByRef bsReportList As BindingSource)

    End Interface

End Namespace