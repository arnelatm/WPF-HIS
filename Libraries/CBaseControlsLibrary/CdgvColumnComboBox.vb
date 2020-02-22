Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CdgvColumnComboBox
    Inherits DataGridViewComboBoxColumn
    Implements IEntryControl

    Private _editingMode As Boolean
    Private _displayOnly As Boolean

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            _displayOnly = value
            If value Then
                _editingMode = True
            End If
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Or DisplayOnly Then
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                [ReadOnly] = True
            Else
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                [ReadOnly] = False
            End If
        End Set
    End Property

    'Public Sub EnterHandler(sender As Object, e As EventArgs) Handles Me.Enter
    '    If Not _editingMode Then
    '        ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
    '        BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
    '    End If
    'End Sub

    'Public Sub LeaveHandler(sender As Object, e As EventArgs) Handles MyBase.Leave
    '    If Not _editingMode Then
    '        ForeColor = GlobalVariables.DefaultFormControlForegroundColor
    '        BackColor = GlobalVariables.DefaultFormControlBackgroundColor
    '    End If
    'End Sub

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

    'Public Sub MakeEditable(editableControl As Boolean) Implements IEntryControl.MakeEditable
    '    [ReadOnly] = editableControl
    'End Sub

    'Public Sub MakeVisible(visibleControl As Boolean) Implements IEntryControl.MakeVisible
    '    Visible = visibleControl
    'End Sub

    'Public Sub MakeViewable(ViewableControl As Boolean) Implements IEntryControl.MakeViewable
    '    ' not applicable
    'End Sub

    'Public Sub MakeSelectable(selectableControl As Boolean) Implements IEntryControl.MakeSelectable
    '    ' not applicable
    'End Sub
End Class