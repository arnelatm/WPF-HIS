Namespace AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryOld
        Implements IDaoFactoryOld

        Public ReadOnly Property CommonDaoOld As ICommonDao Implements IDaoFactoryOld.CommonDaoOld
            Get
                Return New CommonDaoOld()
            End Get
        End Property

        Public ReadOnly Property DefaultFieldValueDao As IDefaultFieldValueDao _
            Implements IDaoFactoryOld.DefaultFieldValueDao
            Get
                Return New DefaultFieldValueDao()
            End Get
        End Property

        Public ReadOnly Property TblColPropDao As ITblColPropDao Implements IDaoFactoryOld.TblColPropDao
            Get
                Return New TblColPropDao()
            End Get
        End Property

        Public ReadOnly Property SecurityDao As ISecurityDao Implements IDaoFactoryOld.SecurityDao
            Get
                Return New SecurityDao()
            End Get
        End Property
    End Class
End Namespace