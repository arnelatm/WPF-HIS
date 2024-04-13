Imports System.Windows.Controls
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
            dgvDateCreated.DisplayOnly = True
            dgvEmployeeIdNo.DataSource = EmployeeList
            dgvEmployeeIdNo.DisplayMember = "Name"
            dgvEmployeeIdNo.ValueMember = "IdNo"
            dgvLeaveIdNo.DataSource = LeaveList
            dgvLeaveIdNo.DisplayMember = "Name"
            dgvLeaveIdNo.ValueMember = "IdNo"
            dgvLeaveIdNo.DisplayOnly = True
            dgvApproved.DisplayOnly = False
            dgvDisapproved.DisplayOnly = False
            dgvEndDate.DisplayOnly = True
            dgvReason.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvEmployeeLeaveEarnedIdNo.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    Private Sub CheckBoxValueChanged() Handles DataGridViewEmployeeLeave.CellValueChanged
        With DataGridViewEmployeeLeave
            If TypeOf .CurrentCell Is Libraries.CBaseControlsLibrary.CDgvCheckboxCell Then
                If .CurrentCell.OwningColumn.Name.ToLower = "dgvapproved" Then
                    If .CurrentCell.Value Then
                        .CurrentRow.Cells("dgvDisapproved").Value = False
                    End If
                ElseIf .CurrentCell.OwningColumn.Name.ToLower = "dgvdisapproved" Then
                    If .CurrentCell.Value Then
                        .CurrentRow.Cells("dgvApproved").Value = False
                    End If
                End If
            End If
        End With

    End Sub

    Protected Overrides Sub CreateMainFieldsDictionary()
        MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
            {"IdNo", txtIdNo},
            {"DateCreated", dtpDateCreated},
            {"ApprovedBy", cboApprovedBy}
            }
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

End Class