' Factory of factories. This class is a factory class that creates
' data-base specific factories which in turn create data access objects.
' ** GoF Design Patterns: Factory.

Imports AATM.Common.DataLayer.AdoNet

Namespace DataLayer

    Public Class DaoFactoriesCommon
        ' gets a provider specific (i.e. database specific) factory

        ' ** GoF Design Pattern: Factory

        Public Shared Function GetCommonFactory(dataProvider As String) As IDaoFactoryCommon
            ' return the requested DaoFactoryCommon

            Select Case dataProvider.ToLower()
                Case "ado.net"
                    Return New DaoFactoryCommon()
                    'Case "linq2sql"
                    'Return New Linq2Sql.DaoFactoryOld()
                    'Case "entityframework"
                    'Return New EntityFramework.DaoFactoryOld()

                Case Else
                    Return New DaoFactoryCommon()
            End Select
        End Function

    End Class

End Namespace