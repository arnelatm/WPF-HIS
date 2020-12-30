Imports AATM.Common.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryAccounts
        Inherits DaoFactoryCommon
        Implements IDaoFactoryAccounts

        Public Overloads Function CreateDao(accountName As String, ParamArray arguments As Object()) As Object Implements IDaoFactoryAccounts.CreateDao
            Dim className = $"AATM.Accounts.DataLayer.AdoNet." + accountName + "Dao"
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