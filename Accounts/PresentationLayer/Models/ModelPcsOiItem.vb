
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelPcsOiItem
        Inherits ModelAccounts
        Implements IModelPcsOiItem

        Private Shared ReadOnly Property Service As New PcsOiItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

        Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Integer) As List(Of PcsOiItemModel) Implements IModelPcsOiItem.GetSupplierOpenInvoices
            Dim bizObj = Service.GetSupplierOpenInvoices(supplierIdNo)
            Dim models As New List(Of PcsOiItemModel)
            For Each biz In bizObj
                Dim model As New PcsOiItemModel
                model.AccountIdNo = biz.AccountIdNo
                model.Amount = biz.Amount
                model.Balance = biz.Balance
                model.InvoiceNo = biz.InvoiceNo
                model.JournalCode = biz.JournalCode
                model.JournalIdNo = biz.JournalIdNo
                model.JournalItemIdNo = biz.JournalItemIdNo
                model.OpenInvoiceIdNo = biz.OpenInvoiceIdNo
                model.TransactionDate = biz.TransactionDate
                models.Add(model)
            Next
            Return models
        End Function

    End Class

    Public Interface IModelPcsOiItem

        Function GetSupplierOpenInvoices(supplierIdNo As Integer) As List(Of PcsOiItemModel)

    End Interface
End NameSpace