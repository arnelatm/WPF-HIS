Imports System.Drawing
Imports System.Windows.Forms

Namespace PresentationLayer.Views.Forms
    Partial Public Class FiscalYearPostingForm
        Private Sub InitializeComponent()
            Text = "Fiscal-Year Journal Posting"
            StartPosition = FormStartPosition.CenterScreen
            ClientSize = New Size(980, 620)
            MinimumSize = New Size(820, 500)

            Dim header As New Label With {.Text = "Fiscal-Year Journal Posting", .BackColor = Color.Green, .ForeColor = Color.White, .Font = New Font("Microsoft Sans Serif", 14.25!), .TextAlign = ContentAlignment.MiddleCenter, .Dock = DockStyle.Top, .Height = 36}
            Controls.Add(header)
            Dim commandPanel As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 52, .Padding = New Padding(8), .FlowDirection = FlowDirection.LeftToRight, .WrapContents = False}
            commandPanel.Controls.Add(New Label With {.Text = "Fiscal year:", .AutoSize = True, .Margin = New Padding(4, 8, 4, 0)})
            _fiscalYear.Minimum = 2000 : _fiscalYear.Maximum = 2099 : _fiscalYear.Width = 80 : _fiscalYear.Margin = New Padding(4, 4, 12, 4) : commandPanel.Controls.Add(_fiscalYear)
            _previewButton.Text = "Preview" : _previewButton.Width = 110 : _previewButton.Margin = New Padding(4) : AddHandler _previewButton.Click, AddressOf PreviewButton_Click : commandPanel.Controls.Add(_previewButton)
            _executeButton.Text = "Execute Posting" : _executeButton.Width = 130 : _executeButton.Margin = New Padding(4) : AddHandler _executeButton.Click, AddressOf ExecuteButton_Click : commandPanel.Controls.Add(_executeButton)
            _closeButton.Text = "Close" : _closeButton.Width = 90 : _closeButton.Margin = New Padding(4)
            AddHandler _closeButton.Click, Sub(sender, e) Close()
            commandPanel.Controls.Add(_closeButton)
            _monthlyButton.Text = "Monthly Posting" : _monthlyButton.Width = 125 : _monthlyButton.Margin = New Padding(4)
            AddHandler _monthlyButton.Click, Sub(sender, e)
                                                 Using monthlyForm As New MonthlyPostingForm()
                                                     monthlyForm.ShowDialog(Me)
                                                 End Using
                                             End Sub
            commandPanel.Controls.Add(_monthlyButton)
            _statusLabel.Text = "Preview is required before execution." : _statusLabel.AutoSize = True : _statusLabel.Margin = New Padding(16, 8, 4, 0) : commandPanel.Controls.Add(_statusLabel)
            Controls.Add(commandPanel)

            Dim tabs As New TabControl With {.Dock = DockStyle.Fill, .Visible = True, .Appearance = TabAppearance.Normal, .SizeMode = TabSizeMode.Fixed, .ItemSize = New Size(170, 28), .Padding = New Point(10, 3), .BackColor = Color.White, .ForeColor = Color.Black, .Font = New Font("Microsoft Sans Serif", 9.0!)}
            Dim summaryPage As New TabPage("Validation summary") With {.BackColor = Color.White, .ForeColor = Color.Black}
            ConfigureGrid(_summaryGrid)
            _summaryInfo.Multiline = True : _summaryInfo.ReadOnly = True : _summaryInfo.ScrollBars = ScrollBars.Horizontal : _summaryInfo.Dock = DockStyle.Top : _summaryInfo.Height = 58 : _summaryInfo.BackColor = Color.White : _summaryInfo.ForeColor = Color.Black : _summaryInfo.BorderStyle = BorderStyle.FixedSingle : _summaryInfo.Font = New Font("Consolas", 9.0!)
            summaryPage.Controls.Add(_summaryGrid) : summaryPage.Controls.Add(_summaryInfo) : tabs.TabPages.Add(summaryPage)
            Dim journalPage As New TabPage("Journal batches") With {.BackColor = Color.White, .ForeColor = Color.Black}
            ConfigureGrid(_journalGrid) : journalPage.Controls.Add(_journalGrid) : tabs.TabPages.Add(journalPage)
            Dim detailsPage As New TabPage("Validation details") With {.BackColor = Color.White, .ForeColor = Color.Black}
            _detailsText.Multiline = True : _detailsText.ReadOnly = True : _detailsText.ScrollBars = ScrollBars.Both : _detailsText.Dock = DockStyle.Fill : _detailsText.Font = New Font("Consolas", 9.0!)
            detailsPage.Controls.Add(_detailsText) : tabs.TabPages.Add(detailsPage)
            Controls.Add(tabs)
        End Sub
    End Class
End Namespace
