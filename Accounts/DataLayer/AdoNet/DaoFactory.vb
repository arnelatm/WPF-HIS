

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactory
        Inherits AATM.DataLayer.AdoNet.DaoFactory
        Implements IDaoFactory

        Public ReadOnly Property ApJournalDao As IApJournalDao Implements IDaoFactory.ApJournalDao
            Get
                Return New ApJournalDao()
            End Get
        End Property

        Public ReadOnly Property ApJournalItemDao As IJournalItemDao Implements IDaoFactory.ApJournalItemDao
            Get
                Return New ApJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property ApOpenInvoiceDao As IApOpenInvoiceDao Implements IDaoFactory.ApOpenInvoiceDao
            Get
                Return New ApOpenInvoiceDao()
            End Get
        End Property

        Public ReadOnly Property ArJournalDao As IArJournalDao Implements IDaoFactory.ArJournalDao
            Get
                Return New ArJournalDao()
            End Get
        End Property

        Public ReadOnly Property ArJournalItemDao As IJournalItemDao Implements IDaoFactory.ArJournalItemDao
            Get
                Return New ArJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property ArOpenInvoiceDao As IArOpenInvoiceDao Implements IDaoFactory.ArOpenInvoiceDao
            Get
                Return New ArOpenInvoiceDao()
            End Get
        End Property

        Public ReadOnly Property BankDao As IBankDao Implements IDaoFactory.BankDao
            Get
                Return New BankDao()
            End Get
        End Property

        Public ReadOnly Property CadOiItemDao As ICadOiItemDao Implements IDaoFactory.CadOiItemDao
            Get
                Return New CadOiItemDao()
            End Get
        End Property

        Public ReadOnly Property CashDisbursementJournalDao As ICashDisbursementJournalDao Implements IDaoFactory.CashDisbursementJournalDao
            Get
                Return New CashDisbursementJournalDao()
            End Get
        End Property

        Public ReadOnly Property CashDisbursementJournalItemDao As IJournalItemDao Implements IDaoFactory.CashDisbursementJournalItemDao
            Get
                Return New CashDisbursementJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property CashReceiptJournalDao As ICashReceiptJournalDao Implements IDaoFactory.CashReceiptJournalDao
            Get
                Return New CashReceiptJournalDao()
            End Get
        End Property

        Public ReadOnly Property CashReceiptJournalItemDao As IJournalItemDao Implements IDaoFactory.CashReceiptJournalItemDao
            Get
                Return New CashReceiptJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property CategoryDao As ICategoryDao Implements IDaoFactory.CategoryDao
            Get
                Return New CategoryDao()
            End Get
        End Property

        Public ReadOnly Property ChartDao As IChartDao Implements IDaoFactory.ChartDao
            Get
                Return New ChartDao()
            End Get
        End Property

        Public ReadOnly Property CkdOiItemDao As ICkdOiItemDao Implements IDaoFactory.CkdOiItemDao
            Get
                Return New CkdOiItemDao()
            End Get
        End Property

        Public ReadOnly Property CsrOiItemDao As ICsrOiItemDao Implements IDaoFactory.CsrOiItemDao
            Get
                Return New CsrOiItemDao()
            End Get
        End Property

        Public ReadOnly Property ChequeDisbursementJournalDao As IChequeDisbursementJournalDao Implements IDaoFactory.ChequeDisbursementJournalDao
            Get
                Return New ChequeDisbursementJournalDao()
            End Get
        End Property

        Public ReadOnly Property ChequeDisbursementJournalItemDao As IJournalItemDao Implements IDaoFactory.ChequeDisbursementJournalItemDao
            Get
                Return New ChequeDisbursementJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property CustomerDao As ICustomerDao Implements IDaoFactory.CustomerDao
            Get
                Return New CustomerDao()
            End Get
        End Property

        Public ReadOnly Property DesignationDao As IDesignationDao Implements IDaoFactory.DesignationDao
            Get
                Return New DesignationDao()
            End Get
        End Property

        Public ReadOnly Property DistributionSchemeDao As IDistributionSchemeDao Implements IDaoFactory.DistributionSchemeDao
            Get
                Return New DistributionSchemeDao()
            End Get
        End Property

        Public ReadOnly Property DistributionSchemeItemDao As IDistributionSchemeItemDao Implements IDaoFactory.DistributionSchemeItemDao
            Get
                Return New DistributionSchemeItemDao()
            End Get
        End Property

        Public ReadOnly Property EmployeeDao As IEmployeeDao Implements IDaoFactory.EmployeeDao
            Get
                Return New EmployeeDao()
            End Get
        End Property

        Public ReadOnly Property GeneralJournalDao As IGeneralJournalDao Implements IDaoFactory.GeneralJournalDao
            Get
                Return New GeneralJournalDao()
            End Get
        End Property

        Public ReadOnly Property GeneralJournalItemDao As IJournalItemDao Implements IDaoFactory.GeneralJournalItemDao
            Get
                Return New GeneralJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property JournalItemDao As IJournalItemDao Implements IDaoFactory.JournalItemDao
            Get
                Return New JournalItemDao()
            End Get
        End Property

        Public ReadOnly Property PcsOiItemDao As IPcsOiItemDao Implements IDaoFactory.PcsOiItemDao
            Get
                Return New PcsOiItemDao()
            End Get
        End Property

        Public ReadOnly Property PurchaseItemDao As IPurchaseItemDao Implements IDaoFactory.PurchaseItemDao
            Get
                Return New PurchaseItemDao()
            End Get
        End Property

        Public ReadOnly Property PurchaseJournalDao As IPurchaseJournalDao Implements IDaoFactory.PurchaseJournalDao
            Get
                Return New PurchaseJournalDao()
            End Get
        End Property

        Public ReadOnly Property PurchaseJournalItemDao As IJournalItemDao Implements IDaoFactory.PurchaseJournalItemDao
            Get
                Return New PurchaseJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property SupplierDao As ISupplierDao Implements IDaoFactory.SupplierDao
            Get
                Return New SupplierDao()
            End Get
        End Property

        Public ReadOnly Property SalesJournalDao As ISalesJournalDao Implements IDaoFactory.SalesJournalDao
            Get
                Return New SalesJournalDao()
            End Get
        End Property

        Public ReadOnly Property SalesJournalItemDao As IJournalItemDao Implements IDaoFactory.SalesJournalItemDao
            Get
                Return New SalesJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property SalesCashItemDao As ISalesCashItemDao Implements IDaoFactory.SalesCashItemDao
            Get
                Return New SalesCashItemDao()
            End Get
        End Property

        Public ReadOnly Property CashCodeDao As ICashCodeDao Implements IDaoFactory.CashCodeDao
            Get
                Return New CashCodeDao()
            End Get
        End Property

        Public ReadOnly Property AccountReconciliationDao As IAccountReconciliationDao Implements IDaoFactory.AccountReconciliationDao
            Get
                Return New AccountReconciliationDao()
            End Get
        End Property

        Public ReadOnly Property AccountReconciliationItemDao As IAccountReconciliationItemDao Implements IDaoFactory.AccountReconciliationItemDao
            Get
                Return New AccountReconciliationItemDao()
            End Get
        End Property

        Public ReadOnly Property PettyCashJournalDao As IPettyCashJournalDao Implements IDaoFactory.PettyCashJournalDao
            Get
                Return New PettyCashJournalDao()
            End Get
        End Property

        Public ReadOnly Property PettyCashJournalItemDao As IJournalItemDao Implements IDaoFactory.PettyCashJournalItemDao
            Get
                Return New PettyCashJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property ReconciledDao As IReconciledDao Implements IDaoFactory.ReconciledDao
            Get
                Return New ReconciledDao()
            End Get
        End Property

    End Class

End Namespace