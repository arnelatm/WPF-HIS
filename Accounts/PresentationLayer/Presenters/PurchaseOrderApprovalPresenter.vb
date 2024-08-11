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
            AddHandler view.ApproveSelectedPO, AddressOf OnApproveOrder
        End Sub

        Private Sub OnApproveOrder(PurchaseOrderIdNo As Int32)

            Dim dtPurchaseOrderApproval As New System.Data.DataTable
            Dim daoParameter As Object = {True, False}
            Dim purchaseOrderDao = New PurchaseDao(daoParameter)

            Dim PurchaseOrderApproval As New Object
            Dim invReqSupDataTable As New System.Data.DataTable
            dtPurchaseOrderApproval.Columns.Add("PurchaseOrderDetailIdNo", GetType(Int32))
            dtPurchaseOrderApproval.Columns.Add("QtySupplied", GetType(Int32))
            Dim PurchaseOrder As New Purchase

            PurchaseOrder = purchaseOrderDao.GetRecordByIdNo(PurchaseOrderIdNo)
            'PurchaseOrder.Notes = "Purchase Order Number " & PurchaseOrderIdNo.ToString() & " approved by : " + GlobalVariables.UserName
            'PurchaseOrder.TransactionDate = Today()
            'PurchaseOrder.Cancelled = False



            'Dim dataObj As New Object()
            For Each item In View.PurchaseOrderDetails
                Dim dr As DataRow = dtPurchaseOrderApproval.NewRow
                dr("PurchaseOrderDetailIdNo") = item.IdNo
                dr("QtySupplied") = item.QtyApproved
                dtPurchaseOrderApproval.Rows.Add(dr)
            Next

            Dim parameters As Object = {"@MParamType", dtPurchaseOrderApproval,
                                        "@PurchaseOrderIdNo", PurchaseOrder.IdNo,
                                        "@ApprovedBy", GlobalVariables.UserIdNo
                                       }

            Dim retVal As Int16
            retVal = purchaseOrderDao.RunSpWithRollBack("spPostPurchaseOrder", parameters)
            If retVal >= 0 Then
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgInvTransferSuccess")
                GetUnPostedPo()
                RefreshRequestDetailsAndQtyOnHand(0)
            End If
        End Sub

        Private Sub OnSupplyQuantity(PurchaseOrderIdNo As Integer)
            ' refresh quantity on hand to reflect current values
            ' values might have changed if the screen has been left open for a long time
            RefreshRequestDetailsAndQtyOnHand(PurchaseOrderIdNo)
            If View.PurchaseOrderDetails Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgNoSelectedRecordToView")
            Else
                Dim qtyToTransfer As Decimal
                For Each item In View.PurchaseOrderDetails
                    qtyToTransfer = item.Quantity
                    item.QtyApproved = qtyToTransfer
                Next
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgApprovedQtyUpdated")
            End If
        End Sub

        Private Sub OnEntryFormLoaded()
            GetUnPostedPo()
        End Sub

        Private Sub OnRowChanged(PurchaseOrderIdNo As Integer)
            RefreshRequestDetailsAndQtyOnHand(PurchaseOrderIdNo)
        End Sub

        Private Sub RefreshRequestDetailsAndQtyOnHand(PurchaseOrderIdNo As Integer)
            Dim PurchaseOrderApprovalItems As List(Of PurchaseOrderApprovalDetailModel) = _purchaseOrderApprovalItemService.GetRecordsWithGroupIdNo(Of PurchaseOrderApprovalDetailModel)(PurchaseOrderIdNo)
            Dim invItems As New List(Of PurchaseOrderApprovalDetailView)
            GlobalFunctions.ManualMap(PurchaseOrderApprovalItems, invItems)
            View.PurchaseOrderDetails = invItems
        End Sub

        Public Overrides Sub UpdateViewData(idNo As Int32)
            ' Override default action for this case do nothing
        End Sub

        Private Sub OnWarehouseIdNoChanged()
            GetUnPostedPo()
        End Sub

        Protected Overrides Sub CreateDataSources()
            'MakeControlDataSources({New Object() {"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"}})
            MakeVarDataSources({New Object() {"User", "UserList", "IdNo,UserName", Nothing, "UserName"},
                                New Object() {"Unit", "UnitList", Nothing, Nothing, "UnitName"},
                                New Object() {"Supplier", "SupplierList", Nothing, Nothing, "SupplierName"},
                                New Object() {"Warehouse", "WarehouseList", Nothing, Nothing, "WarehouseName"}})
        End Sub

        Private Sub GetUnPostedPo()
            Dim purchaseOrders As New PurchaseOrderApprovalModel
            purchaseOrders = Service.GetParametrized(Of PurchaseOrderApprovalModel)(Nothing)
            GlobalFunctions.ManualMap(purchaseOrders, View)
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
