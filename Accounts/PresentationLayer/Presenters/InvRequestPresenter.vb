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
    Public Class InvRequestPresenter(Of TM As New)
        Inherits CommonPresenter(Of IInvRequestView, TM)
        Implements ISubscriber(Of DgvItemsChanged)

        Private _invRequestItemService


        Public Sub New()

        End Sub

        Public Sub New(view As IInvRequestView)
            MyBase.New(view)
            Service = New AccountsService("InvRequest")
            TableName = "InvTransaction"
            SortOrderKey = "IdNo"
            WithTreeView = False
            _invRequestItemService = New AccountsService("InvRequestDetail")
            AddHandler view.WarehouseIdNoChanged, AddressOf OnWarehouseIdNoChanged
            AddHandler view.RowChanged, AddressOf OnRowChanged
            AddHandler view.FormLoaded, AddressOf OnEntryFormLoaded
            AddHandler view.SupplyQuantityClicked, AddressOf OnSupplyQuantity
            AddHandler view.TransferRequestClicked, AddressOf OnTransferRequest
        End Sub

        Private Sub OnTransferRequest(invTransactionIdNo As Int32)

            Dim invTransaction As New InvTransaction
            Dim invTranDao = New InvTransactionDao
            Dim invRequest As New Object
            Dim invReqSupDataTable As New System.Data.DataTable
            invTransaction = invTranDao.GetRecordByIdNo(invTransactionIdNo)
            invTransaction.Notes = "Request Number " & invTransactionIdNo.ToString() & " approved by : " + GlobalVariables.UserName
            invTransaction.TransactionDate = Today()
            invTransaction.Cancelled = False
            invTransaction.InvTransTypeIdNo = 1


            Dim dtInvRequest As New System.Data.DataTable
            dtInvRequest.Columns.Add("InvTransactionDetailIdNo", GetType(Int32))
            dtInvRequest.Columns.Add("QtySupplied", GetType(Int32))
            Dim qtyToPost As Decimal = 0
            'Dim dataObj As New Object()
            For Each item In View.InvRequestDetails
                Dim dr As DataRow = dtInvRequest.NewRow
                dr("InvTransactionDetailIdNo") = item.IdNo
                dr("QtySupplied") = item.QtyApproved
                dtInvRequest.Rows.Add(dr)
                qtyToPost += Math.Abs(item.QtyApproved)
            Next
            If qtyToPost > 0 Then
                Dim parameters As Object = {"@MParamType", dtInvRequest,
                                        "@InvTransactionIdNo", invTransaction.IdNo,
                                        "@Amount", 0,
                                        "@BranchIdNo", GlobalVariables.BranchIdNo,
                                        "@Cancelled", False,
                                        "@InvTransTypeIdNo", 1,
                                        "@Notes", "Request #" & invTransaction.IdNo.ToString() & " Appr. by " & GlobalVariables.UserName,
                                        "@Posted", True,
                                        "@ReferenceNo", invTransaction.ReferenceNo,
                                        "@TransactionDate", Today(),
                                        "@UseridNo", GlobalVariables.UserIdNo,
                                        "@WarehouseIdNo", invTransaction.WarehouseIdNo,
                                        "@WarehouseToIdNo", invTransaction.WarehouseToIdNo}

                Dim retVal As Int16
                retVal = invTranDao.RunSpWithRollBack("spPostInvRequest", parameters)
                If retVal >= 0 Then
                    View.WarehouseIdNo = View.WarehouseSelector
                    AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgInvTransferSuccess")
                    GetInvTransactions()
                    RefreshRequestDetailsAndQtyOnHand(0)
                End If
            Else
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgNoApprovedQtySpecified")
            End If
        End Sub

        Private Sub OnSupplyQuantity(invTransactionIdNo As Integer)
            ' refresh quantity on hand to reflect current values
            ' values might have changed if the screen has been left open for a long time
            RefreshRequestDetailsAndQtyOnHand(invTransactionIdNo)
            If View.InvRequestDetails Is Nothing Then
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgNoSelectedRecordToView")
            Else
                Dim qtyToTransfer As Decimal
                For Each item In View.InvRequestDetails
                    qtyToTransfer = Math.Min(item.Quantity, item.QtyOnHand)
                    item.QtyApproved = qtyToTransfer
                Next
                AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgApprovedQtyUpdated")
            End If
        End Sub

        Private Sub OnEntryFormLoaded()
            View.WarehouseIdNo = Service.GetField(Of Int16, Int16, Int16)(AppSettingGroupSelector.UserDefaultWarehouse, GlobalVariables.UserIdNo, "AppSetting", "AppSettingGroupIdNo", "Selector1IdNo", "selector2IdNo")
            View.WarehouseSelector = View.WarehouseIdNo
            GetInvTransactions()
        End Sub

        Private Sub OnRowChanged(invTransactionIdNo As Integer)
            RefreshRequestDetailsAndQtyOnHand(invTransactionIdNo)
        End Sub

        Private Sub RefreshRequestDetailsAndQtyOnHand(invTransactionIdNo As Integer)
            Dim invRequestItems As List(Of InvRequestDetailModel) = _invRequestItemService.GetRecordsWithGroupIdNo(Of InvRequestDetailModel)(invTransactionIdNo)
            Dim invItems As New List(Of InvRequestDetailView)
            GlobalVariables.Mapper.Map(invRequestItems, invItems)
            View.InvRequestDetails = invItems
        End Sub

        Public Overrides Sub UpdateViewData(idNo As Int32)
            ' Override default action for this case do nothing
        End Sub

        Private Sub OnWarehouseIdNoChanged()
            GetInvTransactions()
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New String() {"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"}})
            MakeVarDataSources({New String() {"User", "UserList", "IdNo,UserName", Nothing, "UserName"},
                                New String() {"Unit", "UnitList", Nothing, Nothing, "UnitName"},
                                New String() {"Warehouse", "WarehouseList", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"}})
        End Sub

        Private Sub GetInvTransactions()
            Dim invTransactions As New InvRequestModel
            If String.IsNullOrEmpty(View.WarehouseIdNo) Then
                invTransactions = Nothing
            Else
                invTransactions = Service.GetParametrized(Of InvRequestModel)({View.WarehouseIdNo})
            End If
            GlobalVariables.Mapper.Map(invTransactions, View)
        End Sub

        Public Sub OnInvTransactiondgvItemsChangedEventHandler(ByRef eventType As DgvItemsChanged) Implements ISubscriber(Of DgvItemsChanged).OnEventHandler
            Dim invRequestDetail As InvRequestDetailView = eventType.BindingSource.Current
            With eventType.BindingSource.Current
                If eventType.Row >= 0 And eventType.Row < eventType.BindingSource.Count() Then
                    Dim gAmt As Decimal = 0
                    Dim dAmt As Decimal = 0
                    Dim nAmt As Decimal = 0
                    Select Case eventType.PropertyName
                        Case $"QtyApproved"
                            If invRequestDetail.QtyApproved + invRequestDetail.QtySupplied > invRequestDetail.Quantity Then
                                AATM.Libraries.MessagingLibrary.Messaging.Show("Sorry Quantity Approved + Quantity Supplied can't be more than the requested quantity! Changing value to maximum allowed quantity.")
                                invRequestDetail.QtyApproved = invRequestDetail.Quantity - invRequestDetail.QtySupplied
                            End If
                    End Select
                    '.NetAmount = GetNetAmount(InvTransactionDetail)
                    eventType.BindingSource.ResetItem(eventType.Row)
                End If
            End With
        End Sub

    End Class

End Namespace
