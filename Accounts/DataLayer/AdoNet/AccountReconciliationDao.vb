Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for AccountReconciliation
    ' ** DAO Pattern

    Public Class AccountReconciliationDao
        Implements IDao(Of AccountReconciliation)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As AccountReconciliation _
            Implements IDao(Of AccountReconciliation).GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Balance," &
                    "DateCreated," &
                    "IdNo," &
                    "Posted," &
                    "ReconciliationDate" &
                    " FROM [AccountReconciliation]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef accountReconciliation As AccountReconciliation) As Integer _
            Implements IDao(Of AccountReconciliation).UpdateRecord
            Dim sql As String =
                    "UPDATE [AccountReconciliation] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Balance = @Balance," &
                    "Posted = @Posted," &
                    "ReconciliationDate = @ReconciliationDate " &
                    " WHERE IDNo = @IDNo"
            Return Db.Update(sql, Take(accountReconciliation))
        End Function

        Public Function AddRecord(ByRef accountReconciliation As AccountReconciliation) As Integer _
            Implements IDao(Of AccountReconciliation).AddRecord
            Dim sql As String =
                    " INSERT INTO [AccountReconciliation] " &
                    "(" &
                    "AccountIdNo," &
                    "Balance," &
                    "Posted," &
                    "ReconciliationDate" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Balance," &
                    "@Posted," &
                    "@ReconciliationDate" &
                    ")"
            Return Db.Insert(sql, Take(accountReconciliation))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, AccountReconciliation) =
                                    Function(reader) _
            New AccountReconciliation() With {
            .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .Posted = Extensions.AsBool(reader("Posted")),
            .ReconciliationDate = Extensions.AsDate(reader("ReconciliationDate"))
            }

        Private Function Take(accountReconciliation As AccountReconciliation) As Object()
            Return New Object() {
                                    "@AccountIdNo", accountReconciliation.AccountIdNo,
                                    "@DateCreated", accountReconciliation.DateCreated,
                                    "@IdNo", accountReconciliation.IdNo,
                                    "@Balance", accountReconciliation.Balance,
                                    "@Posted", accountReconciliation.Posted,
                                    "@ReconciliationDate", accountReconciliation.ReconciliationDate
                                }
        End Function

    End Class

End Namespace