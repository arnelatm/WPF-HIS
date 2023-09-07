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
            AddHandler view.FormLoaded, AddressOf OnEntryFormLoaded

        End Sub

        Private Sub OnEntryFormLoaded()
            Throw New NotImplementedException()
        End Sub

        Private Sub OnRowChanged(productIdNo As Integer)
            Dim invRequestItems As List(Of InvTransactionDetailModel)
            invRequestItems = _invRequestItemService.GetRecordsWithGroupIdNo(Of InvTransactionDetailModel)(productIdNo)
            Dim invItems As New List(Of InvTransactionDetailView)
            GlobalVariables.Mapper.Map(invRequestItems, invItems)
            View.InvTransactionDetails = invItems
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
