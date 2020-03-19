' ** GoF Design Pattern: Factory.
Imports AATM.Common.DataLayer

Namespace DataLayer

    Public Interface IDaoFactoryAccounts
        Inherits IDaoFactoryCommon

        'ReadOnly Property DaoAccounts As IDaoAccounts

        'Function CreateDao(classBaseName As String)

        'ReadOnly Property BankDao As IDaoAll(Of Bank)
        'ReadOnly Property CashCodeDao As IDaoAll(Of CashCode)
        'ReadOnly Property CategoryDao As IDaoAll(Of Category)
        'ReadOnly Property ChartDao As IDaoAll(Of Chart)
        'ReadOnly Property CustomerDao As IDaoAll(Of Customer)
        'ReadOnly Property DesignationDao As IDaoAll(Of Designation)
        'ReadOnly Property DistributionSchemeDao As IDao(Of DistributionScheme)
        'ReadOnly Property EmployeeDao As IDaoAll(Of Employee)
        'ReadOnly Property PurchaseItemDao As IDaoAll(Of PurchaseItem)
        'ReadOnly Property SupplierDao As IDaoAll(Of Supplier)

        'ReadOnly Property GeneralJournalDao As IDao(Of GeneralJournal)

        ''ReadOnly Property AccountReconciliationDao As IDao(Of AccountReconciliation)
        'ReadOnly Property ApJournalDao As IDao(Of ApJournal)
        'ReadOnly Property ArJournalDao As IDao(Of ArJournal)

        ''ReadOnly Property CashDisbursementJournalDao As IDao(Of CashDisbursementJournal)
        ''ReadOnly Property CashReceiptJournalDao As IDao(Of CashReceiptJournal)
        ''ReadOnly Property CheckDisbursementJournalDao As IDao(Of CheckDisbursementJournal)
        ''ReadOnly Property PettyCashJournalDao As IDao(Of PettyCashJournal)
        ''ReadOnly Property PurchaseJournalDao As IDao(Of PurchaseJournal)
        ''ReadOnly Property SalesJournalDao As IDao(Of SalesJournal)
        ''ReadOnly Property SalesCashItemDao As ISalesCashItemDao

        'ReadOnly Property ApJournalItemDao As IDaoChild(Of JournalItem)
        'ReadOnly Property ArJournalItemDao As IDaoChild(Of JournalItem)
        'ReadOnly Property DistributionSchemeItemDao As IDaoChild(Of DistributionSchemeItem)
        'ReadOnly Property GeneralJournalItemDao As IDaoChild(Of JournalItem)
        'ReadOnly Property JournalItemDao As IDaoChild(Of JournalItem)

        ''ReadOnly Property CashDisbursementJournalItemDao As IDaoChild(Of JournalItem)
        ''ReadOnly Property CashReceiptJournalItemDao As IDaoChild(Of JournalItem)
        ''ReadOnly Property CheckDisbursementJournalItemDao As IDaoChild(Of JournalItem)
        ''ReadOnly Property PettyCashJournalItemDao As IDaoChild(Of JournalItem)
        ''ReadOnly Property PurchaseJournalItemDao As IDaoChild(Of JournalItem)
        ''ReadOnly Property SalesJournalItemDao As IDaoChild(Of JournalItem)

        'ReadOnly Property ArOpenInvoiceDao As IDaoOpenInvoice(Of ArOpenInvoice)
        'ReadOnly Property ApOpenInvoiceDao As IDaoOpenInvoice(Of ApOpenInvoice)

        ''ReadOnly Property AccountReconciliationItemDao As IAccountReconciliationItemDao

        ''ReadOnly Property CkdOiItemDao As ICkdOiItemDao
        ''ReadOnly Property CsrOiItemDao As ICsrOiItemDao
        ''ReadOnly Property PcsOiItemDao As IPcsOiItemDao
        ''ReadOnly Property ReconciledDao As IReconciledDao
        ''ReadOnly Property CadOiItemDao As ICadOiItemDao

    End Interface

End Namespace