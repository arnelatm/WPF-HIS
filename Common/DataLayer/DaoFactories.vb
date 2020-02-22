' Factory of factories. This class is a factory class that creates
' data-base specific factories which in turn create data access objects.
' ** GoF Design Patterns: Factory.

Imports AATM.DataLayer.AdoNet

Namespace DataLayer

    Public Class DaoFactories
        ' gets a provider specific (i.e. database specific) factory

        ' ** GoF Design Pattern: Factory

        Public Shared Function GetFactory(dataProvider As String) As IDaoFactory
            ' return the requested DaoFactory

            Select Case dataProvider.ToLower()
                Case "ado.net"
                    Return New DaoFactory()
                    'Case "linq2sql"
                    'Return New Linq2Sql.DaoFactoryOld()
                    'Case "entityframework"
                    'Return New EntityFramework.DaoFactoryOld()

                Case Else
                    Return New DaoFactory()
            End Select
        End Function

    End Class

End Namespace