Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for AccountReconciliation
    ' ** DAO Pattern

    Public Class AccountReconciliationDao
        Implements IDao(Of AccountReconciliation) ', IDaoChild(Of AccountReconciliationItem)

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
            Dim data = Db.Read(sql, Make, params).FirstOrDefault()
            Dim arDao = New AccountReconciliationItemDao()
            data.AccountReconciliationItems = arDao.GetRecordsWithIdNo(idNo, "Sequence")
            'For Each item In data.AccountReconciliationItems
            '    data.TotalDebits += item.Debit
            '    data.TotalCredits += item.Credit
            'Next
            Return data
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

        'Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of AccountReconciliationItem) Implements IDaoChild(Of AccountReconciliationItem).GetRecordsWithIdNo
        '    Dim arDao = New AccountReconciliationItemDao()
        '    Return arDao.GetRecordsWithIdNo(idNo, sortExpression)
        'End Function

        'Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of AccountReconciliationItem).DelUpdateTvp
        '    Dim arDao = New AccountReconciliationItemDao()
        '    Return arDao.DelUpdateTvp(tvpTable, groupIdNo)
        'End Function

        'Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of AccountReconciliationItem).InsertTvp
        '    Dim arDao = New AccountReconciliationItemDao()
        '    Return arDao.InsertTvp(tvpTable)
        'End Function
    End Class

End Namespace