Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet

Namespace PresentationLayer.Views.Forms

    Public Class MedicalFitnessReportFormatAssignmentForm
        Inherits MedicalFitnessMaintenanceFormBase

        Private ReadOnly _dao As New MedicalFitnessReportDao()
        Private _formats As New List(Of MedicalFitnessReportFormat)
        Private _selectedIdNo As Int32
        Private _loading As Boolean

        Private txtCompanyName As TextBox
        Private cboFormat As ComboBox
        Private chkActive As CheckBox
        Private dgvAssignments As DataGridView
        Private btnNew As Button
        Private btnSave As Button
        Private btnToggleActive As Button
        Private btnClose As Button

        Public Sub New()
            Text = "Medical Fitness Report Company Assignments"
            StartPosition = FormStartPosition.CenterParent
            MinimumSize = New Size(700, 450)
            ClientSize = New Size(900, 560)
            Font = SystemFonts.MessageBoxFont
            BuildControls()
            AddHandler Load, AddressOf FormLoad
        End Sub

        Private Sub BuildControls()
            Dim editor = New TableLayoutPanel With {
                .ColumnCount = 4, .Dock = DockStyle.Fill, .Padding = New Padding(8), .RowCount = 1}
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
            editor.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            editor.RowStyles.Add(New RowStyle(SizeType.Absolute, 32.0!))

            txtCompanyName = New TextBox With {.Dock = DockStyle.Fill, .MaxLength = 255}
            cboFormat = New ComboBox With {.Dock = DockStyle.Fill, .DropDownStyle = ComboBoxStyle.DropDownList}
            chkActive = New CheckBox With {.AutoSize = True, .Text = "Active", .Checked = True}
            editor.Controls.Add(New Label With {.AutoSize = True, .Dock = DockStyle.Fill,
                                                .Text = "Company Name", .TextAlign = ContentAlignment.MiddleLeft}, 0, 0)
            editor.Controls.Add(txtCompanyName, 1, 0)
            editor.Controls.Add(New Label With {.AutoSize = True, .Dock = DockStyle.Fill,
                                                .Text = "Report Format", .TextAlign = ContentAlignment.MiddleLeft}, 2, 0)
            editor.Controls.Add(cboFormat, 3, 0)

            btnNew = New Button With {.AutoSize = True, .Text = "New"}
            btnSave = New Button With {.AutoSize = True, .Text = "Save"}
            btnToggleActive = New Button With {.AutoSize = True, .Text = "Deactivate"}
            btnClose = New Button With {.AutoSize = True, .Text = "Close", .DialogResult = DialogResult.Cancel}
            AddHandler btnNew.Click, AddressOf NewClick
            AddHandler btnSave.Click, AddressOf SaveClick
            AddHandler btnToggleActive.Click, AddressOf ToggleActiveClick
            AddHandler btnClose.Click, Sub() Close()

            Dim actionPanel = New FlowLayoutPanel With {
                .AutoSize = False, .Dock = DockStyle.Top, .Height = 42,
                .Padding = New Padding(8, 8, 8, 4), .WrapContents = False}
            actionPanel.Controls.Add(btnNew)
            actionPanel.Controls.Add(btnSave)
            actionPanel.Controls.Add(btnToggleActive)
            actionPanel.Controls.Add(btnClose)

            dgvAssignments = New DataGridView With {
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False,
                .AutoGenerateColumns = False, .Dock = DockStyle.Fill, .MultiSelect = False,
                .ReadOnly = True, .RowHeadersVisible = False,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect}
            AddGridColumn("Company Name", "CompanyName", 350)
            AddGridColumn("Report Format", "FormatTitle", 300)
            AddGridColumn("Active", "Active", 80, True)
            AddHandler dgvAssignments.SelectionChanged, AddressOf AssignmentSelectionChanged

            Dim split = New SplitContainer With {
                .Dock = DockStyle.Fill, .FixedPanel = FixedPanel.Panel1,
                .Orientation = Orientation.Horizontal, .Panel1MinSize = 50,
                .SplitterDistance = 55}
            split.Panel1.Controls.Add(editor)
            split.Panel2.Controls.Add(dgvAssignments)
            MaintenanceContent.Controls.Add(CreateMaintenanceLayout(actionPanel, split))
            AcceptButton = btnSave
            CancelButton = btnClose
        End Sub

        Private Sub AddGridColumn(headerText As String, propertyName As String, width As Int32,
                                  Optional checkBox As Boolean = False)
            Dim column As DataGridViewColumn = If(checkBox,
                                                  CType(New DataGridViewCheckBoxColumn(), DataGridViewColumn),
                                                  CType(New DataGridViewTextBoxColumn(), DataGridViewColumn))
            column.DataPropertyName = propertyName
            column.HeaderText = headerText
            column.Width = width
            dgvAssignments.Columns.Add(column)
        End Sub

        Private Sub FormLoad(sender As Object, e As EventArgs)
            RefreshData()
        End Sub

        Private Sub RefreshData(Optional selectedIdNo As Int32 = 0)
            Try
                _loading = True
                _formats = _dao.GetReportFormats()
                cboFormat.DataSource = Nothing
                cboFormat.DisplayMember = "TitleEnglish"
                cboFormat.ValueMember = "MRIdNo"
                cboFormat.DataSource = _formats
                dgvAssignments.DataSource = _dao.GetReportFormatAssignments()
                dgvAssignments.ClearSelection()
                SelectRow(selectedIdNo)
                If dgvAssignments.CurrentRow Is Nothing Then ClearEditor() Else LoadAssignment(TryCast(dgvAssignments.CurrentRow.DataBoundItem, MedicalFitnessReportFormatAssignment))
            Catch ex As Exception
                MessageBox.Show("Unable to load company assignments." & Environment.NewLine & ex.Message,
                                "Report Format Assignments", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _loading = False
            End Try
        End Sub

        Private Sub SelectRow(idNo As Int32)
            If idNo = 0 Then Return
            For Each row As DataGridViewRow In dgvAssignments.Rows
                Dim assignment = TryCast(row.DataBoundItem, MedicalFitnessReportFormatAssignment)
                If assignment IsNot Nothing AndAlso assignment.IdNo = idNo Then
                    row.Selected = True
                    dgvAssignments.CurrentCell = row.Cells(0)
                    Exit For
                End If
            Next
        End Sub

        Private Sub AssignmentSelectionChanged(sender As Object, e As EventArgs)
            If Not _loading Then LoadAssignment(TryCast(dgvAssignments.CurrentRow?.DataBoundItem, MedicalFitnessReportFormatAssignment))
        End Sub

        Private Sub LoadAssignment(assignment As MedicalFitnessReportFormatAssignment)
            If assignment Is Nothing Then ClearEditor() : Return
            _selectedIdNo = assignment.IdNo
            txtCompanyName.Text = If(assignment.CompanyName, "")
            txtCompanyName.ReadOnly = False
            If _formats.Any(Function(item) item.MRIdNo = assignment.MRIdNo) Then cboFormat.SelectedValue = assignment.MRIdNo
            chkActive.Checked = assignment.Active
            btnToggleActive.Text = If(assignment.Active, "Deactivate", "Activate")
        End Sub

        Private Sub ClearEditor()
            _selectedIdNo = 0
            txtCompanyName.ReadOnly = False
            txtCompanyName.Clear()
            If cboFormat.Items.Count > 0 Then cboFormat.SelectedIndex = 0
            chkActive.Checked = True
            btnToggleActive.Text = "Deactivate"
        End Sub

        Private Sub NewClick(sender As Object, e As EventArgs)
            ClearEditor()
            txtCompanyName.Focus()
        End Sub

        Private Sub SaveClick(sender As Object, e As EventArgs)
            Dim companyName = txtCompanyName.Text.Trim()
            If String.IsNullOrWhiteSpace(companyName) OrElse cboFormat.SelectedIndex < 0 Then
                MessageBox.Show("Company Name and Report Format are required.")
                Return
            End If
            Try
                Dim assignment As New MedicalFitnessReportFormatAssignment With {
                    .IdNo = _selectedIdNo, .CompanyName = companyName,
                    .MRIdNo = Convert.ToInt32(cboFormat.SelectedValue), .Active = chkActive.Checked}
                Dim idNo = _dao.SaveReportFormatAssignment(assignment)
                MessageBox.Show("Company assignment saved.")
                RefreshData(idNo)
            Catch ex As Exception
                MessageBox.Show("Unable to save the company assignment." & Environment.NewLine & ex.Message,
                                "Report Format Assignments", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ToggleActiveClick(sender As Object, e As EventArgs)
            Dim assignment = TryCast(dgvAssignments.CurrentRow?.DataBoundItem, MedicalFitnessReportFormatAssignment)
            If assignment Is Nothing Then
                MessageBox.Show("Select a company assignment first.")
                Return
            End If
            assignment.Active = Not assignment.Active
            Try
                _dao.SaveReportFormatAssignment(assignment)
                RefreshData(assignment.IdNo)
            Catch ex As Exception
                MessageBox.Show("Unable to change the assignment status." & Environment.NewLine & ex.Message,
                                "Report Format Assignments", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class

End Namespace
