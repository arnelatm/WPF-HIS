Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms

    Public Class FiscalYearPostingForm
        Inherits BFMain

        Private ReadOnly _fiscalYear As New NumericUpDown()
        Private ReadOnly _previewButton As New Button()
        Private ReadOnly _executeButton As New Button()
        Private ReadOnly _closeButton As New Button()
        Private ReadOnly _statusLabel As New Label()
        Private ReadOnly _summaryGrid As New DataGridView()
        Private ReadOnly _journalGrid As New DataGridView()
        Private ReadOnly _detailsText As New TextBox()
        Private _lastPreview As DataSet

        Public Sub New()
            InitializeComponent()
            _fiscalYear.Value = Math.Max(_fiscalYear.Minimum, Date.Today.Year - 1)
            _executeButton.Enabled = False
        End Sub

        Private Sub InitializeComponent()
            Text = "Fiscal-Year Journal Posting"
            StartPosition = FormStartPosition.CenterScreen
            ClientSize = New Size(980, 620)
            MinimumSize = New Size(820, 500)

            Dim header As New Label With {
                .Text = "Fiscal-Year Journal Posting",
                .BackColor = Color.Green,
                .ForeColor = Color.White,
                .Font = New Font("Microsoft Sans Serif", 14.25!, FontStyle.Regular),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Dock = DockStyle.Top,
                .Height = 36
            }
            Controls.Add(header)

            Dim commandPanel As New FlowLayoutPanel With {
                .Dock = DockStyle.Top,
                .Height = 52,
                .Padding = New Padding(8),
                .FlowDirection = FlowDirection.LeftToRight,
                .WrapContents = False
            }
            commandPanel.Controls.Add(New Label With {.Text = "Fiscal year:", .AutoSize = True, .Margin = New Padding(4, 8, 4, 0)})
            _fiscalYear.Minimum = 2000
            _fiscalYear.Maximum = 2099
            _fiscalYear.Width = 80
            _fiscalYear.Margin = New Padding(4, 4, 12, 4)
            commandPanel.Controls.Add(_fiscalYear)

            _previewButton.Text = "Preview"
            _previewButton.Width = 110
            _previewButton.Margin = New Padding(4)
            AddHandler _previewButton.Click, AddressOf PreviewButton_Click
            commandPanel.Controls.Add(_previewButton)

            _executeButton.Text = "Execute Posting"
            _executeButton.Width = 130
            _executeButton.Margin = New Padding(4)
            AddHandler _executeButton.Click, AddressOf ExecuteButton_Click
            commandPanel.Controls.Add(_executeButton)

            _closeButton.Text = "Close"
            _closeButton.Width = 90
            _closeButton.Margin = New Padding(4)
            AddHandler _closeButton.Click, Sub(sender, e) Close()
            commandPanel.Controls.Add(_closeButton)

            _statusLabel.Text = "Preview is required before execution."
            _statusLabel.AutoSize = True
            _statusLabel.Margin = New Padding(16, 8, 4, 0)
            commandPanel.Controls.Add(_statusLabel)
            Controls.Add(commandPanel)

            Dim tabs As New TabControl With {.Dock = DockStyle.Fill}
            Dim summaryPage As New TabPage("Validation summary")
            ConfigureGrid(_summaryGrid)
            summaryPage.Controls.Add(_summaryGrid)
            tabs.TabPages.Add(summaryPage)

            Dim journalPage As New TabPage("Journal batches")
            ConfigureGrid(_journalGrid)
            journalPage.Controls.Add(_journalGrid)
            tabs.TabPages.Add(journalPage)

            Dim detailsPage As New TabPage("Validation details")
            _detailsText.Multiline = True
            _detailsText.ReadOnly = True
            _detailsText.ScrollBars = ScrollBars.Both
            _detailsText.Dock = DockStyle.Fill
            _detailsText.Font = New Font("Consolas", 9.0!)
            detailsPage.Controls.Add(_detailsText)
            tabs.TabPages.Add(detailsPage)

            Controls.Add(tabs)
        End Sub

        Private Shared Sub ConfigureGrid(grid As DataGridView)
            grid.Dock = DockStyle.Fill
            grid.ReadOnly = True
            grid.AllowUserToAddRows = False
            grid.AllowUserToDeleteRows = False
            grid.AutoGenerateColumns = True
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        End Sub

        Private Sub PreviewButton_Click(sender As Object, e As EventArgs)
            LoadPosting(False)
        End Sub

        Private Sub ExecuteButton_Click(sender As Object, e As EventArgs)
            If _lastPreview Is Nothing OrElse _lastPreview.Tables.Count = 0 Then
                MessageBox.Show("Run Preview before executing posting.", "Fiscal-Year Posting", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            If MessageBox.Show(
                    "This will mark all currently unposted journal headers and items in fiscal year " & _fiscalYear.Value.ToString() & " as Posted." & Environment.NewLine &
                    "The operation is audited and cannot be undone by this screen. Continue?",
                    "Confirm fiscal-year posting", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then
                Return
            End If

            LoadPosting(True)
        End Sub

        Private Sub LoadPosting(executePosting As Boolean)
            Try
                Cursor = Cursors.WaitCursor
                Dim data = ExecutePostingProcedure(executePosting)

                _lastPreview = data
                BindResults(data)

                If executePosting Then
                    _executeButton.Enabled = False
                    _statusLabel.Text = "Posting completed. Run Preview again to verify the final state."
                Else
                    Dim blockingErrors = GetInt(data, 0, "BlockingErrors")
                    Dim headersToPost = GetInt(data, 0, "HeadersToPost")
                    Dim itemsToPost = GetInt(data, 0, "ItemsToPost")
                    _executeButton.Enabled = blockingErrors = 0 AndAlso (headersToPost > 0 OrElse itemsToPost > 0)
                    _statusLabel.Text = String.Format(
                        "Blocking errors: {0}; headers to post: {1}; items to post: {2}",
                        blockingErrors, headersToPost, itemsToPost)
                End If
            Catch ex As Exception
                _executeButton.Enabled = False
                _statusLabel.Text = "Posting request failed."
                MessageBox.Show(ex.Message, "Fiscal-Year Posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Function ExecutePostingProcedure(executePosting As Boolean) As DataSet
            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.PostFiscalYearJournalEntries", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.CommandTimeout = 120
                    command.Parameters.Add("@FiscalYear", SqlDbType.Int).Value = Convert.ToInt32(_fiscalYear.Value)
                    command.Parameters.Add("@ExecutePosting", SqlDbType.Bit).Value = executePosting

                    Using adapter As New SqlDataAdapter(command)
                        Dim result As New DataSet()
                        adapter.Fill(result)
                        Return result
                    End Using
                End Using
            End Using
        End Function

        Private Sub BindResults(data As DataSet)
            _summaryGrid.DataSource = Nothing
            _journalGrid.DataSource = Nothing
            _detailsText.Clear()

            If data Is Nothing OrElse data.Tables.Count = 0 Then Return

            _summaryGrid.DataSource = data.Tables(0)
            If data.Tables.Count > 1 Then _journalGrid.DataSource = data.Tables(1)

            For tableIndex As Integer = 2 To data.Tables.Count - 1
                _detailsText.AppendText("Result set " & tableIndex.ToString() & Environment.NewLine)
                For Each row As DataRow In data.Tables(tableIndex).Rows
                    Dim values = row.ItemArray.Select(Function(value) If(value Is DBNull.Value, "", value.ToString()))
                    _detailsText.AppendText(String.Join(" | ", values) & Environment.NewLine)
                Next
                _detailsText.AppendText(Environment.NewLine)
            Next
        End Sub

        Private Shared Function GetInt(data As DataSet, tableIndex As Integer, columnName As String) As Integer
            If data Is Nothing OrElse data.Tables.Count <= tableIndex OrElse data.Tables(tableIndex).Rows.Count = 0 Then Return 0
            Dim value = data.Tables(tableIndex).Rows(0)(columnName)
            If value Is DBNull.Value OrElse value Is Nothing Then Return 0
            Return Convert.ToInt32(value)
        End Function
    End Class

End Namespace
