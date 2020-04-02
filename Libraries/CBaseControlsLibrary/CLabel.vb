Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CLabel
    Inherits Label
    Implements IEntryControl

    Private _selectable As Boolean
    Private _editable As Boolean
    Private _editingMode As Boolean
    Private _displayOnly As Boolean

    Public Sub New()
        MyBase.New()
        Dim myFont As New Font("Sans Serif", 10, FontStyle.Regular)
        Text = ""
        TextAlign = ContentAlignment.MiddleLeft
        Font = myFont
        Margin = New Padding(1, 1, 1, 1)
    End Sub

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return False
        End Get
        Set(value As Boolean)
            _editingMode = value
        End Set
    End Property

    Public Property DisplayOnly As Boolean
        Get
            Return True
        End Get
        Set(value As Boolean)
            _displayOnly = True
        End Set
    End Property

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return True
        End Get
    End Property

    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<Description("Set to True to specify that this control value will be shown but masked by <*> .")>
    '<Browsable(True)>
    'Public Property Viewable As Boolean

    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<Description("Set to True to specify that this control can be selected.")>
    '<Browsable(True)>
    'Public Property Selectable As Boolean
    '    Get
    '        Return _selectable
    '    End Get
    '    Set
    '        _selectable = Value
    '        Enabled = Value
    '        Refresh()
    '    End Set
    'End Property

    Public Sub SetText(cText As String)
        Text = cText
    End Sub

End Class