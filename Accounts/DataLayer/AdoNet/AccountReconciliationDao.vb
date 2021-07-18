Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for AccountReconciliation
    ' ** DAO Pattern

    Public Class AccountReconciliationDao
        Inherits AccountsDao
        Implements IDao(Of AccountReconciliation), IDaoChild(Of AccountReconciliationItem), IDaoAccountReconciliationItem(Of AccountReconciliationItem)

        Private ReadOnly _db As New Db()
        Protected TableFileName As String = "AccountReconciliationItem_View"
        Protected DboTvpUpdateFileName As String = "dbo.UpdateAccountReconciliationItemTVP"
        Protected DboTvpInsertFileName As String = "dbo.InsertAccountReconciliationItemTVP"

        Public Function GetRecordByIdNo(idNo) As AccountReconciliation _
            Implements IDao(Of AccountReconciliation).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " &
                    "AccountIdNo," &
                    "Balance," &
                    "DateCreated," &
                    "IdNo," &
                    "Posted," &
                    "ReconciliationDate" &
                    " FROM [AccountReconciliation]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data As AccountReconciliation = _db.Read(sql, Make, params).FirstOrDefault()
            'Dim accounts As List(Of Lookup.LookupData) = GetLookupData("Account", "AccountCode", "SpecialAccount = 'BA' or SpecialAccount = 'CK' or SpecialAccount = 'CS'")
            'data.Accounts = accounts
            data.AccountReconciliationItems = GetRecordsWithGroupIdNo(idNo, "Sequence")
            data.ComputeCalculatedProperties()
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
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(accountReconciliation))
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
            Return _db.Insert(sql, Take(accountReconciliation))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, AccountReconciliation) =
                                    Function(reader) _
            New AccountReconciliation() With {
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .Balance = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Balance")),
            .Posted = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Posted")),
            .ReconciliationDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("ReconciliationDate"))
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

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortExpression = Nothing) As List(Of AccountReconciliationItem) _
            Implements IDaoChild(Of AccountReconciliationItem).GetRecordsWithGroupIdNo
            If sortExpression Is Nothing Then
                sortExpression = "Sequence"
            End If
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
            Dim x = _db.Read(sql, MakeAccountReconciliationItem).ToList()
            Return x
        End Function

        Public Function GetReconciledRecordsWithIdNo(reconciled As Boolean, idNo As Int32, Optional sortExpression As String = Nothing) _
            As List(Of AccountReconciliationItem) Implements IDaoAccountReconciliationItem(Of AccountReconciliationItem).GetReconciledRecordsWithIdNo
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
            Dim x = _db.Read(sql, MakeAccountReconciliationItem).ToList()
            Return x
        End Function

        Public Shared ReadOnly MakeAccountReconciliationItem As Func(Of IDataReader, AccountReconciliationItem) = Function(reader) New AccountReconciliationItem() With
            {
            .AccountIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("AccountIdNo")),
            .AccountReconciliationIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("AccountReconciliationIdNo")),
            .Cleared = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("Cleared")),
            .Credit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Credit")),
            .Debit = AATM.DataLayer.AdoNet.Extensions.AsDecimal(reader("Debit")),
            .DocumentNumber = AATM.DataLayer.AdoNet.Extensions.AsString(reader("DocumentNumber")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo")),
            .JournalCode = AATM.DataLayer.AdoNet.Extensions.AsString(reader("JournalCode")),
            .JournalIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalIdNo")),
            .JournalItemIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Integer)(reader("JournalItemIdNo")),
            .PayDescription = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayDescription")),
            .PayDescriptionAra = AATM.DataLayer.AdoNet.Extensions.AsString(reader("PayDescriptionAra")),
            .TransactionDate = AATM.DataLayer.AdoNet.Extensions.AsDate(reader("TransactionDate")),
            .ReferenceNo = AATM.DataLayer.AdoNet.Extensions.AsString(reader("ReferenceNo")),
            .Sequence = AATM.DataLayer.AdoNet.Extensions.AsString(reader("Sequence"))
            }

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of AccountReconciliationItem).DelUpdateTvp
            Return _db.DelUpdateTvp(DboTvpUpdateFileName, tvpTable, "@MParam", groupIdNo)
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of AccountReconciliationItem).InsertTvp
            Return _db.InsertTvp(DboTvpInsertFileName, tvpTable)
        End Function

        Public Function GetAcctReconItems(AccountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) _
            As List(Of AccountReconciliationItem) Implements IDaoAccountReconciliationItem(Of AccountReconciliationItem).GetAcctReconItems
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
                    " WHERE AccountIdNo = " & AccountIdNo &
                    " and TransactionDate <= '" & DtoS(reconciliationDate) & "'" &
                    " and Reconciled Is Null" &
                    " ORDER BY " & sortExpression
            Dim x = _db.Read(sql, MakeAccountReconciliationItem).ToList()
            Return x
        End Function

        Public Function GetGlItems(AccountIdNo As Int16, reconciliationDate As Date, Optional sortExpression As String = Nothing) _
            As List(Of AccountReconciliationItem) Implements IDaoAccountReconciliationItem(Of AccountReconciliationItem).GetGlItems
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
                    " WHERE AccountIdNo = " & AccountIdNo &
                    " and (Reconciled = 0 OR Reconciled is NULL)" &
                    " and TransactionDate <= '" & DtoS(reconciliationDate) & "'" &
                    " ORDER BY " & sortExpression
            Dim x = _db.Read(sql, MakeAccountReconciliationItem).ToList()
            Return x
        End Function

        Public Function GetLookupData(listName As String, sortKey As String, Optional filter As String = Nothing)
            Dim lookUpTableToGet As String = listName
            Dim lookUpDisplayName As String = listName + "Name"
            Dim lookUpSortExpression As String = lookUpDisplayName
            Dim lookUpDisplayNameArabic As String = lookUpDisplayName + "Ara"
            Dim lookUpDisplayCode As String = listName + "Code"
            Dim lookupFieldsToShow As String()
            If sortKey IsNot Nothing Then
                lookUpSortExpression = sortKey
            End If
            Dim dFieldName As String
            If IsRightToLeft(CultureInfo.CurrentCulture.ToString()) Then
                If lookUpSortExpression = lookUpDisplayName Then
                    lookUpSortExpression = lookUpDisplayNameArabic
                End If
                dFieldName = lookUpDisplayNameArabic
            Else
                dFieldName = lookUpDisplayName
            End If
            lookupFieldsToShow = {"IdNo", dFieldName, lookUpDisplayCode}
            Dim baseDao = New BaseDao
            Dim data = baseDao.GetRecords(listName, sortKey, lookupFieldsToShow, filter)
            Return ProcessLookupByCodeName(data, lookupFieldsToShow.Count())
        End Function

        Private Function ProcessLookupByCodeName(data As Object, fieldCount As UInt16) As List(Of Lookup.LookupData)
            Dim tlData As New List(Of Lookup.LookupData)
            If fieldCount = 3 Then
                For i = 1 To Int(data.Count / 3)
                    Dim tData As New Lookup.LookupData With {.IdNo = data(i * 3 - 3),
                            .Name = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1)) & " | " & data(i * 3 - 2),
                            .Code = If(IsDBNull(data(i * 3 - 1)), "", data(i * 3 - 1))
                            }
                    tlData.Add(tData)
                Next
            Else
                For i = 1 To Int(data.Count / 2)
                    Dim tData As New Lookup.LookupData With {.IdNo = data(i * 2 - 2),
                            .Name = If(IsDBNull(data(i * 2 - 1)), "", data(i * 2 - 1)) & " | " & data(i * 2 - 2)
                            }
                    tlData.Add(tData)
                Next
            End If
            Return tlData
        End Function

        'Dim values = accountType.Split(",")
        'FilterKey = ""
        'For Each account In values
        'If FilterKey <> "" Then
        'FilterKey = FilterKey + " Or "
        'End If
        'FilterKey = FilterKey + "SpecialAccount = '" & account & "'"
        'Next

    End Class

End Namespace