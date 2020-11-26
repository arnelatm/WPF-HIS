Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for CdJournal
    ' ** DAO Pattern

    Public Class CdJournalDao
        Inherits DisbursementJournalDao
        Implements IDao(Of CdJournal), IDaoJournals(Of CdJournal), IDaoOiItem(Of DjOiItem)

        Public Sub New()
            TableName = "CdJournal"
            SeriesName = $"CDJOURNAL"
        End Sub

        Public Function AddRecord(ByRef recordData As CdJournal) As Integer Implements IDao(Of CdJournal).AddRecord
            Return CdAddRecord(recordData)
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
            Return CdGetOpenInvoices(idNo)
        End Function

        Public Function GetRecordById(idNo As Object) As CdJournal Implements IDao(Of CdJournal).GetRecordById

            Dim data As DisbursementJournal = CdGetRecordById(idNo)
            Dim result As New CdJournal
            Return GlobalVariables.Mapper.Map(data, result)
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CdJournal) As Integer Implements IDaoJournals(Of CdJournal).UpdateGlReferenceNumber
            Return CdUpdateGlReferenceNumber(bizObj)
        End Function

        Public Function UpdateRecord(ByRef recordData As CdJournal) As Integer Implements IDao(Of CdJournal).UpdateRecord
            Return CdUpdateRecord(recordData)
        End Function

        Protected Overrides Function GetDjOiItemDao()
            Dim djOiItemDao As CdOiItemDao
            djOiItemDao = New CdOiItemDao()
            'djOiItemDao.TableName = "CdOiItem_View"
            'djOiItemDao.DboTvpInsertName = "InsertCdOiItemTVP"
            'djOiItemDao.DboTvpUpdateName = "UpdateCdOiItemTVP"
            Return djOiItemDao
        End Function

        Protected Overrides Function GetJiDao()
            Return New CdJournalItemDao
        End Function

    End Class

End Namespace