Imports System.Data
Imports System.Data.Common
Imports AATM.Libraries.GlobalFuncNSub

Namespace AdoNet

    ''' <summary>
    ''' Copies the Accounts user context into each SQL session. Audit procedures
    ''' read these values through SESSION_CONTEXT rather than trusting the SQL
    ''' login identity, which is commonly shared by desktop clients.
    ''' </summary>
    Public NotInheritable Class AuditContext
        Private Sub New()
        End Sub

        Public Shared Sub Apply(connection As DbConnection)
            If connection Is Nothing OrElse connection.State <> ConnectionState.Open Then Return

            Using command = connection.CreateCommand()
                command.CommandText =
                    "EXEC sys.sp_set_session_context @key=N'AuditUserIdNo', @value=@UserIdNo;" &
                    "EXEC sys.sp_set_session_context @key=N'AuditUserName', @value=@UserName;" &
                    "EXEC sys.sp_set_session_context @key=N'AuditBranchIdNo', @value=@BranchIdNo;" &
                    "EXEC sys.sp_set_session_context @key=N'AuditApplicationName', @value=N'Accounts';" &
                    "EXEC sys.sp_set_session_context @key=N'AuditMachineName', @value=@MachineName;"

                AddParameter(command, "@UserIdNo", If(GlobalVariables.UserIdNo > 0, CType(GlobalVariables.UserIdNo, Object), DBNull.Value))
                AddParameter(command, "@UserName", If(GlobalVariables.UserName, CType(DBNull.Value, Object)))
                AddParameter(command, "@BranchIdNo", If(GlobalVariables.BranchIdNo > 0, CType(GlobalVariables.BranchIdNo, Object), DBNull.Value))
                AddParameter(command, "@MachineName", Environment.MachineName)
                command.ExecuteNonQuery()
            End Using
        End Sub

        Private Shared Sub AddParameter(command As DbCommand, name As String, value As Object)
            Dim parameter = command.CreateParameter()
            parameter.ParameterName = name
            parameter.Value = If(value, DBNull.Value)
            command.Parameters.Add(parameter)
        End Sub
    End Class

End Namespace
