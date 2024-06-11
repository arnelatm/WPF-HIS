Imports System.Data.Common
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports Telerik.WinControls.VirtualKeyboard

Namespace PresentationLayer.Views.Forms

    Public Class IbLabResultForm
        Implements IIbLabResultView

        'Public Event GetDoctorPatientsRequested() Implements IbLabResultView.GetDoctorPatientsRequested

        'Public Event DoctorCodeRequested(ByRef drId As String) Implements IbLabResultView.DoctorCodeRequested

        'Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements IbLabResultView.GetPmrDataAccessRequested

        Private _ibLabResultDetails As New List(Of IbLabResultDetailView)
        Private _doctorId As String
        Private _dataAccessLevel As String = ""

        Public Event IbLabResultRequested(transactionDate As Date?) Implements IIbLabResultView.IbLabResultRequested
        Public Event IbLabResultChanged(bindingSource As BindingSource) Implements IIbLabResultView.IbLabResultChanged
        Public Event FillUpButtonClicked() Implements IIbLabResultView.FillUpButtonClicked

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

        Public Property TransactionDate As Date? Implements IIbLabResultView.TransactionDate
            Get
                Return dtpTransactionDate.Value
            End Get
            Set(value As Date?)
                dtpTransactionDate.Value = value
            End Set
        End Property

        Public Property IbLabResultDetails As List(Of IbLabResultDetailView) Implements IIbLabResultView.IbLabResultDetails
            Get
                Return _ibLabResultDetails
            End Get
            Set
                _ibLabResultDetails = Value
                BindIbLabResultDisplay()
            End Set
        End Property

        Private Sub BindIbLabResultDisplay()
            SuspendLayout()
            bsIbLabResultDetails.DataSource = Nothing
            DataGridViewIbLabResultDetails.Refresh()
            bsIbLabResultDetails.DataSource = IbLabResultDetails
            bsIbLabResultDetails.AllowNew = True
            With DataGridViewIbLabResultDetails
                .AutoGenerateColumns = False
                .DataSource = bsIbLabResultDetails
            End With
            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent IbLabResultRequested(TransactionDate)
        End Sub

        Private Sub IbLabResultCollectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent IbLabResultRequested(TransactionDate)
            'dgvClinical.ThreeState = True
            ''dgvAge.DisplayOnly = True
            'For Each col In DataGridViewIbLabResultDetails.Columns
            '    Dim headerCell As DataGridViewColumnHeaderCell = col.HeaderCell
            '    headerCell.ToolTipText = col.HeaderText
            'Next
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
            'For Each myRow As DataGridViewRow In DataGridViewIbLabResultDetails.Rows
            '    If myRow.Cells("dgvFileType").Value = "Old" Then
            '        myRow.DefaultCellStyle.ForeColor = Color.Coral
            '    Else
            '        myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
            '    End If
            '    myRow.DefaultCellStyle.BackColor = Color.White
            'Next
        End Sub

        Private Sub dtpTransactionDate_Validated(sender As Object, e As EventArgs) Handles dtpTransactionDate.Validated
            RaiseEvent IbLabResultRequested(TransactionDate)
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs)
            'With DataGridViewIbLabResult
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

        Private Sub DataGridViewIbLabResultDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewIbLabResultDetails.CellEndEdit
            RaiseEvent IbLabResultChanged(bsIbLabResultDetails)
        End Sub

        Private Sub CheckBoxValueChanged() Handles DataGridViewIbLabResultDetails.CellValueChanged
            With DataGridViewIbLabResultDetails
                If TypeOf .CurrentCell Is DataGridViewCheckBoxCell Then
                    RaiseEvent IbLabResultChanged(bsIbLabResultDetails)
                End If
            End With
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            RaiseEvent FillUpButtonClicked()
        End Sub

        'Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewIbLabResultDetails.CellEndEdit
        '    ProcessCellEndEdit(DataGridViewIbLabResultDetails, bsIbLabResultDetails)
        'End Sub

        Private Sub Grid_OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewIbLabResultDetails.CellBeginEdit
            With DataGridViewIbLabResultDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name.ToLower()
                If cColumnName = $"dgvpregnancy" Then
                    If bsIbLabResultDetails.Current.Gender = "M" Then
                        Beep()
                        e.Cancel = True
                    End If
                End If
                If DataGridViewIbLabResultDetails.CurrentCell.OwningColumn.CellType.Name = "DataGridViewCheckBoxCell" Then
                    DataGridViewIbLabResultDetails.EndEdit()
                End If
            End With
        End Sub

    End Class

End Namespace