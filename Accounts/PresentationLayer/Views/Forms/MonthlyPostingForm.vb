Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
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
        Private ReadOnly _approveMonth As New Button()
        Private ReadOnly _status As New Label()
        Private ReadOnly _summaryHeader As New Label()
        Private ReadOnly _summary As New DataGridView()
        Private ReadOnly _checklist As New DataGridView()
        Private ReadOnly _checklistHeader As New Label()
        Private ReadOnly _checklistNotesLabel As New Label()
        Private ReadOnly _checklistNotes As New TextBox()
        Private ReadOnly _tabs As New TabControl()
        Private ReadOnly _details As New TextBox()
        Private _lastPreview As DataSet

        Public Sub New()
            InitializeComponent()
            _year.Value = Math.Max(_year.Minimum, Date.Today.Year - 1)
            _month.SelectedIndex = Date.Today.Month - 2
            If _month.SelectedIndex < 0 Then _month.SelectedIndex = 11
            AddHandler _month.SelectedIndexChanged, Sub(sender, e) LoadChecklist()
            _execute.Enabled = False
            LoadChecklist()
        End Sub

        Private Sub InitializeComponent()
            Text = "Monthly Journal Posting"
            StartPosition = FormStartPosition.CenterParent
            ClientSize = New Size(980, 620)
            MinimumSize = New Size(820, 500)

            Dim title As New Label With {.Text = "Monthly Journal Posting", .BackColor = Color.Green, .ForeColor = Color.White, .Font = New Font("Microsoft Sans Serif", 14.25!), .TextAlign = ContentAlignment.MiddleCenter, .Dock = DockStyle.Top, .Height = 36}
            Controls.Add(title)
            Dim commands As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 52, .Padding = New Padding(8), .WrapContents = False}
            commands.Controls.Add(New Label With {.Text = "Year:", .AutoSize = True, .Margin = New Padding(4, 8, 4, 0)})
            _year.Minimum = 2000 : _year.Maximum = 2099 : _year.Width = 70 : _year.Margin = New Padding(4)
            commands.Controls.Add(_year)
            commands.Controls.Add(New Label With {.Text = "Month:", .AutoSize = True, .Margin = New Padding(12, 8, 4, 0)})
            _month.DropDownStyle = ComboBoxStyle.DropDownList : _month.Width = 110 : _month.Margin = New Padding(4)
            _month.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
            commands.Controls.Add(_month)
            _preview.Text = "Preview" : _preview.Width = 100 : _preview.Margin = New Padding(4) : AddHandler _preview.Click, AddressOf Preview_Click : commands.Controls.Add(_preview)
            _execute.Text = "Execute Posting" : _execute.Width = 125 : _execute.Margin = New Padding(4) : AddHandler _execute.Click, AddressOf Execute_Click : commands.Controls.Add(_execute)
            _close.Text = "Close" : _close.Width = 80 : _close.Margin = New Padding(4)
            AddHandler _close.Click, Sub(sender, e) Close()
            commands.Controls.Add(_close)
            _initializeChecklist.Text = "Load Checklist" : _initializeChecklist.Width = 105 : _initializeChecklist.Margin = New Padding(4) : AddHandler _initializeChecklist.Click, AddressOf InitializeChecklist_Click : commands.Controls.Add(_initializeChecklist)
            _completeChecklist.Text = "Complete Item" : _completeChecklist.Width = 105 : _completeChecklist.Margin = New Padding(4) : AddHandler _completeChecklist.Click, AddressOf CompleteChecklist_Click : commands.Controls.Add(_completeChecklist)
            _approveMonth.Text = "Approve Month" : _approveMonth.Width = 105 : _approveMonth.Margin = New Padding(4) : AddHandler _approveMonth.Click, AddressOf ApproveMonth_Click : commands.Controls.Add(_approveMonth)
            _status.Text = "Preview is required before execution." : _status.AutoSize = True : _status.Margin = New Padding(12, 8, 4, 0) : commands.Controls.Add(_status)
            Controls.Add(commands)

            _tabs.Dock = DockStyle.Fill : _tabs.BackColor = Color.White : _tabs.ForeColor = Color.Black
            Dim summaryPage As New TabPage("Journal batches") With {.BackColor = Color.White, .Padding = New Padding(0, 28, 0, 0)}
            ConfigureGrid(_summary)
            _summaryHeader.Text = "JournalCode    Headers    HeadersToPost    EmptyHeaders    Items    ItemsToPost    ZeroAmountItems    CancelledHeaders    Debit    Credit"
            _summaryHeader.Dock = DockStyle.Top
            _summaryHeader.Height = 28
            _summaryHeader.BackColor = Color.LightSteelBlue
            _summaryHeader.ForeColor = Color.Black
            _summaryHeader.Font = New Font("Consolas", 8.25!, FontStyle.Bold)
            _summaryHeader.TextAlign = ContentAlignment.MiddleLeft
            _summaryHeader.AutoEllipsis = True
            summaryPage.Controls.Add(_summary)
            summaryPage.Controls.Add(_summaryHeader)
            _tabs.TabPages.Add(summaryPage)
            Dim checklistPage As New TabPage("Close checklist") With {.BackColor = Color.White, .Padding = New Padding(0, 28, 0, 0)}
            ConfigureGrid(_checklist)
            AddHandler _checklist.SelectionChanged, AddressOf Checklist_SelectionChanged
            _checklistHeader.Text = "FiscalYear    FiscalMonth    Status    ChecklistCode    Completed    CompletedBy    CompletedAt    Notes"
            _checklistHeader.Dock = DockStyle.Top : _checklistHeader.Height = 28 : _checklistHeader.BackColor = Color.LightSteelBlue : _checklistHeader.ForeColor = Color.Black : _checklistHeader.Font = New Font("Consolas", 8.25!, FontStyle.Bold) : _checklistHeader.TextAlign = ContentAlignment.MiddleLeft : _checklistHeader.AutoEllipsis = True
            checklistPage.Controls.Add(_checklist)
            checklistPage.Controls.Add(_checklistHeader)
            _checklistNotesLabel.Text = "Notes for selected checklist item:"
            _checklistNotesLabel.Dock = DockStyle.Bottom : _checklistNotesLabel.Height = 20 : _checklistNotesLabel.BackColor = Color.White : _checklistNotesLabel.ForeColor = Color.Black
            _checklistNotes.Multiline = True : _checklistNotes.ScrollBars = ScrollBars.Vertical : _checklistNotes.Dock = DockStyle.Bottom : _checklistNotes.Height = 48 : _checklistNotes.BackColor = Color.White : _checklistNotes.ForeColor = Color.Black
            checklistPage.Controls.Add(_checklistNotes)
            checklistPage.Controls.Add(_checklistNotesLabel)
            _tabs.TabPages.Add(checklistPage)
            Dim detailsPage As New TabPage("Validation details") With {.BackColor = Color.White}
            _details.Multiline = True : _details.ReadOnly = True : _details.ScrollBars = ScrollBars.Both : _details.Dock = DockStyle.Fill : _details.Font = New Font("Consolas", 9.0!)
            detailsPage.Controls.Add(_details) : _tabs.TabPages.Add(detailsPage)
            Controls.Add(_tabs)
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
                MessageBox.Show("Run Preview before executing posting.", "Monthly Posting", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
            End If
            If MessageBox.Show("Post all valid journals for " & _month.Text & " " & _year.Value.ToString() & "?", "Confirm monthly posting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then LoadPosting(True)
        End Sub

        Private Sub InitializeChecklist_Click(sender As Object, e As EventArgs)
            LoadChecklist()
        End Sub

        Private Sub CompleteChecklist_Click(sender As Object, e As EventArgs)
            If _checklist.CurrentRow Is Nothing Then Return
            Dim code = Convert.ToString(_checklist.CurrentRow.Cells("ChecklistCode").Value)
            If String.IsNullOrWhiteSpace(code) Then Return
            Try
                Dim data = ExecuteChecklistProcedure("dbo.SetMonthlyCloseChecklistItem", code, True, _checklistNotes.Text)
                _checklist.DataSource = data.Tables(data.Tables.Count - 1)
                _checklistNotes.Clear()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Monthly Close Checklist", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub Checklist_SelectionChanged(sender As Object, e As EventArgs)
            If _checklist.CurrentRow Is Nothing OrElse Not _checklist.Columns.Contains("Notes") Then Return
            Dim value = _checklist.CurrentRow.Cells("Notes").Value
            _checklistNotes.Text = If(value Is Nothing OrElse value Is DBNull.Value, "", value.ToString())
        End Sub

        Private Sub ApproveMonth_Click(sender As Object, e As EventArgs)
            Try
                Dim data = ExecuteChecklistProcedure("dbo.ApproveMonthlyClose")
                MessageBox.Show("Month approved. You may now run Monthly Posting.", "Monthly Close", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadChecklist()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Monthly Close", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub LoadChecklist()
            Try
                Dim data = ExecuteChecklistProcedure("dbo.InitializeMonthlyCloseChecklist")
                If data.Tables.Count > 0 Then
                    _checklist.DataSource = data.Tables(0)
                    _tabs.SelectedIndex = 1
                    _status.Text = "Checklist loaded: " & data.Tables(0).Rows.Count.ToString() & " items. Select an item and click Complete Item."
                End If
            Catch ex As Exception
                _status.Text = "Checklist load failed."
            End Try
        End Sub

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
                    ElseIf procedureName.EndsWith("ApproveMonthlyClose", StringComparison.OrdinalIgnoreCase) Then
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
                Dim data = ExecuteProcedure(executePosting)
                _lastPreview = data : BindResults(data)
                If executePosting Then
                    _execute.Enabled = False : _status.Text = "Posting completed. Run Preview again to verify."
                Else
                    Dim blockers = GetInt(data, 0, "BlockingErrors") : Dim headers = GetInt(data, 0, "HeadersToPost") : Dim items = GetInt(data, 0, "ItemsToPost")
                    Dim closeApproved = data.Tables(0).Columns.Contains("MonthlyCloseStatus") AndAlso String.Equals(Convert.ToString(data.Tables(0).Rows(0)("MonthlyCloseStatus")), "Approved", StringComparison.OrdinalIgnoreCase)
                    _execute.Enabled = closeApproved AndAlso blockers = 0 AndAlso (headers > 0 OrElse items > 0)
                    _status.Text = String.Format("Errors: {0}; headers: {1}; items: {2}; close status: {3}", blockers, headers, items, If(closeApproved, "Approved", "Not approved"))
                End If
            Catch ex As Exception
                _execute.Enabled = False : _status.Text = "Posting request failed." : MessageBox.Show(ex.Message, "Monthly Posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
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
            For index As Integer = 2 To data.Tables.Count - 1
                _details.AppendText("Result set " & index.ToString() & Environment.NewLine)
                For Each row As DataRow In data.Tables(index).Rows
                    _details.AppendText(String.Join(" | ", row.ItemArray.Select(Function(value) If(value Is DBNull.Value, "", value.ToString()))) & Environment.NewLine)
                Next
            Next
        End Sub

        Private Shared Function GetInt(data As DataSet, tableIndex As Integer, columnName As String) As Integer
            If data Is Nothing OrElse data.Tables.Count <= tableIndex OrElse data.Tables(tableIndex).Rows.Count = 0 Then Return 0
            Dim value = data.Tables(tableIndex).Rows(0)(columnName) : If value Is DBNull.Value OrElse value Is Nothing Then Return 0
            Return Convert.ToInt32(value)
        End Function
    End Class
End Namespace
