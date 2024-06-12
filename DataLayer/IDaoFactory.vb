' abstract factory interface. Creates data access objects.
' ** GoF Design Pattern: Factory.

Imports AATM.BusinessLayer.BusinessObjects

Public Interface IDaoFactory
    ReadOnly Property BaseDao As IBaseDao
    ReadOnly Property DefaultFieldValueDao As IDefaultFieldValueDao
    ReadOnly Property TblColPropDao As ITblColPropDao
    ReadOnly Property SaltDao As ISaltDao
    ReadOnly Property GroupAccessDao As IDaoChild(Of GroupAccess)
    ReadOnly Property DataRetriever As IDataPageRetriever

    Function CreateDao(classBasename As String, ParamArray arguments As Object())

End Interface