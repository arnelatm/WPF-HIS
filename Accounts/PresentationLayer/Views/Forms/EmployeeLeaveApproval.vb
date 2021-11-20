Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.PresentationLayer.Events

Public Class EmployeeLeaveApproval
    Implements IEmployeeLeaveApprovalView

    Private _employeeLeaveList As New List(Of IEmployeeLeaveView)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property EmployeeLeaveList As List(Of IEmployeeLeaveView) Implements IEmployeeLeaveApprovalView.EmployeeLeaveList
        Get
            Return _employeeLeaveList
        End Get
        Set
            _employeeLeaveList = Value
            BindEmployeeLeaveList()
        End Set
    End Property

    Public Property EmployeeList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.EmployeeList

    Public Property LeaveList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.LeaveList

    Public Property LeaveStatusList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.LeaveStatusList
    Public Property ApprovalStatusList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.ApprovalStatusList

    Private Sub BindEmployeeLeaveList()
        SuspendLayout()
        bsEmployeeLeave.DataSource = Nothing
        DataGridViewEmployeeLeave.ShowInsertColumnWhenEditing = False
        DataGridViewEmployeeLeave.Refresh()
        bsEmployeeLeave.DataSource = EmployeeLeaveList
        bsEmployeeLeave.AllowNew = True
        With DataGridViewEmployeeLeave
            .AutoGenerateColumns = False
            .DataSource = bsEmployeeLeave
            .RemoveInsertColumn()
        End With
        With DataGridViewEmployeeLeave.Columns
            dgvEmployeeIdNo.DisplayOnly = True
            dgvEmployeeIdNo.DataSource = EmployeeList
            dgvEmployeeIdNo.DisplayMember = "Name"
            dgvEmployeeIdNo.ValueMember = "IdNo"
            dgvEmployeeIdNo.DisplayStyleForCurrentCellOnly = True
            dgvLeaveIdNo.DataSource = LeaveList
            dgvLeaveIdNo.DisplayMember = "Name"
            dgvLeaveIdNo.ValueMember = "IdNo"
            dgvLeaveIdNo.DisplayStyleForCurrentCellOnly = True
            dgvLeaveIdNo.DisplayOnly = True
            dgvLeaveStatus.DisplayOnly = True
            dgvLeaveStatus.DataSource = LeaveStatusList
            dgvLeaveStatus.ValueMember = "Code"
            dgvLeaveStatus.DisplayMember = "Name"
            dgvLeaveStatus.DisplayStyleForCurrentCellOnly = True
            dgvApproval.DisplayOnly = False
            dgvApproval.DataSource = ApprovalStatusList
            dgvApproval.ValueMember = "Code"
            dgvApproval.DisplayMember = "Name"
            dgvApproval.DisplayStyleForCurrentCellOnly = True
            dgvFullDay.DisplayOnly = True
            dgvEndDate.DisplayOnly = True
            dgvLeaveReason.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    Private Sub EmployeeLeaveApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridViewEmployeeLeave.Refresh()
        BindEmployeeLeaveList()
        btnEdit.Visible = False
    End Sub

    Private Sub EmployeeLeaveApproval_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        bsEmployeeLeave.ResetBindings(True)
        PublishClickedButton(ButtonClicked.Edit)
    End Sub

    Protected Overrides Sub CreateMainFieldsDictionary()
        MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
            {"EmployeeList", EmployeeList},
            {"LeaveList", LeaveList},
            {"LeaveStatus", LeaveStatusList}
            }
    End Sub

End Class