Imports System.Windows.Forms

Public Class CDgvDtpCalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New CDgvDtpCalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            ' Ensure that the cell used for the template is a CdgvDtpCalendarCell.
            If (value IsNot Nothing) AndAlso
                Not value.GetType().IsAssignableFrom(GetType(CDgvDtpCalendarCell)) _
                Then
                Throw New InvalidCastException("Must be a CDgvDtpCalendarCell")
            End If
            MyBase.CellTemplate = value

        End Set
    End Property

End Class

Public Class CDgvDtpCalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        ' Use the short date format.
        'Me.Style.Format = "d"
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
            ' Return the type of the editing control that CDgvDtpCalendarCell uses.
            Return GetType(CDgvDtpCalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            ' Return the type of the value that CDgvDtpCalendarCell contains.
            Return GetType(DateTime?)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            ' Use the current date and time as the default value.
            'Return DateTime.Now
            Return Nothing
        End Get
    End Property

End Class

Class CDgvDtpCalendarEditingControl
    Inherits CDateTimePickerNullable
    Implements IDataGridViewEditingControl

    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer
    Private dataGridViewControl As DataGridView

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
        Me.ShowCheckBox = True
    End Sub

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

        Get
            Return Me.Value.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            Try
                ' This will throw an exception of the string is
                ' null, empty, or not in the format of a date.
                Me.Value = DateTime.Parse(CStr(value))
            Catch
                ' In the case of an exception, just use the default
                ' value so we're not left with a null value.
                Me.Value = DateTime.Now
            End Try
        End Set

    End Property

    Public Function GetEditingControlFormattedValue(ByVal context _
        As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

        Return Me.Value.ToShortDateString()

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
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
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

        Get
            Return MyBase.Cursor
        End Get

    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        ' Notify the DataGridView that the contents of the cell have changed.
        valueIsChanged = True
        'If Not Checked Then
        '    Value = Nothing
        'End If
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub

End Class