Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for HolidayTransferItem
    ' ** DAO Pattern

    Public Class HolidayTransferItemDao
        Inherits AccountsDao
        Implements IDaoTvp(Of HolidayTransferItem), IDaoChild(Of HolidayTransferItem)

        Private ReadOnly _db As New Db()
        Private Const DboTvpUpdateInsertName As String = "UpdateInsertHolidayTransferItemTVP"
        Private Const DboTableOrViewName As String = "HolidayTransferItem"

        Public Sub New()
        End Sub

        Public Function GetRecordsWithGroupIdNo(idNo, Optional sortKey = Nothing) As List(Of HolidayTransferItem) Implements IDaoChild(Of HolidayTransferItem).GetRecordsWithGroupIdNo
            Dim sql As String =
                    "SELECT " &
                    "EmployeeIdNo," &
                    "HolidayTransferIdNo," &
                    "a.IdNo" &
                    " FROM " & DboTableOrViewName & " as a" &
                    " Left Join Employee b on a.IdNo = b.IdNo" &
                    " WHERE HolidayTransferIdNo = @IdNo" &
                    " ORDER BY b.EmployeeName"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).ToList()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of HolidayTransferItem).DelUpdateTvp
            Throw New NotImplementedException
        End Function

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer Implements IDaoChild(Of HolidayTransferItem).InsertTvp
            Throw New NotImplementedException
        End Function

        'Public Function UpdateInsertTvp(ByRef updateTvpTable As DataTable, ByRef insertTvpTable As DataTable, ByVal groupIdNo As Integer) As Integer Implements IDaoTvp(Of HolidayTransferItem).UpdateInsertTvp
        '    Return _db.UpdateInsertTvp(DboTvpUpdateInsertName, updateTvpTable, insertTvpTable, groupIdNo)
        'End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, HolidayTransferItem) =
                                    Function(reader) _
            New HolidayTransferItem() With {
            .EmployeeIdNo = Extensions.AsInt(Of Int32)(reader("EmployeeIdNo")),
            .HolidayTransferIdNo = Extensions.AsString(reader("HolidayTransferIdNo")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo"))
            }

    End Class

End Namespace