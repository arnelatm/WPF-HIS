
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Reconciled
    ' ** DAO Pattern

    Public Class ReconciledDao
        Inherits CommonDao
        Implements IReconciledDao

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "Reconciled"
        Protected DboTvpInsertFileName As String = "dbo.InsertReconciledTVP"

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IReconciledDao.InsertTvp
            Return Db.TvpInsert(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

    End Class

End Namespace