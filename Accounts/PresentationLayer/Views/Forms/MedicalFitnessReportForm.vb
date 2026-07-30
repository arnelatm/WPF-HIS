Imports System.ComponentModel
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Partial Public Class MedicalFitnessReportForm
        Inherits AATM.PresentationLayer.Forms.CFormBase
        Implements IMedicalFitnessReportView

        Private _reportIdNo As Int32
        Private _invoiceDate As Date?
        Private _testResults As New BindingList(Of MedicalFitnessReportTestResultView)
        Private ReadOnly _bindingSource As New BindingSource()

        Public Event RetrieveRequested() Implements IMedicalFitnessReportView.RetrieveRequested
        Public Event SaveRequested() Implements IMedicalFitnessReportView.SaveRequested

        Public Sub New()
            InitializeComponent()
            SingleData = True
            QueryOnly = False
            ConfigureGridColumns()
            BindGrid()
        End Sub

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
                _testResults = If(value, New BindingList(Of MedicalFitnessReportTestResultView)())
                BindGrid()
            End Set
        End Property

        Private Sub BindGrid()
            If _bindingSource Is Nothing OrElse dgvResults Is Nothing Then
                Return
            End If
            _bindingSource.DataSource = _testResults
            dgvResults.DataSource = _bindingSource
        End Sub

        Private Sub ConfigureGridColumns()
            If dgvResults Is Nothing OrElse dgvResults.Columns.Count > 0 Then
                Return
            End If

            dgvResults.AutoGenerateColumns = False

            colSection = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "SectionCode",
                .HeaderText = "Section",
                .Name = "colSection",
                .ReadOnly = True,
                .FillWeight = 75}
            colTest = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "TestNameEnglish",
                .HeaderText = "Test",
                .Name = "colTest",
                .ReadOnly = True,
                .FillWeight = 160}
            colResultText = New DataGridViewTextBoxColumn With {
                .DataPropertyName = "ResultText",
                .HeaderText = "Result",
                .Name = "colResultText",
                .FillWeight = 120}
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
                colSection,
                colTest,
                colResultText,
                colFit,
                colUnfit,
                colRemarks})
        End Sub

        Private Sub btnRetrieve_Click(sender As Object, e As EventArgs) Handles btnRetrieve.Click
            RaiseEvent RetrieveRequested()
        End Sub

        Private Sub btnSaveReport_Click(sender As Object, e As EventArgs) Handles btnSaveReport.Click
            dgvResults.EndEdit()
            _bindingSource.EndEdit()
            RaiseEvent SaveRequested()
        End Sub

        Private Sub txtInvoiceNo_Validated(sender As Object, e As EventArgs) Handles txtInvoiceNo.Validated
            If InvoiceNo <> 0 Then
                RaiseEvent RetrieveRequested()
            End If
        End Sub

        Private Sub dgvResults_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvResults.CurrentCellDirtyStateChanged
            If dgvResults.IsCurrentCellDirty Then
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
            dgvResults.InvalidateRow(e.RowIndex)
        End Sub

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
