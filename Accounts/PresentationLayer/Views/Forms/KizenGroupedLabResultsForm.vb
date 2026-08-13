Imports System.ComponentModel
Imports System.Drawing
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    ''' <summary>
    ''' Displays live Kizen laboratory details. This form is read-only by design.
    ''' </summary>
    Public NotInheritable Class KizenGroupedLabResultsForm
        Inherits Form

        Private ReadOnly _grid As New DataGridView()
        Private ReadOnly _results As BindingList(Of MedicalFitnessGroupedLabResultView)

        Public Sub New(invoiceNo As Int32,
                       testName As String,
                       results As BindingList(Of MedicalFitnessGroupedLabResultView))
            _results = If(results, New BindingList(Of MedicalFitnessGroupedLabResultView)())
            InitializeWindow(invoiceNo, testName)
            ConfigureGrid()
            _grid.DataSource = _results
        End Sub

        Private Sub InitializeWindow(invoiceNo As Int32, testName As String)
            Text = "Kizen Laboratory Results"
            StartPosition = FormStartPosition.CenterParent
            FormBorderStyle = FormBorderStyle.Sizable
            MinimizeBox = False
            MinimumSize = New Size(850, 480)
            ClientSize = New Size(1050, 620)

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
                .Text = String.Format(
                    "{0}{1}Invoice {2} — {3} result(s){1}Read-only live data from Kizen",
                    If(testName, "Laboratory Results"),
                    Environment.NewLine,
                    invoiceNo,
                    _results.Count)}

            Dim buttonPanel As New FlowLayoutPanel With {
                .AutoSize = True,
                .Dock = DockStyle.Fill,
                .FlowDirection = FlowDirection.RightToLeft,
                .WrapContents = False}
            Dim closeButton As New Button With {
                .AutoSize = True,
                .DialogResult = DialogResult.OK,
                .Text = "Close"}
            buttonPanel.Controls.Add(closeButton)

            layout.Controls.Add(heading, 0, 0)
            layout.Controls.Add(_grid, 0, 1)
            layout.Controls.Add(buttonPanel, 0, 2)
            Controls.Add(layout)
            AcceptButton = closeButton
            CancelButton = closeButton
        End Sub

        Private Sub ConfigureGrid()
            _grid.AllowUserToAddRows = False
            _grid.AllowUserToDeleteRows = False
            _grid.AllowUserToOrderColumns = True
            _grid.AutoGenerateColumns = False
            _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            _grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            _grid.BackgroundColor = SystemColors.Window
            _grid.Dock = DockStyle.Fill
            _grid.MultiSelect = False
            _grid.ReadOnly = True
            _grid.RowHeadersVisible = False
            _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            _grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True

            _grid.Columns.Add(CreateColumn("GroupName", "Group", 130.0F))
            _grid.Columns.Add(CreateColumn("TestName", "Analysis", 180.0F))
            _grid.Columns.Add(CreateColumn("ResultValue", "Result", 80.0F))
            _grid.Columns.Add(CreateColumn("ReferenceValue", "Reference Value", 150.0F))
            _grid.Columns.Add(CreateColumn("Unit", "Unit", 70.0F))
            _grid.Columns.Add(CreateColumn("Assessment", "Assessment", 90.0F))

            AddHandler _grid.CellFormatting, AddressOf GridCellFormatting
        End Sub

        Private Shared Function CreateColumn(propertyName As String,
                                             heading As String,
                                             fillWeight As Single) As DataGridViewTextBoxColumn
            Return New DataGridViewTextBoxColumn With {
                .DataPropertyName = propertyName,
                .HeaderText = heading,
                .Name = "col" & propertyName,
                .FillWeight = fillWeight,
                .ReadOnly = True}
        End Function

        Private Sub GridCellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
            If e.RowIndex < 0 OrElse e.RowIndex >= _grid.Rows.Count Then
                Return
            End If

            Dim result = TryCast(_grid.Rows(e.RowIndex).DataBoundItem, MedicalFitnessGroupedLabResultView)
            If result Is Nothing Then
                Return
            End If

            If String.Equals(result.Assessment, MedicalFitnessLabResultEvaluator.OutsideRangeAssessment, StringComparison.OrdinalIgnoreCase) Then
                _grid.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.MistyRose
                _grid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.DarkRed
            ElseIf String.Equals(result.Assessment, MedicalFitnessLabResultEvaluator.NeedsReviewAssessment, StringComparison.OrdinalIgnoreCase) Then
                _grid.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.LemonChiffon
                _grid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = SystemColors.WindowText
            Else
                _grid.Rows(e.RowIndex).DefaultCellStyle.BackColor = SystemColors.Window
                _grid.Rows(e.RowIndex).DefaultCellStyle.ForeColor = SystemColors.WindowText
            End If
        End Sub

    End Class

End Namespace
