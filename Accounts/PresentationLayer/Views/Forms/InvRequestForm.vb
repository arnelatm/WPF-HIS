Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class InvRequestForm
        Implements IInvRequestView

        Private _invTransactionRequests As New List(Of IInvTransactionBaseView)
        Private _invRequestDetails As List(Of InvRequestDetailView)
        Public Event WarehouseIdNoChanged() Implements IInvRequestView.WarehouseIdNoChanged
        Public Event RowChanged(productIdNo As Int32) Implements IInvRequestView.RowChanged
        Public Event FormLoaded() Implements IInvRequestView.FormLoaded
        Public Event TransferRequestClicked(invTransIdNo As Int32) Implements IInvRequestView.TransferRequestClicked
        Public Event SupplyQuantityClicked(invTransIdNo As Int32) Implements IInvRequestView.SupplyQuantityClicked
        Public Property WarehouseList As DataTable Implements IInvRequestView.WarehouseList
        Public Property UserList As DataTable Implements IInvRequestView.UserList
        Public Property UnitList As DataTable Implements IInvRequestView.UnitList

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            SingleData = True
            QueryOnly = True
            cboWarehouseSelector.EditingMode = True
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

        Public Property WarehouseSelector As Short Implements IInvRequestView.WarehouseSelector
            Get
                Return cboWarehouseSelector.GetValue(Of Short)
            End Get
            Set(value As Short)
                cboWarehouseSelector.SetValue(value)
                txtWarehouseIdNo.Text = value.ToString()
            End Set
        End Property

        Public Property WarehouseIdNo As Short Implements IInvRequestView.WarehouseIdNo
            Get
                Return txtWarehouseIdNo.GetValue(Of Short)
            End Get
            Set(value As Short)
                txtWarehouseIdNo.SetValue(value)
            End Set
        End Property

        Public Property InvTransactionRequests As List(Of IInvTransactionBaseView) Implements IInvRequestView.InvTransactionRequests
            Get
                Return _invTransactionRequests
            End Get
            Set
                _invTransactionRequests = Value
                BindInvTransactionRequests()
            End Set
        End Property

        Private Sub BindInvTransactionRequests()
            SuspendLayout()
            bsInvTransactionRequest.DataSource = Nothing
            bsInvTransactionRequest.DataSource = InvTransactionRequests
            bsInvTransactionRequest.AllowNew = False
            With DataGridViewInvTransactionRequests
                .AutoGenerateColumns = False
                .DataSource = bsInvTransactionRequest
                dgvUserIdNo.DataSource = UserList
                dgvUserIdNo.DisplayMember = "Name"
                dgvUserIdNo.ValueMember = "IdNo"
                dgvWarehouseToIdNo.DataSource = WarehouseList
                dgvWarehouseToIdNo.DisplayMember = "Name"
                dgvWarehouseToIdNo.ValueMember = "IdNo"
            End With
            ResumeLayout()
        End Sub

        Public Property InvRequestDetails As List(Of InvRequestDetailView) Implements IInvRequestView.InvRequestDetails
            Get
                Return _invRequestDetails
            End Get
            Set
                _invRequestDetails = Value
                BindInvTransactionDetail()
            End Set
        End Property


        Private Sub BindInvTransactionDetail()
            SuspendLayout()
            bsInvTranItems.DataSource = Nothing
            DataGridViewInvTransItems.Refresh()
            bsInvTranItems.DataSource = InvRequestDetails
            bsInvTranItems.AllowNew = False
            ResumeLayout()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"WarehouseIdNo", cboWarehouseSelector}
                }
        End Sub

        Private Sub SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboWarehouseSelector.SelectionChangeCommitted
            WarehouseIdNo = cboWarehouseSelector.SelectedValue
            RaiseEvent WarehouseIdNoChanged()
            bsInvTransactionRequest.ResetBindings(True)
            DataGridViewInvTransactionRequests.Refresh()
        End Sub

        Private Sub DgvInvTransactionRequest_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransactionRequests.RowEnter
            Dim dgvRow As DataGridViewRow = DataGridViewInvTransactionRequests.Rows(e.RowIndex)
            Dim invTranIdNo As Int32 = dgvRow.Cells("dgvIdNo").Value
            RaiseEvent RowChanged(invTranIdNo)
            bsInvTranItems.ResetBindings(False)
            lblRequestedItems.Text = Messaging.TranslateCaption("Requested Items for ") + dgvRow.Cells("dgvReferenceNo").Value
        End Sub

        Private Sub InvRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                        If e.Value <= x.Cells("dgvQuantity").Value Then
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
            bsInvTranItems.ResetBindings(False)
        End Sub


        Private Sub OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransItems.CellEndEdit
            ProcessCellEndEdit(sender, bsInvTranItems)
            'UpdateTotals()
        End Sub

    End Class

End Namespace