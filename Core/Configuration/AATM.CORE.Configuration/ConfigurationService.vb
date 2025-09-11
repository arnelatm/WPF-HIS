Imports System.Configuration

''' <summary>
''' Provides a concrete implementation of IConfigurationService
''' that reads settings from the application's App.config file.
''' </summary>
Public Class ConfigurationService
    Implements IConfigurationService

    Private Const APP_CONFIG_FILE As String = "App.config"

    Public Function GetSetting(ByVal key As String) As String Implements IConfigurationService.GetSetting
        Try
            ' We'll need to add a reference to System.Configuration to use ConfigurationManager.
            Return ConfigurationManager.AppSettings(key)
        Catch ex As Exception
            ' In a real-world app, you'd want to log this error.
            ' For now, we'll just return an empty string.
            Console.WriteLine($"Error reading setting for key '{key}': {ex.Message}")
            Return String.Empty
        End Try
    End Function
End Class
