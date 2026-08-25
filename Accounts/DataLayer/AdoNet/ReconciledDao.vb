Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Reconciled
    ' ** DAO Pattern

    Public Class ReconciledDao
        Inherits CommonDao
        Implements IDaoChild(Of Reconciled)

        Private Const FieldList = "IdNo," &
                                  "JournalCode," &
                                  "JournalItemIdNo," &
                                  "ReconciliationIdNo"

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "Reconciled"
        Protected DboTvpInsertFileName As String = "dbo.InsertReconciledTVP"

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of Reconciled) Implements IDaoChild(Of Reconciled).GetRecordsWithGroupIdNo
            Throw New NotImplementedException
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Int32) As Integer Implements IDaoChild(Of Reconciled).DelUpdateTvp
            Throw New NotImplementedException
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of Reconciled).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable)
        End Function

        'Public Function GetReconciledItem(ByVal journalCode As String, journalItemIdNo As Int32)
        '    Dim Sql = "Select IdNo, JournalCode, JournalItemIdNo, ReconciliationIdNo from Reconciled where JournalCode = @journalCode and JournalItemIdNo = @journalItemIdNo"
        '    Dim params() As Object = {"@JournalCode", journalCode, "@JournalItemIdNo", journalItemIdNo}
        '    Dim results As Reconciled = Db.Read(Sql, Make, params).FirstOrDefault()
        '    Return results
        'End Function

        Public Function IsItemReconciled(ByVal journalCode As String, journalItemIdNo As Int32)
            Dim params() As Object = {"@JournalCode", journalCode, "@JournalItemIdNo", journalItemIdNo}
            Dim sql = "SELECT COUNT(*) " &
                      "FROM Reconciled AS item " &
                      "INNER JOIN AccountReconciliation AS reconciliation " &
                      "ON reconciliation.IdNo = item.ReconciliationIdNo " &
                      "WHERE item.JournalCode = @JournalCode " &
                      "AND item.JournalItemIdNo = @JournalItemIdNo " &
                      "AND (ISNULL(reconciliation.Posted, 0) = 1 OR reconciliation.Status = 'Finalized')"
            If Db.Scalar(sql, params) > 0 Then
                Return True
            End If
            Return False
        End Function

        Public Function IsItemInLockedReconciliation(ByVal journalCode As String, journalItemIdNo As Int32) As Boolean
            Dim params() As Object = {"@JournalCode", journalCode, "@JournalItemIdNo", journalItemIdNo}
            Dim sql = "SELECT COUNT(*) " &
                      "FROM AccountReconciliationItem AS item " &
                      "INNER JOIN AccountReconciliation AS reconciliation " &
                      "ON reconciliation.IdNo = item.AccountReconciliationIdNo " &
                      "WHERE item.JournalCode = @JournalCode " &
                      "AND item.JournalItemIdNo = @JournalItemIdNo " &
                      "AND reconciliation.Status IN ('ReviewCompleted', 'Finalized')"
            Return Db.Scalar(sql, params) > 0
        End Function

        'Private Shared ReadOnly Make As Func(Of IDataReader, Reconciled) =
        '                            Function(reader) _
        '    New Reconciled() With {
        '    .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
        '    .JournalCode = Extensions.AsString(reader("JournalCode")),
        '    .JOurnalItemIdNo = Extensions.AsInt(Of Int32)(reader("JournalItemIdNo")),
        '    .ReconciliationIdNo = Extensions.AsInt(Of Int32)(reader("ReconciliationIdNo"))
        '    }

        'Public Function IsReconciled(ByVal journalCode As String, journalItemIdNo As Int32)
        '    Dim Sql = "Select Count(*) from Reconciled where JournalCode = @journalCode and JournalItemIdNo = @journalItemIdNo"
        '    Return Db.Read(Sql, Make)
        'End Function

    End Class

End Namespace
