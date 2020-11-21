Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for DisbursementJournal
    ' ** DAO Pattern

    Public Class CdJournalDao
        Inherits DisbursementJournalDao

        Protected Overrides Function GetJiDao()
            Return New CashDisbursementJournalItemDao
        End Function

        Protected Overrides Function GetCjOiItemDao()
            Return New CjOiItemDao
        End Function

    End Class

End Namespace