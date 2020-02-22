
Imports AATM.Accounts.ServiceLayer.ActionService

Namespace PresentationLayer.Models

    Public Class ModelCsrOiItem
        Inherits ModelAccounts
        Implements IModelCsrOiItem

        Private Shared ReadOnly Property Service As New CsrOiItemService()

        Public Overrides Function GetAccountsService()
            Return Service
        End Function

        Public Function GetCustomerOpenInvoices(ByVal supplierIdNo As Integer) As List(Of CsrOiItemModel) Implements IModelCsrOiItem.GetCustomerOpenInvoices
            Dim bizObj = Service.GetSupplierOpenInvoices(supplierIdNo)
            Dim models As New List(Of CsrOiItemModel)
            For Each biz In bizObj
                Dim model As New CsrOiItemModel
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

    Public Interface IModelCsrOiItem

        Function GetCustomerOpenInvoices(supplierIdNo As Integer) As List(Of CsrOiItemModel)

    End Interface
End NameSpace