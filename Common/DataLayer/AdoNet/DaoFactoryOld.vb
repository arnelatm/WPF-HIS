
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryOld
        Inherits AATM.DataLayer.AdoNet.DaoFactoryOld
        Implements IDaoFactoryOld

        Sub New(logoutDao As ILogoutDao)
            Me.LogoutDao = logoutDao
        End Sub

        Public ReadOnly Property CountryDao As ICountryDao Implements IDaoFactoryOld.CountryDao
            Get
                Return New CountryDao()
            End Get
        End Property

        Public ReadOnly Property BranchDao As IBranchDao Implements IDaoFactoryOld.BranchDao
            Get
                Return New BranchDao()
            End Get
        End Property

        Public ReadOnly Property ProfitCenterDao As IProfitCenterDao Implements IDaoFactoryOld.ProfitCenterDao
            Get
                Return New ProfitCenterDao()
            End Get
        End Property

        Public ReadOnly Property CostCenterDao As ICostCenterDao Implements IDaoFactoryOld.CostCenterDao
            Get
                Return New CostCenterDao()
            End Get
        End Property

        Public ReadOnly Property DepartmentDao As IDepartmentDao Implements IDaoFactoryOld.DepartmentDao
            Get
                Return New DepartmentDao()
            End Get
        End Property

        Public ReadOnly Property ReligionDao As IReligionDao Implements IDaoFactoryOld.ReligionDao
            Get
                Return New ReligionDao()
            End Get
        End Property

        'Public ReadOnly Property UserDao As IUserDao Implements IDaoFactoryOld.UserDao
        '    Get
        '        Return New UserDao()
        '    End Get
        'End Property

        'Public ReadOnly Property LoginDao As ILoginDao Implements IDaoFactoryOld.LoginDao
        '    Get
        '        Return New LoginDao()
        '    End Get
        'End Property

        Public ReadOnly Property LogoutDao As ILogoutDao Implements IDaoFactoryOld.LogoutDao

        'Public ReadOnly Property SaltDao As ISaltDao Implements IDaoFactoryOld.SaltDao
        '    Get
        '        Return New SaltDao()
        '    End Get
        'End Property

        'Public ReadOnly Property UserDao As IUserDao Implements IDaoFactoryOld.UserDao
        '    Get
        '        Return New UserDao()
        '    End Get
        'End Property

        Public ReadOnly Property RevenueGroupDao As IRevenueGroupDao Implements IDaoFactoryOld.RevenueGroupDao
            Get
                Return New RevenueGroupDao()
            End Get
        End Property

        Public ReadOnly Property SecurityGroupDao As ISecurityGroupDao Implements IDaoFactoryOld.SecurityGroupDao
            Get
                Return New SecurityGroupDao()
            End Get
        End Property

        Public ReadOnly Property SecurityObjectDao As ISecurityObjectDao Implements IDaoFactoryOld.SecurityObjectDao
            Get
                Return New SecurityObjectDao()
            End Get
        End Property

        Public ReadOnly Property GroupAccessDao As IGroupAccessDao Implements IDaoFactoryOld.GroupAccessDao
            Get
                Return New GroupAccessDao()
            End Get
        End Property

        Public ReadOnly Property PhoneTypeDao As IPhoneTypeDao Implements IDaoFactoryOld.PhoneTypeDao
            Get
                Return New PhoneTypeDao()
            End Get
        End Property

        Public ReadOnly Property OriginalMessagesDao As IOriginalMessagesDao Implements IDaoFactoryOld.OriginalMessagesDao
            Get
                Return New OriginalMessagesDao()
            End Get
        End Property

        Public ReadOnly Property TranslatedMessagesDao As ITranslatedMessagesDao Implements IDaoFactoryOld.TranslatedMessagesDao
            Get
                Return New TranslatedMessagesDao()
            End Get
        End Property


        Public Overloads ReadOnly Property SecurityDao As ISecurityDao Implements IDaoFactoryOld.SecurityDao
            Get
                Return New SecurityDao()
            End Get
        End Property

    End Class

End Namespace