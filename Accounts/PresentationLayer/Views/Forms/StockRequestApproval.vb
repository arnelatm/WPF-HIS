Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Public Class StockRequestApproval
    Implements IStockRequestApprovalView

    Private _StockRequestApprovalItems As New List(Of StockRequestApprovalItemView)

    Public Event ApprovalCheckedEvent(sender As Object) Implements IStockRequestApprovalView.ApprovalCheckedEvent

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Property EmployeeList As List(Of Lookup.LookupData) Implements IStockRequestApprovalView.EmployeeList

    Public Property LeaveList As List(Of Lookup.LookupData) Implements IStockRequestApprovalView.LeaveList

    Public Property LeaveStatusList As List(Of Lookup.LookupData) Implements IStockRequestApprovalView.LeaveStatusList
    Public Property ApprovalStatusList As List(Of Lookup.LookupData) Implements IStockRequestApprovalView.ApprovalStatusList

#Region "Fields"

    Public Property IdNo As Int32 Implements IStockRequestApprovalView.IdNo
        Get
            Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
        End Get
        Set
            txtIdNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property ApprovedBy As Integer Implements IStockRequestApprovalView.ApprovedBy
        Get
            Return cboApprovedBy.GetValue()
        End Get
        Set
            cboApprovedBy.SetValue(Value)
        End Set
    End Property

    Public Property DateCreated As DateTime? Implements IStockRequestApprovalView.DateCreated
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

    Public Property StockRequestApprovalItems As List(Of StockRequestApprovalItemView) Implements IStockRequestApprovalView.StockRequestApprovalItems
        Get
            Return _StockRequestApprovalItems
        End Get
        Set
            _StockRequestApprovalItems = Value
            BindStockRequestList()
        End Set
    End Property

#End Region

    Public Sub BindStockRequestList()
        SuspendLayout()
        bsStockRequest.DataSource = Nothing
        DataGridViewStockRequest.Refresh()
        bsStockRequest.DataSource = StockRequestApprovalItems
        bsStockRequest.AllowNew = True
        With DataGridViewStockRequest
            .AutoGenerateColumns = False
            .DataSource = bsStockRequest
        End With
        With DataGridViewStockRequest.Columns
            dgvEmployeeIdNo.DisplayOnly = True
            dgvEmployeeIdNo.DataSource = EmployeeList
            dgvEmployeeIdNo.DisplayMember = "Name"
            dgvEmployeeIdNo.ValueMember = "IdNo"
            dgvEmployeeIdNo.DisplayStyleForCurrentCellOnly = True
            dgvLeaveStatus.DisplayOnly = True
            dgvLeaveStatus.DataSource = LeaveStatusList
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
            dgvStockRequestIdNo.DisplayOnly = True
        End With
        ResumeLayout()
    End Sub

    'Private Sub StockRequestApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    DataGridViewStockRequest.Refresh()
    '    If StockRequestApprovalItems.Count() = 0 Then
    '        Messaging.Show(True, "MsgNoLeavesToApprove")
    '    Else
    '        BindStockRequestList()
    '    End If
    '    btnEdit.Visible = False
    'End Sub

    'Private Sub StockRequestApproval_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    bsStockRequest.ResetBindings(True)
    '    'PublishClickedButton(ButtonClicked.Edit)
    '    'cboApprovedBy.SelectedValue = GlobalVariables.UserIdNo
    '    'dtpDateCreated.Value = Now()
    'End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewStockRequest.CellEndEdit
        ProcessCellEndEdit(DataGridViewStockRequest, bsStockRequest)
        bsStockRequest.ResetBindings(False)
    End Sub

    Private Sub CheckBoxValueChanged() Handles DataGridViewStockRequest.CellValueChanged
        If TypeOf DataGridViewStockRequest.CurrentCell Is DataGridViewCheckBoxCell Then
            If DataGridViewStockRequest.CurrentCell.OwningColumn.Name = "dgvApprove" Then
                DataGridViewStockRequest.CurrentRow.Cells("dgvDisapprove").Value = False
            ElseIf DataGridViewStockRequest.CurrentCell.OwningColumn.Name = "dgvDisapprove" Then
                DataGridViewStockRequest.CurrentRow.Cells("dgvApprove").Value = False
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

    Private Sub DataGridViewStockRequest_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewStockRequest.CellContentClick

    End Sub
End Class