' abstract factory interface. Creates data access objects.
' ** GoF Design Pattern: Factory.


Public Interface IDaoFactory
    ReadOnly Property CommonDao As ICommonDao

    ReadOnly Property DefaultFieldValueDao As IDefaultFieldValueDao
    ReadOnly Property TblColPropDao As ITblColPropDao

    ReadOnly Property SecurityDao As ISecurityDao
    ReadOnly Property LoginDao As ILoginDao
    ReadOnly Property SaltDao As ISaltDao
    ReadOnly Property UserDao As IUserDao
End Interface