Imports AATM.Common.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryAccounts
        Inherits DaoFactoryCommon
        Implements IDaoFactoryAccounts

        Public Overloads Function CreateDao(classBaseName As String) As Object Implements IDaoFactoryAccounts.CreateDao
            Dim className = $"AATM.Accounts.DataLayer.AdoNet." + classBaseName + "Dao"
            Dim dao As Object
            Dim tType As Type = Type.GetType(className)
            If tType Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + className)
                Debugger.Break()
            End If
            dao = Activator.CreateInstance(tType)
            Return dao
        End Function

    End Class

End Namespace