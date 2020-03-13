' ** GoF Design Pattern: Factory.
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IDaoFactoryAccounts
        Inherits IDaoFactoryCommon

        ReadOnly Property DaoAccounts As IDaoAccounts
        ReadOnly Property EmployeeDao As IDaoAll(Of Employee)
        ReadOnly Property CategoryDao As IDaoAll(Of Category)
        ReadOnly Property JournalItemDao As IDaoJournalItems

        ReadOnly Property ApJournalDao As IDao(Of ApJournal)
        ReadOnly Property ApJournalItemDao As IDaoJournalItems
        ReadOnly Property ApOpenInvoiceDao As IDaoOpenInvoice

        ReadOnly Property ArJournalDao As IDao(Of ArJournal)
        ReadOnly Property ArJournalItemDao As IDaoJournalItems
        ReadOnly Property ArOpenInvoiceDao As IDaoOpenInvoice

        ReadOnly Property GeneralJournalDao As IDao(Of GeneralJournal)
        ReadOnly Property GeneralJournalItemDao As IDaoJournalItems

        'ReadOnly Property BankDao As IBankDao
        'ReadOnly Property CadOiItemDao As ICadOiItemDao
        'ReadOnly Property CashDisbursementJournalDao As ICashDisbursementJournalDao
        'ReadOnly Property CashDisbursementJournalItemDao As IJournalItemDao
        'ReadOnly Property CashReceiptJournalDao As ICashReceiptJournalDao
        'ReadOnly Property CashReceiptJournalItemDao As IJournalItemDao
        'ReadOnly Property ChartDao As IChartDao
        'ReadOnly Property ChequeDisbursementJournalDao As IChequeDisbursementJournalDao
        'ReadOnly Property ChequeDisbursementJournalItemDao As IJournalItemDao
        'ReadOnly Property CkdOiItemDao As ICkdOiItemDao
        'ReadOnly Property CsrOiItemDao As ICsrOiItemDao
        'ReadOnly Property CustomerDao As ICustomerDao
        'ReadOnly Property DesignationDao As IDesignationDao
        'ReadOnly Property DistributionSchemeDao As IDistributionSchemeDao
        'ReadOnly Property DistributionSchemeItemDao As IDistributionSchemeItemDao
        'ReadOnly Property PcsOiItemDao As IPcsOiItemDao
        'ReadOnly Property PettyCashJournalDao As IPettyCashJournalDao
        'ReadOnly Property PettyCashJournalItemDao As IJournalItemDao
        'ReadOnly Property PurchaseItemDao As IPurchaseItemDao
        'ReadOnly Property PurchaseJournalDao As IPurchaseJournalDao
        'ReadOnly Property PurchaseJournalItemDao As IJournalItemDao
        'ReadOnly Property SupplierDao As ISupplierDao
        'ReadOnly Property SalesJournalDao As ISalesJournalDao
        'ReadOnly Property SalesJournalItemDao As IJournalItemDao
        'ReadOnly Property SalesCashItemDao As ISalesCashItemDao
        'ReadOnly Property CashCodeDao As ICashCodeDao
        'ReadOnly Property AccountReconciliationDao As IAccountReconciliationDao
        'ReadOnly Property AccountReconciliationItemDao As IAccountReconciliationItemDao
        'ReadOnly Property ReconciledDao As IReconciledDao
    End Interface

End Namespace