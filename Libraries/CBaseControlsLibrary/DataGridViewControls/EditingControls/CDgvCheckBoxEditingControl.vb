Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvCheckBoxEditingControl
    Inherits CCheckBox
    Implements IDataGridViewEditingControl

    Private dataGridView As DataGridView
    Private rowIndex As Integer
    Private _valueChanged As Boolean

    Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridView
        End Get
        Set(value As DataGridView)
            dataGridView = value
        End Set
    End Property

    Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting)
        End Get
        Set(ByVal value As Object)
            MyBase.Checked = value
        End Set
    End Property



    '
    ' Summary:
    '     Gets or sets the index of the owning cell's parent row.
    '
    ' Returns:
    '     The index of the row that contains the owning cell; -1 if there is no owning
    '     row.
    Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndex
        End Get
        Set(ByVal value As Integer)
            rowIndex = value
        End Set
    End Property

    '
    ' Summary:
    '     Retrieves the formatted value of the cell.
    '
    ' Parameters:
    '   context:
    '     A bitwise combination of System.Windows.Forms.DataGridViewDataErrorContexts values
    '     that specifies the data error context.
    '
    ' Returns:
    '     An System.Object that represents the formatted version of the cell contents.
    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Checked
    End Function

    '
    ' Summary:
    '     Gets or sets a value indicating whether the current value of the control has
    '     changed.
    '
    ' Returns:
    '     true if the value of the control has changed; otherwise, false.
    Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return _valueChanged
        End Get
        Set(ByVal value As Boolean)
            _valueChanged = value
        End Set
    End Property


    '
    ' Summary:
    '     Gets the cursor used during editing.
    '
    ' Returns:
    '     A System.Windows.Forms.Cursor that represents the cursor image used by the mouse
    '     pointer during editing.
    Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return Cursors.Default
        End Get
    End Property

    '
    ' Summary:
    '     Gets a value indicating whether the cell contents need to be repositioned whenever
    '     the value changes.
    '
    ' Returns:
    '     false in all cases.
    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    '
    ' Summary:
    '     Initializes a new instance of the System.Windows.Forms.DataGridViewComboBoxEditingControl
    '     class.
    Public Sub New()
        TabStop = False
    End Sub

    'Protected Overrides Function CreateAccessibilityInstance() As AccessibleObject
    '    If AccessibilityImprovements.Level3 Then
    '        Return New DataGridViewComboBoxEditingControlAccessibleObject(Me)
    '    End If

    '    If AccessibilityImprovements.Level2 Then
    '        Return New DataGridViewEditingControlAccessibleObject(Me)
    '    End If

    '    Return MyBase.CreateAccessibilityInstance()
    'End Function

    '
    ' Summary:
    '     Changes the control's user interface (UI) to be consistent with the specified
    '     cell style.
    '
    ' Parameters:
    '   dataGridViewCellStyle:
    '     The System.Windows.Forms.DataGridViewCellStyle to use as a pattern for the UI.
    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        MyBase.Font = dataGridViewCellStyle.Font
        If dataGridViewCellStyle.BackColor.A < Byte.MaxValue Then

            MyBase.BackColor = Color.FromArgb(255, dataGridViewCellStyle.BackColor)
            BackColor = MyBase.BackColor
            dataGridView.EditingPanel.BackColor = BackColor
        Else
            BackColor = dataGridViewCellStyle.BackColor
        End If

        ForeColor = dataGridViewCellStyle.ForeColor
    End Sub


    '
    ' Summary:
    '     Determines whether the specified key is a regular input key that the editing
    '     control should process or a special key that the System.Windows.Forms.DataGridView
    '     should process.
    '
    ' Parameters:
    '   keyData:
    '     A bitwise combination of System.Windows.Forms.Keys values that represents the
    '     key that was pressed.
    '
    '   dataGridViewWantsInputKey:
    '     true to indicate that the System.Windows.Forms.DataGridView control can process
    '     the key; otherwise, false.
    '
    ' Returns:
    '     true if the specified key is a regular input key that should be handled by the
    '     editing control; otherwise, false.

    'Public Function EditingControlWantsInputKey(ByVal keyData As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
    '    If (keyData And Keys.KeyCode) = Keys.Down OrElse (keyData And Keys.KeyCode) = Keys.Up AndAlso (keyData And Keys.KeyCode) = Keys.Escape OrElse (keyData And Keys.KeyCode) = Keys.Return Then
    '        Return True
    '    End If
    '    Return Not dataGridViewWantsInputKey
    '    'Select Case keyData And Keys.KeyCode

    '    '    Case Keys.Return, Keys.Escape
    '    '        If DroppedDown Then
    '    '            Return True
    '    '        Else
    '    '            Return dataGridViewWantsInputKey
    '    '        End If

    '    '    'Case Keys.Left, Keys.Right, Keys.Home, Keys.End
    '    '    '    '    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
    '    '    '    Return True

    '    '    Case Keys.PageDown, Keys.PageUp, Keys.Up, Keys.Down
    '    '        If DroppedDown Then
    '    '            Return True
    '    '        Else
    '    '            Return False
    '    '        End If

    '    '    Case Else
    '    '        Return Not dataGridViewWantsInputKey
    '    '    End Select
    'End Function


    '
    ' Summary:
    '     Prepares the currently selected cell for editing.
    '
    ' Parameters:
    '   selectAll:
    '     true to select all of the cell's content; otherwise, false.
    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        'If selectAll Then
        '    MyBase.SelectAll()
        'End If
        BackColor = GlobalVariables.DefaultFormControlEditingBackgroundColor
        ForeColor = GlobalVariables.DefaultFormControlEditingForegroundColor
        Me.EditingMode = True
    End Sub

    Private Sub NotifyDataGridViewOfValueChange()
        _valueChanged = True
        dataGridView.NotifyCurrentCellDirty(dirty:=True)
    End Sub

    Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        'If (keyData And Keys.KeyCode) = Keys.Down OrElse (keyData And Keys.KeyCode) = Keys.Up AndAlso (keyData And Keys.KeyCode) = Keys.Escape OrElse (keyData And Keys.KeyCode) = Keys.Return Then
        '    Return True
        'End If
        'Return Not dataGridViewWantsInputKey
        Return False
    End Function


End Class