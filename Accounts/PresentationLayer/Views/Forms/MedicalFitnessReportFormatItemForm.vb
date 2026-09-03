Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet

Namespace PresentationLayer.Views.Forms

    Public Class MedicalFitnessReportFormatItemForm
        Inherits MedicalFitnessMaintenanceFormBase

        Private ReadOnly _dao As New MedicalFitnessReportDao()
        Private ReadOnly _mrIdNo As Int32
        Private ReadOnly _formatTitle As String
        Private dgvItems As DataGridView
        Private btnSave As Button
        Private btnClinicalItems As Button
        Private btnXRayItems As Button
        Private btnClose As Button
        Private _sortQueued As Boolean

        Public Sub New(mrIdNo As Int32, formatTitle As String)
            _mrIdNo = mrIdNo
            _formatTitle = formatTitle
            Text = "Items - " & If(formatTitle, "Medical Report Format")
            StartPosition = FormStartPosition.CenterParent
            MinimumSize = New Size(1000, 560)
            ClientSize = New Size(1200, 700)
            Font = SystemFonts.MessageBoxFont
            BuildControls()
            AddHandler Load, AddressOf FormLoad
        End Sub

        Private Sub BuildControls()
            btnSave = New Button With {.AutoSize = True, .Text = "Save Items"}
            btnClinicalItems = New Button With {.AutoSize = True, .Text = "Manage Clinical Items"}
            btnXRayItems = New Button With {.AutoSize = True, .Text = "Manage XRay Items"}
            btnClose = New Button With {.AutoSize = True, .Text = "Close", .DialogResult = DialogResult.Cancel}
            AddHandler btnSave.Click, AddressOf SaveClick
            AddHandler btnClinicalItems.Click, AddressOf ClinicalItemsClick
            AddHandler btnXRayItems.Click, AddressOf XRayItemsClick
            AddHandler btnClose.Click, Sub() Close()

            Dim actionPanel = New FlowLayoutPanel With {
                .AutoSize = False, .Dock = DockStyle.Top, .Height = 42,
                .Padding = New Padding(8, 8, 8, 4), .WrapContents = False}
            actionPanel.Controls.Add(btnSave)
            actionPanel.Controls.Add(btnClinicalItems)
            actionPanel.Controls.Add(btnXRayItems)
            actionPanel.Controls.Add(btnClose)

            dgvItems = New DataGridView With {
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False,
                .AutoGenerateColumns = False, .Dock = DockStyle.Fill,
                .RowHeadersVisible = False, .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .EditMode = DataGridViewEditMode.EditOnEnter}
            AddGridColumn("Active", "Active", 60, False, True)
            AddGridColumn("Section", "SectionCode", 80, True)
            AddGridColumn("Test Code", "TestCode", 140, True)
            AddGridColumn("English Name", "TestNameEnglish", 220, True)
            AddGridColumn("Arabic Name", "TestNameArabic", 220, True)
            AddGridColumn("Unit", "Unit", 80, True)
            AddGridColumn("Default Value", "DefaultValue", 160)
            AddGridColumn("Order", "DisplayOrder", 70)
            AddGridColumn("Input Mode", "InputMode", 100)
            AddGridColumn("Required", "IsRequired", 70, False, True)
            AddHandler dgvItems.CellEndEdit, AddressOf ItemCellEndEdit

            MaintenanceContent.Controls.Add(CreateMaintenanceLayout(actionPanel, dgvItems))
            CancelButton = btnClose
        End Sub

        Private Sub AddGridColumn(headerText As String, propertyName As String, width As Int32,
                                  Optional readOnlyColumn As Boolean = False, Optional checkBox As Boolean = False)
            Dim column As DataGridViewColumn = If(checkBox,
                                                  CType(New DataGridViewCheckBoxColumn(), DataGridViewColumn),
                                                  CType(New DataGridViewTextBoxColumn(), DataGridViewColumn))
            column.DataPropertyName = propertyName
            column.HeaderText = headerText
            column.Width = width
            column.ReadOnly = readOnlyColumn
            dgvItems.Columns.Add(column)
        End Sub

        Private Sub FormLoad(sender As Object, e As EventArgs)
            RefreshItems()
        End Sub

        Private Sub RefreshItems()
            Try
                dgvItems.DataSource = _dao.GetReportFormatItems(_mrIdNo)
                SortItemsInGrid()
            Catch ex As Exception
                MessageBox.Show("Unable to load report format items." & Environment.NewLine & ex.Message,
                                "Report Format Items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ItemCellEndEdit(sender As Object, e As DataGridViewCellEventArgs)
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return
            If Not String.Equals(dgvItems.Columns(e.ColumnIndex).DataPropertyName,
                                 "DisplayOrder", StringComparison.OrdinalIgnoreCase) Then
                Return
            End If

            If _sortQueued OrElse dgvItems.IsDisposed OrElse Not dgvItems.IsHandleCreated Then Return
            _sortQueued = True
            dgvItems.BeginInvoke(New MethodInvoker(AddressOf SortItemsAfterEdit))
        End Sub

        Private Sub SortItemsAfterEdit()
            _sortQueued = False
            If dgvItems.IsDisposed Then Return
            SortItemsInGrid()
        End Sub

        Private Sub SortItemsInGrid()
            Dim items = TryCast(dgvItems.DataSource, List(Of MedicalFitnessReportFormatItem))
            If items Is Nothing Then Return

            dgvItems.DataSource = items.
                OrderBy(Function(item) item.DisplayOrder).
                ThenBy(Function(item) item.SectionCode).
                ThenBy(Function(item) item.TestNameEnglish).
                ToList()
        End Sub

        Private Sub SaveClick(sender As Object, e As EventArgs)
            Try
                dgvItems.EndEdit()
                For Each row As DataGridViewRow In dgvItems.Rows
                    Dim item = TryCast(row.DataBoundItem, MedicalFitnessReportFormatItem)
                    If item Is Nothing Then Continue For
                    item.MRIdNo = _mrIdNo
                    If String.IsNullOrWhiteSpace(item.SectionCode) Then item.SectionCode = "CLINICAL"
                    If String.IsNullOrWhiteSpace(item.InputMode) Then item.InputMode = "FIT_UNFIT"
                    _dao.SaveReportFormatItem(item)
                Next
                MessageBox.Show("Report format items saved.")
                RefreshItems()
            Catch ex As Exception
                MessageBox.Show("Unable to save report format items." & Environment.NewLine & ex.Message,
                                "Report Format Items", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ClinicalItemsClick(sender As Object, e As EventArgs)
            Using form As New MedicalFitnessExamTemplateForm("CLINICAL")
                form.ShowDialog(Me)
            End Using
            RefreshItems()
        End Sub

        Private Sub XRayItemsClick(sender As Object, e As EventArgs)
            Using form As New MedicalFitnessExamTemplateForm("XRAY")
                form.ShowDialog(Me)
            End Using
            RefreshItems()
        End Sub

    End Class

End Namespace
