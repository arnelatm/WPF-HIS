
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCkdOiItem
        Inherits ModelAccounts
        Implements IModelCkdOiItem

        Private Shared ReadOnly Property Service As New CkdOiItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

        Public Function GetSupplierOpenInvoices(ByVal supplierIdNo As Integer) As List(Of CkdOiItemModel) Implements IModelCkdOiItem.GetSupplierOpenInvoices
            Dim bizObj = Service.GetSupplierOpenInvoices(supplierIdNo)
            Dim models As New List(Of CkdOiItemModel)
            For Each biz In bizObj
                Dim model As New CkdOiItemModel
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

    Public Interface IModelCkdOiItem

        Function GetSupplierOpenInvoices(supplierIdNo As Integer) As List(Of CkdOiItemModel)

    End Interface
End NameSpace