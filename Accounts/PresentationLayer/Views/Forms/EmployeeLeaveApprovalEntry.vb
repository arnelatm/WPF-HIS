Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Public Class EmployeeLeaveApprovalEntry
    Implements IEmployeeLeaveApprovalView

    Private _employeeLeaveApprovalItems As New List(Of EmployeeLeaveApprovalItemView)

    Public Event ApprovalCheckedEvent(sender As Object) Implements IEmployeeLeaveApprovalView.ApprovalCheckedEvent

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub


    Public Property EmployeeList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.EmployeeList

    Public Property LeaveList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.LeaveList

    Public Property LeaveStatusList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.LeaveStatusList
    Public Property ApprovalStatusList As List(Of Lookup.LookupData) Implements IEmployeeLeaveApprovalView.ApprovalStatusList

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
            Return cboApprovedBy.GetValue()
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
            BindEmployeeLeaveList()
        End Set
    End Property

#End Region

    Public Sub BindEmployeeLeaveList()
        SuspendLayout()
        bsEmployeeLeave.DataSource = Nothing
        DataGridViewEmployeeLeave.ShowInsertColumnWhenEditing = False
        DataGridViewEmployeeLeave.Refresh()
        bsEmployeeLeave.DataSource = EmployeeLeaveApprovalItems
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
            dgvDateCreated.DisplayOnly = True
            dgvApprove.DisplayOnly = False
            dgvFullDay.DisplayOnly = True
            dgvEndDate.DisplayOnly = True
            dgvLeaveReason.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
            dgvStartDate.DisplayOnly = True
            dgvFullDay.DisplayOnly = True
            dgvEmployeeLeaveIdNo.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    'Private Sub EmployeeLeaveApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    DataGridViewEmployeeLeave.Refresh()
    '    If EmployeeLeaveApprovalItems.Count() = 0 Then
    '        Messaging.Show(True, "MsgNoLeavesToApprove")
    '    Else
    '        BindEmployeeLeaveList()
    '    End If
    '    btnEdit.Visible = False
    'End Sub

    'Private Sub EmployeeLeaveApproval_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    bsEmployeeLeave.ResetBindings(True)
    '    'PublishClickedButton(ButtonClicked.Edit)
    '    'cboApprovedBy.SelectedValue = GlobalVariables.UserIdNo
    '    'dtpDateCreated.Value = Now()
    'End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellEndEdit
        ProcessCellEndEdit(DataGridViewEmployeeLeave, bsEmployeeLeave)
        bsEmployeeLeave.ResetBindings(False)
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

    Private Sub CheckBoxValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellValueChanged

    End Sub
End Class