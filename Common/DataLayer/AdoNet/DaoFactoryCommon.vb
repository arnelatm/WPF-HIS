Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object factory
    ' ** Factory Pattern

    Public Class DaoFactoryCommon
        Inherits DaoFactory
        Implements IDaoFactoryCommon

        Public Overrides Function CreateDao(classBaseName As String, ParamArray arguments As Object()) As Object Implements IDaoFactoryCommon.CreateDao
            Dim className = $"AATM.Common.DataLayer.AdoNet." + classBaseName + "Dao"
            Dim dao As Object
            Dim tType As Type = Type.GetType(className)
            If tType Is Nothing Then
                MessageBox.Show("Missing Data Access Object " + className + "!")
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