Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class AccountsDaoFactory
        Inherits CommonDaoFactory
        Implements IAccountsDaoFactory

        Public ReadOnly Property AccountsDao As IAccountsDao Implements IAccountsDaoFactory.AccountsDao
            Get
                Return New AccountsDao()
            End Get
        End Property

        Public ReadOnly Property ApJournalDao As IDao(Of ApJournal) Implements IAccountsDaoFactory.ApJournalDao
            Get
                Return New ApJournalDao()
            End Get
        End Property

        'Public ReadOnly Property ApOpenInvoiceDao As IApOpenInvoiceDao Implements ICommonDaoFactory.ApOpenInvoiceDao
        '    Get
        '        Return New ApOpenInvoiceDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ArJournalDao As IArJournalDao Implements ICommonDaoFactory.ArJournalDao
        '    Get
        '        Return New ArJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ArJournalItemDao As IJournalItemDao Implements ICommonDaoFactory.ArJournalItemDao
        '    Get
        '        Return New ArJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ArOpenInvoiceDao As IArOpenInvoiceDao Implements ICommonDaoFactory.ArOpenInvoiceDao
        '    Get
        '        Return New ArOpenInvoiceDao()
        '    End Get
        'End Property

        'Public ReadOnly Property BankDao As IBankDao Implements ICommonDaoFactory.BankDao
        '    Get
        '        Return New BankDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CadOiItemDao As ICadOiItemDao Implements ICommonDaoFactory.CadOiItemDao
        '    Get
        '        Return New CadOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashDisbursementJournalDao As ICashDisbursementJournalDao Implements ICommonDaoFactory.CashDisbursementJournalDao
        '    Get
        '        Return New CashDisbursementJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashDisbursementJournalItemDao As IJournalItemDao Implements ICommonDaoFactory.CashDisbursementJournalItemDao
        '    Get
        '        Return New CashDisbursementJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashReceiptJournalDao As ICashReceiptJournalDao Implements ICommonDaoFactory.CashReceiptJournalDao
        '    Get
        '        Return New CashReceiptJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashReceiptJournalItemDao As IJournalItemDao Implements ICommonDaoFactory.CashReceiptJournalItemDao
        '    Get
        '        Return New CashReceiptJournalItemDao()
        '    End Get
        'End Property

        Public ReadOnly Property CategoryDao As IDaoAll(Of Category) Implements IAccountsDaoFactory.CategoryDao
            Get
                Return New CategoryDao()
            End Get
        End Property

        Public ReadOnly Property EmployeeDao As IDaoAll(Of Employee) Implements IAccountsDaoFactory.EmployeeDao
            Get
                Return New EmployeeDao()
            End Get
        End Property

        Public ReadOnly Property ApOpenInvoiceDao As IDaoChild(Of ApOpenInvoice) Implements IAccountsDaoFactory.ApOpenInvoiceDao
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        Public ReadOnly Property ApJournalItemDao As IDaoChild(Of JournalItem) Implements IAccountsDaoFactory.ApJournalItemDao
            Get
                Throw New NotImplementedException()
            End Get
        End Property

        'Public ReadOnly Property ChartDao As IChartDao Implements ICommonDaoFactory.ChartDao
        '    Get
        '        Return New ChartDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CkdOiItemDao As ICkdOiItemDao Implements ICommonDaoFactory.CkdOiItemDao
        '    Get
        '        Return New CkdOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CsrOiItemDao As ICsrOiItemDao Implements ICommonDaoFactory.CsrOiItemDao
        '    Get
        '        Return New CsrOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ChequeDisbursementJournalDao As IChequeDisbursementJournalDao Implements ICommonDaoFactory.ChequeDisbursementJournalDao
        '    Get
        '        Return New ChequeDisbursementJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ChequeDisbursementJournalItemDao As IJournalItemDao Implements ICommonDaoFactory.ChequeDisbursementJournalItemDao
        '    Get
        '        Return New ChequeDisbursementJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CustomerDao As ICustomerDao Implements ICommonDaoFactory.CustomerDao
        '    Get
        '        Return New CustomerDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DesignationDao As IDesignationDao Implements ICommonDaoFactory.DesignationDao
        '    Get
        '        Return New DesignationDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DistributionSchemeDao As IDistributionSchemeDao Implements ICommonDaoFactory.DistributionSchemeDao
        '    Get
        '        Return New DistributionSchemeDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DistributionSchemeItemDao As IDistributionSchemeItemDao Implements ICommonDaoFactory.DistributionSchemeItemDao
        '    Get
        '        Return New DistributionSchemeItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property EmployeeDao As IEmployeeDao Implements ICommonDaoFactory.EmployeeDao
        '    Get
        '        Return New EmployeeDao()
        '    End Get
        'End Property
        Public ReadOnly Property JournalItemDao As IDaoJournalItems(Of JournalItem) Implements IAccountsDaoFactory.JournalItemDao
            Get
                Return New JournalItemDao()
            End Get
        End Property

        'Public ReadOnly Property JournalItemDaoProperty As Object()
        '    Get
        '        Return New JournalItemDao
        '    End Get
        'End Property

        Public ReadOnly Property GeneralJournalDao As IDao(Of GeneralJournal) Implements IAccountsDaoFactory.GeneralJournalDao
            Get
                Return New GeneralJournalDao()
            End Get
        End Property

        Public ReadOnly Property GeneralJournalItemDao As IDaoJournalItems(Of JournalItem) Implements IAccountsDaoFactory.GeneralJournalItemDao
            Get
                Return New GeneralJournalItemDao()
            End Get
        End Property

        'Public ReadOnly Property JournalItemDao As IDaoChild(Of JournalItem) Implements IAccountsDaoFactory.JournalItemDao
        '    Get
        '        Return New JournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PcsOiItemDao As IPcsOiItemDao Implements ICommonDaoFactory.PcsOiItemDao
        '    Get
        '        Return New PcsOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PurchaseItemDao As IPurchaseItemDao Implements ICommonDaoFactory.PurchaseItemDao
        '    Get
        '        Return New PurchaseItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PurchaseJournalDao As IPurchaseJournalDao Implements ICommonDaoFactory.PurchaseJournalDao
        '    Get
        '        Return New PurchaseJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PurchaseJournalItemDao As IJournalItemDao Implements ICommonDaoFactory.PurchaseJournalItemDao
        '    Get
        '        Return New PurchaseJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SupplierDao As ISupplierDao Implements ICommonDaoFactory.SupplierDao
        '    Get
        '        Return New SupplierDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SalesJournalDao As ISalesJournalDao Implements ICommonDaoFactory.SalesJournalDao
        '    Get
        '        Return New SalesJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SalesJournalItemDao As IJournalItemDao Implements ICommonDaoFactory.SalesJournalItemDao
        '    Get
        '        Return New SalesJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SalesCashItemDao As ISalesCashItemDao Implements ICommonDaoFactory.SalesCashItemDao
        '    Get
        '        Return New SalesCashItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashCodeDao As ICashCodeDao Implements ICommonDaoFactory.CashCodeDao
        '    Get
        '        Return New CashCodeDao()
        '    End Get
        'End Property

        'Public ReadOnly Property AccountReconciliationDao As IAccountReconciliationDao Implements ICommonDaoFactory.AccountReconciliationDao
        '    Get
        '        Return New AccountReconciliationDao()
        '    End Get
        'End Property

        'Public ReadOnly Property AccountReconciliationItemDao As IAccountReconciliationItemDao Implements ICommonDaoFactory.AccountReconciliationItemDao
        '    Get
        '        Return New AccountReconciliationItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PettyCashJournalDao As IPettyCashJournalDao Implements ICommonDaoFactory.PettyCashJournalDao
        '    Get
        '        Return New PettyCashJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PettyCashJournalItemDao As IJournalItemDao Implements ICommonDaoFactory.PettyCashJournalItemDao
        '    Get
        '        Return New PettyCashJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ReconciledDao As IReconciledDao Implements ICommonDaoFactory.ReconciledDao
        '    Get
        '        Return New ReconciledDao()
        '    End Get
        'End Property

    End Class

End Namespace