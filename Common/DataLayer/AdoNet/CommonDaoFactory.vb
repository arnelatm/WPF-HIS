
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class CommonDaoFactory
        Inherits DaoFactory
        Implements ICommonDaoFactory

        'Sub New(logoutDao As ILogoutDao)
        '    Me.LogoutDao = logoutDao
        'End Sub

        'Public ReadOnly Property CountryDao As ICountryDao Implements ICommonDaoFactory.CountryDao
        '    Get
        '        Return New CountryDao()
        '    End Get
        'End Property

        Public ReadOnly Property CommonDao As ICommonDao Implements ICommonDaoFactory.CommonDao
            Get
                Return New CommonDao()
            End Get
        End Property

        Public ReadOnly Property BranchDao As IBranchDao Implements ICommonDaoFactory.BranchDao
            Get
                Return New BranchDao()
            End Get
        End Property

        'Public ReadOnly Property ProfitCenterDao As IProfitCenterDao Implements ICommonDaoFactory.ProfitCenterDao
        '    Get
        '        Return New ProfitCenterDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CostCenterDao As ICostCenterDao Implements ICommonDaoFactory.CostCenterDao
        '    Get
        '        Return New CostCenterDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DepartmentDao As IDepartmentDao Implements ICommonDaoFactory.DepartmentDao
        '    Get
        '        Return New DepartmentDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ReligionDao As IReligionDao Implements ICommonDaoFactory.ReligionDao
        '    Get
        '        Return New ReligionDao()
        '    End Get
        'End Property

        'Public ReadOnly Property UserDao As IUserDao Implements ICommonDaoFactory.UserDao
        '    Get
        '        Return New UserDao()
        '    End Get
        'End Property

        ''Public ReadOnly Property LoginDao As ILoginDao Implements ICommonDaoFactory.LoginDao
        ''    Get
        ''        Return New LoginDao()
        ''    End Get
        ''End Property

        'Public ReadOnly Property LogoutDao As ILogoutDao Implements ICommonDaoFactory.LogoutDao

        ''Public ReadOnly Property SaltDao As ISaltDao Implements ICommonDaoFactory.SaltDao
        ''    Get
        ''        Return New SaltDao()
        ''    End Get
        ''End Property

        ''Public ReadOnly Property UserDao As IUserDao Implements ICommonDaoFactory.UserDao
        ''    Get
        ''        Return New UserDao()
        ''    End Get
        ''End Property

        'Public ReadOnly Property RevenueGroupDao As IRevenueGroupDao Implements ICommonDaoFactory.RevenueGroupDao
        '    Get
        '        Return New RevenueGroupDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PhoneTypeDao As IPhoneTypeDao Implements ICommonDaoFactory.PhoneTypeDao
        '    Get
        '        Return New PhoneTypeDao()
        '    End Get
        'End Property

        'Public ReadOnly Property OriginalMessagesDao As IOriginalMessagesDao Implements ICommonDaoFactory.OriginalMessagesDao
        '    Get
        '        Return New OriginalMessagesDao()
        '    End Get
        'End Property

        Public ReadOnly Property TranslatedMessagesDao As ITranslatedMessagesDao Implements ICommonDaoFactory.TranslatedMessagesDao
            Get
                Return New TranslatedMessagesDao()
            End Get
        End Property

        Public Overloads ReadOnly Property SecurityDao As ISecurityDao Implements ICommonDaoFactory.SecurityDao
            Get
                Return New SecurityDao()
            End Get
        End Property

    End Class

End Namespace