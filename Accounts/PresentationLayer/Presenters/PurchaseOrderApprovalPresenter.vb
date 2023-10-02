Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters
    Public Class PurchaseOrderApprovalPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPurchaseOrderApprovalView, TM)
        Implements ISubscriber(Of DgvItemsChanged)

        Private _purchaseOrderApprovalItemService


        Public Sub New()

        End Sub

        Public Sub New(view As IPurchaseOrderApprovalView)
            MyBase.New(view)
            Service = New AccountsService("PurchaseOrderApproval")
            TableName = "PurchaseOrder"
            SortOrderKey = "IdNo"
            WithTreeView = False
            _purchaseOrderApprovalItemService = New AccountsService("PurchaseOrderApprovalDetail")
            AddHandler view.RowChanged, AddressOf OnRowChanged
            AddHandler view.FormLoaded, AddressOf OnEntryFormLoaded
            AddHandler view.SupplyQuantityClicked, AddressOf OnSupplyQuantity
            AddHandler view.TransferRequestClicked, AddressOf OnTransferRequest
        End Sub

        Private Sub OnTransferRequest(PurchaseOrderIdNo As Int32)

            Dim PurchaseOrder As New PurchaseOrder
            Dim invTranDao = New PurchaseOrderDao
            Dim PurchaseOrderApproval As New Object
            Dim invReqSupDataTable As New System.Data.DataTable
            PurchaseOrder = invTranDao.GetRecordByIdNo(PurchaseOrderIdNo)
            PurchaseOrder.Notes = "Purchase Order Number " & PurchaseOrderIdNo.ToString() & " approved by : " + GlobalVariables.UserName
            PurchaseOrder.TransactionDate = Today()
            PurchaseOrder.Cancelled = False

            Dim dtPurchaseOrderApproval As New System.Data.DataTable
            dtPurchaseOrderApproval.Columns.Add("PurchaseOrderDetailIdNo", GetType(Int32))
            dtPurchaseOrderApproval.Columns.Add("QtySupplied", GetType(Int32))

            'Dim dataObj As New Object()
            For Each item In View.PurchaseOrderDetails
                Dim dr As DataRow = dtPurchaseOrderApproval.NewRow
                dr("PurchaseOrderDetailIdNo") = item.IdNo
                ' dr("QtySupplied") = item.QtyApproved
                dtPurchaseOrderApproval.Rows.Add(dr)
            Next

            Dim parameters As Object = {"@MParamType", dtPurchaseOrderApproval,
                                        "@PurchaseOrderIdNo", PurchaseOrder.IdNo,
                                        "@Amount", 0,
                                        "@BranchIdNo", GlobalVariables.BranchIdNo,
                                        "@Cancelled", False,
                                        "@InvTransTypeIdNo", 1,
                                        "@Notes", "Request #" & PurchaseOrder.IdNo.ToString() & " Appr. by " & GlobalVariables.UserName,
                                        "@Posted", True,
                                        "@ReferenceNo", PurchaseOrder.ReferenceNo,
                                        "@TransactionDate", Today(),
                                        "@UseridNo", GlobalVariables.UserIdNo,
                                        "@WarehouseIdNo", PurchaseOrder.WarehouseIdNo}

            Dim retVal As Int16
            retVal = invTranDao.RunSpWithRollBack("spPostPurchaseOrderApproval", parameters)
            If retVal >= 0 Then
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgInvTransferSuccess")
                GetUnPostedPo()
                RefreshRequestDetailsAndQtyOnHand(0)
            End If
        End Sub

        Private Sub OnSupplyQuantity(PurchaseOrderIdNo As Integer)
            '' refresh quantity on hand to reflect current values
            '' values might have changed if the screen has been left open for a long time
            'RefreshRequestDetailsAndQtyOnHand(PurchaseOrderIdNo)
            'If View.PurchaseOrderApprovalDetails Is Nothing Then
            '    AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgNoSelectedRecordToView")
            'Else
            '    Dim qtyToTransfer As Decimal
            '    For Each item In View.PurchaseOrderApprovalDetails
            '        qtyToTransfer = Math.Min(item.Quantity, item.QtyOnHand)
            '        item.QtyApproved = qtyToTransfer
            '    Next
            '    AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgApprovedQtyUpdated")
            'End If
        End Sub

        Private Sub OnEntryFormLoaded()
            GetUnPostedPo()
        End Sub

        Private Sub OnRowChanged(PurchaseOrderIdNo As Integer)
            RefreshRequestDetailsAndQtyOnHand(PurchaseOrderIdNo)
        End Sub

        Private Sub RefreshRequestDetailsAndQtyOnHand(PurchaseOrderIdNo As Integer)
            'Dim PurchaseOrderApprovalItems As List(Of PurchaseOrderApprovalDetailModel) = _PurchaseOrderApprovalItemService.GetRecordsWithGroupIdNo(Of PurchaseOrderApprovalDetailModel)(PurchaseOrderIdNo)
            'Dim invItems As New List(Of PurchaseOrderApprovalDetailView)
            'GlobalVariables.Mapper.Map(PurchaseOrderApprovalItems, invItems)
            'View.PurchaseOrderApprovalDetails = invItems
        End Sub

        Public Overrides Sub UpdateViewData(idNo As Int32)
            ' Override default action for this case do nothing
        End Sub

        Private Sub OnWarehouseIdNoChanged()
            GetUnPostedPo()
        End Sub

        Protected Overrides Sub CreateDataSources()
            'MakeControlDataSources({New String() {"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"}})
            MakeVarDataSources({New String() {"User", "UserList", "IdNo,UserName", Nothing, "UserName"},
                                New String() {"Unit", "UnitList", Nothing, Nothing, "UnitName"},
                                New String() {"Warehouse", "WarehouseList", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"}})
        End Sub

        Private Sub GetUnPostedPo()
            Dim purchaseOrders As New PurchaseOrderModel
            purchaseOrders = Service.GetParametrized(Of PurchaseOrderModel)({View.WarehouseIdNo})
            GlobalVariables.Mapper.Map(purchaseOrders, View)
        End Sub

        Public Sub OnPurchaseOrderdgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
            Dim purchaseOrderApprovalDetail As PurchaseOrderDetailView = eventType.BindingSource.Current
            With eventType.BindingSource.Current
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim gAmt As Decimal = 0
                    Dim dAmt As Decimal = 0
                    Dim nAmt As Decimal = 0
                    Select Case eventType.PropertyName
                        Case $"QtyApproved"
                            'If purchaseOrderApprovalDetail.QtyApproved + purchaseOrderApprovalDetail.QtySupplied > purchaseOrderApprovalDetail.Quantity Then
                            '    AATM.Libraries.MessagingLibrary.Messaging.Show("Sorry Quantity Approved + Quantity Supplied can't be more than the requested quantity! Changing value to maximum allowed quantity.")
                            '    purchaseOrderApprovalDetail.QtyApproved = purchaseOrderApprovalDetail.Quantity - purchaseOrderApprovalDetail.QtySupplied
                            'End If
                    End Select
                    '.NetAmount = GetNetAmount(PurchaseOrderDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub

    End Class

End Namespace
