' This is the class that represents your cell which can use your ComboBox class
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class CtDgvComboBoxCell
    Inherits DataGridViewComboBoxCell

    Public Sub New()
        MyBase.New()
        'AutoComplete = False
        'CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom ComboBox class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CtDgvComboBoxEditingControl)
        End Get
    End Property

    'You must also override this method To initialize the ComboBox instance...
    'This method will be called Each time a cell In the column enters edit-mode,
    'so you can fill the ComboBox instance based On the value Of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal pRowIndex As Integer, ByVal pFormattedValue As Object, ByVal cellStyle As DataGridViewCellStyle)

        'Dim comboBox As ComboBox = TryCast(MyBase.DataGridView.EditingControl, ComboBox)

        'If comboBox IsNot Nothing Then

        '    If (GetInheritedState(RowIndex) And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
        '        'DataGridView.EditingPanel.BackColor = cellStyle.SelectionBackColor
        '    End If

        '    Dim handle As IntPtr

        '    handle = comboBox.Handle
        '    'comboBox.DropDownStyle = ComboBoxStyle.DropDownList
        '    comboBox.FormattingEnabled = True
        '    comboBox.MaxDropDownItems = MaxDropDownItems
        '    comboBox.DropDownWidth = DropDownWidth
        '    comboBox.DataSource = Nothing
        '    comboBox.ValueMember = Nothing
        '    comboBox.Items.Clear()
        '    comboBox.DataSource = DataSource
        '    comboBox.DisplayMember = DisplayMember
        '    comboBox.ValueMember = ValueMember

        '    'If DataSource Is Nothing AndAlso Items.Count > 0 Then
        '    '    comboBox.Items.AddRange(Items.InnerArray.ToArray())
        '    'End If

        '    comboBox.Sorted = Sorted
        '    comboBox.FlatStyle = FlatStyle

        '    'If AutoComplete Then
        '    '    comboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        '    '    comboBox.AutoCompleteMode = AutoCompleteMode.Append
        '    'Else
        '    '    comboBox.AutoCompleteMode = AutoCompleteMode.None
        '    '    comboBox.AutoCompleteSource = AutoCompleteSource.None
        '    'End If

        '    Dim text As String = TryCast(pFormattedValue, String)

        '    If text Is Nothing Then
        '        text = String.Empty
        '    End If

        '    comboBox.Text = text

        '    'If (flags And &H20) = 0 Then
        '    '    AddHandler comboBox.DropDown, ComboBox_DropDown
        '    '    flags = flags Or 32
        '    'End If

        '    'cachedDropDownWidth = -1

        '    CellEditingControl = TryCast(DataGridView.EditingControl, CtDgvComboBoxEditingControl)

        '    'If GetHeight(RowIndex) > 21 Then
        '    '    Dim cellDisplayRectangle As Rectangle = MyBase.DataGridView.GetCellDisplayRectangle(MyBase.ColumnIndex, RowIndex, cutOverflow:=True)
        '    '    cellDisplayRectangle.Y += 21
        '    '    cellDisplayRectangle.Height -= 21
        '    '    MyBase.DataGridView.Invalidate(cellDisplayRectangle)
        '    'End If
        'End If

        MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)
        CellEditingControl = CType(DataGridView.EditingControl, CtDgvComboBoxEditingControl)
        CellEditingControl.Enabled = True
        CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
        CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    '<Bindable(True)>
    '<Category("Custom Properties")>
    '<DefaultValue(False)>
    '<Description("Set to an integer to specify the this will only suggestappend when more than this specified number of characters is typed in.")>
    '<Browsable(True)>
    'Public Property SuggestCharCount As Integer


    Private _cellEditingControl As CtDgvComboBoxEditingControl
    Public Property CellEditingControl As CtDgvComboBoxEditingControl
        Get
            Return _cellEditingControl
        End Get
        Set(value As CtDgvComboBoxEditingControl)
            _cellEditingControl = value
        End Set
    End Property

    Protected Overrides Sub OnMouseClick(ByVal e As DataGridViewCellMouseEventArgs)

        MyBase.OnMouseClick(e)

        If MyBase.DataGridView Is Nothing Then
            Return
        End If

        Dim currentCellAddress As Point = MyBase.DataGridView.CurrentCellAddress

        If currentCellAddress.X = e.ColumnIndex AndAlso currentCellAddress.Y = e.RowIndex Then


        End If
    End Sub

End Class