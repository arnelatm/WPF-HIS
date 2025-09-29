Imports System.Data.SqlClient
Imports System.Configuration

''' <summary>
''' Provides a simple way to get a new SqlConnection instance by reading
''' the connection string from the application's configuration file.
''' </summary>
Public Class DbConnector

    ''' <summary>
    ''' Returns a new, open SqlConnection instance.
    ''' </summary>
    ''' <returns>An open SqlConnection object.</returns>
    ''' <exception cref="ConfigurationErrorsException">Thrown if the connection string is not found.</exception>
    Public Shared Function GetConnection() As SqlConnection
        ' The name of the connection string in the configuration file.
        Const connectionStringName As String = "LocalizationDb"

        ' Get the connection string from the application's configuration file.
        Dim connStringSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(connectionStringName)

        If connStringSettings Is Nothing OrElse String.IsNullOrEmpty(connStringSettings.ConnectionString) Then
            Throw New ConfigurationErrorsException($"Connection string '{connectionStringName}' was not found or is empty in the application's configuration file.")
        End If

        Dim conn As New SqlConnection(connStringSettings.ConnectionString)
        conn.Open()
        Return conn
    End Function

End Class
