Imports System.Configuration
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.DataLayer.AdoNet

Namespace Security
    ''' <summary>
    ''' Loads the optional machine-protected ISPDATA connection string before the
    ''' Accounts main form is created. The existing configuration value remains
    ''' a migration fallback until the protected file is provisioned.
    ''' </summary>
    Friend NotInheritable Class ProtectedConnectionStringBootstrap
        Private Const ProtectedPathSetting As String = "ProtectedISPDATAFile"
        Private Const DefaultProtectedPath As String = "%ProgramData%\AATM\Accounts\ISPDATA.connection"
        Private Const DefaultKizenPath As String = "%ProgramData%\AATM\Accounts\KIZEN.connection"
        Private Const DefaultBioTimePath As String = "%ProgramData%\AATM\Accounts\BIOTIME.connection"
        Private Const DefaultIGroupClinicPath As String = "%ProgramData%\AATM\Accounts\IGROUPCLINIC.connection"

        Private Sub New()
        End Sub

        Public Shared Sub LoadIfPresent()
            LoadConnectionIfPresent("ISPDATA", ConfigurationManager.AppSettings(ProtectedPathSetting), DefaultProtectedPath)
            LoadConnectionIfPresent("KIZEN", Nothing, DefaultKizenPath)
            LoadConnectionIfPresent("BIOTIME", Nothing, DefaultBioTimePath)
            LoadConnectionIfPresent("IGROUPCLINIC", Nothing, DefaultIGroupClinicPath)
        End Sub

        Private Shared Sub LoadConnectionIfPresent(connectionName As String, configuredPath As String, defaultPath As String)
            Dim path = If(String.IsNullOrWhiteSpace(configuredPath), DefaultProtectedPath, configuredPath)
            If String.Equals(connectionName, "KIZEN", StringComparison.OrdinalIgnoreCase) AndAlso String.IsNullOrWhiteSpace(configuredPath) Then
                path = defaultPath
            End If
            If String.Equals(connectionName, "BIOTIME", StringComparison.OrdinalIgnoreCase) AndAlso String.IsNullOrWhiteSpace(configuredPath) Then
                path = defaultPath
            End If
            path = Environment.ExpandEnvironmentVariables(path)

            If Not File.Exists(path) Then Return

            Dim protectedValue = File.ReadAllText(path, Encoding.UTF8).Trim()
            If String.IsNullOrWhiteSpace(protectedValue) Then
                Throw New ConfigurationErrorsException("The protected ISPDATA connection file is empty.")
            End If

            Try
                Dim encrypted = Convert.FromBase64String(protectedValue)
                Dim clearBytes = ProtectedData.Unprotect(encrypted, Nothing, DataProtectionScope.LocalMachine)
                Dim connectionString = Encoding.UTF8.GetString(clearBytes)
                If String.IsNullOrWhiteSpace(connectionString) Then
                    Throw New ConfigurationErrorsException("The protected ISPDATA connection file contains no connection string.")
                End If
                If String.Equals(connectionName, "ISPDATA", StringComparison.OrdinalIgnoreCase) Then
                    GlobalVariables.DacConnectionString = connectionString
                Else
                    Db.SetProtectedConnectionString(connectionName, connectionString)
                End If
            Catch ex As ConfigurationErrorsException
                Throw
            Catch ex As Exception
                Throw New ConfigurationErrorsException("The protected ISPDATA connection file could not be decrypted on this computer.", ex)
            End Try
        End Sub
    End Class
End Namespace
