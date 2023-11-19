Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class ClinicLabSampleForm
        Implements IClinicLabSampleView

        'Public Event GetDoctorPatientsRequested() Implements ClinicLabSampleView.GetDoctorPatientsRequested

        'Public Event DoctorCodeRequested(ByRef drId As String) Implements ClinicLabSampleView.DoctorCodeRequested

        'Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements ClinicLabSampleView.GetPmrDataAccessRequested

        Private _ClinicLabSampleDetails As New List(Of ClinicLabSampleDetailView)
        Private _doctorId As String
        Private _dataAccessLevel As String = ""

        Public Event ClinicLabSamplesRequested(transactionDate As Date?) Implements IClinicLabSampleView.ClinicLabSamplesRequested
        Public Event ClinicLabSampleChanged(bindingSource As BindingSource) Implements IClinicLabSampleView.ClinicLabSampleChanged

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

        Public Property TransactionDate As Date? Implements IClinicLabSampleView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set(value As Date?)
                dtpTransactionDate.Value = value
            End Set
        End Property

        Public Property ClinicLabSampleDetails As List(Of ClinicLabSampleDetailView) Implements IClinicLabSampleView.ClinicLabSampleDetails
            Get
                Return _ClinicLabSampleDetails
            End Get
            Set
                _ClinicLabSampleDetails = Value
                BindClinicLabSampleDisplay()
            End Set
        End Property

        Private Sub BindClinicLabSampleDisplay()
            SuspendLayout()
            bsClinicLabSampleDetails.DataSource = Nothing
            DataGridViewClinicLabSampleDetails.Refresh()
            bsClinicLabSampleDetails.DataSource = ClinicLabSampleDetails
            bsClinicLabSampleDetails.AllowNew = True
            With DataGridViewClinicLabSampleDetails
                .AutoGenerateColumns = False
                .DataSource = bsClinicLabSampleDetails
            End With
            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent ClinicLabSamplesRequested(TransactionDate)
        End Sub

        Private Sub ClinicLabSampleCollectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent ClinicLabSamplesRequested(TransactionDate)
            dgvAge.SetFormat(3, 0)
            dgvAge.DisplayOnly = True
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
            'For Each myRow As DataGridViewRow In DataGridViewClinicLabSampleDetails.Rows
            '    If myRow.Cells("dgvFileType").Value = "Old" Then
            '        myRow.DefaultCellStyle.ForeColor = Color.Coral
            '    Else
            '        myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
            '    End If
            '    myRow.DefaultCellStyle.BackColor = Color.White
            'Next
        End Sub

        Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            'RaiseEvent GetDoctorPatientsRequested()
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs)
            'With DataGridViewClinicLabSample
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

        Private Sub DataGridViewClinicLabSampleDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewClinicLabSampleDetails.CellEndEdit
            RaiseEvent ClinicLabSampleChanged(bsClinicLabSampleDetails)
        End Sub
    End Class

End Namespace