Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PrescriptionForm
        Implements IPrescriptionView

        'Public Event GetDoctorPatientsRequested() Implements IPrescriptionView.GetDoctorPatientsRequested

        'Public Event FileNoRequested(ByRef drId As String) Implements IPrescriptionView.FileNoRequested

        'Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements IPrescriptionView.GetPmrDataAccessRequested

        Private _prescriptionDetails As New List(Of PrescriptionDetailView)

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            'SingleData = True
            'QueryOnly = True
            'DisplaySetup()
        End Sub

        'Private Sub DisplaySetup()
        '    dtpTransDate.Value = Today()
        'End Sub

        Private Sub AddDgColumn(dgvColumnName As DataGridViewImageColumn, dgvName As String, caption As String)
            With DataGridViewPrescriptionDetails
                .Columns.Insert(.Columns.Count, dgvColumnName)
                dgvColumnName.Image = imgList.Images(0)
                dgvColumnName.Width = 35
                dgvColumnName.Name = dgvName
                dgvColumnName.HeaderText = Messaging.TranslateCaption(caption)
            End With
        End Sub

        'Public Property FileNo As Int32 Implements IPrescriptionView.FileNo
        '    Get
        '        Return txtFileNo.Text
        '    End Get
        '    Set(value As String)
        '        txtFileNo.Text = value
        '    End Set
        'End Property

        'Public Property DoctorName As String Implements IPrescriptionView.DoctorName
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

        'Public Property DoctorName As String Implements IPrescriptionVIew.DoctorName
        '    Get
        '        Return cboDoctorName.Text
        '    End Get
        '    Set(value As String)
        '        txtDoctorName.Text = value
        '    End Set
        'End Property

        'Public Property TransactionDate As Date? Implements IPrescriptionView.TransactionDate
        '    Get
        '        Return dtpTransactionDate.Value
        '    End Get
        '    Set(value As Date?)
        '        dtpTransactionDate.Value = value
        '    End Set
        'End Property

        'Public Property PmrPatientsDisplay As List(Of PmrPatientDisplayView) Implements IPrescriptionView.PmrPatientsDisplay
        '    Get
        '        Return _pmrPatientsDisplay
        '    End Get
        '    Set
        '        _pmrPatientsDisplay = Value
        '        BindPmrPatientDisplay()
        '    End Set
        'End Property

        Public Property Series As String Implements IPrescriptionView.Series
            Get
                Return txtSeries.Text
                'Return cboSeries.GetValue()
            End Get
            Set(value As String)
                txtSeries.Text = value
                'cboSeries.SetValue(value)
            End Set
        End Property

        Public Property PatientName As String Implements IPrescriptionView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set(value As String)
                txtPatientName.Text = value
            End Set
        End Property

        Public Property Gender As String Implements IPrescriptionView.Gender
            Get
                Return txtGender.Text
                'Return cboGender.GetValue()
            End Get
            Set(value As String)
                txtGender.Text = value
                'cboGender.SetValue(value)
            End Set
        End Property

        Public Property Age As String Implements IPrescriptionView.Age
            Get
                Return txtAge.Text
            End Get
            Set(value As String)
                txtAge.Text = value
            End Set
        End Property

        Public Property AgeYMD As String Implements IPrescriptionView.AgeYmd
            Get
                Return txtAge.Text
            End Get
            Set(value As String)
                txtAge.Text = value
            End Set
        End Property

        Public Property Dob As String Implements IPrescriptionView.Dob

        Public Property FileNo As Integer Implements IPrescriptionView.FileNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtFileNo.Text)
            End Get
            Set
                txtFileNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DoctorName As String Implements IPrescriptionView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set(value As String)
                txtDoctorName.Text = value
            End Set
        End Property

        Public Property TransKey As Integer Implements IPrescriptionView.TransKey
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtTransKey.Text)
            End Get
            Set(value As Integer)
                txtTransKey.Text = value
            End Set
        End Property

        Public Property PrescriptionDetails As List(Of PrescriptionDetailView) Implements IPrescriptionView.PrescriptionDetails
            Get
                Return _prescriptionDetails
            End Get
            Set
                _prescriptionDetails = Value
                BindPrescriptionDetails()
            End Set
        End Property

        Public Property DoctorCode As String Implements IPrescriptionView.DoctorCode
        '    Get
        '        Throw New NotImplementedException()
        '    End Get
        '    Set(value As String)
        '        Throw New NotImplementedException()
        '    End Set
        'End Property

        Public Property TransDate As String Implements IPrescriptionView.TransDate
            Get
                Return dtpTransDate.Value
            End Get
            Set(value As String)
                dtpTransDate.Value = value
            End Set
        End Property

        Private Sub BindPrescriptionDetails()
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
        '    If FileNo IsNot Nothing Then
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
        '    RaiseEvent FileNoRequested(drCode)
        '    If drCode IsNot Nothing Then
        '        FileNo = drCode
        '        RaiseEvent GetDoctorPatientsRequested()
        '        cboDoctorName.DisplayOnly = True
        '        'dtpTransactionDate.EditingMode = True
        '    Else
        '        'btnEdit.PerformClick()
        '        cboDoctorName.DisplayOnly = False
        '        dtpTransactionDate.DisplayOnly = False
        '    End If
        'End Sub

        'Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewPrescriptionDetails.CellFormatting
        '    For Each myRow As DataGridViewRow In DataGridViewPrescriptionDetails.Rows
        '        If myRow.Cells("dgvFileType").Value = "Old" Then
        '            myRow.DefaultCellStyle.ForeColor = Color.Coral
        '        Else
        '            myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
        '        End If
        '        myRow.DefaultCellStyle.BackColor = Color.White
        '    Next
        'End Sub

        'Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
        '    RaiseEvent GetDoctorPatientsRequested()
        'End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPrescriptionDetails.CellClick
            With DataGridViewPrescriptionDetails
                'Dim cForm As New ReportFormIGroup($"PMR Doctors Form.Rpt", FormCulture)
            End With
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Age", txtAge},
                {"AgeYmd", txtAgeYMD},
                {"Dob", txtDob},
                {"DoctorCode", txtDoctorCode},
                {"DoctorName", txtDoctorName},
                {"FileNo", txtFileNo},
                {"Gender", txtGender},
                {"PatientName", txtPatientName},
                {"Series", txtSeries},
                {"TransDate", dtpTransDate},
                {"TransKey", txtTransKey}
                }
        End Sub

        'Private Sub cboDoctorName_Validated(sender As Object, e As EventArgs)
        '    If String.IsNullOrEmpty(cboDoctorName.SelectedValue) Then
        '        PmrPatientsDisplay = Nothing
        '        txtFileNo.Text = ""
        '    Else
        '        txtFileNo.Text = cboDoctorName.SelectedValue
        '        RaiseEvent GetDoctorPatientsRequested()
        '    End If
        'End Sub

    End Class

End Namespace