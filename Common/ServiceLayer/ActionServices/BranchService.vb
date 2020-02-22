
Imports System.Configuration
Imports AATM.Common.DataLayer
Imports AATM.ServicesLayer.Services
Imports ServicesLayer.Services

Namespace ServiceLayer.ActionServices

    Public Class BranchService
        Inherits ServiceOld

        Private Shared Shadows ReadOnly Provider As String = ConfigurationManager.AppSettings.Get("DataProvider")
        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly BranchDao As IBranchDao = Factory.BranchDao

        Public Sub New()
            DataDao = BranchDao
        End Sub

    End Class

End Namespace