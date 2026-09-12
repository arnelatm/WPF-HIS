Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Libraries.CBaseControlsLibrary

Namespace PresentationLayer.Views.Forms
    ' Inspection dialog: data is supplied by the Cash Position presenter/service.
    Public NotInheritable Class CashPositionTransactionForm
        Inherits Form

        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _transaction As CashPositionTransactionModel

        Public Sub New(transaction As CashPositionTransactionModel)
            If transaction Is Nothing Then Throw New ArgumentNullException(NameOf(transaction))
            _transaction = transaction
            Text = Caption("TransactionTitle") & " - " & transaction.JournalCode & " " & transaction.JournalIdNo.ToString()
            StartPosition = FormStartPosition.CenterParent
            ClientSize = New Size(1080, 620)
            MinimumSize = New Size(800, 480)
            MinimizeBox = False
            ShowInTaskbar = False
            Font = New Font("Segoe UI", 9.0!)
            BackColor = Color.White
            RightToLeft = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft

            Dim layout As New TableLayoutPanel With {.Dock = DockStyle.Fill, .ColumnCount = 1, .RowCount = 5, .Padding = New Padding(10)}
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 76))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100))
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            layout.RowStyles.Add(New RowStyle(SizeType.Absolute, 40))
            Dim dateText = If(transaction.TransactionDate.HasValue,
                              transaction.TransactionDate.GetValueOrDefault().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), Caption("Unknown"))
            Dim referenceText = transaction.ReferenceNo
            If RightToLeftLayout Then
                dateText = ChrW(&H200E) & dateText & ChrW(&H200E)
                referenceText = ChrW(&H200E) & referenceText & ChrW(&H200E)
            End If
            Dim heading As New CLabel With {.AutoSize = True, .Dock = DockStyle.Fill, .Padding = New Padding(0, 0, 0, 8),
                .Text = Caption("Date") & ": " & dateText & "    " & Caption("Reference") & ": " & referenceText & Environment.NewLine &
                    Caption("HeaderPosted") & ": " & Flag(transaction.Posted) & "    " & Caption("Approved") & ": " & Flag(transaction.Approved) &
                    "    " & Caption("Cancelled") & ": " & Flag(transaction.Cancelled) & "    " & Caption("ClosingEntry") & ": " & Flag(transaction.ClosingJournal)}
            layout.Controls.Add(heading, 0, 0)
            Dim notes As New TextBox With {.Dock = DockStyle.Fill, .ReadOnly = True, .Multiline = True,
                .ScrollBars = ScrollBars.Vertical, .BackColor = Color.White,
                .Text = Caption("Notes") & ": " & transaction.Notes}
            layout.Controls.Add(notes, 0, 1)

            With _grid
                .Dock = DockStyle.Fill
                .ReadOnly = True
                .AutoGenerateColumns = False
                .AllowUserToAddRows = False
                .AllowUserToDeleteRows = False
                .AllowUserToOrderColumns = True
                .MultiSelect = False
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .BackgroundColor = Color.White
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            End With
            AddColumn("Sequence", "Sequence", 65)
            AddColumn("ItemIdNo", "ItemId", 85)
            AddColumn("DisplayName", "Account", 280)
            AddColumn("Debit", "Debit", 115, "N2")
            AddColumn("Credit", "Credit", 115, "N2")
            AddColumn("Posted", "ItemPosted", 105)
            AddColumn("Notes", "Notes", 280)
            _grid.Columns("Notes").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            AddHandler _grid.CellFormatting, Sub(sender, e)
                                                 If e.RowIndex >= 0 AndAlso _grid.Columns(e.ColumnIndex).Name = "Posted" Then
                                                     e.Value = Flag(TryCast(_grid.Rows(e.RowIndex).DataBoundItem, CashPositionTransactionLineModel).Posted)
                                                     e.FormattingApplied = True
                                                 End If
                                             End Sub
            AddHandler _grid.DataBindingComplete, Sub() SelectSourceLine()
            layout.Controls.Add(_grid, 0, 2)
            Dim debits = transaction.Lines.Sum(Function(line) line.Debit)
            Dim credits = transaction.Lines.Sum(Function(line) line.Credit)
            Dim totals As New CLabel With {.AutoSize = True, .Dock = DockStyle.Fill, .Padding = New Padding(0, 8, 0, 8),
                .Text = String.Format(CultureInfo.CurrentCulture, Caption("TransactionTotals"), debits, credits, debits - credits)}
            layout.Controls.Add(totals, 0, 3)
            Dim closeButton As New CButton With {.Text = Caption("Close"), .DialogResult = DialogResult.Cancel, .Size = New Size(110, 32)}
            Dim commands As New FlowLayoutPanel With {.Dock = DockStyle.Fill, .FlowDirection = FlowDirection.RightToLeft}
            commands.Controls.Add(closeButton)
            layout.Controls.Add(commands, 0, 4)
            CancelButton = closeButton
            Controls.Add(layout)
            _grid.DataSource = New BindingList(Of CashPositionTransactionLineModel)(transaction.Lines)
        End Sub

        Protected Overrides Sub OnShown(e As EventArgs)
            MyBase.OnShown(e)
            SelectSourceLine()
            _grid.Focus()
        End Sub

        Private Sub SelectSourceLine()
            For Each row As DataGridViewRow In _grid.Rows
                Dim line = TryCast(row.DataBoundItem, CashPositionTransactionLineModel)
                If line IsNot Nothing AndAlso line.ItemIdNo = _transaction.SelectedItemIdNo Then
                    _grid.CurrentCell = row.Cells("DisplayName")
                    Return
                End If
            Next
        End Sub

        Private Sub AddColumn(field As String, key As String, width As Integer, Optional format As String = Nothing)
            Dim column As New DataGridViewTextBoxColumn With {.Name = field, .DataPropertyName = field,
                .HeaderText = Caption(key), .Width = width, .SortMode = DataGridViewColumnSortMode.NotSortable}
            If format IsNot Nothing Then
                column.DefaultCellStyle.Format = format
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            _grid.Columns.Add(column)
        End Sub

        Private Shared Function Flag(value As Boolean?) As String
            Return If(value.HasValue, Caption(If(value.GetValueOrDefault(), "Yes", "No")), Caption("Unknown"))
        End Function
    End Class
End Namespace
