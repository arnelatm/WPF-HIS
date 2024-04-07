Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class EmployeeLeaveEarnedApprovalEntry
    Implements IEmployeeLeaveEarnedApprovalView

    Private _employeeLeaveEarnedApprovalItems As New List(Of EmployeeLeaveEarnedApprovalItemView)

    Public Event ApprovalCheckedEvent(sender As Object) Implements IEmployeeLeaveEarnedApprovalView.ApprovalCheckedEvent

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property EmployeeList As DataTable Implements IEmployeeLeaveEarnedApprovalView.EmployeeList

    Public Property LeaveList As DataTable Implements IEmployeeLeaveEarnedApprovalView.LeaveList


#Region "Fields"

    Public Property IdNo As Int32 Implements IEmployeeLeaveEarnedApprovalView.IdNo
        Get
            Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
        End Get
        Set
            txtIdNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property ApprovedBy As Integer Implements IEmployeeLeaveEarnedApprovalView.ApprovedBy
        Get
            Return cboApprovedBy.GetValue(Of Integer)
        End Get
        Set
            cboApprovedBy.SetValue(Value)
        End Set
    End Property

    Public Property DateCreated As DateTime? Implements IEmployeeLeaveEarnedApprovalView.DateCreated
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

    Public Property EmployeeLeaveEarnedApprovalItems As List(Of EmployeeLeaveEarnedApprovalItemView) Implements IEmployeeLeaveEarnedApprovalView.EmployeeLeaveEarnedApprovalItems
        Get
            Return _employeeLeaveEarnedApprovalItems
        End Get
        Set
            _employeeLeaveEarnedApprovalItems = Value
            BindEmployeeLeaveList()
        End Set
    End Property

    Public Property UserIsASuperAdministrator As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserIsASuperAdministrator
    Public Property UserIsASupervisor As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserIsASupervisor
    Public Property UserHasHrAccess As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserHasHrAccess
    Public Property UserHasHrManagerAccess As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserHasHrManagerAccess

#End Region

    Public Sub BindEmployeeLeaveList()
        SuspendLayout()
        bsEmployeeLeaveEarnedApprovalItem.DataSource = Nothing
        DataGridViewEmployeeLeave.Refresh()
        bsEmployeeLeaveEarnedApprovalItem.DataSource = EmployeeLeaveEarnedApprovalItems
        bsEmployeeLeaveEarnedApprovalItem.AllowNew = True
        With DataGridViewEmployeeLeave
            .AutoGenerateColumns = False
            .DataSource = bsEmployeeLeaveEarnedApprovalItem
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
            dgvApprove.ReadOnly = False
            dgvDisapprove.DisplayOnly = False
            dgvDisapprove.ReadOnly = False
            dgvEndDate.DisplayOnly = True
            dgvReason.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvEmployeeLeaveEarnedIdNo.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellEndEdit
        ProcessCellEndEdit(DataGridViewEmployeeLeave, bsEmployeeLeaveEarnedApprovalItem)
        bsEmployeeLeaveEarnedApprovalItem.ResetBindings(False)
    End Sub

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
            {"ApprovedBy", cboApprovedBy}
            }
    End Sub
    Protected Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
        If AddingMode Then
            dgvApprove.ReadOnly = False
            dgvDisapprove.ReadOnly = False
            dgvDisapprove.DisplayOnly = False
        Else
            dgvApprove.ReadOnly = False
            dgvDisapprove.ReadOnly = False
            dgvDisapprove.DisplayOnly = False
        End If
    End Sub

    Private Sub EmployeeLeaveEarnedApprovalEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If UserIsASuperAdministrator() Then
            cboApprovedBy.DisplayOnly = False
        End If
        btnAdd.PerformClick()
    End Sub

    Private Sub OnAfterSave() Handles MyBase.AfterSave
        bsEmployeeLeaveEarnedApprovalItem.ResetBindings(False)
        btnAdd.PerformClick()
    End Sub

    Private Sub DataGridViewEmployeeLeave_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellContentClick
        If e.ColumnIndex < 0 OrElse e.RowIndex < 0 Then Exit Sub
        Dim x = DataGridViewEmployeeLeave.CurrentCell.Value
        DataGridViewEmployeeLeave.CurrentCell.Value = Not DataGridViewEmployeeLeave.CurrentCell.Value
        DataGridViewEmployeeLeave.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

End Class