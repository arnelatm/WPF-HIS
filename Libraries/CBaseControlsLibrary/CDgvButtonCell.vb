Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvButtonCell
    Inherits DataGridViewButtonCell
    Implements IEntryControl

    Private _editingMode As Boolean

    Public Sub New()
        Translatable = True
        'If GlobalVariables.RightToLeftLayout Then
        '    Style.Alignment = DataGridViewContentAlignment.MiddleLeft
        'Else
        '    Style.Alignment = DataGridViewContentAlignment.MiddleRight
        'End If
    End Sub

    Public Overrides Function Clone() As Object
        Dim copy As CDgvButtonCell = TryCast(MyBase.Clone(), CDgvButtonCell)
        copy.DisplayOnly = DisplayOnly
        copy.EditingMode = EditingMode
        copy.Translatable = Translatable
        Return copy
    End Function

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

    Public Property Translatable As Boolean Implements IEntryControl.Translatable

End Class