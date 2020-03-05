' abstract factory interface. Creates data access objects.
' ** GoF Design Pattern: Factory.


Public Interface IDaoFactory
    ReadOnly Property BaseDao As IBaseDao

    ReadOnly Property DefaultFieldValueDao As IDefaultFieldValueDao
    ReadOnly Property TblColPropDao As ITblColPropDao
    ReadOnly Property SecurityDao As ISecurityDao
    ReadOnly Property LoginDao As ILoginDao
    ReadOnly Property SaltDao As ISaltDao
    ReadOnly Property UserDao As IUserDao
    ReadOnly Property SecurityObjectDao As ISecurityObjectDao
    ReadOnly Property GroupAccessDao As IGroupAccessDao
    ReadOnly Property SecurityGroupDao As ISecurityGroupDao

End Interface