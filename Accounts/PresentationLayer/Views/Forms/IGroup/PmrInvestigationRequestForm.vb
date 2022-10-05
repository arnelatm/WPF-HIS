Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.GlobalResources
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class PmrInvestigationRequestForm
        Implements IPmrInvestigationView

        Public Event GetDoctorPatientsRequested() Implements IPmrInvestigationView.GetDoctorPatientsRequested

        Public Event PrintReportRequested(rowIndex As Short) Implements IPmrInvestigationView.PrintReportRequested

        Private _pmrPatientsDisplay As New List(Of PmrPatientDisplayView)

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            dtpTransactionDate.Value = "2022/01/06"
            txtDoctorId.Text = "209"

        End Sub

        Public Property DoctorId As String Implements IPmrInvestigationView.DoctorId
            Get
                Return txtDoctorId.Text
            End Get
            Set(value As String)
                txtDoctorId.Text = value
            End Set
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
            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent GetDoctorPatientsRequested()
        End Sub

        Private Sub PmrInvestigationRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent GetDoctorPatientsRequested()
            dtpTransactionDate.EditingMode = True
            btnSave.Visible = False
            btnEdit.Visible = False
            btnUndo.Visible = False
            btnEdit.Visible = False
            btnUndo.Visible = False
            btnFilter.Visible = False
        End Sub

        Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            RaiseEvent GetDoctorPatientsRequested()
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewPmrPatientDisplay.CellFormatting
            For Each myRow As DataGridViewRow In DataGridViewPmrPatientDisplay.Rows
                If myRow.Cells("dgvPType").Value = "Old" Then
                    myRow.DefaultCellStyle.ForeColor = Color.Coral
                Else
                    myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
                End If
                myRow.DefaultCellStyle.BackColor = Color.White
            Next
        End Sub

    End Class

End Namespace