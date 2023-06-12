Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IReportSelectorView
        Inherits IReportView

        Property ReportList As List(Of IReportView)

        Event ReportDoubleClickEvent(reportIdNo As Int16)

    End Interface

End Namespace