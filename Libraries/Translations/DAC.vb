Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Dac
    Inherits Component

    ' Generated form code omitted

#Region " Declarations and properties "

    Public Const SqlError = "Error connecting to server"
    Public Const MdbError = "Error opening MDB file"
    Public Const DbfError = "Error with DBF directory or DBC"
    Public Const FillError = "Error filling dataset"
    Public Const NonQueryError = "Error executing nonquery statement"

    Public Da As Object
    Public Cn As Object
    Public Dc As Object

    <Category("AATM")> Public Property DacAccessType As String = "SQL"
    <Category("AATM")> Public Property DacFileName As String = "Translations"
    <Category("AATM")> Public Property DacDatabase As String = "Translations"
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

                    Do While reader.Read()
                        result.Add(reader.GetString(0))
                        result.Add(reader.GetString(1))
                    Loop
                End If

            End Using
        Catch ex As Exception
            'status = "Error"
            ErrorMessage(ex, NonQueryError)
            result = Nothing
        Finally
            If Cn.state = ConnectionState.Open Then Cn.close()
        End Try
        Return result

    End Function

    Public Function ExecScalar(Of T)(ByVal cmd As String) As T
        Dim retVal As T
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

#End Region

End Class