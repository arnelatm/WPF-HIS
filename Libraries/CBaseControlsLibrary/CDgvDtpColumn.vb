Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvDtpColumn
    Inherits DataGridViewColumn
    Implements IEntryControl

    Private _displayOnly As Boolean
    Private _editingMode As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        CellTemplate = New CDgvDtpCell()
    End Sub

    Public Overrides Function Clone() As Object
        Dim copy As CDgvDtpColumn = TryCast(MyBase.Clone(), CDgvDtpColumn)
        copy.DisplayOnly = DisplayOnly
        copy.EditingMode = EditingMode
        copy.Translatable = Translatable
        Return copy
    End Function

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

    ' ReSharper disable once LocalizableElement
    <DisplayName("DisplayOnly")>
    <Category("Custom Properties")>
    <DefaultValue(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <EditorBrowsable(EditorBrowsableState.Always), Bindable(True)>
    <Description("Set to True to specify that this control's value cannot be edited or changed.")>
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

End Class

Public Class CDgvDtpCell
    Inherits DataGridViewTextBoxCell
    Implements IEntryControl

    Private _editingMode As Boolean
    Private _displayOnly As Boolean
    Private _translatable As Boolean = False

    Public Sub New()
        ' Use the short date format.
        Me.Style.Format = "d"
    End Sub

    ' You must also override this method to initialize the CDgvDtpColumn instance...
    ' This method will be called each time a cell in the column enters edit-mode,
    ' so you can fill the CDgvDtpColumn instance based on the value of the edited cell
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

    Public Property CellEditingControl As CDgvDtpEditingControl

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(val As Boolean)
            _displayOnly = val
            If val Then
                _editingMode = True
            End If
        End Set
    End Property

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

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode
        Get
            Return _editingMode
        End Get
        Set(eValue As Boolean)
            _editingMode = Value
            If eValue Or DisplayOnly Then
                Style.BackColor = GlobalVariables.DefaultFormControlReadOnlyBackgroundColor
                Style.ForeColor = GlobalVariables.DefaultFormControlReadOnlyForegroundColor
                [ReadOnly] = True
            Else
                Style.ForeColor = GlobalVariables.DefaultFormControlForegroundColor
                Style.BackColor = GlobalVariables.DefaultFormControlBackgroundColor
                [ReadOnly] = False
            End If
        End Set
    End Property

    Public Property Translatable As Boolean Implements IEntryControl.Translatable
        Get
            Return False
        End Get
        Set(tValue As Boolean)
            _translatable = tValue
        End Set
    End Property

End Class

Public Class CDgvDtpEditingControl
    Inherits CCustomDateTimePicker
    Implements IDataGridViewEditingControl

    Private _valueIsChanged As Boolean = False
    Private _rowIndexNum As Integer
    Private _dataGridViewControl As DataGridView
    Private _switch As Int32 = 0

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
        Dim efValue As String
        efValue = txtDate.Text
        Dim retVal As String = ""
        Try

            If Not ShowLongDate Then
                If txtDate.Text Is Nothing OrElse txtDate.Text = "" OrElse txtDate.Text.TrimEnd() = EmptyMask Then
                    txtTime.Text = ""
                    txtLongDate.Text = ""
                    retVal = ""
                Else
                    Dim cText As String
                    cText = GlobalFunctions.PadWithZeroSingleDigitDate(DateTime.Parse(txtDate.Text).ToShortDateString())
                    If ShowTime Then
                        cText += " " + txtTime.GetMilitaryTime()
                    End If
                    retVal = Convert.ToDateTime(cText, CalendarCulture)
                End If
            Else
                Dim cText As String
                If txtLongDate.Text Is Nothing OrElse txtLongDate.Text.Trim() = "" Then
                    txtTime.Text = ""
                    txtDate.Text = ""
                    retVal = Nothing
                ElseIf ShowTime Then
                    cText = PadWithZeroSingleDigitDate(DateTime.Parse(txtLongDate.Text).ToShortDateString()) + " " + txtTime.GetMilitaryTime()
                    retVal = Convert.ToDateTime(cText, CalendarCulture)
                Else
                    retVal = Convert.ToDateTime(PadWithZeroSingleDigitDate(DateTime.Parse(txtLongDate.Text).ToShortDateString()), CalendarCulture)
                End If
            End If
            _switch = 0
        Catch ex As Exception
            'PassErrorMessageToGrid()
            retVal = Nothing
        End Try
        Return retVal

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
        DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Me.Font = dataGridViewCellStyle.Font
        ForeColor = dataGridViewCellStyle.ForeColor
        BackColor = dataGridViewCellStyle.BackColor

    End Sub

    Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex

    Public Function EditingControlWantsInputKey(ByVal key As Keys,
        ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

        ' Let the DateTimePicker handle the keys listed.
        Select Case key And Keys.KeyCode

            Case Keys.Enter, Keys.Left, Keys.Right, Keys.Home, Keys.End
                ' Keys.Up, Keys.Down
                '    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                Return True

            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

        Focus()
        If selectAll Then
            If ShowLongDate Then
                txtLongDate.SelectAll()
            Else
                txtDate.InsertKeyMode = InsertKeyMode.Overwrite
                txtDate.SelectAll()
            End If
            Focus()
        End If
        ' No preparation needs to be done.

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

        Get
            Return False
        End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView

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