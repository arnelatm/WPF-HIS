' abstract factory interface. Creates data access objects.
' ** GoF Design Pattern: Factory.

Imports AATM.BusinessLayer.BusinessObjects

Public Interface IDaoFactory
    ReadOnly Property BaseDao As IBaseDao

    ReadOnly Property DefaultFieldValueDao As IDefaultFieldValueDao
    ReadOnly Property TblColPropDao As ITblColPropDao
    ReadOnly Property SecurityDao As ISecurityDao
    ReadOnly Property LoginDao As ILoginDao
    ReadOnly Property SaltDao As ISaltDao
    ReadOnly Property UserDao As IDaoAll(Of User)

    'ReadOnly Property SecurityObjectDao As ISecurityObjectDao
    ReadOnly Property GroupAccessDao As IDaoChild(Of GroupAccess)

    ReadOnly Property SecurityGroupDao As IDaoAll(Of SecurityGroup)
    ReadOnly Property SecurityObjectDao As IDaoAll(Of SecurityObject)

End Interface