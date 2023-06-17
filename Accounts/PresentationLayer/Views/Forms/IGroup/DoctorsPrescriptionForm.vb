Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class DoctorsPrescriptionForm
        Implements IDoctorsPrescriptionView

        Public Event GetDoctorPatientsRequested() Implements IDoctorsPrescriptionView.GetDoctorPatientsRequested

        Public Event DoctorCodeRequested(ByRef drId As String) Implements IDoctorsPrescriptionView.DoctorCodeRequested

        Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements IDoctorsPrescriptionView.GetPmrDataAccessRequested

        Private _pmrDoctorsPatients As New List(Of DoctorsPatientView)
        Private _doctorId As String
        Private _dataAccessLevel As String = ""
        Private _prescriptionDetails As New List(Of PrescriptionDetailView)
        Public Event RowChanged(patientIdNo As Int32) Implements IDoctorsPrescriptionView.RowChanged

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            SingleData = True
            QueryOnly = True
            DisplaySetup()
        End Sub

        Private Sub DisplaySetup()
            dtpTransactionDate.Value = Today()
        End Sub

        Private _doctorCode As String

        Public Property DoctorCode As String Implements IDoctorsPrescriptionView.DoctorCode
            Get
                Return cboDoctorName.GetValue()
            End Get
            Set(value As String)
                cboDoctorName.SetValue(value)
            End Set
        End Property

        Public Property DoctorName As String Implements IDoctorsPrescriptionView.DoctorName
            Get
                Return cboDoctorName.GetValue()
            End Get
            Set(value As String)
                cboDoctorName.SetValue(value)
            End Set
        End Property

        Public ReadOnly Property SeriesDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
            Get
                Return SeriesDataGridViewTextBoxColumn
            End Get
        End Property

        'Public Property DoctorName As String Implements IPmrInvestigationView.DoctorName
        '    Get
        '        Return cboDoctorName.Text
        '    End Get
        '    Set(value As String)
        '        txtDoctorName.Text = value
        '    End Set
        'End Property

        Public Property TransactionDate As Date? Implements IDoctorsPrescriptionView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set(value As Date?)
                dtpTransactionDate.Value = value
            End Set
        End Property

        Public Property DoctorsPatients As List(Of DoctorsPatientView) Implements IDoctorsPrescriptionView.DoctorsPatients
            Get
                Return _pmrDoctorsPatients
            End Get
            Set
                _pmrDoctorsPatients = Value
                BindDoctorsPatient()
            End Set
        End Property

        Public Property PrescriptionDetails As List(Of PrescriptionDetailView) Implements IDoctorsPrescriptionView.PrescriptionDetails
            Get
                Return _prescriptionDetails
            End Get
            Set
                _prescriptionDetails = Value
                BindPrescriptionDetails()
            End Set
        End Property

        Private Sub BindDoctorsPatient()
            SuspendLayout()
            bsDoctorsPatient.DataSource = Nothing
            DataGridViewDoctorsPatient.Refresh()
            bsDoctorsPatient.DataSource = DoctorsPatients
            bsDoctorsPatient.AllowNew = True
            With DataGridViewDoctorsPatient
                .AutoGenerateColumns = False
                .DataSource = bsDoctorsPatient
            End With

            ResumeLayout()
        End Sub

        Private Sub BindPrescriptionDetails()
            SuspendLayout()
            bsPrescriptionDetails.DataSource = Nothing
            DataGridViewPrescriptionDetails.Refresh()
            bsPrescriptionDetails.DataSource = PrescriptionDetails
            bsPrescriptionDetails.AllowNew = False
            ResumeLayout()
        End Sub


        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            If DoctorCode IsNot Nothing Then
                RaiseEvent GetDoctorPatientsRequested()
            Else
                DoctorsPatients.Clear()
                DataGridViewDoctorsPatient.Refresh()
            End If
        End Sub

        Private Sub PrescriptionDosage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent GetPmrDataAccessRequested(_dataAccessLevel)
            With DataGridViewDoctorsPatient
                .DefaultCellStyle.ForeColor = Color.Black
                .BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            End With
            Dim drCode As String = ""
            RaiseEvent DoctorCodeRequested(drCode)
            If drCode IsNot Nothing Then
                DoctorCode = drCode
                RaiseEvent GetDoctorPatientsRequested()
                cboDoctorName.DisplayOnly = True
                'dtpTransactionDate.EditingMode = True
            Else
                'btnEdit.PerformClick()
                cboDoctorName.DisplayOnly = False
                dtpTransactionDate.DisplayOnly = False
            End If
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewDoctorsPatient.CellFormatting
            For Each myRow As DataGridViewRow In DataGridViewDoctorsPatient.Rows
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

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDoctorsPatient.CellClick
            With DataGridViewDoctorsPatient
                'Dim cForm As New ReportFormIGroup($"PMR Doctors Form.Rpt", FormCulture)
            End With
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"DoctorCode", txtDoctorCode},
                {"DoctorName", cboDoctorName}
                }
        End Sub

        Private Sub cboDoctorName_Validated(sender As Object, e As EventArgs) Handles cboDoctorName.SelectionChangeCommitted, cboDoctorName.Leave
            If String.IsNullOrEmpty(cboDoctorName.SelectedValue) Then
                DoctorsPatients = Nothing
                txtDoctorCode.Text = ""
            Else
                txtDoctorCode.Text = cboDoctorName.SelectedValue
                RaiseEvent GetDoctorPatientsRequested()
            End If
        End Sub

        Private Sub DataGridViewPrescriptionDetails_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDoctorsPatient.RowEnter
            Dim dgvRow As DataGridViewRow = DataGridViewDoctorsPatient.Rows(e.RowIndex)
            Dim ptIdNo As Int32 = dgvRow.Cells("dgvPatientIdNo").Value
            RaiseEvent RowChanged(ptIdNo)
            bsPrescriptionDetails.ResetBindings(False)
            CGroupBox1.Text = Messaging.TranslateCaption("Prescription for ") + dgvRow.Cells("dgvFileNo").Value + "-" + dgvRow.Cells("dgvPatientName").Value
        End Sub
    End Class

End Namespace