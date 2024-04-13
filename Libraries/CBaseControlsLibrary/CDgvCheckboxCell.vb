Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvCheckboxCell
    Inherits DataGridViewCheckBoxCell
    Implements IEntryControl

    Public Sub New()
        MyBase.New()
    End Sub

    Private _editingMode As Boolean
    Private _translatable As Boolean = False


    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean = False

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set
            If Not AlwaysEditable Then
                _DisplayOnly = Value
                If Value Or DisplayOnly Then
                    Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                    [ReadOnly] = True
                Else
                    Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                    [ReadOnly] = False
                End If
            End If
        End Set
    End Property


    Public Overrides Function Clone() As Object
        Dim copy As CDgvCheckboxCell = TryCast(MyBase.Clone(), CDgvCheckboxCell)
        copy.DisplayOnly = DisplayOnly
        copy.EditingMode = EditingMode
        copy.Translatable = Translatable
        Return copy
    End Function


    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(val As Boolean)
            If Not AlwaysEditable Then
                _editingMode = val
                UpdateDisplayOnlyControl()
            End If
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
            [ReadOnly] = False
        Else
            [ReadOnly] = False
            Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            [ReadOnly] = True
        End If
    End Sub


End Class