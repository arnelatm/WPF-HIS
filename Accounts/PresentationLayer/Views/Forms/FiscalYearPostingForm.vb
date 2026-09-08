Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms

    Partial Public Class FiscalYearPostingForm
        Inherits BFMain

        Private ReadOnly _issuesGrid As New DataGridView()
        Private ReadOnly _transferGrid As New DataGridView()
        Private ReadOnly _openingGrid As New DataGridView()
        Private ReadOnly _reconciliationGrid As New DataGridView()
        Private ReadOnly _accountReviewGrid As New DataGridView()
        Private ReadOnly _inventoryGrid As New DataGridView()
        Private ReadOnly _historyGrid As New DataGridView()
        Private ReadOnly _acknowledgeWarnings As New CheckBox()
        Private ReadOnly _approvalNotes As New TextBox()
        Private _lastPreview As DataSet

        Public Sub New()
            InitializeComponent()
            ConfigureFiscalYearEndScreen()
            SetDefaultFiscalYear()
            AddHandler _previewButton.Click, AddressOf PreviewButton_Click
            AddHandler _executeButton.Click, AddressOf ExecuteButton_Click
            AddHandler _closeButton.Click, Sub(sender, e) Close()
            AddHandler _monthlyButton.Click,
                Sub(sender, e)
                    Using monthlyForm As New MonthlyPostingForm()
                        monthlyForm.ShowDialog(Me)
                    End Using
                End Sub
            AddHandler _fiscalYear.ValueChanged, AddressOf FiscalYearChanged
            AddHandler _acknowledgeWarnings.CheckedChanged, Sub(sender, e) UpdateFinalizeAvailability()
            AddHandler _approvalNotes.TextChanged, Sub(sender, e) UpdateFinalizeAvailability()
            AddHandler Shown, AddressOf PositionFiscalYearTabs
            LoadHistory()
        End Sub

        Private Sub ConfigureFiscalYearEndScreen()
            Text = "Fiscal Year End"
            ClientSize = New Size(1180, 700)
            MinimumSize = New Size(980, 560)
            _header.Text = "Fiscal Year End"
            _previewButton.Text = "Run Year-End Preview"
            _previewButton.Width = 155
            _executeButton.Text = "Finalize Fiscal Year"
            _executeButton.Width = 150
            _executeButton.Enabled = False
            _monthlyButton.Text = "Monthly Close"
            _commandPanel.Height = 94
            _commandPanel.WrapContents = True
            _commandPanel.AutoScroll = True
            _statusLabel.Text = "Run Preview and review every tab before finalization."

            _acknowledgeWarnings.Text = "I reviewed inventory, VAT, Zakah/tax, and existing next-year activity."
            _acknowledgeWarnings.AutoSize = True
            _acknowledgeWarnings.Margin = New Padding(12, 8, 4, 0)
            _commandPanel.Controls.Add(_acknowledgeWarnings)
            _commandPanel.Controls.Add(New Label With {.Text = "Approval notes:", .AutoSize = True, .Margin = New Padding(12, 8, 4, 0)})
            _approvalNotes.Width = 280
            _approvalNotes.Margin = New Padding(4)
            _commandPanel.Controls.Add(_approvalNotes)

            _tabs.Multiline = True
            _tabs.SizeMode = TabSizeMode.Fixed
            _tabs.ItemSize = New Size(160, 28)
            _tabs.SendToBack()
            _summaryPage.Text = "Readiness"
            _journalPage.Text = "Closing entries"
            _detailsPage.Text = "Validation issues"
            _detailsPage.Controls.Clear()
            ConfigureGrid(_issuesGrid)
            _detailsPage.Controls.Add(_issuesGrid)

            AddGridPage("Income Summary transfer", _transferGrid)
            AddGridPage("2026 opening balances", _openingGrid)
            AddGridPage("Reconciliation", _reconciliationGrid)
            AddGridPage("Account review", _accountReviewGrid)
            AddGridPage("Inventory roll-forward", _inventoryGrid)
            AddGridPage("Close history", _historyGrid)
            _tabs.SelectedTab = _summaryPage
        End Sub

        Private Sub PositionFiscalYearTabs(sender As Object, e As EventArgs)
            Dim top = Math.Max(_header.Bottom, _commandPanel.Bottom) + 2
            _tabs.Dock = DockStyle.None
            _tabs.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
            _tabs.SetBounds(0, top, ClientSize.Width, Math.Max(100, ClientSize.Height - top))
            _tabs.BringToFront()
        End Sub

        Private Shared Sub ConfigureGrid(grid As DataGridView)
            grid.Dock = DockStyle.Fill
            grid.ReadOnly = True
            grid.AllowUserToAddRows = False
            grid.AllowUserToDeleteRows = False
            grid.AutoGenerateColumns = True
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            grid.RowHeadersVisible = False
            grid.BackgroundColor = Color.White
            grid.ForeColor = Color.Black
            grid.GridColor = Color.Silver
            grid.EnableHeadersVisualStyles = False
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            grid.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold)
        End Sub

        Private Sub AddGridPage(caption As String, grid As DataGridView)
            ConfigureGrid(grid)
            Dim page As New TabPage(caption) With {.BackColor = Color.White, .ForeColor = Color.Black}
            page.Controls.Add(grid)
            _tabs.TabPages.Add(page)
        End Sub

        Private Sub SetDefaultFiscalYear()
            Dim fiscalYear = Date.Today.Year - 1
            Try
                Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                    Using command As New SqlCommand("SELECT YEAR(LastPostingDate) + 1 FROM dbo.LastPosting WHERE TransactionName = 'LastFiscalYearEnd'", connection)
                        connection.Open()
                        Dim value = command.ExecuteScalar()
                        If value IsNot Nothing AndAlso value IsNot DBNull.Value Then fiscalYear = Convert.ToInt32(value)
                    End Using
                End Using
            Catch
                'The previous calendar year remains the fallback when the control record is unavailable.
            End Try
            _fiscalYear.Value = Math.Min(_fiscalYear.Maximum, Math.Max(_fiscalYear.Minimum, fiscalYear))
        End Sub

        Private Sub FiscalYearChanged(sender As Object, e As EventArgs)
            ClearPreview()
            LoadHistory()
        End Sub

        Private Sub PreviewButton_Click(sender As Object, e As EventArgs)
            Try
                Cursor = Cursors.WaitCursor
                _lastPreview = ExecutePreview()
                BindPreviewResults(_lastPreview)
                UpdateFinalizeAvailability()
            Catch ex As Exception
                ClearPreview()
                _statusLabel.Text = Messaging.TranslateCaption("Fiscal-year preview failed.")
                Messaging.Show(True, "MsgFiscalYearClosePreviewFailed", "Fiscal-year close preview failed: {details}", "Fiscal Year End", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub ExecuteButton_Click(sender As Object, e As EventArgs)
            If Not CanFinalize() Then
                Messaging.Show(True, "MsgFiscalYearClosePreviewRequired", "Run Preview, resolve all blockers, acknowledge the review items, and enter approval notes.", "Fiscal Year End", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim yearText = Convert.ToInt32(_fiscalYear.Value).ToString()
            Dim confirmation = Microsoft.VisualBasic.Interaction.InputBox(
                "This operation creates posted closing journals, installs the next-year opening balances, and permanently blocks ordinary reversal of this fiscal year." & Environment.NewLine & Environment.NewLine &
                "Type " & yearText & " to finalize:",
                "Permanent Fiscal-Year Finalization", "")
            If confirmation <> yearText Then Return

            If Messaging.Show(True, "MsgConfirmFiscalYearClose", "Permanently finalize fiscal year {year}? This operation has no ordinary Unfinalize option.", "Confirm Fiscal Year End", {"year", yearText}, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return

            Try
                Cursor = Cursors.WaitCursor
                Dim result = ExecuteFinalization()
                _lastPreview = Nothing
                _executeButton.Enabled = False
                LoadHistory()
                Dim row = result.Tables(0).Rows(0)
                _statusLabel.Text = Messaging.ReplaceValues("Fiscal year {year} finalized. Result: {result} {amount}; opening rows: {rows}.", {"year", yearText, "result", Convert.ToString(row("FiscalResult")), "amount", Convert.ToDecimal(row("FiscalResultAmount")).ToString("N2"), "rows", Convert.ToString(row("OpeningRows"))})
                Messaging.Show(True, "MsgFiscalYearFinalized", "Fiscal year {year} was finalized successfully. Review Close history for the permanent audit record.", "Fiscal Year End", {"year", yearText}, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                _executeButton.Enabled = False
                _statusLabel.Text = Messaging.TranslateCaption("Fiscal-year finalization failed. No partial close was retained.")
                Messaging.Show(True, "MsgFiscalYearCloseFailed", "Fiscal-year finalization failed: {details}", "Fiscal Year End", {"details", ex.Message}, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Function ExecutePreview() As DataSet
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.PreviewFiscalYearClose", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandTimeout = 180
                    command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = Convert.ToInt32(_fiscalYear.Value)
                    Using adapter As New SqlDataAdapter(command)
                        Dim result As New DataSet()
                        adapter.Fill(result)
                        Return result
                    End Using
                End Using
            End Using
        End Function

        Private Function ExecuteFinalization() As DataSet
            Dim summary = _lastPreview.Tables(0).Rows(0)
            Dim openingReconciliation = _lastPreview.Tables(5).Rows.Cast(Of DataRow)().First(Function(row) Convert.ToString(row("Reconciliation")) = "NEXT_YEAR_OPENING")
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.FinalizeFiscalYearClose", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandTimeout = 300
                    command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = Convert.ToInt32(_fiscalYear.Value)
                    command.Parameters.Add("@IncomeSummaryAccountIdNo", SqlDbType.SmallInt).Value = Convert.ToInt16(summary("IncomeSummaryAccountIdNo"))
                    command.Parameters.Add("@RetainedEarningsAccountIdNo", SqlDbType.SmallInt).Value = Convert.ToInt16(summary("RetainedEarningsAccountIdNo"))
                    command.Parameters.Add("@ApplicationUser", SqlDbType.NVarChar, 128).Value = GlobalVariables.UserName
                    command.Parameters.Add("@ApprovalNotes", SqlDbType.NVarChar, 1000).Value = _approvalNotes.Text.Trim()
                    command.Parameters.Add("@WarningsAcknowledged", SqlDbType.Bit).Value = _acknowledgeWarnings.Checked
                    command.Parameters.Add("@ExpectedFiscalResult", SqlDbType.VarChar, 10).Value = Convert.ToString(summary("FiscalResult"))
                    AddDecimalParameter(command, "@ExpectedFiscalResultAmount", summary("FiscalResultAmount"))
                    AddDecimalParameter(command, "@ExpectedOpeningDebit", openingReconciliation("Debit"))
                    AddDecimalParameter(command, "@ExpectedOpeningCredit", openingReconciliation("Credit"))
                    AddDecimalParameter(command, "@ExpectedJanuaryBeginningInventory", summary("JanuaryBeginningInventory"))
                    AddDecimalParameter(command, "@ExpectedDecemberEndingInventory", summary("DecemberEndingInventory"))
                    Using adapter As New SqlDataAdapter(command)
                        Dim result As New DataSet()
                        adapter.Fill(result)
                        Return result
                    End Using
                End Using
            End Using
        End Function

        Private Shared Sub AddDecimalParameter(command As SqlCommand, name As String, value As Object)
            Dim parameter = command.Parameters.Add(name, SqlDbType.Decimal)
            parameter.Precision = 19
            parameter.Scale = 4
            parameter.Value = Convert.ToDecimal(value)
        End Sub

        Private Sub BindPreviewResults(data As DataSet)
            SetGridData(_summaryGrid, data, 0)
            SetGridData(_issuesGrid, data, 1)
            SetGridData(_journalGrid, data, 2)
            SetGridData(_transferGrid, data, 3)
            SetGridData(_openingGrid, data, 4)
            SetGridData(_reconciliationGrid, data, 5)
            SetGridData(_accountReviewGrid, data, 6)
            SetGridData(_inventoryGrid, data, 7)

            If data.Tables.Count = 0 OrElse data.Tables(0).Rows.Count = 0 Then
                _summaryInfo.Text = Messaging.TranslateCaption("No year-end summary was returned.")
                Return
            End If

            Dim row = data.Tables(0).Rows(0)
            _summaryInfo.Text = "Status=" & Convert.ToString(row("PreviewStatus")) &
                "  |  Result=" & Convert.ToString(row("FiscalResult")) & " " & Convert.ToDecimal(row("FiscalResultAmount")).ToString("N2") &
                "  |  January beginning inventory=" & Convert.ToDecimal(row("JanuaryBeginningInventory")).ToString("N2") &
                "  |  December ending inventory=" & Convert.ToDecimal(row("DecemberEndingInventory")).ToString("N2")
            _statusLabel.Text = "Blockers: " & Convert.ToString(row("BlockingErrors")) & "; review warnings: " & Convert.ToString(row("ReviewWarnings")) & ". Review every tab before finalization."
        End Sub

        Private Shared Sub SetGridData(grid As DataGridView, data As DataSet, tableIndex As Integer)
            grid.DataSource = If(data IsNot Nothing AndAlso data.Tables.Count > tableIndex, data.Tables(tableIndex), Nothing)
        End Sub

        Private Sub LoadHistory()
            Try
                Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                    Using command As New SqlCommand("dbo.GetFiscalYearCloseHistory", connection)
                        command.CommandType = CommandType.StoredProcedure
                        command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = Convert.ToInt32(_fiscalYear.Value)
                        Using adapter As New SqlDataAdapter(command)
                            Dim table As New DataTable()
                            adapter.Fill(table)
                            _historyGrid.DataSource = table
                        End Using
                    End Using
                End Using
            Catch
                _historyGrid.DataSource = Nothing
            End Try
            UpdateFinalizeAvailability()
        End Sub

        Private Sub ClearPreview()
            _lastPreview = Nothing
            _summaryGrid.DataSource = Nothing
            _issuesGrid.DataSource = Nothing
            _journalGrid.DataSource = Nothing
            _transferGrid.DataSource = Nothing
            _openingGrid.DataSource = Nothing
            _reconciliationGrid.DataSource = Nothing
            _accountReviewGrid.DataSource = Nothing
            _inventoryGrid.DataSource = Nothing
            _summaryInfo.Clear()
            _executeButton.Enabled = False
        End Sub

        Private Function CanFinalize() As Boolean
            If _lastPreview Is Nothing OrElse _lastPreview.Tables.Count < 8 OrElse _lastPreview.Tables(0).Rows.Count = 0 Then Return False
            If GetInt(_lastPreview, 0, "BlockingErrors") <> 0 Then Return False
            If Not _acknowledgeWarnings.Checked OrElse String.IsNullOrWhiteSpace(_approvalNotes.Text) Then Return False
            Dim history = TryCast(_historyGrid.DataSource, DataTable)
            Return history Is Nothing OrElse history.Rows.Count = 0
        End Function

        Private Sub UpdateFinalizeAvailability()
            _executeButton.Enabled = CanFinalize()
        End Sub

        Private Shared Function GetInt(data As DataSet, tableIndex As Integer, columnName As String) As Integer
            If data Is Nothing OrElse data.Tables.Count <= tableIndex OrElse data.Tables(tableIndex).Rows.Count = 0 Then Return 0
            Dim value = data.Tables(tableIndex).Rows(0)(columnName)
            If value Is DBNull.Value OrElse value Is Nothing Then Return 0
            Return Convert.ToInt32(value)
        End Function
    End Class

End Namespace
