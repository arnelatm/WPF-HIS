' ** GoF Design Pattern: Factory.
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IDaoFactoryAccounts
        Inherits IDaoFactoryCommon

        ReadOnly Property DaoAccounts As IDaoAccounts

        ReadOnly Property BankDao As IDaoAll(Of Bank)
        ReadOnly Property CashCodeDao As IDaoAll(Of CashCode)
        ReadOnly Property CategoryDao As IDaoAll(Of Category)
        ReadOnly Property ChartDao As IDaoAll(Of Chart)
        ReadOnly Property CustomerDao As IDaoAll(Of Customer)
        ReadOnly Property DesignationDao As IDaoAll(Of Designation)
        ReadOnly Property EmployeeDao As IDaoAll(Of Employee)
        ReadOnly Property PurchaseItemDao As IDaoAll(Of PurchaseItem)
        ReadOnly Property SupplierDao As IDaoAll(Of Supplier)

        'ReadOnly Property AccountReconciliationDao As IDao(Of AccountReconciliation)
        ReadOnly Property ApJournalDao As IDao(Of ApJournal)

        ReadOnly Property ArJournalDao As IDao(Of ArJournal)

        'ReadOnly Property CashDisbursementJournalDao As IDao(Of CashDisbursementJournal)
        'ReadOnly Property CashReceiptJournalDao As IDao(Of CashReceiptJournal)
        'ReadOnly Property ChequeDisbursementJournalDao As IDao(Of ChequeDisbursementJournal)
        ReadOnly Property DistributionSchemeDao As IDao(Of DistributionScheme)

        ReadOnly Property GeneralJournalDao As IDao(Of GeneralJournal)

        'ReadOnly Property PettyCashJournalDao As IDao(Of PettyCashJournal)
        'ReadOnly Property PurchaseJournalDao As IDao(Of PurchaseJournal)
        'ReadOnly Property SalesJournalDao As IDao(Of SalesJournal)

        ReadOnly Property ApJournalItemDao As IDaoJournalItems
        ReadOnly Property ArJournalItemDao As IDaoJournalItems
        ReadOnly Property DistributionSchemeItemDao As IDao(Of DistributionSchemeItem)

        'ReadOnly Property CashDisbursementJournalItemDao As IDaoJournalItems
        'ReadOnly Property CashReceiptJournalItemDao As IDaoJournalItems
        'ReadOnly Property ChequeDisbursementJournalItemDao As IDaoJournalItems
        ReadOnly Property GeneralJournalItemDao As IDaoJournalItems

        ReadOnly Property JournalItemDao As IDaoJournalItems
        'ReadOnly Property PettyCashJournalItemDao As IDaoJournalItems
        'ReadOnly Property PurchaseJournalItemDao As IDaoJournalItems
        'ReadOnly Property SalesJournalItemDao As IDaoJournalItems

        'ReadOnly Property SalesCashItemDao As ISalesCashItemDao

        ReadOnly Property ArOpenInvoiceDao As IDaoOpenInvoice(Of ArOpenInvoice)
        ReadOnly Property ApOpenInvoiceDao As IDaoOpenInvoice(Of ApOpenInvoice)

        'ReadOnly Property AccountReconciliationItemDao As IAccountReconciliationItemDao

        'ReadOnly Property CkdOiItemDao As ICkdOiItemDao
        'ReadOnly Property CsrOiItemDao As ICsrOiItemDao
        'ReadOnly Property PcsOiItemDao As IPcsOiItemDao
        'ReadOnly Property ReconciledDao As IReconciledDao
        'ReadOnly Property CadOiItemDao As ICadOiItemDao

    End Interface

End Namespace