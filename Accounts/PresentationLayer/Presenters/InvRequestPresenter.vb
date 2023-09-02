Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

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
            _invRequestItemService = New AccountsService("InvTransactionDetail")
            AddHandler view.WarehouseIdNoChanged, AddressOf OnWarehouseIdNoChanged
            AddHandler view.RowChanged, AddressOf OnRowChanged
        End Sub

        Private Sub OnRowChanged(productIdNo As Integer)
            Dim invRequestItems As List(Of InvTransactionDetailModel)
            invRequestItems = _invRequestItemService.GetRecordsWithGroupIdNo(Of InvTransactionDetailModel)(productIdNo)
            GlobalVariables.Mapper.Map(invRequestItems, View.InvTransactionDetails)
        End Sub

        Private Sub OnWarehouseIdNoChanged()
            GetInvTransactions()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"Warehouse", "WarehouseIdNo", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"})
            CreateDataSourceThread(data)
            data.Clear()
            data.Add({"User", "UserList", "IdNo,UserName", Nothing})
            data.Add({"Warehouse", "WarehouseList", Nothing, "BranchIdNo = " + GlobalVariables.BranchIdNo.ToString(), "WarehouseName"})
            CreateLookupDataThread(data)
        End Sub

        Private Sub GetInvTransactions()
            Dim invTransactions As New InvRequestModel
            If String.IsNullOrEmpty(View.WarehouseIdNo) Then
                invTransactions = Nothing
            Else
                invTransactions = Service.GetParametrized(Of InvRequestModel)({View.WarehouseIdNo})
            End If
            'For Each item In invTransactions.InvTransactionRequests
            '    Dim x As New InvRequestListView
            '    View.InvTransactionRequests.Clear()
            '    x.Cancelled = item.Cancelled
            '    x.DateCreated = item.DateCreated
            '    x.IdNo = item.IdNo
            '    x.InvTransTypeIdNo = item.InvTransTypeIdNo
            '    x.Notes = item.Notes
            '    x.Posted = item.Posted
            '    x.ReferenceNo = item.ReferenceNo
            '    x.TransactionDate = item.TransactionDate
            '    x.UserIdNo = item.UserIdNo
            '    x.WarehouseIdNo = item.WarehouseIdNo
            '    x.WarehouseToIdNo = item.WarehouseToIdNo
            '    View.InvTransactionRequests.Add(x)
            'Next
            'View.InvTransactionRequests.Clear()
            'For Each item In invTransactions.InvTransactionRequests
            '    Dim x As IInvTransactionBaseView
            '    GlobalVariables.Mapper.Map(item, x)
            '    View.InvTransactionRequests.Add(x)
            '    'x.Cancelled = item.Cancelled
            '    'x.DateCreated = item.DateCreated
            '    'x.IdNo = item.IdNo
            '    'x.InvTransTypeIdNo = item.InvTransTypeIdNo
            '    'x.Notes = item.Notes
            '    'x.Posted = item.Posted
            '    'x.ReferenceNo = item.ReferenceNo
            '    'x.TransactionDate = item.TransactionDate
            '    'x.UserIdNo = item.UserIdNo
            '    'x.WarehouseIdNo = item.WarehouseIdNo
            '    'x.WarehouseToIdNo = item.WarehouseToIdNo
            '    'View.InvTransactionRequests.Add(x)
            'Next
            GlobalVariables.Mapper.Map(invTransactions, View)

            'Dim x As InvTransactionView =
            'For Each item In invTransactions.InvTransactionRequests
            '    GlobalVariables.Mapper.Map(item, x)
            'Next


            '
            'View.InvTransactionRequests = DirectCast(invTransactions, IInvRequestView)



            'For Each item In invTransactions.InvTransactionRequests
            '    Dim x As IInvTransactionView = Nothing
            '    GlobalVariables.Mapper.Map(item, x)
            'Next

        End Sub


    End Class

End Namespace
