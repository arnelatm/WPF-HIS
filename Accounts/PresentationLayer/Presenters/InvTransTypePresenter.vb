Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class InvTransTypePresenter(Of TM As New)
        Inherits AccountsPresenter(Of IInvTransTypeView, TM)

        Public Sub New(itemView As IInvTransTypeView)
            MyBase.New(itemView)
            Service = New AccountsService("InvTransType")
            TableName = "InvTransType"
            TreeViewMainField = "InvTransTypeName"
            SortOrderKey = "InvTransTypeName"
            WithTreeView = True
            Service = New AccountsService("InvTransType")
            DataFilter = "BranchIdNo = " & GlobalVariables.BranchIdNo.ToString() + " "
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of InventoryActionSelection)("InventoryAction")
            Dim data As New ArrayList
            data.Add({"Account", "AccountIdNo", Nothing, Nothing})
            CreateDataSourceThread(data)

        End Sub


    End Class

End Namespace