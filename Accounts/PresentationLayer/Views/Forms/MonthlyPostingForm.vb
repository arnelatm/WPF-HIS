Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    Public Class MonthlyPostingForm
        Inherits BFMain

        Private ReadOnly _year As New NumericUpDown()
        Private ReadOnly _month As New ComboBox()
        Private ReadOnly _preview As New Button()
        Private ReadOnly _execute As New Button()
        Private ReadOnly _close As New Button()
        Private ReadOnly _initializeChecklist As New Button()
        Private ReadOnly _completeChecklist As New Button()
        Private ReadOnly _uncompleteChecklist As New Button()
        Private ReadOnly _approveMonth As New Button()
        Private ReadOnly _closeMonth As New Button()
        Private ReadOnly _unpostMonth As New Button()
        Private ReadOnly _uncloseMonth As New Button()
        Private ReadOnly _status As New Label()
        Private ReadOnly _summary As New DataGridView()
        Private ReadOnly _checklist As New DataGridView()
        Private ReadOnly _reversalHistory As New DataGridView()
        Private ReadOnly _checklistNotesLabel As New Label()
        Private ReadOnly _checklistNotes As New TextBox()
        Private ReadOnly _tabs As New TabControl()
        Private ReadOnly _details As New TextBox()
        Private _lastPreview As DataSet
        Private _monthlyCloseStatus As String = "Open"

        Public Sub New()
            InitializeComponent()
            SetDefaultPeriod()
            AddHandler _year.ValueChanged, AddressOf PeriodSelectionChanged
            AddHandler _month.SelectedIndexChanged, AddressOf PeriodSelectionChanged
            _execute.Enabled = False
            _unpostMonth.Enabled = False
            _uncloseMonth.Enabled = False
            LoadChecklist()
        End Sub

        Private Sub SetDefaultPeriod()
            Dim defaultPeriod = Date.Today.AddMonths(-1)
            Try
                Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                    Using command As New SqlCommand("dbo.GetDefaultMonthlyPostingPeriod", connection)
                        command.CommandType = CommandType.StoredProcedure
                        command.CommandTimeout = 30
                        connection.Open()
                        Using reader = command.ExecuteReader()
                            If reader.Read() Then defaultPeriod = New Date(Convert.ToInt32(reader("FiscalYear")), Convert.ToInt32(reader("FiscalMonth")), 1)
                        End Using
                    End Using
                End Using
            Catch
                'The previous calendar month remains a safe fallback when the database helper is unavailable.
            End Try
            _year.Value = Math.Min(_year.Maximum, Math.Max(_year.Minimum, defaultPeriod.Year))
            _month.SelectedIndex = defaultPeriod.Month - 1
        End Sub

        Private Sub InitializeComponent()
            Text = "Monthly Journal Posting"
            StartPosition = FormStartPosition.CenterParent
            ClientSize = New Size(980, 620)
            MinimumSize = New Size(820, 500)

            Dim title As New Label With {.Text = "Monthly Journal Posting", .BackColor = Color.Green, .ForeColor = Color.White, .Font = New Font("Microsoft Sans Serif", 14.25!), .TextAlign = ContentAlignment.MiddleCenter, .Dock = DockStyle.Top, .Height = 36}
            Dim commandArea As New Panel With {.Dock = DockStyle.Top, .Height = 126, .BackColor = Color.Aquamarine}
            Dim commands As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 42, .Padding = New Padding(8, 6, 8, 2), .WrapContents = False}
            commands.Controls.Add(New Label With {.Text = "Year:", .AutoSize = True, .Margin = New Padding(4, 8, 4, 0)})
            _year.Minimum = 2000 : _year.Maximum = 2099 : _year.Width = 70 : _year.Margin = New Padding(4)
            commands.Controls.Add(_year)
            commands.Controls.Add(New Label With {.Text = "Month:", .AutoSize = True, .Margin = New Padding(12, 8, 4, 0)})
            _month.DropDownStyle = ComboBoxStyle.DropDownList : _month.Width = 110 : _month.Margin = New Padding(4)
            _month.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
            commands.Controls.Add(_month)
            _preview.Text = "Preview" : _preview.Width = 100 : _preview.Margin = New Padding(4) : AddHandler _preview.Click, AddressOf Preview_Click : commands.Controls.Add(_preview)
            _execute.Text = "Execute Posting" : _execute.Width = 125 : _execute.Margin = New Padding(4) : AddHandler _execute.Click, AddressOf Execute_Click : commands.Controls.Add(_execute)
            _close.Text = "Exit" : _close.Width = 80 : _close.Margin = New Padding(4)
            AddHandler _close.Click, Sub(sender, e) Close()
            commands.Controls.Add(_close)
            Dim closeCommands As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 42, .Padding = New Padding(8, 2, 8, 2), .WrapContents = False}
            _initializeChecklist.Text = "Load Checklist" : _initializeChecklist.Width = 105 : _initializeChecklist.Margin = New Padding(4) : AddHandler _initializeChecklist.Click, AddressOf InitializeChecklist_Click : closeCommands.Controls.Add(_initializeChecklist)
            _completeChecklist.Text = "Complete Item" : _completeChecklist.Width = 105 : _completeChecklist.Margin = New Padding(4) : AddHandler _completeChecklist.Click, AddressOf CompleteChecklist_Click : closeCommands.Controls.Add(_completeChecklist)
            _uncompleteChecklist.Text = "Uncomplete Item" : _uncompleteChecklist.Width = 115 : _uncompleteChecklist.Margin = New Padding(4) : AddHandler _uncompleteChecklist.Click, AddressOf UncompleteChecklist_Click : closeCommands.Controls.Add(_uncompleteChecklist)
            _approveMonth.Text = "Approve Month" : _approveMonth.Width = 105 : _approveMonth.Margin = New Padding(4) : AddHandler _approveMonth.Click, AddressOf ApproveMonth_Click : closeCommands.Controls.Add(_approveMonth)
            _closeMonth.Text = "Close Month" : _closeMonth.Width = 105 : _closeMonth.Margin = New Padding(4) : AddHandler _closeMonth.Click, AddressOf CloseMonth_Click : closeCommands.Controls.Add(_closeMonth)
            _status.Text = "Preview is required before execution." : _status.AutoSize = True : _status.Margin = New Padding(12, 8, 4, 0) : closeCommands.Controls.Add(_status)
            Dim reversalCommands As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .Padding = New Padding(8, 2, 8, 6), .WrapContents = False}
            _unpostMonth.Text = "Unpost Month" : _unpostMonth.Width = 105 : _unpostMonth.Margin = New Padding(4) : AddHandler _unpostMonth.Click, AddressOf UnpostMonth_Click : reversalCommands.Controls.Add(_unpostMonth)
            _uncloseMonth.Text = "Unclose Month" : _uncloseMonth.Width = 105 : _uncloseMonth.Margin = New Padding(4) : AddHandler _uncloseMonth.Click, AddressOf UncloseMonth_Click : reversalCommands.Controls.Add(_uncloseMonth)
            reversalCommands.Controls.Add(New Label With {.Text = "Only the latest month can be reversed. Unpost it before unclosing it.", .AutoSize = True, .Margin = New Padding(12, 8, 4, 0)})
            commandArea.Controls.Add(reversalCommands)
            commandArea.Controls.Add(closeCommands)
            commandArea.Controls.Add(commands)
            Controls.Add(commandArea)
            Controls.Add(title)

            _tabs.Dock = DockStyle.Fill : _tabs.BackColor = Color.White : _tabs.ForeColor = Color.Black
            Dim summaryPage As New TabPage("Journal batches") With {.BackColor = Color.White}
            ConfigureGrid(_summary)
            summaryPage.Controls.Add(_summary)
            _tabs.TabPages.Add(summaryPage)
            Dim checklistPage As New TabPage("Close checklist") With {.BackColor = Color.White}
            ConfigureGrid(_checklist)
            AddHandler _checklist.SelectionChanged, AddressOf Checklist_SelectionChanged
            checklistPage.Controls.Add(_checklist)
            _checklistNotesLabel.Text = "Notes for selected checklist item:"
            _checklistNotesLabel.Dock = DockStyle.Bottom : _checklistNotesLabel.Height = 20 : _checklistNotesLabel.BackColor = Color.White : _checklistNotesLabel.ForeColor = Color.Black
            _checklistNotes.Multiline = True : _checklistNotes.ScrollBars = ScrollBars.Vertical : _checklistNotes.Dock = DockStyle.Bottom : _checklistNotes.Height = 48 : _checklistNotes.BackColor = Color.White : _checklistNotes.ForeColor = Color.Black
            checklistPage.Controls.Add(_checklistNotes)
            checklistPage.Controls.Add(_checklistNotesLabel)
            _tabs.TabPages.Add(checklistPage)
            Dim reversalHistoryPage As New TabPage("Reversal history") With {.BackColor = Color.White}
            ConfigureGrid(_reversalHistory)
            reversalHistoryPage.Controls.Add(_reversalHistory)
            _tabs.TabPages.Add(reversalHistoryPage)
            Dim detailsPage As New TabPage("Validation details") With {.BackColor = Color.White}
            _details.Multiline = True : _details.ReadOnly = True : _details.ScrollBars = ScrollBars.Both : _details.Dock = DockStyle.Fill : _details.Font = New Font("Consolas", 9.0!)
            detailsPage.Controls.Add(_details) : _tabs.TabPages.Add(detailsPage)
            Controls.Add(_tabs)
            Controls.SetChildIndex(_tabs, 0)
        End Sub

        Private Shared Sub ConfigureGrid(grid As DataGridView)
            grid.Dock = DockStyle.Fill : grid.ReadOnly = True : grid.AllowUserToAddRows = False : grid.AllowUserToDeleteRows = False
            grid.AutoGenerateColumns = True : grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells : grid.RowHeadersVisible = False
            grid.ColumnHeadersVisible = True : grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing : grid.ColumnHeadersHeight = 28
            grid.BackgroundColor = Color.White : grid.ForeColor = Color.Black : grid.GridColor = Color.Silver : grid.EnableHeadersVisualStyles = False
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue : grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black : grid.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold)
            grid.DefaultCellStyle.BackColor = Color.White : grid.DefaultCellStyle.ForeColor = Color.Black
        End Sub

        Private Sub Preview_Click(sender As Object, e As EventArgs)
            LoadPosting(False)
        End Sub

        Private Sub Execute_Click(sender As Object, e As EventArgs)
            If _lastPreview Is Nothing OrElse _lastPreview.Tables.Count = 0 Then
                Messaging.Show(True, "MsgRunPreviewBeforeExecution", "Run Preview before executing posting.", "Monthly Posting", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
            End If
            If Messaging.Show(True, "MsgConfirmMonthlyPosting", "Post all valid journals for {month} {year}?", "Confirm monthly posting", {"month", _month.Text, "year", _year.Value.ToString()}, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then LoadPosting(True)
        End Sub

        Private Sub InitializeChecklist_Click(sender As Object, e As EventArgs)
            LoadChecklist()
        End Sub

        Private Sub PeriodSelectionChanged(sender As Object, e As EventArgs)
            _lastPreview = Nothing
            _summary.DataSource = Nothing
            _details.Clear()
            _execute.Enabled = False
            _unpostMonth.Enabled = False
            _uncloseMonth.Enabled = False
            LoadChecklist()
        End Sub

        Private Sub CompleteChecklist_Click(sender As Object, e As EventArgs)
            If _checklist.CurrentRow Is Nothing Then Return
            Dim code = Convert.ToString(_checklist.CurrentRow.Cells("ChecklistCode").Value)
            If String.IsNullOrWhiteSpace(code) Then Return
            If String.IsNullOrWhiteSpace(_checklistNotes.Text) Then
                Messaging.Show(True, "MsgEnterChecklistNote", "Enter a note before completing this checklist item.", "Monthly Close Checklist", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _checklistNotes.Focus()
                Return
            End If
            Try
                Dim data = ExecuteChecklistProcedure("dbo.SetMonthlyCloseChecklistItem", code, True, _checklistNotes.Text)
                _checklist.DataSource = data.Tables(data.Tables.Count - 1)
                _checklistNotes.Clear()
            Catch ex As Exception
                Messaging.Show(True, "MsgMonthlyCloseChecklistFailed", "Checklist operation failed: {details}", "Monthly Close Checklist", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub UncompleteChecklist_Click(sender As Object, e As EventArgs)
            If _checklist.CurrentRow Is Nothing Then Return
            Dim code = Convert.ToString(_checklist.CurrentRow.Cells("ChecklistCode").Value)
            If String.IsNullOrWhiteSpace(code) Then Return
            If String.IsNullOrWhiteSpace(_checklistNotes.Text) Then
                Messaging.Show(True, "MsgEnterChecklistCorrectionReason", "Enter the correction reason in Notes before uncompleting this checklist item.", "Monthly Close Checklist", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _checklistNotes.Focus()
                Return
            End If
            If Messaging.Show(True, "MsgConfirmChecklistUncomplete", "Uncomplete checklist item {item}? An Approved month will return to Open and must be approved again.", "Confirm checklist correction", {"item", code}, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
            Try
                ExecuteChecklistProcedure("dbo.UncompleteMonthlyCloseChecklistItem", code, False, _checklistNotes.Text)
                _lastPreview = Nothing
                _execute.Enabled = False
                _summary.DataSource = Nothing
                _details.Clear()
                LoadChecklist()
                Messaging.Show(True, "MsgChecklistItemUncompleted", "Checklist item {item} was uncompleted. Correct it, complete it again, and then approve the month.", "Monthly Close Checklist", {"item", code}, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Messaging.Show(True, "MsgChecklistItemUncompleteFailed", "Checklist item could not be uncompleted: {details}", "Monthly Close Checklist", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub Checklist_SelectionChanged(sender As Object, e As EventArgs)
            If _checklist.CurrentRow Is Nothing OrElse Not _checklist.Columns.Contains("Notes") Then
                UpdateChecklistItemButtons()
                Return
            End If
            Dim value = _checklist.CurrentRow.Cells("Notes").Value
            _checklistNotes.Text = If(value Is Nothing OrElse value Is DBNull.Value, "", value.ToString())
            UpdateChecklistItemButtons()
        End Sub

        Private Sub ApproveMonth_Click(sender As Object, e As EventArgs)
            Try
                Dim data = ExecuteChecklistProcedure("dbo.ApproveMonthlyClose")
                Messaging.Show(True, "MsgMonthApproved", "Month approved. Run Preview, then close the month before executing Monthly Posting.", "Monthly Close", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadChecklist()
            Catch ex As Exception
                Messaging.Show(True, "MsgMonthlyCloseChecklistFailed", "Checklist operation failed: {details}", "Monthly Close", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub CloseMonth_Click(sender As Object, e As EventArgs)
            Dim periodEnd = New Date(Convert.ToInt32(_year.Value), _month.SelectedIndex + 1, 1).AddMonths(1).AddDays(-1)
            If Messaging.Show(True, "MsgConfirmMonthlyClose", "Close {month} {year} through {periodEnd}? Transactions through this date can no longer be added, edited, or deleted.", "Confirm monthly close", {"month", _month.Text, "year", _year.Value.ToString(), "periodEnd", periodEnd.ToShortDateString()}, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
            Try
                Cursor = Cursors.WaitCursor
                Dim data = ExecuteChecklistProcedure("dbo.CloseMonthlyPeriod")
                Dim lockedThrough = periodEnd
                If data.Tables.Count > 0 AndAlso data.Tables(0).Rows.Count > 0 AndAlso data.Tables(0).Columns.Contains("PeriodLockedThrough") Then
                    lockedThrough = Convert.ToDateTime(data.Tables(0).Rows(0)("PeriodLockedThrough"))
                End If
                Messaging.Show(True, "MsgMonthClosed", "Month closed. Transactions are locked through {periodEnd}.", "Monthly Close", {"periodEnd", lockedThrough.ToShortDateString()}, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadChecklist()
                LoadPosting(False)
            Catch ex As Exception
                Messaging.Show(True, "MsgMonthlyCloseFailed", "Monthly close failed: {details}", "Monthly Close", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub UnpostMonth_Click(sender As Object, e As EventArgs)
            If Messaging.Show(True, "MsgConfirmMonthlyUnpost", "Unpost {month} {year}? Only journal records changed by the latest monthly posting run will be restored.", "Confirm monthly unpost", {"month", _month.Text, "year", _year.Value.ToString()}, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
            Try
                Cursor = Cursors.WaitCursor
                Dim data = ExecuteChecklistProcedure("dbo.UnpostMonthlyJournalEntries")
                Dim headers = GetInt(data, 0, "HeadersChanged")
                Dim items = GetInt(data, 0, "ItemsChanged")
                Messaging.Show(True, "MsgMonthUnposted", "Month unposted: {headers} headers and {items} items restored. You may now unclose this month.", "Monthly Unpost", {"headers", headers.ToString(), "items", items.ToString()}, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadChecklist()
                LoadPosting(False)
            Catch ex As Exception
                Messaging.Show(True, "MsgMonthlyUnpostFailed", "Monthly unpost failed: {details}", "Monthly Unpost", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub UncloseMonth_Click(sender As Object, e As EventArgs)
            If Messaging.Show(True, "MsgConfirmMonthlyUnclose", "Unclose {month} {year}? The closed-period lock will move back one month.", "Confirm monthly unclose", {"month", _month.Text, "year", _year.Value.ToString()}, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
            Try
                Cursor = Cursors.WaitCursor
                Dim data = ExecuteChecklistProcedure("dbo.UncloseMonthlyPeriod")
                Dim lockedThrough As Date
                If data.Tables.Count > 0 AndAlso data.Tables(0).Rows.Count > 0 AndAlso data.Tables(0).Columns.Contains("PeriodLockedThrough") Then lockedThrough = Convert.ToDateTime(data.Tables(0).Rows(0)("PeriodLockedThrough"))
                Messaging.Show(True, "MsgMonthUnclosed", "Month unclosed. Transactions are now locked through {periodEnd}.", "Monthly Unclose", {"periodEnd", lockedThrough.ToShortDateString()}, MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadChecklist()
                LoadPosting(False)
            Catch ex As Exception
                Messaging.Show(True, "MsgMonthlyUncloseFailed", "Monthly unclose failed: {details}", "Monthly Unclose", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub LoadChecklist()
            Try
                Dim data = ExecuteChecklistProcedure("dbo.InitializeMonthlyCloseChecklist")
                If data.Tables.Count > 0 Then
                    _checklist.DataSource = data.Tables(0)
                    UpdateMonthlyCloseButtons(data.Tables(0))
                    LoadReversalHistory()
                    _tabs.SelectedIndex = 1
                    Dim checklistStatus = "Checklist loaded: {itemCount} items. Select an item and click Complete Item."
                    Dim checklistCaption = "Monthly Close Checklist"
                    Messaging.GetMessage(True, "MsgChecklistLoaded", checklistStatus, checklistCaption)
                    _status.Text = Messaging.ReplaceValues(checklistStatus, {"itemCount", data.Tables(0).Rows.Count.ToString()})
                End If
            Catch ex As Exception
                _status.Text = Messaging.TranslateCaption("Checklist load failed.")
                _completeChecklist.Enabled = False
                _uncompleteChecklist.Enabled = False
                _approveMonth.Enabled = False
                _closeMonth.Enabled = False
                _unpostMonth.Enabled = False
                _uncloseMonth.Enabled = False
            End Try
        End Sub

        Private Sub LoadReversalHistory()
            Try
                Dim data = ExecuteChecklistProcedure("dbo.GetMonthlyCloseReversalHistory")
                _reversalHistory.DataSource = If(data.Tables.Count > 0, data.Tables(0), Nothing)
            Catch
                _reversalHistory.DataSource = Nothing
            End Try
        End Sub

        Private Sub UpdateMonthlyCloseButtons(periodData As DataTable)
            _monthlyCloseStatus = "Open"
            If periodData IsNot Nothing AndAlso periodData.Rows.Count > 0 AndAlso periodData.Columns.Contains("Status") Then _monthlyCloseStatus = Convert.ToString(periodData.Rows(0)("Status"))
            UpdateChecklistItemButtons()
            _approveMonth.Enabled = String.Equals(_monthlyCloseStatus, "Open", StringComparison.OrdinalIgnoreCase)
            _closeMonth.Enabled = String.Equals(_monthlyCloseStatus, "Approved", StringComparison.OrdinalIgnoreCase) AndAlso PreviewHasNoBlockingErrors()
            _unpostMonth.Enabled = PreviewAllows("CanUnpost")
            _uncloseMonth.Enabled = PreviewAllows("CanUnclose")
        End Sub

        Private Sub UpdateChecklistItemButtons()
            Dim rowIsCompleted = False
            If _checklist.CurrentRow IsNot Nothing AndAlso _checklist.Columns.Contains("Completed") Then
                Dim value = _checklist.CurrentRow.Cells("Completed").Value
                rowIsCompleted = value IsNot Nothing AndAlso value IsNot DBNull.Value AndAlso Convert.ToBoolean(value)
            End If
            _completeChecklist.Enabled = String.Equals(_monthlyCloseStatus, "Open", StringComparison.OrdinalIgnoreCase) AndAlso Not rowIsCompleted
            _uncompleteChecklist.Enabled = (String.Equals(_monthlyCloseStatus, "Open", StringComparison.OrdinalIgnoreCase) OrElse String.Equals(_monthlyCloseStatus, "Approved", StringComparison.OrdinalIgnoreCase)) AndAlso rowIsCompleted
        End Sub

        Private Function PreviewHasNoBlockingErrors() As Boolean
            Return _lastPreview IsNot Nothing AndAlso _lastPreview.Tables.Count > 0 AndAlso _lastPreview.Tables(0).Rows.Count > 0 AndAlso GetInt(_lastPreview, 0, "BlockingErrors") = 0
        End Function

        Private Function PreviewAllows(columnName As String) As Boolean
            If _lastPreview Is Nothing OrElse _lastPreview.Tables.Count = 0 OrElse _lastPreview.Tables(0).Rows.Count = 0 OrElse Not _lastPreview.Tables(0).Columns.Contains(columnName) Then Return False
            Dim value = _lastPreview.Tables(0).Rows(0)(columnName)
            Return value IsNot DBNull.Value AndAlso Convert.ToBoolean(value)
        End Function

        Private Function ExecuteChecklistProcedure(procedureName As String, Optional checklistCode As String = Nothing, Optional completed As Boolean = False, Optional notes As String = Nothing) As DataSet
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand(procedureName, connection)
                    command.CommandType = CommandType.StoredProcedure : command.CommandTimeout = 120
                    command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = Convert.ToInt32(_year.Value)
                    command.Parameters.Add("@FiscalMonth", SqlDbType.Int).Value = _month.SelectedIndex + 1
                    If procedureName.EndsWith("SetMonthlyCloseChecklistItem", StringComparison.OrdinalIgnoreCase) Then
                        command.Parameters.Add("@ChecklistCode", SqlDbType.VarChar, 40).Value = checklistCode
                        command.Parameters.Add("@Completed", SqlDbType.Bit).Value = completed
                        command.Parameters.Add("@Notes", SqlDbType.NVarChar, 500).Value = If(notes, "")
                        command.Parameters.Add("@ApplicationUser", SqlDbType.NVarChar, 128).Value = GlobalVariables.UserName
                    ElseIf procedureName.EndsWith("UncompleteMonthlyCloseChecklistItem", StringComparison.OrdinalIgnoreCase) Then
                        command.Parameters.Add("@ChecklistCode", SqlDbType.VarChar, 40).Value = checklistCode
                        command.Parameters.Add("@Reason", SqlDbType.NVarChar, 500).Value = If(notes, "")
                        command.Parameters.Add("@ApplicationUser", SqlDbType.NVarChar, 128).Value = GlobalVariables.UserName
                    ElseIf procedureName.EndsWith("ApproveMonthlyClose", StringComparison.OrdinalIgnoreCase) OrElse procedureName.EndsWith("CloseMonthlyPeriod", StringComparison.OrdinalIgnoreCase) OrElse procedureName.EndsWith("UnpostMonthlyJournalEntries", StringComparison.OrdinalIgnoreCase) OrElse procedureName.EndsWith("UncloseMonthlyPeriod", StringComparison.OrdinalIgnoreCase) Then
                        command.Parameters.Add("@ApplicationUser", SqlDbType.NVarChar, 128).Value = GlobalVariables.UserName
                    End If
                    Using adapter As New SqlDataAdapter(command)
                        Dim result As New DataSet() : adapter.Fill(result) : Return result
                    End Using
                End Using
            End Using
        End Function

        Private Sub LoadPosting(executePosting As Boolean)
            Try
                Cursor = Cursors.WaitCursor
                If Not executePosting Then _lastPreview = Nothing
                Dim data = ExecuteProcedure(executePosting)
                _lastPreview = data : BindResults(data)
                If executePosting Then
                    _execute.Enabled = False : _unpostMonth.Enabled = False : _uncloseMonth.Enabled = False : _status.Text = Messaging.TranslateCaption("Posting completed. Run Preview again to verify.")
                Else
                    Dim blockers = GetInt(data, 0, "BlockingErrors") : Dim headers = GetInt(data, 0, "HeadersToPost") : Dim items = GetInt(data, 0, "ItemsToPost")
                    Dim headersPosted = GetInt(data, 0, "HeadersPosted") : Dim itemsPosted = GetInt(data, 0, "ItemsPosted")
                    Dim monthlyCloseStatus = If(data.Tables(0).Columns.Contains("MonthlyCloseStatus"), Convert.ToString(data.Tables(0).Rows(0)("MonthlyCloseStatus")), "Open")
                    Dim periodEnd = New Date(Convert.ToInt32(_year.Value), _month.SelectedIndex + 1, 1).AddMonths(1).AddDays(-1)
                    Dim periodLocked = data.Tables(0).Columns.Contains("PeriodLockedThrough") AndAlso data.Tables(0).Rows(0)("PeriodLockedThrough") IsNot DBNull.Value AndAlso Convert.ToDateTime(data.Tables(0).Rows(0)("PeriodLockedThrough")) >= periodEnd
                    Dim closeCompleted = String.Equals(monthlyCloseStatus, "Closed", StringComparison.OrdinalIgnoreCase)
                    _execute.Enabled = closeCompleted AndAlso periodLocked AndAlso blockers = 0 AndAlso (headers > 0 OrElse items > 0)
                    UpdateMonthlyCloseButtonsFromPreview(monthlyCloseStatus)
                    Dim closeStatus = Messaging.TranslateCaption(monthlyCloseStatus)
                    Dim postingStatus = "Errors: {errors}; to post: {headers} headers/{items} items; posted: {headersPosted} headers/{itemsPosted} items; close status: {closeStatus}"
                    Dim postingCaption = "Monthly Journal Posting"
                    Messaging.GetMessage(True, "MsgMonthlyPostingStatus", postingStatus, postingCaption)
                    _status.Text = Messaging.ReplaceValues(postingStatus, {"errors", blockers.ToString(), "headers", headers.ToString(), "items", items.ToString(), "headersPosted", headersPosted.ToString(), "itemsPosted", itemsPosted.ToString(), "closeStatus", closeStatus})
                End If
            Catch ex As Exception
                _lastPreview = Nothing : _execute.Enabled = False : _closeMonth.Enabled = False : _unpostMonth.Enabled = False : _uncloseMonth.Enabled = False : _status.Text = Messaging.TranslateCaption("Posting request failed.") : Messaging.Show(True, "MsgMonthlyPostingRequestFailed", "Posting request failed: {details}", "Monthly Posting", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub UpdateMonthlyCloseButtonsFromPreview(closeStatus As String)
            _monthlyCloseStatus = closeStatus
            _closeMonth.Enabled = String.Equals(_monthlyCloseStatus, "Approved", StringComparison.OrdinalIgnoreCase) AndAlso PreviewHasNoBlockingErrors()
            _unpostMonth.Enabled = PreviewAllows("CanUnpost")
            _uncloseMonth.Enabled = PreviewAllows("CanUnclose")
        End Sub

        Private Function ExecuteProcedure(executePosting As Boolean) As DataSet
            Dim procedureName = If(executePosting, "dbo.PostMonthlyJournalEntries", "dbo.PreviewMonthlyJournalPosting")
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand(procedureName, connection)
                    command.CommandType = CommandType.StoredProcedure : command.CommandTimeout = 120
                    command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = Convert.ToInt32(_year.Value)
                    command.Parameters.Add("@Month", SqlDbType.Int).Value = _month.SelectedIndex + 1
                    If executePosting Then command.Parameters.Add("@ExecutePosting", SqlDbType.Bit).Value = True
                    Using adapter As New SqlDataAdapter(command)
                        Dim result As New DataSet() : adapter.Fill(result) : Return result
                    End Using
                End Using
            End Using
        End Function

        Private Sub BindResults(data As DataSet)
            _summary.DataSource = Nothing : _details.Clear()
            If data Is Nothing OrElse data.Tables.Count = 0 Then Return
            _summary.DataSource = data.Tables(If(data.Tables.Count > 1, 1, 0))
            If data.Tables.Count < 4 Then Return

            AppendValidationDetails("Unbalanced journal batches", data.Tables(2))
            AppendValidationDetails("Invalid journal items", data.Tables(3))
            If data.Tables(2).Rows.Count = 0 AndAlso data.Tables(3).Rows.Count = 0 Then
                _details.Text = Messaging.TranslateCaption("No validation errors found. The journals are balanced and all journal items passed validation.")
            End If
        End Sub

        Private Sub AppendValidationDetails(title As String, table As DataTable)
            If table Is Nothing OrElse table.Rows.Count = 0 Then Return
            If _details.TextLength > 0 Then _details.AppendText(Environment.NewLine)
            _details.AppendText(Messaging.TranslateCaption(title) & Environment.NewLine)
            _details.AppendText(String.Join(" | ", table.Columns.Cast(Of DataColumn)().Select(Function(column) column.ColumnName)) & Environment.NewLine)
            For Each row As DataRow In table.Rows
                _details.AppendText(String.Join(" | ", row.ItemArray.Select(Function(value) If(value Is DBNull.Value, "", value.ToString()))) & Environment.NewLine)
            Next
        End Sub

        Private Shared Function GetInt(data As DataSet, tableIndex As Integer, columnName As String) As Integer
            If data Is Nothing OrElse data.Tables.Count <= tableIndex OrElse data.Tables(tableIndex).Rows.Count = 0 Then Return 0
            Dim value = data.Tables(tableIndex).Rows(0)(columnName) : If value Is DBNull.Value OrElse value Is Nothing Then Return 0
            Return Convert.ToInt32(value)
        End Function
    End Class
End Namespace
