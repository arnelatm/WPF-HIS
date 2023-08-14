Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IAppSettingView
        Inherits IView
        Property IdNo As Int32
        Property AppSettingGroupIdNo As Int16
        Property Selector1IdNo As Int32
        Property Selector2IdNo As Int32
        Property LockGroup As Boolean
        Property SavedGroupIdNo As Int16
        Property AppSettingGroupSelector As Int16
        Event LockGroupClicked()
        Event FilterRecords()
    End Interface

End Namespace