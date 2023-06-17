Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PatientPrescriptionForm
        Implements IPatientPrescriptionView

        'Public Event GetDoctorPatientsRequested() Implements IPatientView.GetDoctorPatientsRequested

        'Public Event RegistrationNoRequested(ByRef drId As String) Implements IPatientView.RegistrationNoRequested

        'Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements IPatientView.GetPmrDataAccessRequested

        Private _prescriptionDetails As New List(Of PrescriptionDetailView)

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

        Private Sub AddDgColumn(dgvColumnName As DataGridViewImageColumn, dgvName As String, caption As String)
            With DataGridViewPrescriptionDetails
                .Columns.Insert(.Columns.Count, dgvColumnName)
                dgvColumnName.Image = imgList.Images(0)
                dgvColumnName.Width = 35
                dgvColumnName.Name = dgvName
                dgvColumnName.HeaderText = Messaging.TranslateCaption(caption)
            End With
        End Sub

        'Public Property RegistrationNo As Int32 Implements IPatientView.RegistrationNo
        '    Get
        '        Return txtRegistrationNo.Text
        '    End Get
        '    Set(value As String)
        '        txtRegistrationNo.Text = value
        '    End Set
        'End Property

        'Public Property DoctorName As String Implements IPatientView.DoctorName
        '    Get
        '        Return cboDoctorName.GetValue()
        '    End Get
        '    Set(value As String)
        '        cboDoctorName.SetValue(value)
        '    End Set
        'End Property

        Public ReadOnly Property SeriesDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
            Get
                Return SeriesDataGridViewTextBoxColumn
            End Get
        End Property

        'Public Property DoctorName As String Implements IPatientVIew.DoctorName
        '    Get
        '        Return cboDoctorName.Text
        '    End Get
        '    Set(value As String)
        '        txtDoctorName.Text = value
        '    End Set
        'End Property

        'Public Property TransactionDate As Date? Implements IPatientView.TransactionDate
        '    Get
        '        Return dtpTransactionDate.Value
        '    End Get
        '    Set(value As Date?)
        '        dtpTransactionDate.Value = value
        '    End Set
        'End Property

        'Public Property PmrPatientsDisplay As List(Of PmrPatientDisplayView) Implements IPatientView.PmrPatientsDisplay
        '    Get
        '        Return _pmrPatientsDisplay
        '    End Get
        '    Set
        '        _pmrPatientsDisplay = Value
        '        BindPmrPatientDisplay()
        '    End Set
        'End Property

        Public Property Series As String Implements IPatientView.Series
            Get
                Return cboSeries.GetValue()
            End Get
            Set(value As String)
                cboSeries.SetValue(value)
            End Set
        End Property

        Public Property PatientNameEnglish As String Implements IPatientView.PatientNameEnglish
            Get
                Return txtPatientNameEnglish.Text
            End Get
            Set(value As String)
                txtPatientNameEnglish.Text = value
            End Set
        End Property

        Public Property Gender As String Implements IPatientView.Gender
            Get
                Return cboGender.GetValue()
            End Get
            Set(value As String)
                cboGender.SetValue(value)
            End Set
        End Property

        Public Property Age As String Implements IPatientView.Age
            Get
                Return txtAge.Text
            End Get
            Set(value As String)
                txtAge.Text = value
            End Set
        End Property

        Public Property AgeYMD As String Implements IPatientView.AgeYMD
            Get
                Return txtAge.Text
            End Get
            Set(value As String)
                txtAge.Text = value
            End Set
        End Property

        Public Property PrescriptionDetail As List(Of Prescription) Implements IPatientPrescriptionView.PrescriptionDetail

        Public Property RegistrationNo As Integer Implements IPatientView.RegistrationNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtRegistrationNo.Text)
            End Get
            Set
                txtRegistrationNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Private Sub BindPmrPatientDisplay()
            SuspendLayout()
            bsPrescriptionDetails.DataSource = Nothing
            DataGridViewPrescriptionDetails.Refresh()
            bsPrescriptionDetails.DataSource =
            bsPrescriptionDetails.AllowNew = True
            With DataGridViewPrescriptionDetails
                .AutoGenerateColumns = False
                .DataSource = bsPrescriptionDetails
            End With

            ResumeLayout()
        End Sub

        'Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs)
        '    If RegistrationNo IsNot Nothing Then
        '        RaiseEvent GetDoctorPatientsRequested()
        '    Else
        '        PmrPatientsDisplay.Clear()
        '        DataGridViewPmrPatientDisplay.Refresh()
        '    End If
        'End Sub

        'Private Sub PrescriptionDosage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    RaiseEvent GetPmrDataAccessRequested(_dataAccessLevel)
        '    With DataGridViewPmrPatientDisplay
        '        .DefaultCellStyle.ForeColor = Color.Black
        '        .BackColor = Color.White
        '        .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        '    End With
        '    Dim drCode As String = ""
        '    RaiseEvent RegistrationNoRequested(drCode)
        '    If drCode IsNot Nothing Then
        '        RegistrationNo = drCode
        '        RaiseEvent GetDoctorPatientsRequested()
        '        cboDoctorName.DisplayOnly = True
        '        'dtpTransactionDate.EditingMode = True
        '    Else
        '        'btnEdit.PerformClick()
        '        cboDoctorName.DisplayOnly = False
        '        dtpTransactionDate.DisplayOnly = False
        '    End If
        'End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewPrescriptionDetails.CellFormatting
            For Each myRow As DataGridViewRow In DataGridViewPrescriptionDetails.Rows
                If myRow.Cells("dgvFileType").Value = "Old" Then
                    myRow.DefaultCellStyle.ForeColor = Color.Coral
                Else
                    myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
                End If
                myRow.DefaultCellStyle.BackColor = Color.White
            Next
        End Sub

        'Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
        '    RaiseEvent GetDoctorPatientsRequested()
        'End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPrescriptionDetails.CellClick
            With DataGridViewPrescriptionDetails
                'Dim cForm As New ReportFormIGroup($"PMR Doctors Form.Rpt", FormCulture)
            End With
        End Sub

        'Protected Overrides Sub CreateMainFieldsDictionary()
        '    MainFieldsDictionary = New Dictionary(Of String, Object) From
        '        {
        '        {"RegistrationNo", txtRegistrationNo},
        '        {"DoctorName", cboDoctorName}
        '        }
        'End Sub

        'Private Sub cboDoctorName_Validated(sender As Object, e As EventArgs)
        '    If String.IsNullOrEmpty(cboDoctorName.SelectedValue) Then
        '        PmrPatientsDisplay = Nothing
        '        txtRegistrationNo.Text = ""
        '    Else
        '        txtRegistrationNo.Text = cboDoctorName.SelectedValue
        '        RaiseEvent GetDoctorPatientsRequested()
        '    End If
        'End Sub

    End Class

End Namespace