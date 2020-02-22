
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelSalesCashItem
        Inherits ModelAccounts
        Implements IModelSaleCashItem

        Private Shared ReadOnly Property Service As New SalesCashItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

    End Class

    Public Interface IModelSaleCashItem

    End Interface
End NameSpace