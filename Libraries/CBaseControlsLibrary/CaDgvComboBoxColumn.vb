Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CaDgvComboBoxColumn
    Inherits DataGridViewComboBoxColumn
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        AutoComplete = False
        CellTemplate = New CaDgvComboboxCell
    End Sub

    'Public Overrides Function Clone() As Object
    '    Dim copy As CaDgvComboboxCell = TryCast(MyBase.Clone(), CaDgvComboboxCell)
    '    If copy Is Nothing Then
    '        copy.DisplayOnly = DisplayOnly
    '        copy.Translatable = Translatable
    '        copy.EditingMode = EditingMode
    '    End If
    '    Return copy
    'End Function

    <Bindable(True)>
    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is for DisplayOnly.")>
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
            If value Then
                If DisplayOnly Then
                    [ReadOnly] = True
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                Else
                    [ReadOnly] = False
                    DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                    DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                    [ReadOnly] = False
                End If
            Else
                [ReadOnly] = True
                DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
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

    'Public Property LinkedLabel As CLabel Implements IEntryControl.LinkedLabel

    'Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements IEntryControl.GetControlDescription
    '    Dim description As String
    '    If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
    '        description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
    '    Else
    '        description = LinkedLabel.Text
    '    End If
    '    Return description
    'End Function

End Class