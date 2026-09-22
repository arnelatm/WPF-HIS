Imports System.Data
Imports System.Data.SqlClient
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class PayrollJournalTransactionService
        Public Function CreateForPayroll(payrollIdNo As Int16, notes As String, ByRef alreadyExists As Boolean) As Integer
            If payrollIdNo <= 0 Then Throw New InvalidOperationException("A saved payroll record is required.")

            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),
                  cmd As New SqlCommand("dbo.CreatePayrollGeneralJournalAtomic", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@PayrollIdNo", SqlDbType.SmallInt).Value = payrollIdNo
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 300).Value = If(String.IsNullOrWhiteSpace(notes), CType(DBNull.Value, Object), notes)

                Dim journalId = cmd.Parameters.Add("@JournalIdNo", SqlDbType.Int)
                journalId.Direction = ParameterDirection.Output
                Dim exists = cmd.Parameters.Add("@AlreadyExists", SqlDbType.Bit)
                exists.Direction = ParameterDirection.Output

                cn.Open()
                AATM.DataLayer.AdoNet.AuditContext.Apply(cn)
                cmd.ExecuteNonQuery()

                alreadyExists = Convert.ToBoolean(exists.Value)
                Return Convert.ToInt32(journalId.Value)
            End Using
        End Function
    End Class
End Namespace
