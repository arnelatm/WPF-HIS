Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeIdListView
        Inherits IView

        Property EmployeeIdList As List(Of EmployeeIdView)

        Event ClearAllEmployee(sender As Object, clear As Boolean)

        'Event EmployeeIdCheckedEvent(sender As Object)

    End Interface

End Namespace