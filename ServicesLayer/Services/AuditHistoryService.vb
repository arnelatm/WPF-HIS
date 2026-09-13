Imports System.Data
Imports AATM.DataLayer.AdoNet

Namespace Services

    Public Class AuditHistoryService
        Private ReadOnly _dao As New AuditHistoryDao()

        Public Function GetHistory(fromUtc As DateTime?, toUtc As DateTime?, userIdNo As Short?,
                                   entityName As String, action As String, recordIdNo As Integer?,
                                   referenceNo As String, Optional topRows As Integer = 1000) As DataTable
            Return _dao.GetHistory(fromUtc, toUtc, userIdNo, entityName, action, recordIdNo, referenceNo, topRows)
        End Function
    End Class

End Namespace
