Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports AATM.Libraries.GlobalFuncNSub

Public Class Dac
    Inherits Component

    ' Generated form code omitted

#Region " Declarations and properties "

    Private ReadOnly _defaultMirroredLanguageIdNo As Integer = 0
    Public Const SqlError = "Error connecting to server"
    Public Const MdbError = "Error opening MDB file"
    Public Const DbfError = "Error with DBF directory or DBC"
    Public Const FillError = "Error filling dataset"
    Public Const NonQueryError = "Error executing nonquery statement"

    Public Da As Object
    Public Cn As Object
    Public Dc As Object

    'Public Shared DefaultMirroredLanguageIdNo As Integer

    <Category("AATM")> Public Property DacAccessType As String = "SQL"
    <Category("AATM")> Public Property DacFileName As String = $"ISPDATA" '""Translations"
    <Category("AATM")> Public Property DacDatabase As String = $"ISPDATA" '""Translations"
    <Category("AATM")> Public Property DacServer As String = ""
    <Category("AATM")> Public Property DacUid As String = ""
    <Category("AATM")> Public Property DacServerType As String = ""
    <Category("AATM")> Public Property DacPassword As String = ""

    Public Sub New()

        ' Read data access component settings from App.Config file.
        Dim accessType As String = ConfigurationManager.AppSettings.Get("AccessTypeTranslator") ' "SQL", "MDB", "DBF"
        Dim server As String = ConfigurationManager.AppSettings.Get("ServerTranslator") ' SQL only
        Dim serverType As String = ConfigurationManager.AppSettings.Get("ServerType") ' SQL only
        Dim database As String = ConfigurationManager.AppSettings.Get("DatabaseTranslator") ' SQL only
        Dim uid As String = ConfigurationManager.AppSettings.Get("UIDTranslator") ' SQL, MDB
        Dim pwd As String = ConfigurationManager.AppSettings.Get("PWDTranslator") ' SQL, MDB
        Dim fileName As String = ConfigurationManager.AppSettings.Get("FileNameTranslator") ' DBF, MDB
        DacAccessType = accessType
        DacServer = server
        DacServerType = serverType
        DacDatabase = database
        DacUid = uid
        DacPassword = pwd
        DacFileName = fileName

    End Sub

    Private _cs As String = ""

    <Category("AATM")> Public Property Cs() As String
        Get
            Return _cs
        End Get
        Set(ByVal value As String)
            _cs = value
        End Set
    End Property

    Public ReadOnly Property DefaultMirroredLanguageIdNo As Integer
        Get
            If _defaultMirroredLanguageIdNo = 0 Then
                If Not (System.ComponentModel.LicenseManager.CurrentContext.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
                    Dim cmd As String
                    cmd = "Select IdNo from Languages where CultureInfoCode = '" + GlobalVariables.DefaultMirroredCultureInfoStr + "'"
                    Return ExecScalar(Of Int16)(cmd)
                End If
            End If
            Return _defaultMirroredLanguageIdNo
        End Get
    End Property

#End Region

#Region " Functions "

    Public Function ReturnDs(ByVal cmd As String) As DataSet
        If Not cmd = "" Then
            Cs = BuildConnString()
            Select Case DacAccessType
                Case "SQL"
                    Dim cn1 As SqlConnection = New SqlConnection(Cs)
                    Try
                        cn1.Open()
                    Catch ex As Exception
                        ErrorMessage(ex, SqlError)
                    End Try
                    Dim da1 As SqlDataAdapter =
                            New SqlDataAdapter(cmd, cn1)
                    Cn = cn1
                    Da = da1
                Case "MDB"
                    Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                    Try
                        cn1.Open()
                    Catch ex As Exception
                        ErrorMessage(ex, MdbError)
                    End Try
                    Dim da1 As OleDbDataAdapter =
                            New OleDbDataAdapter(cmd, cn1)
                    Cn = cn1
                    Da = da1
                Case "DBF"
                    Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                    Try
                        cn1.Open()
                    Catch ex As Exception
                        ErrorMessage(ex, DbfError)
                    End Try
                    Dim da1 As OleDbDataAdapter =
                            New OleDbDataAdapter(cmd, cn1)
                    Cn = cn1
                    Da = da1
            End Select
            Dim ds As New DataSet
            ds.Clear()

            Try
                Da.fill(ds)
            Catch ex As Exception
                ErrorMessage(ex, FillError)
            End Try
            If Cn.state = ConnectionState.Open Then Cn.close()
            Return ds
        Else
            Return Nothing
        End If
    End Function

    Public Function ExecCmd(ByVal cmd As String) As String
        Dim status As String = "Ok"
        Cs = BuildConnString()
        Select Case DacAccessType
            Case "SQL"
                Dim cn1 As SqlConnection = New SqlConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, SqlError)
                End Try
                Dim dc1 As New SqlCommand(cmd, cn1)
                Dc = dc1
                Cn = cn1
            Case "MDB"
                Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, MdbError)
                End Try
                Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                Dc = dc1
                Cn = cn1
            Case "DBF"
                Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, DbfError)
                End Try
                Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                Dc = dc1
                Cn = cn1
        End Select
        Dc.CommandType = CommandType.Text
        Try
            Dc.ExecuteNonQuery()
        Catch ex As Exception
            status = "Error"
            ErrorMessage(ex, NonQueryError)
        Finally
            If Cn.state = ConnectionState.Open Then Cn.close()
        End Try
        Return status

    End Function

    Public Function ExecReader(ByVal cmd As String) As Object
        Dim result As New Collection
        Cs = BuildConnString()
        Select Case DacAccessType
            Case "SQL"
                Dim cn1 As SqlConnection = New SqlConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, SqlError)
                End Try
                Dim dc1 As New SqlCommand(cmd, cn1)
                Dc = dc1
                Cn = cn1
            Case "MDB"
                Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, MdbError)
                End Try
                Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                Dc = dc1
                Cn = cn1
            Case "DBF"
                Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, DbfError)
                End Try
                Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                Dc = dc1
                Cn = cn1
        End Select
        Dc.CommandType = CommandType.Text
        Try
            Using reader = Dc.ExecuteReader()
                If reader.hasRows() Then
                    Dim i = 0
                    Do While reader.Read()
                        Try
                            result.Add(reader.GetString(0))
                        Catch ex As Exception
                            If ex.HResult = &H80131931 Then
                                result.Add("")
                            Else
                                ErrorMessage(ex, NonQueryError)
                            End If
                        End Try
                        Try
                            result.Add(reader.GetString(1))
                        Catch ex As Exception
                            If ex.HResult = &H80131931 Then
                                result.Add("")
                            Else
                                ErrorMessage(ex, NonQueryError)
                            End If
                        End Try
                    Loop
                End If
            End Using
        Catch ex As Exception
            'status = "Error"
            If ex.HResult = &H80131931 Then
                result = Nothing
            Else
                ErrorMessage(ex, NonQueryError)
            End If
        Finally
            If Cn.state = ConnectionState.Open Then Cn.close()
        End Try
        Return result

    End Function

    Public Function ExecScalar(Of T)(ByVal cmd As String) As T
        Dim retVal As T
        If Not (System.ComponentModel.LicenseManager.UsageMode = System.ComponentModel.LicenseUsageMode.Designtime) Then
            Cs = BuildConnString()
            Select Case DacAccessType
                Case "SQL"
                    Dim cn1 As SqlConnection = New SqlConnection(Cs)
                    Try
                        cn1.Open()
                    Catch ex As Exception
                        ErrorMessage(ex, SqlError)
                    End Try
                    Dim dc1 As New SqlCommand(cmd, cn1)
                    dc1.CommandType = CommandType.Text
                    Dc = dc1
                    Cn = cn1
                Case "MDB"
                    Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                    Try
                        cn1.Open()
                    Catch ex As Exception
                        ErrorMessage(ex, MdbError)
                    End Try
                    Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                    dc1.CommandType = CommandType.Text
                    Dc = dc1
                    Cn = cn1
                Case "DBF"
                    Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                    Try
                        cn1.Open()
                    Catch ex As Exception
                        ErrorMessage(ex, DbfError)
                    End Try
                    Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                    dc1.CommandType = CommandType.Text
                    Dc = dc1
                    Cn = cn1
            End Select
            Try
                retVal = Dc.ExecuteScalar()
            Catch ex As Exception
                ErrorMessage(ex, Dc.commandtext)
            Finally
                If Cn.state = ConnectionState.Open Then Cn.close()
            End Try
        End If
        Return retVal

    End Function

    Public Function ExecScalarString(ByVal cmd As String) As String
        Dim retVal As String = ""
        Cs = BuildConnString()
        Select Case DacAccessType
            Case "SQL"
                Dim cn1 As SqlConnection = New SqlConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, SqlError)
                End Try
                Dim dc1 As New SqlCommand(cmd, cn1)
                dc1.CommandType = CommandType.Text
                Dc = dc1
                Cn = cn1
            Case "MDB"
                Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, MdbError)
                End Try
                Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                dc1.CommandType = CommandType.Text
                Dc = dc1
                Cn = cn1
            Case "DBF"
                Dim cn1 As OleDbConnection = New OleDbConnection(Cs)
                Try
                    cn1.Open()
                Catch ex As Exception
                    ErrorMessage(ex, DbfError)
                End Try
                Dim dc1 As OleDbCommand = New OleDbCommand(cmd, cn1)
                dc1.CommandType = CommandType.Text
                Dc = dc1
                Cn = cn1
        End Select
        Try
            retVal = Dc.ExecuteScalar()
        Catch ex As Exception
            ErrorMessage(ex, Dc.commandtext)
        Finally
            If Cn.state = ConnectionState.Open Then Cn.close()
        End Try

        Return retVal

    End Function

    Function BuildConnString()
        Select Case DacAccessType
            Case "SQL"
                'BuildConnString = "Server=" + DacServer _
                '                  + ";Database=" + DacDatabase _
                '                  + ";Integrated Security=SSPI;Persist Security Info=False"
                '+ ";UID=" + DacUID _
                '+ ";PWD=" + DacPassword
                If DacServerType = "server" Then
                    BuildConnString = "Data Source=" + DacServer + ";Initial Catalog=" + DacDatabase + ";Persist Security Info=True; User ID=" +
                                      DacUid + ";Password=" + DacPassword
                Else
                    'BuildConnString = "Data Source=" + DacServer + ";Initial Catalog=" + DacDatabase + ";Persist Security Info=True;User ID=MARCELO-DELL\Arnel;Password=JaSi5214@"
                    BuildConnString = "Data Source=" + DacServer + ";Initial Catalog=" + DacDatabase + ";Integrated Security=True;Connection Timeout=5"
                End If
                '                  + ";Integrated Security=SSPI;Persist Security Info=False"
                '+ ";UID=" + DacUID _
                '+ ";PWD=" + DacPassword
                '"Data Source=IBN-SERVER;Initial Catalog=ISPData;Persist Security Info=True;User ID=igroupadmin;Password=igss@123"
                'BuildConnString = "Data Source=" + DacServer + ";Initial Catalog=" + DacDatabase + ";Integrated Security=True;Connection Timeout=5"
                'BuildConnString = "Data Source=ISPADMIN2\SQLEXPRESS01;Initial Catalog=TRANSLATIONS;Integrated Security=True;Connection Timeout=5"
                'BuildConnString = "Data Source=MARCELO-DELL;Initial Catalog=TRANSLATIONS;Integrated Security=SSPI;Persist Security Info=False"
                'Case "MDB"
                'BuildConnString = "Provider=Microsoft.Jet.OLEDB.4.0;" _
                '+ "User ID=" + UID + ";" + "Data Source=" _
                '+ FileName + ";"
                'Case "DBF"
                'BuildConnString = "Provider=VFPOLEDB.1;Data Source=" _
                '+ FileName + ";Collating Sequence=MACHINE;"
            Case Else
                BuildConnString = ""
        End Select
    End Function

    Sub ErrorMessage(ByVal e As Exception,
                     Optional ByVal s2 As String = "")
        Dim s As String = e.Message
        If Not e.InnerException Is Nothing Then _
            s += ControlChars.CrLf + e.InnerException.Message
        MessageBox.Show(s, $"Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    Function AddMessage(ByVal key As String, ByVal message As String, ByVal caption As String) As Boolean
        Dim cmd As String
        Dim status As Boolean = True
        cmd = "SELECT IdNo FROM OriginalMessages where MessageKey='" + key + "'"
        Dim idNo As Int32 = ExecScalar(Of Int32)(cmd)
        If idNo = 0 Then
            Cs = BuildConnString()
            Dim conn As SqlConnection = New SqlConnection(Cs)
            Dim sqlCommand As New SqlCommand("INSERT INTO OriginalMessages (messageKey, message, caption) values (@key,  @message, @caption)", conn)
            Try
                conn.Open()
                sqlCommand.Parameters.Add("@key", SqlDbType.VarChar).Value = key
                sqlCommand.Parameters.Add("@message", SqlDbType.VarChar).Value = message
                sqlCommand.Parameters.Add("@caption", SqlDbType.VarChar).Value = caption
                sqlCommand.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                ErrorMessage(ex, SqlError)
                status = False
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
        End If
        Return status
    End Function

    Function AddCaption(ByVal caption As String) As Boolean
        Dim cmd As String
        Dim status As Boolean = True
        cmd = "SELECT IdNo FROM OriginalCaptions where Caption ='" + caption + "'"
        Dim idNo As Int32 = ExecScalar(Of Int32)(cmd)
        If idNo = 0 Then
            Cs = BuildConnString()
            Dim conn As SqlConnection = New SqlConnection(Cs)
            Dim sqlCommand As New SqlCommand("INSERT INTO OriginalCaptions (caption) values (@caption)", conn)
            Try
                conn.Open()
                sqlCommand.Parameters.Add("@caption", SqlDbType.VarChar).Value = caption
                sqlCommand.ExecuteNonQuery()
                conn.Close()
            Catch ex As Exception
                ErrorMessage(ex, SqlError)
                status = False
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
        End If
        Return status
    End Function

    Function GetMessage(ByVal key As String, ByRef message As String, ByRef caption As String) As String
        'Dim translatedMessage As String = message
        Dim cmd As String
        cmd = "SELECT IdNo FROM OriginalMessages where MessageKey = '" + key.Trim() + "'"
        Dim idNo As Integer = ExecScalar(Of Int16)(cmd)
        If idNo <> 0 Then
            Dim textDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name.ToLower()
            If textDisplayLanguage = GlobalVariables.OriginalAppTextLanguage Or (Strings.Left(textDisplayLanguage, 2) = "en" And GlobalVariables.UseOriginalAppTextLanguageForEnglish) Then
                ' no need to translate
            Else
                cmd = "SELECT TranslatedMessage, TranslatedCaption FROM TranslatedMessages_View where MessageIdNo = " + idNo.ToString() + " and Lower(CultureInfoCode) = '" + textDisplayLanguage.TrimEnd + "'"
                Dim items As Collection = ExecReader(cmd)
                If Not (items Is Nothing OrElse items.Count = 0) Then
                    message = items(1)
                    If String.IsNullOrEmpty(items(2)) Then
                        caption = TranslateCaption(caption)
                    Else
                        caption = items(2)
                    End If
                Else
                    Dim languageBaseCode = Left(textDisplayLanguage, textDisplayLanguage.IndexOf("-", StringComparison.Ordinal))
                    cmd = "SELECT TranslatedMessage, TranslatedCaption from TranslatedMessages_View where MessageIdNo = " + idNo.ToString() + " and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
                    items = ExecReader(cmd)
                    If Not (items Is Nothing OrElse items.Count = 0) Then
                        message = message
                        If String.IsNullOrEmpty(caption) Then
                            caption = TranslateCaption(caption)
                        End If
                    Else
                        If items.Count() <> 0 Then
                            message = items(1)
                            If String.IsNullOrEmpty(items(2)) Then
                                caption = TranslateCaption(caption)
                            Else
                                caption = items(2)
                            End If
                        End If
                    End If

                End If
            End If
        Else
            AddMessage(key, message, caption)
        End If
        Return message
    End Function

    Function GetMessage(ByVal translate As Boolean, ByVal key As String, ByRef message As String, ByRef caption As String) As String
        If Not translate Then
            Return GetOriginalMessage(key, message, caption)
        End If
        'Dim translatedMessage As String = message
        Dim cmd As String
        cmd = "SELECT IdNo FROM OriginalMessages where MessageKey = '" + key.Trim() + "'"
        Dim idNo As Integer = ExecScalar(Of Int16)(cmd)
        If idNo <> 0 Then
            Dim textDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name.ToLower()
            cmd = "SELECT TranslatedMessage, TranslatedCaption FROM TranslatedMessages_View where MessageIdNo = " + idNo.ToString() + " and Lower(CultureInfoCode) = '" + textDisplayLanguage.TrimEnd + "'"
            Dim items As Collection = ExecReader(cmd)
            If Not (items Is Nothing OrElse items.Count = 0) Then
                message = items(1)
                If Not String.IsNullOrEmpty(items(2)) Then
                    caption = Strings.Trim(items(2))
                Else
                    caption = TranslateCaption(items(2))
                End If
            Else
                Dim languageBaseCode = Left(textDisplayLanguage, textDisplayLanguage.IndexOf("-", StringComparison.Ordinal))
                cmd = "SELECT TranslatedMessage, TranslatedCaption from TranslatedMessages_View where MessageIdNo = " + idNo.ToString() + " and RTrim(LanguageCode2) = '" + languageBaseCode + "' "
                items = ExecReader(cmd)
                If Not (items Is Nothing OrElse items.Count = 0) Then
                    message = message
                    If String.IsNullOrEmpty(caption) Then
                        caption = TranslateCaption(caption)
                    End If
                Else
                    If items.Count() <> 0 Then
                        message = items(1)
                        If String.IsNullOrEmpty(items(2)) Then
                            caption = TranslateCaption(caption)
                        Else
                            caption = items(2)
                        End If
                    Else
                        message = GetOriginalMessage(key, message, caption)
                    End If
                End If
            End If
        Else
            AddMessage(key, message, caption)
        End If
        Return message
    End Function

    Function GetOriginalMessage(ByVal key As String, ByRef message As String, ByRef caption As String) As String
        Dim cmd As String
        Dim textDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name.ToLower()
        cmd = "SELECT Message, Caption FROM OriginalMessages where MessageKey = '" + key + "'"
        Dim items As Collection = ExecReader(cmd)
        If Not (items Is Nothing OrElse items.Count = 0) Then
            message = items(1)
            If Not String.IsNullOrEmpty(items(2)) Then
                caption = items(2)
            End If
        End If
        Return message
    End Function

    Function GetMessageCaption(ByVal key As String) As String
        Dim translatedCaption As String = ""
        Dim cmd As String
        cmd = "SELECT IdNo FROM OriginalMessages where MessageKey = '" + key.Trim() + "'"
        Dim idNo As Integer = ExecScalar(Of Int16)(cmd)
        If idNo <> 0 Then
            Dim textDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name.ToLower()
            cmd = "SELECT TranslatedCaption FROM TranslatedMessages_View where MessageIdNo = " + idNo.ToString() + " and Lower(CultureInfoCode) = '" + textDisplayLanguage.TrimEnd + "'"
            translatedCaption = ExecScalar(Of String)(cmd)
            If translatedCaption Is Nothing Then
                cmd = "SELECT Caption FROM OriginalMessages where MessageIdNo = " + idNo.ToString()
                translatedCaption = ExecScalar(Of String)(cmd)
            End If
        End If
        Return translatedCaption
    End Function

    Public Function TranslateCaption(textToTranslate As String)
        Dim translatedText = textToTranslate
        Dim textDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name.ToLower()
        If NeedToTranslateText(textDisplayLanguage) Then
            Dim cmd As String
            cmd = "SELECT Concat(Coalesce(Translated,''), '~', Caption) FROM Captions_View where Caption = '" & textToTranslate.Trim() & "' and CultureInfoCode = '" + textDisplayLanguage.TrimEnd + "'"
            translatedText = ExecScalar(Of String)(cmd)
            'If Strings.Left(translatedText, 1) <> "~" Then
            '    translatedText = Strings.Mid(translatedText, 2)
            'End If

            If translatedText IsNot Nothing AndAlso Strings.Left(translatedText, 1) <> "~" Then
                If GlobalVariables.RightToLeftLayout Then
                    translatedText = Strings.Left(translatedText, translatedText.IndexOf("~", StringComparison.CurrentCulture))
                Else
                    translatedText = Strings.Mid(translatedText, translatedText.IndexOf("~", StringComparison.CurrentCulture) + 1)
                End If
            Else
                AddCaption(textToTranslate)
                translatedText = textToTranslate
            End If

        End If
        If translatedText Is Nothing Then
            AddCaption(textToTranslate)
            translatedText = textToTranslate
        End If
        Return translatedText
    End Function

#End Region

End Class