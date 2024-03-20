Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CComboBoxEditingControl
    Inherits CtComboBox
    Implements IDataGridViewEditingControl

    Private _dataGridView As DataGridView
    Private _valueIsChanged As Boolean = False
    Private _rowIndexNum As Integer
    Private _currentCell As CComboBoxCell = Nothing


    Public Sub New()
        DropDownStyle = ComboBoxStyle.DropDown
        AutoCompleteSource = AutoCompleteSource.ListItems
        AutoCompleteMode = AutoCompleteMode.SuggestAppend
        DisplayMember = Me.DisplayMember
        ValueMember = Me.ValueMember
        EditingMode = True
        DisplayOnly = False
    End Sub

    Public Property OwnerCell() As CComboBoxCell
        Get
            Return _currentCell
        End Get
        Set(ByVal value As CComboBoxCell)
            'Clear currentCell so DoSelectedValueChanged doesn't cause an endless loop
            _currentCell = Nothing
            'Set SelectedIDValue
            MyBase.SelectedValue = value.Value
            'Show that the value hasn't changed yet
            _valueIsChanged = False
            'Finally remember the new Owner Cell
            _currentCell = value
        End Set
    End Property

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.ForeColor = dataGridViewCellStyle.ForeColor
        Me.BackColor = dataGridViewCellStyle.BackColor


    End Sub

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return _dataGridView
        End Get
        Set(ByVal value As DataGridView)
            _dataGridView = value
        End Set
    End Property

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As Object)
            MyBase.Text = value
        End Set
    End Property

    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return _rowIndexNum
        End Get
        Set(ByVal value As Integer)
            _rowIndexNum = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return _valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            _valueIsChanged = value
        End Set
    End Property



    'Public Function EditingCOntrolWantsInputKey()

    'End Function
    'Public Function EditingControlWantsInputKey(ByVal keyData As Keys,
    '    ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
    '    Implements IDataGridViewEditingControl.EditingControlWantsInputKey


    '    Select Case keyData And Keys.KeyCode

    '        Case Keys.Return, Keys.Escape
    '            If DroppedDown Then
    '                Return True
    '            Else
    '                Return dataGridViewWantsInputKey
    '            End If

    '        Case Keys.Left, Keys.Right, Keys.Home, Keys.End
    '            '    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
    '            Return True

    '        Case Keys.PageDown, Keys.PageUp, Keys.Up, Keys.Down
    '            If DroppedDown Then
    '                Return True
    '            Else
    '                Return False
    '            End If

    '        Case Else
    '            Return Not dataGridViewWantsInputKey
    '    End Select
    'End Function

    Public ReadOnly Property EditingPanelCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Public Function GetEditingControlFormattedValue(
        ByVal context As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return MyBase.Text
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        OwnerCell = EditingControlDataGridView.CurrentCell
        'OwnerCell.Value = Me.SelectedValue
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean _
        Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Private Sub DoSelectedValueChanged(ByVal sender As Object,
        ByVal e As System.EventArgs) Handles Me.SelectedValueChanged

        If _currentCell IsNot Nothing Then
            'Remember that the value has changed
            _valueIsChanged = True
            'Pass back the new ID
            '_currentCell.Value = MyBase.SelectedValue
            'Pass back the new display value
            'currentCell.SetDisplayValue(MyBase.Text)
            Text = MyBase.Text
        End If
    End Sub

    Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case keyData And Keys.KeyCode

            Case Keys.Return, Keys.Escape
                If DroppedDown Then
                    Return True
                Else
                    Return dataGridViewWantsInputKey
                End If

            Case Keys.Left, Keys.Right, Keys.Home, Keys.End
                '    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True

            Case Keys.PageDown, Keys.PageUp, Keys.Up, Keys.Down
                If DroppedDown Then
                    Return True
                Else
                    Return False
                End If

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select
    End Function
End Class