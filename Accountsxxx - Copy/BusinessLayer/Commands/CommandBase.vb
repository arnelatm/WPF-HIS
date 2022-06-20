Imports System.ComponentModel
Imports AATM.Accounts.BusinessLayer.Commands

Namespace Commands

    Friend MustInherit Class CommandBase
        Implements IToolbarCommand

        Private f_IsEnabled As Boolean
        Private f_Icon As Image
        Private f_ToolTip As String

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Protected Sub New()
            f_IsEnabled = True
        End Sub

        Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
            Dim handler As PropertyChangedEventHandler = PropertyChangedEvent
            If handler IsNot Nothing Then handler(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        Public MustOverride Sub Execute() Implements IToolbarCommand.Execute

        Public Property IsEnabled As Boolean Implements IToolbarCommand.IsEnabled
            Get
                Return f_IsEnabled
            End Get
            Set(ByVal value As Boolean)

                If f_IsEnabled <> value Then
                    f_IsEnabled = value
                    OnPropertyChanged("IsEnabled")
                End If
            End Set
        End Property

        Public Property Icon As Image Implements IToolbarCommand.Icon
            Get
                Return f_Icon
            End Get
            Set(ByVal value As Image)

                If f_Icon IsNot value Then
                    f_Icon = value
                    OnPropertyChanged("Icon")
                End If
            End Set
        End Property

        Public Property ToolTip As String Implements IToolbarCommand.ToolTip
            Get
                Return f_ToolTip
            End Get
            Set(ByVal value As String)

                If Not Equals(f_ToolTip, value) Then
                    f_ToolTip = value
                    OnPropertyChanged("ToolTip")
                End If
            End Set
        End Property

        Public Property ShortcutKey As Keys Implements IToolbarCommand.ShortcutKey
    End Class

End Namespace