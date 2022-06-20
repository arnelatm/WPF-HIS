' Factory of factories. This class is a factory class that creates
' data-base specific factories which in turn create data access objects.
' ** GoF Design Patterns: Factory.
Imports AATM.Accounts.DataLayer.AdoNet

Namespace DataLayer

    Public Class DaoFactoriesAccounts
        ' gets a provider specific (i.e. database specific) factory

        ' ** GoF Design Pattern: Factory

        Public Shared Function GetAccountsFactory(dataProvider As String) As IDaoFactoryAccounts
            ' return the requested DaoFactoryCommon

            Select Case dataProvider.ToLower()
                Case "ado.net"
                    Dim retVal = New DaoFactoryAccounts()
                    Return retVal
                    'Case "linq2sql"
                    'Return New Linq2Sql.DaoFactoryCommon()
                    'Case "entityframework"
                    'Return New EntityFramework.DaoFactoryCommon()

                Case Else
                    Return New DaoFactoryAccounts()
            End Select
        End Function

    End Class

End Namespace