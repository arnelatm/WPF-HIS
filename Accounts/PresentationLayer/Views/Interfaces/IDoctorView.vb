Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDoctorView
        Inherits IView
        Property DoctorCode As String
        Property DoctorName As String
        Property DoctorNameAra As String
        Property DateCreated As DateTime?
        Property EmployeeIdNo As Int32
        Property IdNo As Int32
        Property SpecialtyIdNo As Int32

    End Interface

End Namespace