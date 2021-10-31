Public MustInherit Class BaseSqlServerConnection
    Inherits BaseExceptionsHandler
    ''' <summary>
    ''' This points to your database server
    ''' </summary>
    Protected DatabaseServer As String = "ISPADMIN2"
    ''' <summary>
    ''' Name of database containing required tables
    ''' </summary>
    Protected DefaultCatalog As String = "ISPDATA"
    Public ReadOnly Property ConnectionString() As String
        Get
            Return $"Data Source={DatabaseServer};Initial Catalog={DefaultCatalog};Integrated Security=True"
        End Get
    End Property
End Class

