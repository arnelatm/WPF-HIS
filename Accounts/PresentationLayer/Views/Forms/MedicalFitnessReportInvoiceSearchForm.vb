Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer

Namespace PresentationLayer.Views.Forms

    Public NotInheritable Class MedicalFitnessReportInvoiceSearchForm
        Inherits Form

        Private ReadOnly _grid As New DataGridView()
        Private _selectedInvoiceNo As Int32

        Public Sub New(results As List(Of MedicalFitnessReportInvoiceSearchResult))
            InitializeWindow()
            ConfigureGrid()
            _grid.DataSource = If(results, New List(Of MedicalFitnessReportInvoiceSearchResult)())
            If _grid.Rows.Count > 0 Then
                _grid.Rows(0).Selected = True
                _grid.CurrentCell = _grid.Rows(0).Cells(0)
            End If
        End Sub

        Public ReadOnly Property SelectedInvoiceNo As Int32
            Get
                Return _selectedInvoiceNo
            End Get
        End Property

        Private Sub InitializeWindow()
            Text = "Medical Report Invoice Search"
            StartPosition = FormStartPosition.CenterParent
            FormBorderStyle = FormBorderStyle.Sizable
            MinimizeBox = False
            MaximizeBox = False
            MinimumSize = New Size(760, 360)
            ClientSize = New Size(900, 460)

            Dim layout As New TableLayoutPanel With {
                .ColumnCount = 1,
                .RowCount = 3,
                .Dock = DockStyle.Fill,
                .Padding = New Padding(10)}
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            layout.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
            layout.RowStyles.Add(New RowStyle(SizeType.AutoSize))

            Dim heading As New Label With {
                .AutoSize = True,
                .Dock = DockStyle.Fill,
                .Font = New Font(Font, FontStyle.Bold),
                .Padding = New Padding(0, 0, 0, 8),
                .Text = "Select an invoice. Results are ordered by invoice date (newest first)."}

            Dim buttonPanel As New FlowLayoutPanel With {
                .AutoSize = True,
                .Dock = DockStyle.Fill,
                .FlowDirection = FlowDirection.RightToLeft,
                .WrapContents = False}
            Dim cancelButton As New Button With {
                .AutoSize = True,
                .DialogResult = DialogResult.Cancel,
                .Text = "Cancel"}
            Dim selectButton As New Button With {
                .AutoSize = True,
                .Text = "Select"}
            AddHandler selectButton.Click, AddressOf SelectButtonClicked
            buttonPanel.Controls.Add(cancelButton)
            buttonPanel.Controls.Add(selectButton)

            layout.Controls.Add(heading, 0, 0)
            layout.Controls.Add(_grid, 0, 1)
            layout.Controls.Add(buttonPanel, 0, 2)
            Controls.Add(layout)

            AcceptButton = selectButton
            CancelButton = cancelButton
        End Sub

        Private Sub ConfigureGrid()
            _grid.AllowUserToAddRows = False
            _grid.AllowUserToDeleteRows = False
            _grid.AutoGenerateColumns = False
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            _grid.BackgroundColor = SystemColors.Window
            _grid.Dock = DockStyle.Fill
            _grid.MultiSelect = False
            _grid.ReadOnly = True
            _grid.RowHeadersVisible = False
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            _grid.Columns.Add(CreateColumn("InvoiceNo", "Invoice No.", 90.0F))
            _grid.Columns.Add(CreateColumn("InvoiceDate", "Invoice Date", 110.0F, "dd/MM/yyyy"))
            _grid.Columns.Add(CreateColumn("FileNo", "File No.", 90.0F))
            _grid.Columns.Add(CreateColumn("IdentityNo", "ID No.", 130.0F))
            _grid.Columns.Add(CreateColumn("PatientName", "Patient Name", 220.0F))

            AddHandler _grid.CellDoubleClick, AddressOf GridCellDoubleClick
            AddHandler _grid.KeyDown, AddressOf GridKeyDown
        End Sub

        Private Shared Function CreateColumn(propertyName As String,
                                             heading As String,
                                             fillWeight As Single,
                                             Optional format As String = Nothing) As DataGridViewTextBoxColumn
            Dim column As New DataGridViewTextBoxColumn With {
                .DataPropertyName = propertyName,
                .HeaderText = heading,
                .Name = "col" & propertyName,
                .FillWeight = fillWeight,
                .ReadOnly = True}
            If Not String.IsNullOrWhiteSpace(format) Then
                column.DefaultCellStyle = New DataGridViewCellStyle With {.Format = format}
            End If
            Return column
        End Function

        Private Sub SelectButtonClicked(sender As Object, e As EventArgs)
            SelectCurrentInvoice()
        End Sub

        Private Sub GridCellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex >= 0 Then
                SelectCurrentInvoice()
            End If
        End Sub

        Private Sub GridKeyDown(sender As Object, e As KeyEventArgs)
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                SelectCurrentInvoice()
            End If
        End Sub

        Private Sub SelectCurrentInvoice()
            If _grid.CurrentRow Is Nothing Then
                Return
            End If

            Dim selected = TryCast(_grid.CurrentRow.DataBoundItem, MedicalFitnessReportInvoiceSearchResult)
            If selected Is Nothing Then
                Return
            End If

            _selectedInvoiceNo = selected.InvoiceNo
            DialogResult = DialogResult.OK
        End Sub

    End Class

End Namespace
