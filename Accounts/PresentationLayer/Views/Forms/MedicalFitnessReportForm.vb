Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Linq
Imports System.Drawing
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views
Imports System.Windows.Forms
Imports AATM.Accounts.DataLayer.AdoNet
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
        Private ReadOnly _dao As New MedicalFitnessReportDao()
        Private ReadOnly _bindingSource As New BindingSource()
        Private _reportFormats As New List(Of MedicalFitnessReportFormat)
        Private _loadingReportFormats As Boolean
        Private txtCompanyName As TextBox
        Private txtPassportNo As TextBox
        Private btnManageLabItems As Button
        Private lblReportFormat As Label
        Private cboReportFormat As ComboBox
        Private lblPaperType As Label
        Private cboPaperType As ComboBox
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
        Private txtPatientSearch As TextBox
        Private btnSearchPatient As Button

        Public Event RetrieveRequested() Implements IMedicalFitnessReportView.RetrieveRequested
        Public Event PatientSearchRequested(searchValue As String) Implements IMedicalFitnessReportView.PatientSearchRequested
        Public Event RefreshLabResultsRequested() Implements IMedicalFitnessReportView.RefreshLabResultsRequested
        Public Event ReportFormatChangedRequested() Implements IMedicalFitnessReportView.ReportFormatChangedRequested
        Public Event ViewKizenResultsRequested() Implements IMedicalFitnessReportView.ViewKizenResultsRequested
        Public Event SaveRequested() Implements IMedicalFitnessReportView.SaveRequested
        Public Event DeleteRequested() Implements IMedicalFitnessReportView.DeleteRequested

        Public Sub New()
            InitializeComponent()
            SingleData = True
            QueryOnly = False
            ConfigureAdditionalPatientFields()
            ConfigureLegacyExamFields()
            ConfigureGridColumns()
            ConfigureReportFormatSelector()
            ConfigureLabItemsManager()
            ConfigurePatientSearch()
            LoadReportFormats()
            BindGrid()
            ConfigureParentActionButtons()
        End Sub

        Private Sub ConfigureReportFormatSelector()
            lblReportFormat = New Label With {
                .AutoSize = True,
                .Margin = New Padding(8, 7, 3, 3),
                .Text = "Report Format"}
            cboReportFormat = New ComboBox With {
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Margin = New Padding(0, 3, 0, 3),
                .Width = 155}
            AddHandler cboReportFormat.SelectionChangeCommitted, AddressOf ReportFormatSelectionChanged
            invoicePanel.Controls.Add(lblReportFormat)
            invoicePanel.Controls.Add(cboReportFormat)

            lblPaperType = New Label With {
                .AutoSize = True,
                .Margin = New Padding(8, 7, 3, 3),
                .Text = "Print On"}
            cboPaperType = New ComboBox With {
                .DropDownStyle = ComboBoxStyle.DropDownList,
                .Margin = New Padding(0, 3, 0, 3),
                .Width = 110}
            cboPaperType.Items.AddRange(New Object() {"Plain Paper", "Letterhead"})
            cboPaperType.SelectedIndex = 0
            invoicePanel.Controls.Add(lblPaperType)
            invoicePanel.Controls.Add(cboPaperType)
        End Sub

        Private ReadOnly Property SuppressLogoForPrint As Boolean
            Get
                Return cboPaperType IsNot Nothing AndAlso cboPaperType.SelectedIndex = 1
            End Get
        End Property

        Private Sub ConfigureLabItemsManager()
            btnManageLabItems = New Button With {
                .AutoSize = True,
                .Margin = New Padding(3, 3, 0, 3),
                .Text = "Manage Lab Items",
                .UseVisualStyleBackColor = True}
            AddHandler btnManageLabItems.Click, AddressOf ManageLabItemsButtonClicked
            invoicePanel.Controls.Add(btnManageLabItems)
        End Sub

        Private Sub ManageLabItemsButtonClicked(sender As Object, e As EventArgs)
            Using form As New MedicalFitnessReportLabTemplateForm()
                form.ShowDialog(Me)
            End Using
            If InvoiceNo <> 0 Then
                RaiseEvent RefreshLabResultsRequested()
            End If
        End Sub

        Private Sub LoadReportFormats(Optional selectedIdNo As Int32 = 0)
            Try
                _loadingReportFormats = True
                _reportFormats = _dao.GetReportFormats()
                cboReportFormat.DataSource = Nothing
                cboReportFormat.DisplayMember = "TitleEnglish"
                cboReportFormat.ValueMember = "MRIdNo"
                cboReportFormat.DataSource = _reportFormats

                Dim selected = selectedIdNo
                If selected = 0 Then
                    Dim defaultFormat = _reportFormats.FirstOrDefault(Function(item) item.IsDefault)
                    selected = If(defaultFormat Is Nothing, 0, defaultFormat.MRIdNo)
                End If
                If selected <> 0 AndAlso Not _reportFormats.Any(Function(item) item.MRIdNo = selected) Then
                    Dim savedFormat = _dao.GetReportFormat(selected)
                    If savedFormat IsNot Nothing Then
                        _reportFormats.Add(savedFormat)
                        cboReportFormat.DataSource = Nothing
                        cboReportFormat.DataSource = _reportFormats
                    End If
                End If
                If selected <> 0 Then
                    cboReportFormat.SelectedValue = selected
                End If
            Catch ex As Exception
                MessageBox.Show("Unable to load medical report formats." & Environment.NewLine & ex.Message,
                                "Medical Report Formats", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _loadingReportFormats = False
            End Try
        End Sub

        Private Sub ReportFormatSelectionChanged(sender As Object, e As EventArgs)
            If Not _loadingReportFormats Then
                RaiseEvent ReportFormatChangedRequested()
            End If
        End Sub

        Private Sub ConfigurePatientSearch()
            ' Keep the search controls visible when the invoice toolbar also
            ' contains the report-format and laboratory buttons.
            invoicePanel.WrapContents = True

            Dim searchLabel As New Label With {
                .AutoSize = True,
                .Margin = New Padding(10, 7, 3, 3),
                .Text = "Patient ID / File No."}
            txtPatientSearch = New TextBox With {
                .Margin = New Padding(0, 3, 3, 3),
                .Width = 135}
            btnSearchPatient = New Button With {
                .AutoSize = True,
                .Margin = New Padding(0, 3, 0, 3),
                .Text = "Search Patient",
                .UseVisualStyleBackColor = True}

            AddHandler btnSearchPatient.Click, AddressOf SearchPatientButtonClicked
            AddHandler txtPatientSearch.KeyDown, AddressOf PatientSearchKeyDown

            invoicePanel.Controls.Add(searchLabel)
            invoicePanel.Controls.Add(txtPatientSearch)
            invoicePanel.Controls.Add(btnSearchPatient)
        End Sub

        Private Sub SearchPatientButtonClicked(sender As Object, e As EventArgs)
            RaiseEvent PatientSearchRequested(txtPatientSearch.Text)
        End Sub

        Private Sub PatientSearchKeyDown(sender As Object, e As KeyEventArgs)
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                RaiseEvent PatientSearchRequested(txtPatientSearch.Text)
            End If
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

        Private Sub ConfigureLegacyExamFields()
            ' These fields are not displayed. They preserve the existing
            ' Crystal report header-field contract while the dynamic grid is
            ' now the sole data-entry control for clinical and X-Ray items.
            txtExamTemperature = CreateExamTextBox()
            txtExamBloodPressure = CreateExamTextBox()
            txtExamPulse = CreateExamTextBox()
            txtExamRespiratorySystem = CreateExamTextBox()
            txtExamCardiovascularSystem = CreateExamTextBox()
            txtExamAbdomen = CreateExamTextBox()
            txtExamNervousSystem = CreateExamTextBox()
            txtExamExtremities = CreateExamTextBox()
            txtExamChestXRay = CreateExamTextBox()
            txtExamWeight = CreateExamTextBox()
            txtExamHeight = CreateExamTextBox()
            txtExamRightEye = CreateExamTextBox()
            txtExamLeftEye = CreateExamTextBox()
            txtExamRightEar = CreateExamTextBox()
            txtExamLeftEar = CreateExamTextBox()
        End Sub

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

        Public Property MedicalReportFormatIdNo As Int32 Implements IMedicalFitnessReportView.MedicalReportFormatIdNo
            Get
                If cboReportFormat Is Nothing OrElse cboReportFormat.SelectedIndex < 0 Then
                    Return 0
                End If
                Return Convert.ToInt32(cboReportFormat.SelectedValue)
            End Get
            Set(value As Int32)
                If cboReportFormat Is Nothing OrElse value = 0 Then
                    Return
                End If
                cboReportFormat.SelectedValue = value
            End Set
        End Property

        Public Property ReportFormat As String Implements IMedicalFitnessReportView.ReportFormat
            Get
                Dim format = _reportFormats.FirstOrDefault(Function(item) item.MRIdNo = MedicalReportFormatIdNo)
                If format IsNot Nothing Then
                    Return format.FormatCode
                End If
                Return "STANDARD"
            End Get
            Set(value As String)
                If cboReportFormat Is Nothing Then
                    Return
                End If
                Dim format = _reportFormats.FirstOrDefault(
                    Function(item) String.Equals(item.FormatCode, value, StringComparison.OrdinalIgnoreCase))
                If format IsNot Nothing Then
                    cboReportFormat.SelectedValue = format.MRIdNo
                End If
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

                Dim inputMode = If(result.InputMode, "").Trim().ToUpperInvariant()
                SetEntryCellEnabled(gridRow.Cells(colResultText.Index), True)
                SetEntryCellEnabled(gridRow.Cells(colFit.Index), inputMode = "" OrElse inputMode = "FIT_UNFIT")
                SetEntryCellEnabled(gridRow.Cells(colUnfit.Index), inputMode = "" OrElse inputMode = "FIT_UNFIT")
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

        Public Function SelectPatientInvoice(results As List(Of MedicalFitnessReportInvoiceSearchResult)) As Int32 Implements IMedicalFitnessReportView.SelectPatientInvoice
            If results Is Nothing OrElse results.Count = 0 Then
                Return 0
            End If

            Using selector As New MedicalFitnessReportInvoiceSearchForm(results)
                If selector.ShowDialog(Me) = DialogResult.OK Then
                    Return selector.SelectedInvoiceNo
                End If
            End Using

            Return 0
        End Function

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

            Dim reportData = New MedicalFitnessReportDao().GetReportPrintDataSet(InvoiceNo)
            Dim medicalReportForm As ReportForm
            Dim reportFormat = _dao.GetReportFormat(MedicalReportFormatIdNo)
            If reportFormat Is Nothing Then
                MessageBox.Show("Select a valid medical report format before printing.")
                Return True
            End If

            If String.Equals(reportFormat.FormatCode, "LEGACY", StringComparison.OrdinalIgnoreCase) Then
                medicalReportForm = New ReportForm(
                    reportFormat.CrystalReportFileName,
                    InvoiceNo,
                    "InvoiceNo",
                    SuppressLogoForPrint,
                    "SuppressLogo")
            Else
                medicalReportForm = ReportForm.CreateSorted(
                    reportFormat.CrystalReportFileName,
                    "MedicalFitnessReportPrint_View",
                    "Sequence",
                    reportData,
                    InvoiceNo,
                    "InvoiceNo",
                    SuppressLogoForPrint,
                    "SuppressLogo")
            End If
            medicalReportForm.Show()
            Return True
        End Function

        Public Function ValidateRequiredEntries(actionName As String) As Boolean Implements IMedicalFitnessReportView.ValidateRequiredEntries
            If dgvResults IsNot Nothing Then
                dgvResults.EndEdit()
                _bindingSource.EndEdit()
            End If

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
            ' Examination-item required flags are now fully configurable.
            ' Do not require legacy Temperature/Blood Pressure/Pulse fields
            ' when those items are inactive or not mapped to the selected
            ' report format.
            For Each row In _testResults.Where(Function(item) item.IsRequired)
                If String.IsNullOrWhiteSpace(row.ResultText) AndAlso String.IsNullOrWhiteSpace(row.ResultStatus) Then
                    missing.Add(If(String.IsNullOrWhiteSpace(row.TestNameEnglish), row.TestCode, row.TestNameEnglish))
                End If
            Next
            If String.IsNullOrWhiteSpace(FinalResultStatus) Then
                missing.Add("Final Result")
            End If
            Return missing
        End Function

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

        Private Sub dgvResults_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvResults.CellValidating
            If e.RowIndex < 0 OrElse e.ColumnIndex < 0 OrElse
               dgvResults.Columns(e.ColumnIndex).DataPropertyName <> "ResultText" Then
                Return
            End If

            Dim row = TryCast(dgvResults.Rows(e.RowIndex).DataBoundItem, MedicalFitnessReportTestResultView)
            If row Is Nothing OrElse Not String.Equals(row.InputMode, "NUMBER", StringComparison.OrdinalIgnoreCase) OrElse
               String.IsNullOrWhiteSpace(Convert.ToString(e.FormattedValue)) Then
                Return
            End If

            Dim number As Decimal
            If Not Decimal.TryParse(Convert.ToString(e.FormattedValue), number) Then
                e.Cancel = True
                MessageBox.Show("Enter a numeric value for " & row.TestNameEnglish & ".")
            End If
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
