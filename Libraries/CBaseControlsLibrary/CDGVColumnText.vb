Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CdgvColumnText
    Inherits DataGridViewTextBoxColumn
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean

    Public Sub New()
        CellTemplate = New CdgvCellText
    End Sub

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
        Set(value As Boolean)
            _displayOnly = value
            If value Then
                _editingMode = True
            End If
        End Set
    End Property

    Public Overrides Function Clone() As Object
        Dim copy As CdgvColumnText = TryCast(MyBase.Clone(), CdgvColumnText)
        copy.DisplayOnly = DisplayOnly
        Return copy
    End Function

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            _editingMode = value
            If value Then
                If DisplayOnly Then
                    Me.ReadOnly = True
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                Else
                    Me.ReadOnly = False
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                    Me.ReadOnly = False
                End If
            Else
                Me.ReadOnly = True
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            End If
        End Set
    End Property

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