Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.ServiceLayer

Namespace PresentationLayer.Views.Forms
    Public Class CashFlowReviewForm
        Inherits Form

        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _statement As CashFlowModel

        Public Sub New(statement As CashFlowModel)
            _statement = statement
            Text = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "مراجعة التدفقات النقدية", "Cash Flow Classification Review")
            ClientSize = New Size(1050, 600) : StartPosition = FormStartPosition.CenterParent
            RightToLeft = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = RightToLeft = RightToLeft.Yes
            _grid.Dock = DockStyle.Fill : _grid.ReadOnly = True : _grid.AllowUserToAddRows = False
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill : _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            For Each column In {New DataGridViewTextBoxColumn With {.HeaderText = "Journal", .Name = "Journal"}, New DataGridViewTextBoxColumn With {.HeaderText = "Date", .Name = "Date"}, New DataGridViewTextBoxColumn With {.HeaderText = "Account", .Name = "Account"}, New DataGridViewTextBoxColumn With {.HeaderText = "Amount", .Name = "Amount"}, New DataGridViewTextBoxColumn With {.HeaderText = "Status", .Name = "Status"}}
                _grid.Columns.Add(column)
            Next
            AddHandler _grid.CellDoubleClick, AddressOf OpenSource
            Controls.Add(_grid)
            LoadRows()
        End Sub

        Private Sub LoadRows()
            For Each line In _statement.Lines.Where(Function(x) x.IsWarning)
                For Each source In line.JournalLines.Where(Function(x) Math.Abs(x.Amount) > 0.005D)
                    Dim row = _grid.Rows.Add(source.JournalCode & "-" & source.JournalIdNo, source.TransactionDate.ToString("yyyy-MM-dd"), source.AccountCode & " - " & source.AccountName, source.Amount.ToString("N2"), line.Label)
                    _grid.Rows(row).Tag = source
                Next
            Next
        End Sub

        Private Sub OpenSource(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 Then Return
            Dim source = TryCast(_grid.Rows(e.RowIndex).Tag, CashFlowSourceLineModel)
            If source Is Nothing Then Return
            Try
                Using popup As New CashPositionTransactionForm(New CashFlowService().GetTransaction(source.JournalCode, source.JournalIdNo, source.ItemIdNo))
                    popup.ShowDialog(Me)
                End Using
            Catch ex As Exception
                MessageBox.Show(Me, "The source journal is unavailable.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub
    End Class
End Namespace
