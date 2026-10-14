Imports System.Data
Imports System.Drawing
Imports System.Collections.Generic
Imports System.Linq
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Accounts.ServiceLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms
    Public Class TableViewerForm
        Inherits Form

        Private ReadOnly _tables As New ComboBox()
        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _export As New Button()
        Private ReadOnly _refresh As New Button()
        Private ReadOnly _fields As New Button()
        Private ReadOnly _filters As New Button()
        Private ReadOnly _clearFilters As New Button()
        Private ReadOnly _fieldFilters As New Dictionary(Of String, Tuple(Of String, String, String))(StringComparer.Ordinal)
        Private ReadOnly _selectedFields As New HashSet(Of String)(StringComparer.Ordinal)
        Private ReadOnly _pictureColumns As New HashSet(Of String)(StringComparer.Ordinal)
        Private ReadOnly _thumbnails As New Dictionary(Of Byte(), Image)()
        Private ReadOnly _status As New Label()
        Private ReadOnly _service As New TableViewerService()
        Private _data As DataTable
        Private _loading As Boolean

        Public Sub New()
            Text = Caption("Table Viewer", "عارض الجداول")
            Size = New Size(1200, 720)
            MinimumSize = New Size(650, 400)
            StartPosition = FormStartPosition.CenterParent
            RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = GlobalVariables.RightToLeftLayout
            Dim toolbar As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 52, .Padding = New Padding(8), .WrapContents = False, .AutoScroll = True}
            toolbar.Controls.Add(New Label With {.Text = Caption("Table", "الجدول"), .AutoSize = True, .Padding = New Padding(0, 6, 0, 0)})
            _tables.Width = 400
            _tables.DropDownStyle = ComboBoxStyle.DropDownList
            _tables.DisplayMember = "DisplayName"
            _refresh.Text = Caption("Refresh", "تحديث")
            _refresh.AutoSize = True
            _export.Text = Caption("Export to Excel", "تصدير إلى Excel")
            _export.AutoSize = True
            _export.Enabled = False
            _fields.Text = Caption("Export Fields", "حقول التصدير")
            _fields.AutoSize = True
            _fields.Enabled = False
            _filters.Text = Caption("Filters", "عوامل التصفية")
            _filters.AutoSize = True
            _filters.Enabled = False
            _clearFilters.Text = Caption("Clear Filters", "مسح التصفية")
            _clearFilters.AutoSize = True
            _clearFilters.Enabled = False
            toolbar.Controls.AddRange(New Control() {_tables, _refresh, _filters, _clearFilters, _fields, _export})
            _grid.Dock = DockStyle.Fill
            _grid.ReadOnly = True
            _grid.AllowUserToAddRows = False
            _grid.AllowUserToDeleteRows = False
            _grid.AutoGenerateColumns = False
            _grid.AllowUserToOrderColumns = True
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            _grid.VirtualMode = False
            _status.Dock = DockStyle.Bottom
            _status.Height = 30
            _status.Padding = New Padding(8, 4, 8, 4)
            Controls.Add(_grid)
            Controls.Add(toolbar)
            Controls.Add(_status)
            AddHandler Load, AddressOf LoadTables
            AddHandler _tables.SelectedIndexChanged, AddressOf LoadRecords
            AddHandler _refresh.Click, AddressOf LoadRecords
            AddHandler _export.Click, AddressOf ExportRecords
            AddHandler _grid.CellFormatting, AddressOf FormatCell
            AddHandler _grid.CellPainting, AddressOf PaintPicture
            AddHandler _grid.CellDoubleClick, AddressOf PreviewPicture
            AddHandler _fields.Click, AddressOf SelectFields
            AddHandler _filters.Click, AddressOf SelectFilters
            AddHandler _clearFilters.Click, Sub(sender, e)
                                              If _data Is Nothing Then Return
                                              _data.DefaultView.RowFilter = String.Empty
                                              _fieldFilters.Clear()
                                              UpdateFilterStatus()
                                          End Sub
            AddHandler FormClosed, Sub(sender, e)
                                       If _data IsNot Nothing Then _data.Dispose()
                                   End Sub
        End Sub

        Private Shared Function Caption(english As String, arabic As String) As String
            Return If(GlobalVariables.RightToLeftLayout, arabic, english)
        End Function

        Private Sub LoadTables(sender As Object, e As EventArgs)
            RunOperation(Sub()
                             _loading = True
                             Try
                                 _tables.DataSource = _service.GetTables()
                                 _tables.SelectedIndex = -1
                                 _status.Text = Caption("Select a table to display all records.", "اختر جدولاً لعرض جميع السجلات.")
                             Finally
                                 _loading = False
                             End Try
                         End Sub)
        End Sub

        Private Sub LoadRecords(sender As Object, e As EventArgs)
            If _loading Then Return
            _grid.DataSource = Nothing
            _grid.Columns.Clear()
            ClearThumbnails()
            _pictureColumns.Clear()
            _selectedFields.Clear()
            _grid.RowTemplate.Height = 22
            _export.Enabled = False
            _fields.Enabled = False
            _filters.Enabled = False
            _clearFilters.Enabled = False
            _fieldFilters.Clear()
            _filters.Text = Caption("Filters", "عوامل التصفية")
            If _data IsNot Nothing Then _data.Dispose()
            _data = Nothing
            _status.Text = String.Empty
            Dim selected = TryCast(_tables.SelectedItem, DataRowView)
            If selected Is Nothing Then Return
            RunOperation(Sub()
                             _data = _service.GetRecords(CStr(selected("SchemaName")), CStr(selected("TableName")))
                             For Each column As DataColumn In _data.Columns
                                 _selectedFields.Add(column.ColumnName)
                                 If column.DataType Is GetType(Byte()) Then
                                     Dim name = column.ColumnName.ToLowerInvariant()
                                     Dim isPicture = name.Contains("picture") OrElse name.Contains("photo") OrElse name.Contains("image") OrElse name.Contains("logo") OrElse name.Contains("signature")
                                     If Not isPicture Then
                                         For Each row As DataRow In _data.Rows.Cast(Of DataRow)().Take(32)
                                             Using picture = TableViewerService.TryReadPicture(row(column))
                                                 If picture IsNot Nothing Then isPicture = True
                                             End Using
                                             If isPicture Then Exit For
                                         Next
                                     End If
                                     If isPicture Then _pictureColumns.Add(column.ColumnName)
                                 End If
                                 _grid.Columns.Add(New DataGridViewTextBoxColumn With {
                                     .Name = column.ColumnName, .HeaderText = column.ColumnName,
                                     .DataPropertyName = column.ColumnName, .Width = 160,
                                     .SortMode = DataGridViewColumnSortMode.Automatic})
                             Next
                             If _pictureColumns.Count > 0 Then _grid.RowTemplate.Height = 68
                             _grid.DataSource = _data.DefaultView
                             _export.Enabled = True
                             _fields.Enabled = True
                             _filters.Enabled = True
                             UpdateFilterStatus()
                         End Sub)
        End Sub

        Private Sub FormatCell(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If _pictureColumns.Contains(_grid.Columns(e.ColumnIndex).DataPropertyName) Then
                Dim bytes = TryCast(e.Value, Byte())
                e.Value = If(bytes Is Nothing OrElse bytes.Length = 0, Caption("No picture", "لا توجد صورة"), Caption("Invalid picture", "صورة غير صالحة"))
                e.FormattingApplied = True
                Return
            End If
            If e.Value Is Nothing OrElse Convert.IsDBNull(e.Value) Then
                e.Value = "NULL"
                e.FormattingApplied = True
            ElseIf TypeOf e.Value Is Byte() Then
                e.Value = TableViewerService.DisplayValue(e.Value)
                e.FormattingApplied = True
            End If
        End Sub

        Private Sub PaintPicture(sender As Object, e As DataGridViewCellPaintingEventArgs)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse Not _pictureColumns.Contains(_grid.Columns(e.ColumnIndex).DataPropertyName) Then Return
            Dim bytes = TryCast(_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Byte())
            If bytes Is Nothing OrElse bytes.Length = 0 Then Return
            Dim thumbnail As Image = Nothing
            If Not _thumbnails.TryGetValue(bytes, thumbnail) Then
                If _thumbnails.Count >= 200 Then ClearThumbnails()
                Using picture = TableViewerService.TryReadPicture(bytes)
                    If picture IsNot Nothing Then
                        Dim scale = Math.Min(140.0 / picture.Width, 58.0 / picture.Height)
                        thumbnail = New Bitmap(Math.Max(1, CInt(picture.Width * scale)), Math.Max(1, CInt(picture.Height * scale)))
                        Using canvas = Graphics.FromImage(thumbnail)
                            canvas.DrawImage(picture, 0, 0, thumbnail.Width, thumbnail.Height)
                        End Using
                    End If
                End Using
                _thumbnails.Add(bytes, thumbnail)
            End If
            If thumbnail Is Nothing Then Return
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All And Not DataGridViewPaintParts.ContentForeground)
            e.Graphics.DrawImage(thumbnail, e.CellBounds.Left + (e.CellBounds.Width - thumbnail.Width) \ 2,
                                 e.CellBounds.Top + (e.CellBounds.Height - thumbnail.Height) \ 2)
            e.Handled = True
        End Sub

        Private Sub PreviewPicture(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse Not _pictureColumns.Contains(_grid.Columns(e.ColumnIndex).DataPropertyName) Then Return
            Using picture = TableViewerService.TryReadPicture(_grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                If picture Is Nothing Then Return
                Using preview As New Form With {.Text = Caption("Picture Preview", "معاينة الصورة"), .Size = New Size(850, 650), .StartPosition = FormStartPosition.CenterParent, .RightToLeft = RightToLeft, .RightToLeftLayout = RightToLeftLayout}
                    preview.Controls.Add(New PictureBox With {.Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.Zoom, .Image = picture, .BackColor = Color.White})
                    preview.ShowDialog(Me)
                End Using
            End Using
        End Sub

        Private Sub ClearThumbnails()
            For Each picture In _thumbnails.Values
                If picture IsNot Nothing Then picture.Dispose()
            Next
            _thumbnails.Clear()
        End Sub

        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then ClearThumbnails()
            MyBase.Dispose(disposing)
        End Sub

        Private Sub SelectFields(sender As Object, e As EventArgs)
            If _data Is Nothing Then Return
            Using dialog As New Form With {.Text = Caption("Export Fields", "حقول التصدير"), .Size = New Size(420, 520), .StartPosition = FormStartPosition.CenterParent, .RightToLeft = RightToLeft, .RightToLeftLayout = RightToLeftLayout}
                Dim list As New CheckedListBox With {.Dock = DockStyle.Fill, .CheckOnClick = True}
                For Each column As DataColumn In _data.Columns
                    list.Items.Add(column.ColumnName, _selectedFields.Contains(column.ColumnName))
                Next
                Dim buttons As New FlowLayoutPanel With {.Dock = DockStyle.Bottom, .Height = 42}
                Dim all As New Button With {.Text = Caption("Select all", "تحديد الكل"), .AutoSize = True}
                Dim none As New Button With {.Text = Caption("Clear all", "إلغاء الكل"), .AutoSize = True}
                Dim ok As New Button With {.Text = Caption("OK", "موافق"), .DialogResult = DialogResult.OK}
                AddHandler all.Click, Sub()
                                          For index = 0 To list.Items.Count - 1
                                              list.SetItemChecked(index, True)
                                          Next
                                      End Sub
                AddHandler none.Click, Sub()
                                           For index = 0 To list.Items.Count - 1
                                               list.SetItemChecked(index, False)
                                           Next
                                       End Sub
                buttons.Controls.AddRange(New Control() {all, none, ok})
                dialog.Controls.Add(list)
                dialog.Controls.Add(buttons)
                dialog.AcceptButton = ok
                If dialog.ShowDialog(Me) = DialogResult.OK Then
                    _selectedFields.Clear()
                    For Each field As String In list.CheckedItems
                        _selectedFields.Add(field)
                    Next
                End If
            End Using
        End Sub

        Private Sub UpdateFilterStatus()
            _clearFilters.Enabled = _fieldFilters.Count > 0
            _filters.Text = Caption("Filters", "عوامل التصفية") & If(_fieldFilters.Count = 0, "", " (" & _fieldFilters.Count.ToString() & ")")
            For Each column As DataGridViewColumn In _grid.Columns
                column.HeaderText = column.DataPropertyName & If(_fieldFilters.ContainsKey(column.DataPropertyName), " *", "")
            Next
            _status.Text = String.Format(Caption("{0:N0} of {1:N0} records, {2:N0} fields", "{0:N0} من {1:N0} سجل، {2:N0} حقل"), _data.DefaultView.Count, _data.Rows.Count, _data.Columns.Count)
        End Sub

        Private Sub SelectFilters(sender As Object, e As EventArgs)
            If _data Is Nothing Then Return
            Using dialog As New Form With {.Text = Caption("Field Filters", "تصفية الحقول"), .Size = New Size(1000, 600), .MinimumSize = New Size(700, 400), .StartPosition = FormStartPosition.CenterParent, .RightToLeft = RightToLeft, .RightToLeftLayout = RightToLeftLayout}
                Dim list As New DataGridView With {.Dock = DockStyle.Fill, .AllowUserToAddRows = False, .AllowUserToDeleteRows = False, .RowHeadersVisible = False, .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill}
                list.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Field", .HeaderText = Caption("Field", "الحقل"), .ReadOnly = True})
                list.Columns.Add(New DataGridViewComboBoxColumn With {.Name = "Mode", .HeaderText = Caption("Filter", "التصفية"), .DisplayMember = "Label", .ValueMember = "Mode"})
                list.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Value", .HeaderText = Caption("Value / From", "القيمة / من")})
                list.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Upper", .HeaderText = Caption("To (range)", "إلى (النطاق)")})
                Dim modes As New DataTable()
                modes.Columns.Add("Mode", GetType(String))
                modes.Columns.Add("Label", GetType(String))
                modes.Rows.Add("None", Caption("No filter", "بدون تصفية"))
                modes.Rows.Add("Contains", Caption("Contains", "يحتوي على"))
                modes.Rows.Add("Equals", Caption("Equals", "يساوي"))
                modes.Rows.Add("NotContains", Caption("Does not contain", "لا يحتوي على"))
                modes.Rows.Add("NotEquals", Caption("Does not equal", "لا يساوي"))
                modes.Rows.Add("GreaterThan", Caption("Greater than", "أكبر من"))
                modes.Rows.Add("GreaterOrEqual", Caption("Greater than or equal", "أكبر من أو يساوي"))
                modes.Rows.Add("LessThan", Caption("Less than", "أقل من"))
                modes.Rows.Add("LessOrEqual", Caption("Less than or equal", "أقل من أو يساوي"))
                modes.Rows.Add("Between", Caption("Between (inclusive)", "بين (شامل الطرفين)"))
                modes.Rows.Add("NotBetween", Caption("Outside range", "خارج النطاق"))
                modes.Rows.Add("Before", Caption("Before date", "قبل التاريخ"))
                modes.Rows.Add("OnOrBefore", Caption("On or before date", "في التاريخ أو قبله"))
                modes.Rows.Add("After", Caption("After date", "بعد التاريخ"))
                modes.Rows.Add("OnOrAfter", Caption("On or after date", "في التاريخ أو بعده"))
                modes.Rows.Add("Null", Caption("Is NULL", "قيمة فارغة NULL"))
                modes.Rows.Add("NotNull", Caption("Is not NULL", "قيمة غير فارغة NULL"))
                For Each column As DataColumn In _data.Columns
                    Dim criterion As Tuple(Of String, String, String) = Nothing
                    _fieldFilters.TryGetValue(column.ColumnName, criterion)
                    Dim initialDate = Date.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                    Dim rowIndex = list.Rows.Add(column.ColumnName, If(criterion Is Nothing, "None", criterion.Item1), If(criterion Is Nothing, If(column.DataType Is GetType(DateTime), initialDate, ""), criterion.Item2), If(criterion Is Nothing, If(column.DataType Is GetType(DateTime), initialDate, ""), criterion.Item3))
                    Dim modeCell = DirectCast(list.Rows(rowIndex).Cells("Mode"), DataGridViewComboBoxCell)
                    ' Binary fields support presence/absence filtering rather than text conversion.
                    Dim available = "Mode IN ('None','Contains','Equals','NotEquals','NotContains','Null','NotNull')"
                    If column.DataType Is GetType(Byte()) Then
                        available = "Mode IN ('None','Null','NotNull')"
                    ElseIf IsNumericType(column.DataType) Then
                        available = "Mode NOT IN ('Before','OnOrBefore','After','OnOrAfter')"
                    ElseIf column.DataType Is GetType(DateTime) Then
                        available = "Mode NOT IN ('GreaterThan','GreaterOrEqual','LessThan','LessOrEqual')"
                    End If
                    modeCell.DataSource = New DataView(modes, available, "", DataViewRowState.CurrentRows)
                    If column.DataType Is GetType(Boolean) Then
                        modeCell.DataSource = New DataView(modes, "Mode IN ('None','Equals','Null','NotNull')", "", DataViewRowState.CurrentRows)
                        Dim valueCell As New DataGridViewComboBoxCell With {.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton}
                        valueCell.Items.AddRange("True", "False", "NULL")
                        valueCell.Value = If(criterion Is Nothing, "True", If(criterion.Item1 = "Null", "NULL", If(String.Equals(criterion.Item2, "False", StringComparison.OrdinalIgnoreCase), "False", "True")))
                        list.Rows(rowIndex).Cells("Value") = valueCell
                    End If
                Next
                Dim datePanel As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 40, .Padding = New Padding(8, 2, 8, 2), .WrapContents = False}
                Dim fromDate As New DateTimePicker With {.Format = DateTimePickerFormat.Custom, .CustomFormat = "yyyy-MM-dd", .Width = 135, .Enabled = False}
                Dim toDate As New DateTimePicker With {.Format = DateTimePickerFormat.Custom, .CustomFormat = "yyyy-MM-dd", .Width = 135, .Enabled = False}
                datePanel.Controls.AddRange(New Control() {New Label With {.Text = Caption("Selected date field: From", "حقل التاريخ المحدد: من"), .AutoSize = True}, fromDate, New Label With {.Text = Caption("To", "إلى"), .AutoSize = True}, toDate})
                Dim syncingDates As Boolean = False
                Dim syncDateEditors As Action =
                    Sub()
                        syncingDates = True
                        Try
                            Dim row = If(list.CurrentCell Is Nothing, Nothing, list.Rows(list.CurrentCell.RowIndex))
                            Dim isDate = row IsNot Nothing AndAlso _data.Columns(CStr(row.Cells("Field").Value)).DataType Is GetType(DateTime)
                            Dim mode = If(row Is Nothing, "None", CStr(row.Cells("Mode").Value))
                            fromDate.Enabled = isDate AndAlso mode <> "None" AndAlso mode <> "Null" AndAlso mode <> "NotNull" AndAlso mode <> "Contains" AndAlso mode <> "NotContains"
                            toDate.Enabled = fromDate.Enabled AndAlso (mode = "Between" OrElse mode = "NotBetween")
                            If Not isDate Then Return
                            Dim parsed As DateTime
                            If DateTime.TryParse(Convert.ToString(row.Cells("Value").Value), CultureInfo.InvariantCulture, DateTimeStyles.None, parsed) AndAlso parsed >= fromDate.MinDate AndAlso parsed <= fromDate.MaxDate Then fromDate.Value = parsed
                            If DateTime.TryParse(Convert.ToString(row.Cells("Upper").Value), CultureInfo.InvariantCulture, DateTimeStyles.None, parsed) AndAlso parsed >= toDate.MinDate AndAlso parsed <= toDate.MaxDate Then toDate.Value = parsed
                        Finally
                            syncingDates = False
                        End Try
                    End Sub
                AddHandler list.CurrentCellChanged, Sub(s, args) syncDateEditors()
                AddHandler list.CellValueChanged, Sub(s, args) syncDateEditors()
                AddHandler fromDate.ValueChanged, Sub(s, args)
                                                     If Not syncingDates AndAlso fromDate.Enabled AndAlso list.CurrentCell IsNot Nothing Then list.Rows(list.CurrentCell.RowIndex).Cells("Value").Value = fromDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                                                 End Sub
                AddHandler toDate.ValueChanged, Sub(s, args)
                                                   If Not syncingDates AndAlso toDate.Enabled AndAlso list.CurrentCell IsNot Nothing Then list.Rows(list.CurrentCell.RowIndex).Cells("Upper").Value = toDate.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                                               End Sub
                AddHandler list.CellBeginEdit, Sub(s, args)
                                                   If args.ColumnIndex <> 2 AndAlso args.ColumnIndex <> 3 Then Return
                                                   Dim row = list.Rows(args.RowIndex)
                                                   If _data.Columns(CStr(row.Cells("Field").Value)).DataType Is GetType(Boolean) Then
                                                       If args.ColumnIndex = 3 Then
                                                           args.Cancel = True
                                                           Return
                                                       End If
                                                       row.Cells("Mode").Value = If(CStr(row.Cells("Value").Value) = "NULL", "Null", "Equals")
                                                       Return
                                                   End If
                                                   Dim mode = CStr(list.Rows(args.RowIndex).Cells("Mode").Value)
                                                   args.Cancel = mode = "None" OrElse mode = "Null" OrElse mode = "NotNull"
                                                   If args.ColumnIndex = 3 Then args.Cancel = mode <> "Between" AndAlso mode <> "NotBetween"
                                               End Sub
                AddHandler list.CurrentCellDirtyStateChanged, Sub(s, args)
                                                                  If list.IsCurrentCellDirty AndAlso TypeOf list.CurrentCell Is DataGridViewComboBoxCell Then
                                                                      list.CommitEdit(DataGridViewDataErrorContexts.Commit)
                                                                  End If
                                                              End Sub
                AddHandler list.CellValueChanged, Sub(s, args)
                                                     If args.RowIndex < 0 OrElse args.ColumnIndex <> 2 Then Return
                                                     Dim row = list.Rows(args.RowIndex)
                                                     If _data.Columns(CStr(row.Cells("Field").Value)).DataType Is GetType(Boolean) Then
                                                         row.Cells("Mode").Value = If(CStr(row.Cells("Value").Value) = "NULL", "Null", "Equals")
                                                     End If
                                                 End Sub
                Dim hint As New Label With {.Dock = DockStyle.Top, .Height = 60, .Padding = New Padding(8), .Text = Caption("All active filters must match. Numbers use your regional decimal separator (without grouping). Use yyyy-MM-dd or the date pickers; date ranges include the whole final day. Export uses the filtered list.", "يجب مطابقة جميع عوامل التصفية. أدخل الأرقام بالفاصل العشري المحلي دون فواصل الآلاف. استخدم yyyy-MM-dd أو منتقي التاريخ. النطاق يشمل اليوم الأخير كاملاً. التصدير يستخدم القائمة المصفاة.")}
                Dim buttons As New FlowLayoutPanel With {.Dock = DockStyle.Bottom, .Height = 42}
                Dim apply As New Button With {.Text = Caption("Apply", "تطبيق"), .AutoSize = True}
                Dim cancel As New Button With {.Text = Caption("Cancel", "إلغاء"), .DialogResult = DialogResult.Cancel, .AutoSize = True}
                buttons.Controls.AddRange(New Control() {apply, cancel})
                dialog.Controls.Add(list)
                dialog.Controls.Add(datePanel)
                dialog.Controls.Add(hint)
                dialog.Controls.Add(buttons)
                dialog.AcceptButton = apply
                dialog.CancelButton = cancel
                AddHandler apply.Click,
                    Sub()
                        list.EndEdit()
                        Try
                                 Dim criteria As New Dictionary(Of String, Tuple(Of String, String, String))(StringComparer.Ordinal)
                                 For Each row As DataGridViewRow In list.Rows
                                     Dim mode = CStr(row.Cells("Mode").Value)
                                     Dim field = CStr(row.Cells("Field").Value)
                                     Dim value = Convert.ToString(row.Cells("Value").Value)
                                     If mode = "Equals" AndAlso _data.Columns(field).DataType Is GetType(Boolean) AndAlso value = "NULL" Then mode = "Null"
                                     If mode <> "None" Then criteria.Add(field, Tuple.Create(mode, value, Convert.ToString(row.Cells("Upper").Value)))
                                 Next
                                 _data.CaseSensitive = False
                                 _data.DefaultView.RowFilter = BuildTypedRowFilter(criteria, _data.Columns)
                                 _fieldFilters.Clear()
                                 For Each criterion In criteria
                                     _fieldFilters.Add(criterion.Key, criterion.Value)
                                 Next
                                 UpdateFilterStatus()
                                 dialog.DialogResult = DialogResult.OK
                        Catch ex As ArgumentException
                            MessageBox.Show(dialog, ex.Message, Caption("Invalid filter", "تصفية غير صالحة"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Catch ex As InvalidExpressionException
                            MessageBox.Show(dialog, Caption("The filter cannot be applied to this field type.", "لا يمكن تطبيق التصفية على نوع هذا الحقل."), dialog.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End Try
                    End Sub
                dialog.ShowDialog(Me)
            End Using
        End Sub

        Friend Shared Function IsNumericType(type As Type) As Boolean
            Return New Type() {GetType(Byte), GetType(SByte), GetType(Int16), GetType(UInt16), GetType(Int32), GetType(UInt32), GetType(Int64), GetType(UInt64), GetType(Decimal), GetType(Single), GetType(Double)}.Contains(type)
        End Function

        Friend Shared Function BuildTypedRowFilter(criteria As IDictionary(Of String, Tuple(Of String, String, String)), columns As DataColumnCollection) As String
            Dim expressions As New List(Of String)()
            For Each criterion In criteria
                If Not columns.Contains(criterion.Key) Then Throw New ArgumentException("Unknown field: " & criterion.Key)
                Dim type = columns(criterion.Key).DataType
                Dim mode = criterion.Value.Item1
                Dim value = criterion.Value.Item2
                Dim upper = criterion.Value.Item3
                Dim field = "[" & criterion.Key.Replace("\", "\\").Replace("]", "\]") & "]"
                If mode = "None" Then Continue For
                If mode = "Null" OrElse mode = "NotNull" OrElse mode = "Contains" OrElse mode = "NotContains" Then
                    If type Is GetType(Byte()) AndAlso (mode = "Contains" OrElse mode = "NotContains") Then Throw New ArgumentException("Binary fields support NULL checks only.")
                    expressions.Add(BuildRowFilter(New Dictionary(Of String, Tuple(Of String, String)) From {{criterion.Key, Tuple.Create(mode, value)}}))
                    Continue For
                End If
                If IsNumericType(type) Then
                    Dim literal = NumberLiteral(value, type, criterion.Key)
                    Select Case mode
                        Case "Equals", "NotEquals", "GreaterThan", "GreaterOrEqual", "LessThan", "LessOrEqual"
                            Dim operators As New Dictionary(Of String, String) From {{"Equals", "="}, {"NotEquals", "<>"}, {"GreaterThan", ">"}, {"GreaterOrEqual", ">="}, {"LessThan", "<"}, {"LessOrEqual", "<="}}
                            expressions.Add(field & " " & operators(mode) & " " & literal)
                        Case "Between", "NotBetween"
                            Dim endLiteral = NumberLiteral(upper, type, criterion.Key)
                            If DecimalOrDoubleCompare(literal, endLiteral, type) > 0 Then Throw New ArgumentException(Caption("From must not exceed To for ", "يجب ألا تتجاوز قيمة من قيمة إلى للحقل ") & criterion.Key)
                            expressions.Add(If(mode = "Between", "(" & field & " >= " & literal & " AND " & field & " <= " & endLiteral & ")", "(" & field & " < " & literal & " OR " & field & " > " & endLiteral & ")"))
                        Case Else
                            Throw New ArgumentException("Unsupported numeric filter: " & mode)
                    End Select
                ElseIf type Is GetType(DateTime) Then
                    Dim day = FilterDate(value, criterion.Key)
                    Dim start = DateLiteral(day)
                    Dim nextDay = If(day = DateTime.MaxValue.Date, Nothing, DateLiteral(day.AddDays(1)))
                    Dim dayEnd = If(nextDay Is Nothing, field & " <= " & DateLiteral(DateTime.MaxValue), field & " < " & nextDay)
                    Select Case mode
                        Case "Equals"
                            expressions.Add("(" & field & " >= " & start & " AND " & dayEnd & ")")
                        Case "NotEquals"
                            expressions.Add("(" & field & " < " & start & If(nextDay Is Nothing, "", " OR " & field & " >= " & nextDay) & ")")
                        Case "Before"
                            expressions.Add(field & " < " & start)
                        Case "OnOrBefore"
                            expressions.Add(dayEnd)
                        Case "After"
                            expressions.Add(If(nextDay Is Nothing, field & " > " & DateLiteral(DateTime.MaxValue), field & " >= " & nextDay))
                        Case "OnOrAfter"
                            expressions.Add(field & " >= " & start)
                        Case "Between", "NotBetween"
                            Dim endDay = FilterDate(upper, criterion.Key)
                            If day > endDay Then Throw New ArgumentException(Caption("From date must not exceed To date for ", "يجب ألا يتجاوز تاريخ من تاريخ إلى للحقل ") & criterion.Key)
                            Dim afterEnd = If(endDay = DateTime.MaxValue.Date, Nothing, DateLiteral(endDay.AddDays(1)))
                            Dim endCondition = If(afterEnd Is Nothing, field & " <= " & DateLiteral(DateTime.MaxValue), field & " < " & afterEnd)
                            expressions.Add(If(mode = "Between", "(" & field & " >= " & start & " AND " & endCondition & ")", "(" & field & " < " & start & If(afterEnd Is Nothing, "", " OR " & field & " >= " & afterEnd) & ")"))
                        Case Else
                            Throw New ArgumentException("Unsupported date filter: " & mode)
                    End Select
                ElseIf type Is GetType(Boolean) Then
                    Dim flag As Boolean
                    If (mode <> "Equals" AndAlso mode <> "NotEquals") OrElse Not Boolean.TryParse(value, flag) Then Throw New ArgumentException("Select True or False for " & criterion.Key)
                    expressions.Add(field & If(mode = "Equals", " = ", " <> ") & If(flag, "TRUE", "FALSE"))
                ElseIf mode = "Equals" OrElse mode = "NotEquals" Then
                    Dim expression = BuildRowFilter(New Dictionary(Of String, Tuple(Of String, String)) From {{criterion.Key, Tuple.Create("Equals", value)}})
                    expressions.Add(If(mode = "Equals", expression, "NOT (" & expression & ")"))
                Else
                    Throw New ArgumentException("Unsupported filter for " & criterion.Key)
                End If
            Next
            Return String.Join(" AND ", expressions)
        End Function

        Private Shared Function NumberLiteral(value As String, type As Type, field As String) As String
            Try
                If type Is GetType(Single) OrElse type Is GetType(Double) Then
                    Dim number = Double.Parse(value, NumberStyles.Float, CultureInfo.CurrentCulture)
                    If Double.IsNaN(number) OrElse Double.IsInfinity(number) Then Throw New FormatException()
                    If type Is GetType(Single) AndAlso (number > Single.MaxValue OrElse number < -Single.MaxValue) Then Throw New OverflowException()
                    Return number.ToString("R", CultureInfo.InvariantCulture)
                End If
                Dim exact = Decimal.Parse(value, NumberStyles.Float, CultureInfo.CurrentCulture)
                If type IsNot GetType(Decimal) Then
                    If Decimal.Truncate(exact) <> exact Then Throw New FormatException()
                    Convert.ChangeType(exact, type, CultureInfo.InvariantCulture)
                End If
                Return exact.ToString(CultureInfo.InvariantCulture)
            Catch ex As Exception When TypeOf ex Is FormatException OrElse TypeOf ex Is OverflowException
                Throw New ArgumentException(Caption("Enter a valid number for ", "أدخل رقماً صالحاً للحقل ") & field & " (" & type.Name & ").")
            End Try
        End Function

        Private Shared Function DecimalOrDoubleCompare(first As String, second As String, type As Type) As Integer
            If type Is GetType(Single) OrElse type Is GetType(Double) Then Return Double.Parse(first, CultureInfo.InvariantCulture).CompareTo(Double.Parse(second, CultureInfo.InvariantCulture))
            Return Decimal.Parse(first, NumberStyles.Float, CultureInfo.InvariantCulture).CompareTo(Decimal.Parse(second, NumberStyles.Float, CultureInfo.InvariantCulture))
        End Function

        Private Shared Function FilterDate(value As String, field As String) As DateTime
            Dim parsed As DateTime
            If Not DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, parsed) Then Throw New ArgumentException(Caption("Enter a date as yyyy-MM-dd for ", "أدخل التاريخ بالصيغة yyyy-MM-dd للحقل ") & field)
            Return parsed.Date
        End Function

        Private Shared Function DateLiteral(value As DateTime) As String
            Return "#" & value.ToString("MM/dd/yyyy HH:mm:ss.fffffff", CultureInfo.InvariantCulture) & "#"
        End Function

        Friend Shared Function BuildRowFilter(criteria As IDictionary(Of String, Tuple(Of String, String))) As String
            Dim expressions As New List(Of String)()
            For Each criterion In criteria
                Dim field = "[" & criterion.Key.Replace("\", "\\").Replace("]", "\]") & "]"
                Dim mode = criterion.Value.Item1
                Dim value = criterion.Value.Item2.Replace("'", "''")
                Select Case mode
                    Case "Null"
                        expressions.Add(field & " IS NULL")
                    Case "NotNull"
                        expressions.Add(field & " IS NOT NULL")
                    Case "Equals"
                        expressions.Add("CONVERT(" & field & ", 'System.String') = '" & value & "'")
                    Case "Contains", "NotContains"
                        Dim pattern As New System.Text.StringBuilder()
                        For Each character As Char In value
                            Select Case character
                                Case "["c, "]"c, "*"c, "%"c
                                    pattern.Append("[" & character & "]")
                                Case Else
                                    pattern.Append(character)
                            End Select
                        Next
                        expressions.Add("CONVERT(" & field & ", 'System.String') " & If(mode = "NotContains", "NOT LIKE", "LIKE") & " '%" & pattern.ToString() & "%'")
                End Select
            Next
            Return String.Join(" AND ", expressions)
        End Function

        Private Sub ExportRecords(sender As Object, e As EventArgs)
            If _data Is Nothing Then Return
            If _selectedFields.Count = 0 Then
                MessageBox.Show(Me, Caption("Select at least one field to export.", "اختر حقلاً واحداً على الأقل للتصدير."), Text)
                Return
            End If
            Using dialog As New SaveFileDialog With {.Filter = "Excel Workbook (*.xlsx)|*.xlsx", .DefaultExt = "xlsx", .AddExtension = True, .OverwritePrompt = True, .FileName = "TableData.xlsx"}
                If dialog.ShowDialog(Me) <> DialogResult.OK Then Return
                RunOperation(Sub()
                                 Dim names = _data.Columns.Cast(Of DataColumn)().Where(Function(column) _selectedFields.Contains(column.ColumnName)).Select(Function(column) column.ColumnName).ToArray()
                                 Using exportData = _data.DefaultView.ToTable(False, names)
                                     _service.ExportToExcel(exportData, dialog.FileName)
                                 End Using
                                 MessageBox.Show(Me, Caption("Export completed.", "اكتمل التصدير."), Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                             End Sub)
            End Using
        End Sub

        Private Sub RunOperation(operation As Action)
            UseWaitCursor = True
            _tables.Enabled = False
            _refresh.Enabled = False
            Try
                operation()
            Catch ex As InvalidOperationException
                _status.Text = Caption("Operation failed.", "فشلت العملية.")
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                _status.Text = Caption("Operation failed.", "فشلت العملية.")
                MessageBox.Show(Me, Caption("Unable to complete the operation. Verify database access and, for export, that Microsoft Excel is installed.", "تعذر إكمال العملية. تحقق من صلاحية الوصول إلى قاعدة البيانات ومن تثبيت Microsoft Excel للتصدير."), Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _tables.Enabled = True
                _refresh.Enabled = True
                UseWaitCursor = False
            End Try
        End Sub
    End Class
End Namespace
