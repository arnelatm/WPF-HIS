Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

'***********************************************************************
'   Author: Heriberto Lugo
'   Website: heribertolugo.com
'   Description: DGVfooter_Basic.
'   A basic pseudo footer for use in a .net datagridview.
'   Please keep these lines in any source files.
'***********************************************************************

Public Class DgvFooter
    Inherits DataGridView

#Region "Private Class Members"

    ''' <summary>
    ''' Holds our parent DGV, to which DGVfooter is bound to as footer.
    ''' </summary>
    Private WithEvents _parentDgv As DataGridView

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
    Private _footerHeaderBackColor As Color = DefaultCellStyle.BackColor

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
    ''' Rounds the sum up to the decimalPlaces chosen to display
    ''' </summary>
    ''' <remarks></remarks>
    Private _roundSum As Boolean = True

    ''' <summary>
    ''' Whether to use AwayFromZero rounding or ToEven (bankers) rounding.
    ''' </summary>
    ''' <remarks></remarks>
    Private _bankersRounding As Boolean = False

    ''' <summary>
    ''' Column collection for footer.
    ''' </summary>
    ''' <remarks>This columnCollection has unique boolean property that must be set whenever columns are manipulated by footer.
    ''' Column manipulation will only occur when this property has been set. This will prevent footer columns from being manipulated by anything other than footer.
    ''' After many trials, it was found columns could be manipulated by simply casting footer into base dgv.
    ''' An override of OnColumnAdded was put to remove column added unless _killAddColumns is set.</remarks>
    Private _fColumns As FooterColumnCollection

#End Region

#Region "Constructor, and initial set-up"

    ''' <summary>
    ''' Contructor
    ''' </summary>
    ''' <param name="parentDgv">DataGridView which we will be bound to as a footer.</param>
    ''' <remarks></remarks>
    Public Sub New(ByRef parentDgv As DataGridView)
        InitLayout()
        Name = parentDgv.Name & "Footer"

        _parentDgv = parentDgv

        SetBaseProperties()

        parentDgv.Controls.Add(Me)

        OnParentRowsAdded(Nothing, Nothing) 'Just incase footer is added to dgv who already contains rows.
    End Sub

    ''' <summary>
    ''' Sets the fundamental properties required for this DGV which acts as a footer row for another DGV
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetBaseProperties()
        MyBase.RowHeadersVisible = False
        Height = 22
        Width = _parentDgv.Width
        AllowUserToAddRows = False
        AllowUserToDeleteRows = False
        AllowUserToOrderColumns = False
        AllowUserToResizeColumns = False
        AllowUserToResizeRows = False
        ScrollBars = ScrollBars.None
        DefaultCellStyle.SelectionBackColor = _parentDgv.DefaultCellStyle.BackColor
        DefaultCellStyle.SelectionForeColor = _parentDgv.ForeColor
        DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Width = Width
        Dock = DockStyle.Bottom
        Show()

        If _parentDgv.ColumnCount > 0 Then
            SetColumns(_parentDgv)
        End If
    End Sub

    ''' <summary>
    ''' Adds corresponding columns to our footer DGV from our parent DGV
    ''' </summary>
    ''' <param name="parentsdgv">The parent/owing datagridview to which this footer is added to.</param>
    ''' <remarks></remarks>
    Public Sub SetColumns(ByVal parentsdgv As DataGridView)

        If _parentDgv.Columns.Count > 0 Then
            _killAddColumns = False

            For Each c As DataGridViewColumn In parentsdgv.Columns

                If Columns.Contains(c.Name & "_footer") Then Continue For

                Dim childCol As New DataGridViewTextBoxColumn
                childCol.Name = c.Name & "_footer"
                childCol.Width = c.Width
                childCol.ReadOnly = True
                childCol.Resizable = DataGridViewTriState.False
                childCol.HeaderText = c.Name

                'Columns.CalledByFooter = True

                Columns.Add(childCol)
                Columns(c.Index).Frozen = c.Frozen
                Columns(c.Index).FillWeight = c.FillWeight

                'SyncBaseColumns()
                If RowCount = 0 Then Rows.Add()

                If AutoCalc Then
                    ColumnToSum(c.Name) = True
                End If
            Next

            RowHeadersVisible = _parentDgv.RowHeadersVisible
            ColumnHeadersVisible = False

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
    Protected Overrides Sub OnRowsAdded(e As DataGridViewRowsAddedEventArgs)
        If RowCount > 1 Then
            Rows.RemoveAt(Rows.Count - 1)
            Exit Sub
        End If

        SetHeader()

        MyBase.OnRowsAdded(e)
        SelectionMode = DataGridViewSelectionMode.CellSelect
        ClearSelection()
        CurrentCell = Rows(0).Cells(0)
        Rows(0).Cells(0).Selected = False
        Enabled = False
        MyClass.ReadOnly = True
    End Sub

    ''' <summary>
    ''' Processing that needs to be done when a new column is added
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>If a column is added by outside manipulation (anyone other that footer), the column is removed..</remarks>
    Protected Overrides Sub OnColumnAdded(e As DataGridViewColumnEventArgs)
        If Not _killAddColumns Then
            MyBase.OnColumnAdded(e)
        Else
            'Check to see if form is closing
            Dim parentForm As Form = FindForm()

            If Not IsNothing(parentForm) Then
                'Remove any columns not inserted by our footer class.
                Columns.Remove(e.Column)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Processing that needs to be done when a column is removed
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>If a column is removed by outside manipulation (anyone other that footer), the column is re-inserted..</remarks>
    Protected Overrides Sub OnColumnRemoved(e As DataGridViewColumnEventArgs)
        If Not _killRemoveColumns Then
            MyBase.OnColumnRemoved(e)
        Else
            'Check to see if form is closing
            Dim parentForm As Form = FindForm()

            If Not IsNothing(parentForm) Then
                'Re-Add any column removed by outside manipulation.
                Columns.Insert(e.Column.Index, e.Column)
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
    Private Sub ParentValChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles _parentDgv.CellEndEdit
        If Not _autoCalc Then Exit Sub
        Dim curColumnName As String = _parentDgv.Columns(e.ColumnIndex).Name
        Dim columnAddable As Boolean = _columnsToSum.Contains(curColumnName)

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
    Private Sub ParentValChanged(ByVal sender As Object, ByVal e As DataGridViewRowsRemovedEventArgs) Handles _parentDgv.RowsRemoved
        If Not _autoCalc Then Exit Sub
        For Each c As DataGridViewColumn In CType(sender, DataGridView).Columns.OfType(Of DataGridViewTextBoxColumn)()
            Dim columnAddable As Boolean = _columnsToSum.Contains(c.Name)
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
    Private Sub OnParentRowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles _parentDgv.RowsAdded

        If _parentDgv.Rows.Count < 1 Then Exit Sub

        Dim rowY As Integer = (_parentDgv.Rows.Count + 1) * _parentDgv.Rows(0).Height
        Dim footY As Integer = _parentDgv.Controls(Name).Top

        If _parentDgv.Rows.Count = 1 Then
            SetColumns(_parentDgv)
            'Rows.Add()
        End If

        If rowY >= footY And Not _killParentRowAddedEvent Then

            _killParentRowAddedEvent = True

            For Each dgvr As DataGridViewRow In _parentDgv.Rows
                If dgvr.Tag Is Nothing Then Continue For
                If dgvr.Tag.ToString = "spacer" Then _parentDgv.Rows.Remove(dgvr)
            Next

            '_parentDGV.Rows.Add(SpacerRow)

            _parentDgv.FirstDisplayedScrollingRowIndex = _parentDgv.Rows.Count - 2

            _killParentRowAddedEvent = False
        End If
        CheckParentVScrollBar()
    End Sub

    ''' <summary>
    ''' Resizes footer columns to match _parentDGV columns.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReSizeCol() Handles _parentDgv.ColumnWidthChanged
        If Rows.Count < 1 Then Exit Sub
        If Columns.Count < 1 Then Exit Sub
        If _parentDgv.Rows.Count < 1 Then Exit Sub
        If _parentDgv.Columns.Count < 1 Then Exit Sub
        For Each c As DataGridViewColumn In _parentDgv.Columns
            Columns(c.Index).Width = c.Width
        Next
    End Sub

    ''' <summary>
    ''' Adds columns when columns are added to parent DGV.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>This will actually call the same Sub which is called during instantiation.</remarks>
    Private Sub ResetColumns(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles _parentDgv.ColumnAdded
        SetColumns(_parentDgv)

        If ColumnsOverflow() Then
            _parentDgv.Size = New Size(_parentDgv.Size.Width + 1, _parentDgv.Size.Height + 1)
            _parentDgv.Size = New Size(_parentDgv.Size.Width - 1, _parentDgv.Size.Height - 1)
        End If
    End Sub

    ''' <summary>
    ''' Removes our corresponding (footer) column, when parent DGV has a column removed.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RemoveColumns(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles _parentDgv.ColumnRemoved
        _killRemoveColumns = False
        ColumnToSum(e.Column.Name) = False
        Columns.Remove(e.Column.Name & "_footer")
        If e.Column.DisplayIndex = 0 And Columns.Count > 0 And UseHeader Then SetHeader()
        _killRemoveColumns = True
    End Sub

    ''' <summary>
    ''' Synchronizes the scrolling of parent DGV to the footer row.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ScrollMe(ByVal sender As Object, ByVal e As EventArgs) Handles _parentDgv.Scroll
        HorizontalScrollingOffset = _parentDgv.HorizontalScrollingOffset
    End Sub

    ''' <summary>
    ''' Keeps the footers columns order ensync with corresponding columns in parent.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ShiftColumns(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles _parentDgv.ColumnDisplayIndexChanged
        Columns(e.Column.Name & "_footer").DisplayIndex = e.Column.DisplayIndex
    End Sub

    ''' <summary>
    ''' Keeps the footers columns name ensync with corresponding columns in parent.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ChangeName(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles _parentDgv.ColumnNameChanged
        Columns(e.Column.DisplayIndex).Name = e.Column.Name & "_footer"
    End Sub

    ''' <summary>
    ''' Keeps the footers built in standard row header width ensync with parent's built in standard row header.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ResizeRowHeader(ByVal sender As Object, ByVal e As EventArgs) Handles _parentDgv.RowHeadersWidthChanged
        RowHeadersWidth = _parentDgv.RowHeadersWidth
    End Sub

#End Region

#Region "Methods and Sub-Procedures"

    ''' <summary>
    ''' Attempts to add the values in all the cells in a column in parent, and then displays the total in footer column corresponding to parent column.
    ''' </summary>
    ''' <param name="columnName">Name of column in parent which to try and sum all cell values of.</param>
    ''' <remarks>If a cell value cannot be parsed to double, no error will be thrown. That cell will be skipped.</remarks>
    Public Sub SumColumn(ByVal columnName As String)
        If Not String.IsNullOrEmpty(columnName) Then
            Dim tally As Double = 0.00D
            Dim nfi As NumberFormatInfo = New CultureInfo("en-US", False).NumberFormat
            Dim cVal As String

            For Each r As DataGridViewRow In _parentDgv.Rows
                If Not String.IsNullOrEmpty(columnName) Then
                    cVal = CStr(r.Cells(columnName).Value)
                    tally += If(Double.TryParse(cVal, Nothing), CDbl(cVal), 0)
                End If
            Next

            nfi.NumberDecimalDigits = _decimalPlaces
            tally = If(_roundSum, Math.Round(tally, _decimalPlaces, If(_bankersRounding, MidpointRounding.ToEven, MidpointRounding.AwayFromZero)), TruncateToDecimalPlace(tally, _decimalPlaces))

            Rows(0).Cells(columnName & "_footer").Value = tally.ToString("N", nfi) & " " & _valueSuffix
        End If
    End Sub

    Public Function GetColumnTotal(ByVal ColumnName As String)
        SumColumn(ColumnName)
        Return Rows(0).Cells(ColumnName & "_footer").Value
    End Function

    ''' <summary>
    ''' Attempts to add the values in all the cells in all columns in parent, and then displays the total in footer column corresponding to parent column.
    ''' </summary>
    ''' <remarks>If a cell value cannot be parsed to double, no error will be thrown. That cell will be skipped.</remarks>
    Public Sub CalculateTotals()
        For Each c As String In _columnsToSum
            SumColumn(c)
        Next
    End Sub

    Public Sub SetText(columnName As String, columnText As String)
        Rows(0).Cells(columnName & "_footer").Value = columnText
    End Sub

    Public Sub SetTextAuto(columnName As String, columnText As String)
        Rows(0).Cells(columnName).Value = columnText
    End Sub

    Public Sub SetAlignment(columnName As String, colAlignment As ContentAlignment)
        Columns(columnName & "_footer").DefaultCellStyle.Alignment = colAlignment
    End Sub

    ''' <summary>
    ''' Checks whether _parentDGV has scrollbar visible or not, and sets the width of the footer row accordingly.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckParentVScrollBar()
        Dim dgvVerticalScroll As VScrollBar = _parentDgv.Controls.OfType(Of VScrollBar).SingleOrDefault

        If dgvVerticalScroll.Visible Then
            Width = _parentDgv.Width + dgvVerticalScroll.Width
        Else
            Width = _parentDgv.Width
        End If

    End Sub

    ''' <summary>
    ''' Sets the display properties for footer header cell.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetHeader()
        If Not _footerHeader Then Exit Sub
        If RowCount < 1 Then Exit Sub

        Dim s As New DataGridViewCellStyle
        s.ForeColor = _footerHeaderForeColor
        s.BackColor = _footerHeaderBackColor
        s.SelectionBackColor = _footerHeaderBackColor
        s.SelectionForeColor = _footerHeaderForeColor
        s.Font = New Font(DefaultCellStyle.Font.FontFamily, DefaultCellStyle.Font.Size, FontStyle.Bold)

        Rows(0).Cells(0).Style = s

        Rows(0).Cells(0).Value = _footerHeaderText
        Rows(0).Cells(0).Style.ForeColor = _footerHeaderForeColor
        Rows(0).Cells(0).Style.BackColor = _footerHeaderBackColor
    End Sub

    ''' <summary>
    ''' Sets the display properties for footer header cell to match the rest of the footer formatting.
    ''' </summary>
    ''' <remarks>This is used when footer header is being disabled</remarks>
    Private Sub UnSetHeader()
        Console.WriteLine(_footerHeader)
        If _footerHeader Then Exit Sub
        If RowCount < 1 Then Exit Sub

        Dim s As New DataGridViewCellStyle(DefaultCellStyle)

        Rows(0).Cells(0).Style = s

        Rows(0).Cells(0).Style.ForeColor = s.ForeColor
        Rows(0).Cells(0).Style.BackColor = s.BackColor
    End Sub

    ''' <summary>
    ''' Synchronizes the columncollection between our footer class and base class.
    ''' </summary>
    ''' <remarks>Since using a custom columncollection for footer, the base class for footer never gets updated with column. As a result, even though columns.count and
    ''' myclass.columns.count both return the value for our column collection, whenever a row is attempted to get added an exception will occur for adding rows without columns.
    ''' This happenes even if we used rows.add or myclass.rows.add. Which honestly makes no sense to me, since both of those return a valid column count.
    ''' So we add a column by same name to mybase, so we can get our row. I could not find any other way around this. Unless we change mybase.columncount to match, but then
    ''' event handlers are triggered, and they receive a column with an empty na</remarks>
    Private Sub SyncBaseColumns()
        For Each c As DataGridViewColumn In _fColumns
            Columns.Add(c.Name, c.HeaderText)
        Next
    End Sub

    ''' <summary>
    ''' Returns a datagridviewrow for use as spacer row.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SpacerRow() As DataGridViewRow
        Dim sRow As New DataGridViewRow

        sRow.DefaultCellStyle.BackColor = _parentDgv.BackgroundColor
        sRow.Tag = "spacer"
        sRow.DefaultCellStyle.SelectionBackColor = _parentDgv.BackgroundColor
        sRow.ReadOnly = True
        sRow.Height = Height + 2

        Return sRow
    End Function

    ''' <summary>
    ''' Checks whether the total columns width will display a horizontal scrollbar.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ColumnsOverflow() As Boolean
        Dim colSpace As Integer = 0

        For Each col As DataGridViewColumn In _parentDgv.Columns
            colSpace += col.Width
        Next

        If _parentDgv.RowHeadersVisible Then colSpace += _parentDgv.RowHeadersWidth

        Return colSpace > _parentDgv.ClientSize.Width

    End Function

    'static double[] pow10 = { 1e0, 1e1, 1e2, 1e3, 1e4, 1e5, 1e6, 1e7, 1e8, 1e9, 1e10 };
    Private ReadOnly pow10 As Double() = {1.0, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, 10000000.0, 100000000.0, 1000000000.0, 10000000000.0}

    ''' <summary>
    ''' Truncates a decimal number to specified decimal places without rounding.
    ''' </summary>
    ''' <param name="numToTruncate"></param>
    ''' <param name="decimalPlaces"></param>
    ''' <returns>A double truncated to the specified decimal places.</returns>
    ''' <remarks>Function provided by Glenn Slayden (http://stackoverflow.com/users/147511/glenn-slayden) on http://stackoverflow.com/questions/329957/truncate-decimal-number-not-round-off</remarks>
    Private Function TruncateToDecimalPlace(ByVal numToTruncate As Double, ByVal decimalPlaces As Integer) As Double
        If decimalPlaces < 0 Then Throw New ArgumentException()
        If decimalPlaces = 0 Then Return Math.Truncate(numToTruncate)

        Dim m As Double = If(decimalPlaces >= pow10.Length, Math.Pow(10, decimalPlaces), pow10(decimalPlaces))
        Return Math.Truncate(numToTruncate * m) / m
    End Function

#End Region

#Region "Properties"

    ''' <summary>
    ''' If set to true, footer will autosum the columns in parent datagridview
    ''' </summary>
    ''' <value>A boolean indicating whether footer should autosum parent dgv columns.</value>
    ''' <returns>True if set to autocalc. Otherwise false.</returns>
    ''' <remarks>If this is set to false after footer has already summed columns, the values will not be removed from footer.
    ''' But no further autosum will be performed.</remarks>
    Public Property AutoCalc As Boolean
        Get
            Return _autoCalc
        End Get
        Set
            _autoCalc = Value
            CalculateTotals()
        End Set
    End Property

    ''' <summary>
    ''' The descriptive suffix appended to the end of the totals in footer cells.
    ''' </summary>
    ''' <value>String to be used as the descriptive suffix appended to the end of the totals in footer cells.</value>
    ''' <returns>The descriptive suffix appended to the end of the totals in footer cells.</returns>
    ''' <remarks></remarks>
    Public Property ValueSuffix As String
        Get
            Return _valueSuffix
        End Get
        Set
            _valueSuffix = Value
            CalculateTotals()
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
        Set
            _footerHeader = Value

            If Columns.Count > 0 Then

                ColumnToSum(0) = Not Value

                If RowCount > 0 Then
                    CalculateTotals()

                    If Value Then
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
        Set
            _footerHeaderText = Value
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
        Set
            _footerHeaderBackColor = Value
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
        Set
            _footerHeaderForeColor = Value
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
        Set
            _decimalPlaces = Value

            CalculateTotals()
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
        Set
            If Columns.Count < 1 Then Exit Property
            If _parentDgv.Columns.Count > 0 Then
                If UseHeader And _parentDgv.Columns(0).Name = columnName Then Value = False
            End If

            If Value Then
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
        'Lets be a little lazy/smart and just call this property using the na
        'We could just perform needed actions using the index, but im sure we are getting a displayindex number, and not the actual index.
        'So to be safe, we will get the name from the index passed and call the property using columnName instead.
        'Besides this avoids recoding the same exact thing more than once, just to use index rather than columnNa
        Get
            Dim columnName As String = _parentDgv.Columns(columnIndex).Name
            Return ColumnToSum(columnName)
        End Get
        Set
            Dim columnName As String = _parentDgv.Columns(columnIndex).Name
            ColumnToSum(columnName) = Value
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
        Set
            _roundSum = Value

            CalculateTotals()
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
        Set
            _bankersRounding = Value

            CalculateTotals()
        End Set
    End Property

    ''' <summary>
    ''' Gets the value of the footer cell as a double.
    ''' </summary>
    ''' <param name="columnName">The name of the column in the parent dataGridView to which get the corresponding value from in footer.</param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Will return 0 if value is not a number</remarks>
    Public ReadOnly Property Value(ByVal columnName As String) As Double
        Get
            Dim cVal As String = CStr(Rows(0).Cells(columnName & "_footer").Value)
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
            Return Value(_parentDgv.Columns(columnIndex).Name)
        End Get
    End Property

