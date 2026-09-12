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
    Public Class CashFlowForm
        Inherits BFMain
        Implements ICashFlowView

        Private ReadOnly _from As New CDateTimePicker(), _to As New CDateTimePicker()
        Private ReadOnly _accounts As New CheckedListBox(), _load As New CButton(), _review As New CButton(), _setup As New CButton()
        Private ReadOnly _all As New CButton(), _none As New CButton()
        Private ReadOnly _grid As New DataGridView(), _status As New CLabel()
        Private ReadOnly _filters As New FlowLayoutPanel()
        Private ReadOnly _captions As New Dictionary(Of Control, String)()
        Private _statement As CashFlowModel, _binding As Boolean

        Public Event InitializeRequested() Implements ICashFlowView.InitializeRequested
        Public Event RefreshRequested() Implements ICashFlowView.RefreshRequested
        Public Event SourceRequested(code As String, journalIdNo As Integer, itemIdNo As Integer) Implements ICashFlowView.SourceRequested

        Public Sub New()
            Name = "CashFlowForm" : ViewDisplayName = "Statement of Cash Flows"
            ClientSize = New Size(1250, 760) : MinimumSize = New Size(1050, 600)
            StartPosition = FormStartPosition.CenterParent : Font = New Font("Segoe UI", 9.0!) : BackColor = Color.White
            ConfigureDate(_from, New Date(2025, 12, 1)) : ConfigureDate(_to, New Date(2025, 12, 31))
            AddCaption(_filters, New CLabel With {.AutoSize = True, .Margin = New Padding(4, 8, 4, 0)}, "From") : _filters.Controls.Add(_from)
            AddCaption(_filters, New CLabel With {.AutoSize = True, .Margin = New Padding(12, 8, 4, 0)}, "To") : _filters.Controls.Add(_to)
            _load.Size = New Size(120, 32) : AddCaption(_filters, _load, "Load")
            _review.Size = New Size(120, 32) : _review.Text = "Review" : _filters.Controls.Add(_review)
            AddHandler _review.Click, Sub()
                                          If _statement IsNot Nothing Then
                                              Using review As New CashFlowReviewForm(_statement)
                                                  review.ShowDialog(Me)
                                              End Using
                                          End If
                                      End Sub
            _setup.Size = New Size(120, 32) : _setup.Text = "Setup" : _filters.Controls.Add(_setup)
            AddHandler _setup.Click, Sub()
                                         Using setup As New CashFlowSetupForm()
                                             setup.ShowDialog(Me)
                                         End Using
                                         RaiseEvent InitializeRequested()
                                     End Sub
            AddHandler _load.Click, Sub() RaiseEvent RefreshRequested()
            AddCaption(_filters, New CLabel With {.AutoSize = True, .Margin = New Padding(12, 8, 4, 0)}, "Basis")
            _filters.Dock = DockStyle.Top : _filters.Height = 52 : _filters.Padding = New Padding(8)

            Dim layout As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 2, .Padding = New Padding(8)}
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 290)) : layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            Dim left As New Panel With {.Dock = DockStyle.Fill, .Padding = New Padding(0, 0, 8, 0)}
            AddCaption(left, New CLabel With {.Dock = DockStyle.Top, .Height = 42}, "Accounts")
            _accounts.Dock = DockStyle.Fill : _accounts.CheckOnClick = True : _accounts.IntegralHeight = False : _accounts.DisplayMember = "DisplayName"
            AddHandler _accounts.Format, AddressOf FormatAccount
            ConfigureAccountButtons(left) : left.Controls.Add(_accounts) : _accounts.BringToFront() : layout.Controls.Add(left, 0, 0)
            ConfigureGrid() : layout.Controls.Add(_grid, 1, 0)
            Controls.Add(layout) : _status.Dock = DockStyle.Bottom : _status.Height = 38 : _status.Padding = New Padding(8) : Controls.Add(_status) : Controls.Add(_filters)
            AddHandler _grid.CellDoubleClick, AddressOf GridDoubleClick
            AddHandler _from.ValueChanged, Sub() ClearStatement()
            AddHandler _to.ValueChanged, Sub() ClearStatement()
            ApplyCaptions()
        End Sub

        Private Sub ConfigureAccountButtons(parent As Control)
            Dim buttons As New FlowLayoutPanel With {.Dock = DockStyle.Bottom, .Height = 42}
            _all.Size = New Size(120, 30) : _none.Size = New Size(120, 30)
            AddCaption(buttons, _all, "SelectAll") : AddCaption(buttons, _none, "ClearSelection")
            AddHandler _all.Click, Sub() CheckAccounts(True)
            AddHandler _none.Click, Sub() CheckAccounts(False)
            parent.Controls.Add(buttons)
        End Sub

        Private Sub ConfigureGrid()
            _grid.Dock = DockStyle.Fill : _grid.ReadOnly = True : _grid.AutoGenerateColumns = False : _grid.AllowUserToAddRows = False : _grid.RowHeadersVisible = False
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect : _grid.BackgroundColor = Color.White
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Section", .HeaderText = "Section", .DataPropertyName = "Section", .Width = 130})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Label", .HeaderText = "Description", .DataPropertyName = "Label", .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "Amount", .HeaderText = "Amount", .DataPropertyName = "Amount", .Width = 150, .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2", .Alignment = DataGridViewContentAlignment.MiddleRight}})
            AddHandler _grid.CellFormatting, AddressOf FormatLine
        End Sub

        Private Sub FormatAccount(sender As Object, e As ListControlConvertEventArgs)
            Dim account = TryCast(e.ListItem, CashFlowAccountModel)
            If account IsNot Nothing Then e.Value = account.DisplayName & If(account.Active, "", " (inactive)")
        End Sub

        Private Sub FormatLine(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If e.RowIndex < 0 Then Return
            Dim line = TryCast(_grid.Rows(e.RowIndex).DataBoundItem, CashFlowLineModel)
            If line Is Nothing Then Return
            If e.ColumnIndex = 1 Then e.Value = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, line.LabelAra, line.Label) : e.FormattingApplied = True
            If line.IsTotal Then _grid.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(_grid.Font, FontStyle.Bold)
            If line.IsWarning Then _grid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed
        End Sub

        Private Sub ConfigureDate(picker As CDateTimePicker, value As Date)
            picker.Format = DateTimePickerFormat.Custom : picker.CustomFormat = "yyyy-MM-dd" : picker.Width = 140 : picker.Value = value
        End Sub
        Private Sub AddCaption(parent As Control, control As Control, key As String)
            _captions(control) = key
            parent.Controls.Add(control)
        End Sub

        Private Sub ApplyCaptions()
            Text = CashFlowText.GetCaption("Title")
            Dim rtl = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft : RightToLeft = If(rtl, RightToLeft.Yes, RightToLeft.No) : RightToLeftLayout = rtl
            _review.Text = If(rtl, "مراجعة", "Review")
            _setup.Text = If(rtl, "إعداد", "Setup")
            For Each pair In _captions : pair.Key.Text = CashFlowText.GetCaption(pair.Value) : Next
            _grid.Columns(0).HeaderText = CashFlowText.GetCaption("Title") : _grid.Columns(1).HeaderText = CashFlowText.GetCaption("Accounts") : _grid.Columns(2).HeaderText = CashFlowText.GetCaption("Amount")
        End Sub

        Private Sub CheckAccounts(value As Boolean)
            _binding = True
            Try : For i = 0 To _accounts.Items.Count - 1 : _accounts.SetItemChecked(i, value) : Next
            Finally : _binding = False : End Try
            ClearStatement()
        End Sub

        Private Sub GridDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
            If _statement Is Nothing OrElse e.RowIndex < 0 Then Return
            Dim line = TryCast(_grid.Rows(e.RowIndex).DataBoundItem, CashFlowLineModel)
            If line Is Nothing OrElse line.JournalLines.Count = 0 Then Return
            Dim source = line.JournalLines(0) : RaiseEvent SourceRequested(source.JournalCode, source.JournalIdNo, source.ItemIdNo)
        End Sub

        Public ReadOnly Property BeginningDate As Date Implements ICashFlowView.BeginningDate
            Get
                Return _from.Value.Date
            End Get
        End Property
        Public ReadOnly Property EndingDate As Date Implements ICashFlowView.EndingDate
            Get
                Return _to.Value.Date
            End Get
        End Property
        Public ReadOnly Property SelectedAccountIds As List(Of Short) Implements ICashFlowView.SelectedAccountIds
            Get
                Return _accounts.CheckedItems.Cast(Of CashFlowAccountModel)().Select(Function(a) a.IdNo).ToList()
            End Get
        End Property

        Public Sub SetAccounts(accounts As List(Of CashFlowAccountModel)) Implements ICashFlowView.SetAccounts
            _binding = True
            Try : _accounts.Items.Clear() : For Each account In accounts : _accounts.Items.Add(account, True) : Next
            Finally : _binding = False : End Try
        End Sub
        Public Sub ShowStatement(statement As CashFlowModel) Implements ICashFlowView.ShowStatement
            _statement = statement : _grid.DataSource = New BindingList(Of CashFlowLineModel)(statement.Lines)
            If Math.Abs(statement.ReconciliationDifference) > 0.005D Then
                _status.Text = CashFlowText.GetCaption("OutOfBalance") & "  Difference: " & statement.ReconciliationDifference.ToString("N2")
            Else
                _status.Text = CashFlowText.GetCaption("Reconciled") & "  Difference: 0.00"
                If statement.ReviewMessages.Count > 0 Then _status.Text &= "  Review required"
            End If
            _status.ForeColor = If(Math.Abs(statement.ReconciliationDifference) > 0.005D OrElse statement.ReviewMessages.Count > 0, Color.DarkRed, Color.DarkGreen)
        End Sub
        Public Sub ClearStatement() Implements ICashFlowView.ClearStatement
            If Not _binding Then _statement = Nothing : _grid.DataSource = Nothing : _status.Text = CashFlowText.GetCaption("ChooseAndLoad")
        End Sub
        Public Sub ShowSource(source As CashPositionTransactionModel) Implements ICashFlowView.ShowSource
            Using popup As New CashPositionTransactionForm(source) : popup.ShowDialog(Me) : End Using
        End Sub
        Public Sub ShowError(messageKey As String) Implements ICashFlowView.ShowError
            _status.Text = CashFlowText.GetCaption(messageKey) : MessageBox.Show(Me, _status.Text, CashFlowText.GetCaption("Title"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub
        Public Sub SetBusy(busy As Boolean) Implements ICashFlowView.SetBusy
            UseWaitCursor = busy
            _load.Enabled = Not busy
            _review.Enabled = Not busy AndAlso _statement IsNot Nothing
            _setup.Enabled = Not busy
            _accounts.Enabled = Not busy
        End Sub
        Protected Overrides Sub OnShown(e As EventArgs)
            MyBase.OnShown(e)
            ApplyCaptions()
            RaiseEvent InitializeRequested()
        End Sub
    End Class
End Namespace
