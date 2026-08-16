Imports System.ComponentModel
Imports System.Linq
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Partial Public Class MedicalFitnessReportForm
        Inherits AATM.PresentationLayer.Forms.CFormBase
        Implements IMedicalFitnessReportView

        Protected Overrides ReadOnly Property LanguageLayoutMode As AATM.PresentationLayer.Forms.LanguageLayoutPolicy
            Get
                Return AATM.PresentationLayer.Forms.LanguageLayoutPolicy.Fast
            End Get
        End Property

        Private _reportIdNo As Int32
        Private _invoiceDate As Date?
        Private _testResults As New BindingList(Of MedicalFitnessReportTestResultView)
        Private ReadOnly _bindingSource As New BindingSource()
        Private txtCompanyName As TextBox
        Private txtPassportNo As TextBox
        Private generalExamGroup As GroupBox
        Private txtExamTemperature As TextBox
        Private txtExamBloodPressure As TextBox
        Private txtExamPulse As TextBox
        Private txtExamRespiratorySystem As TextBox
        Private txtExamCardiovascularSystem As TextBox
        Private txtExamNervousSystem As TextBox
        Private txtExamAbdomen As TextBox
        Private txtExamWeight As TextBox
        Private txtExamHeight As TextBox
        Private txtExamExtremities As TextBox
        Private txtExamChestXRay As TextBox
        Private txtExamRightEye As TextBox
        Private txtExamLeftEye As TextBox
        Private txtExamRightEar As TextBox
        Private txtExamLeftEar As TextBox

        Public Event RetrieveRequested() Implements IMedicalFitnessReportView.RetrieveRequested
        Public Event RefreshLabResultsRequested() Implements IMedicalFitnessReportView.RefreshLabResultsRequested
        Public Event ViewKizenResultsRequested() Implements IMedicalFitnessReportView.ViewKizenResultsRequested
        Public Event SaveRequested() Implements IMedicalFitnessReportView.SaveRequested
        Public Event DeleteRequested() Implements IMedicalFitnessReportView.DeleteRequested

        Public Sub New()
            InitializeComponent()
            SingleData = True
            QueryOnly = False
            ConfigureAdditionalPatientFields()
            ConfigureGeneralExamPanel()
            ConfigureGridColumns()
            BindGrid()
            ConfigureParentActionButtons()
        End Sub

        Protected Overrides Sub OnShown(e As EventArgs)
            MyBase.OnShown(e)
            ConfigureParentActionButtons()
        End Sub

        Private Sub ConfigureParentActionButtons()
            btnSave.Visible = True
            btnSave.Enabled = True
            btnSave.ToolTipText = "Save medical fitness report"
            btnPrint.Visible = True
            btnPrint.Enabled = True
            btnPrint.ToolTipText = "Print medical fitness report"
            btnDelete.Visible = True
            btnDelete.Enabled = True
            btnDelete.ToolTipText = "Delete medical fitness report"
        End Sub

        Private Sub ConfigureAdditionalPatientFields()
            headerPanel.RowCount = 4
            headerPanel.RowStyles.Add(New RowStyle(SizeType.AutoSize))

            Dim companyLabel As New Label With {
                .AutoSize = True,
                .Margin = New Padding(3, 6, 3, 3),
                .Text = "Company Name"}
            txtCompanyName = New TextBox With {
                .Dock = DockStyle.Fill,
                .ReadOnly = True}

            Dim passportLabel As New Label With {
                .AutoSize = True,
                .Margin = New Padding(3, 6, 3, 3),
                .Text = "Passport No."}
            txtPassportNo = New TextBox With {
                .BackColor = Color.LightYellow,
                .Dock = DockStyle.Fill,
                .MaxLength = 100}

            headerPanel.Controls.Add(companyLabel, 0, 3)
            headerPanel.Controls.Add(txtCompanyName, 1, 3)
            headerPanel.SetColumnSpan(txtCompanyName, 3)
            headerPanel.Controls.Add(passportLabel, 4, 3)
            headerPanel.Controls.Add(txtPassportNo, 5, 3)
        End Sub

        Private Sub ConfigureGeneralExamPanel()
            generalExamGroup = New GroupBox With {
                .Dock = DockStyle.Fill,
                .Height = 220,
                .Padding = New Padding(6),
                .Text = "General Medical Examination / الفحص الطبي العام"}

            Dim examLayout As New TableLayoutPanel With {
                .ColumnCount = 6,
                .Dock = DockStyle.Fill,
                .RowCount = 6}
            For columnIndex = 0 To 5
                examLayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 16.6667!))
            Next
            For rowIndex = 0 To 5
                examLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 16.6667!))
            Next

            txtExamTemperature = AddExamEntry(examLayout, "Temp (°C) / درجة الحرارة", 0, 0)
            txtExamBloodPressure = AddExamEntry(examLayout, "B.P / ضغط الدم", 2, 0)
            txtExamPulse = AddExamEntry(examLayout, "Pulse / النبض", 4, 0)
            txtExamRespiratorySystem = AddExamEntry(examLayout, "Resp. System / الجهاز التنفسي", 0, 1)
            txtExamCardiovascularSystem = AddExamEntry(examLayout, "CVS / فحص القلب", 2, 1)
            txtExamAbdomen = AddExamEntry(examLayout, "Abdomen / فحص الباطني", 4, 1)
            txtExamNervousSystem = AddExamEntry(examLayout, "Nervous System / الجهاز العصبي", 0, 2)
            txtExamExtremities = AddExamEntry(examLayout, "Extremities / فحص الأطراف", 2, 2)
            txtExamChestXRay = AddExamEntry(examLayout, "Chest X-ray / الأشعة الصدرية", 4, 2)
            txtExamWeight = AddExamEntry(examLayout, "Weight (kg) / الوزن", 0, 3)
            txtExamHeight = AddExamEntry(examLayout, "Height (cm) / الطول", 2, 3)
            txtExamRightEye = AddExamEntry(examLayout, "Right Eye / العين اليمنى", 0, 4)
            txtExamLeftEye = AddExamEntry(examLayout, "Left Eye / العين اليسرى", 2, 4)
            txtExamRightEar = AddExamEntry(examLayout, "Right Ear / الأذن اليمنى", 0, 5)
            txtExamLeftEar = AddExamEntry(examLayout, "Left Ear / الأذن اليسرى", 2, 5)

            generalExamGroup.Controls.Add(examLayout)
            mainPanel.RowCount = 5
            mainPanel.RowStyles.Clear()
            mainPanel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            mainPanel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            mainPanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 220.0!))
            mainPanel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            mainPanel.RowStyles.Add(New RowStyle(SizeType.AutoSize))
            mainPanel.Controls.Add(generalExamGroup, 0, 2)
            mainPanel.SetRow(dgvResults, 3)
            mainPanel.SetRow(finalPanel, 4)
        End Sub

        Private Shared Function AddExamEntry(layout As TableLayoutPanel,
                                             labelText As String,
                                             columnIndex As Int32,
                                             rowIndex As Int32) As TextBox
            Dim label = CreateExamLabel(labelText)
            Dim textBox = CreateExamTextBox()
            layout.Controls.Add(label, columnIndex, rowIndex)
            layout.Controls.Add(textBox, columnIndex + 1, rowIndex)
            Return textBox
        End Function

        Private Shared Function CreateExamLabel(text As String) As Label
            Return New Label With {
                .AutoEllipsis = True,
                .Dock = DockStyle.Fill,
                .Margin = New Padding(3, 6, 3, 3),
                .Text = text,
                .TextAlign = ContentAlignment.MiddleLeft}
        End Function

        Private Shared Function CreateExamTextBox() As TextBox
            Return New TextBox With {
                .BackColor = Color.LightYellow,
                .Dock = DockStyle.Fill,
                .MaxLength = 255,
                .Margin = New Padding(3, 5, 3, 3)}
        End Function

        Public Property ReportIdNo As Integer Implements IMedicalFitnessReportView.ReportIdNo
            Get
                Return _reportIdNo
            End Get
            Set(value As Integer)
                _reportIdNo = value
            End Set
        End Property

        Public Property InvoiceNo As Integer Implements IMedicalFitnessReportView.InvoiceNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtInvoiceNo.Text)
            End Get
            Set(value As Integer)
                txtInvoiceNo.Text = If(value = 0, "", value.ToString())
            End Set
        End Property

        Public Property InvoiceDate As Date? Implements IMedicalFitnessReportView.InvoiceDate
            Get
                Return _invoiceDate
            End Get
            Set(value As Date?)
                _invoiceDate = value
                txtInvoiceDate.Text = If(value.HasValue, value.Value.ToString("dd/MM/yyyy"), "")
            End Set
        End Property

        Public Property FileNo As Integer? Implements IMedicalFitnessReportView.FileNo
            Get
                If txtFileNo.Text = "" Then
                    Return Nothing
                End If
                Return GlobalFunctions.NumParser(Of Int32)(txtFileNo.Text)
            End Get
            Set(value As Integer?)
                txtFileNo.Text = If(value.HasValue, value.Value.ToString(), "")
            End Set
        End Property

        Public Property PatientName As String Implements IMedicalFitnessReportView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set(value As String)
                txtPatientName.Text = value
            End Set
        End Property

        Public Property Gender As String Implements IMedicalFitnessReportView.Gender
            Get
                Return txtGender.Text
            End Get
            Set(value As String)
                txtGender.Text = value
            End Set
        End Property

        Public Property Age As String Implements IMedicalFitnessReportView.Age
            Get
                Return txtAge.Text
            End Get
            Set(value As String)
                txtAge.Text = value
            End Set
        End Property

        Public Property Nationality As String Implements IMedicalFitnessReportView.Nationality
            Get
                Return txtNationality.Text
            End Get
            Set(value As String)
                txtNationality.Text = value
            End Set
        End Property

        Public Property IdentityNo As String Implements IMedicalFitnessReportView.IdentityNo
            Get
                Return txtIdentityNo.Text
            End Get
            Set(value As String)
                txtIdentityNo.Text = value
            End Set
        End Property

        Public Property DoctorName As String Implements IMedicalFitnessReportView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set(value As String)
                txtDoctorName.Text = value
            End Set
        End Property

        Public Property BloodType As String Implements IMedicalFitnessReportView.BloodType
            Get
                Return Convert.ToString(cboBloodType.SelectedItem)
            End Get
            Set(value As String)
                cboBloodType.SelectedItem = value
                If value IsNot Nothing AndAlso value <> "" AndAlso cboBloodType.SelectedIndex = -1 Then
                    cboBloodType.Text = value
                End If
            End Set
        End Property

        Public Shadows Property CompanyName As String Implements IMedicalFitnessReportView.CompanyName
            Get
                Return txtCompanyName.Text.Trim()
            End Get
            Set(value As String)
                txtCompanyName.Text = If(value, "")
            End Set
        End Property

        Public Property PassportNo As String Implements IMedicalFitnessReportView.PassportNo
            Get
                Return txtPassportNo.Text.Trim()
            End Get
            Set(value As String)
                txtPassportNo.Text = If(value, "")
            End Set
        End Property

        Public Property ExamTemperature As String Implements IMedicalFitnessReportView.ExamTemperature
            Get
                Return txtExamTemperature.Text.Trim()
            End Get
            Set(value As String)
                txtExamTemperature.Text = If(value, "")
            End Set
        End Property

        Public Property ExamBloodPressure As String Implements IMedicalFitnessReportView.ExamBloodPressure
            Get
                Return txtExamBloodPressure.Text.Trim()
            End Get
            Set(value As String)
                txtExamBloodPressure.Text = If(value, "")
            End Set
        End Property

        Public Property ExamPulse As String Implements IMedicalFitnessReportView.ExamPulse
            Get
                Return txtExamPulse.Text.Trim()
            End Get
            Set(value As String)
                txtExamPulse.Text = If(value, "")
            End Set
        End Property

        Public Property ExamRespiratorySystem As String Implements IMedicalFitnessReportView.ExamRespiratorySystem
            Get
                Return txtExamRespiratorySystem.Text.Trim()
            End Get
            Set(value As String)
                txtExamRespiratorySystem.Text = If(value, "")
            End Set
        End Property

        Public Property ExamCardiovascularSystem As String Implements IMedicalFitnessReportView.ExamCardiovascularSystem
            Get
                Return txtExamCardiovascularSystem.Text.Trim()
            End Get
            Set(value As String)
                txtExamCardiovascularSystem.Text = If(value, "")
            End Set
        End Property

        Public Property ExamNervousSystem As String Implements IMedicalFitnessReportView.ExamNervousSystem
            Get
                Return txtExamNervousSystem.Text.Trim()
            End Get
            Set(value As String)
                txtExamNervousSystem.Text = If(value, "")
            End Set
        End Property

        Public Property ExamAbdomen As String Implements IMedicalFitnessReportView.ExamAbdomen
            Get
                Return txtExamAbdomen.Text.Trim()
            End Get
            Set(value As String)
                txtExamAbdomen.Text = If(value, "")
            End Set
        End Property

        Public Property ExamWeight As String Implements IMedicalFitnessReportView.ExamWeight
            Get
                Return txtExamWeight.Text.Trim()
            End Get
            Set(value As String)
                txtExamWeight.Text = If(value, "")
            End Set
        End Property

        Public Property ExamHeight As String Implements IMedicalFitnessReportView.ExamHeight
            Get
                Return txtExamHeight.Text.Trim()
            End Get
            Set(value As String)
                txtExamHeight.Text = If(value, "")
            End Set
        End Property

        Public Property ExamExtremities As String Implements IMedicalFitnessReportView.ExamExtremities
            Get
                Return txtExamExtremities.Text.Trim()
            End Get
            Set(value As String)
                txtExamExtremities.Text = If(value, "")
            End Set
        End Property

        Public Property ExamChestXRay As String Implements IMedicalFitnessReportView.ExamChestXRay
            Get
                Return txtExamChestXRay.Text.Trim()
            End Get
            Set(value As String)
                txtExamChestXRay.Text = If(value, "")
            End Set
        End Property

        Public Property ExamRightEye As String Implements IMedicalFitnessReportView.ExamRightEye
            Get
                Return txtExamRightEye.Text.Trim()
            End Get
            Set(value As String)
                txtExamRightEye.Text = If(value, "")
            End Set
        End Property

        Public Property ExamLeftEye As String Implements IMedicalFitnessReportView.ExamLeftEye
            Get
                Return txtExamLeftEye.Text.Trim()
            End Get
            Set(value As String)
                txtExamLeftEye.Text = If(value, "")
            End Set
        End Property

        Public Property ExamRightEar As String Implements IMedicalFitnessReportView.ExamRightEar
            Get
                Return txtExamRightEar.Text.Trim()
            End Get
            Set(value As String)
                txtExamRightEar.Text = If(value, "")
            End Set
        End Property

        Public Property ExamLeftEar As String Implements IMedicalFitnessReportView.ExamLeftEar
            Get
                Return txtExamLeftEar.Text.Trim()
            End Get
            Set(value As String)
                txtExamLeftEar.Text = If(value, "")
            End Set
        End Property

        Public Property FinalResultStatus As String Implements IMedicalFitnessReportView.FinalResultStatus
            Get
                If chkFinalFit.Checked Then
                    Return "F"
                End If
                If chkFinalUnfit.Checked Then
                    Return "U"
                End If
                Return Nothing
            End Get
            Set(value As String)
                chkFinalFit.Checked = value = "F"
                chkFinalUnfit.Checked = value = "U"
            End Set
        End Property

        Public Property Remarks As String Implements IMedicalFitnessReportView.Remarks
            Get
                Return txtRemarks.Text
            End Get
            Set(value As String)
                txtRemarks.Text = value
            End Set
        End Property

        Public Property TestResults As BindingList(Of MedicalFitnessReportTestResultView) Implements IMedicalFitnessReportView.TestResults
            Get
                Return _testResults
            End Get
            Set(value As BindingList(Of MedicalFitnessReportTestResultView))
                Dim rows = If(value, New BindingList(Of MedicalFitnessReportTestResultView)())
                _testResults = New BindingList(Of MedicalFitnessReportTestResultView)(
                    rows.OrderBy(Function(row) row.Sequence).
                         ThenBy(Function(row) row.IdNo).
                         ToList())
                BindGrid()
            End Set
        End Property

        Public ReadOnly Property SelectedTestResult As MedicalFitnessReportTestResultView Implements IMedicalFitnessReportView.SelectedTestResult
            Get
                If dgvResults Is Nothing OrElse dgvResults.CurrentRow Is Nothing Then
                    Return Nothing
                End If

                Return TryCast(dgvResults.CurrentRow.DataBoundItem, MedicalFitnessReportTestResultView)
            End Get
        End Property

        Public Sub ShowKizenGroupedResults(testName As String,
                                           results As BindingList(Of MedicalFitnessGroupedLabResultView)) Implements IMedicalFitnessReportView.ShowKizenGroupedResults
            Using resultForm As New KizenGroupedLabResultsForm(InvoiceNo, testName, results)
                resultForm.ShowDialog(Me)
            End Using
        End Sub

        Private Sub BindGrid()
            If _bindingSource Is Nothing OrElse dgvResults Is Nothing Then
                Return
            End If
            _bindingSource.DataSource = _testResults
            dgvResults.DataSource = _bindingSource
            ApplyResultEntryModes()
            UpdateViewKizenResultsButton()
        End Sub

        Private Sub ApplyResultEntryModes()
            If dgvResults Is Nothing OrElse dgvResults.Columns.Count = 0 Then
                Return
            End If

            For Each gridRow As DataGridViewRow In dgvResults.Rows
                Dim result = TryCast(gridRow.DataBoundItem, MedicalFitnessReportTestResultView)
                If result Is Nothing Then
                    Continue For
                End If

                SetEntryCellEnabled(gridRow.Cells(colResultText.Index), True)
                SetEntryCellEnabled(gridRow.Cells(colFit.Index), True)
                SetEntryCellEnabled(gridRow.Cells(colUnfit.Index), True)
            Next
        End Sub

        Private Shared Sub SetEntryCellEnabled(cell As DataGridViewCell, enabled As Boolean)
            cell.ReadOnly = Not enabled
            cell.Style.BackColor = If(enabled, SystemColors.Window, SystemColors.Control)
            cell.Style.ForeColor = If(enabled, SystemColors.WindowText, SystemColors.GrayText)
            cell.Style.SelectionBackColor = If(enabled, SystemColors.Highlight, SystemColors.ControlDark)
            cell.Style.SelectionForeColor = If(enabled, SystemColors.HighlightText, SystemColors.GrayText)
        End Sub

        Private Sub ConfigureGridColumns()
            If dgvResults Is Nothing OrElse dgvResults.Columns.Count > 0 Then
                Return
            End If

            dgvResults.AutoGenerateColumns = False

            colSequence = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "Sequence",
                .HeaderText = "Sequence",
                .Name = "colSequence",
                .FillWeight = 55}
            colSection = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "SectionDisplay",
                .HeaderText = "Section",
                .Name = "colSection",
                .ReadOnly = True,
                .FillWeight = 75}
            colTest = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "TestNameEnglish",
                .HeaderText = "Test",
                .Name = "colTest",
                .ReadOnly = True,
                .FillWeight = 140}
            colLabResult = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "LabResult",
                .HeaderText = "Kizen Result",
                .Name = "colLabResult",
                .ReadOnly = True,
                .FillWeight = 75}
            colLabReferenceValue = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "LabReferenceValue",
                .HeaderText = "Reference Value",
                .Name = "colLabReferenceValue",
                .ReadOnly = True,
                .FillWeight = 110}
            colLabUnit = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "LabUnit",
                .HeaderText = "Unit",
                .Name = "colLabUnit",
                .ReadOnly = True,
                .FillWeight = 50}
            colLabAssessment = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "LabAssessment",
                .HeaderText = "Assessment",
                .Name = "colLabAssessment",
                .ReadOnly = True,
                .FillWeight = 80}
            colResultStatusSource = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "ResultStatusSourceDisplay",
                .HeaderText = "Status Source",
                .Name = "colResultStatusSource",
                .ReadOnly = True,
                .FillWeight = 70}
            colResultText = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "ResultText",
                .HeaderText = "Entry Result",
                .Name = "colResultText",
                .FillWeight = 75}
            colFit = New DataGridViewCheckBoxColumn With {
                .DataPropertyName = "IsFit",
                .HeaderText = "Fit",
                .Name = "colFit",
                .FillWeight = 45,
                .ThreeState = False}
            colUnfit = New DataGridViewCheckBoxColumn With {
                .DataPropertyName = "IsUnfit",
                .HeaderText = "Unfit",
                .Name = "colUnfit",
                .FillWeight = 50,
                .ThreeState = False}
            colRemarks = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "Remarks",
                .HeaderText = "Remarks",
                .Name = "colRemarks",
                .FillWeight = 140}

            dgvResults.Columns.AddRange(New DataGridViewColumn() {
                colSequence,
                colSection,
                colTest,
                colLabResult,
                colLabReferenceValue,
                colLabUnit,
                colLabAssessment,
                colResultStatusSource,
                colResultText,
                colFit,
                colUnfit,
                colRemarks})
        End Sub

        Private Sub btnRetrieve_Click(sender As Object, e As EventArgs) Handles btnRetrieve.Click
            RaiseEvent RetrieveRequested()
        End Sub

        Private Sub btnRefreshLabResults_Click(sender As Object, e As EventArgs) Handles btnRefreshLabResults.Click
            dgvResults.EndEdit()
            _bindingSource.EndEdit()
            RaiseEvent RefreshLabResultsRequested()
        End Sub

        Private Sub btnViewKizenResults_Click(sender As Object, e As EventArgs) Handles btnViewKizenResults.Click
            RaiseEvent ViewKizenResultsRequested()
        End Sub

        Protected Overrides Function HandleSaveButtonClick() As Boolean
            dgvResults.EndEdit()
            _bindingSource.EndEdit()
            RaiseEvent SaveRequested()
            Return True
        End Function

        Protected Overrides Function HandleDeleteButtonClick() As Boolean
            RaiseEvent DeleteRequested()
            Return True
        End Function

        Protected Overrides Function HandlePrintButtonClick() As Boolean
            If InvoiceNo = 0 Then
                MessageBox.Show("Please retrieve an invoice before printing.")
                Return True
            End If

            If ReportIdNo = 0 Then
                MessageBox.Show("Please save the medical report before printing.")
                Return True
            End If

            If Not ValidateRequiredEntries("printing") Then
                Return True
            End If

            Dim medicalReportForm = ReportForm.CreateSorted(
                "Medical Fitness Report.Rpt",
                "MedicalFitnessReportPrint_View",
                "Sequence",
                InvoiceNo,
                "InvoiceNo")
            medicalReportForm.Show()
            Return True
        End Function

        Public Function ValidateRequiredEntries(actionName As String) As Boolean Implements IMedicalFitnessReportView.ValidateRequiredEntries
            Dim missing = GetMissingRequiredEntries()
            If missing.Count = 0 Then
                Return True
            End If

            MessageBox.Show(
                "Complete the following required entries before " & actionName & ":" &
                Environment.NewLine & String.Join(", ", missing),
                "Required Medical Fitness Entries",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return False
        End Function

        Private Function GetMissingRequiredEntries() As List(Of String)
            Dim missing As New List(Of String)
            AddMissingExamination(missing, "Temperature", ExamTemperature)
            AddMissingExamination(missing, "Blood Pressure", ExamBloodPressure)
            AddMissingExamination(missing, "Pulse", ExamPulse)
            AddMissingExamination(missing, "Final Result", FinalResultStatus)
            Return missing
        End Function

        Private Shared Sub AddMissingExamination(missing As List(Of String), displayName As String, value As String)
            If String.IsNullOrWhiteSpace(value) Then
                missing.Add(displayName)
            End If
        End Sub

        Private Sub txtInvoiceNo_Validated(sender As Object, e As EventArgs) Handles txtInvoiceNo.Validated
            If InvoiceNo <> 0 Then
                RaiseEvent RetrieveRequested()
            End If
        End Sub

        Private Sub dgvResults_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvResults.CurrentCellDirtyStateChanged
            If dgvResults.IsCurrentCellDirty AndAlso
               dgvResults.CurrentCell IsNot Nothing AndAlso
               TypeOf dgvResults.CurrentCell.OwningColumn Is DataGridViewCheckBoxColumn Then
                dgvResults.CommitEdit(DataGridViewDataErrorContexts.Commit)
            End If
        End Sub

        Private Sub dgvResults_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResults.CellValueChanged
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
                Return
            End If

            Dim row = TryCast(dgvResults.Rows(e.RowIndex).DataBoundItem, MedicalFitnessReportTestResultView)
            If row Is Nothing Then
                Return
            End If

            Dim columnName = dgvResults.Columns(e.ColumnIndex).DataPropertyName
            If columnName = "IsFit" AndAlso row.IsFit Then
                row.IsUnfit = False
            ElseIf columnName = "IsUnfit" AndAlso row.IsUnfit Then
                row.IsFit = False
            End If
            dgvResults.Rows(e.RowIndex).Cells(colResultStatusSource.Index).Value = row.ResultStatusSourceDisplay
            dgvResults.InvalidateRow(e.RowIndex)
        End Sub

        Private Sub dgvResults_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvResults.DataBindingComplete
            ApplyResultEntryModes()
            UpdateViewKizenResultsButton()
        End Sub

        Private Sub dgvResults_SelectionChanged(sender As Object, e As EventArgs) Handles dgvResults.SelectionChanged
            UpdateViewKizenResultsButton()
        End Sub

        Private Sub dgvResults_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResults.CellDoubleClick
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
                Return
            End If

            Dim selectedRow = TryCast(dgvResults.Rows(e.RowIndex).DataBoundItem, MedicalFitnessReportTestResultView)
            If Not CanViewKizenResults(selectedRow) Then
                Return
            End If

            dgvResults.CurrentCell = dgvResults.Rows(e.RowIndex).Cells(e.ColumnIndex)
            RaiseEvent ViewKizenResultsRequested()
        End Sub

        Private Sub UpdateViewKizenResultsButton()
            If btnViewKizenResults Is Nothing Then
                Return
            End If

            btnViewKizenResults.Enabled = CanViewKizenResults(SelectedTestResult)
        End Sub

        Private Function CanViewKizenResults(selectedRow As MedicalFitnessReportTestResultView) As Boolean
            Return InvoiceNo <> 0 AndAlso
                selectedRow IsNot Nothing AndAlso
                String.Equals(selectedRow.SectionCode, "LAB", StringComparison.OrdinalIgnoreCase) AndAlso
                Not String.IsNullOrWhiteSpace(selectedRow.TestCode)
        End Function

        Private Sub chkFinalFit_CheckedChanged(sender As Object, e As EventArgs) Handles chkFinalFit.CheckedChanged
            If chkFinalFit.Checked Then
                chkFinalUnfit.Checked = False
            End If
        End Sub

        Private Sub chkFinalUnfit_CheckedChanged(sender As Object, e As EventArgs) Handles chkFinalUnfit.CheckedChanged
            If chkFinalUnfit.Checked Then
                chkFinalFit.Checked = False
            End If
        End Sub

    End Class

End Namespace
