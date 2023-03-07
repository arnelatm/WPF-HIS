Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for DosagePrinting
    ' ** DAO Pattern

    Public Class DosagePrintingDao
        Inherits CommonDao

        Private ReadOnly _db As New Db()

        Public Overrides Function GetDB()
            Return _db
        End Function

    End Class

End Namespace