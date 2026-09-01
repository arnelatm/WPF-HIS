Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet

Namespace PresentationLayer.Views.Forms

    Public Class MedicalFitnessReportFormatForm
        Inherits MedicalFitnessMaintenanceFormBase

        Private ReadOnly _dao As New MedicalFitnessReportDao()
        Private _selectedIdNo As Int32
        Private _loading As Boolean

        Private txtCode As TextBox
        Private txtTitleEnglish As TextBox
        Private txtTitleArabic As TextBox
        Private txtCrystalFileName As TextBox
        Private numDisplayOrder As NumericUpDown
        Private chkActive As CheckBox
        Private chkDefault As CheckBox
        Private dgvFormats As DataGridView
        Private btnNew As Button
        Private btnSave As Button
        Private btnItems As Button
        Private btnAssignments As Button
        Private btnClose As Button

        Public Sub New()
            Text = "Medical Fitness Report Formats"
            StartPosition = FormStartPosition.CenterParent
            MinimumSize = New Size(900, 520)
            ClientSize = New Size(1050, 620)
            Font = SystemFonts.MessageBoxFont
            BuildControls()
            AddHandler Load, AddressOf FormLoad
        End Sub

        Private Sub BuildControls()
            Dim editor = New TableLayoutPanel With {
                .ColumnCount = 8, .Dock = DockStyle.Fill, .Padding = New Padding(8), .RowCount = 2}
            For index = 0 To 3
                editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
                editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Next
            editor.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0!))
            editor.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0!))

            txtCode = CreateTextBox(50)
            txtTitleEnglish = CreateTextBox(255)
            txtTitleArabic = CreateTextBox(255)
            txtCrystalFileName = CreateTextBox(255)
            AddField(editor, "Format Code", txtCode, 0, 0)
            AddField(editor, "English Title", txtTitleEnglish, 2, 0)
            AddField(editor, "Arabic Title", txtTitleArabic, 4, 0)
            AddField(editor, "Crystal File", txtCrystalFileName, 6, 0)

            numDisplayOrder = New NumericUpDown With {.Dock = DockStyle.Fill, .Minimum = 1, .Maximum = 2147483647, .Value = 10}
            AddField(editor, "Display Order", numDisplayOrder, 0, 1)
            chkActive = New CheckBox With {.AutoSize = True, .Text = "Active", .Checked = True}
            chkDefault = New CheckBox With {.AutoSize = True, .Text = "Default"}
            editor.Controls.Add(chkActive, 2, 1)
            editor.Controls.Add(chkDefault, 4, 1)

            btnNew = New Button With {.AutoSize = True, .Text = "New"}
            btnSave = New Button With {.AutoSize = True, .Text = "Save"}
            btnItems = New Button With {.AutoSize = True, .Text = "Configure Items"}
            btnAssignments = New Button With {.AutoSize = True, .Text = "Assign Companies"}
            btnClose = New Button With {.AutoSize = True, .Text = "Close", .DialogResult = DialogResult.Cancel}
            AddHandler btnNew.Click, AddressOf NewClick
            AddHandler btnSave.Click, AddressOf SaveClick
            AddHandler btnItems.Click, AddressOf ItemsClick
            AddHandler btnAssignments.Click, AddressOf AssignmentsClick
            AddHandler btnClose.Click, Sub() Close()

            Dim actionPanel = New FlowLayoutPanel With {
                .AutoSize = False, .Dock = DockStyle.Top, .Height = 42,
                .Padding = New Padding(8, 8, 8, 4), .WrapContents = False}
            actionPanel.Controls.Add(btnNew)
            actionPanel.Controls.Add(btnSave)
            actionPanel.Controls.Add(btnItems)
            actionPanel.Controls.Add(btnAssignments)
            actionPanel.Controls.Add(btnClose)

            dgvFormats = New DataGridView With {
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False,
                .AutoGenerateColumns = False, .Dock = DockStyle.Fill, .MultiSelect = False,
                .ReadOnly = True, .RowHeadersVisible = False,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect}
            AddGridColumn("Code", "FormatCode", 120)
            AddGridColumn("English Title", "TitleEnglish", 250)
            AddGridColumn("Crystal File", "CrystalReportFileName", 240)
            AddGridColumn("Order", "DisplayOrder", 70)
            AddGridColumn("Active", "Active", 70, True)
            AddGridColumn("Default", "IsDefault", 70, True)
            AddHandler dgvFormats.SelectionChanged, AddressOf FormatSelectionChanged

            Dim split = New SplitContainer With {
                .Dock = DockStyle.Fill, .FixedPanel = FixedPanel.Panel1,
                .Orientation = Orientation.Horizontal, .Panel1MinSize = 90,
                .SplitterDistance = 100}
            split.Panel1.Controls.Add(editor)
            split.Panel2.Controls.Add(dgvFormats)
            MaintenanceContent.Controls.Add(CreateMaintenanceLayout(actionPanel, split))
            AcceptButton = btnSave
            CancelButton = btnClose
        End Sub

        Private Shared Function CreateTextBox(maxLength As Int32) As TextBox
            Return New TextBox With {.Dock = DockStyle.Fill, .MaxLength = maxLength}
        End Function

        Private Shared Sub AddField(layout As TableLayoutPanel, labelText As String, control As Control,
                                     labelColumn As Int32, row As Int32)
            layout.Controls.Add(New Label With {.AutoSize = True, .Dock = DockStyle.Fill,
                                                .Text = labelText, .TextAlign = ContentAlignment.MiddleLeft}, labelColumn, row)
            layout.Controls.Add(control, labelColumn + 1, row)
        End Sub

        Private Sub AddGridColumn(headerText As String, propertyName As String, width As Int32,
                                  Optional checkBox As Boolean = False)
            Dim column As DataGridViewColumn = If(checkBox,
                                                  CType(New DataGridViewCheckBoxColumn(), DataGridViewColumn),
                                                  CType(New DataGridViewTextBoxColumn(), DataGridViewColumn))
            column.DataPropertyName = propertyName
            column.HeaderText = headerText
            column.Width = width
            dgvFormats.Columns.Add(column)
        End Sub

        Private Sub FormLoad(sender As Object, e As EventArgs)
            RefreshFormats()
        End Sub

        Private Sub RefreshFormats(Optional selectedIdNo As Int32 = 0)
            Try
                _loading = True
                dgvFormats.DataSource = _dao.GetReportFormats(True)
                dgvFormats.ClearSelection()
                SelectRow(selectedIdNo)
                If dgvFormats.CurrentRow Is Nothing Then
                    ClearEditor()
                Else
                    LoadFormat(TryCast(dgvFormats.CurrentRow.DataBoundItem, MedicalFitnessReportFormat))
                End If
            Catch ex As Exception
                MessageBox.Show("Unable to load report formats." & Environment.NewLine & ex.Message,
                                "Report Formats", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _loading = False
            End Try
        End Sub

        Private Sub SelectRow(idNo As Int32)
            If idNo = 0 Then Return
            For Each row As DataGridViewRow In dgvFormats.Rows
                Dim format = TryCast(row.DataBoundItem, MedicalFitnessReportFormat)
                If format IsNot Nothing AndAlso format.MRIdNo = idNo Then
                    row.Selected = True
                    dgvFormats.CurrentCell = row.Cells(0)
                    Exit For
                End If
            Next
        End Sub

        Private Sub FormatSelectionChanged(sender As Object, e As EventArgs)
            If Not _loading Then LoadFormat(TryCast(dgvFormats.CurrentRow?.DataBoundItem, MedicalFitnessReportFormat))
        End Sub

        Private Sub LoadFormat(format As MedicalFitnessReportFormat)
            If format Is Nothing Then ClearEditor() : Return
            _selectedIdNo = format.MRIdNo
            txtCode.Text = If(format.FormatCode, "")
            txtCode.ReadOnly = True
            txtTitleEnglish.Text = If(format.TitleEnglish, "")
            txtTitleArabic.Text = If(format.TitleArabic, "")
            txtCrystalFileName.Text = If(format.CrystalReportFileName, "")
            numDisplayOrder.Value = Math.Max(numDisplayOrder.Minimum, Math.Min(numDisplayOrder.Maximum, format.DisplayOrder))
            chkActive.Checked = format.Active
            chkDefault.Checked = format.IsDefault
        End Sub

        Private Sub ClearEditor()
            _selectedIdNo = 0
            txtCode.ReadOnly = False
            txtCode.Clear()
            txtTitleEnglish.Clear()
            txtTitleArabic.Clear()
            txtCrystalFileName.Clear()
            numDisplayOrder.Value = 10
            chkActive.Checked = True
            chkDefault.Checked = False
        End Sub

        Private Sub NewClick(sender As Object, e As EventArgs)
            ClearEditor()
            txtCode.Focus()
        End Sub

        Private Sub SaveClick(sender As Object, e As EventArgs)
            Dim code = txtCode.Text.Trim().ToUpperInvariant()
            Dim title = txtTitleEnglish.Text.Trim()
            Dim fileName = txtCrystalFileName.Text.Trim()
            If String.IsNullOrWhiteSpace(code) OrElse String.IsNullOrWhiteSpace(title) OrElse String.IsNullOrWhiteSpace(fileName) Then
                MessageBox.Show("Format Code, English Title, and Crystal File are required.")
                Return
            End If
            If Path.GetFileName(fileName) <> fileName OrElse fileName.Contains("..") Then
                MessageBox.Show("Crystal File must be a file name located in the configured report folder.")
                Return
            End If

            Try
                Dim format As New MedicalFitnessReportFormat With {
                    .MRIdNo = _selectedIdNo, .FormatCode = code, .TitleEnglish = title,
                    .TitleArabic = txtTitleArabic.Text.Trim(), .CrystalReportFileName = fileName,
                    .DisplayOrder = CInt(numDisplayOrder.Value), .Active = chkActive.Checked,
                    .IsDefault = chkDefault.Checked}
                Dim idNo = _dao.SaveReportFormat(format)
                MessageBox.Show("Report format saved.")
                RefreshFormats(idNo)
            Catch ex As Exception
                MessageBox.Show("Unable to save the report format." & Environment.NewLine & ex.Message,
                                "Report Formats", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Function SelectedFormat() As MedicalFitnessReportFormat
            Return TryCast(dgvFormats.CurrentRow?.DataBoundItem, MedicalFitnessReportFormat)
        End Function

        Private Sub ItemsClick(sender As Object, e As EventArgs)
            Dim format = SelectedFormat()
            If format Is Nothing Then
                MessageBox.Show("Select a report format first.")
                Return
            End If
            Using itemForm As New MedicalFitnessReportFormatItemForm(format.MRIdNo, format.TitleEnglish)
                itemForm.ShowDialog(Me)
            End Using
        End Sub

        Private Sub AssignmentsClick(sender As Object, e As EventArgs)
            Using assignmentForm As New MedicalFitnessReportFormatAssignmentForm()
                assignmentForm.ShowDialog(Me)
            End Using
        End Sub

    End Class

End Namespace
