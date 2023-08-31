Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Public Class StockRequestApprovalEntry
    Implements IStockRequestApprovalView

    Private _invTransactionRequests As New List(Of InvTransaction)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Fields"

    Public Property StockRequests As List(Of InvTransaction) Implements IStockRequestApprovalView.StockRequests
        Get
            Return _invTransactionRequests
        End Get
        Set(value As List(Of InvTransaction))
            _invTransactionRequests = value
            BindStockRequestList()
        End Set
    End Property

#End Region

    Public Sub BindStockRequestList()
        SuspendLayout()
        bsInvTransactionRequest.DataSource = Nothing
        DataGridViewStockRequest.Refresh()
        bsInvTransactionRequest.DataSource = _invTransactionRequests
        bsInvTransactionRequest.AllowNew = True
        With DataGridViewStockRequest
            .AutoGenerateColumns = False
            .DataSource = bsInvTransactionRequest
        End With
        With DataGridViewStockRequest.Columns

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
    '    bsInvTransactionRequest.ResetBindings(True)
    '    'PublishClickedButton(ButtonClicked.Edit)
    '    'cboApprovedBy.SelectedValue = GlobalVariables.UserIdNo
    '    'dtpDateCreated.Value = Now()
    'End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewStockRequest.CellEndEdit
        ProcessCellEndEdit(DataGridViewStockRequest, bsInvTransactionRequest)
        bsInvTransactionRequest.ResetBindings(False)
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
            {"WarehouseIdNo", cboWarehouseIdNo}
            }
    End Sub

End Class