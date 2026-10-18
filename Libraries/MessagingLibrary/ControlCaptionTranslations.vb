Imports System.ComponentModel
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text
Imports AATM.Libraries.GlobalFuncNSub

' Runtime database overrides for reusable controls. This class has no Dac instance
' or database work in its initializer, so it is safe to load in the designer.
Public NotInheritable Class ControlCaptionTranslations
    Private Sub New()
    End Sub

    Private Class CachedCaptions
        Public Values As Dictionary(Of String, String)
        Public ExpiresUtc As DateTime
    End Class

    Private Shared ReadOnly CacheLock As New Object()
    Private Shared ReadOnly Cache As New Dictionary(Of String, CachedCaptions)(StringComparer.Ordinal)
    Private Shared _generation As Integer
    Private Shared ReadOnly LoadCaptions As Func(Of String, String, ICollection(Of String), Dictionary(Of String, String)) = AddressOf ReadDatabaseCaptions

    ' Call after a local translation save/delete. Other workstations' changes are
    ' picked up on the next lookup after the one-minute cache lifetime.
    Public Shared Sub Invalidate()
        SyncLock CacheLock
            Cache.Clear()
            _generation += 1
        End SyncLock
    End Sub

    Public Shared Function GetCaptions(fallbacks As IDictionary(Of String, String),
                                      culture As CultureInfo,
                                      Optional designTime As Boolean = False) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)(fallbacks, StringComparer.OrdinalIgnoreCase)
        If designTime OrElse LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return result
        culture = If(culture, CultureInfo.CurrentUICulture)
        If Not NeedToTranslateText(culture.Name) Then Return result

        Try
            Dim connectionString = GlobalVariables.DacConnectionString
            If String.IsNullOrWhiteSpace(connectionString) Then Return result
            Dim captions As New List(Of String)(fallbacks.Keys)
            captions.Sort(StringComparer.Ordinal)
            Dim contextKey As String
            Using hash = SHA256.Create()
                contextKey = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(connectionString)))
            End Using
            Dim cacheKey = contextKey & ChrW(0) & culture.Name.ToLowerInvariant() & ChrW(0) & String.Join(ChrW(0), captions)
            Dim entry As CachedCaptions = Nothing
            Dim generation As Integer
            SyncLock CacheLock
                generation = _generation
                If Cache.TryGetValue(cacheKey, entry) AndAlso entry.ExpiresUtc <= DateTime.UtcNow Then entry = Nothing
            End SyncLock
            If entry Is Nothing Then
                Dim values As Dictionary(Of String, String) = Nothing
                Try
                    values = LoadCaptions(connectionString, culture.Name, captions)
                Catch ex As SqlException
                    ' An unavailable translation database must not display error dialogs.
                Catch ex As InvalidOperationException
                Catch ex As ArgumentException
                End Try
                entry = New CachedCaptions With {
                    .Values = If(values, New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)),
                    .ExpiresUtc = DateTime.UtcNow.AddSeconds(If(values Is Nothing, 5, 60))}
                SyncLock CacheLock
                    ' A lookup started before a save cannot repopulate an invalidated cache.
                    If generation = _generation Then
                        If Cache.Count >= 32 Then Cache.Clear()
                        Cache(cacheKey) = entry
                    End If
                End SyncLock
            End If
            For Each caption In fallbacks.Keys
                Dim translated As String = Nothing
                If entry.Values.TryGetValue(caption, translated) AndAlso Not String.IsNullOrWhiteSpace(translated) Then
                    result(caption) = translated
                End If
            Next
        Catch ex As ConfigurationErrorsException
            ' Missing workstation settings also use the built-in captions.
        Catch ex As ArgumentException
        End Try
        Return result
    End Function

    Private Shared Function ReadDatabaseCaptions(connectionString As String,
                                                 cultureName As String,
                                                 captions As ICollection(Of String)) As Dictionary(Of String, String)
        Dim values As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        If captions.Count = 0 Then Return values
        Dim settings As New SqlConnectionStringBuilder(connectionString)
        If settings.ConnectTimeout = 0 OrElse settings.ConnectTimeout > 2 Then settings.ConnectTimeout = 2
        Using connection As New SqlConnection(settings.ConnectionString)
            Using command As New SqlCommand With {.Connection = connection, .CommandTimeout = 2}
                Dim parameters As New List(Of String)
                Dim missing As New HashSet(Of String)(captions, StringComparer.OrdinalIgnoreCase)
                For Each caption In captions
                    Dim name = "@Caption" & parameters.Count.ToString(CultureInfo.InvariantCulture)
                    parameters.Add(name)
                    command.Parameters.Add(name, SqlDbType.NVarChar, 1024).Value = caption
                Next
                Dim captionList = String.Join(",", parameters)
                command.Parameters.Add("@CultureInfoCode", SqlDbType.NVarChar, 64).Value = cultureName
                command.CommandText =
                    "SELECT Caption, TranslatedCaption FROM dbo.Captions_View " &
                    "WHERE CultureInfoCode = @CultureInfoCode AND Caption IN (" & captionList & "); " &
                    "SELECT Caption FROM dbo.OriginalCaptions WHERE Caption IN (" & captionList & ");"
                connection.Open()
                Using reader = command.ExecuteReader()
                    While reader.Read()
                        If Not reader.IsDBNull(0) AndAlso Not reader.IsDBNull(1) Then
                            values(reader.GetString(0).TrimEnd()) = reader.GetString(1)
                        End If
                    End While
                    If reader.NextResult() Then
                        While reader.Read()
                            If Not reader.IsDBNull(0) Then missing.Remove(reader.GetString(0).TrimEnd())
                        End While
                    End If
                End Using
                ' Preserve discovery of new captions for the existing user translation
                ' screens. Registration never overwrites a caption or translation.
                For Each caption In missing
                    command.Parameters.Clear()
                    command.Parameters.Add("@Caption", SqlDbType.NVarChar, 1024).Value = caption
                    command.CommandText =
                        "INSERT INTO dbo.OriginalCaptions (Caption) SELECT @Caption " &
                        "WHERE NOT EXISTS (SELECT 1 FROM dbo.OriginalCaptions WITH (UPDLOCK, HOLDLOCK) WHERE Caption = @Caption);"
                    Try
                        command.ExecuteNonQuery()
                    Catch ex As SqlException
                        ' Read-only database access can still use existing translations.
                        Exit For
                    End Try
                Next
            End Using
        End Using
        Return values
    End Function
End Class
