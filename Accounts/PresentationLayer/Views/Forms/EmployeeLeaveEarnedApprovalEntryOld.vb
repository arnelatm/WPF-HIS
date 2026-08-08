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
            RunOrDeferViewDataBinding(AddressOf BindEmployeeLeaveEarnedList)
        End Set
    End Property

    Public Property UserIsASuperAdministrator As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserIsASuperAdministrator

    Public Property UserIsASupervisor As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserIsASupervisor

    Public Property UserHasHrAccess As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserHasHrAccess

    Public Property UserHasHrManagerAccess As Boolean Implements IEmployeeLeaveEarnedApprovalView.UserHasHrManagerAccess

#End Region

    Public Sub BindEmployeeLeaveEarnedList()
        SuspendLayout()
        bsEmployeeLeaveEarned.DataSource = Nothing
        DataGridViewEmployeeLeaveEarned.Refresh()
        bsEmployeeLeaveEarned.DataSource = EmployeeLeaveEarnedApprovalItems
        bsEmployeeLeaveEarned.AllowNew = True
        With DataGridViewEmployeeLeaveEarned
            .AutoGenerateColumns = False
            .DataSource = bsEmployeeLeaveEarned
        End With
        With DataGridViewEmployeeLeaveEarned.Columns
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
            dgvApproved.DisplayOnly = False
            dgvApproved.ReadOnly = False
            dgvDisapproved.DisplayOnly = False
            dgvDisapproved.ReadOnly = False
            dgvEndDate.DisplayOnly = True
            dgvReason.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvEmployeeLeaveEarnedIdNo.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeaveEarned.CellEndEdit
        ProcessCellEndEdit(DataGridViewEmployeeLeaveEarned, bsEmployeeLeaveEarned)
        bsEmployeeLeaveEarned.ResetBindings(False)
    End Sub

    Private Sub CheckBoxValueChanged() Handles DataGridViewEmployeeLeaveEarned.CellValueChanged
        If TypeOf DataGridViewEmployeeLeaveEarned.CurrentCell Is DataGridViewCheckBoxCell Then
            If DataGridViewEmployeeLeaveEarned.CurrentCell.OwningColumn.Name = "dgvApproved" Then
                DataGridViewEmployeeLeaveEarned.CurrentRow.Cells("dgvDisapproved").Value = False
            ElseIf DataGridViewEmployeeLeaveEarned.CurrentCell.OwningColumn.Name = "dgvDisapproved" Then
                DataGridViewEmployeeLeaveEarned.CurrentRow.Cells("dgvApproved").Value = False
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
        bsEmployeeLeaveEarned.ResetBindings(False)
        btnAdd.PerformClick()
    End Sub

End Class
