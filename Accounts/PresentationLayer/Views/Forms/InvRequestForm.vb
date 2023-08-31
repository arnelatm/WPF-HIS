Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class InvRequestForm
        Implements IInvRequestView

        Private _invTransactionRequests As New List(Of InvRequestListView)
        Public Event WarehouseIdNoChanged() Implements IInvRequestView.WarehouseIdNoChanged


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

        Public Property WarehouseIdNo As Short Implements IInvRequestView.WarehouseIdNo
            Get
                Return cboWarehouseIdNo.GetValue(Of Short)
            End Get
            Set(value As Short)
                cboWarehouseIdNo.SetValue(value)
            End Set
        End Property

        Public Property InvTransactionRequests As List(Of InvRequestListView) Implements IInvRequestView.InvTransactionRequests
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
            DataGridViewInvTransactionRequests.Refresh()
            bsInvTransactionRequest.DataSource = InvTransactionRequests
            bsInvTransactionRequest.AllowNew = True
            With DataGridViewInvTransactionRequests
                .AutoGenerateColumns = False
                .DataSource = bsInvTransactionRequest
            End With
            ResumeLayout()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"WarehouseIdNo", cboWarehouseIdNo}
                }
        End Sub

        Private Sub SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboWarehouseIdNo.SelectionChangeCommitted
            RaiseEvent WarehouseIdNoChanged()
            bsInvTransactionRequest.ResetBindings(True)
            DataGridViewInvTransactionRequests.Refresh()
        End Sub

    End Class

End Namespace