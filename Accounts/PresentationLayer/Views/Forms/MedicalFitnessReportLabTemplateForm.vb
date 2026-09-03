Imports System.Drawing
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet

Namespace PresentationLayer.Views.Forms

    Public Class MedicalFitnessReportLabTemplateForm
        Inherits MedicalFitnessMaintenanceFormBase

        Private ReadOnly _dao As New MedicalFitnessReportDao()
        Private _selectedIdNo As Int32
        Private _loading As Boolean
        Private _nextDisplayOrder As Int32 = 200
        Private _kizenLabItems As List(Of MedicalFitnessReportKizenLabItem)

        Private cmbTestCode As ComboBox
        Private txtKizenName As TextBox
        Private txtEnglishOverride As TextBox
        Private txtArabicOverride As TextBox
        Private numDisplayOrder As NumericUpDown
        Private chkCopyResultToEntry As CheckBox
        Private chkActive As CheckBox
        Private dgvTemplates As DataGridView
        Private reportSplit As SplitContainer
        Private btnNew As Button
        Private btnSave As Button
        Private btnToggleActive As Button
        Private btnClose As Button

        Public Sub New()
            Text = "Medical Fitness Laboratory Test Items"
            StartPosition = FormStartPosition.CenterParent
            MinimumSize = New Size(900, 560)
            ClientSize = New Size(1180, 700)
            Font = SystemFonts.MessageBoxFont

            BuildControls()
            AddHandler Load, AddressOf FormLoad
        End Sub

        Private Sub BuildControls()
            Dim editor = New TableLayoutPanel With {
                .ColumnCount = 6,
                .Dock = DockStyle.Fill,
                .Padding = New Padding(8),
                .RowCount = 4}
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 24.0!))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 26.0!))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            For index = 1 To 4
                editor.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0!))
            Next

            cmbTestCode = New ComboBox With {
                .Dock = DockStyle.Fill,
                .AutoCompleteSource = AutoCompleteSource.ListItems,
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                .FormattingEnabled = True,
                .DropDownStyle = ComboBoxStyle.DropDownList}
            AddHandler cmbTestCode.SelectedIndexChanged, AddressOf KizenTestCodeChanged
            txtKizenName = CreateTextBox(255)
            txtKizenName.ReadOnly = True
            txtKizenName.BackColor = SystemColors.Control
            txtEnglishOverride = CreateTextBox(255)
            txtArabicOverride = CreateTextBox(255)

            AddField(editor, "Kizen Test Code", cmbTestCode, 0, 0)

            AddField(editor, "Kizen Name", txtKizenName, 2, 0)
            editor.SetColumnSpan(txtKizenName, 3)
            AddField(editor, "English Override", txtEnglishOverride, 0, 1)
            editor.SetColumnSpan(txtEnglishOverride, 5)
            AddField(editor, "Arabic Override", txtArabicOverride, 0, 2)
            editor.SetColumnSpan(txtArabicOverride, 5)

            numDisplayOrder = New NumericUpDown With {
                .Dock = DockStyle.Fill,
                .Maximum = 2147483647,
                .Minimum = 1,
                .TextAlign = HorizontalAlignment.Left,
                .Margin = New Padding(0, 3, 0, 3),
                .Value = 200}
            AddField(editor, "Display Order", numDisplayOrder, 0, 3)

            chkCopyResultToEntry = New CheckBox With {
                .AutoSize = True,
                .Text = "Copy Kizen result to Entry Result"}
            editor.Controls.Add(chkCopyResultToEntry, 2, 3)
            editor.SetColumnSpan(chkCopyResultToEntry, 2)
            chkActive = New CheckBox With {.AutoSize = True, .Text = "Active", .Checked = True}
            editor.Controls.Add(chkActive, 4, 3)

            btnNew = New Button With {.AutoSize = True, .Text = "New"}
            btnSave = New Button With {.AutoSize = True, .Text = "Save"}
            btnToggleActive = New Button With {.AutoSize = True, .Text = "Deactivate"}
            btnClose = New Button With {.AutoSize = True, .Text = "Close", .DialogResult = DialogResult.Cancel}
            AddHandler btnNew.Click, AddressOf NewTemplateClick
            AddHandler btnSave.Click, AddressOf SaveTemplateClick
            AddHandler btnToggleActive.Click, AddressOf ToggleActiveClick
            AddHandler btnClose.Click, AddressOf CloseClick
            Dim actionPanel = New FlowLayoutPanel With {
                .AutoSize = False,
                .Dock = DockStyle.Top,
                .Height = 42,
                .Padding = New Padding(8, 8, 8, 4),
                .WrapContents = False}
            actionPanel.Controls.Add(btnNew)
            actionPanel.Controls.Add(btnSave)
            actionPanel.Controls.Add(btnToggleActive)
            actionPanel.Controls.Add(btnClose)

            dgvTemplates = New DataGridView With {
                .AllowUserToAddRows = False,
                .AllowUserToDeleteRows = False,
                .AutoGenerateColumns = False,
                .Dock = DockStyle.Fill,
                .MultiSelect = False,
                .ReadOnly = False,
                .RowHeadersVisible = False,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect}
            AddGridColumn("Kizen Code", "TestCode", 130)
            AddGridColumn("Kizen Name", "KizenTestNameEnglish", 220)
            AddGridColumn("English Name", "TestNameEnglish", 220)
            AddGridColumn("Arabic Name", "TestNameArabic", 220)
            AddGridColumn("Copy Result", "CopyResultToEntry", 80, True)
            AddGridColumn("Order", "DisplayOrder", 65)
            AddGridColumn("Active", "Active", 65, True)
            AddHandler dgvTemplates.SelectionChanged, AddressOf TemplateSelectionChanged
            AddHandler dgvTemplates.CurrentCellDirtyStateChanged, AddressOf TemplatesCurrentCellDirtyStateChanged
            AddHandler dgvTemplates.CellValueChanged, AddressOf TemplatesCellValueChanged

            reportSplit = New SplitContainer With {
                .Dock = DockStyle.Fill,
                .FixedPanel = FixedPanel.Panel1,
                .Orientation = Orientation.Horizontal,
                .Panel1MinSize = 170,
                .Panel2MinSize = 80,
                .SplitterDistance = 180}
            reportSplit.Panel1.AutoScroll = True
            reportSplit.Panel1.Controls.Add(editor)
            reportSplit.Panel2.Controls.Add(dgvTemplates)
            MaintenanceContent.Controls.Add(CreateMaintenanceLayout(actionPanel, reportSplit))

            AcceptButton = btnSave
            CancelButton = btnClose
        End Sub

        Private Shared Function CreateTextBox(maxLength As Int32) As TextBox
            Return New TextBox With {.Dock = DockStyle.Fill, .MaxLength = maxLength}
        End Function

        Private Shared Sub AddField(layout As TableLayoutPanel,
                                     labelText As String,
                                     control As Control,
                                     labelColumn As Int32,
                                     row As Int32)
            Dim label = New Label With {
                .AutoSize = True,
                .Dock = DockStyle.Fill,
                .Text = labelText,
                .TextAlign = ContentAlignment.MiddleLeft}
            layout.Controls.Add(label, labelColumn, row)
            layout.Controls.Add(control, labelColumn + 1, row)
        End Sub

        Private Sub AddGridColumn(headerText As String,
                                  propertyName As String,
                                  width As Int32,
                                  Optional checkBox As Boolean = False)
            Dim column As DataGridViewColumn = If(checkBox,
                                                  CType(New DataGridViewCheckBoxColumn(), DataGridViewColumn),
                                                  CType(New DataGridViewTextBoxColumn(), DataGridViewColumn))
            column.DataPropertyName = propertyName
            column.HeaderText = headerText
            column.Width = width
            column.ReadOnly = Not (checkBox AndAlso propertyName = "CopyResultToEntry")
            dgvTemplates.Columns.Add(column)
        End Sub

        Private Sub FormLoad(sender As Object, e As EventArgs)
            If reportSplit.Height >= reportSplit.Panel1MinSize + reportSplit.Panel2MinSize + reportSplit.SplitterWidth Then
                reportSplit.SplitterDistance = 180
            End If
            LoadKizenLabItems()
            RefreshTemplates()
        End Sub

        Private Sub LoadKizenLabItems()
            Try
                _loading = True
                _kizenLabItems = _dao.GetKizenLabItems()
                cmbTestCode.DataSource = Nothing
                cmbTestCode.DisplayMember = "DisplayText"
                cmbTestCode.ValueMember = "Code"
                cmbTestCode.DataSource = _kizenLabItems
            Catch ex As Exception
                _kizenLabItems = New List(Of MedicalFitnessReportKizenLabItem)()
                MessageBox.Show("Unable to load laboratory test codes from Kizen." & Environment.NewLine & ex.Message,
                                "Laboratory Test Items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _loading = False
            End Try
        End Sub

        Private Sub RefreshTemplates(Optional selectedIdNo As Int32 = 0)
            Try
                _loading = True
                Dim templates = _dao.GetLabTemplates(True)
                Dim largestDisplayOrder = templates.Select(Function(template) CLng(template.DisplayOrder)).DefaultIfEmpty(190).Max()
                _nextDisplayOrder = CInt(Math.Min(Integer.MaxValue, Math.Max(200L, largestDisplayOrder + 10L)))
                dgvTemplates.DataSource = templates
                dgvTemplates.ClearSelection()

                If selectedIdNo <> 0 Then
                    For Each row As DataGridViewRow In dgvTemplates.Rows
                        Dim template = TryCast(row.DataBoundItem, MedicalFitnessReportLabTemplate)
                        If template IsNot Nothing AndAlso template.IdNo = selectedIdNo Then
                            row.Selected = True
                            dgvTemplates.CurrentCell = row.Cells(0)
                            Exit For
                        End If
                    Next
                End If

                If dgvTemplates.CurrentRow Is Nothing Then
                    ClearEditor()
                Else
                    LoadTemplate(TryCast(dgvTemplates.CurrentRow.DataBoundItem, MedicalFitnessReportLabTemplate))
                End If
            Catch ex As Exception
                MessageBox.Show("Unable to load laboratory test items." & Environment.NewLine & ex.Message,
                                "Laboratory Test Items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _loading = False
            End Try
        End Sub

        Private Sub TemplateSelectionChanged(sender As Object, e As EventArgs)
            If Not _loading Then
                LoadTemplate(TryCast(dgvTemplates.CurrentRow?.DataBoundItem, MedicalFitnessReportLabTemplate))
            End If
        End Sub

        Private Sub LoadTemplate(template As MedicalFitnessReportLabTemplate)
            If template Is Nothing Then
                ClearEditor()
                Return
            End If

            _selectedIdNo = template.IdNo
            SelectKizenLabItem(template.TestCode)
            txtKizenName.Text = If(template.KizenTestNameEnglish, template.TestNameEnglish)
            txtEnglishOverride.Text = If(template.EnglishNameOverride, "")
            txtArabicOverride.Text = If(template.ArabicNameOverride, "")
            numDisplayOrder.Value = Math.Max(numDisplayOrder.Minimum, Math.Min(numDisplayOrder.Maximum, template.DisplayOrder))
            chkCopyResultToEntry.Checked = template.CopyResultToEntry
            chkActive.Checked = template.Active
            btnToggleActive.Text = If(template.Active, "Deactivate", "Activate")
        End Sub

        Private Sub ClearEditor(Optional preserveSelectedCode As Boolean = False)
            _selectedIdNo = 0
            If Not preserveSelectedCode Then
                cmbTestCode.SelectedIndex = -1
                txtKizenName.Clear()
            End If
            txtEnglishOverride.Clear()
            txtArabicOverride.Clear()
            numDisplayOrder.Value = Math.Min(numDisplayOrder.Maximum, Math.Max(numDisplayOrder.Minimum, _nextDisplayOrder))
            chkCopyResultToEntry.Checked = False
            chkActive.Checked = True
            btnToggleActive.Text = "Deactivate"
        End Sub

        Private Sub NewTemplateClick(sender As Object, e As EventArgs)
            ClearEditor()
            cmbTestCode.Focus()
        End Sub

        Private Sub SelectKizenLabItem(testCode As String)
            If _kizenLabItems Is Nothing Then
                cmbTestCode.SelectedIndex = -1
                Return
            End If

            Dim item = _kizenLabItems.FirstOrDefault(
                Function(candidate) String.Equals(candidate.Code, testCode, StringComparison.OrdinalIgnoreCase) OrElse
                                   String.Equals("Item_" & candidate.Code, testCode, StringComparison.OrdinalIgnoreCase))
            Dim wasLoading = _loading
            _loading = True
            cmbTestCode.SelectedItem = item
            _loading = wasLoading
        End Sub

        Private Sub KizenTestCodeChanged(sender As Object, e As EventArgs)
            If _loading Then
                Return
            End If

            Dim item = TryCast(cmbTestCode.SelectedItem, MedicalFitnessReportKizenLabItem)
            txtKizenName.Text = If(item Is Nothing, "", item.Name)
            _selectedIdNo = 0
            txtEnglishOverride.Clear()
            txtArabicOverride.Clear()
            numDisplayOrder.Value = Math.Min(numDisplayOrder.Maximum, Math.Max(numDisplayOrder.Minimum, _nextDisplayOrder))
            chkCopyResultToEntry.Checked = False
            chkActive.Checked = True
            btnToggleActive.Text = "Deactivate"
        End Sub

        Private Sub TemplatesCurrentCellDirtyStateChanged(sender As Object, e As EventArgs)
            If dgvTemplates.IsCurrentCellDirty AndAlso
               TypeOf dgvTemplates.CurrentCell Is DataGridViewCheckBoxCell Then
                dgvTemplates.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End Sub

        Private Sub TemplatesCellValueChanged(sender As Object, e As DataGridViewCellEventArgs)
            If _loading OrElse e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse
               dgvTemplates.Columns(e.ColumnIndex).DataPropertyName <> "CopyResultToEntry" Then
                Return
            End If

            Dim template = TryCast(dgvTemplates.Rows(e.RowIndex).DataBoundItem, MedicalFitnessReportLabTemplate)
            If template Is Nothing Then
                Return
            End If

            Dim cell = dgvTemplates.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim newValue = If(cell.Value Is Nothing OrElse IsDBNull(cell.Value), False, Convert.ToBoolean(cell.Value))
            Try
                template.CopyResultToEntry = newValue
                _dao.SaveLabTemplate(template)
                If _selectedIdNo = template.IdNo Then
                    chkCopyResultToEntry.Checked = newValue
                End If
            Catch ex As Exception
                _loading = True
                cell.Value = Not newValue
                template.CopyResultToEntry = Not newValue
                _loading = False
                MessageBox.Show("Unable to update the Copy Result setting." & Environment.NewLine & ex.Message,
                                "Laboratory Test Items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SaveTemplateClick(sender As Object, e As EventArgs)
            Dim selectedItem = TryCast(cmbTestCode.SelectedItem, MedicalFitnessReportKizenLabItem)
            Dim code = If(selectedItem Is Nothing, "", selectedItem.Code).Trim().ToUpperInvariant()
            Dim sourceName = txtKizenName.Text.Trim()
            Dim englishOverride = txtEnglishOverride.Text.Trim()
            Dim arabicOverride = txtArabicOverride.Text.Trim()
            If selectedItem Is Nothing OrElse code = "" Then
                MessageBox.Show("Select a laboratory test code from the Kizen list.")
                Return
            End If

            If sourceName = "" AndAlso englishOverride = "" Then
                MessageBox.Show("The selected Kizen laboratory test has no name.")
                Return
            End If

            Try
                Dim template As New MedicalFitnessReportLabTemplate With {
                    .IdNo = _selectedIdNo,
                    .TestCode = code,
                    .TestNameEnglish = If(sourceName = "", englishOverride, sourceName),
                    .TestNameArabic = arabicOverride,
                    .EnglishNameOverride = englishOverride,
                    .ArabicNameOverride = arabicOverride,
                    .DisplayOrder = CInt(numDisplayOrder.Value),
                    .CopyResultToEntry = chkCopyResultToEntry.Checked,
                    .Active = chkActive.Checked}
                Dim idNo = _dao.SaveLabTemplate(template)
                MessageBox.Show("Laboratory test item saved.")
                RefreshTemplates(idNo)
            Catch ex As Exception
                MessageBox.Show("Unable to save the laboratory test item." & Environment.NewLine & ex.Message,
                                "Laboratory Test Items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ToggleActiveClick(sender As Object, e As EventArgs)
            Dim template = TryCast(dgvTemplates.CurrentRow?.DataBoundItem, MedicalFitnessReportLabTemplate)
            If template Is Nothing Then
                MessageBox.Show("Select a laboratory test item first.")
                Return
            End If

            template.Active = Not template.Active
            Try
                template.TestNameEnglish = If(template.KizenTestNameEnglish, template.TestNameEnglish)
                template.TestNameArabic = template.ArabicNameOverride
                _dao.SaveLabTemplate(template)
                RefreshTemplates(template.IdNo)
            Catch ex As Exception
                MessageBox.Show("Unable to change the item status." & Environment.NewLine & ex.Message,
                                "Laboratory Test Items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CloseClick(sender As Object, e As EventArgs)
            Close()
        End Sub

    End Class

End Namespace
