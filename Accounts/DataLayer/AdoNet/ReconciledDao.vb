Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Reconciled
    ' ** DAO Pattern

    Public Class ReconciledDao
        Inherits CommonDao
        Implements IDaoChild(Of Reconciled)

        Private Shared ReadOnly Db As New Db()
        Protected TableFileName As String = "Reconciled"
        Protected DboTvpInsertFileName As String = "dbo.InsertReconciledTVP"

        Public Function GetRecordsWithIdNo(idNo As Integer, Optional sortExpression As String = Nothing) As List(Of Reconciled) Implements IDaoChild(Of Reconciled).GetRecordsWithIdNo
            Throw New NotImplementedException
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of Reconciled).DelUpdateTvp
            Throw New NotImplementedException
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of Reconciled).InsertTvp
            Return Db.InsertTvp(DboTvpInsertFileName, tvpTable, "@MParam")
        End Function

    End Class

End Namespace