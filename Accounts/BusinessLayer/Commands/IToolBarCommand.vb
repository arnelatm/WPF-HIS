Imports System.ComponentModel

Namespace BusinessLayer.Commands

    Public Interface IToolbarCommand
        Inherits INotifyPropertyChanged

        Sub Execute()

        Property IsEnabled As Boolean
        Property Icon As Image
        Property ToolTip As String
        Property ShortcutKey As Keys

    End Interface

End Namespace