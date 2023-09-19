Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Microsoft.Office.Interop.Excel

Namespace PresentationLayer.Presenters
    Public Class InvRequestPresenter(Of TM As New)
        Inherits CommonPresenter(Of IInvRequestView, TM)

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
            'invRequestSuppliedDTable.Columns.Add("InvTransactionDetailIdNo", GetType(Int32))
            'invRequestSuppliedDTable.Columns.Add("QtySupplied", GetType(Int32))
            'Dim dataObj As New Object()
            'For Each item In View.InvRequestDetails
            '    dataObj.Add(New Object() {item.Quantity, item.QtyApproved})
            'Next
            'CustomObjToDataTable(dataObj, invRequestSuppliedDTable)

            'invTranDao.DelUpdateTvp("PostInvRequestSupplied", invReqSupDataTable, @MParam, invTransactionIdNo)


            invTransaction = invTranDao.GetRecordByIdNo(invTransactionIdNo)
            invTransaction.Notes = "Request approved by : " + GlobalVariables.UserName
            invTransaction.TransactionDate = Today()
            invTransaction.Cancelled = False
            invTransaction.InvTransTypeIdNo = 15
            invTransaction.IdNo = 0
            Dim idNo As Int32 = invTranDao.AddRecord(invTransaction)


            If idNo > 0 Then



                Dim parameters As Object = {"InvTransactionIdNo", invTransactionIdNo, "oldUnitIdNo", parameters}

                invTranDao.RunStoredProcedure("PostUpdateInvTransactionDetailTVP", parameters)

                'For Each item In View.InvRequestDetails
                '    DtInsertTable.Rows.Add(item.Quantity, item.QtyApproved)
                'Next

                Service.RunStoredProcedure("SpPostInvRequest", {invTransactionIdNo, invTransaction, invRequest})
                Service.Insert()


            End If


            'Dim 

            'Service.InsertRecord("InvTransaction", {"BranchIdNo", "ReferenceNo", "TransactionDate", "InvTransTypeIdNo", "WarehouseIdNo", "WarehouseToIdNo", "Amount", "Cancelled", "Notes", "Posted", "UserIdNo"},
            '                                       {"Integer", "String", "Date", "Integer", "Integer", "Integer", "Decimal", "Boolean", "String", "Boolean", "Integer"}
            '                                       {GlobalVariables.BranchIdNo,"",Today(), 15, View.WarehouseIdNo, View.InvRequest(index), item.IdNo, item.QtyApproved})
        End Sub

        Private Sub OnSupplyQuantity()
            For Each item In View.InvRequestDetails
                item.QtyApproved = Math.Min(item.Quantity, item.QtyOnHand)
            Next
        End Sub

        Private Sub OnEntryFormLoaded()
            View.WarehouseIdNo = Service.GetField(Of Int16, Int16, Int16)(AppSettingGroupSelector.UserDefaultWarehouse, GlobalVariables.UserIdNo, "AppSetting", "AppSettingGroupIdNo", "Selector1IdNo", "selector2IdNo")
            View.WarehouseSelector = View.WarehouseIdNo
            GetInvTransactions()
        End Sub

        Private Sub OnRowChanged(productIdNo As Integer)
            Dim invRequestItems As List(Of InvRequestDetailModel)
            invRequestItems = _invRequestItemService.GetRecordsWithGroupIdNo(Of InvRequestDetailModel)(productIdNo)
            Dim invItems As New List(Of InvRequestDetailView)
            GlobalVariables.Mapper.Map(invRequestItems, invItems)
            View.InvRequestDetails = invItems
        End Sub

        Public Overrides Sub UpdateViewData(idNo As Int32)
            'MyBase.UpdateViewData(idNo)
            'If _WithTreeView Then
            '    TreeViewUpdateViewDisplay(idNo)
            'End If
        End Sub

        Private Sub OnWarehouseIdNoChanged()
            GetInvTransactions()
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New String() {"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"}})
            MakeVarDataSources({New String() {"User", "UserList", Nothing, Nothing, "UserName"},
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


    End Class

End Namespace
