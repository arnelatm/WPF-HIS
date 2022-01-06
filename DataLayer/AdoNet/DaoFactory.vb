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

        Public ReadOnly Property SaltDao As ISaltDao Implements IDaoFactory.SaltDao
            Get
                Return New SaltDao()
            End Get
        End Property

        Public ReadOnly Property GroupAccessDao As IDaoChild(Of GroupAccess) Implements IDaoFactory.GroupAccessDao
            Get
                Return New GroupAccessDao()
            End Get
        End Property

        'Public ReadOnly Property SecurityGroupDao As IDaoAll(Of SecurityGroup) Implements IDaoFactory.SecurityGroupDao
        '    Get
        '        Return New SecurityGroupDao()
        '    End Get
        'End Property

        'Public ReadOnly Property SecurityObjectDao As IDaoAll(Of SecurityObject) _
        '    Implements IDaoFactory.SecurityObjectDao
        '    Get
        '        Return New SecurityObjectDao()
        '    End Get
        'End Property

        'Private ReadOnly Property UserDao As IDaoAll(Of User) Implements IDaoFactory.UserDao
        '    Get
        '        Return New UserDao()
        '    End Get
        'End Property

        Public Overridable Function CreateDao(classBasename As String, ParamArray arguments As Object()) As Object Implements IDaoFactory.CreateDao
            Dim className = $"AATM.DataLayer.AdoNet." + classBasename + "Dao"
            Dim dao As Object
            Dim tType As Type = Type.GetType(className)
            If tType Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + className)
                Debugger.Break()
            End If
            If arguments Is Nothing Then
                dao = Activator.CreateInstance(tType)
            Else
                dao = Activator.CreateInstance(tType, arguments)
            End If
            Return dao
        End Function

    End Class

End Namespace