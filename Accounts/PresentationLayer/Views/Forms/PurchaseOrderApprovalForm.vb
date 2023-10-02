Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Public Class PurchaseOrderApprovalEntry
    Implements IPurchaseOrderApprovalView

    Private _PurchaseOrderRequests As New List(Of PurchaseOrder)

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Fields"

    Public Property PurchaseOrders As List(Of PurchaseOrder) Implements IPurchaseOrderApprovalView.PurchaseOrders
        Get
            Return _PurchaseOrderRequests
        End Get
        Set(value As List(Of PurchaseOrder))
            _PurchaseOrderRequests = value
            BindPurchaseOrderList()
        End Set
    End Property

#End Region

    Public Sub BindPurchaseOrderList()
        SuspendLayout()
        bsPurchaseOrderRequest.DataSource = Nothing
        DataGridViewPurchaseOrder.Refresh()
        bsPurchaseOrderRequest.DataSource = _PurchaseOrderRequests
        bsPurchaseOrderRequest.AllowNew = True
        With DataGridViewPurchaseOrder
            .AutoGenerateColumns = False
            .DataSource = bsPurchaseOrderRequest
        End With
        With DataGridViewPurchaseOrder.Columns

        End With
        ResumeLayout()
    End Sub

    'Private Sub PurchaseOrderApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    DataGridViewPurchaseOrder.Refresh()
    '    If PurchaseOrderApprovalItems.Count() = 0 Then
    '        Messaging.Show(True, "MsgNoLeavesToApprove")
    '    Else
    '        BindPurchaseOrderList()
    '    End If
    '    btnEdit.Visible = False
    'End Sub

    'Private Sub PurchaseOrderApproval_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
    '    bsPurchaseOrderRequest.ResetBindings(True)
    '    'PublishClickedButton(ButtonClicked.Edit)
    '    'cboApprovedBy.SelectedValue = GlobalVariables.UserIdNo
    '    'dtpDateCreated.Value = Now()
    'End Sub

    Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewPurchaseOrder.CellEndEdit
        ProcessCellEndEdit(DataGridViewPurchaseOrder, bsPurchaseOrderRequest)
        bsPurchaseOrderRequest.ResetBindings(False)
    End Sub

    Private Sub CheckBoxValueChanged() Handles DataGridViewPurchaseOrder.CellValueChanged
        If TypeOf DataGridViewPurchaseOrder.CurrentCell Is DataGridViewCheckBoxCell Then
            If DataGridViewPurchaseOrder.CurrentCell.OwningColumn.Name = "dgvApprove" Then
                DataGridViewPurchaseOrder.CurrentRow.Cells("dgvDisapprove").Value = False
            ElseIf DataGridViewPurchaseOrder.CurrentCell.OwningColumn.Name = "dgvDisapprove" Then
                DataGridViewPurchaseOrder.CurrentRow.Cells("dgvApprove").Value = False
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