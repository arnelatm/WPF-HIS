Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class CGroupBox
    Inherits GroupBox

    Private _viewable As Boolean
    Private _selectable As Boolean
    Private _editable As Boolean

    Public Sub New()
        BackColor = Color.Transparent
        AutoSize = True
    End Sub

    Public Overrides Sub Refresh()
        MyBase.Refresh()
        BackColor = Color.Transparent
    End Sub

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this GroupBox cannot be selected or executed.")>
    <Browsable(True)>
    Public Property Selectable As Boolean
        Get
            Return _selectable
        End Get
        Set
            _selectable = Value
            Enabled = Value
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control value will be shown.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean = True

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control value will be shown.")>
    <Browsable(True)>
    Public Property Viewable As Boolean
        Get
            Return _viewable
        End Get
        Set
            _viewable = Value
            Visible = Value
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control value will be shown.")>
    <Browsable(True)>
    Public Property Editable As Boolean
        Get
            Return _editable
        End Get
        Set
            _editable = Value
            Enabled = Value
        End Set
    End Property

End Class
