Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Public Class EmployeeLeaveEarnedApprovalEntry
    Implements IEmployeeLeaveEarnedApprovalView

    Private _EmployeeLeaveEarnedApprovalItems As New List(Of EmployeeLeaveEarnedApprovalItemView)

    Public Event ApprovalCheckedEvent(sender As Object) Implements IEmployeeLeaveEarnedApprovalView.ApprovalCheckedEvent


    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property EmployeeList As DataTable Implements IEmployeeLeaveEarnedApprovalView.EmployeeList

    Public Property LeaveList As DataTable Implements IEmployeeLeaveEarnedApprovalView.LeaveList

    Public Property StatusList As DataTable Implements IEmployeeLeaveEarnedApprovalView.StatusList
    Public Property ApprovalStatusList As DataTable Implements IEmployeeLeaveEarnedApprovalView.ApprovalStatusList


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
            Return _EmployeeLeaveEarnedApprovalItems
        End Get
        Set
            _EmployeeLeaveEarnedApprovalItems = Value
            BindEmployeeLeaveList()
        End Set
    End Property

#End Region

    Public Sub BindEmployeeLeaveList()
        SuspendLayout()
        bsEmployeeLeaveEarned.DataSource = Nothing
        DataGridViewEmployeeLeave.Refresh()
        bsEmployeeLeaveEarned.DataSource = EmployeeLeaveEarnedApprovalItems
        bsEmployeeLeaveEarned.AllowNew = True
        With DataGridViewEmployeeLeave
            .AutoGenerateColumns = False
            .DataSource = bsEmployeeLeaveEarned
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
            dgvStatus.DataSource = StatusList
            dgvStatus.ValueMember = "Code"
            dgvStatus.DisplayMember = "Name"
            dgvStatus.DisplayStyleForCurrentCellOnly = True
            dgvDateCreated.DisplayOnly = True
            dgvApprove.DisplayOnly = False
            dgvEndDate.DisplayOnly = True
            dgvReason.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvEmployeeLeaveIdNo.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    'Private Sub EmployeeLeaveEarnedApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    DataGridViewEmployeeLeave.Refresh()
    '    If EmployeeLeaveEarnedApprovalItems.Count() = 0 Then
    '        Messaging.Show(True, "MsgNoLeavesToApprove")
    '    Else
    '        BindEmployeeLeaveList()
    '    End If
    '    btnEdit.Visible = False
    'End Sub

    'Private Sub EmployeeLeaveEarnedApproval_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    bsEmployeeLeave.ResetBindings(True)
    '    'PublishClickedButton(ButtonClicked.Edit)
    '    'cboApprovedBy.SelectedValue = GlobalVariables.UserIdNo
    '    'dtpDateCreated.Value = Now()
    'End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellEndEdit
        ProcessCellEndEdit(DataGridViewEmployeeLeave, bsEmployeeLeaveEarned)
        bsEmployeeLeaveEarned.ResetBindings(False)
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
            dgvApprove.Visible = True
            dgvDisapprove.Visible = True
        Else
            dgvApprove.Visible = False
            dgvDisapprove.Visible = False
        End If
    End Sub

    Private Sub EmployeeLeaveEarnedApprovalEntry_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        btnEdit.Enabled = False
        btnEdit.Visible = False
        btnDelete.Enabled = False
        btnDelete.Visible = False
    End Sub

    Private Sub EmployeeLeaveEarnedApproval_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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