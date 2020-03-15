Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryAccounts
        Inherits DaoFactoryCommon
        Implements IDaoFactoryAccounts

        Public ReadOnly Property DaoAccounts As IDaoAccounts Implements IDaoFactoryAccounts.DaoAccounts
            Get
                Return New DaoAccounts()
            End Get
        End Property

        Public ReadOnly Property BankDao As IDaoAll(Of Bank) Implements IDaoFactoryAccounts.BankDao
        Public ReadOnly Property CashCodeDao As IDaoAll(Of CashCode) Implements IDaoFactoryAccounts.CashCodeDao

        Public ReadOnly Property SupplierDao As IDaoAll(Of Supplier) Implements IDaoFactoryAccounts.SupplierDao

        Public ReadOnly Property ApJournalDao As IDao(Of ApJournal) Implements IDaoFactoryAccounts.ApJournalDao
            Get
                Return New ApJournalDao()
            End Get
        End Property

        Public ReadOnly Property ApJournalItemDao As IDaoJournalItems Implements IDaoFactoryAccounts.ApJournalItemDao
            Get
                Return New ApJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property ApOpenInvoiceDao As IDaoOpenInvoice(Of ApOpenInvoice) Implements IDaoFactoryAccounts.ApOpenInvoiceDao
            Get
                Return New ApOpenInvoiceDao()
            End Get
        End Property

        Public ReadOnly Property ArJournalDao As IDao(Of ArJournal) Implements IDaoFactoryAccounts.ArJournalDao
            Get
                Return New ArJournalDao()
            End Get
        End Property

        Public ReadOnly Property ArJournalItemDao As IDaoJournalItems Implements IDaoFactoryAccounts.ArJournalItemDao
            Get
                Return New ArJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property ArOpenInvoiceDao As IDaoOpenInvoice(Of ArOpenInvoice) Implements IDaoFactoryAccounts.ArOpenInvoiceDao
            Get
                Return New ArOpenInvoiceDao()
            End Get
        End Property

        Public ReadOnly Property GeneralJournalDao As IDao(Of GeneralJournal) Implements IDaoFactoryAccounts.GeneralJournalDao
            Get
                Return New GeneralJournalDao()
            End Get
        End Property

        Public ReadOnly Property GeneralJournalItemDao As IDaoJournalItems Implements IDaoFactoryAccounts.GeneralJournalItemDao
            Get
                Return New GeneralJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property CategoryDao As IDaoAll(Of Category) Implements IDaoFactoryAccounts.CategoryDao
            Get
                Return New CategoryDao()
            End Get
        End Property

        Public ReadOnly Property ChartDao As IDaoAll(Of Chart) Implements IDaoFactoryAccounts.ChartDao
            Get
                Return New ChartDao()
            End Get
        End Property

        Public ReadOnly Property CustomerDao As IDaoAll(Of Customer) Implements IDaoFactoryAccounts.CustomerDao
        Public ReadOnly Property DesignationDao As IDaoAll(Of Designation) Implements IDaoFactoryAccounts.DesignationDao

        Public ReadOnly Property EmployeeDao As IDaoAll(Of Employee) Implements IDaoFactoryAccounts.EmployeeDao
            Get
                Return New EmployeeDao()
            End Get
        End Property

        Public ReadOnly Property PurchaseItemDao As IDaoAll(Of PurchaseItem) Implements IDaoFactoryAccounts.PurchaseItemDao

        Public ReadOnly Property JournalItemDao As IDaoJournalItems Implements IDaoFactoryAccounts.JournalItemDao
            Get
                Return New JournalItemDao()
            End Get
        End Property

        'Public ReadOnly Property ArJournalDao As IArJournalDao Implements IDaoFactoryCommon.ArJournalDao
        '    Get
        '        Return New ArJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ArJournalItemDao As IJournalItemDao Implements IDaoFactoryCommon.ArJournalItemDao
        '    Get
        '        Return New ArJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ArOpenInvoiceDao As IArOpenInvoiceDao Implements IDaoFactoryCommon.ArOpenInvoiceDao
        '    Get
        '        Return New ArOpenInvoiceDao()
        '    End Get
        'End Property

        'Public ReadOnly Property BankDao As IBankDao Implements IDaoFactoryCommon.BankDao
        '    Get
        '        Return New BankDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CadOiItemDao As ICadOiItemDao Implements IDaoFactoryCommon.CadOiItemDao
        '    Get
        '        Return New CadOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashDisbursementJournalDao As ICashDisbursementJournalDao Implements IDaoFactoryCommon.CashDisbursementJournalDao
        '    Get
        '        Return New CashDisbursementJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashDisbursementJournalItemDao As IJournalItemDao Implements IDaoFactoryCommon.CashDisbursementJournalItemDao
        '    Get
        '        Return New CashDisbursementJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashReceiptJournalDao As ICashReceiptJournalDao Implements IDaoFactoryCommon.CashReceiptJournalDao
        '    Get
        '        Return New CashReceiptJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashReceiptJournalItemDao As IJournalItemDao Implements IDaoFactoryCommon.CashReceiptJournalItemDao
        '    Get
        '        Return New CashReceiptJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ChartDao As IChartDao Implements IDaoFactoryCommon.ChartDao
        '    Get
        '        Return New ChartDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CkdOiItemDao As ICkdOiItemDao Implements IDaoFactoryCommon.CkdOiItemDao
        '    Get
        '        Return New CkdOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CsrOiItemDao As ICsrOiItemDao Implements IDaoFactoryCommon.CsrOiItemDao
        '    Get
        '        Return New CsrOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ChequeDisbursementJournalDao As IChequeDisbursementJournalDao Implements IDaoFactoryCommon.ChequeDisbursementJournalDao
        '    Get
        '        Return New ChequeDisbursementJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ChequeDisbursementJournalItemDao As IJournalItemDao Implements IDaoFactoryCommon.ChequeDisbursementJournalItemDao
        '    Get
        '        Return New ChequeDisbursementJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CustomerDao As ICustomerDao Implements IDaoFactoryCommon.CustomerDao
        '    Get
        '        Return New CustomerDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DesignationDao As IDesignationDao Implements IDaoFactoryCommon.DesignationDao
        '    Get
        '        Return New DesignationDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DistributionSchemeDao As IDistributionSchemeDao Implements IDaoFactoryCommon.DistributionSchemeDao
        '    Get
        '        Return New DistributionSchemeDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DistributionSchemeItemDao As IDistributionSchemeItemDao Implements IDaoFactoryCommon.DistributionSchemeItemDao
        '    Get
        '        Return New DistributionSchemeItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property EmployeeDao As IEmployeeDao Implements IDaoFactoryCommon.EmployeeDao
        '    Get
        '        Return New EmployeeDao()
        '    End Get
        'End Property

        'Public ReadOnly Property JournalItemDaoProperty As Object()
        '    Get
        '        Return New JournalItemDao
        '    End Get
        'End Property

        'Public ReadOnly Property JournalItemDao As IDaoChild(Of JournalItem) Implements IDaoFactoryAccounts.JournalItemDao
        '    Get
        '        Return New JournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PcsOiItemDao As IPcsOiItemDao Implements IDaoFactoryCommon.PcsOiItemDao
        '    Get
        '        Return New PcsOiItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PurchaseItemDao As IPurchaseItemDao Implements IDaoFactoryCommon.PurchaseItemDao
        '    Get
        '        Return New PurchaseItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PurchaseJournalDao As IPurchaseJournalDao Implements IDaoFactoryCommon.PurchaseJournalDao
        '    Get
        '        Return New PurchaseJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PurchaseJournalItemDao As IJournalItemDao Implements IDaoFactoryCommon.PurchaseJournalItemDao
        '    Get
        '        Return New PurchaseJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SupplierDao As ISupplierDao Implements IDaoFactoryCommon.SupplierDao
        '    Get
        '        Return New SupplierDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SalesJournalDao As ISalesJournalDao Implements IDaoFactoryCommon.SalesJournalDao
        '    Get
        '        Return New SalesJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SalesJournalItemDao As IJournalItemDao Implements IDaoFactoryCommon.SalesJournalItemDao
        '    Get
        '        Return New SalesJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SalesCashItemDao As ISalesCashItemDao Implements IDaoFactoryCommon.SalesCashItemDao
        '    Get
        '        Return New SalesCashItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CashCodeDao As ICashCodeDao Implements IDaoFactoryCommon.CashCodeDao
        '    Get
        '        Return New CashCodeDao()
        '    End Get
        'End Property

        'Public ReadOnly Property AccountReconciliationDao As IAccountReconciliationDao Implements IDaoFactoryCommon.AccountReconciliationDao
        '    Get
        '        Return New AccountReconciliationDao()
        '    End Get
        'End Property

        'Public ReadOnly Property AccountReconciliationItemDao As IAccountReconciliationItemDao Implements IDaoFactoryCommon.AccountReconciliationItemDao
        '    Get
        '        Return New AccountReconciliationItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PettyCashJournalDao As IPettyCashJournalDao Implements IDaoFactoryCommon.PettyCashJournalDao
        '    Get
        '        Return New PettyCashJournalDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PettyCashJournalItemDao As IJournalItemDao Implements IDaoFactoryCommon.PettyCashJournalItemDao
        '    Get
        '        Return New PettyCashJournalItemDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ReconciledDao As IReconciledDao Implements IDaoFactoryCommon.ReconciledDao
        '    Get
        '        Return New ReconciledDao()
        '    End Get
        'End Property

    End Class

End Namespace