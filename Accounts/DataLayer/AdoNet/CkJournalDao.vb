Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for CkJournal
    ' ** DAO Pattern

    Public Class CkJournalDao
        Inherits DisbursementJournalDao
        Implements IDao(Of CkJournal), IDaoJournals(Of CkJournal), IDaoOiItem(Of DjOiItem)

        Public Sub New()
            TableName = "CkJournal"
            SeriesName = $"CKJOURNAL"
        End Sub

        Public Function AddRecord(ByRef recordData As CkJournal) As Integer Implements IDao(Of CkJournal).AddRecord
            Return DjAddRecord(recordData)
        End Function

        Public Function GetOpenInvoices(idNo As Integer) As List(Of DjOiItem) Implements IDaoOiItem(Of DjOiItem).GetOpenInvoices
            Return CdGetOpenInvoices(idNo)
        End Function

        Public Function GetRecordById(idNo As Object) As CkJournal Implements IDao(Of CkJournal).GetRecordById

            Dim data As DisbursementJournal = DjGetRecordById(idNo)
            Dim result As New CkJournal
            Return GlobalVariables.Mapper.Map(data, result)
        End Function

        Public Function UpdateGlReferenceNumber(ByRef bizObj As CkJournal) As Integer Implements IDaoJournals(Of CkJournal).UpdateGlReferenceNumber
            Return DjUpdateGlReferenceNumber(bizObj)
        End Function

        Public Function UpdateRecord(ByRef recordData As CkJournal) As Integer Implements IDao(Of CkJournal).UpdateRecord
            Return DjUpdateRecord(recordData)
        End Function

        Protected Overrides Function GetDjOiItemDao()
            Dim djOiItemDao As CkOiItemDao
            djOiItemDao = New CkOiItemDao()
            Return djOiItemDao
        End Function

        Protected Overrides Function GetJiDao()
            Return New CkJournalItemDao
        End Function

    End Class

End Namespace