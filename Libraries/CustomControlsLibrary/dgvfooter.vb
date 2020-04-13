Imports System.ComponentModel
Imports System.Drawing

'***********************************************************************
'   Author: Heriberto Lugo
'   Website: heribertolugo.com
'   Description: DGVfooter_Basic.
'   A basic pseudo footer for use in a .net datagridview.
'   Please keep these lines in any source files.
'***********************************************************************

Public Class DgvFooter
    Inherits System.Windows.Forms.DataGridView

#Region "Private Class Members"

    ''' <summary>
    ''' Holds our parent DGV, to which DGVfooter is bound to as footer.
    ''' </summary>
    Private WithEvents _parentDGV As DataGridView

    ''' <summary>
    ''' Used to store value as to whether or not to kill our parents RowAddedEvent.
    ''' </summary>
    ''' <remarks>This is used to help do operations which would recursively call our parent's RowAddedEvent. So me must stop the event from being called, and store whether we have done so in this var.</remarks>
    Private _killParentRowAddedEvent As Boolean = False

    Private _killAddColumns As Boolean = True
    Private _killRemoveColumns As Boolean = True

    ''' <summary>
    ''' Whether we perform calculations on columns as data is insrted into cells
    ''' </summary>
    ''' <remarks></remarks>
    Private _autoCalc As Boolean = False

    ''' <summary>
    ''' How many decimal places a double type should display
    ''' </summary>
    ''' <remarks></remarks>
    Private _decimalPlaces As Integer = 2

    ''' <summary>
    ''' The descriptive suffix apended to the end of the totals in footer cells.
    ''' </summary>
    ''' <remarks></remarks>
    Private _valueSuffix As String = ""

    ''' <summary>
    ''' Whether the first footer cell should be a descriptive header cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private _footerHeader As Boolean = False

    ''' <summary>
    ''' The heading in the footer's first cell. Default is "Totals"
    ''' </summary>
    ''' <remarks></remarks>
    Private _footerHeaderText As String = "Totals"

    ''' <summary>
    ''' The backcolor of the first cell in footer if used as header cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private _footerHeaderBackColor As Color = MyBase.DefaultCellStyle.BackColor

    ''' <summary>
    ''' The forecolor of the first cell in footer if used as header cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private _footerHeaderForeColor As Color = Color.Red

    ''' <summary>
    ''' List of columns which are to be summed.
    ''' </summary>
    ''' <remarks></remarks>
    Private _columnsToSum As New List(Of String)

    ''' <summary>
    ''' Rounds the sum upto the decimalPlaces chosen to display
    ''' </summary>
    ''' <remarks></remarks>
    Private _roundSum As Boolean = False

    ''' <summary>
    ''' Whether to use AwayFromZero rounding or ToEven (bankers) rounding.
    ''' </summary>
    ''' <remarks></remarks>
    Private _bankersRounding As Boolean = False

    ''' <summary>
    ''' Column collection for footer.
    ''' </summary>
    ''' <remarks>This columncollection has unique boolean property that must be set whenever columns are manipulated by footer.
    ''' Column manipulation will only occur when this property has been set. This will prevent footer columns from being manipulated by anything other than footer.
    ''' After many trials, it was found columns could be manipulated by simply casting footer into base dgv.
    ''' An override of OnColumnAdded was put to remove column added unless _killAddColumns is set.</remarks>
    Private _fColumns As FooterColumnCollection

#End Region