#End Region

#Region "Hidden Overridden Properties"

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Overrides Property Dock As DockStyle
        Get
            Return MyBase.Dock
        End Get
        Set
            MyBase.Dock = DockStyle.Bottom
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property RowHeadersVisible As Boolean
        Get
            Return False
        End Get
        Set
            MyBase.RowHeadersVisible = Value
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property ColumnHeadersVisible As Boolean
        Get
            Return False
        End Get
        Set
            MyBase.ColumnHeadersVisible = False
        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AllowUserToOrderColumns As Boolean
        Get
            Return False
        End Get
        Set

        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AllowUserToResizeColumns As Boolean
        Get
            Return False
        End Get
        Set

        End Set
    End Property

    <Browsable(False)>
    <EditorBrowsable(EditorBrowsableState.Never)>
    Public Shadows Property AllowUserToResizeRows As Boolean
        Get
            Return False
        End Get
        Set

        End Set
    End Property

    '<Browsable(False)> _
    '<EditorBrowsable(EditorBrowsableState.Never)>
    'Public Shadows ReadOnly Property Columns As FooterColumnCollection
    '    Get
    '        If IsNothing(_fColumns) Then
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

    Public Overrides Function Add(dataGridViewColumn As DataGridViewColumn) As Integer
        If _calledByFooter Then
            _calledByFooter = False
            Return MyBase.Add(dataGridViewColumn)
        Else
            Return -1
        End If
    End Function

    Public Overrides Sub AddRange(ParamArray dataGridViewColumns() As DataGridViewColumn)
        If _calledByFooter Then
            _calledByFooter = False
            MyBase.AddRange(dataGridViewColumns)
        End If
    End Sub

    Public Overrides Sub Clear()
        MyBase.Clear()
    End Sub

    Public Overrides Sub Insert(columnIndex As Integer, dataGridViewColumn As DataGridViewColumn)
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

    Public Overrides Sub Remove(dataGridViewColumn As DataGridViewColumn)
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