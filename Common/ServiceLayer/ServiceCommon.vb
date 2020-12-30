Imports System.Reflection
Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer
Imports AATM.DataLayer
Imports AATM.ServicesLayer.Services

Namespace ServiceLayer

    Public Class ServiceCommon
        Inherits Service
        Implements IServiceCommon

        Protected Shared ReadOnly DaoFactoryCommonFactory As IDaoFactoryCommon = DaoFactoriesCommon.GetCommonFactory(Provider)

        Public Sub New(accountName As String, Optional daoTableOrViewName As String = Nothing)
            Dim bizObject = $"AATM.Common.BusinessLayer." + accountName
            DataBo = Activator.CreateInstance(Type.GetType(bizObject))
            If DataBo Is Nothing Then
                MessageBox.Show("Missing Business Object " + bizObject)
                Debugger.Break()
            End If
            If daoTableOrViewName Is Nothing Then
                DataDao = DaoFactoryCommonFactory.CreateDao(accountName)
            Else
                DataDao = DaoFactoryCommonFactory.CreateDao(accountName, daoTableOrViewName)
            End If
            If DataDao Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + accountName.Trim() + "dao")
                Debugger.Break()
            End If

        End Sub

        Public Sub New()
        End Sub

    End Class

End Namespace