Imports System.Windows.Forms

Public Class CComboBoxCell
    Inherits DataGridViewComboBoxCell

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False
    Private DisplayValue As String = Nothing
    'Public _cellEditingControl As CComboBoxEditingControl


    'Public Sub New()
    '    MyBase.New()
    'End Sub

    'Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As DataGridViewCellStyle)
    '    MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
    '    Debugger.Break()
    '    CellEditingControl = CType(DataGridView.EditingControl, CComboBoxEditingControl)
    '    CellEditingControl.DataSource = DataSource
    '    CellEditingControl.ValueMember = ValueMember
    '    CellEditingControl.DisplayMember = DisplayMember
    '    CellEditingControl.SelectedValue = Value
    '    CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
    '    CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    'End Sub

    'Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
    '    ByVal initialFormattedValue As Object,
    '    ByVal dataGridViewCellStyle As DataGridViewCellStyle)
    '    Debugger.Break()
    '    MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)


    '    'Cast the EditingControl to a variable we can work with
    '    Dim ctl As CComboBoxEditingControl = DirectCast(DataGridView.EditingControl, CComboBoxEditingControl)
    '    'Cast the OwningColumn to a variable we can work with
    '    Dim col As CComboBoxColumn = DirectCast(Me.OwningColumn, CComboBoxColumn)
    '    CellEditingControl = CType(DataGridView.EditingControl, CComboBoxEditingControl)
    '    CellEditingControl.DataSource = col.DataSource
    '    CellEditingControl.ValueMember = col.ValueMember
    '    CellEditingControl.DisplayMember = col.DisplayMember
    '    CellEditingControl.SelectedValue = Value
    '    CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
    '    CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '    ctl.DropDownStyle = ComboBoxStyle.DropDown
    '    ctl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '    ctl.AutoCompleteSource = AutoCompleteSource.ListItems
    'End Sub

    'Private _cellEditingControl As CComboBoxEditingControl

    'Public Property CellEditingControl As CComboBoxEditingControl
    '    Get
    '        Return _cellEditingControl
    '    End Get
    '    Set(value As CComboBoxEditingControl)
    '        _cellEditingControl = value
    '    End Set
    'End Property


    'Friend Sub SetDisplayValue(ByVal NewValue As String)
    '    DisplayValue = NewValue
    'End Sub

    'Public Overrides ReadOnly Property EditType() As Type
    '    Get
    '        ' Return the type of the editing contol that ComboBoxCell uses.
    '        Return GetType(CComboBoxEditingControl)
    '    End Get
    'End Property

    'Public Overrides ReadOnly Property ValueType() As Type
    '    Get
    '        ' Return the type of the value that ComboBoxCell contains.
    '        Return GetType(Long)
    '    End Get
    'End Property

    'Public Overrides ReadOnly Property DefaultNewRowValue() As Object
    '    Get
    '        ' Use DBNull as the default cell value.
    '        Return DBNull.Value
    '    End Get
    'End Property

    'Protected Overrides Sub Paint(ByVal graphics As System.Drawing.Graphics,
    '    ByVal clipBounds As System.Drawing.Rectangle,
    '    ByVal cellBounds As System.Drawing.Rectangle, ByVal rowIndex As Integer,
    '    ByVal cellState As DataGridViewElementStates,
    '    ByVal value As Object, ByVal formattedValue As Object,
    '    ByVal errorText As String, ByVal cellStyle As DataGridViewCellStyle,
    '    ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle,
    '    ByVal paintParts As DataGridViewPaintParts)

    '    'The first time in, make sure that we get the initial DisplayValue
    '    'If DisplayValue Is Nothing Then SetDisplayValue(LookupDisplayValue(value))

    '    'Override paint to pass DisplayValue instead of formattedValue
    '    MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value,
    '        formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts)
    'End Sub

    'Protected Function LookupDisplayValue(value)
    '    'Cast the EditingControl to a variable we can work with
    '    Dim ctl As CComboBoxEditingControl = DirectCast(DataGridView.EditingControl, CComboBoxEditingControl)
    '    ctl.Text = DataSource(RowIndex).Column(1)
    '    'Return Text
    'End Function

End Class






'' This is the class that represents your cell which can use your ComboBox class
'Imports System.ComponentModel
'Imports System.Drawing
'Imports System.Windows.Forms

'Public Class CtComboBoxCell
'    Inherits DataGridViewComboBoxCell

'    Public Sub New()
'        MyBase.New()
'        AutoComplete = True
'        'CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend
'    End Sub

'    ' You must override the EditType property to return the cell's
'    ' editing control type, which is your custom ComboBox class...
'    Public Overrides ReadOnly Property EditType() As Type
'        Get
'            Return GetType(CtComboBoxEditingControl)
'        End Get
'    End Property

'    'You must also override this method To initialize the ComboBox instance...
'    'This method will be called Each time a cell In the column enters edit-mode,
'    'so you can fill the ComboBox instance based On the value Of the edited cell
'    Public Overrides Sub InitializeEditingControl(ByVal initialFormattedValue As Integer, ByVal pFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)


'        MyBase.InitializeEditingControl(RowIndex, initialFormattedValue, dataGridViewCellStyle)

'        ''MyBase.InitializeEditingControl(pRowIndex, pFormattedValue, cellStyle)
'        CellEditingControl = CType(DataGridView.EditingControl, CtComboBoxEditingControl)
'        CellEditingControl.DataSource = DataSource
'        CellEditingControl.ValueMember = ValueMember
'        CellEditingControl.DisplayMember = DisplayMember
'        CellEditingControl.SelectedValue = Value
'        'CellEditingControl.DropDownStyle = ComboBoxStyle.DropDown
'        'CellEditingControl.AutoCompleteMode = AutoCompleteMode.SuggestAppend

'    End Sub

'    '<Bindable(True)>
'    '<Category("Custom Properties")>
'    '<DefaultValue(False)>
'    '<Description("Set to an integer to specify the this will only suggestappend when more than this specified number of characters is typed in.")>
'    '<Browsable(True)>
'    'Public Property SuggestCharCount As Integer

'    Public Property CellEditingControl As CtComboBoxEditingControl
'    '    Get
'    '        Return _cellEditingControl
'    '    End Get
'    '    Set(value As CtComboBoxEditingControl)
'    '        _cellEditingControl = value
'    '    End Set
'    'End Property

'    'Protected Overrides Sub OnMouseClick(ByVal e As DataGridViewCellMouseEventArgs)

'    '    MyBase.OnMouseClick(e)

'    '    If MyBase.DataGridView Is Nothing Then
'    '        Return
'    '    End If

'    '    Dim currentCellAddress As Point = MyBase.DataGridView.CurrentCellAddress

'    '    If currentCellAddress.X = e.ColumnIndex AndAlso currentCellAddress.Y = e.RowIndex Then


'    '    End If
'    'End Sub

'End Class