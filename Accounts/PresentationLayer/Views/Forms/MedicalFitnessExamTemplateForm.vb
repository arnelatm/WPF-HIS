Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet

Namespace PresentationLayer.Views.Forms

    Public Class MedicalFitnessExamTemplateForm
        Inherits MedicalFitnessMaintenanceFormBase

        Private ReadOnly _dao As New MedicalFitnessReportDao()
        Private ReadOnly _sectionCode As String
        Private ReadOnly _sectionName As String
        Private _selectedIdNo As Int32
        Private _loading As Boolean

        Private txtTestCode As TextBox
        Private txtTestNameEnglish As TextBox
        Private txtTestNameArabic As TextBox
        Private txtUnit As TextBox
        Private txtDefaultValue As TextBox
        Private numDisplayOrder As NumericUpDown
        Private cboInputMode As ComboBox
        Private chkRequired As CheckBox
        Private chkActive As CheckBox
        Private dgvTemplates As DataGridView
        Private btnNew As Button
        Private btnSave As Button
        Private btnToggleActive As Button
        Private btnClose As Button

        Public Sub New(Optional sectionCode As String = "CLINICAL")
            _sectionCode = If(String.Equals(sectionCode, "XRAY", StringComparison.OrdinalIgnoreCase), "XRAY", "CLINICAL")
            _sectionName = If(_sectionCode = "XRAY", "XRay", "Clinical")
            Text = "Medical Fitness " & _sectionName & " Examination Items"
            StartPosition = FormStartPosition.CenterParent
            MinimumSize = New Size(900, 560)
            ClientSize = New Size(1100, 680)
            Font = SystemFonts.MessageBoxFont

            BuildControls()
            AddHandler Load, AddressOf FormLoad
        End Sub

        Private Sub BuildControls()
            Dim editor = New TableLayoutPanel With {
                .ColumnCount = 8,
                .Dock = DockStyle.Fill,
                .Padding = New Padding(8),
                .RowCount = 2}
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            editor.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0!))
            editor.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0!))

            txtTestCode = CreateTextBox(50)
            txtTestNameEnglish = CreateTextBox(255)
            txtTestNameArabic = CreateTextBox(255)
            txtUnit = CreateTextBox(100)
            txtDefaultValue = CreateTextBox(255)

            AddField(editor, "Test Code", txtTestCode, 0, 0)
            AddField(editor, "English Name", txtTestNameEnglish, 2, 0)
            AddField(editor, "Arabic Name", txtTestNameArabic, 4, 0)
            AddField(editor, "Unit", txtUnit, 6, 0)

            numDisplayOrder = New NumericUpDown With {
                .Dock = DockStyle.Fill,
                .Maximum = 2147483647,
                .Minimum = 1,
                .Value = 10}
            cboInputMode = New ComboBox With {
                .Dock = DockStyle.Fill,
                .DropDownStyle = ComboBoxStyle.DropDownList}
            cboInputMode.Items.AddRange(New Object() {"FIT_UNFIT", "TEXT", "NUMBER"})
            cboInputMode.SelectedIndex = 0
            AddField(editor, "Display Order", numDisplayOrder, 0, 1)
            AddField(editor, "Input Mode", cboInputMode, 2, 1)
            AddField(editor, "Default Value", txtDefaultValue, 4, 1)

            chkRequired = New CheckBox With {.AutoSize = True, .Text = "Required"}
            chkActive = New CheckBox With {.AutoSize = True, .Text = "Active", .Checked = True}
            editor.Controls.Add(chkRequired, 6, 1)
            editor.Controls.Add(chkActive, 7, 1)

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
                .ReadOnly = True,
                .RowHeadersVisible = False,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect}
            AddGridColumn("Test Code", "TestCode", 130)
            AddGridColumn("English Name", "TestNameEnglish", 220)
            AddGridColumn("Arabic Name", "TestNameArabic", 220)
            AddGridColumn("Unit", "Unit", 80)
            AddGridColumn("Default Value", "DefaultValue", 180)
            AddGridColumn("Order", "DisplayOrder", 70)
            AddGridColumn("Input Mode", "InputMode", 100)
            AddGridColumn("Required", "IsRequired", 75, True)
            AddGridColumn("Active", "Active", 65, True)
            AddHandler dgvTemplates.SelectionChanged, AddressOf TemplateSelectionChanged

            Dim split = New SplitContainer With {
                .Dock = DockStyle.Fill,
                .FixedPanel = FixedPanel.Panel1,
                .Orientation = Orientation.Horizontal,
                .Panel1MinSize = 90,
                .SplitterDistance = 100}
            split.Panel1.Controls.Add(editor)
            split.Panel2.Controls.Add(dgvTemplates)
            MaintenanceContent.Controls.Add(CreateMaintenanceLayout(actionPanel, split))

            AcceptButton = btnSave
            CancelButton = btnClose
        End Sub

        Private Shared Function CreateTextBox(maxLength As Int32) As TextBox
            Return New TextBox With {
                .Dock = DockStyle.Fill,
                .MaxLength = maxLength}
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
            Dim column As DataGridViewColumn
            If checkBox Then
                column = New DataGridViewCheckBoxColumn()
            Else
                column = New DataGridViewTextBoxColumn()
            End If
            column.DataPropertyName = propertyName
            column.HeaderText = headerText
            column.Width = width
            dgvTemplates.Columns.Add(column)
        End Sub

        Private Sub FormLoad(sender As Object, e As EventArgs)
            RefreshTemplates()
        End Sub

        Private Sub RefreshTemplates(Optional selectedIdNo As Int32 = 0)
            Try
                _loading = True
                dgvTemplates.DataSource = _dao.GetExamTemplates(_sectionCode, True)
                dgvTemplates.ClearSelection()

                If selectedIdNo <> 0 Then
                    For Each row As DataGridViewRow In dgvTemplates.Rows
                        Dim template = TryCast(row.DataBoundItem, MedicalFitnessReportExamTemplate)
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
                    LoadTemplate(TryCast(dgvTemplates.CurrentRow.DataBoundItem, MedicalFitnessReportExamTemplate))
                End If
            Catch ex As Exception
                MessageBox.Show(
                    "Unable to load " & _sectionName & " examination items." & Environment.NewLine & ex.Message,
                    _sectionName & " Examination Items",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            Finally
                _loading = False
            End Try
        End Sub

        Private Sub TemplateSelectionChanged(sender As Object, e As EventArgs)
            If _loading Then
                Return
            End If
            LoadTemplate(TryCast(dgvTemplates.CurrentRow?.DataBoundItem, MedicalFitnessReportExamTemplate))
        End Sub

        Private Sub LoadTemplate(template As MedicalFitnessReportExamTemplate)
            If template Is Nothing Then
                ClearEditor()
                Return
            End If

            _selectedIdNo = template.IdNo
            txtTestCode.Text = If(template.TestCode, "")
            txtTestCode.ReadOnly = True
            txtTestNameEnglish.Text = If(template.TestNameEnglish, "")
            txtTestNameArabic.Text = If(template.TestNameArabic, "")
            txtUnit.Text = If(template.Unit, "")
            txtDefaultValue.Text = If(template.DefaultValue, "")
            numDisplayOrder.Value = Math.Max(numDisplayOrder.Minimum, Math.Min(numDisplayOrder.Maximum, template.DisplayOrder))
            cboInputMode.SelectedItem = If(String.IsNullOrWhiteSpace(template.InputMode), "FIT_UNFIT", template.InputMode)
            If cboInputMode.SelectedIndex < 0 Then
                cboInputMode.SelectedIndex = 0
            End If
            chkRequired.Checked = template.IsRequired
            chkActive.Checked = template.Active
            btnToggleActive.Text = If(template.Active, "Deactivate", "Activate")
        End Sub

        Private Sub ClearEditor()
            _selectedIdNo = 0
            txtTestCode.ReadOnly = False
            txtTestCode.Clear()
            txtTestNameEnglish.Clear()
            txtTestNameArabic.Clear()
            txtUnit.Clear()
            txtDefaultValue.Clear()
            numDisplayOrder.Value = 10
            cboInputMode.SelectedIndex = 0
            chkRequired.Checked = False
            chkActive.Checked = True
            btnToggleActive.Text = "Deactivate"
        End Sub

        Private Sub NewTemplateClick(sender As Object, e As EventArgs)
            ClearEditor()
            txtTestCode.Focus()
        End Sub

        Private Sub SaveTemplateClick(sender As Object, e As EventArgs)
            Dim testCode = txtTestCode.Text.Trim().ToUpperInvariant()
            Dim englishName = txtTestNameEnglish.Text.Trim()
            If String.IsNullOrWhiteSpace(testCode) OrElse String.IsNullOrWhiteSpace(englishName) Then
                MessageBox.Show("Test Code and English Name are required.")
                Return
            End If

            Try
                Dim template As New MedicalFitnessReportExamTemplate With {
                    .IdNo = _selectedIdNo,
                    .SectionCode = _sectionCode,
                    .TestCode = testCode,
                    .TestNameEnglish = englishName,
                    .TestNameArabic = txtTestNameArabic.Text.Trim(),
                    .Unit = txtUnit.Text.Trim(),
                    .DefaultValue = txtDefaultValue.Text.Trim(),
                    .DisplayOrder = CInt(numDisplayOrder.Value),
                    .InputMode = Convert.ToString(cboInputMode.SelectedItem),
                    .IsRequired = chkRequired.Checked,
                    .Active = chkActive.Checked}
                Dim idNo = _dao.SaveClinicalExamTemplate(template)
                MessageBox.Show(_sectionName & " examination item saved.")
                RefreshTemplates(idNo)
            Catch ex As Exception
                MessageBox.Show(
                    "Unable to save the " & _sectionName & " examination item." & Environment.NewLine & ex.Message,
                    _sectionName & " Examination Items",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ToggleActiveClick(sender As Object, e As EventArgs)
            Dim template = TryCast(dgvTemplates.CurrentRow?.DataBoundItem, MedicalFitnessReportExamTemplate)
            If template Is Nothing Then
                MessageBox.Show("Select a clinical examination item first.")
                Return
            End If

            template.Active = Not template.Active
            Try
                _dao.SaveClinicalExamTemplate(template)
                RefreshTemplates(template.IdNo)
            Catch ex As Exception
                MessageBox.Show(
                    "Unable to change the item status." & Environment.NewLine & ex.Message,
                    _sectionName & " Examination Items",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CloseClick(sender As Object, e As EventArgs)
            Close()
        End Sub

    End Class

End Namespace
