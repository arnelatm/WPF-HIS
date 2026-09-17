Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms
Imports System.Web.Script.Serialization
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Views.Forms

    Public Class AuditHistoryForm
        Inherits Form

        Private ReadOnly _fromDate As New DateTimePicker()
        Private ReadOnly _toDate As New DateTimePicker()
        Private ReadOnly _entity As New ComboBox()
        Private ReadOnly _action As New ComboBox()
        Private ReadOnly _recordId As New TextBox()
        Private ReadOnly _reference As New TextBox()
        Private ReadOnly _search As New Button()
        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _service As New AuditHistoryService()
        Private ReadOnly _securityService As New Service()
        Private ReadOnly _showTechnicalDetails As New CheckBox()

        Private Const TechnicalDetailsSecurityKey As String = "ViewAuditTechnicalDetails"
        Private ReadOnly _canViewTechnicalDetails As Boolean

        Public Sub New()
            Text = If(GlobalVariables.RightToLeftLayout, "سجل تحديث البيانات", "Data Update History")
            Width = 1250
            Height = 700
            StartPosition = FormStartPosition.CenterParent
            RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = GlobalVariables.RightToLeftLayout
            _canViewTechnicalDetails = CanViewTechnicalDetails()
            BuildFilters()
            BuildGrid()
            AddHandler Load, Sub(sender, e) LoadHistory()
        End Sub

        Private Sub BuildFilters()
            Dim panel As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 72, .Padding = New Padding(8), .WrapContents = True}
            _fromDate.Format = DateTimePickerFormat.Short
            _toDate.Format = DateTimePickerFormat.Short
            _fromDate.Value = Date.Today.AddDays(-30)
            _toDate.Value = Date.Today
            AddFilter(panel, "From", _fromDate)
            AddFilter(panel, "To", _toDate)
            AddFilter(panel, "Entity", _entity)
            AddFilter(panel, "Action", _action)
            AddFilter(panel, "Record ID", _recordId)
            AddFilter(panel, "Reference", _reference)
            _showTechnicalDetails.Text = If(GlobalVariables.RightToLeftLayout, "عرض التفاصيل الفنية", "Show Technical Details")
            _showTechnicalDetails.AutoSize = True
            _showTechnicalDetails.Enabled = _canViewTechnicalDetails
            AddHandler _showTechnicalDetails.CheckedChanged, Sub(sender, e) LoadHistory()
            panel.Controls.Add(_showTechnicalDetails)
            _entity.Items.AddRange(New Object() {"", "Account", "Customer", "Supplier", "GeneralJournal", "ApJournal", "ArJournal", "CashReceiptJournal", "CdJournal", "SalesJournal", "ErJournal", "Purchase", "PcJournal"})
            _action.Items.AddRange(New Object() {"", "Insert", "Update", "Delete", "Post", "Approve", "Cancel"})
            _entity.DropDownStyle = ComboBoxStyle.DropDownList
            _action.DropDownStyle = ComboBoxStyle.DropDownList
            _entity.SelectedIndex = 0
            _action.SelectedIndex = 0
            _search.Text = If(GlobalVariables.RightToLeftLayout, "بحث", "Search")
            _search.AutoSize = True
            AddHandler _search.Click, Sub(sender, e) LoadHistory()
            panel.Controls.Add(_search)
            Controls.Add(panel)
        End Sub

        Private Shared Sub AddFilter(panel As FlowLayoutPanel, caption As String, control As Control)
            panel.Controls.Add(New Label With {.Text = caption, .AutoSize = True, .Margin = New Padding(8, 9, 2, 0)})
            control.Width = If(TypeOf control Is DateTimePicker, 100, 125)
            panel.Controls.Add(control)
        End Sub

        Private Sub BuildGrid()
            _grid.Dock = DockStyle.Fill
            _grid.ReadOnly = True
            _grid.AllowUserToAddRows = False
            _grid.AllowUserToDeleteRows = False
            _grid.AutoGenerateColumns = True
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            _grid.MultiSelect = False
            AddHandler _grid.CellDoubleClick, AddressOf GridCellDoubleClick
            Controls.Add(_grid)
            ' Dock Fill must be in front of the top filter panel so it uses
            ' the remaining area instead of hiding its first rows underneath it.
            _grid.BringToFront()
        End Sub

        Private Sub GridCellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
                Return
            End If

            Dim cellValue = _grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            If cellValue Is Nothing OrElse cellValue Is DBNull.Value Then
                Return
            End If

            Dim details As List(Of KeyValuePair(Of String, String)) = Nothing
            If Not TryGetJsonDetails(Convert.ToString(cellValue), details) Then
                Return
            End If

            Using form As New AuditFieldDetailsForm(_grid.Columns(e.ColumnIndex).HeaderText, details)
                form.ShowDialog(Me)
            End Using
        End Sub

        Private Shared Function TryGetJsonDetails(rawValue As String,
                                                   ByRef details As List(Of KeyValuePair(Of String, String))) As Boolean
            If String.IsNullOrWhiteSpace(rawValue) Then
                Return False
            End If

            Dim json = rawValue.Trim()
            If Not json.StartsWith("{") OrElse Not json.EndsWith("}") Then
                Return False
            End If

            Try
                Dim serializer As New JavaScriptSerializer()
                Dim parsedValue = serializer.DeserializeObject(json)
                Dim fields = TryCast(parsedValue, IDictionary)
                If fields Is Nothing Then
                    Return False
                End If

                details = New List(Of KeyValuePair(Of String, String))()
                For Each key As Object In fields.Keys
                    AddJsonDetail(details, Convert.ToString(key), fields(key), serializer)
                Next
                Return details.Count > 0
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Shared Sub AddJsonDetail(details As List(Of KeyValuePair(Of String, String)),
                                          fieldName As String,
                                          value As Object,
                                          serializer As JavaScriptSerializer)
            Dim childFields = TryCast(value, IDictionary)
            If childFields IsNot Nothing AndAlso childFields.Count > 0 Then
                For Each key As Object In childFields.Keys
                    AddJsonDetail(details, fieldName & "." & Convert.ToString(key), childFields(key), serializer)
                Next
                Return
            End If

            details.Add(New KeyValuePair(Of String, String)(fieldName, FormatJsonValue(value, serializer)))
        End Sub

        Private Shared Function FormatJsonValue(value As Object, serializer As JavaScriptSerializer) As String
            If value Is Nothing Then
                Return "null"
            End If

            If TypeOf value Is String Then
                Return Convert.ToString(value)
            End If

            If TypeOf value Is IDictionary OrElse TypeOf value Is IEnumerable Then
                Return serializer.Serialize(value)
            End If

            Return Convert.ToString(value, CultureInfo.CurrentCulture)
        End Function

        Private Sub LoadHistory()
            Try
                Dim fromUtc = _fromDate.Value.Date.ToUniversalTime()
                Dim toUtc = _toDate.Value.Date.AddDays(1).ToUniversalTime()
                Dim recordId As Integer? = Nothing
                Dim parsedId As Integer
                If Integer.TryParse(_recordId.Text.Trim(), parsedId) Then recordId = parsedId
                Dim history = _service.GetHistory(fromUtc, toUtc, Nothing,
                    Convert.ToString(_entity.SelectedItem), Convert.ToString(_action.SelectedItem),
                    recordId, _reference.Text.Trim(), 10000)
                If Not _canViewTechnicalDetails OrElse Not _showTechnicalDetails.Checked Then
                    RemoveTechnicalDetails(history)
                    CollapseNewJournalLifecycle(history)
                Else
                    CollapseCdJournalItemFieldRows(history)
                End If
                ConvertOccurredAtToLocalTime(history)
                _grid.DataSource = history
                If _grid.Columns.Contains("OccurredAtUtc") Then
                    _grid.Columns("OccurredAtUtc").HeaderText = "Occurred At (Local)"
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Audit History", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function CanViewTechnicalDetails() As Boolean
            If UserIsASuperAdmin() Then
                Return True
            End If

            Dim access = _securityService.GetUserSecurityForKey(TechnicalDetailsSecurityKey, GlobalVariables.SecurityGroupIdNo)
            Return access IsNot Nothing AndAlso access.Count > 1 AndAlso Convert.ToBoolean(access(1))
        End Function

        Private Shared Sub RemoveTechnicalDetails(history As DataTable)
            If history Is Nothing OrElse Not history.Columns.Contains("EntityName") Then
                Return
            End If

            For index = history.Rows.Count - 1 To 0 Step -1
                Dim entityName = Convert.ToString(history.Rows(index)("EntityName"))
                If String.Equals(entityName, "GeneralJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "ApJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "ArJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "ErJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "CashReceiptJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "CdJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "ApOpenInvoice", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "PcJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "SalesJournalItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "PurchaseDetail", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "CdOiItem", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "Series", StringComparison.OrdinalIgnoreCase) OrElse
                   String.Equals(entityName, "NumberSeries", StringComparison.OrdinalIgnoreCase) Then
                    history.Rows.RemoveAt(index)
                End If
            Next
        End Sub

        Private Shared Sub CollapseNewJournalLifecycle(history As DataTable)
            If history Is Nothing OrElse Not history.Columns.Contains("EntityName") OrElse
               Not history.Columns.Contains("Action") OrElse Not history.Columns.Contains("RecordIdNo") OrElse
               Not history.Columns.Contains("OccurredAtUtc") Then Return

            For updateIndex = history.Rows.Count - 1 To 0 Step -1
                Dim updateRow = history.Rows(updateIndex)
                If Not String.Equals(Convert.ToString(updateRow("Action")), "Update", StringComparison.OrdinalIgnoreCase) OrElse
                   Not String.Equals(Convert.ToString(updateRow("EntityName")), "CdJournal", StringComparison.OrdinalIgnoreCase) Then Continue For

                For insertIndex = 0 To history.Rows.Count - 1
                    If insertIndex = updateIndex Then Continue For
                    Dim insertRow = history.Rows(insertIndex)
                    If Not String.Equals(Convert.ToString(insertRow("Action")), "Insert", StringComparison.OrdinalIgnoreCase) OrElse
                       Not String.Equals(Convert.ToString(insertRow("EntityName")), "CdJournal", StringComparison.OrdinalIgnoreCase) OrElse
                       Not String.Equals(Convert.ToString(insertRow("RecordIdNo")), Convert.ToString(updateRow("RecordIdNo")), StringComparison.OrdinalIgnoreCase) Then Continue For

                    If Math.Abs((Convert.ToDateTime(insertRow("OccurredAtUtc")) - Convert.ToDateTime(updateRow("OccurredAtUtc"))).TotalSeconds) <= 10 Then
                        history.Rows.RemoveAt(updateIndex)
                        Exit For
                    End If
                Next
            Next
        End Sub

        Private Shared Sub CollapseCdJournalItemFieldRows(history As DataTable)
            If history Is Nothing OrElse Not history.Columns.Contains("AuditEventId") OrElse
               Not history.Columns.Contains("EntityName") OrElse Not history.Columns.Contains("FieldName") OrElse
               Not history.Columns.Contains("OldValue") OrElse Not history.Columns.Contains("NewValue") Then Return

            Dim eventRows As New Dictionary(Of Long, List(Of DataRow))()
            For Each row As DataRow In history.Rows
                If Not String.Equals(Convert.ToString(row("EntityName")), "CdJournalItem", StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If

                Dim auditEventId = Convert.ToInt64(row("AuditEventId"))
                If Not eventRows.ContainsKey(auditEventId) Then
                    eventRows(auditEventId) = New List(Of DataRow)()
                End If
                eventRows(auditEventId).Add(row)
            Next

            Dim serializer As New JavaScriptSerializer()
            Dim rowsToRemove As New List(Of DataRow)()
            For Each rows In eventRows.Values
                Dim snapshotRow = rows.FirstOrDefault(
                    Function(row) String.Equals(Convert.ToString(row("FieldName")), "Record fields", StringComparison.OrdinalIgnoreCase))

                If snapshotRow Is Nothing Then
                    snapshotRow = rows(0)
                    Dim oldValues As New Dictionary(Of String, Object)()
                    Dim newValues As New Dictionary(Of String, Object)()
                    For Each row In rows
                        Dim fieldName = Convert.ToString(row("FieldName"))
                        If Not row.IsNull("OldValue") Then oldValues(fieldName) = ConvertAuditValue(row("OldValue"), serializer)
                        If Not row.IsNull("NewValue") Then newValues(fieldName) = ConvertAuditValue(row("NewValue"), serializer)
                    Next
                    snapshotRow("OldValue") = If(oldValues.Count = 0, CType(DBNull.Value, Object), serializer.Serialize(oldValues))
                    snapshotRow("NewValue") = If(newValues.Count = 0, CType(DBNull.Value, Object), serializer.Serialize(newValues))
                    snapshotRow("FieldName") = "Record fields"
                End If

                For Each row In rows
                    If Not Object.ReferenceEquals(row, snapshotRow) Then rowsToRemove.Add(row)
                Next
            Next

            For Each row In rowsToRemove
                history.Rows.Remove(row)
            Next
        End Sub

        Private Shared Function ConvertAuditValue(value As Object, serializer As JavaScriptSerializer) As Object
            Dim textValue = Convert.ToString(value)
            Try
                Return serializer.DeserializeObject(textValue)
            Catch ex As Exception
                Return textValue
            End Try
        End Function

        Private Shared Sub ConvertOccurredAtToLocalTime(history As DataTable)
            If history Is Nothing OrElse Not history.Columns.Contains("OccurredAtUtc") Then
                Return
            End If

            For Each row As DataRow In history.Rows
                If row.IsNull("OccurredAtUtc") Then
                    Continue For
                End If

                Dim occurredAtUtc = DateTime.SpecifyKind(Convert.ToDateTime(row("OccurredAtUtc")), DateTimeKind.Utc)
                row("OccurredAtUtc") = occurredAtUtc.ToLocalTime()
            Next
        End Sub
End Class

Friend NotInheritable Class AuditFieldDetailsForm
    Inherits Form

    Private ReadOnly _grid As New DataGridView()

    Public Sub New(sourceColumn As String, details As IList(Of KeyValuePair(Of String, String)))
        Text = If(GlobalVariables.RightToLeftLayout,
                  "تفاصيل التدقيق - " & sourceColumn,
                  If(String.IsNullOrWhiteSpace(sourceColumn), "Audit Details", "Audit Details - " & sourceColumn))
        Width = 760
        Height = 520
        MinimumSize = New Size(560, 320)
        StartPosition = FormStartPosition.CenterParent
        MinimizeBox = False
        MaximizeBox = True
        RightToLeft = If(GlobalVariables.RightToLeftLayout, RightToLeft.Yes, RightToLeft.No)
        RightToLeftLayout = GlobalVariables.RightToLeftLayout

        _grid.Dock = DockStyle.Fill
        _grid.ReadOnly = True
        _grid.AllowUserToAddRows = False
        _grid.AllowUserToDeleteRows = False
        _grid.RowHeadersVisible = False
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        _grid.MultiSelect = False
        _grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        _grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        _grid.DefaultCellStyle.Padding = New Padding(4)
        _grid.BackgroundColor = Color.White
        _grid.BorderStyle = BorderStyle.FixedSingle
        _grid.EnableHeadersVisualStyles = False
        _grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        _grid.ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
            .BackColor = Color.FromArgb(221, 235, 247),
            .ForeColor = Color.Black,
            .Font = New Font(_grid.Font, FontStyle.Bold),
            .Alignment = DataGridViewContentAlignment.MiddleLeft,
            .Padding = New Padding(4)
        }
        _grid.RowsDefaultCellStyle = New DataGridViewCellStyle With {
            .BackColor = Color.White,
            .ForeColor = Color.Black,
            .SelectionBackColor = Color.FromArgb(0, 120, 215),
            .SelectionForeColor = Color.White,
            .Padding = New Padding(4)
        }
        _grid.AlternatingRowsDefaultCellStyle = New DataGridViewCellStyle With {
            .BackColor = Color.FromArgb(248, 248, 248),
            .ForeColor = Color.Black,
            .SelectionBackColor = Color.FromArgb(0, 120, 215),
            .SelectionForeColor = Color.White,
            .Padding = New Padding(4)
        }

        Dim fieldColumn = New DataGridViewTextBoxColumn With {
            .Name = "Field",
            .HeaderText = "Field",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 30
        }
        Dim valueColumn = New DataGridViewTextBoxColumn With {
            .Name = "Value",
            .HeaderText = "Value",
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            .FillWeight = 70
        }
        _grid.Columns.Add(fieldColumn)
        _grid.Columns.Add(valueColumn)

        For Each detail In details
            _grid.Rows.Add(detail.Key, detail.Value)
        Next

        Height = Math.Min(700, Math.Max(320, 96 + (_grid.Rows.Count * 28)))
        Controls.Add(_grid)
    End Sub
End Class

End Namespace
