' Factory of factories. This class is a factory class that creates
' data-base specific factories which in turn create data access objects.
' ** GoF Design Patterns: Factory.

Imports AATM.Common.DataLayer.AdoNet

Namespace DataLayer

    Public Class CommonDaoFactories
        ' gets a provider specific (i.e. database specific) factory

        ' ** GoF Design Pattern: Factory

        Public Shared Function GetFactory(dataProvider As String) As ICommonDaoFactory
            ' return the requested CommonDaoFactory

            Select Case dataProvider.ToLower()
                Case "ado.net"
                    Return New CommonDaoFactory()
                    'Case "linq2sql"
                    'Return New Linq2Sql.DaoFactoryOld()
                    'Case "entityframework"
                    'Return New EntityFramework.DaoFactoryOld()

                Case Else
                    Return New CommonDaoFactory()
            End Select
        End Function

    End Class

End Namespace