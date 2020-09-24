Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class DaoAccounts
        Inherits CommonDao
        Implements IDaoAccounts

        Private ReadOnly _db As New Db()

    End Class

End Namespace