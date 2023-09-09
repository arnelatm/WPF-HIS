Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDisbursementJournalView
        Inherits IView
        Property AccountIdNo As Int16?
        Property Amount As Decimal
        Property Applied As Decimal
        Property Approved As Boolean
        Property Cancelled As Boolean
        Property CdJournalIdNo As Int32?
        Property CheckDate As Date?
        Property CheckNumber As String
        Property DateCreated As DateTime?
        Property DiscountAccountIdNo As Int16?
        Property DiscountTaken As Decimal
        Property IdNo As Int32
        Property Notes As String
        Property OrNumber As String
        Property PayeeIdNo As Int32?
        Property PayeeName As String
        Property PaymentType As String
        Property PayType As String
        Property PcClosed As Boolean
        Property Posted As Boolean
        Property ReferenceNo As String
        ReadOnly Property TotalCredits As Decimal
        ReadOnly Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property UnApplied As Decimal
        Property VatAmount As Decimal
        Property VatNumber As String
        Property JournalItems As List(Of JournalItemView)
        Property DjOiItems As List(Of DjOiItemView)
        Property AccountsByCode
        Property EmployeesByName
        Property SuppliersByName
        Property CustomersByName
        Property RevCostCentersByCode
        Property BankTransfer As Boolean
        Property PayeeDataSource As Object
        Event PrintCheck()

        Event AutoApplyAmount(bsDjOiItem As BindingSource)

        Event AddSupplierOpenInvoices()

        Event UserDeletedRow()

        Event PrintPcReplenishment()

        Event FirstLineUpdateNeeded()

        Event SetSupplierVatNumber(ByRef currentVatNumber As String, idNo As String, override As Boolean)
        Event PaymentTypeChanged(paymentType As String)

    End Interface

End Namespace