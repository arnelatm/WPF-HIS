Imports AATM.Presentation.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IItemCodeView
        Inherits IView
        Property IdNo As Int32
        Property ItemCodeCode As String
        Property ItemCodeName As String
        Property ItemCodeNameAra As String
        Property CodeGroupIdNo As Int16
        Property Note As String
        Property LockGroup As Boolean
        Property SavedGroupIdNo As Int16
        Property CodeGroupSelector As Int16
        Event LockGroupClicked()
        Event FilterRecords()
    End Interface

End Namespace