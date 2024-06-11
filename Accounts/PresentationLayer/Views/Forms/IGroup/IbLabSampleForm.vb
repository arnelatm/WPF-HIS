Imports AATM.Accounts.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class IbLabSampleForm
        Implements IIbLabSampleView

        'Public Event GetDoctorPatientsRequested() Implements IbLabSampleView.GetDoctorPatientsRequested

        'Public Event DoctorCodeRequested(ByRef drId As String) Implements IbLabSampleView.DoctorCodeRequested

        'Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements IbLabSampleView.GetPmrDataAccessRequested

        Private _ibLabSampleDetails As New List(Of IbLabSampleDetailView)
        Private _doctorId As String
        Private _dataAccessLevel As String = ""

        Public Event IbLabSamplesRequested(transactionDate As Date?) Implements IIbLabSampleView.IbLabSamplesRequested
        Public Event IbLabSampleChanged(bindingSource As BindingSource) Implements IIbLabSampleView.IbLabSampleChanged

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
                BindIbLabSampleDisplay()
            End Set
        End Property

        Private Sub BindIbLabSampleDisplay()
            SuspendLayout()
            bsIbLabSampleDetails.DataSource = Nothing
            DataGridViewIbLabSampleDetails.Refresh()
            bsIbLabSampleDetails.DataSource = IbLabSampleDetails
            bsIbLabSampleDetails.AllowNew = True
            With DataGridViewIbLabSampleDetails
                .AutoGenerateColumns = False
                .DataSource = bsIbLabSampleDetails
            End With
            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent IbLabSamplesRequested(TransactionDate)
        End Sub

        Private Sub IbLabSampleCollectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent IbLabSamplesRequested(TransactionDate)
            dgvAge.SetFormat(3, 0)
            dgvAge.DisplayOnly = True
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
            'For Each myRow As DataGridViewRow In DataGridViewIbLabSampleDetails.Rows
            '    If myRow.Cells("dgvFileType").Value = "Old" Then
            '        myRow.DefaultCellStyle.ForeColor = Color.Coral
            '    Else
            '        myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
            '    End If
            '    myRow.DefaultCellStyle.BackColor = Color.White
            'Next
        End Sub

        'Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
        '    RaiseEvent IbLabSamplesRequested(TransactionDate)
        'End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs)
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

        Private Sub DataGridViewIbLabSampleDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewIbLabSampleDetails.CellEndEdit
            RaiseEvent IbLabSampleChanged(bsIbLabSampleDetails)
        End Sub

        Private Sub CheckBoxValueChanged() Handles DataGridViewIbLabSampleDetails.CellValueChanged
            With DataGridViewIbLabSampleDetails
                If TypeOf .CurrentCell Is DataGridViewCheckBoxCell Then
                    RaiseEvent IbLabSampleChanged(bsIbLabSampleDetails)
                End If
            End With
        End Sub

        'Private Sub dtpTransactionDate_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtpTransactionDate.Validating
        '    RaiseEvent IbLabSamplesRequested(TransactionDate)
        'End Sub

        Private Sub dtpTransactionDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpTransactionDate.ValueChanged
            RaiseEvent IbLabSamplesRequested(TransactionDate)
        End Sub
    End Class

End Namespace