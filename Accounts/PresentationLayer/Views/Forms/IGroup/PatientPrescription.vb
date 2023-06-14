Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PatientPrescription
        Implements IPatientView

        Public Event GetDoctorPatientsRequested() Implements IPatientView.GetDoctorPatientsRequested

        Public Event FileNoRequested(ByRef drId As String) Implements IPatientView.FileNoRequested

        Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements IPatientView.GetPmrDataAccessRequested

        Private _pmrPatientsDisplay As New List(Of PmrPatientDisplayView)
        Private _doctorId As String
        Private _dataAccessLevel As String = ""

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
            With DataGridViewPmrPatientDisplay
                .Columns.Insert(.Columns.Count, dgvColumnName)
                dgvColumnName.Image = imgList.Images(0)
                dgvColumnName.Width = 35
                dgvColumnName.Name = dgvName
                dgvColumnName.HeaderText = Messaging.TranslateCaption(caption)
            End With
        End Sub

        Private _FileNo As String

        Public Property FileNo As String Implements IPatientView.FileNo
            Get
                Return cboDoctorName.GetValue()
            End Get
            Set(value As String)
                cboDoctorName.SetValue(value)
            End Set
        End Property

        Public Property DoctorName As String Implements IPatientView.DoctorName
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

        'Public Property DoctorName As String Implements IPatientVIew.DoctorName
        '    Get
        '        Return cboDoctorName.Text
        '    End Get
        '    Set(value As String)
        '        txtDoctorName.Text = value
        '    End Set
        'End Property

        Public Property TransactionDate As Date? Implements IPatientView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set(value As Date?)
                dtpTransactionDate.Value = value
            End Set
        End Property

        Public Property PmrPatientsDisplay As List(Of PmrPatientDisplayView) Implements IPatientView.PmrPatientsDisplay
            Get
                Return _pmrPatientsDisplay
            End Get
            Set
                _pmrPatientsDisplay = Value
                BindPmrPatientDisplay()
            End Set
        End Property

        Public Property RegistrationNo As Integer Implements IPatientView.RegistrationNo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Series As String Implements IPatientView.Series
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PatientNameEnglish As String Implements IPatientView.PatientNameEnglish
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Gender As String Implements IPatientView.Gender
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Age As String Implements IPatientView.Age
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property AgeYMD As String Implements IPatientView.AgeYMD
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
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

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs)
            If FileNo IsNot Nothing Then
                RaiseEvent GetDoctorPatientsRequested()
            Else
                PmrPatientsDisplay.Clear()
                DataGridViewPmrPatientDisplay.Refresh()
            End If
        End Sub

        Private Sub PrescriptionDosage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent GetPmrDataAccessRequested(_dataAccessLevel)
            With DataGridViewPmrPatientDisplay
                .DefaultCellStyle.ForeColor = Color.Black
                .BackColor = Color.White
                .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            End With
            Dim drCode As String = ""
            RaiseEvent FileNoRequested(drCode)
            If drCode IsNot Nothing Then
                FileNo = drCode
                RaiseEvent GetDoctorPatientsRequested()
                cboDoctorName.DisplayOnly = True
                'dtpTransactionDate.EditingMode = True
            Else
                'btnEdit.PerformClick()
                cboDoctorName.DisplayOnly = False
                dtpTransactionDate.DisplayOnly = False
            End If
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
                'Dim cForm As New ReportFormIGroup($"PMR Doctors Form.Rpt", FormCulture)
            End With
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"FileNo", txtFileNo},
                {"DoctorName", cboDoctorName}
                }
        End Sub

        Private Sub cboDoctorName_Validated(sender As Object, e As EventArgs)
            If String.IsNullOrEmpty(cboDoctorName.SelectedValue) Then
                PmrPatientsDisplay = Nothing
                txtFileNo.Text = ""
            Else
                txtFileNo.Text = cboDoctorName.SelectedValue
                RaiseEvent GetDoctorPatientsRequested()
            End If
        End Sub

    End Class

End Namespace