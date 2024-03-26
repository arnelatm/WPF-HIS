Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CtComboBoxColumn
    Inherits DataGridViewComboBoxColumn
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        '' Specify the column to use your custom cell class...
        CellTemplate = New CtComboBoxCell()
        AutoComplete = False
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            Dim dataGridViewComboBoxCell As CtComboBoxCell = TryCast(value, CtComboBoxCell)
            If value IsNot Nothing AndAlso dataGridViewComboBoxCell Is Nothing Then
                Throw New InvalidCastException("Must be a CtComboBoxCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property

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
                _editingMode = False
            End If
        End Set
    End Property

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(value As Boolean)
            If _displayOnly Then
                _editingMode = False
            Else
                _editingMode = value
            End If
            UpdateDisplayOnlyControl()
        End Set
    End Property

    Public Sub UpdateDisplayOnlyControl()
        If _editingMode And Not DisplayOnly Then
            [ReadOnly] = False
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
        Else
            [ReadOnly] = False
            DefaultCellStyle.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
            DefaultCellStyle.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
            [ReadOnly] = True
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

    Public Property SuggestCharCount As Integer

    'Public Overrides Function Clone() As Object
    '    Dim copy As CtComboBoxColumn = TryCast(MyBase.Clone(), CtComboBoxColumn)
    '    'copy.DisplayOnly = DisplayOnly
    '    'copy.EditingMode = EditingMode
    '    'copy.Translatable = Translatable
    '    Return copy
    'End Function

End Class