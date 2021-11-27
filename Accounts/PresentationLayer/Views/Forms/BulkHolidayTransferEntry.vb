Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.BusinessLayer
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Public Class BulkHolidayTransferEntry
    Implements IHolidayTransferView

    Private _employeeList As New List(Of GenericData)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Fields"

    Public Property IdNo As Int32 Implements IHolidayTransferView.IdNo
        Get
            Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
        End Get
        Set
            txtIdNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property AppliedBy As Integer Implements IHolidayTransferView.AppliedBy
        Get
            Return cboAppliedBy.GetValue()
        End Get
        Set
            cboAppliedBy.SetValue(Value)
        End Set
    End Property

    Public Property DateCreated As DateTime? Implements IHolidayTransferView.DateCreated
        Get
            Return dtpDateCreated.Value
        End Get
        Set
            If Value.HasValue Then
                dtpDateCreated.Value = Value
            Else
                dtpDateCreated.Value = Date.Now()
            End If
        End Set
    End Property

    Private Property EmployeeList As List(Of GenericData) Implements IHolidayTransferView.EmployeeList
        Get
            Return _employeeList
        End Get
        Set
            _employeeList = Value
            BindEmployeeList()
        End Set
    End Property

    Public Property HolidayIdNo As Integer Implements IHolidayTransferView.HolidayIdNo
        Get
            Return cboHolidayIdNo.GetValue()
        End Get
        Set(value As Integer)
            cboHolidayIdNo.SetValue(value)
        End Set
    End Property

#End Region

    Private Sub BindEmployeeList()
        SuspendLayout()
        bsEmployeeList.DataSource = Nothing
        DataGridViewEmployeeLeave.ShowInsertColumnWhenEditing = False
        DataGridViewEmployeeLeave.Refresh()
        bsEmployeeList.DataSource = EmployeeList
        bsEmployeeList.AllowNew = True
        With DataGridViewEmployeeLeave
            .AutoGenerateColumns = False
            .DataSource = bsEmployeeList
            .RemoveInsertColumn()
        End With
        With DataGridViewEmployeeLeave.Columns
            dgvEmployeeIdNo.DisplayOnly = True
            dgvEmployeeIdNo.DataSource = EmployeeList
            dgvEmployeeIdNo.DisplayMember = "Name"
            dgvEmployeeIdNo.ValueMember = "IdNo"
            dgvEmployeeIdNo.DisplayStyleForCurrentCellOnly = True
            dgvLeaveIdNo.DataSource = ""
            dgvLeaveIdNo.DisplayMember = "Name"
            dgvLeaveIdNo.ValueMember = "IdNo"
            dgvLeaveIdNo.DisplayStyleForCurrentCellOnly = True
            dgvLeaveIdNo.DisplayOnly = True
            dgvLeaveStatus.DisplayOnly = True
            dgvLeaveStatus.DataSource = ""
            dgvLeaveStatus.ValueMember = "Code"
            dgvLeaveStatus.DisplayMember = "Name"
            dgvLeaveStatus.DisplayStyleForCurrentCellOnly = True
            dgvApprove.DisplayOnly = False
            dgvFullDay.DisplayOnly = True
            dgvEndDate.DisplayOnly = True
            dgvLeaveReason.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    Private Sub HolidayTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewEmployeeLeave.Refresh()
        If EmployeeList.Count() <> 0 Then
            BindEmployeeList()
        End If
        btnEdit.Visible = False
    End Sub

    Private Sub HolidayTransfer_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        bsEmployeeList.ResetBindings(True)
        PublishClickedButton(ButtonClicked.Edit)
        cboAppliedBy.SelectedValue = GlobalVariables.UserIdNo
        dtpDateCreated.Value = Now()
    End Sub

    'Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellEndEdit
    '    ProcessCellEndEdit(DataGridViewEmployeeLeave, bsEmployeeLeave)
    '    bsEmployeeLeaveeesf.ResetBindings(False)
    'End Sub

    Private Sub CheckBoxValueChanged() Handles DataGridViewEmployeeLeave.CellValueChanged
        If TypeOf DataGridViewEmployeeLeave.CurrentCell Is DataGridViewCheckBoxCell Then
            If DataGridViewEmployeeLeave.CurrentCell.OwningColumn.Name = "dgvApprove" Then
                DataGridViewEmployeeLeave.CurrentRow.Cells("dgvDisapprove").Value = False
            ElseIf DataGridViewEmployeeLeave.CurrentCell.OwningColumn.Name = "dgvDisapprove" Then
                DataGridViewEmployeeLeave.CurrentRow.Cells("dgvApprove").Value = False
            End If
        End If
    End Sub

    Protected Overrides Sub CreateMainFieldsDictionary()
        MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
            {"IdNo", txtIdNo},
            {"DateCreated", dtpDateCreated},
            {"AppliedBy", cboAppliedBy},
            {"EmployeeIdNo", cboAppliedBy},
            {"HolidayIdNo", cboHolidayIdNo}
            }
    End Sub

End Class