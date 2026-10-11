Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports AATM.Libraries.GlobalFuncNSub

Namespace ServiceLayer
    Public Class PayrollJournalTransactionService
        Public Function PreviewForPayroll(payrollIdNo As Int16,
                                          notes As String,
                                          ByRef journalIdNo As Integer,
                                          ByRef alreadyExists As Boolean) As List(Of PayrollJournalPreviewLine)
            If payrollIdNo <= 0 Then Throw New InvalidOperationException("A saved payroll record is required.")
            Dim lines As New List(Of PayrollJournalPreviewLine)
            Using cn As New SqlConnection(GlobalVariables.DacConnectionString),
                  cmd As New SqlCommand("dbo.CreatePayrollGeneralJournalAtomic", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@PayrollIdNo", SqlDbType.SmallInt).Value = payrollIdNo
                cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, 300).Value = If(String.IsNullOrWhiteSpace(notes), CType(DBNull.Value, Object), notes)
                Dim journalId = cmd.Parameters.Add("@JournalIdNo", SqlDbType.Int)
                journalId.Direction = ParameterDirection.Output
                Dim exists = cmd.Parameters.Add("@AlreadyExists", SqlDbType.Bit)
                exists.Direction = ParameterDirection.Output
                cmd.Parameters.Add("@PreviewOnly", SqlDbType.Bit).Value = True
                cn.Open()
                AATM.DataLayer.AdoNet.AuditContext.Apply(cn)
                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        lines.Add(New PayrollJournalPreviewLine With {
                            .Sequence = Convert.ToInt32(reader("Sequence")),
                            .AccountCode = Convert.ToString(reader("AccountCode")),
                            .AccountName = Convert.ToString(reader("AccountName")),
                            .EmployeeName = Convert.ToString(reader("EmployeeName")),
                            .RevCostCenterCode = Convert.ToString(reader("RevCostCenterCode")),
                            .RevCostCenterName = Convert.ToString(reader("RevCostCenterName")),
                            .Debit = Convert.ToDecimal(reader("Debit")),
                            .Credit = Convert.ToDecimal(reader("Credit"))
                        })
                    End While
                End Using
                journalIdNo = Convert.ToInt32(journalId.Value)
                alreadyExists = Convert.ToBoolean(exists.Value)
            End Using
            Return lines
        End Function
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
    Public Class PayrollJournalPreviewLine
        Public Property Sequence As Integer
        Public Property AccountCode As String
        Public Property AccountName As String
        Public Property EmployeeName As String
        Public Property RevCostCenterCode As String
        Public Property RevCostCenterName As String
        Public Property Debit As Decimal
        Public Property Credit As Decimal
    End Class
End Namespace
