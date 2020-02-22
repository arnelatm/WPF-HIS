

' ** GoF Design Pattern: Factory.
Namespace DataLayer
    Public Interface IDaoFactoryOld
        Inherits AATM.DataLayer.IDaoFactoryOld

        ReadOnly Property ChartDao As IChartDao
        ReadOnly Property SupplierDao As ISupplierDao
        ReadOnly Property CustomerDao As ICustomerDao
        ReadOnly Property EmployeeDao As IEmployeeDao
        ReadOnly Property BankDao As IBankDao
        ReadOnly Property GeneralJournalDao As IGeneralJournalDao
        ReadOnly Property GeneralJournalItemDao As IJournalItemDao
        ReadOnly Property PurchaseJournalDao As IPurchaseJournalDao
        ReadOnly Property PurchaseJournalItemDao As IJournalItemDao
        ReadOnly Property CashDisbursementJournalDao As ICashDisbursementJournalDao
        ReadOnly Property CashDisbursementJournalItemDao As IJournalItemDao
        ReadOnly Property CashReceiptJournalDao As ICashReceiptJournalDao
        ReadOnly Property CashReceiptJournalItemDao As IJournalItemDao
        ReadOnly Property JournalItemDao As IJournalItemDao
        ReadOnly Property DistributionSchemeDao As IDistributionSchemeDao
        ReadOnly Property DistributionSchemeItemDao As IDistributionSchemeItemDao
        ReadOnly Property DesignationDao As IDesignationDao
    End Interface
End NameSpace