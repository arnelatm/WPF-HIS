
Imports AATM.BusinessLayer.BusinessObjects

Namespace AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactory
        Implements IDaoFactory

        Public ReadOnly Property BaseDao As IBaseDao Implements IDaoFactory.BaseDao
            Get
                Return New BaseDao()
            End Get
        End Property

        Public ReadOnly Property DefaultFieldValueDao As IDefaultFieldValueDao _
            Implements IDaoFactory.DefaultFieldValueDao
            Get
                Return New DefaultFieldValueDao()
            End Get
        End Property

        Public ReadOnly Property TblColPropDao As ITblColPropDao Implements IDaoFactory.TblColPropDao
            Get
                Return New TblColPropDao()
            End Get
        End Property

        Public ReadOnly Property SecurityDao As ISecurityDao Implements IDaoFactory.SecurityDao
            Get
                Return New SecurityDao()
            End Get
        End Property

        Public ReadOnly Property LoginDao As ILoginDao Implements IDaoFactory.LoginDao
            Get
                Return New LoginDao()
            End Get
        End Property

        Public ReadOnly Property SaltDao As ISaltDao Implements IDaoFactory.SaltDao
            Get
                Return New SaltDao()
            End Get
        End Property

        Public ReadOnly Property UserDao As IUserDao Implements IDaoFactory.UserDao
            Get
                Return New UserDao()
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

        Public ReadOnly Property SecurityGroupDao As ISecurityGroupDao Implements IDaoFactory.SecurityGroupDao
            Get
                Return New SecurityGroupDao()
            End Get
        End Property
    End Class
End Namespace