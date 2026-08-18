Imports System.Drawing
Imports System.Windows.Forms

Namespace PresentationLayer.Views.Forms
    Partial Public Class FiscalYearPostingForm
        Friend WithEvents _fiscalYear As NumericUpDown
        Friend WithEvents _previewButton As Button
        Friend WithEvents _executeButton As Button
        Friend WithEvents _monthlyButton As Button
        Friend WithEvents _closeButton As Button
        Friend WithEvents _statusLabel As Label
        Friend WithEvents _summaryGrid As DataGridView
        Friend WithEvents _journalGrid As DataGridView
        Friend WithEvents _summaryInfo As TextBox
        Friend WithEvents _detailsText As TextBox
        Friend WithEvents _header As Label
        Friend WithEvents _commandPanel As FlowLayoutPanel
        Friend WithEvents _fiscalYearLabel As Label
        Friend WithEvents _tabs As TabControl
        Friend WithEvents _summaryPage As TabPage
        Friend WithEvents _journalPage As TabPage
        Friend WithEvents _detailsPage As TabPage

        Private Sub InitializeComponent()
            _fiscalYear = New NumericUpDown()
            _previewButton = New Button()
            _executeButton = New Button()
            _monthlyButton = New Button()
            _closeButton = New Button()
            _statusLabel = New Label()
            _summaryGrid = New DataGridView()
            _journalGrid = New DataGridView()
            _summaryInfo = New TextBox()
            _detailsText = New TextBox()
            _header = New Label()
            _commandPanel = New FlowLayoutPanel()
            _fiscalYearLabel = New Label()
            _tabs = New TabControl()
            _summaryPage = New TabPage()
            _journalPage = New TabPage()
            _detailsPage = New TabPage()

            Text = "Fiscal-Year Journal Posting"
            StartPosition = FormStartPosition.CenterScreen
            ClientSize = New Size(980, 620)
            MinimumSize = New Size(820, 500)
            BackColor = Color.White
            BackgroundImage = Nothing

            _header.Text = "Fiscal-Year Journal Posting" : _header.BackColor = Color.Green : _header.ForeColor = Color.White : _header.Font = New Font("Microsoft Sans Serif", 14.25!) : _header.TextAlign = ContentAlignment.MiddleCenter : _header.Dock = DockStyle.Top : _header.Height = 36
            Controls.Add(_header)
            _commandPanel.Dock = DockStyle.Top : _commandPanel.Height = 52 : _commandPanel.Padding = New Padding(8) : _commandPanel.FlowDirection = FlowDirection.LeftToRight : _commandPanel.WrapContents = False : _commandPanel.BackColor = Color.White : _commandPanel.ForeColor = Color.Black
            _fiscalYearLabel.Text = "Fiscal year:" : _fiscalYearLabel.AutoSize = True : _fiscalYearLabel.Margin = New Padding(4, 8, 4, 0)
            _commandPanel.Controls.Add(_fiscalYearLabel)
            _fiscalYear.Minimum = 2000 : _fiscalYear.Maximum = 2099 : _fiscalYear.Width = 80 : _fiscalYear.Margin = New Padding(4, 4, 12, 4) : _commandPanel.Controls.Add(_fiscalYear)
            _previewButton.Text = "Preview" : _previewButton.Width = 110 : _previewButton.Margin = New Padding(4) : _commandPanel.Controls.Add(_previewButton)
            _executeButton.Text = "Execute Posting" : _executeButton.Width = 130 : _executeButton.Margin = New Padding(4) : _commandPanel.Controls.Add(_executeButton)
            _closeButton.Text = "Close" : _closeButton.Width = 90 : _closeButton.Margin = New Padding(4)
            _commandPanel.Controls.Add(_closeButton)
            _monthlyButton.Text = "Monthly Posting" : _monthlyButton.Width = 125 : _monthlyButton.Margin = New Padding(4)
            _commandPanel.Controls.Add(_monthlyButton)
            _statusLabel.Text = "Preview is required before execution." : _statusLabel.AutoSize = True : _statusLabel.Margin = New Padding(16, 8, 4, 0) : _commandPanel.Controls.Add(_statusLabel)
            Controls.Add(_commandPanel)

            _tabs.Dock = DockStyle.Fill : _tabs.Visible = True : _tabs.Appearance = TabAppearance.Normal : _tabs.SizeMode = TabSizeMode.Fixed : _tabs.ItemSize = New Size(170, 28) : _tabs.Padding = New Point(10, 3) : _tabs.BackColor = Color.White : _tabs.ForeColor = Color.Black : _tabs.Font = New Font("Microsoft Sans Serif", 9.0!)
            _summaryPage.Text = "Validation summary" : _summaryPage.BackColor = Color.White : _summaryPage.ForeColor = Color.Black
            _summaryGrid.Dock = DockStyle.Fill : _summaryGrid.ReadOnly = True : _summaryGrid.AllowUserToAddRows = False : _summaryGrid.AllowUserToDeleteRows = False : _summaryGrid.AutoGenerateColumns = True : _summaryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells : _summaryGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect : _summaryGrid.Visible = True : _summaryGrid.BackgroundColor = Color.White : _summaryGrid.ForeColor = Color.Black : _summaryGrid.GridColor = Color.Silver : _summaryGrid.BorderStyle = BorderStyle.FixedSingle : _summaryGrid.ColumnHeadersVisible = True : _summaryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing : _summaryGrid.ColumnHeadersHeight = 28 : _summaryGrid.RowHeadersVisible = False : _summaryGrid.EnableHeadersVisualStyles = False
            _summaryInfo.Multiline = True : _summaryInfo.ReadOnly = True : _summaryInfo.ScrollBars = ScrollBars.Horizontal : _summaryInfo.Dock = DockStyle.Top : _summaryInfo.Height = 58 : _summaryInfo.BackColor = Color.White : _summaryInfo.ForeColor = Color.Black : _summaryInfo.BorderStyle = BorderStyle.FixedSingle : _summaryInfo.Font = New Font("Consolas", 9.0!)
            _summaryPage.Controls.Add(_summaryGrid) : _summaryPage.Controls.Add(_summaryInfo) : _tabs.TabPages.Add(_summaryPage)
            _journalPage.Text = "Journal batches" : _journalPage.BackColor = Color.White : _journalPage.ForeColor = Color.Black
            _journalGrid.Dock = DockStyle.Fill : _journalGrid.ReadOnly = True : _journalGrid.AllowUserToAddRows = False : _journalGrid.AllowUserToDeleteRows = False : _journalGrid.AutoGenerateColumns = True : _journalGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells : _journalGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect : _journalGrid.Visible = True : _journalGrid.BackgroundColor = Color.White : _journalGrid.ForeColor = Color.Black : _journalGrid.GridColor = Color.Silver : _journalGrid.BorderStyle = BorderStyle.FixedSingle : _journalGrid.ColumnHeadersVisible = True : _journalGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing : _journalGrid.ColumnHeadersHeight = 28 : _journalGrid.RowHeadersVisible = False : _journalGrid.EnableHeadersVisualStyles = False : _journalPage.Controls.Add(_journalGrid) : _tabs.TabPages.Add(_journalPage)
            _detailsPage.Text = "Validation details" : _detailsPage.BackColor = Color.White : _detailsPage.ForeColor = Color.Black
            _detailsText.Multiline = True : _detailsText.ReadOnly = True : _detailsText.ScrollBars = ScrollBars.Both : _detailsText.Dock = DockStyle.Fill : _detailsText.Font = New Font("Consolas", 9.0!)
            _detailsPage.Controls.Add(_detailsText) : _tabs.TabPages.Add(_detailsPage)
            Controls.Add(_tabs)
        End Sub
    End Class
End Namespace
