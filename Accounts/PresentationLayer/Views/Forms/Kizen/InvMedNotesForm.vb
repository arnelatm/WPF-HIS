Imports System.Data.Common
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub
Imports Telerik.WinControls.VirtualKeyboard

Namespace PresentationLayer.Views.Forms

    Public Class InvMedNotesForm
        Implements IInvMedNotesView

        'Public Event GetDoctorPatientsRequested() Implements InvMedNotesView.GetDoctorPatientsRequested

        'Public Event DoctorCodeRequested(ByRef drId As String) Implements InvMedNotesView.DoctorCodeRequested

        'Public Event GetPmrDataAccessRequested(ByRef dataAccessCode As String) Implements InvMedNotesView.GetPmrDataAccessRequested

        Private _InvMedNotesDetails As New List(Of InvMedNotesDetailView)
        Private _doctorId As String
        Private _dataAccessLevel As String = ""
        Private _connectionName As String = "Kizen"

        Public Event InvMedNotesRequested(transactionDate As Int32) Implements IInvMedNotesView.InvMedNotesRequested
        'Public Event InvMedNotesChanged(note As String) Implements IInvMedNotesView.InvMedNotesChanged
        Public Event InvMedNotesChanged(bindingSource As BindingSource) Implements IInvMedNotesView.InvMedNotesChanged

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            SingleData = True
            QueryOnly = True
            DisplaySetup()
        End Sub

        Private Sub DisplaySetup()
            dtpInvoiceDate.Value = Today()
        End Sub

        Public Property InvoiceDate As Date Implements IInvMedNotesView.InvoiceDate
            Get
                Return dtpInvoiceDate.Value
            End Get
            Set(value As Date)
                dtpInvoiceDate.Value = value
            End Set
        End Property

        Public Property InvMedNotesDetails As List(Of InvMedNotesDetailView) Implements IInvMedNotesView.InvMedNotesDetails
            Get
                Return _InvMedNotesDetails
            End Get
            Set
                _InvMedNotesDetails = Value
                BindInvMedNotesDisplay()
            End Set
        End Property

        Public Property PatientName As String Implements IInvMedNotesView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set
                txtPatientName.Text = Value
            End Set
        End Property

        Public Property Gender As String Implements IInvMedNotesView.Gender
            Get
                Return txtGender.Text
            End Get
            Set
                txtGender.Text = Value
            End Set
        End Property

        Public Property Age As String Implements IInvMedNotesView.Age
            Get
                Return txtAge.Text
            End Get
            Set
                txtAge.Text = Value
            End Set
        End Property

        Public Property DoctorName As String Implements IInvMedNotesView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set
                txtDoctorName.Text = Value
            End Set
        End Property

        Public Property InvoiceNo As Integer Implements IInvMedNotesView.InvoiceNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtInvoiceNo.Text)
            End Get
            Set
                txtInvoiceNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Nationality As String Implements IInvMedNotesView.Nationality
            Get
                Return txtNationality.Text
            End Get
            Set
                txtNationality.Text = Value
            End Set
        End Property

        Public Property MRN As Integer Implements IInvMedNotesView.MRN
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtMRN.Text)
            End Get
            Set
                txtMRN.Text = Convert.ToString(Value)
            End Set
        End Property

        Private Sub BindInvMedNotesDisplay()
            SuspendLayout()
            bsInvMedNotesDetails.DataSource = Nothing
            DataGridViewInvMedNotesDetails.Refresh()
            bsInvMedNotesDetails.DataSource = InvMedNotesDetails
            bsInvMedNotesDetails.AllowNew = True
            With DataGridViewInvMedNotesDetails
                .AutoGenerateColumns = False
                .DataSource = bsInvMedNotesDetails
                dgvSeq.DisplayOnly = True
                dgvItemCode.DisplayOnly = True
                dgvItemName.DisplayOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub btnRefresh_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRefresh.ClickButtonArea
            RaiseEvent InvMedNotesRequested(InvoiceNo)
        End Sub

        Private Sub InvMedNotesCollectionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent InvMedNotesRequested(InvoiceNo)
            'dgvClinical.ThreeState = True
            ''dgvAge.DisplayOnly = True
            'For Each col In DataGridViewInvMedNotesDetails.Columns
            '    Dim headerCell As DataGridViewColumnHeaderCell = col.HeaderCell
            '    headerCell.ToolTipText = col.HeaderText
            'Next
        End Sub

        Private Sub dataGridView1_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs)
            'For Each myRow As DataGridViewRow In DataGridViewInvMedNotesDetails.Rows
            '    If myRow.Cells("dgvFileType").Value = "Old" Then
            '        myRow.DefaultCellStyle.ForeColor = Color.Coral
            '    Else
            '        myRow.DefaultCellStyle.ForeColor = Color.DarkGreen
            '    End If
            '    myRow.DefaultCellStyle.BackColor = Color.White
            'Next
        End Sub

        Private Sub txtInvoiceNo_Validated(sender As Object, e As EventArgs) Handles txtInvoiceNo.Validated
            RaiseEvent InvMedNotesRequested(InvoiceNo)
        End Sub

        Private Sub DataGridView_CellClick(sender As Object, e As DataGridViewCellEventArgs)
            'With DataGridViewInvMedNotes
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

        Private Sub DataGridViewInvMedNotesDetails_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvMedNotesDetails.CellEndEdit
            'Dim editedNote As String = DirectCast(sender, System.Windows.Forms.DataGridView).CurrentCell.EditedFormattedValue
            RaiseEvent InvMedNotesChanged(bsInvMedNotesDetails)
        End Sub

        'Private Sub CheckBoxValueChanged() Handles DataGridViewInvMedNotesDetails.CellValueChanged
        '    With DataGridViewInvMedNotesDetails
        '        If TypeOf .CurrentCell Is DataGridViewCheckBoxCell Then
        '            RaiseEvent InvMedNotesChanged(bsInvMedNotesDetails)
        '        End If
        '    End With
        'End Sub

        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvMedNotesDetails.CellEndEdit
            ProcessCellEndEdit(DataGridViewInvMedNotesDetails, bsInvMedNotesDetails)
        End Sub

        Private Sub Grid_OnCellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridViewInvMedNotesDetails.CellBeginEdit
            With DataGridViewInvMedNotesDetails.CurrentCell
                Dim cColumnName = .OwningColumn.Name.ToLower()
                If cColumnName = $"dgvpregnancy" Then
                    If bsInvMedNotesDetails.Current.Gender = "M" Then
                        Beep()
                        e.Cancel = True
                    End If
                End If
                If DataGridViewInvMedNotesDetails.CurrentCell.OwningColumn.CellType.Name = "DataGridViewCheckBoxCell" Then
                    DataGridViewInvMedNotesDetails.EndEdit()
                End If
            End With
        End Sub

    End Class

End Namespace