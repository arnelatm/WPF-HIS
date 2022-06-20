Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for HolidayTransfer
    ' ** DAO Pattern

    Public Class HolidayTransferDao
        Implements IDao(Of HolidayTransfer), IDaoGetRecords(Of HolidayTransferItem)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As HolidayTransfer _
            Implements IDao(Of HolidayTransfer).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "a.EnteredBy," &
                    "a.DateCreated," &
                    "b.DateStart," &
                    "b.DateEnd," &
                    "a.HolidayIdNo," &
                    "a.IdNo" &
                    " FROM [HolidayTransfer] a" &
                    " Left Join Holiday_View b on a.HolidayIdNo = b.IdNo" &
                    " WHERE a.IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            If data IsNot Nothing Then
                Dim htDao = New HolidayTransferItemDao()
                data.HolidayTransferItems = htDao.GetRecordsWithGroupIdNo(idNo)
                For Each item In data.HolidayTransferItems
                    item.Transfer = True
                Next
            End If
            Return data
        End Function

        Public Function UpdateRecord(ByRef holidayTransfer As HolidayTransfer) As Integer _
            Implements IDao(Of HolidayTransfer).UpdateRecord
            Dim sql As String =
                    "UPDATE [HolidayTransfer] SET " &
                    "EnteredBy = @EnteredBy," &
                    "HolidayIdNo = @HolidayIdNo" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(holidayTransfer))
        End Function

        Public Function AddRecord(ByRef holidayTransfer As HolidayTransfer) As Integer _
            Implements IDao(Of HolidayTransfer).AddRecord
            Dim sql As String =
                    " INSERT INTO [HolidayTransfer] " &
                    "(" &
                    "EnteredBy," &
                    "HolidayIdNo" &
                    ") VALUES (" &
                    "@EnteredBy," &
                    "@HolidayIdNo" &
                    ")"
            Return _db.Insert(sql, Take(holidayTransfer))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, HolidayTransfer) =
                                    Function(reader) _
            New HolidayTransfer() With {
            .EnteredBy = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("EnteredBy")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .DateEnd = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateEnd")),
            .DateStart = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateStart")),
            .HolidayIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int16)(reader("HolidayIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Private Function Take(holidayTransfer As HolidayTransfer) As Object()
            Return New Object() {"@EnteredBy", holidayTransfer.EnteredBy,
                                 "@HolidayIdNo", holidayTransfer.HolidayIdNo,
                                 "@DateStart", holidayTransfer.DateStart,
                                 "@DateEnd", holidayTransfer.DateEnd,
                                 "@IdNo", holidayTransfer.IdNo
                                 }
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of HolidayTransferItem) Implements IDaoGetRecords(Of HolidayTransferItem).GetDaoRecords
            Dim sql As String = "SELECT " &
                                "EmployeeIdNo," &
                                "HolidayTransferIdNo," &
                                "IdNo " &
                                " FROM HolidayTransferItem" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return _db.Read(sql, MakeHolidayTransferItem).ToList()
        End Function

        Private Shared ReadOnly MakeHolidayTransferItem As Func(Of IDataReader, HolidayTransferItem) =
                                    Function(reader) _
            New HolidayTransferItem() With {
            .EmployeeIdNo = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("EmployeeIdNo")),
            .HolidayTransferIdNo = AATM.DataLayer.AdoNet.Extensions.AsInt(Of Int32)(reader("HolidayTransferIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo"))
            }

    End Class

End Namespace