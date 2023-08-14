Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvCheckboxCell
    Inherits DataGridViewCheckBoxCell
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean

    Public Overrides Function Clone() As Object
        Dim copy As CDgvCheckboxCell = TryCast(MyBase.Clone(), CDgvCheckboxCell)
        copy.DisplayOnly = DisplayOnly
        copy.EditingMode = EditingMode
        copy.Translatable = Translatable
        Return copy
    End Function


    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is always editable.")>
    Public Property AlwaysEditable As Boolean = False


    ' ReSharper disable once LocalizableElement
    <DisplayName("DisplayOnly")>
    <Category("Custom Properties")>
    <DefaultValue(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <EditorBrowsable(EditorBrowsableState.Always), Bindable(True)>
    <Description("Set to True to specify that this control's value cannot be edited or changed.")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set
            If Not AlwaysEditable Then
                _displayOnly = Value
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

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(value As Boolean)

        End Set
    End Property

End Class