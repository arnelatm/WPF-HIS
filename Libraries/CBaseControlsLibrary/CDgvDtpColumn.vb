Imports System.Windows.Forms

Public Class CDgvDtpColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CDgvDtpCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CalendarCell.
            If (value IsNot Nothing) AndAlso
                Not value.GetType().IsAssignableFrom(GetType(CDgvDtpCell)) _
                Then
                Throw New InvalidCastException("Must be a CDgvDtpCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CDgvDtpCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub

    ' You must also override this method to initialize the ComboBox instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the ComboBox instance based on the value of the edited cell
    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer,
        ByVal initialFormattedValue As Object,
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

        ' Set the value of the editing control to the current cell value.
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

        Dim ctl As CDgvDtpEditingControl = CType(DataGridView.EditingControl, CDgvDtpEditingControl)

        ' Make sure you have an instance...
        'If ctl IsNot Nothing Then
        ' Populate the TextBox, passing the instance as a parameter
        ' Set the value of the editing control instance to the current cell value.

        ' Use the default row value when Value property is null.
        If (Me.Value Is Nothing) Then
            ctl.Value = CType(DefaultNewRowValue, DateTime?)
        Else
            Try
                ctl.Value = CType(Me.Value, DateTime?)
            Catch ex As Exception
                ctl.Value = Now()
            End Try
        End If
    End Sub

    ' You must override the EditType property to return the cell's
    ' editing control type, which is your custom control class...
    Public Overrides ReadOnly Property EditType() As Type
        Get
            ' Return the type of the editing control that cDgvDtpCell uses.
            Return GetType(CDgvDtpEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CDgvDtpCell contains.
            Return GetType(DateTime?)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            Return Nothing
        End Get
    End Property

End Class

Public Class CDgvDtpEditingControl
    Inherits CCustomDateTimePicker
    Implements IDataGridViewEditingControl

    Private _valueIsChanged As Boolean = False
    Private _rowIndexNum As Integer
    Private _dataGridViewControl As DataGridView

    Public Sub New()
        'Me. Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            If Text Is Nothing Then
                Return Nothing
            End If
            Return CDate(Me.Text).ToShortDateString()
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is
                ' null, empty, or not in the format of a date.
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                Me.Value = Nothing
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        If Value Is Nothing Then
            Return Nothing
        End If
        Return CDate(Value).ToShortDateString()
        'Dim dateValue As DateTime?
        'Try
        '    dateValue = CDate(Value).ToShortDateString()
        'Catch ex As Exception
        '    Return Nothing
        'End Try
        'Return dateValue
    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        ForeColor = dataGridViewCellStyle.ForeColor
        BackColor = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return _rowIndexNum
        End Get
        Set(ByVal value As Integer)
            _rowIndexNum = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys,
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right,
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return _dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            _dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return _valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            _valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(sender As Object, ByVal eventargs As EventArgs)

        ' Notify the DataGridView that the contents of the cell have changed.
        _valueIsChanged = True
        'Dim dgv As DataGridView = Parent
        If EditingControlDataGridView IsNot Nothing Then
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        End If
        MyBase.OnValueChanged(sender, eventargs)

    End Sub


End Class

'Public Class Form1
'    Inherits Form

'    Private dataGridView1 As New DataGridView()

'    <STAThreadAttribute()> _
'    Public Shared Sub Main()
'        Application.Run(New Form1())
'    End Sub

'    Public Sub New()
'        Me.dataGridView1.Dock = DockStyle.Fill
'        Me.Controls.Add(Me.dataGridView1)
'        Me.Text = "DataGridView calendar column demo"
'    End Sub

'    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) _
'        Handles Me.Load

'        Dim col As New CDgvDtpCalendarColumn()
'        Me.dataGridView1.Columns.Add(col)
'        Me.dataGridView1.RowCount = 5
'        Dim row As DataGridViewRow
'        For Each row In Me.dataGridView1.Rows
'            row.Cells(0).Value = DateTime.Now
'        Next row

'    End Sub

'End Class