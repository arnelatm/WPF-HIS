Imports System.ComponentModel
Imports System.Windows.Forms

Public Class EcbComboBoxEditingControl
    Inherits CaComboBox
    Implements IDataGridViewEditingControl

    Private WithEvents _dataGridView As DataGridView
    Private _hasValueChanged As Boolean = False
    Private _rowIndex As Integer

    Private Sub DataGridView1EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles _dataGridView.EditingControlShowing
        If _dataGridView.CurrentCell.IsComboBoxCell Then
            'If _DataGridView.Columns(_DataGridView.CurrentCell.ColumnIndex).Name = "ContactPosition" Then
            Dim cb As ComboBox = TryCast(e.Control, ComboBox)
            RemoveHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
            AddHandler cb.SelectionChangeCommitted, AddressOf _SelectionChangeCommitted
            'End If
        End If
    End Sub

    Private Sub _SelectionChangeCommitted(sender As Object, e As EventArgs)
        Dim comboBox1 = CType(sender, DataGridViewComboBoxEditingControl)
        _dataGridView.CurrentCell.Value = comboBox1.SelectedValue
    End Sub

    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return _dataGridView
        End Get
        Set(ByVal value As DataGridView)
            _dataGridView = value
        End Set
    End Property

    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return _rowIndex
        End Get
        Set(ByVal value As Integer)
            _rowIndex = value
        End Set
    End Property

    'Public Sub New()
    '    'Me.Format = DateTimePickerFormat.Short
    'End Sub

    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            If SelectedValue Is Nothing Then
                Return 0
            Else
                Return SelectedValue
            End If

        End Get
        Set(ByVal value As Object)
            Dim newValue As String = TryCast(value, String)
            If Not newValue Is Nothing Then
                SelectedValue = Integer.Parse(newValue)
            End If
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return EditingControlFormattedValue
    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Font = dataGridViewCellStyle.Font
        ForeColor = dataGridViewCellStyle.ForeColor
        BackColor = dataGridViewCellStyle.BackColor
    End Sub

    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the ComboBox handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Keys.Enter, Keys.Tab
                Return False
            Case Else
                Return False
        End Select
    End Function

    Public Sub OnValidation(ByVal sender As Object, ByVal _
                               e As CancelEventArgs) Handles Me.Validating
        e.Cancel = False
    End Sub

    Private Shadows Sub OnLostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles Me.LostFocus
        If Not Focused Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        SelectedValue = _dataGridView.CurrentCell.Value
        ' No preparation needs to be done.
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public ReadOnly Property EditingPanelCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Public Sub SelectedValueChange() Handles Me.SelectedValueChanged

    End Sub

    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return _hasValueChanged
        End Get
        Set(ByVal value As Boolean)
            _hasValueChanged = True
        End Set
    End Property

    Protected Overrides Sub OnSelectedValueChanged(ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell
        ' have changed

        '_DataGridView.CurrentRow.Cells(_dataGridView.CurrentCell.ColumnIndex).Value = Me.SelectedValue
        _hasValueChanged = True
        EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnSelectedValueChanged(eventargs)
    End Sub

    Private Sub m_ComboBoxColumn_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim comboBox1 = CType(sender, DataGridViewComboBoxEditingControl)
        Dim rowIndex As Integer = comboBox1.EditingControlRowIndex
        _dataGridView.CurrentCell.Value = comboBox1.SelectedValue
    End Sub

End Class