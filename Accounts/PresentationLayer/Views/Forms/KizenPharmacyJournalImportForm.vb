Imports System
Imports System.Drawing
Imports System.Globalization
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Accounts.ServiceLayer

Namespace PresentationLayer.Views.Forms
    Public Class KizenPharmacyJournalImportForm
        Inherits Form

        Private ReadOnly _service As New KizenPharmacyJournalImportService()
        Private ReadOnly _start As New DateTimePicker()
        Private ReadOnly _end As New DateTimePicker()
        Private ReadOnly _preview As New Button()
        Private ReadOnly _post As New Button()
        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _status As New Label()
        Private _batch As KizenRevenueJournalBatch

        Public Sub New()
            Text = "Import Kizen Pharmacy Sales to General Journal"
            ClientSize = New Size(1040, 590) : MinimumSize = New Size(820, 420)
            StartPosition = FormStartPosition.CenterParent
            RightToLeft = If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, RightToLeft.Yes, RightToLeft.No)
            RightToLeftLayout = RightToLeft = RightToLeft.Yes
            Dim firstMonth = New DateTime(Today.Year, Today.Month, 1).AddMonths(-1)
            _start.Format = DateTimePickerFormat.Short : _start.Value = firstMonth : _start.Width = 105
            _end.Format = DateTimePickerFormat.Short : _end.Value = firstMonth.AddMonths(1).AddDays(-1) : _end.Width = 105
            AddHandler _start.ValueChanged, AddressOf PeriodChanged : AddHandler _end.ValueChanged, AddressOf PeriodChanged
            _preview.Text = "Preview Pharmacy Data" : _preview.Width = 155
            _post.Text = "Create General Journal" : _post.Width = 165 : _post.Enabled = False
            AddHandler _preview.Click, AddressOf PreviewClick : AddHandler _post.Click, AddressOf PostClick
            Dim options As New FlowLayoutPanel With {.Dock = DockStyle.Top, .Height = 48, .Padding = New Padding(8), .WrapContents = False}
            options.Controls.Add(New Label With {.Text = "Month start", .AutoSize = True, .Margin = New Padding(3, 8, 3, 3)})
            options.Controls.Add(_start) : options.Controls.Add(New Label With {.Text = "Month end", .AutoSize = True, .Margin = New Padding(12, 8, 3, 3)})
            options.Controls.Add(_end) : options.Controls.Add(_preview) : options.Controls.Add(_post)
            _grid.Dock = DockStyle.Fill : _grid.ReadOnly = True : _grid.AllowUserToAddRows = False : _grid.AllowUserToDeleteRows = False
            _grid.AutoGenerateColumns = False : _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect : _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            AddColumn("RevCostCenterIdNo", "Cost center ID") : AddColumn("RevCostCenterName", "Revenue cost center") : AddColumn("DoctorCode", "Doctor code")
            AddColumn("Taxable", "Taxable (402)", "N2") : AddColumn("Vat", "VAT (232)", "N2")
            AddColumn("ZeroRated", "Zero-rated (414)", "N2") : AddColumn("WithVat", "Total (419)", "N2")
            _status.Dock = DockStyle.Bottom : _status.Height = 60 : _status.Padding = New Padding(8) : _status.TextAlign = ContentAlignment.MiddleLeft
            _status.Text = "Preview receipt sales from Pharmacy. Taxable, zero-rated and VAT amounts follow the receipt allocations."
            Controls.Add(_grid) : Controls.Add(_status) : Controls.Add(options)
        End Sub

        Private Sub AddColumn(field As String, caption As String, Optional format As String = Nothing)
            Dim column As New DataGridViewTextBoxColumn With {.HeaderText = caption, .DataPropertyName = field}
            If format IsNot Nothing Then column.DefaultCellStyle.Format = format
            _grid.Columns.Add(column)
        End Sub

        Private Sub PeriodChanged(sender As Object, e As EventArgs)
            _batch = Nothing : _grid.DataSource = Nothing : _post.Enabled = False
            _status.Text = "Period changed. Preview the Pharmacy data again."
        End Sub

        Private Sub PreviewClick(sender As Object, e As EventArgs)
            Try
                Cursor = Cursors.WaitCursor
                If _service.IsMonthImported(_start.Value.Date) Then
                    _batch = Nothing : _grid.DataSource = Nothing : _post.Enabled = False
                    _status.Text = String.Format("Kizen Pharmacy sales for {0:MMMM yyyy} have already been imported.", _start.Value)
                    MessageBox.Show(Me, _status.Text, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                _batch = _service.LoadBatch(_start.Value.Date, _end.Value.Date)
                _grid.DataSource = _batch.CostCenters.Select(Function(c) New With {
                    .RevCostCenterIdNo = c.RevCostCenterIdNo, .RevCostCenterName = c.RevCostCenterName,
                    .DoctorCode = c.DoctorCode, .Taxable = c.Taxable, .Vat = c.Vat, .ZeroRated = c.ZeroRated, .WithVat = c.WithVat
                }).ToList()
                _post.Enabled = True
                _status.Text = String.Format("{0:N0} Pharmacy receipts / {1:N0} invoices; {2:N0} revenue cost centers; taxable (402) {5:N2}; exempt none; zero-rated (414) {3:N2}; VAT (232) {6:N2}; total (419) {4:N2}.",
                    _batch.ReceiptCount, _batch.InvoiceCount, _batch.CostCenters.Count, _batch.ZeroRated, _batch.WithVat, _batch.Taxable, _batch.Vat)
            Catch ex As Exception
                _batch = Nothing : _grid.DataSource = Nothing : _post.Enabled = False
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub PostClick(sender As Object, e As EventArgs)
            If _batch Is Nothing Then Return
            Try
                If _service.IsMonthImported(_batch.SourcePeriodStart) Then
                    _post.Enabled = False
                    _status.Text = String.Format("Kizen Pharmacy sales for {0:MMMM yyyy} have already been imported.", _batch.SourcePeriodStart)
                    MessageBox.Show(Me, _status.Text, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
            If MessageBox.Show(Me, String.Format("Create one General Journal for {0:N2} Pharmacy receipt sales for {1:MMMM yyyy}?", _batch.WithVat, _batch.SourcePeriodStart), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
            Try
                Cursor = Cursors.WaitCursor
                Dim result = _service.Import(_batch)
                If result.AlreadyImported Then
                    _post.Enabled = False
                    _status.Text = String.Format("Kizen Pharmacy sales for {0:MMMM yyyy} have already been imported.", _batch.SourcePeriodStart)
                    MessageBox.Show(Me, _status.Text, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                _post.Enabled = False
                _status.Text = String.Format("Created Pharmacy General Journal {0} (ID {1}) for {2:N2}.", result.ReferenceNo, result.JournalIdNo, _batch.WithVat)
                MessageBox.Show(Me, _status.Text, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(Me, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try
        End Sub
    End Class
End Namespace
