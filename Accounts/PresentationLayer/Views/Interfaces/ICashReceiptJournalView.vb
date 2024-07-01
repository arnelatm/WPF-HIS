Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICashReceiptJournalView
        Inherits IView

        Property AccountIdNo As Int16?
        Property Amount As Decimal
        Property Applied As Decimal
        Property Approved As Boolean
        Property Cancelled As Boolean
        Property CheckDate As Date?
        Property CheckNumber As String
        Property ContactIdNo As Int32?
        Property DateCreated As DateTime?
        Property DiscountAccountIdNo As Int16?
        Property DiscountTaken As Decimal
        Property IdNo As Int32
        Property Notes As String
        Property OrNumber As String
        Property PayorIdNo As Int32?
        Property PayorName As String
        Property PayorType As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property TransactionDate As Date?
        ReadOnly Property TotalCredits As Decimal
        ReadOnly Property TotalDebits As Decimal
        Property UnApplied As Decimal
        Property VatAmount As Decimal
        Property VatNumber As String
        Property JournalItems As List(Of JournalItemView)
        Property CsrOiItems As List(Of CsrOiItemView)
        Property AccountsByCode As Object
        Property RevCostCentersByCode As Object
        Property EmployeesByName As Object
        Property CustomersByName As Object
        Property SuppliersByName As Object
        Property ContactDataSource As DataTable
        Property JournalCode As String
        Property JournalCodeDisplay As String
        Property CashReceiptAccountCount As Int16
        Property OpenInvoiceMode As Boolean

        Event AutoApplyAmountRequested(bsCsrOiItems As BindingSource)
        Event AddCustomerOpenInvoices(bs As BindingSource)
        Event UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs)
        Event FirstLineUpdateNeeded()
        Event ReceiptTypeChanged(paymentType As String, bsJournalItem As BindingSource, bsCsrOiItems As BindingSource)
        Event JiAccountIdNoChanged(sender As Object, e As DataGridViewCellEventArgs)
        Event DebitAmountChanged(sender As Object, e As DataGridViewCellEventArgs)
        Event CreditAmountChanged(sender As Object, e As DataGridViewCellEventArgs)
        Event OpenInvoiceDataRequested(bs As BindingSource)
        Event ContactIdNoChanged(bs As BindingSource)
        Event ReceiptAmountChanged(bsJournalItem As BindingSource, bsCsrOiItem As BindingSource)
        Event DebitAccountIdNoChanged(bs As BindingSource)

    End Interface

End Namespace