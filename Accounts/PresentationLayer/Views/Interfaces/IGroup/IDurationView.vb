Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDurationView
        Inherits IView

        Property DurationCode As String
        Property DurationName As String
        Property DurationNameAra As String
        Property IdNo As Int32


    End Interface

    Public Interface IDurationListView
        Inherits IDurationView

        Property DurationList As List(Of IDurationView)
        Event LoadAll(sortKey As String)
        Event SaveCurrent(idNo As Int32, translation As String)

    End Interface



End Namespace