Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer

    ''' <summary>
    ''' Database transaction boundary for account-reconciliation deletion.
    ''' </summary>
    Public Class AccountReconciliationTransactionService

        Public Function DeleteExisting(reconciliationIdNo As Integer) As Integer
            If reconciliationIdNo <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(reconciliationIdNo))
            End If

            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.DeleteAccountReconciliationAtomic", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ReconciliationIdNo", reconciliationIdNo)
                    connection.Open()
                    command.ExecuteNonQuery()
                    'SET NOCOUNT ON means ExecuteNonQuery may return -1.
                    Return 1
                End Using
            End Using
        End Function

        Public Function CompleteReview(reconciliationIdNo As Integer, reviewedBy As String) As Integer
            Return ExecuteUserProcedure("dbo.CompleteAccountReconciliationReview", reconciliationIdNo, reviewedBy, "@ReviewedBy")
        End Function

        Public Function FinalizeExisting(reconciliationIdNo As Integer, finalizedBy As String) As Integer
            Return ExecuteUserProcedure("dbo.FinalizeAccountReconciliation", reconciliationIdNo, finalizedBy, "@FinalizedBy")
        End Function

        Public Function ReopenReview(reconciliationIdNo As Integer) As Integer
            If reconciliationIdNo <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(reconciliationIdNo))
            End If

            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand("dbo.ReopenAccountReconciliationReview", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ReconciliationIdNo", reconciliationIdNo)
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return 1
                End Using
            End Using
        End Function

        Private Shared Function ExecuteUserProcedure(procedureName As String,
                                                      reconciliationIdNo As Integer,
                                                      userName As String,
                                                      userParameterName As String) As Integer
            If reconciliationIdNo <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(reconciliationIdNo))
            End If

            Using connection As New SqlConnection(GlobalVariables.DacConnectionString)
                Using command As New SqlCommand(procedureName, connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddWithValue("@ReconciliationIdNo", reconciliationIdNo)
                    Dim userParameter = command.Parameters.Add(userParameterName, SqlDbType.NVarChar, 100)
                    userParameter.Value = If(String.IsNullOrWhiteSpace(userName), CObj(DBNull.Value), CObj(userName))
                    connection.Open()
                    command.ExecuteNonQuery()
                    Return 1
                End Using
            End Using
        End Function

    End Class

End Namespace
