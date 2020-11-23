' Data access object for PcJournal
' ** DAO Pattern
Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for PcJournal
    ' ** DAO Pattern

    Public Class PcJournalDao
        Inherits DisbursementJournalDao
        Implements IDao(Of PcJournal), IDaoJournals(Of PcJournal), IDaoOiItem(Of DjOiItem)

        Public Sub New()
            TableName = "PcJournal"
            SeriesName = $"PCJOURNAL"
        End Sub

        Public Function AddRecord(ByRef recordData As PcJournal) As Integer Implements IDao(Of PcJournal).AddRecord
            Return CdAddRecord(recordData)
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
            Return CdGetOpenInvoices(idNo)
        End Function

        Public Function GetRecordById(idNo As Object) As PcJournal Implements IDao(Of PcJournal).GetRecordById
            Dim data As DisbursementJournal = CdGetRecordById(idNo)
            Dim result As New PcJournal
            Return GlobalVariables.Mapper.Map(data, result)
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As PcJournal) As Integer Implements IDaoJournals(Of PcJournal).UpdateGlReferenceNumber
            Return CdUpdateGlReferenceNumber(bizObj)
        End Function

        Public Function UpdateRecord(ByRef recordData As PcJournal) As Integer Implements IDao(Of PcJournal).UpdateRecord
            Return CdUpdateRecord(recordData)
        End Function

        Protected Overrides Function GetDjOiItemDao()
            Dim djOiItemDao As PcOiItemDao
            djOiItemDao = New PcOiItemDao()
            djOiItemDao.TableName = "PcOiItem_View"
            djOiItemDao.DboTvpInsertName = "InsertPcOiItemTVP"
            djOiItemDao.DboTvpUpdateName = "UpdatePcOiItemTVP"
            Return djOiItemDao
        End Function

        Protected Overrides Function GetJiDao()
            Return New PcJournalItemDao
        End Function

    End Class

End Namespace