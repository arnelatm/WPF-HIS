' ** GoF Design Pattern: Factory.
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.DataLayer

Namespace DataLayer

    Public Interface IAccountsDaoFactory
        Inherits AATM.Common.DataLayer.ICommonDaoFactory
        Inherits AATM.DataLayer.IDaoFactory

        ReadOnly Property AccountsDao As IAccountsDao
        ReadOnly Property ApJournalDao As IDao(Of ApJournal)
        ReadOnly Property ApJournalItemDao As IDaoJournalItems(Of JournalItem)
        ReadOnly Property ApOpenInvoiceDao As IDaoChild(Of ApOpenInvoice)

        'ReadOnly Property ArJournalDao As IArJournalDao
        'ReadOnly Property ArJournalItemDao As IJournalItemDao
        'ReadOnly Property ArOpenInvoiceDao As IArOpenInvoiceDao
        'ReadOnly Property BankDao As IBankDao
        'ReadOnly Property CadOiItemDao As ICadOiItemDao
        'ReadOnly Property CashDisbursementJournalDao As ICashDisbursementJournalDao
        'ReadOnly Property CashDisbursementJournalItemDao As IJournalItemDao
        'ReadOnly Property CashReceiptJournalDao As ICashReceiptJournalDao
        'ReadOnly Property CashReceiptJournalItemDao As IJournalItemDao
        ReadOnly Property CategoryDao As IDaoAll(Of Category)

        'ReadOnly Property ChartDao As IChartDao
        'ReadOnly Property ChequeDisbursementJournalDao As IChequeDisbursementJournalDao
        'ReadOnly Property ChequeDisbursementJournalItemDao As IJournalItemDao
        'ReadOnly Property CkdOiItemDao As ICkdOiItemDao
        'ReadOnly Property CsrOiItemDao As ICsrOiItemDao
        'ReadOnly Property CustomerDao As ICustomerDao
        'ReadOnly Property DesignationDao As IDesignationDao
        'ReadOnly Property DistributionSchemeDao As IDistributionSchemeDao
        'ReadOnly Property DistributionSchemeItemDao As IDistributionSchemeItemDao
        ReadOnly Property EmployeeDao As IDaoAll(Of Employee)

        ReadOnly Property GeneralJournalDao As IDao(Of GeneralJournal)
        ReadOnly Property GeneralJournalItemDao As IDaoJournalItems(Of JournalItem)
        ReadOnly Property JournalItemDao As IDaoJournalItems(Of JournalItem)

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