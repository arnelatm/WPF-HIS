Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CdgvCellDecimal
    Inherits DataGridViewTextBoxCell
    Implements IEntryControl

    Private _editingMode As Boolean

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
                Me.ReadOnly = True
            Else
                Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                Me.ReadOnly = False
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

    Public ReadOnly Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
    End Property

End Class