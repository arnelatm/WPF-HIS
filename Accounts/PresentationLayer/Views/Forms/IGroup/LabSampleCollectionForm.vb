Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class IbLabSampleForm
        Implements IIbLabSampleView

        'Public Event GetDoctorPatientsRequested() Implements IbLabSampleView.GetDoctorPatientsRequested

        'Public Event DoctorCodeRequested(ByRef drId As String) Implements IbLabSampleView.DoctorCodeRequested

        'Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements IbLabSampleView.GetPmrDataAccessRequested

        Private _ibLabSampleDetails As New List(Of IbLabSampleDetailView)
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
            With DataGridViewIbLabSample
                .Columns.Insert(.Columns.Count, dgvColumnName)
                dgvColumnName.Image = imgList.Images(0)
                dgvColumnName.Width = 35
                dgvColumnName.Name = dgvName
                dgvColumnName.HeaderText = Messaging.TranslateCaption(caption)
            End With
        End Sub

        Public ReadOnly Property SeriesDataGridViewTextBoxColumnProperty As DataGridViewTextBoxColumn
            Get
                Return SeriesDataGridViewTextBoxColumn
            End Get
        End Property

        Public Property TransactionDate As Date? Implements IIbLabSampleView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set(value As Date?)
                dtpTransactionDate.Value = value
            End Set
        End Property



        Public Property IbLabSampleDetails As List(Of IbLabSampleDetailView) Implements IIbLabSampleView.IbLabSampleDetails
            Get
                Return _ibLabSampleDetails
            End Get
            Set
                _ibLabSampleDetails = Value
                BindIbSampleDisplay()
            End Set
        End Property

        Private Sub BindIbSampleDisplay()
            SuspendLayout()
            bsLabSampleDetail.DataSource = Nothing
            DataGridViewIbLabSample.Refresh()
            bsLabSampleDetail.DataSource = IbLabSampleDetails
            bsLabSampleDetail.AllowNew = True
            With DataGridViewIbLabSample
                .AutoGenerateColumns = False
                .DataSource = bsLabSampleDetail
            End With

            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            'If DoctorCode IsNot Nothing Then
            '    RaiseEvent GetDoctorPatientsRequested()
            'Else
            '    PmrPatientsDisplay.Clear()
            '    DataGridViewIbLabSample.Refresh()
            'End If
        End Sub

        Private Sub IbLabSampleCollectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'RaiseEvent GetPmrDataAccessRequested(_dataAccessLevel)
            'With DataGridViewPmrPatientDisplay
            '    .DefaultCellStyle.ForeColor = Color.Black
            '    .BackColor = Color.White
            '    .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
            '    If Mid(_dataAccessLevel, 1, 1) = "1" Then
            '        Dim dgvPharma As New DataGridViewImageColumn
            '        AddDgColumn(dgvPharma, "dgvPharma", "Pharm")
            '    End If
            '    If Mid(_dataAccessLevel, 2, 1) = "1" Then
            '        Dim dgvLab As New DataGridViewImageColumn
            '        AddDgColumn(dgvLab, "dgvLab", "Lab")
            '    End If
            '    If Mid(_dataAccessLevel, 3, 1) = "1" Then
            '        Dim dgvXray As New DataGridViewImageColumn
            '        AddDgColumn(dgvXray, "dgvXray", "XRay")
            '    End If
            '    If Mid(_dataAccessLevel, 4, 1) = "1" Then
            '        Dim dgvOther As New DataGridViewImageColumn
            '        AddDgColumn(dgvOther, "dgvOther", "Other")
            '    End If
            '    If _dataAccessLevel = "1111" Then
            '        Dim dgvAll As New DataGridViewImageColumn
            '        AddDgColumn(dgvAll, "dgvAll", "All")
            '    End If
            'End With

            'Dim drCode As String = ""
            'RaiseEvent DoctorCodeRequested(drCode)
            'If drCode IsNot Nothing Then
            '    DoctorCode = drCode
            '    RaiseEvent GetDoctorPatientsRequested()
            '    cboDoctorName.DisplayOnly = True
            '    'dtpTransactionDate.EditingMode = True
            'Else
            '    'btnEdit.PerformClick()
            '    cboDoctorName.DisplayOnly = False
            '    dtpTransactionDate.DisplayOnly = False
            'End If
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DataGridViewIbLabSample.CellFormatting
            For Each myRow As DataGridViewRow In DataGridViewIbLabSample.Rows
                If myRow.Cells("dgvFileType").Value = "Old" Then
                    myRow.DefaultCellStyle.ForeColor = Color.Coral
                Else
                    myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
                End If
                myRow.DefaultCellStyle.BackColor = Color.White
            Next
        End Sub

        Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            'RaiseEvent GetDoctorPatientsRequested()
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewIbLabSample.CellClick
            'With DataGridViewIbLabSample
            '    Dim whichToPrint As Int16 = 0
            '    If .CurrentCell IsNot Nothing And .CurrentCell.OwningColumn.Name() = $"dgvPharma" Then
            '        whichToPrint = 1
            '    ElseIf .CurrentCell IsNot Nothing And .CurrentCell.OwningColumn.Name() = $"dgvLab" Then
            '        whichToPrint = 2
            '    ElseIf .CurrentCell IsNot Nothing And .CurrentCell.OwningColumn.Name() = $"dgvXray" Then
            '        whichToPrint = 3
            '    ElseIf .CurrentCell IsNot Nothing And .CurrentCell.OwningColumn.Name() = $"dgvOther" Then
            '        whichToPrint = 4
            '    ElseIf .CurrentCell IsNot Nothing And .CurrentCell.OwningColumn.Name() = $"dgvAll" Then
            '        whichToPrint = 5
            '    End If
            '    If whichToPrint > 0 Then
            '        Dim transKey As Int32 = .CurrentRow.Cells("dgvTransKey").Value
            '        Dim parameter As New ArrayList
            '        parameter.Add({"TransKey", transKey})
            '        parameter.Add({"DataAccessLevel", _dataAccessLevel})
            '        parameter.Add({"WhichToPrint", whichToPrint})
            '        Dim cForm As New ReportFormIGroup($"PMR Doctors Form.Rpt", FormCulture, parameter)
            '        cForm.Show()
            '    End If
            'End With
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            'MainFieldsDictionary = New Dictionary(Of String, Object) From
            '    {
            '    {"DoctorCode", txtDoctorCode},
            '    {"DoctorName", cboDoctorName}
            '    }
        End Sub

        Private Sub cboDoctorName_Validated(sender As Object, e As EventArgs)
            'If String.IsNullOrEmpty(cboDoctorName.SelectedValue) Then
            '    PmrPatientsDisplay = Nothing
            '    txtDoctorCode.Text = ""
            'Else
            '    txtDoctorCode.Text = cboDoctorName.SelectedValue
            '    RaiseEvent GetDoctorPatientsRequested()
            'End If
        End Sub

    End Class

End Namespace