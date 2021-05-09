Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvTextCell
    Inherits DataGridViewTextBoxCell
    Implements IEntryControl

    Private _editingMode As Boolean
    Private _displayOnly As Boolean
    Private _translatable As Boolean = False

    Public Overrides Function Clone() As Object
        Dim copy As CDgvTextCell = TryCast(MyBase.Clone(), CDgvTextCell)
        copy.DisplayOnly = DisplayOnly
        copy.Translatable = Translatable
        copy.EditingMode = EditingMode
        Return copy
    End Function

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(val As Boolean)
            _displayOnly = val
            If val Then
                _editingMode = True
            End If
        End Set
    End Property

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control will only accept numeric values.")>
    <Browsable(True)>
    Public Property ValueIsNumeric As Boolean = False

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set
            _editingMode = Value
            If Value Or DisplayOnly Then
                Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                [ReadOnly] = True
            Else
                Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                [ReadOnly] = False
            End If
        End Set
    End Property

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)
            _translatable = value
        End Set
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    Me.ReadOnly = editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    ' not applicable
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    ' not applicable
    'End Sub
End Class