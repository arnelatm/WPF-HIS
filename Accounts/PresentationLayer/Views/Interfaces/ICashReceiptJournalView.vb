Imports AATM.Presentation.Views

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
        Property PayorDataSource As Object
        Event AutoApplyAmount(bsDjOiItem As BindingSource)
        Event AddCustomerOpenInvoices()
        Event UserDeletedRow()
        Event FirstLineUpdateNeeded()
        Event ReceiptTypeChanged(paymentType As String)
    End Interface

End Namespace