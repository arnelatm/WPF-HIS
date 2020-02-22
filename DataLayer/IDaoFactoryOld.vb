Public Interface IDaoFactoryOld
    ReadOnly Property CommonDaoOld As ICommonDao

    ReadOnly Property DefaultFieldValueDao As IDefaultFieldValueDao
    ReadOnly Property TblColPropDao As ITblColPropDao

    ReadOnly Property SecurityDao As ISecurityDao
End Interface