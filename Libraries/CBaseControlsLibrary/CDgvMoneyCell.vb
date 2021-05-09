Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvMoneyCell
    Inherits DataGridViewTextBoxCell
    Implements IEntryControl

    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is display only.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean = False

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set
            _editingMode = Value
            If Value Or DisplayOnly Then
                Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                [ReadOnly] = True
            Else
                Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                [ReadOnly] = False
            End If
        End Set
    End Property

    Sub New()
        If GlobalVariables.RightToLeftLayout Then
            Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        Else
            Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End If

    End Sub

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