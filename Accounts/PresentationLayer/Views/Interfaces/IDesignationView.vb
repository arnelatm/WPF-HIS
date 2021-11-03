Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDesignationView
        Inherits IView
        Property IdNo As Int16
        Property DesignationCode As String
        Property DesignationName As String
        Property DesignationNameFemale As String
        Property DesignationNameAra As String
        Property DesignationNameFemaleAra As String
        Property Notes As String
    End Interface

End Namespace