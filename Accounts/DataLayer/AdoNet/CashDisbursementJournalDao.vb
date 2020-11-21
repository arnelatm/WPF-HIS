Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for CashDisbursementJournal
    ' ** DAO Pattern

    Public Class CashDisbursementJournalDao
        Inherits DisbursementJournalDao
        Implements IDao(Of CashDisbursementJournal), IDaoJournals(Of CashDisbursementJournal), IDaoOiItem(Of CjOiItem)

        Public Function AddRecord(ByRef recordData As CashDisbursementJournal) As Integer Implements IDao(Of CashDisbursementJournal).AddRecord
            Return CdAddRecord(recordData)
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of CjOiItem) Implements IDaoOiItem(Of CjOiItem).GetOpenInvoices
            Return CdGetOpenInvoices(idNo)
        End Function

        Public Function GetRecordById(idNo As Object) As CashDisbursementJournal Implements IDao(Of CashDisbursementJournal).GetRecordById
            TableName = "CashDisbursementJournal"
            SeriesName = $"CDJOURNAL"
            Dim data As DisbursementJournal = CdGetRecordById(idNo)
            Dim result As New CashDisbursementJournal
            Return GlobalVariables.Mapper.Map(data, result)
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CashDisbursementJournal) As Integer Implements IDaoJournals(Of CashDisbursementJournal).UpdateGlReferenceNumber
            Return CdUpdateGlReferenceNumber(bizObj)
        End Function

        Public Function UpdateRecord(ByRef recordData As CashDisbursementJournal) As Integer Implements IDao(Of CashDisbursementJournal).UpdateRecord
            Return CdUpdateRecord(recordData)
        End Function

        Protected Overrides Function GetCjOiItemDao()
            Dim cjOiItemDao As CdOiItemDao
            cjOiItemDao = New CdOiItemDao()
            cjOiItemDao.TableName = "CdOiItem_View"
            cjOiItemDao.DboTvpInsertName = "InsertCdOiItemTVP"
            cjOiItemDao.DboTvpUpdateName = "UpdateCdOiItemTVP"
            Return cjOiItemDao
        End Function

        Protected Overrides Function GetJiDao()
            Return New CashDisbursementJournalItemDao
        End Function

    End Class

End Namespace