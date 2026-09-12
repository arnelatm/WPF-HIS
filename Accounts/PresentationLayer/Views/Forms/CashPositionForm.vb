Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    Public Class CashPositionForm
        Inherits BFMain
        Implements ICashPositionView, IGeneralAccountPositionView

        Private ReadOnly _beginning As New CDateTimePicker()
        Private ReadOnly _ending As New CDateTimePicker()
        Private ReadOnly _accounts As New CheckedListBox()
        Protected ReadOnly _accountTree As New TreeView()
        Private ReadOnly _refresh As New CButton()
        Private ReadOnly _scopeSetup As New CButton()
        Protected ReadOnly _includeClosingEntries As New CheckBox()
        Private ReadOnly _all As New CButton()
        Private ReadOnly _none As New CButton()
        Private ReadOnly _summary As New DataGridView()
        Private ReadOnly _details As New DataGridView()
        Private ReadOnly _totals As New CLabel()
        Private ReadOnly _status As New CLabel()
        Private ReadOnly _captions As New Dictionary(Of Control, String)
        Private ReadOnly _columnCaptions As New Dictionary(Of DataGridViewColumn, String)
        Private ReadOnly _filters As New FlowLayoutPanel()
        Private ReadOnly _accountCommands As New FlowLayoutPanel()
        Private _position As CashPositionModel
        Private _binding As Boolean
        Private _openingTransaction As Boolean

        Public Event InitializeRequested() Implements ICashPositionView.InitializeRequested
        Public Event RefreshRequested() Implements ICashPositionView.RefreshRequested
        Public Event TransactionRequested(journalCode As String, journalIdNo As Integer,
                                          itemIdNo As Integer) Implements ICashPositionView.TransactionRequested

        Public Sub ShowTransaction(transaction As CashPositionTransactionModel) Implements ICashPositionView.ShowTransaction
            UseWaitCursor = False
            Using popup As New CashPositionTransactionForm(transaction)
                popup.ShowDialog(Me)
            End Using
        End Sub

        Private Sub DetailsCellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
            If _openingTransaction OrElse _position Is Nothing OrElse e.RowIndex < 0 OrElse
               e.ColumnIndex < 0 OrElse e.RowIndex >= _details.Rows.Count Then Return
            Dim line = TryCast(_details.Rows(e.RowIndex).DataBoundItem, CashPositionLineModel)
            If line Is Nothing Then Return
            _openingTransaction = True
            Try
                RaiseEvent TransactionRequested(line.JournalCode, line.JournalIdNo, line.ItemIdNo)
            Finally
                _openingTransaction = False
            End Try
        End Sub

        Public Sub New()
            Name = "CashPositionForm"
            ViewDisplayName = ReportTitle
            InitializeUi()
            ApplyCaptions()
        End Sub

        Protected Overridable ReadOnly Property ReportTitle As String
            Get
                Return "Cash Position"
            End Get
        End Property

        Protected Overridable ReadOnly Property ShowsCashScopeSetup As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overridable ReadOnly Property ShowsClosingEntriesOption As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overridable ReadOnly Property SelectAllAccountsByDefault As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overridable ReadOnly Property UsesAccountTree As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overridable ReadOnly Property IncludeClosingEntries As Boolean Implements IGeneralAccountPositionView.IncludeClosingEntries
            Get
                Return If(_includeClosingEntries Is Nothing, True, _includeClosingEntries.Checked)
            End Get
        End Property

        Public ReadOnly Property BeginningDate As Date Implements ICashPositionView.BeginningDate
            Get
                Return _beginning.Value.Date
            End Get
        End Property

        Public ReadOnly Property EndingDate As Date Implements ICashPositionView.EndingDate
            Get
                Return _ending.Value.Date
            End Get
        End Property

        Public ReadOnly Property SelectedAccountIds As List(Of Short) Implements ICashPositionView.SelectedAccountIds
            Get
                If UsesAccountTree Then
                    Return CheckedTreeAccounts(_accountTree.Nodes).Distinct().ToList()
                End If
                Return _accounts.CheckedItems.Cast(Of CashPositionAccountModel)().Select(Function(a) a.IdNo).ToList()
            End Get
        End Property

        Public Overridable ReadOnly Property IsGeneralAccountPosition As Boolean Implements ICashPositionView.IsGeneralAccountPosition
            Get
                Return False
            End Get
        End Property

        Public Sub SetAccounts(accounts As List(Of CashPositionAccountModel)) Implements ICashPositionView.SetAccounts
            If UsesAccountTree Then
                SetAccountTree(accounts)
                Return
            End If
            _binding = True
            Try
                _accounts.Items.Clear()
                For Each account In accounts
                    _accounts.Items.Add(account, SelectAllAccountsByDefault)
                Next
            Finally
                _binding = False
            End Try
        End Sub

        Private Sub SetAccountTree(accounts As List(Of CashPositionAccountModel))
            _binding = True
            Try
                _accountTree.Nodes.Clear()
                Dim accountRoot As New TreeNode(If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "شجرة الحسابات", "Account_View")) With {.Name = "ACCOUNT_ROOT", .Tag = Nothing}
                _accountTree.Nodes.Add(accountRoot)
                Dim accountNodes As New Dictionary(Of Short, TreeNode)
                Dim ordered = accounts.OrderBy(Function(a) If(String.IsNullOrWhiteSpace(a.SortKey), a.AccountCode, a.SortKey)).ThenBy(Function(a) a.AccountCode).ToList()
                For Each account In ordered
                    Dim parent As TreeNode = Nothing
                    If account.ParentIdNo.HasValue Then accountNodes.TryGetValue(account.ParentIdNo.Value, parent)
                    If parent Is Nothing Then accountRoot.Nodes.Add(New TreeNode(account.DisplayName) With {.Tag = account}) Else parent.Nodes.Add(New TreeNode(account.DisplayName) With {.Tag = account})
                    Dim added = If(parent Is Nothing, accountRoot.Nodes(accountRoot.Nodes.Count - 1), parent.Nodes(parent.Nodes.Count - 1))
                    accountNodes(account.IdNo) = added
                Next
                _accountTree.ExpandAll()
            Finally
                _binding = False
            End Try
        End Sub

        Private Shared Function CheckedTreeAccounts(nodes As TreeNodeCollection) As IEnumerable(Of Short)
            Dim result As New List(Of Short)
            For Each node As TreeNode In nodes
                If node.Checked AndAlso node.Tag IsNot Nothing Then result.Add(DirectCast(node.Tag, CashPositionAccountModel).IdNo)
                result.AddRange(CheckedTreeAccounts(node.Nodes))
            Next
            Return result
        End Function

        Public Sub ShowPosition(position As CashPositionModel) Implements ICashPositionView.ShowPosition
            _position = position
            _summary.DataSource = New BindingList(Of CashPositionAccountModel)(position.Accounts)
            UpdateTotals()
            ShowAccountLines()
        End Sub

        Public Sub ClearPosition() Implements ICashPositionView.ClearPosition
            _position = Nothing
            _summary.DataSource = Nothing
            _details.DataSource = Nothing
            _totals.Text = ""
            _status.Text = Caption("ChooseAndLoad")
        End Sub

        Public Sub SetBusy(busy As Boolean) Implements ICashPositionView.SetBusy
            UseWaitCursor = busy
            _refresh.Enabled = Not busy
            _scopeSetup.Enabled = Not busy
            _accounts.Enabled = Not busy
            _accountTree.Enabled = Not busy
            _beginning.Enabled = Not busy
            _ending.Enabled = Not busy
            _all.Enabled = Not busy
            _none.Enabled = Not busy
        End Sub

        Public Sub ShowError(messageKey As String) Implements ICashPositionView.ShowError
            _status.Text = Caption(messageKey)
            MessageBox.Show(Me, Caption(messageKey), Caption("Title"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub

        Protected Overrides Sub OnShown(e As EventArgs)
            MyBase.OnShown(e)
            ApplyCaptions()
            If LicenseManager.UsageMode <> LicenseUsageMode.Designtime Then RaiseEvent InitializeRequested()
        End Sub

        Protected Overrides Sub OnAfterLanguageSwitch(context As LanguageSwitchContext)
            MyBase.OnAfterLanguageSwitch(context)
            ApplyCaptions()
        End Sub

        Protected Overrides ReadOnly Property LanguageLayoutMode As LanguageLayoutPolicy
            Get
                Return LanguageLayoutPolicy.AlwaysFull
            End Get
        End Property

        Private Sub InitializeUi()
            SuspendLayout()
            StartPosition = FormStartPosition.CenterParent
            ClientSize = New Size(1280, 740)
            MinimumSize = New Size(1120, 640)
            Font = New Font("Segoe UI", 9.0!)
            UseGlobalFormColor = False
            BackgroundImage = Nothing
            BackColor = Color.White
            ForeColor = Color.Black

            _filters.Dock = DockStyle.Top
            _filters.Height = 52
            _filters.Padding = New Padding(8)
            AddCaption(_filters, New CLabel With {.AutoSize = True, .Margin = New Padding(4, 8, 4, 0)}, "From")
            ConfigureDate(_beginning, New Date(2025, 12, 1))
            _filters.Controls.Add(_beginning)
            AddCaption(_filters, New CLabel With {.AutoSize = True, .Margin = New Padding(12, 8, 4, 0)}, "To")
            ConfigureDate(_ending, New Date(2025, 12, 31))
            _filters.Controls.Add(_ending)
            _refresh.Size = New Size(120, 32)
            AddCaption(_filters, _refresh, "Load")
            AddHandler _refresh.Click, Sub() RaiseEvent RefreshRequested()
            AddCaption(_filters, New CLabel With {.AutoSize = True, .Margin = New Padding(16, 8, 4, 0)}, "Basis")
            _scopeSetup.Size = New Size(145, 32) : _scopeSetup.Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "إعداد نطاق النقد", "Cash Scope Setup") : _filters.Controls.Add(_scopeSetup)
            _scopeSetup.Visible = ShowsCashScopeSetup
            If ShowsClosingEntriesOption Then
                _includeClosingEntries.AutoSize = True
                _includeClosingEntries.Checked = True
                _includeClosingEntries.Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "تضمين قيود الإقفال السنوية", "Include fiscal closing entries")
                _includeClosingEntries.Margin = New Padding(12, 8, 4, 0)
                _filters.Controls.Add(_includeClosingEntries)
                AddHandler _includeClosingEntries.CheckedChanged, Sub() ClearPosition()
            End If
            AddHandler _scopeSetup.Click, Sub()
                                              Using setup As New CashFlowSetupForm()
                                                  setup.ShowDialog(Me)
                                              End Using
                                              RaiseEvent InitializeRequested()
                                          End Sub

            Dim layout As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 2, .RowCount = 1, .Padding = New Padding(8)}
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 280))
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            Dim selection As New Panel With {.Dock = DockStyle.Fill, .Padding = New Padding(0, 0, 8, 0)}
            AddCaption(selection, New CLabel With {.Dock = DockStyle.Top, .Height = 46}, If(UsesAccountTree, "AccountsGeneral", "Accounts"))
            _accounts.Dock = DockStyle.Fill
            _accounts.CheckOnClick = True
            _accounts.IntegralHeight = False
            _accounts.HorizontalScrollbar = True
            _accounts.DisplayMember = "DisplayName"
            _accounts.FormattingEnabled = True
            AddHandler _accounts.Format, Sub(sender, e)
                                             Dim account = TryCast(e.ListItem, CashPositionAccountModel)
                                             If account IsNot Nothing Then e.Value = account.DisplayName & If(account.Active, "", " " & Caption("Inactive"))
                                         End Sub
            AddHandler _accounts.ItemCheck, Sub()
                                               If Not _binding Then ClearPosition()
                                           End Sub
            _accountTree.Dock = DockStyle.Fill
            _accountTree.CheckBoxes = True
            _accountTree.HideSelection = False
            _accountTree.Visible = UsesAccountTree
            AddHandler _accountTree.AfterCheck, AddressOf AccountTreeAfterCheck
            _accountCommands.Dock = DockStyle.Bottom
            _accountCommands.Height = 44
            _all.Size = New Size(120, 32)
            _none.Size = New Size(120, 32)
            AddCaption(_accountCommands, _all, "SelectAll")
            AddCaption(_accountCommands, _none, "ClearSelection")
            AddHandler _all.Click, Sub() CheckAccounts(True)
            AddHandler _none.Click, Sub() CheckAccounts(False)
            selection.Controls.Add(_accounts)
            selection.Controls.Add(_accountTree)
            selection.Controls.Add(_accountCommands)
            _accounts.BringToFront()
            If UsesAccountTree Then _accountTree.BringToFront()
            layout.Controls.Add(selection, 0, 0)

            Dim grids As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 4}
            grids.RowStyles.Add(New RowStyle(SizeType.Percent, 43))
            grids.RowStyles.Add(New RowStyle(SizeType.Absolute, 58))
            grids.RowStyles.Add(New RowStyle(SizeType.Absolute, 26))
            grids.RowStyles.Add(New RowStyle(SizeType.Percent, 57))
            ConfigureGrid(_summary)
            ConfigureGrid(_details)
            AddColumn(_summary, "DisplayName", "Account", 245)
            AddColumn(_summary, "OpeningBalance", "Opening", 120, "N2")
            AddColumn(_summary, "Debit", "Debit", 120, "N2")
            AddColumn(_summary, "Credit", "Credit", 120, "N2")
            AddColumn(_summary, "ClosingBalance", "Closing", 120, "N2")
            AddColumn(_summary, "Review", "Review", 310)
            _summary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            For Each column As DataGridViewColumn In _summary.Columns
                column.FillWeight = column.Width
                column.MinimumWidth = If(column.Name = "DisplayName" OrElse column.Name = "Review", 160, 85)
            Next
            AddHandler _summary.DataBindingComplete, AddressOf GridDataBindingComplete
            AddHandler _summary.SelectionChanged, Sub() ShowAccountLines()
            AddHandler _summary.CellFormatting, AddressOf FormatSummary
            grids.Controls.Add(_summary, 0, 0)
            _totals.Dock = DockStyle.Fill
            _totals.Padding = New Padding(4)
            grids.Controls.Add(_totals, 0, 1)
            AddCaption(grids, New CLabel With {.Dock = DockStyle.Fill}, "Details")
            AddColumn(_details, "TransactionDate", "Date", 105, "yyyy-MM-dd")
            AddColumn(_details, "JournalCode", "Journal", 65)
            AddColumn(_details, "JournalIdNo", "JournalId", 80)
            AddColumn(_details, "ItemIdNo", "ItemId", 80)
            AddColumn(_details, "ReferenceNo", "Reference", 100)
            AddColumn(_details, "Debit", "Debit", 110, "N2")
            AddColumn(_details, "Credit", "Credit", 110, "N2")
            AddColumn(_details, "HeaderPosted", "HeaderPosted", 110)
            AddColumn(_details, "ItemPosted", "ItemPosted", 110)
            AddColumn(_details, "ClosingJournal", "ClosingEntry", 110)
            AddColumn(_details, "Notes", "Notes", 270)
            AddHandler _details.DataBindingComplete, AddressOf GridDataBindingComplete
            AddHandler _details.CellFormatting, AddressOf FormatDetails
            AddHandler _details.CellDoubleClick, AddressOf DetailsCellDoubleClick
            grids.Controls.Add(_details, 0, 3)
            layout.Controls.Add(grids, 1, 0)
            _status.Dock = DockStyle.Bottom
            _status.Height = 42
            _status.Padding = New Padding(10, 4, 10, 4)
            Controls.Add(layout)
            Controls.Add(_status)
            Controls.Add(_filters)
            AddHandler _beginning.ValueChanged, Sub() ClearPosition()
            AddHandler _ending.ValueChanged, Sub() ClearPosition()
            ResumeLayout(True)
        End Sub

        Private Shared Sub ConfigureDate(picker As CDateTimePicker, value As Date)
            picker.Format = DateTimePickerFormat.Custom
            picker.CustomFormat = "yyyy-MM-dd"
            picker.Width = 145
            picker.ReadOnlyDp = False
            picker.Value = value
        End Sub

        Private Shared Sub ConfigureGrid(grid As DataGridView)
            grid.Dock = DockStyle.Fill
            grid.ReadOnly = True
            grid.AutoGenerateColumns = False
            grid.AllowUserToAddRows = False
            grid.AllowUserToDeleteRows = False
            grid.AllowUserToOrderColumns = True
            grid.RowHeadersVisible = False
            grid.MultiSelect = False
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            grid.BackgroundColor = Color.White
            grid.DefaultCellStyle.ForeColor = Color.Black
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
        End Sub

        Private Sub AddColumn(grid As DataGridView, field As String, captionKey As String,
                                     width As Integer, Optional format As String = Nothing)
            ' The shared caption collector owns Tag. Keep resource keys separately
            ' because neither display captions nor bound field names are resource keys.
            Dim column As New DataGridViewTextBoxColumn With {
                .Name = field, .DataPropertyName = If(field = "Review", "", field),
                .HeaderText = Caption(captionKey), .Width = width,
                .SortMode = DataGridViewColumnSortMode.NotSortable}
            _columnCaptions.Add(column, captionKey)
            If format IsNot Nothing Then column.DefaultCellStyle.Format = format
            If format = "yyyy-MM-dd" Then column.DefaultCellStyle.FormatProvider = CultureInfo.InvariantCulture
            If format = "N2" Then column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            If field = "Review" Then column.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            grid.Columns.Add(column)
        End Sub

        Private Sub AddCaption(parent As Control, control As Control, key As String)
            _captions.Add(control, key)
            parent.Controls.Add(control)
        End Sub

        Private Sub CheckAccounts(check As Boolean)
            If UsesAccountTree Then
                _binding = True
                Try
                    For Each root As TreeNode In _accountTree.Nodes
                        SetTreeChecked(root, check)
                    Next
                Finally
                    _binding = False
                End Try
                ClearPosition()
                Return
            End If
            _binding = True
            Try
                For index = 0 To _accounts.Items.Count - 1
                    _accounts.SetItemChecked(index, check)
                Next
            Finally
                _binding = False
            End Try
            ClearPosition()
        End Sub

        Private Sub AccountTreeAfterCheck(sender As Object, e As TreeViewEventArgs)
            If _binding Then Return
            _binding = True
            Try
                SetTreeChecked(e.Node, e.Node.Checked)
            Finally
                _binding = False
            End Try
            ClearPosition()
        End Sub

        Private Shared Sub SetTreeChecked(node As TreeNode, checked As Boolean)
            For Each child As TreeNode In node.Nodes
                child.Checked = checked
                SetTreeChecked(child, checked)
            Next
        End Sub

        Private Sub ApplyCaptions()
            Text = ReportTitle
            Dim rtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft
            RightToLeft = If(rtl, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = rtl
            For Each pair In _captions
                pair.Key.Text = Caption(pair.Value)
            Next
            For Each grid In {_summary, _details}
                ApplyGridCaptions(grid)
                grid.Refresh()
            Next
            _accounts.Refresh()
            UpdateTotals()
        End Sub

        Private Sub GridDataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
            ApplyGridCaptions(TryCast(sender, DataGridView))
        End Sub

        Private Sub ApplyGridCaptions(grid As DataGridView)
            If grid Is Nothing Then Return
            For Each column As DataGridViewColumn In grid.Columns
                Dim captionKey As String = Nothing
                If _columnCaptions.TryGetValue(column, captionKey) Then
                    column.HeaderText = Caption(captionKey)
                End If
            Next
        End Sub

        Private Sub UpdateTotals()
            If _position Is Nothing Then
                _status.Text = Caption("ChooseAndLoad")
                Return
            End If
            _totals.Text = String.Format(CultureInfo.CurrentCulture, Caption("Totals"),
                _position.Accounts.Sum(Function(a) a.OpeningBalance), _position.Accounts.Sum(Function(a) a.Debit),
                _position.Accounts.Sum(Function(a) a.Credit), _position.Accounts.Sum(Function(a) a.ClosingBalance))
            _status.Text = Caption("BookBalances")
        End Sub

        Private Sub ShowAccountLines()
            Dim account = If(_summary.CurrentRow Is Nothing, Nothing,
                             TryCast(_summary.CurrentRow.DataBoundItem, CashPositionAccountModel))
            If _position Is Nothing OrElse account Is Nothing Then
                _details.DataSource = Nothing
            Else
                _details.DataSource = New BindingList(Of CashPositionLineModel)(
                    _position.Lines.Where(Function(line) line.AccountIdNo = account.IdNo).ToList())
            End If
        End Sub

        Private Sub FormatSummary(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If e.RowIndex < 0 Then Return
            Dim account = TryCast(_summary.Rows(e.RowIndex).DataBoundItem, CashPositionAccountModel)
            If account Is Nothing Then Return
            If _summary.Columns(e.ColumnIndex).Name = "Review" Then
                Dim warnings As New List(Of String)
                If Not account.HasOpeningSnapshot Then warnings.Add(Caption("MissingAccountSnapshot"))
                If account.OpeningBalance < 0 Then warnings.Add(Caption("NegativeOpening"))
                If account.ClosingBalance < 0 Then warnings.Add(Caption("NegativeClosing"))
                If account.ClosingJournalLines > 0 Then warnings.Add(Caption("ReviewClosing"))
                If account.PostingReviewLines > 0 Then warnings.Add(Caption("ReviewPosting"))
                e.Value = String.Join("; ", warnings)
                e.FormattingApplied = True
            End If
        End Sub

        Private Sub FormatDetails(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If e.RowIndex < 0 Then Return
            Dim field = _details.Columns(e.ColumnIndex).Name
            If field = "HeaderPosted" OrElse field = "ItemPosted" OrElse field = "ClosingJournal" Then
                e.Value = If(e.Value Is Nothing, Caption("Unknown"), Caption(If(Convert.ToBoolean(e.Value), "Yes", "No")))
                e.FormattingApplied = True
            End If
        End Sub
    End Class
End Namespace
