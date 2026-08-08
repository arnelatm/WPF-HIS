Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class EmployeeLeaveApprovalEntry
    Implements IEmployeeLeaveApprovalView

    Private _employeeLeaveApprovalItems As New List(Of EmployeeLeaveApprovalItemView)

    Public Event ApprovalCheckedEvent(sender As Object) Implements IEmployeeLeaveApprovalView.ApprovalCheckedEvent

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property EmployeeList As DataTable Implements IEmployeeLeaveApprovalView.EmployeeList

    Public Property LeaveList As DataTable Implements IEmployeeLeaveApprovalView.LeaveList

    Public Property LeaveStatusList As DataTable Implements IEmployeeLeaveApprovalView.StatusList
    Public Property ApprovalStatusList As DataTable Implements IEmployeeLeaveApprovalView.ApprovalStatusList


#Region "Fields"

    Public Property IdNo As Int32 Implements IEmployeeLeaveApprovalView.IdNo
        Get
            Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
        End Get
        Set
            txtIdNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property ApprovedBy As Integer Implements IEmployeeLeaveApprovalView.ApprovedBy
        Get
            Return cboApprovedBy.GetValue(Of Integer)
        End Get
        Set
            cboApprovedBy.SetValue(Value)
        End Set
    End Property

    Public Property DateCreated As DateTime? Implements IEmployeeLeaveApprovalView.DateCreated
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

    Public Property EmployeeLeaveApprovalItems As List(Of EmployeeLeaveApprovalItemView) Implements IEmployeeLeaveApprovalView.EmployeeLeaveApprovalItems
        Get
            Return _employeeLeaveApprovalItems
        End Get
        Set
            _employeeLeaveApprovalItems = Value
            RunOrDeferViewDataBinding(AddressOf BindEmployeeLeaveList)
        End Set
    End Property

    Public Property UserIsASuperAdministrator As Boolean Implements IEmployeeLeaveApprovalView.UserIsASuperAdministrator
    Public Property UserIsASupervisor As Boolean Implements IEmployeeLeaveApprovalView.UserIsASupervisor
    Public Property UserHasHrAccess As Boolean Implements IEmployeeLeaveApprovalView.UserHasHrAccess
    Public Property UserHasHrManagerAccess As Boolean Implements IEmployeeLeaveApprovalView.UserHasHrManagerAccess

#End Region

    Public Sub BindEmployeeLeaveList()
        SuspendLayout()
        bsEmployeeLeave.DataSource = Nothing
        DataGridViewEmployeeLeave.Refresh()
        bsEmployeeLeave.DataSource = EmployeeLeaveApprovalItems
        bsEmployeeLeave.AllowNew = True
        With DataGridViewEmployeeLeave
            .AutoGenerateColumns = False
            .DataSource = bsEmployeeLeave
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
            dgvStatus.DisplayOnly = True
            dgvStatus.DataSource = LeaveStatusList
            dgvStatus.ValueMember = "Code"
            dgvStatus.DisplayMember = "Name"
            dgvStatus.DisplayStyleForCurrentCellOnly = True
            dgvApproved.DisplayOnly = False
            dgvDisapproved.DisplayOnly = False
            dgvDisapproved.ReadOnly = False
            dgvFullDay.DisplayOnly = True
            dgvEndDate.DisplayOnly = True
            dgvReason.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
            dgvEmployeeLeaveIdNo.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellEndEdit
        ProcessCellEndEdit(DataGridViewEmployeeLeave, bsEmployeeLeave)
        bsEmployeeLeave.ResetBindings(False)
    End Sub

    Private Sub CheckBoxValueChanged() Handles DataGridViewEmployeeLeave.CellValueChanged
        If TypeOf DataGridViewEmployeeLeave.CurrentCell Is DataGridViewCheckBoxCell Then
            If DataGridViewEmployeeLeave.CurrentCell.OwningColumn.Name = "dgvApproved" Then
                DataGridViewEmployeeLeave.CurrentRow.Cells("dgvDisapproved").Value = False
            ElseIf DataGridViewEmployeeLeave.CurrentCell.OwningColumn.Name = "dgvDisapproved" Then
                DataGridViewEmployeeLeave.CurrentRow.Cells("dgvApproved").Value = False
            End If
        End If
    End Sub

    Protected Overrides Sub CreateMainFieldsDictionary()
        MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
            {"IdNo", txtIdNo},
            {"DateCreated", dtpDateCreated},
            {"ApprovedBy", cboApprovedBy}
            }
    End Sub
    Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
        If AddingMode Then
            dgvApproved.Visible = True
            dgvDisapproved.Visible = True
            dgvApproved.ReadOnly = False
            dgvDisapproved.ReadOnly = False
            dgvApproved.DisplayOnly = False
            dgvDisapproved.DisplayOnly = False
        Else
            dgvApproved.Visible = False
            dgvDisapproved.Visible = False
        End If
    End Sub

    Private Sub EmployeeLeaveApprovalEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UserIsASuperAdministrator() Then
            cboApprovedBy.DisplayOnly = False
        End If
        btnAdd.PerformClick()
    End Sub

    Private Sub OnAfterSave() Handles MyBase.AfterSave
        bsEmployeeLeave.ResetBindings(False)
        btnAdd.PerformClick()
    End Sub

End Class
