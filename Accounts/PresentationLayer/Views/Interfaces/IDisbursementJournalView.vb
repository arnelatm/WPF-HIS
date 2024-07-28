Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces

    Public Interface IDisbursementJournalView
        Inherits IView

        Event AddSupplierOpenInvoices()

        Event AutoApplyAmount(bsDjOiItem As BindingSource)

        Event FirstLineUpdateNeeded()

        Event ContactIdNoChanged()

        Event PaymentTypeChanged(paymentType As String)

        Event PrintCheck()

        Event PrintPcReplenishment()

        Event SetSupplierVatNumber(ByRef currentVatNumber As String, idNo As String, override As Boolean)

        Event UserDeletedRow()

        Property AccountIdNo As Int16?
        Property AccountsByCode
        Property Amount As Decimal
        Property Applied As Decimal
        Property Approved As Boolean
        Property BankTransfer As Boolean
        Property Cancelled As Boolean
        Property CdAccountCount As Int32
        Property CdJournalIdNo As Int32?
        Property CheckDate As Date?
        Property CheckNumber As String
        Property ContactIdNo As Int32?
        Property CSEIdNo As Int32?
        Property CustomersByName
        Property DateCreated As DateTime?
        Property DefaultAccount As Int32?
        Property DiscountAccountIdNo As Int16?
        Property DiscountTaken As Decimal
        Property DjOiItems As List(Of DjOiItemView)
        Property EmployeesByName
        Property IdNo As Int32
        Property JournalCode As String
        Property JournalCodeDisplay As String
        Property JournalItems As List(Of JournalItemView)
        Property Notes As String
        Property OpenInvoiceMode As Boolean
        Property OrNumber As String
        Property PayeeDataSource As Object
        Property PayeeIdNo As Int32?
        Property PayeeName As String
        Property PaymentType As String
        Property PayType As String
        Property PcClosed As Boolean
        Property Posted As Boolean
        Property ReferenceNo As String
        Property RevCostCentersByCode
        Property SuppliersByName
        ReadOnly Property TotalCredits As Decimal
        ReadOnly Property TotalDebits As Decimal
        Property TransactionDate As Date?
        Property UnApplied As Decimal
        Property VatAmount As Decimal
        Property VatNumber As String
    End Interface

End Namespace