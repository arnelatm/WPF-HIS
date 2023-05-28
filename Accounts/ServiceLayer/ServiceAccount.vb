Imports AATM.Common.ServiceLayer
Imports AATM.DataLayer
Imports System.Configuration

Public Class ServiceAccount
    Implements IServiceAccount

    Protected Shared ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
    Protected Shared ReadOnly Factory As IDaoFactory = DaoFactories.GetFactory(Provider)
    Protected Shared ReadOnly BaseDao As IBaseDao = Factory.BaseDao
    Protected Shared ReadOnly DataRetriever As IDataPageRetriever = Factory.DataRetriever


End Class



Public Interface IServiceAccount
    Inherits IServiceCommon



End Interface
