Imports System
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Accounts.ServiceLayer

Namespace PresentationLayer.Views.Forms
    Public Class KizenCreditSalesImportForm
        Inherits Form

        Private ReadOnly _service As New KizenCreditSalesImportService()
        Private ReadOnly _startDate As New DateTimePicker()
        Private ReadOnly _endDate As New DateTimePicker()
        Private ReadOnly _preview As New Button()
        Private ReadOnly _post As New Button()
        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _status As New Label()
        Private _batch As KizenCreditSalesBatch

        Public Sub New()
            Text = "Kizen Credit Sales Import"
            ClientSize = New Size(980, 600)
            MinimumSize = New Size(760, 420)
            StartPosition = FormStartPosition.CenterParent
            RightToLeft = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = RightToLeft = RightToLeft.Yes

            Dim firstOfPreviousMonth = New DateTime(Today.Year, Today.Month, 1).AddMonths(-1)
            _startDate.Format = DateTimePickerFormat.Short
            _startDate.Value = firstOfPreviousMonth
            _endDate.Format = DateTimePickerFormat.Short
            _endDate.Value = firstOfPreviousMonth.AddMonths(1).AddDays(-1)
            _startDate.Width = 105
            _endDate.Width = 105
            AddHandler _startDate.ValueChanged, AddressOf PeriodChanged
            AddHandler _endDate.ValueChanged, AddressOf PeriodChanged

            _preview.Text = "Preview Kizen Data"
            _preview.Width = 145
            _post.Text = "Post AR Batch"
            _post.Width = 120
            _post.Enabled = False
            AddHandler _preview.Click, AddressOf PreviewClick
            AddHandler _post.Click, AddressOf PostClick

            Dim options As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 48, .Padding = New Padding(8), .WrapContents = False}
            options.Controls.Add(New Label With {.Text = "Month start", .AutoSize = True, .Margin = New Padding(3, 8, 3, 3)})
            options.Controls.Add(_startDate)
            options.Controls.Add(New Label With {.Text = "Month end", .AutoSize = True, .Margin = New Padding(12, 8, 3, 3)})
            options.Controls.Add(_endDate)
            options.Controls.Add(_preview)
            options.Controls.Add(_post)

            _grid.Dock = DockStyle.Fill
            _grid.ReadOnly = True
            _grid.AllowUserToAddRows = False
            _grid.AllowUserToDeleteRows = False
            _grid.AutoGenerateColumns = False
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Company code", .DataPropertyName = "CompanyCode"})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Company", .DataPropertyName = "CompanyName"})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Invoice number", .DataPropertyName = "ZatcaNumber"})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "AR amount", .DataPropertyName = "Amount", .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2"}})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "VAT", .DataPropertyName = "VatAmount", .DefaultCellStyle = New DataGridViewCellStyle With {.Format = "N2"}})
            _grid.Columns.Add(New DataGridViewTextBoxColumn With {.HeaderText = "Lines", .DataPropertyName = "ItemCount"})

            _status.Dock = DockStyle.Bottom
            _status.Height = 52
            _status.Padding = New Padding(8)
            _status.TextAlign = ContentAlignment.MiddleLeft
            _status.Text = "Preview the selected complete calendar month before posting."

            Controls.Add(_grid)
            Controls.Add(_status)
            Controls.Add(options)
        End Sub

        Private Sub PeriodChanged(sender As Object, e As EventArgs)
            _batch = Nothing
            _grid.DataSource = Nothing
            _post.Enabled = False
            _status.Text = "The period changed. Preview the Kizen data again."
        End Sub

        Private Sub PreviewClick(sender As Object, e As EventArgs)
            Try
                Cursor = Cursors.WaitCursor
                _batch = _service.LoadBatch(_startDate.Value.Date, _endDate.Value.Date)
                _grid.DataSource = _batch.Companies.Select(Function(c) New With {
                    .CompanyCode = c.CompanyCode,
                    .CompanyName = c.CompanyName,
                    .ZatcaNumber = c.ZatcaNumber,
                    .Amount = c.Amount,
                    .VatAmount = c.VatAmount,
                    .ItemCount = c.Items.Count
                }).ToList()
                _post.Enabled = True
                _status.Text = String.Format("{0:N0} source invoices / {1:N0} detail rows; {2} AR journals; total AR {3:N2}. One GL series reference will be allocated when posted.",
                                             _batch.SourceInvoiceCount, _batch.SourceDetailCount, _batch.JournalCount, _batch.SourceAmount)
            Catch ex As Exception
                _batch = Nothing
                _grid.DataSource = Nothing
                _post.Enabled = False
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub PostClick(sender As Object, e As EventArgs)
            If _batch Is Nothing Then Return
            If MessageBox.Show(Me, String.Format("Post {0} AR journals for {1:N2} from Kizen? The operation is atomic and uses one next GL series reference.", _batch.JournalCount, _batch.SourceAmount), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            Try
                Cursor = Cursors.WaitCursor
                Dim result = _service.Import(_batch)
                _post.Enabled = False
                _status.Text = String.Format("Posted {0} AR journals with reference {1}. Source invoices: {2:N0}; AR total: {3:N2}.", result.JournalCount, result.ReferenceNo, result.SourceInvoiceCount, result.SourceAmount)
                MessageBox.Show(Me, _status.Text, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
