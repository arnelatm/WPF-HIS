Public Interface IEntryControl
    Property EditingMode As Boolean
    Property Translatable As Boolean

    'Sub MakeViewable(ByVal ViewableControl As Boolean)
    'Sub MakeEditable(ByVal editableControl As Boolean)
    'Sub MakeSelectable(ByVal selectableControl As Boolean)
    'Sub MakeVisible(ByVal visibleControl As Boolean)
End Interface

Public Interface ILinkedLabel

    Property LinkedLabel As CLabel

    Function GetControlDescription(Optional description As String = Nothing)

End Interface