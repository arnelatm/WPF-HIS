Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDosageMasterView
        Inherits IView

        Property DosageMasterCode As String
        Property DosageMasterName As String
        Property DosageMasterNameAra As String
        Property IdNo As Int32


    End Interface

    Public Interface IDosageMasterListView
        Inherits IDosageMasterView

        Property DosageMasterList As List(Of IDosageMasterView)
        Event LoadAll(sortKey As String)
        Event SaveCurrent(idNo As Int32, translation As String)

    End Interface



End Namespace