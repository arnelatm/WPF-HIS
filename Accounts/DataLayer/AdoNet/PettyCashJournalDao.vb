' Data access object for PettyCashJournal
' ** DAO Pattern
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PettyCashJournal
    ' ** DAO Pattern

    Public Class PettyCashJournalDao
        Inherits DisbursementJournalDao
        Implements IDao(Of PettyCashJournal), IDaoJournals(Of PettyCashJournal), IDaoOiItem(Of CjOiItem)

        Public Function AddRecord(ByRef recordData As PettyCashJournal) As Integer Implements IDao(Of PettyCashJournal).AddRecord
            Return CdAddRecord(recordData)
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of CjOiItem) Implements IDaoOiItem(Of CjOiItem).GetOpenInvoices
            Return CdGetOpenInvoices(idNo)
        End Function

        Public Function GetRecordById(idNo As Object) As PettyCashJournal Implements IDao(Of PettyCashJournal).GetRecordById
            TableName = "PettyCashJournal"
            SeriesName = $"PCJOURNAL"
            Dim data As DisbursementJournal = CdGetRecordById(idNo)
            Dim result As New PettyCashJournal
            Return GlobalVariables.Mapper.Map(data, result)
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As PettyCashJournal) As Integer Implements IDaoJournals(Of PettyCashJournal).UpdateGlReferenceNumber
            Return CdUpdateGlReferenceNumber(bizObj)
        End Function

        Public Function UpdateRecord(ByRef recordData As PettyCashJournal) As Integer Implements IDao(Of PettyCashJournal).UpdateRecord
            Return CdUpdateRecord(recordData)
        End Function

        Protected Overrides Function GetCjOiItemDao()
            Dim cjOiItemDao As PcOiItemDao
            cjOiItemDao = New PcOiItemDao()
            cjOiItemDao.TableName = "PcOiItem_View"
            cjOiItemDao.DboTvpInsertName = "InsertPcOiItemTVP"
            cjOiItemDao.DboTvpUpdateName = "UpdatePcOiItemTVP"
            Return cjOiItemDao
        End Function

        Protected Overrides Function GetJiDao()
            Return New PettyCashJournalItemDao
        End Function

    End Class

End Namespace