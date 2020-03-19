Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryCommon
        Inherits DaoFactory
        Implements IDaoFactoryCommon

        Public Overridable Function CreateDao(classBaseName As String) As Object Implements IDaoFactoryCommon.CreateDao
            Dim className = $"AATM.Common.DataLayer.AdoNet." + classBaseName + "Dao"
            Dim dao As Object
            Dim tType As Type = Type.GetType(className)
            If tType Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + className + "!")
            End If
            dao = Activator.CreateInstance(tType)
            Return dao
        End Function

        'Public ReadOnly Property CommonDao As ICommonDao Implements IDaoFactoryCommon.CommonDao
        '    Get
        '        Return New CommonDao()
        '    End Get
        'End Property

        'Public ReadOnly Property BranchDao As IBranchDao Implements IDaoFactoryCommon.BranchDao
        '    Get
        '        Return New BranchDao()
        '    End Get
        'End Property

        'Public ReadOnly Property TranslatedMessagesDao As ITranslatedMessagesDao Implements IDaoFactoryCommon.TranslatedMessagesDao
        '    Get
        '        Return New TranslatedMessagesDao()
        '    End Get
        'End Property

        'Public Overloads ReadOnly Property SecurityDao As ISecurityDao Implements IDaoFactoryCommon.SecurityDao
        '    Get
        '        Return New SecurityDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CountryDao As ICountryDao Implements IDaoFactoryCommon.CountryDao
        '    Get
        '        Return New CountryDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ProfitCenterDao As IProfitCenterDao Implements IDaoFactoryCommon.ProfitCenterDao
        '    Get
        '        Return New ProfitCenterDao()
        '    End Get
        'End Property

        'Public ReadOnly Property CostCenterDao As ICostCenterDao Implements IDaoFactoryCommon.CostCenterDao
        '    Get
        '        Return New CostCenterDao()
        '    End Get
        'End Property

        'Public ReadOnly Property DepartmentDao As IDepartmentDao Implements IDaoFactoryCommon.DepartmentDao
        '    Get
        '        Return New DepartmentDao()
        '    End Get
        'End Property

        'Public ReadOnly Property ReligionDao As IReligionDao Implements IDaoFactoryCommon.ReligionDao
        '    Get
        '        Return New ReligionDao()
        '    End Get
        'End Property

        'Public ReadOnly Property RevenueGroupDao As IRevenueGroupDao Implements IDaoFactoryCommon.RevenueGroupDao
        '    Get
        '        Return New RevenueGroupDao()
        '    End Get
        'End Property

        'Public ReadOnly Property PhoneTypeDao As IPhoneTypeDao Implements IDaoFactoryCommon.PhoneTypeDao
        '    Get
        '        Return New PhoneTypeDao()
        '    End Get
        'End Property

        'Public ReadOnly Property OriginalMessagesDao As IOriginalMessagesDao Implements IDaoFactoryCommon.OriginalMessagesDao
        '    Get
        '        Return New OriginalMessagesDao()
        '    End Get
        'End Property

        'Public Function CreateDao(classBasename As String) As Object Implements IDaoFactoryCommon.CreateDao
        '    Throw New NotImplementedException()
        'End Function
    End Class

End Namespace