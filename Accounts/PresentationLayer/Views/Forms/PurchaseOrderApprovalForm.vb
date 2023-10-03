Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class PurchaseOrderApprovalForm
        Implements IPurchaseOrderApprovalView

        Private _unpostedPurchaseOrders As New List(Of IPurchaseOrderView)
        Private _PurchaseOrderDetails As List(Of PurchaseOrderDetailView)

        Public Event RowChanged(productIdNo As Int32) Implements IPurchaseOrderApprovalView.RowChanged
        Public Event FormLoaded() Implements IPurchaseOrderApprovalView.FormLoaded
        Public Event TransferRequestClicked(invTransIdNo As Int32) Implements IPurchaseOrderApprovalView.TransferRequestClicked
        Public Event SupplyQuantityClicked(invTransIdNo As Int32) Implements IPurchaseOrderApprovalView.SupplyQuantityClicked
        Public Property WarehouseList As DataTable Implements IPurchaseOrderApprovalView.WarehouseList
        Public Property UserList As DataTable Implements IPurchaseOrderApprovalView.UserList
        Public Property UnitList As DataTable Implements IPurchaseOrderApprovalView.UnitList

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            SingleData = True
            QueryOnly = True
        End Sub

        Private Sub AddDgColumn(dgvColumnName As DataGridViewImageColumn, dgvName As String, caption As String)
            With DataGridViewInvTransactionRequests
                .Columns.Insert(.Columns.Count, dgvColumnName)
                dgvColumnName.Image = imgList.Images(0)
                dgvColumnName.Width = 35
                dgvColumnName.Name = dgvName
                dgvColumnName.HeaderText = Messaging.TranslateCaption(caption)
            End With
        End Sub

        Public Property WarehouseIdNo As Short Implements IPurchaseOrderApprovalView.WarehouseIdNo
            Get
                Return txtWarehouseIdNo.GetValue(Of Short)
            End Get
            Set(value As Short)
                txtWarehouseIdNo.SetValue(value)
            End Set
        End Property

        Public Property UnpostedPurchaseOrders As List(Of IPurchaseOrderView) Implements IPurchaseOrderApprovalView.UnpostedPurchaseOrders
            Get
                Return _unpostedPurchaseOrders
            End Get
            Set
                _unpostedPurchaseOrders = Value
                BindPurchaseOrderApproval()
            End Set
        End Property

        Private Sub BindPurchaseOrderApproval()
            SuspendLayout()
            bsPurchaseOrders.DataSource = Nothing
            bsPurchaseOrders.DataSource = UnpostedPurchaseOrders
            bsPurchaseOrders.AllowNew = False
            With DataGridViewInvTransactionRequests
                .AutoGenerateColumns = False
                .DataSource = bsPurchaseOrders
                dgvUserIdNo.DataSource = UserList
                dgvUserIdNo.DisplayMember = "Name"
                dgvUserIdNo.ValueMember = "IdNo"
            End With
            ResumeLayout()
        End Sub

        Public Property PurchaseOrderDetails As List(Of PurchaseOrderDetailView) Implements IPurchaseOrderApprovalView.PurchaseOrderDetails
            Get
                Return _PurchaseOrderDetails
            End Get
            Set
                _PurchaseOrderDetails = Value
                BindInvTransactionDetail()
            End Set
        End Property

        'Public Property PurchaseOrders As List(Of PurchaseOrder) Implements IPurchaseOrderApprovalView.PurchaseOrders
        '    Get
        '        Throw New NotImplementedException()
        '    End Get
        '    Set(value As List(Of PurchaseOrder))
        '        Throw New NotImplementedException()
        '    End Set
        'End Property

        Private Sub BindInvTransactionDetail()
            SuspendLayout()
            bsPurchaseOrderDetails.DataSource = Nothing
            DataGridViewInvTransItems.Refresh()
            bsPurchaseOrderDetails.DataSource = PurchaseOrderDetails
            bsPurchaseOrderDetails.AllowNew = False
            ResumeLayout()
        End Sub

        Private Sub DgvInvTransactionRequest_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionRequests.RowEnter
            Dim dgvRow As DataGridViewRow = DataGridViewInvTransactionRequests.Rows(e.RowIndex)
            Dim invTranIdNo As Int32 = dgvRow.Cells("dgvIdNo").Value
            RaiseEvent RowChanged(invTranIdNo)
            bsPurchaseOrderDetails.ResetBindings(False)
            lblRequestedItems.Text = Messaging.TranslateCaption("Requested Items for ") + dgvRow.Cells("dgvReferenceNo").Value
        End Sub

        Private Sub PurchaseOrderApprovalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent FormLoaded()
            DataGridViewInvTransactionRequests.DisplayOnly = True
            'DataGridViewInvTransItems.DisplayOnly = True
            dgvQtyApproved.DisplayOnly = False
            dgvQuantity.DisplayOnly = True
            dgvIdNo.DisplayOnly = True
            dgvNetAmount.DisplayOnly = True
            dgvQtyOnHand.DisplayOnly = True
            dgvQtySupplied.DisplayOnly = True
            dgvUnitCost.DisplayOnly = True
            dgvUnitIdNo.DisplayOnly = True
            dgvUnitName.DisplayOnly = True
            dgvProductName.DisplayOnly = True
            dgvProductCode.DisplayOnly = True
            dgvAmount.DisplayOnly = True
            dgvQtyApproved.ReadOnly = False
            dgvQtyApproved.EditingMode = True
            dgvQtySupplied.SetFormat(12, 4)
            dgvQtyOnHand.SetFormat(12, 4)

        End Sub


        ' Changes how cells are displayed depending on their columns and values.
        Private Sub dgvPurDetailsFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewInvTransItems.CellFormatting
            'If sender.CurrentRow IsNot Nothing AndAlso e.ColumnIndex > 0 Then
            If e.ColumnIndex > 0 AndAlso sender.CurrentRow() IsNot Nothing Then
                If sender.Columns(e.ColumnIndex).Name.Equals("dgvQtyOnHand") Then
                    Dim x = DirectCast(sender, DataGridView).Rows(e.RowIndex)
                    If x IsNot Nothing Then
                        If e.Value < x.Cells("dgvQuantity").Value Then
                            e.CellStyle.BackColor = Color.Red
                        End If
                    End If
                End If

                'If sender.currentrow().cells("dgvQtyOnHand").Value < sender.currentrow().cells("dgvQuantity").Value Then
                '    e.CellStyle.BackColor = Color.Red
                'End If
            End If

        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            Dim dgvRow As DataGridViewRow = DataGridViewInvTransactionRequests.CurrentRow
            Dim invTranIdNo As Int32 = dgvRow.Cells("dgvIdNo").Value
            RaiseEvent TransferRequestClicked(invTranIdNo)
        End Sub

        Private Sub btnSupplyQuantity_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnSupplyQuantity.ClickButtonArea
            Dim dgvRow As DataGridViewRow = DataGridViewInvTransactionRequests.CurrentRow
            Dim invTranIdNo As Int32 = dgvRow.Cells("dgvIdNo").Value
            RaiseEvent SupplyQuantityClicked(invTranIdNo)
            bsPurchaseOrderDetails.ResetBindings(False)
        End Sub


        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransItems.CellEndEdit
            ProcessCellEndEdit(sender, bsPurchaseOrderDetails)
            'UpdateTotals()
        End Sub

    End Class

End Namespace