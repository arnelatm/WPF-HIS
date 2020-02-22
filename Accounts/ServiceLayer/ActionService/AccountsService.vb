Imports AATM.Accounts.DataLayer
Imports AATM.Common.ServiceLayer.ActionServices

Namespace ServiceLayer.ActionService

    Public Class AccountsService
        Inherits ServiceCommonOld
        Implements IAccountsService

        Private Shared Shadows ReadOnly Factory As IDaoFactoryOld = DaoFactoriesOld.GetFactory(Provider)
        Private Shared ReadOnly CashDisbursementJournalItemDao As IJournalItemDao = Factory.CashDisbursementJournalItemDao
        Private Shared ReadOnly CashDisbursementJournalDao As ICashDisbursementJournalDao = Factory.CashDisbursementJournalDao

        Public Function UpdateGlReferenceNumber(Of TBiz)(ByRef model As TBiz) As Integer Implements IAccountsService.UpdateGlReferenceNumber
            DataDao = CashDisbursementJournalDao
            Return DataDao.UpdateGlReferenceNumber(model)
        End Function

    End Class

End Namespace