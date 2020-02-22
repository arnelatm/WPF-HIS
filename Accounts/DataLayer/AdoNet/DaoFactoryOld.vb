Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryOld
        Inherits AATM.DataLayer.AdoNet.DaoFactoryOld
        Implements IDaoFactoryOld

        Public ReadOnly Property ChartDao As IChartDao Implements IDaoFactoryOld.ChartDao
            Get
                Return New ChartDao()
            End Get
        End Property

        Public ReadOnly Property SupplierDao As ISupplierDao Implements IDaoFactoryOld.SupplierDao
            Get
                Return New SupplierDao()
            End Get
        End Property

        Public ReadOnly Property CustomerDao As ICustomerDao Implements IDaoFactoryOld.CustomerDao
            Get
                Return New CustomerDao()
            End Get
        End Property

        Public ReadOnly Property EmployeeDao As IEmployeeDao Implements IDaoFactoryOld.EmployeeDao
            Get
                Return New EmployeeDao()
            End Get
        End Property

        Public ReadOnly Property BankDao As IBankDao Implements IDaoFactoryOld.BankDao
            Get
                Return New BankDao()
            End Get
        End Property

        Public ReadOnly Property GeneralJournalDao As IGeneralJournalDao Implements IDaoFactoryOld.GeneralJournalDao
            Get
                Return New GeneralJournalDao()
            End Get
        End Property

        Public ReadOnly Property GeneralJournalItemDao As IJournalItemDao Implements IDaoFactoryOld.GeneralJournalItemDao
            Get
                Return New GeneralJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property PurchaseJournalDao As IPurchaseJournalDao Implements IDaoFactoryOld.PurchaseJournalDao
            Get
                Return New PurchaseJournalDao()
            End Get
        End Property

        Public ReadOnly Property PurchaseJournalItemDao As IJournalItemDao Implements IDaoFactoryOld.PurchaseJournalItemDao
            Get
                Return New PurchaseJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property CashDisbursementJournalDao As ICashDisbursementJournalDao Implements IDaoFactoryOld.CashDisbursementJournalDao
            Get
                Return New CashDisbursementJournalDao()
            End Get
        End Property

        Public ReadOnly Property CashDisbursementJournalItemDao As IJournalItemDao Implements IDaoFactoryOld.CashDisbursementJournalItemDao
            Get
                Return New CashDisbursementJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property CashReceiptJournalDao As ICashReceiptJournalDao Implements IDaoFactoryOld.CashReceiptJournalDao
            Get
                Return New CashReceiptJournalDao()
            End Get
        End Property

        Public ReadOnly Property CashReceiptJournalItemDao As IJournalItemDao Implements IDaoFactoryOld.CashReceiptJournalItemDao
            Get
                Return New CashReceiptJournalItemDao()
            End Get
        End Property

        Public ReadOnly Property JournalItemDao As IJournalItemDao Implements IDaoFactoryOld.JournalItemDao
            Get
                Return New JournalItemDao()
            End Get
        End Property

        Public ReadOnly Property DistributionSchemeDao As IDistributionSchemeDao Implements IDaoFactoryOld.DistributionSchemeDao
            Get
                Return New DistributionSchemeDao()
            End Get
        End Property

        Public ReadOnly Property DistributionSchemeItemDao As IDistributionSchemeItemDao Implements IDaoFactoryOld.DistributionSchemeItemDao
            Get
                Return New DistributionSchemeItemDao()
            End Get
        End Property

        Public ReadOnly Property DesignationDao As IDesignationDao Implements IDaoFactoryOld.DesignationDao
            Get
                Return New DesignationDao()
            End Get
        End Property

    End Class

End Namespace