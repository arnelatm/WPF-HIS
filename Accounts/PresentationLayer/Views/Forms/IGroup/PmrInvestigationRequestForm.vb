Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PmrInvestigationRequestForm
        Implements IPmrInvestigationView

        Public Event GetDoctorPatientsRequested() Implements IPmrInvestigationView.GetDoctorPatientsRequested

        Public Event DoctorCodeRequested(ByRef drId As String) Implements IPmrInvestigationView.DoctorCodeRequested

        Private _pmrPatientsDisplay As New List(Of PmrPatientDisplayView)
        Private _doctorId As String

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            dtpTransactionDate.Value = Today()

            With DataGridViewPmrPatientDisplay
                .DefaultCellStyle.ForeColor = Color.Black
                .BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
                Dim dgvPrintColumn As New DataGridViewImageColumn
                .Columns.Insert(.Columns.Count, dgvPrintColumn)
                dgvPrintColumn.Image = imgList.Images(0)
                dgvPrintColumn.Width = 30
                dgvPrintColumn.Name = "dgvPrintColumn"
                dgvPrintColumn.HeaderText = Messaging.TranslateCaption("Print")
            End With

        End Sub

        Private _doctorCode As String

        Public Property DoctorCode As String Implements IPmrInvestigationView.DoctorCode
            Get
                Return _doctorCode
            End Get
            Set(value As String)
                txtDoctorId.Text = value
                _doctorCode = value
            End Set
        End Property

        Public ReadOnly Property SeriesDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
            Get
                Return SeriesDataGridViewTextBoxColumn
            End Get
        End Property

        Public Property DoctorName As String Implements IPmrInvestigationView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set(value As String)
                txtDoctorName.Text = value
            End Set
        End Property

        Public Property TransactionDate As Date? Implements IPmrInvestigationView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set(value As Date?)
                dtpTransactionDate.Value = value
            End Set
        End Property

        Public Property PmrPatientsDisplay As List(Of PmrPatientDisplayView) Implements IPmrInvestigationView.PmrPatientsDisplay
            Get
                Return _pmrPatientsDisplay
            End Get
            Set
                _pmrPatientsDisplay = Value
                BindPmrPatientDisplay()
            End Set
        End Property

        Private Sub BindPmrPatientDisplay()
            SuspendLayout()
            bsPmrPatientDisplay.DataSource = Nothing
            DataGridViewPmrPatientDisplay.Refresh()
            bsPmrPatientDisplay.DataSource = PmrPatientsDisplay
            bsPmrPatientDisplay.AllowNew = True
            With DataGridViewPmrPatientDisplay
                .AutoGenerateColumns = False
                .DataSource = bsPmrPatientDisplay
            End With

            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent GetDoctorPatientsRequested()
        End Sub

        Private Sub PmrInvestigationRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Dim drCode As String = ""
            RaiseEvent DoctorCodeRequested(drCode)
            DoctorCode = drCode
            RaiseEvent GetDoctorPatientsRequested()
            dtpTransactionDate.EditingMode = True
            btnSave.Visible = False
            btnEdit.Visible = False
            btnUndo.Visible = False
            btnEdit.Visible = False
            btnUndo.Visible = False
            btnFilter.Visible = False
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewPmrPatientDisplay.CellFormatting
            For Each myRow As DataGridViewRow In DataGridViewPmrPatientDisplay.Rows
                If myRow.Cells("dgvFileType").Value = "Old" Then
                    myRow.DefaultCellStyle.ForeColor = Color.Coral
                Else
                    myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
                End If
                myRow.DefaultCellStyle.BackColor = Color.White
            Next
        End Sub

        Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            RaiseEvent GetDoctorPatientsRequested()
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPmrPatientDisplay.CellClick
            With DataGridViewPmrPatientDisplay
                If .CurrentCell IsNot Nothing And .CurrentCell.OwningColumn.Name() = $"dgvPrintColumn" Then
                    Dim transKey As Int32 = .CurrentRow.Cells("dgvTransKey").Value
                    Dim parameter As New ArrayList
                    parameter.Add({"TransKey", transKey})
                    Dim cForm As New ReportFormIGroup($"PMR Doctors Form.Rpt", FormCulture, parameter)
                    cForm.Show()
                End If
            End With
        End Sub

    End Class

End Namespace