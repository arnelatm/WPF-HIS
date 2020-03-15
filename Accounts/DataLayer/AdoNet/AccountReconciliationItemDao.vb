Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for AccountReconciliationItem
    ' ** DAO Pattern

    Public Class AccountReconciliationItemDao
        Inherits CommonDao
        Implements IDaoChild(Of AccountReconciliationItem)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "AccountReconciliationItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateAccountReconciliationItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertAccountReconciliationItemTVP"

        Public Function GetRecordById(idNo As Integer) As AccountReconciliationItem _
                        Implements IDao(Of AccountReconciliationItem).GetRecordById
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "AccountReconciliationIdNo," &
                    "Cleared," &
                    "Credit," &
                    "Debit," &
                    "DocumentNumber," &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    "   FROM " & TableFileName &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) _
            As List(Of AccountReconciliationItem) Implements IDao(Of AccountReconciliationItem).GetRecordsWithIdNo
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountReconciliationIdNo," &
                    "Cleared," &
                    "Credit," &
                    "Debit," &
                    "DocumentNumber," &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE AccountReconciliationIdNo = " & idNo &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Integer, Optional sortExpression As String = Nothing) _
            As List(Of AccountReconciliationItem) Implements IDao(Of AccountReconciliationItem).GetReconciledRecordsWithIdNo
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountReconciliationIdNo," &
                    "Cleared," &
                    "Credit," &
                    "Debit," &
                    "DocumentNumber," &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "JournalItemIdNo," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE AccountReconciliationIdNo = " & idNo & " and " &
                    IIf(reconciled, "Reconciled = 1 and Cleared = 1", "(Reconciled = 0 or Reconciled Is Null)") &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        'Public Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) _
        '    As List(Of AccountReconciliationItem) Implements IDao(Of AccountReconciliationItem).GetAcctReconItems
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "AccountReconciliationIdNo," &
        '            "Cleared," &
        '            "Credit," &
        '            "Debit," &
        '            "DocumentNumber," &
        '            "IdNo," &
        '            "JournalCode," &
        '            "JournalIdNo," &
        '            "JournalItemIdNo," &
        '            "PayDescription," &
        '            "PayDescriptionAra," &
        '            "ReferenceNo," &
        '            "Sequence," &
        '            "TransactionDate" &
        '            " FROM " & TableFileName &
        '            " WHERE AccountIdNo = " & accountIdNo &
        '            " and TransactionDate <= '" & GlobalFunctions.DtoS(reconciliationDate) & "'" &
        '            " and (Reconciled = 0 OR Posted = 1)" &
        '            " ORDER BY " & sortExpression
        '    Dim x = Db.Read(sql, Make).ToList()
        '    Return x
        'End Function

        'Public Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) _
        '    As List(Of AccountReconciliationItem) Implements IDao(Of AccountReconciliationItem).GetAcctReconItems
        '    Dim sql As String =
        '            "SELECT " &
        '            "AccountIdNo," &
        '            "AccountReconciliationIdNo," &
        '            "Cleared," &
        '            "Credit," &
        '            "Debit," &
        '            "DocumentNumber," &
        '            "IdNo," &
        '            "JournalCode," &
        '            "JournalIdNo," &
        '            "JournalItemIdNo," &
        '            "PayDescription," &
        '            "PayDescriptionAra," &
        '            "ReferenceNo," &
        '            "Sequence," &
        '            "TransactionDate" &
        '            " FROM " & TableFileName &
        '            " WHERE AccountIdNo = " & accountIdNo &
        '            " and TransactionDate <= '" & GlobalFunctions.DtoS(reconciliationDate) & "'" &
        '            " and (Reconciled = 0 OR Posted = 1)" &
        '            " ORDER BY " & sortExpression
        '    Dim x = Db.Read(sql, Make).ToList()
        '    Return x
        'End Function

        Public Function GetAcctReconItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) _
            As List(Of AccountReconciliationItem) Implements IDao(Of AccountReconciliationItem).GetAcctReconItems
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "0 as AccountReconciliationIdNo," &
                    "0 as Cleared," &
                    "Credit," &
                    "Debit," &
                    "DocumentNumber," &
                    "0 as IdNo," &
                    "IdNo as JournalItemIdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "IdNo as JournalItemIdNo," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM GlReconciliation_View" &
                    " WHERE AccountIdNo = " & accountIdNo &
                    " and TransactionDate <= '" & GlobalFunctions.DtoS(reconciliationDate) & "'" &
                    " and Reconciled Is Null" &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        'Private Shared ReadOnly MakeNew As Func(Of IDataReader, AccountReconciliationItem) =
        '                            Function(reader) _
        '    New AccountReconciliationItem() With {
        '    .AccountIdNo = Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
        '    .AccountReconciliationIdNo = Extensions.AsInt(Of Integer)(reader("AccountReconciliationIdNo")),
        '    .Credit = Extensions.AsDecimal(reader("Credit")),
        '    .Debit = Extensions.AsDecimal(reader("Debit")),
        '    .JournalItemIdNo = Extensions.AsInt(Of Integer)(reader("IdNo")),
        '    .IdNo = 0,
        '    .JournalCode = Extensions.AsString(reader("JournalCode")),
        '    .JournalIdNo = Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
        '    .PayDescription = Extensions.AsString(reader("PayDescription")),
        '    .PayDescriptionAra = Extensions.AsString(reader("PayDescriptionAra")),
        '    .ReferenceNo = Extensions.AsString(reader("ReferenceNo")),
        '    .Sequence = 0,
        '    .TransactionDate = Extensions.AsDate(reader("TransactionDate"))
        '    }

        Public Function GetGlItems(accountIdNo As Integer, reconciliationDate As Date, Optional sortExpression As String = Nothing) _
            As List(Of AccountReconciliationItem) Implements IDao(Of AccountReconciliationItem).GetGlItems
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "AccountReconciliationIdNo," &
                    "Cleared," &
                    "Credit," &
                    "Debit," &
                    "DocumentNumber," &
                    "IdNo," &
                    "JournalCode," &
                    "JournalIdNo," &
                    "PayDescription," &
                    "PayDescriptionAra," &
                    "ReferenceNo," &
                    "Sequence," &
                    "TransactionDate" &
                    " FROM " & TableFileName &
                    " WHERE AccountIdNo = " & accountIdNo &
                    " and (Reconciled = 0 OR Reconciled is NULL)" &
                    " and TransactionDate <= '" & DtoS(reconciliationDate) & "'" &
                    " ORDER BY " & sortExpression
            Dim x = Db.Read(sql, Make).ToList()
            Return x
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, accountReconciliationIdNo As Integer) As Integer _
            Implements IDaoChild(Of AccountReconciliationItem).DelUpdateTvp
            Return Db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", accountReconciliationIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of AccountReconciliationItem).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, AccountReconciliationItem) =
                                    Function(reader) _
            New AccountReconciliationItem() With {
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .AccountReconciliationIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("AccountReconciliationIdNo")),
            .Cleared = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cleared")),
            .Credit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Credit")),
            .Debit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Debit")),
            .DocumentNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DocumentNumber")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(reader("IdNo")),
            .JournalCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .JournalItemIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalItemIdNo")),
            .PayDescription = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayDescription")),
            .PayDescriptionAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayDescriptionAra")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Sequence"))
            }

        Public Shared ReadOnly MakeAccountReconciliationItem As Func(Of IDataReader, AccountReconciliationItem) = Function(reader) New AccountReconciliationItem() With
            {
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("AccountIdNo")),
            .AccountReconciliationIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("AccountReconciliationIdNo")),
            .Cleared = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cleared")),
            .Credit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Credit")),
            .Debit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Debit")),
            .DocumentNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DocumentNumber")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(reader("IdNo")),
            .JournalCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .JournalItemIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalItemIdNo")),
            .PayDescription = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayDescription")),
            .PayDescriptionAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayDescriptionAra")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Sequence"))
            }

    End Class

End Namespace