Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IEmployeeIdView
        Inherits IView
        Property EmployeeName As String
        Property IdNo As Int32
        Property NationalIdNo As String
        Property Picture As Image
        Property Print As Boolean

    End Interface

End Namespace