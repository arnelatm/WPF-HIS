Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvDecimalCell
    Inherits DataGridViewTextBoxCell
    Implements IEntryControl

    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    <Bindable(True)>
    <Category("Properties")>
    <DefaultValue(GetType(Boolean))>
    <Description("Set to True to specify that this control is mandatory.")>
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

End Class