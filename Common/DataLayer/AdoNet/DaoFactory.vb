
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactory
        'Inherits AATM.DataLayer.AdoNet.DaoFactory
        Implements IDaoFactory

        Sub New(logoutDao As ILogoutDao)
            Me.LogoutDao = logoutDao
        End Sub

        Public ReadOnly Property CountryDao As ICountryDao Implements IDaoFactory.CountryDao
            Get
                Return New CountryDao()
            End Get
        End Property

        Public ReadOnly Property BranchDao As IBranchDao Implements IDaoFactory.BranchDao
            Get
                Return New BranchDao()
            End Get
        End Property

        Public ReadOnly Property ProfitCenterDao As IProfitCenterDao Implements IDaoFactory.ProfitCenterDao
            Get
                Return New ProfitCenterDao()
            End Get
        End Property

        Public ReadOnly Property CostCenterDao As ICostCenterDao Implements IDaoFactory.CostCenterDao
            Get
                Return New CostCenterDao()
            End Get
        End Property

        Public ReadOnly Property DepartmentDao As IDepartmentDao Implements IDaoFactory.DepartmentDao
            Get
                Return New DepartmentDao()
            End Get
        End Property

        Public ReadOnly Property ReligionDao As IReligionDao Implements IDaoFactory.ReligionDao
            Get
                Return New ReligionDao()
            End Get
        End Property

        Public ReadOnly Property UserDao As IUserDao Implements IDaoFactory.UserDao
            Get
                Return New UserDao()
            End Get
        End Property

        'Public ReadOnly Property LoginDao As ILoginDao Implements IDaoFactory.LoginDao
        '    Get
        '        Return New LoginDao()
        '    End Get
        'End Property

        Public ReadOnly Property LogoutDao As ILogoutDao Implements IDaoFactory.LogoutDao

        'Public ReadOnly Property SaltDao As ISaltDao Implements IDaoFactory.SaltDao
        '    Get
        '        Return New SaltDao()
        '    End Get
        'End Property

        'Public ReadOnly Property UserDao As IUserDao Implements IDaoFactory.UserDao
        '    Get
        '        Return New UserDao()
        '    End Get
        'End Property

        Public ReadOnly Property RevenueGroupDao As IRevenueGroupDao Implements IDaoFactory.RevenueGroupDao
            Get
                Return New RevenueGroupDao()
            End Get
        End Property

        Public ReadOnly Property SecurityGroupDao As ISecurityGroupDao Implements IDaoFactory.SecurityGroupDao
            Get
                Return New SecurityGroupDao()
            End Get
        End Property

        Public ReadOnly Property SecurityObjectDao As ISecurityObjectDao Implements IDaoFactory.SecurityObjectDao
            Get
                Return New SecurityObjectDao()
            End Get
        End Property

        Public ReadOnly Property GroupAccessDao As IGroupAccessDao Implements IDaoFactory.GroupAccessDao
            Get
                Return New GroupAccessDao()
            End Get
        End Property

        Public ReadOnly Property PhoneTypeDao As IPhoneTypeDao Implements IDaoFactory.PhoneTypeDao
            Get
                Return New PhoneTypeDao()
            End Get
        End Property

        Public ReadOnly Property OriginalMessagesDao As IOriginalMessagesDao Implements IDaoFactory.OriginalMessagesDao
            Get
                Return New OriginalMessagesDao()
            End Get
        End Property

        Public ReadOnly Property TranslatedMessagesDao As ITranslatedMessagesDao Implements IDaoFactory.TranslatedMessagesDao
            Get
                Return New TranslatedMessagesDao()
            End Get
        End Property


        Public Overloads ReadOnly Property SecurityDao As ISecurityDao Implements IDaoFactory.SecurityDao
            Get
                Return New SecurityDao()
            End Get
        End Property

    End Class

End Namespace