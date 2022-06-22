Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace AdoNet
    ' ADO.NET data access class.

    Public Class Db
        ' ** Factory pattern
        'Private ReadOnly _waitForm As New Form

        'Protected ShowWaitForm As BackgroundWorker(Of DbCommand)
        Private ReadOnly Factory As DbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient")

        'Private _exInfo As ExceptionDispatchInfo
        Private _connectionString As String
        Private Shared SecurityConnectionString As String

        'Private _waitForm As LoadingForm

        Public Sub New(Optional ByVal conn As String = Nothing)

            'showWaitForm = New BackgroundWorker(Of DBCommand)
            'AddHandler showWaitForm.DoWork, AddressOf showWaitForm_DoWorkHandler
            'AddHandler showWaitForm.RunWorkerCompleted, AddressOf showWaitForm_RunWorkerCompletedHandler

            If conn Is Nothing Then
                _connectionString = GlobalVariables.DacConnectionString
                'Dim connectionName As String = "ISPDATA"
                'ConnectionString = ConfigurationManager.ConnectionStrings(connectionName).ConnectionString
                'If ConnectionString Is Nothing Then
                '    Dim computerName = System.Windows.Forms.SystemInformation.ComputerName
                '    If computerName = $"ISPADMIN2" Then
                '        connectionName = "ISPDATA2"
                '    ElseIf computerName = $"MARCELO-DELL" Then
                '        connectionName = "ISPDATA3"
                '    End If
                '    ConnectionString = ConfigurationManager.ConnectionStrings(connectionName).ConnectionString
                'End If
                SecurityConnectionString = GlobalVariables.DacConnectionString
            Else
                'If conn = "TRANSLATIONS" Then
                '    Debugger.Break()
                'End If
                _connectionString = ConfigurationManager.ConnectionStrings(conn).ConnectionString
                'SecurityConnectionString = ConfigurationManager.ConnectionStrings(conn).ConnectionString
                'Dim x = ConnectionString
                'MessageBox.Show(x)
            End If


        End Sub

        Public Function GetConnectionString()
            Return _connectionString
        End Function

        Public Function GetSecurityConnectionString()
            Return SecurityConnectionString
        End Function

        Public Sub SetConnectionString(connectionName As String)
            _connectionString = ConfigurationManager.ConnectionStrings(connectionName).ConnectionString
        End Sub

        'Public Sub SetSecurityConnectionString(connectionName As String)
        '    SecurityConnectionString = ConfigurationManager.ConnectionStrings("ISPDATA").ConnectionString
        'End Sub

        Private _savedConnectionString As String

        Public Sub SaveConnectionString()
            _savedConnectionString = _connectionString
        End Sub

        Public Sub RestoreConnectionString()
            _connectionString = _savedConnectionString
        End Sub

        Public Function SqlRead(sql As String, ParamArray ByVal params() As Object)
            Dim arrayResult As New ArrayList
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    Try
                        tryAgain = False
                        Using command = CreateCommand(sql, connection, params)
                            Using reader = command.ExecuteReader()
                                While reader.Read()
                                    For i = 0 To CType(reader, IDataRecord).FieldCount - 1
                                        arrayResult.Add(reader(i))
                                    Next
                                End While
                            End Using
                        End Using
                    Catch ex As Exception
                        '_waitForm.Close()
                        Select Case TryToCatchError(ex)
                            Case DialogResult.Cancel
                                'Exit Do
                            Case DialogResult.Retry
                                ' do nothing
                                tryAgain = True
                                '_waitForm.Show()
                            Case Else
                                MessageBox.Show(ex.Message)
                                Throw
                        End Select
                    Finally
                        '_waitForm.Close()
                    End Try
                    If Not tryAgain Then
                        Exit Do
                    End If
                Loop
            End Using
            '_waitForm.Close()
            Return arrayResult
        End Function

        Public Function SqlReadSecurity(sql As String, ParamArray ByVal params() As Object)
            Dim arrayResult As New ArrayList
            Dim tryAgain As Boolean
            '_waitForm.Show()

            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    Try
                        tryAgain = False
                        Using command = CreateCommand(sql, connection, params)
                            Using reader = command.ExecuteReader()
                                While reader.Read()
                                    For i = 0 To CType(reader, IDataRecord).FieldCount - 1
                                        arrayResult.Add(reader(i))
                                    Next
                                End While
                            End Using
                        End Using
                    Catch ex As Exception
                        '_waitForm.Close()
                        Select Case TryToCatchError(ex)
                            Case DialogResult.Cancel
                                'Exit Do
                            Case DialogResult.Retry
                                ' do nothing
                                tryAgain = True
                                '_waitForm.Show()
                            Case Else
                                MessageBox.Show(ex.Message)
                                Throw
                        End Select
                    Finally
                        '_waitForm.Close()
                    End Try
                    If Not tryAgain Then
                        Exit Do
                    End If
                Loop
            End Using
            '_waitForm.Close()
            Return arrayResult
        End Function

        ''Delegate Function MakeDelegate(ByVal reader as object) As Object

        '' fast read and instantiate (i.e. make) a collection of objects
        'Public Iterator Function Read(Of T)(ByVal sql As String, ByVal make As Func(Of IDataReader, T), ParamArray ByVal params() As Object) As IEnumerable(Of T)
        '    'Dim retVal As Object = Nothing
        '    'Dim waitForm = New WaitForm
        '    'waitForm.Show()
        '    'Thread.Sleep(10)
        '    Do While True
        '        Try

        '            Using connection = CreateConnection()
        '                Using command = CreateCommand(sql, connection, params)

        '                    Using reader = WaitWindow.Show(AddressOf Me.ExecuteReaderMethod, Nothing, command)

        '                        If reader IsNot Nothing Then

        '                            'Using reader = command.ExecuteReader()
        '                            Dim result As Object
        '                            Do While reader.Read()

        '                                result = WaitWindow.Show(AddressOf Me.ReadWorkerMethod, "Trying to read record!", make, reader)

        '                                'result = WaitWindow.Show(AddressOf Me.ReadWorkerMethod, Nothing, Make(reader))
        '                                'Dim obj As Object
        '                                'obj = reader
        '                                'Try
        '                                'retVal = make(reader)
        '                                'Catch ex As Exception
        '                                'retVal = Nothing
        '                                'End Try
        '                                Yield result
        '                                'Yield make(reader)
        '                                'Try
        '                                '    Yield make(reader)
        '                                'Catch ex As Exception
        '                                '    MessageBox.Show(reader.Read())
        '                                'End Try
        '                            Loop
        '                        else
        '                            ' loop and try again
        '                        End If
        '                    End Using
        '                End Using
        '            End Using

        '            Exit Do

        '        Catch ex As Exception
        '            Select Case TryToCatchError(ex)
        '                Case DialogResult.Abort
        '                    Throw
        '                Case DialogResult.Retry
        '                    ' do nothing
        '                Case Else
        '                    Throw
        '            End Select
        '        End Try

        '    Loop

        'End Function

        'Private Sub ExecuteReaderMethod(ByVal sender As Object, ByVal e As WaitWindowEventArgs)
        '    Try
        '        System.Threading.Thread.Sleep(0)
        '        e.Result = e.Arguments(0).ExecuteReader()
        '    Catch ex As Exception
        '        Select Case TryToCatchError(ex)
        '            Case DialogResult.Abort
        '                Throw
        '            Case DialogResult.Retry
        '                ' do nothing
        '            Case Else
        '                Throw
        '        End Select
        '    End Try
        'End Sub

        'Private Sub ReadWorkerMethod(ByVal sender As Object, ByVal e As WaitWindowEventArgs)
        '    e.Result = Nothing
        '    Try
        '        System.Threading.Thread.Sleep(0)
        '        e.Result = e.Arguments(0).Invoke(e.Arguments(1))
        '    Catch ex As Exception
        '        Select Case TryToCatchError(ex)
        '            Case DialogResult.Abort
        '                Throw
        '            Case DialogResult.Retry
        '                ' do nothing
        '            Case Else
        '                Throw
        '        End Select
        '    End Try
        'End Sub

        ' fast read and instantiate (i.e. make) a collection of objects
        Public Iterator Function Read(Of T)(sql As String, make As Func(Of IDataReader, T),
                                             ParamArray ByVal params() As Object) As IEnumerable(Of T)
            'Dim retVal As Object = Nothing
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Try
                Using connection = CreateConnection()
                    '_waitForm.Show()
                    Do While True
                        Try
                            tryAgain = False
                            Using command = CreateCommand(sql, connection, params)
                                Using reader = command.ExecuteReader()
                                    Do While reader.Read()
                                        Yield make(reader)
                                    Loop
                                End Using
                            End Using
                        Catch ex As Exception
                            '_waitForm.Close()
                            Select Case TryToCatchError(ex)
                                Case DialogResult.Cancel
                                    'Exit Do
                                Case DialogResult.Retry
                                    ' do nothing
                                    '_waitForm.Show()
                                    tryAgain = True
                                Case Else
                                    Debugger.Break()
                                    MessageBox.Show("Missing Field " + ex.Message)
                                    Throw
                            End Select
                        Finally
                            '_waitForm.Close()
                        End Try
                        If Not tryAgain Then
                            Exit Do
                        End If
                    Loop
                End Using
            Catch ex As Exception
            Finally
                '_waitForm.Close()
            End Try
        End Function

        'Public Iterator Function Readx(Of T)(ByVal sql As String, ByVal make As Func(Of IDataReader, T), ParamArray ByVal params() As Object) As IEnumerable(Of T)
        '    Using connection = CreateConnection()
        '        Using command = CreateCommand(sql, connection, params)
        '            Using reader = command.ExecuteReader()
        '                Do While reader.Read()
        '                    Yield make(reader)
        '                Loop
        '            End Using
        '        End Using
        '    End Using
        'End Function

        ' return a scalar object

        'Public Overloads Function Scalar(ByVal sql As String, ParamArray ByVal params() As Object) As Object
        '    Dim result As Object = Nothing
        '    Do While True
        '        Try
        '            Using connection = CreateConnection()
        '                If connection IsNot Nothing Then
        '                    Using command = CreateCommand(sql, connection, params)
        '                        If params IsNot Nothing AndAlso params.Length > 0 Then
        '                            result = WaitWindow.Show(AddressOf Me.ExecuteScalarWorker, Nothing, command, sql, params)
        '                        Else
        '                            result = WaitWindow.Show(AddressOf Me.ExecuteScalarWorker, Nothing, command, sql)
        '                        End If
        '                    End Using
        '                Else
        '                    result = Nothing
        '                End If
        '            End Using
        '            Exit Do

        '        Catch ex As Exception
        '            Select Case TryToCatchError(ex)
        '                Case DialogResult.Cancel
        '                    Exit Do
        '                Case DialogResult.Abort
        '                    MessageBox.Show(ex.Message)
        '                    Throw
        '                Case DialogResult.Ignore
        '                    Exit Do
        '                Case Else
        '            End Select
        '        End Try
        '    Loop
        '    Return result
        'End Function

        'Public Overloads Function Scalar(ByVal sql As String, ByVal messageString As String, ParamArray ByVal params() As Object) As Object
        '    Dim result As Object = Nothing
        '    Do While True
        '        Dim errorTry As DialogResult = DialogResult.Abort
        '        Try
        '            Using connection = CreateConnection()
        '                Using command = CreateCommand(sql, connection, params)
        '                    If params IsNot Nothing AndAlso params.Length > 0 Then
        '                        result = WaitWindow.Show(AddressOf Me.ExecuteScalarWorker, messageString, command, sql, params)
        '                    Else
        '                        result = WaitWindow.Show(AddressOf Me.ExecuteScalarWorker, messageString, command, sql)
        '                    End If

        '                    Exit Do
        '                End Using
        '            End Using
        '        Catch ex As Exception
        '            errorTry = TryToCatchError(ex)
        '            Select Case errorTry
        '                Case DialogResult.Cancel
        '                    Exit Do
        '                Case DialogResult.Abort
        '                    MessageBox.Show(ex.Message)
        '                    Throw
        '                Case DialogResult.Ignore
        '                    Exit Do
        '                Case Else
        '            End Select
        '        End Try
        '    Loop
        '    Return result
        'End Function

        Public Function Scalar(sql As String, ParamArray ByVal params() As Object) As Object
            Dim c As Object = Nothing
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    tryAgain = False
                    Try
                        Using command = CreateCommand(sql, connection, params)
                            'Dim thread as New Thread(
                            '    Sub()
                            'showWaitForm.RunWorkerAsync(command)
                            '    End Sub
                            '    )
                            'thread.Start()
                            'thread.Join()
                            'showWaitForm.RunWorkerAsync(command)
                            c = command.ExecuteScalar()
                        End Using
                    Catch ex As Exception
                        '_waitForm.Close()
                        Select Case TryToCatchError(ex)
                            Case DialogResult.Cancel
                                'Exit Do
                            Case DialogResult.Retry
                                tryAgain = True
                                '_waitForm.Show()
                            Case Else
                                MessageBox.Show(ex.Message)
                                'Throw
                        End Select
                    Finally
                        '_waitForm.Close()
                    End Try
                    If Not tryAgain Then
                        Exit Do
                    End If
                Loop
            End Using
            '_waitForm.Close()
            'if c Is nothing Then
            '    Return ""
            'End If
            Return c
        End Function


        Public Function SecurityScalar(sql As String, ParamArray ByVal params() As Object) As Object
            Dim c As Object = Nothing
            Dim tryAgain As Boolean

            Using connection = CreateSecurityConnection()
                '_waitForm.Show()
                Do While True
                    tryAgain = False
                    Try
                        Using command = CreateCommand(sql, connection, params)
                            'Dim thread as New Thread(
                            '    Sub()
                            'showWaitForm.RunWorkerAsync(command)
                            '    End Sub
                            '    )
                            'thread.Start()
                            'thread.Join()
                            'showWaitForm.RunWorkerAsync(command)
                            c = command.ExecuteScalar()
                        End Using
                    Catch ex As Exception
                        '_waitForm.Close()
                        Select Case TryToCatchError(ex)
                            Case DialogResult.Cancel
                                'Exit Do
                            Case DialogResult.Retry
                                tryAgain = True
                                '_waitForm.Show()
                            Case Else
                                MessageBox.Show(ex.Message)
                                'Throw
                        End Select
                    Finally
                        '_waitForm.Close()
                    End Try
                    If Not tryAgain Then
                        Exit Do
                    End If
                Loop
            End Using
            '_waitForm.Close()
            'if c Is nothing Then
            '    Return ""
            'End If
            Return c
        End Function

        'Public Sub showWaitForm_DoWorkHandler(sender As Object, e As DoWorkEventArgs(Of DbCommand))
        '    e.Argument.ExecuteScalar()
        '    '_waitForm.Show()
        '    'showWaitForm.ReportProgress(progress)
        'End Sub

        'Public Sub showWaitForm_RunWorkerCompletedHandler(sender As Object,
        '                                                  e As RunWorkerCompletedEventArgs(Of DbCommand))
        '    If e.Cancelled Then
        '        'ProgressBarLabel.Text = "Cancelled"
        '        'ProgressBar.Value = 0
        '    Else
        '        'ProgressBarLabel.Text = "Done!"
        '        'ProgressBar.Value = 100
        '        'ResetProgressBarStyle()
        '    End If
        '    '_waitForm.Close()
        '    'Thread.Sleep(1000)
        '    'WaitDisplayPanel.Visible = False
        'End Sub

        'Private Function ExecuteScalarWorker(ByVal sender As Object, ByVal e As WaitWindowEventArgs)
        '    e.Result = Nothing
        '    Try
        '        System.Threading.Thread.Sleep(0)
        '        e.Result = e.Arguments(0).ExecuteScalar()
        '    Catch ex As Exception
        '        Select Case TryToCatchError(ex)
        '            Case DialogResult.Retry

        '            Case DialogResult.Cancel
        '                e.Window.Cancel()
        '            Case DialogResult.Abort
        '                MessageBox.Show(ex.Message)
        '                Throw
        '            Case Else
        '                Throw
        '        End Select
        '    End Try
        '    Return e.Result
        'End Function

        ' insert a new record

        Public Function Insert(sql As String, ParamArray ByVal params() As Object) As Integer
            Dim retValue As Int32
            Dim tryAgain As Boolean
            retValue = -1
            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    tryAgain = False
                    Using command = CreateCommand(sql & ";SELECT SCOPE_IDENTITY();", connection, params)
                        Try
                            '' ExecuteScalar returns the first column of the result set and since this is usually the IdNo this will return 0
                            '' because IdNo=0 for inserted records. THat is why the need for the ";SELECT SCOPE_IDENTITY();" to return the
                            '' Identity column (since this is usually the IdNo) this will return the IdNo of the newly added record.
                            retValue = Integer.Parse(command.ExecuteScalar().ToString())
                        Catch ex As SqlException
                            If ex.Number = 2627 OrElse ex.Number = 2601 Then
                                'Violation of UNIQUE KEY constraint <constraint name>. Cannot insert duplicate key in object <Table>. The duplicate key value is (<duplicate entry text>). The statement has been terminated.
                                Dim test As String = ex.Message
                                Dim reg = New Regex("'.*?'")
                                Dim matches = reg.Matches(test)
                                Dim tableName = matches(0).ToString()
                                Dim indexName = matches(1).ToString()
                                reg = New Regex("\(.*?\)")
                                matches = reg.Matches(test)
                                Dim duplicateValue = matches(0).ToString()
                                Dim variables =
                                        {"tableName", tableName, "indexName", indexName, "duplicateValue",
                                         duplicateValue}
                                Messaging.Show(True, "MsgDuplicateKeyValueViolation",
                                               "Cannot insert duplicate key row in object {tableName} with unique index {indexName}. The duplicate key value is {duplicateValue}!",
                                               "Unique Key Violation", variables, MessageBoxButtons.OK,
                                               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                retValue = -2  '' to indicate Unique Key Violation for now.
                            ElseIf ex.Number = 515 Then
                                MessageBox.Show(ex.Message & " Record not added ")
                                retValue = -1
                            Else
                                '_waitForm.Close()
                                Select Case TryToCatchError(ex)
                                    Case DialogResult.Cancel
                                        retValue = -1
                                        'Exit Do
                                    Case DialogResult.Retry
                                        tryAgain = True
                                        '_waitForm.Show()
                                    Case Else
                                        retValue = -1
                                        MessageBox.Show(ex.Message)
                                        Throw
                                End Select
                            End If
                        Catch ex As Exception
                            '_waitForm.Close()
                            Select Case TryToCatchError(ex)
                                Case DialogResult.Cancel
                                    retValue = -1
                                    Exit Do
                                Case DialogResult.Retry
                                    tryAgain = True
                                    '_waitForm.Show()
                                Case Else
                                    retValue = -1
                                    MessageBox.Show(ex.Message)
                                    'Throw
                            End Select
                        Finally
                            '_waitForm.Close()
                        End Try
                        If Not tryAgain Then
                            Exit Do
                        End If
                    End Using
                Loop
            End Using
            Return retValue
        End Function


        Public Function InsertNoId(sql As String, ParamArray ByVal params() As Object) As Integer
            Dim retValue As Int32
            Dim tryAgain As Boolean
            retValue = -1
            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    tryAgain = False
                    Using command = CreateCommand(sql, connection, params)
                        Try
                            '' ExecuteScalar returns the first column of the result set and since this is usually the IdNo this will return 0
                            '' because IdNo=0 for inserted records. THat is why the need for the ";SELECT SCOPE_IDENTITY();" to return the
                            '' Identity column (since this is usually the IdNo) this will return the IdNo of the newly added record.
                            command.ExecuteScalar()
                        Catch ex As SqlException
                            If ex.Number = 2627 OrElse ex.Number = 2601 Then
                                'Violation of UNIQUE KEY constraint <constraint name>. Cannot insert duplicate key in object <Table>. The duplicate key value is (<duplicate entry text>). The statement has been terminated.
                                Dim test As String = ex.Message
                                Dim reg = New Regex("'.*?'")
                                Dim matches = reg.Matches(test)
                                Dim tableName = matches(0).ToString()
                                Dim indexName = matches(1).ToString()
                                reg = New Regex("\(.*?\)")
                                matches = reg.Matches(test)
                                Dim duplicateValue = matches(0).ToString()
                                Dim variables =
                                        {"tableName", tableName, "indexName", indexName, "duplicateValue",
                                         duplicateValue}
                                Messaging.Show(True, "MsgDuplicateKeyValueViolation",
                                               "Cannot insert duplicate key row in object {tableName} with unique index {indexName}. The duplicate key value is {duplicateValue}!",
                                               "Unique Key Violation", variables, MessageBoxButtons.OK,
                                               MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                retValue = -2  '' to indicate Unique Key Violation for now.
                            ElseIf ex.Number = 515 Then
                                MessageBox.Show(ex.Message & " Record not added ")
                                retValue = -1
                            Else
                                '_waitForm.Close()
                                Select Case TryToCatchError(ex)
                                    Case DialogResult.Cancel
                                        retValue = -1
                                        'Exit Do
                                    Case DialogResult.Retry
                                        tryAgain = True
                                        '_waitForm.Show()
                                    Case Else
                                        retValue = -1
                                        MessageBox.Show(ex.Message)
                                        Throw
                                End Select
                            End If
                        Catch ex As Exception
                            '_waitForm.Close()
                            Select Case TryToCatchError(ex)
                                Case DialogResult.Cancel
                                    retValue = -1
                                    Exit Do
                                Case DialogResult.Retry
                                    tryAgain = True
                                    '_waitForm.Show()
                                Case Else
                                    retValue = -1
                                    MessageBox.Show(ex.Message)
                                    'Throw
                            End Select
                        Finally
                            '_waitForm.Close()
                        End Try
                        If Not tryAgain Then
                            Exit Do
                        End If
                    End Using
                Loop
            End Using
            Return 0
        End Function

        ' update an existing record

        Public Function Update(sql As String, ParamArray ByVal parms() As Object) As Integer
            Dim retValue As Object = Nothing
            Dim tryAgain As Boolean
            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    tryAgain = False
                    Try
                        Using command = CreateCommand(sql, connection, parms)
                            retValue = command.ExecuteNonQuery()
                        End Using
                    Catch ex As SqlException
                        '_waitForm.Close()
                        If ex.Number = 2601 OrElse ex.Number = 2627 Then
                            MessageBox.Show(
                                "Duplicate values found ....." & ex.Message & vbNewLine & "Record not saved!!",
                                "NOT Saved", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                            retValue = -1
                        Else
                            Select Case TryToCatchError(ex)
                                Case DialogResult.Cancel
                                    retValue = -1
                                    '
                                Case DialogResult.Retry
                                    tryAgain = True
                                    '_waitForm.Show()
                                Case Else
                                    retValue = -1
                                    MessageBox.Show(ex.Message)
                                    Throw
                            End Select
                        End If
                    Catch ex As Exception
                        retValue = -1
                        MessageBox.Show(ex.Message)
                        Throw
                    Finally
                        '_waitForm.Close()
                    End Try
                    If Not tryAgain Then
                        Exit Do
                    End If
                Loop
            End Using
            Return retValue
        End Function

        Public Function TvpMerge(tableValuedProcedure As String, dataTableName As DataTable, mParam As String) _
            As Integer
            Dim retValue = 0
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    Using connection = CreateConnection()
                        Using command As New SqlCommand(tableValuedProcedure)
                            Try
                                command.CommandType = CommandType.StoredProcedure
                                command.Connection = connection
                                command.Parameters.AddWithValue(mParam, dataTableName)
                                'connection.Open()
                                retValue = command.ExecuteNonQuery()
                                'connection.Close()
                                Exit Do
                            Catch ex As Exception
                                retValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    End Using
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            retValue = -1
                            'Exit Do
                        Case DialogResult.Retry
                            '_waitForm.Show()
                            tryAgain = True
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            Return retValue
        End Function

        Public Function TvpUpdate(tableValuedProcedure As String, dataTableName As DataTable, mParam As String) _
            As Integer
            Dim retValue = 0
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    Using connection = CreateConnection()
                        Using command As New SqlCommand(tableValuedProcedure)
                            Try
                                command.CommandType = CommandType.StoredProcedure
                                command.Connection = connection
                                command.Parameters.AddWithValue(mParam, dataTableName)
                                'connection.Open()
                                retValue = command.ExecuteNonQuery()
                                'connection.Close()
                                Exit Do
                            Catch ex As Exception
                                retValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    End Using
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            retValue = -1
                            'Exit Do
                        Case DialogResult.Retry
                            '_waitForm.Show()
                            tryAgain = True
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            Return retValue
        End Function

        Public Function DelUpdateTvp(Of TI)(tableValuedProcedure As String, dataTableName As DataTable, mParam As String,
                                     groupIdNo As TI) As Integer
            Dim retValue As Integer = 0
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    Using connection = CreateConnection()
                        Using command As New SqlCommand(tableValuedProcedure)
                            Try
                                command.CommandType = CommandType.StoredProcedure
                                command.Connection = connection
                                command.Parameters.AddWithValue(mParam, dataTableName)
                                command.Parameters.AddWithValue("GroupIdNo", groupIdNo)
                                'connection.Open()
                                Dim x = command.ExecuteNonQuery()
                                retValue = x
                                'connection.Close()
                                Exit Do
                            Catch ex As Exception
                                retValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    End Using
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            'Exit Do
                            retValue = -1
                        Case DialogResult.Retry
                            '_waitForm.Show()
                            tryAgain = True
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            Return retValue
        End Function

        Public Function InsertTvp(tableValuedProcedure As String, dataTableName As DataTable) _
            As Integer
            Dim returnValue As Integer
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    Using connection = CreateConnection()
                        Using command As New SqlCommand(tableValuedProcedure)
                            Try
                                command.CommandType = CommandType.StoredProcedure
                                command.Connection = connection
                                command.Parameters.AddWithValue("@MParam", dataTableName)
                                returnValue = command.ExecuteNonQuery()
                            Catch ex As Exception
                                returnValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    End Using
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            returnValue = -1
                            'Exit Do
                        Case DialogResult.Retry
                            ' do nothing
                            tryAgain = True
                            '_waitForm.Show()
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            Return returnValue
        End Function

        Public Function UpdateInsertTvp(Of TI)(updateTvp As String, updateDataTableName As DataTable, insertDataTableName As DataTable, groupIdNo As TI) _
            As Integer
            Dim returnValue As Integer
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    Using connection = CreateConnection()
                        Using command As New SqlCommand(updateTvp)
                            Try
                                command.CommandType = CommandType.StoredProcedure
                                command.Connection = connection
                                command.Parameters.AddWithValue("@MParam1", updateDataTableName)
                                command.Parameters.AddWithValue("@MParam2", insertDataTableName)
                                command.Parameters.AddWithValue("@groupIdNo", groupIdNo)
                                returnValue = command.ExecuteNonQuery()
                            Catch ex As Exception
                                returnValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    End Using
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            returnValue = -1
                            'Exit Do
                        Case DialogResult.Retry
                            ' do nothing
                            tryAgain = True
                            '_waitForm.Show()
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            Return returnValue
        End Function

        Public Function UpdateInsertTvp2(Of TI1, TI2)(updateTvp As String, updateDataTableName As DataTable, insertDataTableName As DataTable, groupIdNo1 As TI1, groupIdNo2 As TI2) _
            As Integer
            Dim returnValue As Integer
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    Using connection = CreateConnection()
                        Using command As New SqlCommand(updateTvp)
                            Try
                                command.CommandType = CommandType.StoredProcedure
                                command.Connection = connection
                                command.Parameters.AddWithValue("@MParam1", updateDataTableName)
                                command.Parameters.AddWithValue("@MParam2", insertDataTableName)
                                command.Parameters.AddWithValue("@groupIdNo1", groupIdNo1)
                                command.Parameters.AddWithValue("@groupIdNo2", groupIdNo2)
                                returnValue = command.ExecuteNonQuery()
                            Catch ex As Exception
                                returnValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    End Using
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            returnValue = -1
                            'Exit Do
                        Case DialogResult.Retry
                            ' do nothing
                            tryAgain = True
                            '_waitForm.Show()
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            Return returnValue
        End Function

        ' delete a record

        Public Function Delete(sql As String) As Integer
            Dim retValue = 0
            Dim tryAgain As Boolean
            Using connection = CreateConnection()
                '_waitForm.Show()
                Do While True
                    Try
                        Using command = CreateCommand(sql, connection)
                            Try
                                retValue = command.ExecuteNonQuery()
                                Exit Do
                            Catch ex As SqlException
                                retValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    Catch ex As Exception
                        '_waitForm.Close()
                        Select Case TryToCatchError(ex)
                            Case DialogResult.Cancel
                                retValue = -1
                                'Exit Do
                            Case DialogResult.Retry
                                ' do nothing
                                tryAgain = True
                                '_waitForm.Show()
                            Case Else
                                retValue = -1
                                MessageBox.Show(ex.Message)
                                Throw
                        End Select
                    Finally
                        '_waitForm.Close()
                    End Try
                    If Not tryAgain Then
                        Exit Do
                    End If
                Loop
            End Using
            Return retValue
        End Function

        ' creates a connection object

        Private Function CreateConnection() As DbConnection
            Dim connection As DbConnection = Nothing
            ' ** Factory pattern in action
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    connection = Factory.CreateConnection()
                    connection.ConnectionString = _connectionString
                    connection.Open()
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            'Exit Do
                        Case DialogResult.Retry
                            ' do nothing
                            tryAgain = True
                            '_waitForm.Show()
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            '_waitForm.Close()
            Return connection
        End Function

        Private Function CreateSecurityConnection() As DbConnection
            Dim connection As DbConnection = Nothing
            ' ** Factory pattern in action
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    connection = Factory.CreateConnection()
                    connection.ConnectionString = SecurityConnectionString
                    connection.Open()
                Catch ex As Exception
                    '_waitForm.Close()
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            'Exit Do
                        Case DialogResult.Retry
                            ' do nothing
                            tryAgain = True
                            '_waitForm.Show()
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    '_waitForm.Close()
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            '_waitForm.Close()
            Return connection
        End Function
        ' creates a connection object

        'Private Function CreateConnection() As DbConnection
        '    ' ** Factory pattern in action
        '    'Try
        '    'If _waitForm Is Nothing Then
        '    '    _waitForm = New LoadingForm()
        '    'End If
        '    '_waitForm.Show()

        '    Dim result = WaitWindow.Show(AddressOf Me.CreateConnectionWorkerMethod, Nothing)

        '    'Dim connection = _factory.CreateConnection()
        '    'connection.ConnectionString = ConnectionString
        '    'If connection.State = ConnectionState.Closed Then
        '    '    connection.Open()
        '    'End If

        '    '_waitForm.Hide()

        '    Return result

        '    'Catch ex As Exception
        '    '    If ex.InnerException IsNot Nothing AndAlso ex.InnerException.Message.Contains("Timeout Expired") Then
        '    '        Return Nothing
        '    '    ElseIf ex.InnerException IsNot Nothing AndAlso ex.InnerException.Message.Contains("Transaction Timeout") Then
        '    '        Return Nothing
        '    '    Else
        '    '        Throw
        '    '    End If

        '    'End Try

        'End Function

        'Private Sub CreateConnectionWorkerMethod(ByVal sender As Object, ByVal e As WaitWindowEventArgs)
        '    'System.Threading.Thread.Sleep(4000)
        '    System.Threading.Thread.Sleep(0)

        '    Dim connection = _factory.CreateConnection()
        '    connection.ConnectionString = ConnectionString
        '    If connection.State = ConnectionState.Closed Then
        '        connection.Open()
        '    End If

        '    e.Result = connection

        'End Sub

        ' creates a command object

        Private Function CreateCommand(sql As String, conn As DbConnection, ByVal ParamArray parms() As Object) _
            As DbCommand
            ' ** Factory pattern in action

            Dim command = Factory.CreateCommand()
            command.Connection = conn
            command.CommandText = sql
            'command.AddParameters(params)
            If parms IsNot Nothing AndAlso parms.Count > 0 Then
                command.AddParameters(parms)
            End If
            Return command
        End Function

        ' creates an adapter object

#Disable Warning IDE0051 ' Remove unused private members

        Private Function CreateAdapter(command As DbCommand) As DbDataAdapter
#Enable Warning IDE0051 ' Remove unused private members
            ' ** Factory pattern in action

            Dim adapter = Factory.CreateDataAdapter()
            adapter.SelectCommand = command
            Return adapter
        End Function

        'Private Sub WorkerMethod(sender As Object, e As WaitWindowEventArgs)
        '    'System.Threading.Thread.Sleep(4000)
        '    Thread.Sleep(0)

        '    'MessageBox.Show("please wait for me!")

        '    If e.Arguments.Count > 0 Then
        '        e.Result = e.Arguments(0).ToString()
        '    Else
        '        e.Result = "Hello World"
        '    End If
        'End Sub

        'Private Sub ProgressWorkerMethod(sender As Object, e As WaitWindowEventArgs)
        '    For progress = 1 To 100
        '        Thread.Sleep(20)
        '        e.Window.Message = String.Format("Please wait ... {0}%", progress.ToString().PadLeft(3))
        '    Next

        '    If e.Arguments.Count > 0 Then
        '        e.Result = e.Arguments(0).ToString()
        '    Else
        '        e.Result = "Hello World"
        '    End If
        'End Sub

        'Private Sub ErroringWorkerMethod(sender As Object, e As WaitWindowEventArgs)
        '    Thread.Sleep(2000)
        '    Throw New ApplicationException("Something went wrong here")
        'End Sub

        'Private Sub CancelingWorkerMethod(sender As Object, e As WaitWindowEventArgs)
        '    Thread.Sleep(2000)
        '    e.Window.Cancel()
        '    Thread.Sleep(2000)
        '    e.Result = "Hello World.  All done"
        'End Sub

        Public Function TryToCatchError(ByRef ex As Exception) As Integer
            If ex.Message.ToUpper().Contains("TIMEOUT") Then
                Dim answer As DialogResult =
                        MessageBox.Show(
                            String.Concat(
                                "A Timeout Exception occured. Problem connecting to Data Server. Do you want to try again?"),
                            "Data Connection Problem!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question)
                If answer = DialogResult.Cancel Then
                    Return DialogResult.Cancel
                Else
                    Return DialogResult.Retry
                End If
            Else
                'Debugger.Break()
                MessageBox.Show(ex.Message)
                Return DialogResult.Abort
            End If
        End Function

        Public Function ExecuteCommands(transactionName As String, commands As Object) As Integer
            Dim retValue As Integer
            retValue = 0
            Using connection As New SqlConnection(_connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction

                ' Start a local transaction
                transaction = connection.BeginTransaction(transactionName)

                ' Must assign both transaction object and connection
                ' to Command object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                Try
                    For Each item In commands
                        command.CommandText = item
                        command.ExecuteNonQuery()
                    Next

                    ' Attempt to commit the transaction.
                    transaction.Commit()
                    retValue = 1
                Catch ex As Exception
                    MessageBox.Show("Commit Exception Type: " & ex.GetType().ToString())
                    MessageBox.Show("  Message: {0}", ex.Message)

                    ' Attempt to roll back the transaction.
                    Try
                        transaction.Rollback()
                    Catch ex2 As Exception
                        ' This catch block will handle any errors that may have occurred
                        ' on the server that would cause the rollback to fail, such as
                        ' a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                        Console.WriteLine("  Message: {0}", ex2.Message)
                    End Try
                    retValue = -1
                End Try
            End Using
            Return retValue
        End Function

        Public Function ExecuteNonQueryCommands(transactionName As String, commandsWithParameters As List(Of DaoCommand)) As Integer
            Dim retValue As Integer
            retValue = 0
            Using connection As New SqlConnection(_connectionString)
                connection.Open()
                Dim transaction As SqlTransaction
                ' Start a local transaction
                transaction = connection.BeginTransaction(transactionName)
                Try
                    Dim command = Factory.CreateCommand()
                    command.Connection = connection
                    command.Transaction = transaction
                    retValue = 0
                    For Each item as DaoCommand In commandsWithParameters
                        command.Parameters.Clear()
                        command.CommandText = item.CommandText
                        If item.Parameters IsNot Nothing AndAlso item.Parameters.Length() > 0 Then
                            command.AddParameters(item.Parameters)
                        End If
                        retValue += command.ExecuteNonQuery()
                    Next
                    ' Attempt to commit the transaction.
                    transaction.Commit()                    
                Catch ex As Exception
                    MessageBox.Show("Commit Exception Type: " & ex.GetType().ToString())
                    MessageBox.Show("  Message: {0}", ex.Message)

                    ' Attempt to roll back the transaction.
                    Try
                        transaction.Rollback()
                    Catch ex2 As Exception
                        ' This catch block will handle any errors that may have occurred
                        ' on the server that would cause the rollback to fail, such as
                        ' a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                        Console.WriteLine("  Message: {0}", ex2.Message)
                    End Try
                    retValue = -1
                End Try
            End Using
            Return retValue
        End Function

        Public Function ExecuteSqlTransaction(transactionName As String, sql1 As String, Optional sql2 As String = "", Optional returnValue As Object = Nothing) As Integer
            Dim retValue As Integer
            retValue = 0
            Using connection As New SqlConnection(_connectionString)
                connection.Open()

                Dim command As SqlCommand = connection.CreateCommand()
                Dim transaction As SqlTransaction

                ' Start a local transaction
                transaction = connection.BeginTransaction(transactionName)

                ' Must assign both transaction object and connection
                ' to Command object for a pending local transaction.
                command.Connection = connection
                command.Transaction = transaction

                Try
                    command.CommandText = sql1
                    command.ExecuteNonQuery()
                    If Not (sql2 Is Nothing Or sql2 = "") Then
                        command.CommandText = sql2
                        command.ExecuteNonQuery()
                    End If

                    ' Attempt to commit the transaction.
                    transaction.Commit()
                Catch ex As Exception
                    MessageBox.Show("Commit Exception Type: " & ex.GetType().ToString())
                    MessageBox.Show("  Message: {0}", ex.Message)

                    ' Attempt to roll back the transaction.
                    Try
                        transaction.Rollback()
                    Catch ex2 As Exception
                        ' This catch block will handle any errors that may have occurred
                        ' on the server that would cause the rollback to fail, such as
                        ' a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType())
                        Console.WriteLine("  Message: {0}", ex2.Message)
                    End Try
                    retValue = -1
                End Try
            End Using
            Return retValue
        End Function

        Public Function FieldExistInTable(tableName As String, fieldName As String)
            Dim retValue As Boolean
            Dim tryAgain As Boolean
            '_waitForm.Show()
            Do While True
                tryAgain = False
                Try
                    Using connection = CreateConnection()
                        Using command As New SqlCommand("spFieldExistInTable")
                            Try
                                command.CommandType = CommandType.StoredProcedure
                                command.Connection = connection
                                command.Parameters.AddWithValue("TableName", tableName)
                                command.Parameters.AddWithValue("FieldName", fieldName)
                                Dim sqp As SqlParameter = New SqlParameter("retValue", SqlDbType.Int)
                                sqp.Direction = ParameterDirection.ReturnValue
                                command.Parameters.Add(sqp)
                                command.ExecuteScalar()
                                retValue = Convert.ToBoolean(sqp.Value)
                                'command.Connection = connection
                                'command.Parameters.AddWithValue("TableName", tableName)
                                'command.Parameters.AddWithValue("FieldName", fieldName)
                                ''Create a SqlParameter object to hold the output parameter value
                                'Dim retValParam As New SqlParameter("@retValue", SqlDbType.Int)
                                ''IMPORTANT - must set Direction as ReturnValue
                                'retValParam.Direction = ParameterDirection.ReturnValue
                                ''Now you can grab the output parameter's value...
                                ''Call the proc...
                                'Dim y = command.ExecuteNonQuery()
                                'Dim x = Convert.ToInt32(retValParam.Value)
                                'Exit Do
                            Catch ex As Exception
                                retValue = 0
                                MessageBox.Show(ex.Message)
                                Throw
                            End Try
                        End Using
                    End Using
                Catch ex As Exception
                    Select Case TryToCatchError(ex)
                        Case DialogResult.Cancel
                            retValue = -1
                        Case DialogResult.Retry
                            tryAgain = True
                        Case Else
                            MessageBox.Show(ex.Message)
                            Throw
                    End Select
                Finally
                    ' nothing
                End Try
                If Not tryAgain Then
                    Exit Do
                End If
            Loop
            Return retValue
        End Function

    End Class

    'Public Class CommandsWithParameters
    '    Dim sqlCommands As List(Of String)
    '    Dim sqlParameters As SqlParameter = New SqlParameter("retValue", SqlDbType.Int)    

    'End Class

    Public Module DbExtensions
        ' adds parameters to a command object

        <Extension>
        Public Sub AddParameters(command As DbCommand, parms() As Object)
            If parms IsNot Nothing AndAlso parms.Length > 0 Then

                ' ** Iterator pattern

                ' NOTE: processes a name/value pair at each iteration

                For i = 0 To parms.Length - 1 Step 2
                    Dim name As String = parms(i).ToString()

                    ' no empty strings to the database

                    If TypeOf parms(i + 1) Is String AndAlso CStr(parms(i + 1)) = "" Then
                        parms(i + 1) = Nothing
                    End If

                    ' if null, set to DbNull

                    If TypeOf parms(i + 1) Is Image Then
                        Dim imageParameter As SqlParameter = New SqlParameter("@imgdata", SqlDbType.Image)
                        imageParameter.Value = DBNull.Value
                        command.Parameters.Add(imageParameter)
                    Else
                        Dim value As Object = If(parms(i + 1), DBNull.Value)
                        ' ** Factory pattern
                        Dim dbParameter = command.CreateParameter()
                        dbParameter.ParameterName = name
                        dbParameter.Value = value
                        command.Parameters.Add(dbParameter)
                    End If

                Next i
            End If
        End Sub

    End Module
End Namespace