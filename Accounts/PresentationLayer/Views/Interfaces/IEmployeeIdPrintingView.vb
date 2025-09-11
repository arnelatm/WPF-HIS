Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeIdPrintingView
        Inherits IView

        Property EmployeeIdListView As List(Of IEmployeeView)

        Event EmployeeCheckedEvent(sender As Object)

        Event ClearAllEmployee(sender As Object, clear As Boolean)

    End Interface

End Namespace