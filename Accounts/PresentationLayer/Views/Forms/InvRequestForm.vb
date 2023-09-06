Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class InvRequestForm
        Implements IInvRequestView

        Private _invTransactionRequests As New List(Of IInvTransactionBaseView)
        Private _invTransactionDetails As List(Of InvTransactionDetailView)
        Public Event WarehouseIdNoChanged() Implements IInvRequestView.WarehouseIdNoChanged
        Public Event RowChanged(productIdNo As Int32) Implements IInvRequestView.RowChanged
        Public Property WarehouseList As DataTable Implements IInvRequestView.WarehouseList
        Public Property UserList As DataTable Implements IInvRequestView.UserList
        Public Property UnitList As DataTable Implements IInvRequestView.UnitList

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

        Public Property WarehouseSelector As Short
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

        Public Property InvTransactionDetails As List(Of InvTransactionDetailView) Implements IInvRequestView.InvTransactionDetails
            Get
                Return _invTransactionDetails
            End Get
            Set
                _invTransactionDetails = Value
                BindInvTransactionDetail()
            End Set
        End Property


        Private Sub BindInvTransactionDetail()
            SuspendLayout()
            bsInvTranItems.DataSource = Nothing
            DataGridViewInvTransItems.Refresh()
            bsInvTranItems.DataSource = InvTransactionDetails
            bsInvTranItems.AllowNew = False
            dgvUnitIdNo.DataSource = UnitList
            dgvUnitIdNo.DisplayMember = "Name"
            dgvUnitIdNo.ValueMember = "IdNo"
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

        Private Sub DataGridViewInvTransItems_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewInvTransItems.CellContentClick

        End Sub
    End Class

End Namespace