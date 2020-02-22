Namespace AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactory
        Implements IDaoFactory

        Public ReadOnly Property CommonDao As ICommonDao Implements IDaoFactory.CommonDao
            Get
                Return New CommonDao()
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
    End Class
End Namespace