Imports AATM.Common.DataLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet

    Public Class AccountsDao
        Inherits CommonDao
        Implements IAccountsDao

    End Class

    Public Interface IDaoJournalItems(Of TBiz)

        Function GetRecordsWithIdNo(idNo As Integer, ByRef Optional sortKey As String = Nothing) As Object

        Function DelUpdateTvp(ByRef tvpTable As DataTable, ByVal groupIdNo As Integer) As Integer

        Function InsertTvp(ByRef tvpTable As DataTable) As Integer

    End Interface

End Namespace