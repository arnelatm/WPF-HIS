' Factory of factories. This class is a factory class that creates
' data-base specific factories which in turn create data access objects.
' ** GoF Design Patterns: Factory.
Imports AATM.DataLayer.DBDataObj.AdoNet
Imports AATM.HIS.Common.DataLayer.AdoNet
Imports DaoFactoryOld = AATM.HIS.Common.DataLayer.AdoNet.DaoFactoryOld

Namespace DataLayer

    Public Class DaoFactoriesOld
        ' gets a provider specific (i.e. database specific) factory

        ' ** GoF Design Pattern: Factory

        Public Shared Function GetFactory(dataProvider As String) As IDaoFactoryOld
            ' return the requested DaoFactoryOld

            Select Case dataProvider.ToLower()
                Case "ado.net"
                    Return New DaoFactoryOld()
                    'Case "linq2sql"
                    'Return New Linq2Sql.DaoFactoryOld()
                    'Case "entityframework"
                    'Return New EntityFramework.DaoFactoryOld()

                Case Else
                    Return New DaoFactoryOld()
            End Select
        End Function

    End Class

End Namespace