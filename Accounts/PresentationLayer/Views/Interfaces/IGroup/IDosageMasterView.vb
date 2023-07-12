Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDosageMasterView
        Inherits IView

        Property DosageMasterList As List(Of IDosageMasterDetailView)
        Event LoadAll(sortKey As String)

    End Interface

    Public Interface IDosageMasterDetailView
        Inherits IView

        Property DosageMasterCode As String
        Property DosageMasterName As String
        Property DosageMasterNameAra As String
        Property IdNo As Int32

    End Interface

End Namespace