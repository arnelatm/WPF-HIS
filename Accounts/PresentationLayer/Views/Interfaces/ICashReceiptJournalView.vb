Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface ICashReceiptJournalView
        Inherits IView

        Event AddCustomerOpenInvoices(bs As BindingSource)

        Event AutoApplyAmountRequested(bsCsrOiItems As BindingSource)

        Event ContactIdNoChanged(bs As BindingSource)

        Event CreditAmountChanged(sender As Object, e As DataGridViewCellEventArgs)

        Event DebitAccountIdNoChanged(bs As BindingSource)

        Event DebitAmountChanged(sender As Object, e As DataGridViewCellEventArgs)

        Event FirstLineUpdateNeeded()

        Event JiAccountIdNoChanged(sender As Object, e As DataGridViewCellEventArgs)

        Event OpenInvoiceDataRequested(bs As BindingSource)

        Event ReceiptAmountChanged(bsJournalItem As BindingSource, bsCsrOiItem As BindingSource)

        Event ReceiptTypeChanged(paymentType As String, bsJournalItem As BindingSource, bsCsrOiItems As BindingSource)

        Event UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs)

        Property AccountIdNo As Int16?
        Property AccountsByCode As Object
        Property Amount As Decimal
        Property Applied As Decimal
        Property Approved As Boolean
        Property Cancelled As Boolean
        Property CashReceiptAccountCount As Int16
        Property CheckDate As Date?
        Property CheckNumber As String
        Property ContactDataSource As DataTable
        Property ContactIdNo As Int32?
        Property CSEIdNo As Int32?
        Property CsrOiItems As List(Of CsrOiItemView)
        Property CustomersByName As Object
        Property DateCreated As DateTime?
        Property DiscountAccountIdNo As Int16?
        Property DiscountTaken As Decimal
        Property EmployeesByName As Object
        Property IdNo As Int32
        Property JournalCode As String
        Property JournalCodeDisplay As String
        Property JournalItems As List(Of JournalItemView)
        Property Notes As String
        Property OpenInvoiceMode As Boolean
        Property OrNumber As String
        Property PayorIdNo As Int32?
        Property PayorName As String
        Property PayorType As String
        Property Posted As Boolean
        Property ReferenceNo As String
        Property RevCostCentersByCode As Object
        Property SuppliersByName As Object
        ReadOnly Property TotalCredits As Decimal
        ReadOnly Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property UnApplied As Decimal
        Property VatAmount As Decimal
        Property VatNumber As String
    End Interface

End Namespace