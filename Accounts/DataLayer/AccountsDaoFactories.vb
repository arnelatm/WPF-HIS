' Factory of factories. This class is a factory class that creates
' data-base specific factories which in turn create data access objects.
' ** GoF Design Patterns: Factory.
Imports AATM.Accounts.DataLayer.AdoNet

Namespace DataLayer

    Public Class AccountsDaoFactories
        ' gets a provider specific (i.e. database specific) factory

        ' ** GoF Design Pattern: Factory

        Public Shared Function GetFactory(dataProvider As String) As IAccountsDaoFactory
            ' return the requested CommonDaoFactory

            Select Case dataProvider.ToLower()
                Case "ado.net"
                    Dim retVal = New AccountsDaoFactory()
                    Return retVal
                    'Case "linq2sql"
                    'Return New Linq2Sql.CommonDaoFactory()
                    'Case "entityframework"
                    'Return New EntityFramework.CommonDaoFactory()

                Case Else
                    Return New AccountsDaoFactory()
            End Select
        End Function

    End Class
End NameSpace