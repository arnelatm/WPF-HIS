Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IAppSettingView
        Inherits IView
        Property IdNo As Int32
        Property AppSettingGroupIdNo As Int16
        Property Selector1IdNo As Int32
        Property Selector2IdNo As Int32
        Property SettingValue As String
        Property LockGroup As Boolean
        Property SavedGroupIdNo As Int16
        Property AppSettingGroupSelector As Int16
        Property Selector1Data As Object
        Property Selector2Data As Object
        WriteOnly Property Selector1Text As String
        WriteOnly Property Selector2Text As String
        Event LockGroupClicked()
        Event FilterRecords()
        Event AppSettingGroupValueChanged(sender As Object)
    End Interface

End Namespace