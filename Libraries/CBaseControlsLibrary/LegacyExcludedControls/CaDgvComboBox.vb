Imports System.Windows.Forms

Public Class CaDgvComboBox
    Inherits CaComboBox
    Implements IDataGridViewEditingControl

    Public Sub New()
        MyBase.New()
        'AutoCompleteMode = AutoCompleteMode.None
        DropDownStyle = ComboBoxStyle.DropDown
        AutoCompleteSource = AutoCompleteSource.ListItems
        AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView

    Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return GetValue()
        End Get
        Set(value As Object)
            SetValue(value)
        End Set
    End Property

    Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex

    Private _editingControlValueChanged = False

    Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return _editingControlValueChanged
        End Get
        Set(value As Boolean)
            _editingControlValueChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return Cursor
        End Get
    End Property

    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    'Private Declare Auto Function GetWindow Lib "user32.dll" (
    '    ByVal hWnd As IntPtr,
    '    ByVal wCmd As Int32
    ') As IntPtr

    Public Sub ApplyCellStyleToEditingControl(dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Font = dataGridViewCellStyle.Font
        ForeColor = dataGridViewCellStyle.ForeColor
        BackColor = dataGridViewCellStyle.BackColor
    End Sub

    Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Return False
    End Function

    Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        If (context And DataGridViewDataErrorContexts.Parsing) <> 0 Then
            Return context
        End If
        Return EditingControlFormattedValue
    End Function

    Public Sub PrepareEditingControlForEdit(selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        '
    End Sub

    'Private Sub DataGridViewEarnings_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridViewEarnings.EditingControlShowing
    '    Dim box As ComboBox = TryCast(e.Control, ComboBox)

    '    If box IsNot Nothing Then
    '        box.DropDownStyle = ComboBoxStyle.DropDown
    '        box.AutoCompleteSource = AutoCompleteSource.ListItems
    '        box.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '    End If
    'End Sub

End Class