#Region "Constructor, and initial set-up"

    ''' <summary>
    ''' Contructor
    ''' </summary>
    ''' <param name="parentDGV">DataGridView which we will be bound to as a footer.</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef parentDGV As DataGridView)
        InitLayout()
        Me.Name = parentDGV.Name & "Footer"

        _parentDGV = parentDGV

        SetBaseProperties()

        parentDGV.Controls.Add(Me)

        OnParentRowsAdded(Nothing, Nothing) 'Just incase footer is added to dgv who already contains rows.
    End Sub

    ''' <summary>
    ''' Sets the fundamental properties required for this DGV which acts as a footer row for another DGV
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetBaseProperties()
        MyBase.RowHeadersVisible = False
        MyBase.Height = 22
        MyBase.Width = _parentDGV.Width
        MyBase.AllowUserToAddRows = False
        MyBase.AllowUserToDeleteRows = False
        MyBase.AllowUserToOrderColumns = False
        MyBase.AllowUserToResizeColumns = False
        MyBase.AllowUserToResizeRows = False
        MyBase.ScrollBars = Windows.Forms.ScrollBars.None
        MyBase.DefaultCellStyle.SelectionBackColor = Me._parentDGV.DefaultCellStyle.BackColor
        MyBase.DefaultCellStyle.SelectionForeColor = Me._parentDGV.ForeColor
        MyBase.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Me.Width = Me.Width
        Me.Dock = DockStyle.Bottom
        Me.Show()

        If _parentDGV.ColumnCount > 0 Then
            Me.SetColumns(_parentDGV)
        End If
    End Sub

    ''' <summary>
    ''' Adds corresponding columns to our footer DGV from our parent DGV
    ''' </summary>
    ''' <param name="parentsdgv">The parent/owing datagridview to which this footer is added to.</param>
    ''' <remarks></remarks>
    Public Sub SetColumns(ByVal parentsdgv As DataGridView)

        If _parentDGV.Columns.Count > 0 Then
            _killAddColumns = False

            For Each c As DataGridViewColumn In parentsdgv.Columns

                If Me.Columns.Contains(c.Name & "_footer") Then Continue For

                Dim childCol As New DataGridViewTextBoxColumn
                childCol.Name = c.Name & "_footer"
                childCol.Width = c.Width
                childCol.ReadOnly = True
                childCol.Resizable = DataGridViewTriState.False
                childCol.HeaderText = c.Name

                'Me.Columns.CalledByFooter = True

                MyClass.Columns.Add(childCol)
                MyClass.Columns(c.Index).Frozen = c.Frozen
                MyClass.Columns(c.Index).FillWeight = c.FillWeight

                'SyncBaseColumns()
                If Me.RowCount = 0 Then Me.Rows.Add()

                If AutoCalc Then
                    ColumnToSum(c.Name) = True
                End If
            Next

            MyClass.RowHeadersVisible = _parentDGV.RowHeadersVisible
            MyClass.ColumnHeadersVisible = False

            _killAddColumns = True
        End If
    End Sub

#End Region

#Region "Event Handler Overrides"

    ''' <summary>
    ''' Processing that needs to be done when a new row is added
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>When a new row is added (which is the only row to ever be added) the following will happen:
    ''' First cell text and text color set if headercell option is used.
    ''' First cell de-selected, so no cells are selected.
    ''' Footer is set to be uneditable.</remarks>
    Protected Overrides Sub OnRowsAdded(e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        If Me.RowCount > 1 Then
            Me.Rows.RemoveAt(Me.Rows.Count - 1)
            Exit Sub
        End If

        SetHeader()

        MyBase.OnRowsAdded(e)
        MyClass.SelectionMode = DataGridViewSelectionMode.CellSelect
        MyClass.ClearSelection()
        MyClass.CurrentCell = MyBase.Rows(0).Cells(0)
        MyClass.Rows(0).Cells(0).Selected = False
        MyClass.Enabled = False
        MyClass.ReadOnly = True
    End Sub

    ''' <summary>
    ''' Processing that needs to be done when a new column is added
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>If a column is added by outside manipulation (anyone other that footer), the column is removed..</remarks>
    Protected Overrides Sub OnColumnAdded(e As System.Windows.Forms.DataGridViewColumnEventArgs)
        If Not _killAddColumns Then
            MyBase.OnColumnAdded(e)
        Else
            'Check to see if form is closing
            Dim parentForm As Form = Me.FindForm
            If Not IsNothing(parentForm) Then
                'Remove any columns not inserted by our footer class.
                MyBase.Columns.Remove(e.Column)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Processing that needs to be done when a column is removed
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>If a column is removed by outside manipulation (anyone other that footer), the column is re-inserted..</remarks>
    Protected Overrides Sub OnColumnRemoved(e As System.Windows.Forms.DataGridViewColumnEventArgs)
        If Not _killRemoveColumns Then
            MyBase.OnColumnRemoved(e)
        Else
            'Check to see if form is closing
            Dim parentForm As Form = Me.FindForm
            If Not IsNothing(parentForm) Then
                'Re-Add any column removed by outside manipulation.
                MyBase.Columns.Insert(e.Column.Index, e.Column)
            End If
        End If
    End Sub

#End Region

#Region "Handle events from parent"

    ''' <summary>
    ''' Tallies the cell entries made in parent DGV to the footer cells in the corresponding column
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Only columns of texboxcolumn type will be totalled.</remarks>
    Private Sub ParentValChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles _parentDGV.CellEndEdit
        If Not _autoCalc Then Exit Sub
        Dim curColumnName As String = _parentDGV.Columns(e.ColumnIndex).Name
        Dim columnAddable As Boolean = Me._columnsToSum.Contains(curColumnName)

        'If _parentDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).GetType.Name = "DataGridViewTextBoxCell" And columnAddable Then
        If columnAddable Then
            SumColumn(curColumnName)
        End If
    End Sub

    ''' <summary>
    ''' Tallies the cell entries made in parent DGV to the footer cells in the corresponding column
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Only columns of texboxcolumn type will be totalled.</remarks>
    Private Sub ParentValChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles _parentDGV.RowsRemoved
        If Not _autoCalc Then Exit Sub
        For Each c As DataGridViewColumn In CType(sender, DataGridView).Columns.OfType(Of DataGridViewTextBoxColumn)()
            Dim columnAddable As Boolean = Me._columnsToSum.Contains(c.Name)
            If Not columnAddable Then Continue For

            SumColumn(c.Name)
        Next
        CheckParentVScrollBar()
    End Sub

    ''' <summary>
    ''' Performs needed maintenance and bug fixes.
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>When the control gets populated with rows to the point where a scrollbar appears, the newly added rows tend to hide behind footer.
    ''' As a fix, we add another row and hide it. When another row is added, a hidden row is deleted.
    ''' To prevent a recursive call when we add a hidden row, we set a sentinel to determine whether we will proceed with hidden row processes.</remarks>
    Private Sub OnParentRowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles _parentDGV.RowsAdded

        If _parentDGV.Rows.Count < 1 Then Exit Sub

        Dim rowY As Integer = (_parentDGV.Rows.Count + 1) * _parentDGV.Rows(0).Height
        Dim footY As Integer = _parentDGV.Controls(Me.Name).Top

        If _parentDGV.Rows.Count = 1 Then
            Me.SetColumns(_parentDGV)
            'Me.Rows.Add()
        End If

        If rowY >= footY And Not Me._killParentRowAddedEvent Then

            Me._killParentRowAddedEvent = True

            For Each dgvr As DataGridViewRow In _parentDGV.Rows
                If dgvr.Tag Is Nothing Then Continue For
                If dgvr.Tag.ToString = "spacer" Then _parentDGV.Rows.Remove(dgvr)
            Next

            _parentDGV.Rows.Add(SpacerRow)

            _parentDGV.FirstDisplayedScrollingRowIndex = _parentDGV.Rows.Count - 2

            Me._killParentRowAddedEvent = False
        End If
        CheckParentVScrollBar()
    End Sub

    ''' <summary>
    ''' Resizes footer columns to match _parentDGV columns.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReSizeCol() Handles _parentDGV.ColumnWidthChanged
        If Me.Rows.Count < 1 Then Exit Sub
        If Me.Columns.Count < 1 Then Exit Sub
        If _parentDGV.Rows.Count < 1 Then Exit Sub
        If _parentDGV.Columns.Count < 1 Then Exit Sub
        For Each c As DataGridViewColumn In _parentDGV.Columns
            Me.Columns(c.Index).Width = c.Width
        Next
    End Sub

    ''' <summary>
    ''' Adds columns when columns are added to parent DGV.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>This will actually call the same Sub which is called during instantiation.</remarks>
    Private Sub ResetColumns(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles _parentDGV.ColumnAdded
        SetColumns(_parentDGV)

        If ColumnsOverflow() Then
            _parentDGV.Size = New Size(_parentDGV.Size.Width + 1, _parentDGV.Size.Height + 1)
            _parentDGV.Size = New Size(_parentDGV.Size.Width - 1, _parentDGV.Size.Height - 1)
        End If
    End Sub

    ''' <summary>
    ''' Removes our corresponding (footer) column, when parent DGV has a column removed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RemoveColumns(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles _parentDGV.ColumnRemoved
        _killRemoveColumns = False
        ColumnToSum(e.Column.Name) = False
        Me.Columns.Remove(e.Column.Name & "_footer")
        If e.Column.DisplayIndex = 0 And Me.Columns.Count > 0 And UseHeader Then SetHeader()
        _killRemoveColumns = True
    End Sub

    ''' <summary>
    ''' Synchronizes the scrolling of parent DGV to the footer row.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ScrollMe(ByVal sender As Object, ByVal e As EventArgs) Handles _parentDGV.Scroll
        Me.HorizontalScrollingOffset = _parentDGV.HorizontalScrollingOffset
    End Sub

    ''' <summary>
    ''' Keeps the footers columns order ensync with corresponding columns in parent.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShiftColumns(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles _parentDGV.ColumnDisplayIndexChanged
        Me.Columns(e.Column.Name & "_footer").DisplayIndex = e.Column.DisplayIndex
    End Sub

    ''' <summary>
    ''' Keeps the footers columns name ensync with corresponding columns in parent.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChangeName(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles _parentDGV.ColumnNameChanged
        Me.Columns(e.Column.DisplayIndex).Name = e.Column.Name & "_footer"
    End Sub

    ''' <summary>
    ''' Keeps the footers built in standard row header width ensync with parent's built in standard row header.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ResizeRowHeader(ByVal sender As Object, ByVal e As EventArgs) Handles _parentDGV.RowHeadersWidthChanged
        Me.RowHeadersWidth = _parentDGV.RowHeadersWidth
    End Sub

#End Region

#Region "Methods and Sub-Procedures"

    ''' <summary>
    ''' Attempts to add the values in all the cells in a column in parent, and then displays the total in footer column corresponding to parent column.
    ''' </summary>
    ''' <param name="columnName">Name of column in parent which to try and sum all cell values of.</param>
    ''' <remarks>If a cell value cannot be parsed to double, no error will be thrown. That cell will be skipped.</remarks>
    Public Sub SumColumn(ByVal columnName As String)
        Dim tally As Double = 0.0
        Dim nfi As Globalization.NumberFormatInfo = New Globalization.CultureInfo("en-US", False).NumberFormat
        Dim cVal As String

        For Each r As DataGridViewRow In _parentDGV.Rows
            cVal = CStr(r.Cells(columnName).Value)
            tally += If(Double.TryParse(cVal, Nothing), CDbl(cVal), 0)
        Next

        nfi.NumberDecimalDigits = _decimalPlaces
        tally = If(_roundSum, Math.Round(tally, _decimalPlaces, If(_bankersRounding, MidpointRounding.ToEven, MidpointRounding.AwayFromZero)), TruncateToDecimalPlace(tally, _decimalPlaces))

        MyClass.Rows(0).Cells(columnName & "_footer").Value = tally.ToString("N", nfi) & " " & _valueSuffix
    End Sub

    ''' <summary>
    ''' Attempts to add the values in all the cells in all columns in parent, and then displays the total in footer column corresponding to parent column.
    ''' </summary>
    ''' <remarks>If a cell value cannot be parsed to double, no error will be thrown. That cell will be skipped.</remarks>
    Public Sub SumAllColumns()
        For Each c As String In _columnsToSum
            SumColumn(c)
        Next
    End Sub

    Public Sub SetText(columnName As String, columnText As String)
        MyClass.Rows(0).Cells(columnName & "_footer").Value = columnText
    End Sub

    ''' <summary>
    ''' Checks whether _parentDGV has scrollbar visible or not, and sets the width of the footer row accordingly.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckParentVScrollBar()
        Dim DGVVerticalScroll As VScrollBar = _parentDGV.Controls.OfType(Of VScrollBar).SingleOrDefault

        If DGVVerticalScroll.Visible Then
            Me.Width = _parentDGV.Width + DGVVerticalScroll.Width
        Else
            Me.Width = _parentDGV.Width
        End If

    End Sub

    ''' <summary>
    ''' Sets the display properties for footer header cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetHeader()
        If Not Me._footerHeader Then Exit Sub
        If Me.RowCount < 1 Then Exit Sub

        Dim s As New DataGridViewCellStyle
        s.ForeColor = _footerHeaderForeColor
        s.BackColor = _footerHeaderBackColor
        s.SelectionBackColor = _footerHeaderBackColor
        s.SelectionForeColor = _footerHeaderForeColor
        s.Font = New Font(MyBase.DefaultCellStyle.Font.FontFamily, MyBase.DefaultCellStyle.Font.Size, FontStyle.Bold)

        Me.Rows(0).Cells(0).Style = s

        Me.Rows(0).Cells(0).Value = _footerHeaderText
        MyBase.Rows(0).Cells(0).Style.ForeColor = _footerHeaderForeColor
        MyBase.Rows(0).Cells(0).Style.BackColor = _footerHeaderBackColor
    End Sub

    ''' <summary>
    ''' Sets the display properties for footer header cell to match the rest of the footer formatting.
    ''' </summary>
    ''' <remarks>This is used when footer header is being disabled</remarks>
    Private Sub UnSetHeader()
        Console.WriteLine(Me._footerHeader)
        If Me._footerHeader Then Exit Sub
        If Me.RowCount < 1 Then Exit Sub

        Dim s As New DataGridViewCellStyle(Me.DefaultCellStyle)

        Me.Rows(0).Cells(0).Style = s

        MyBase.Rows(0).Cells(0).Style.ForeColor = s.ForeColor
        MyBase.Rows(0).Cells(0).Style.BackColor = s.BackColor
    End Sub

    ''' <summary>
    ''' Synchronizes the columncollection between our footer class and base class.
    ''' </summary>
    ''' <remarks>Since using a custom columncollection for footer, the base class for footer never gets updated with column. As a result, even though me.columns.count and
    ''' myclass.columns.count both return the value for our column collection, whenever a row is attempted to get added an exception will occur for adding rows without columns.
    ''' This happenes even if we used me.rows.add or myclass.rows.add. Which honestly makes no sense to me, since both of those return a valid column count.
    ''' So we add a column by same name to mybase, so we can get our row. I could not find any other way around this. Unless we change mybase.columncount to match, but then
    ''' event handlers are triggered, and they receive a column with an empty name.</remarks>
    Private Sub SyncBaseColumns()
        For Each c As DataGridViewColumn In _fColumns
            MyBase.Columns.Add(c.Name, c.HeaderText)
        Next
    End Sub

    ''' <summary>
    ''' Returns a datagridviewrow for use as spacer row.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SpacerRow() As DataGridViewRow
        Dim sRow As New DataGridViewRow

        sRow.DefaultCellStyle.BackColor = _parentDGV.BackgroundColor
        sRow.Tag = "spacer"
        sRow.DefaultCellStyle.SelectionBackColor = _parentDGV.BackgroundColor
        sRow.ReadOnly = True
        sRow.Height = Me.Height + 2

        Return sRow
    End Function

    ''' <summary>
    ''' Checks whether the total columns width will display a horizontal scrollbar.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ColumnsOverflow() As Boolean
        Dim colSpace As Integer = 0

        For Each col As DataGridViewColumn In _parentDGV.Columns
            colSpace += col.Width
        Next

        If _parentDGV.RowHeadersVisible Then colSpace += _parentDGV.RowHeadersWidth

        Return colSpace > _parentDGV.ClientSize.Width

    End Function

    'static double[] pow10 = { 1e0, 1e1, 1e2, 1e3, 1e4, 1e5, 1e6, 1e7, 1e8, 1e9, 1e10 };
    Private ReadOnly pow10 As Double() = {1.0, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, 10000000.0, 100000000.0, 1000000000.0, 10000000000.0}

    ''' <summary>
    ''' Truncates a decimal number to specified decimal places without rounding.
    ''' </summary>
    ''' <param name="NumToTruncate"></param>
    ''' <param name="DecimalPlaces"></param>
    ''' <returns>A double truncated to the specified decimal places.</returns>
    ''' <remarks>Function provided by Glenn Slayden (http://stackoverflow.com/users/147511/glenn-slayden) on http://stackoverflow.com/questions/329957/truncate-decimal-number-not-round-off</remarks>
    Private Function TruncateToDecimalPlace(ByVal NumToTruncate As Double, ByVal DecimalPlaces As Integer) As Double
        If DecimalPlaces < 0 Then Throw New ArgumentException()
        If DecimalPlaces = 0 Then Return Math.Truncate(NumToTruncate)

        Dim m As Double = If(DecimalPlaces >= pow10.Length, Math.Pow(10, DecimalPlaces), pow10(DecimalPlaces))
        Return Math.Truncate(NumToTruncate * m) / m
    End Function

#End Region

#Region "Properties"

    ''' <summary>
    ''' If set to true, footer will autosum the columns in parent datagridview
    ''' </summary>
    ''' <value>A boolean indicating whether footer should autosum parent dgv columns.</value>
    ''' <returns>True if set to autocalc. Otherwise false.</returns>
    ''' <remarks>If this is set to false after footer has already sumed columns, the values will not be removed from footer.
    ''' But no further autosum will be performed.</remarks>
    Public Property AutoCalc As Boolean
        Get
            Return _autoCalc
        End Get
        Set(value As Boolean)
            _autoCalc = value

            SumAllColumns()
        End Set
    End Property

    ''' <summary>
    ''' The descriptive suffix apended to the end of the totals in footer cells.
    ''' </summary>
    ''' <value>String to be used as the descriptive suffix apended to the end of the totals in footer cells.</value>
    ''' <returns>The descriptive suffix apended to the end of the totals in footer cells.</returns>
    ''' <remarks></remarks>
    Public Property ValueSuffix As String
        Get
            Return _valueSuffix
        End Get
        Set(value As String)
            _valueSuffix = value

            SumAllColumns()
        End Set
    End Property

    ''' <summary>
    ''' Whether the first footer cell should be a descriptive header cell.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseHeader As Boolean
        Get
            Return _footerHeader
        End Get
        Set(value As Boolean)
            _footerHeader = value

            If Me.Columns.Count > 0 Then

                ColumnToSum(0) = Not value

                If Me.RowCount > 0 Then
                    SumAllColumns()

                    If value Then
                        SetHeader()
                    Else
                        UnSetHeader()
                    End If
                End If
            End If

        End Set
    End Property

    ''' <summary>
    ''' The heading in the footer's header cell. Default is "Totals"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HeaderText As String
        Get
            Return _footerHeaderText
        End Get
        Set(value As String)
            _footerHeaderText = value
            SetHeader()
        End Set
    End Property

    ''' <summary>
    ''' The backcolor for the header cell.
    ''' </summary>
    ''' <value>A color for which to set the header backcolor to.</value>
    ''' <returns>A color which corresponds to the backcolor for the header cell.</returns>
    ''' <remarks></remarks>
    Public Property HeaderBackColor As Color
        Get
            Return _footerHeaderBackColor
        End Get
        Set(value As Color)
            _footerHeaderBackColor = value
            SetHeader()
        End Set
    End Property

    ''' <summary>
    ''' The forecolor for the header cell.
    ''' </summary>
    ''' <value>A color for which to set the header forecolor to.</value>
    ''' <returns>A color which corresponds to the forecolor for the header cell.</returns>
    Public Property HeaderForeColor As Color
        Get
            Return _footerHeaderForeColor
        End Get
        Set(value As Color)
            _footerHeaderForeColor = value
            SetHeader()
        End Set
    End Property

    ''' <summary>
    ''' How many decimal places will the values displayed have.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DecimalPlaces As Integer
        Get
            Return _decimalPlaces
        End Get
        Set(value As Integer)
            _decimalPlaces = value

            SumAllColumns()
        End Set
    End Property

    ''' <summary>
    ''' Value indicating whether the column in parent dgv will be totalled.
    ''' </summary>
    ''' <param name="columnName">The name of a column in parent dgv.</param>
    ''' <value>Boolean indicating whether column will be totalled.</value>
    ''' <returns>Boolean indicating whether column will be totalled.</returns>
    ''' <remarks></remarks>
    Public Property ColumnToSum(ByVal columnName As String) As Boolean
        Get
            'If the _columnsToSum contains the name of column, then that column will be totaled.
            Return _columnsToSum.Contains(columnName)
        End Get
        Set(value As Boolean)
            If Me.Columns.Count < 1 Then Exit Property
            If _parentDGV.Columns.Count > 0 Then
                If UseHeader And _parentDGV.Columns(0).Name = columnName Then value = False
            End If

            If value Then
                'If we are setting a column to be totaled, and it is not in _columnsToSum list, we must add it - so it can be totaled.
                If Not _columnsToSum.Contains(columnName) Then
                    'Insert the column we are setting to be totaled.
                    _columnsToSum.Add(columnName)

                    SumColumn(columnName)
                End If
            Else
                'If we are setting a column to not be totaled, and it is in _columnsToSum lsit, we must remove it - so it can not be totaled.
                If _columnsToSum.Contains(columnName) Then
                    _columnsToSum.Remove(columnName)
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Value indicating whether the column in parent dgv will be totalled.
    ''' </summary>
    ''' <param name="columnIndex">The index of a column in parent dgv.</param>
    ''' <value>Boolean indicating whether column will be totalled.</value>
    ''' <returns>Boolean indicating whether column will be totalled.</returns>
    ''' <remarks></remarks>
    Public Property ColumnToSum(ByVal columnIndex As Integer) As Boolean
        'Lets be a little lazy/smart and just call this property using the name.
        'We could just perform needed actions using the index, but im sure we are getting a displayindex number, and not the actual index.
        'So to be safe, we will get the name from the index passed and call the property using columnName instead.
        'Besides this avoids recoding the same exact thing more than once, just to use index rather than columnName.
        Get
            Dim columnName As String = Me._parentDGV.Columns(columnIndex).Name
            Return ColumnToSum(columnName)
        End Get
        Set(value As Boolean)
            Dim columnName As String = Me._parentDGV.Columns(columnIndex).Name
            ColumnToSum(columnName) = value
        End Set
    End Property

    ''' <summary>
    ''' Whether to round the totals displayed in footer.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RoundSum As Boolean
        Get
            Return _roundSum
        End Get
        Set(value As Boolean)
            _roundSum = value

            SumAllColumns()
        End Set
    End Property

    ''' <summary>
    ''' Whether to use "bankers" rounding when rounding the totals in footer.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>If true When a number is halfway between two others, it is rounded toward the nearest even number.
    ''' For example: 2.5 would round off to 2.
    ''' If false When a number is halfway between two others, it is rounded toward the nearest number that is away from zero.
    ''' For example: 2.5 would round off to 3.</remarks>
    Public Property BankersRounding As Boolean
        Get
            Return _bankersRounding
        End Get
        Set(value As Boolean)
            _bankersRounding = value

            SumAllColumns()
        End Set
    End Property

    ''' <summary>
    ''' Gets the value of the footer cell as a double.
    ''' </summary>
    ''' <param name="columnName">The name of the column in the parent datagridview to which get the corresponding value from in footer.</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Will return 0 if value is not a number</remarks>
    Public ReadOnly Property Value(ByVal columnName As String) As Double
        Get
            Dim cVal As String = CStr(Me.Rows(0).Cells(columnName & "_footer").Value)
            Dim rVal As Double = 0
            cVal = If(cVal.IndexOf(_valueSuffix) > 0, cVal.Substring(0, cVal.IndexOf(_valueSuffix) - 1).Trim, cVal.Trim)

            Double.TryParse(cVal, rVal)

            Return rVal
        End Get
    End Property

    ''' <summary>
    ''' Gets the value of the footer cell as a double.
    ''' </summary>
    ''' <param name="columnIndex">The index of the column in the parent datagridview to which get the corresponding value from in footer.</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Value(ByVal columnIndex As Integer) As Double
        Get
            Return Value(_parentDGV.Columns(columnIndex).Name)
        End Get
    End Property

#End Region

#Region "Hidden Overridden Properties"

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Overrides Property Dock As System.Windows.Forms.DockStyle
        Get
            Return MyBase.Dock
        End Get
        Set(value As System.Windows.Forms.DockStyle)
            MyBase.Dock = DockStyle.Bottom
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property RowHeadersVisible As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)
            MyBase.RowHeadersVisible = value
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property ColumnHeadersVisible As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)
            MyBase.ColumnHeadersVisible = False
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AllowUserToOrderColumns As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)

        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AllowUserToResizeColumns As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)

        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AllowUserToResizeRows As Boolean
        Get
            Return False
        End Get
        Set(value As Boolean)

        End Set
    End Property

    '<Browsable(False)> _
    '<EditorBrowsable(EditorBrowsableState.Never)>
    'Public Shadows ReadOnly Property Columns As FooterColumnCollection
    '    Get
    '        If IsNothing(Me._fColumns) Then
    '            Return MyClass.CreateColumnsInstance
    '        Else
    '            Return MyClass._fColumns
    '        End If

    '    End Get
    'End Property

    '<Browsable(False)> _
    '<EditorBrowsable(EditorBrowsableState.Never)>
    'Protected Shadows Function CreateColumnsInstance() As FooterColumnCollection
    '    MyBase.CreateColumnsInstance()
    '    _fColumns = New FooterColumnCollection(Me)
    '    Return _fColumns
    'End Function

#End Region

End Class

Public Class FooterColumnCollection
    Inherits DataGridViewColumnCollection

    Private _calledByFooter As Boolean = False
    Private _parent As DataGridView

    Public Sub New(ByRef dgv As DataGridView)
        MyBase.New(dgv)
        _parent = dgv
    End Sub

    '<Browsable(False)> _
    '<EditorBrowsable(EditorBrowsableState.Never)>
    Public Property CalledByFooter As Boolean
        Set(value As Boolean)
            _calledByFooter = value
        End Set
        Get
            Return _calledByFooter
        End Get
    End Property

    Public Overrides Function Add(columnName As String, headerText As String) As Integer
        If _calledByFooter Then
            _calledByFooter = False
            Return MyBase.Add(columnName, headerText)
        Else
            Return -1
        End If
    End Function

    Public Overrides Function Add(dataGridViewColumn As System.Windows.Forms.DataGridViewColumn) As Integer
        If _calledByFooter Then
            _calledByFooter = False
            Return MyBase.Add(dataGridViewColumn)
        Else
            Return -1
        End If
    End Function

    Public Overrides Sub AddRange(ParamArray dataGridViewColumns() As System.Windows.Forms.DataGridViewColumn)
        If _calledByFooter Then
            _calledByFooter = False
            MyBase.AddRange(dataGridViewColumns)
        End If
    End Sub

    Public Overrides Sub Clear()
        MyBase.Clear()
    End Sub

    Public Overrides Sub Insert(columnIndex As Integer, dataGridViewColumn As System.Windows.Forms.DataGridViewColumn)
        If _calledByFooter Then
            _calledByFooter = False
            MyBase.Insert(columnIndex, dataGridViewColumn)
        End If
    End Sub

    Public Overrides Sub Remove(columnName As String)
        If _calledByFooter Then
            _calledByFooter = False
            MyBase.Remove(columnName)
        End If
    End Sub

    Public Overrides Sub Remove(dataGridViewColumn As System.Windows.Forms.DataGridViewColumn)
        If _calledByFooter Then
            _calledByFooter = False
            MyBase.Remove(dataGridViewColumn)
        End If
    End Sub

    Public Overrides Sub RemoveAt(index As Integer)
        If _calledByFooter Then
            _calledByFooter = False
            MyBase.RemoveAt(index)
        End If
    End Sub

End Class