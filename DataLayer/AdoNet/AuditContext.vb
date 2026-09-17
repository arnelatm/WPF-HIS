Imports System.Data
Imports System.Data.Common
Imports AATM.Libraries.GlobalFuncNSub

Namespace AdoNet

    ''' <summary>
    ''' Copies the Accounts user context into each SQL session. The context is
    ''' stored by dbo.SetAuditSessionContext so this also works on SQL Server
    ''' 2014, which does not provide SESSION_CONTEXT.
    ''' </summary>
    Public NotInheritable Class AuditContext
        Private Sub New()
        End Sub

        Public Shared Sub Apply(connection As DbConnection)
            If connection Is Nothing OrElse connection.State <> ConnectionState.Open Then Return

            Using checkCommand = connection.CreateCommand()
                checkCommand.CommandText = "SELECT CASE WHEN OBJECT_ID(N'dbo.SetAuditSessionContext', N'P') IS NULL THEN 0 ELSE 1 END"
                If Convert.ToInt32(checkCommand.ExecuteScalar()) = 0 Then Return
            End Using

            Using command = connection.CreateCommand()
                command.CommandText = "dbo.SetAuditSessionContext"
                command.CommandType = CommandType.StoredProcedure

                AddParameter(command, "@UserIdNo", If(GlobalVariables.UserIdNo > 0, CType(GlobalVariables.UserIdNo, Object), DBNull.Value))
                AddParameter(command, "@UserNameSnapshot", If(GlobalVariables.UserName, CType(DBNull.Value, Object)))
                AddParameter(command, "@BranchIdNo", If(GlobalVariables.BranchIdNo > 0, CType(GlobalVariables.BranchIdNo, Object), DBNull.Value))
                AddParameter(command, "@ApplicationName", "Accounts")
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
