Imports AATM.Accounts.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub

Namespace DataLayer.AdoNet
    ' Data access object for HolidayTransfer
    ' ** DAO Pattern

    Public Class HolidayTransferDao
        Implements IDao(Of HolidayTransfer)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As HolidayTransfer _
            Implements IDao(Of HolidayTransfer).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "AppliedBy," &
                    "DateCreated," &
                    "HolidayIdNo," &
                    "IdNo" &
                    " FROM [HolidayTransfer]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim htDao = New HolidayTransferItemDao()
            data.HolidayTransferItems = htDao.GetRecordsWithGroupIdNo(idNo)
            Return data
        End Function

        Public Function UpdateRecord(ByRef holidayTransfer As HolidayTransfer) As Integer _
            Implements IDao(Of HolidayTransfer).UpdateRecord
            Dim sql As String =
                    "UPDATE [HolidayTransfer] SET " &
                    "AppliedBy = @AppliedBy," &
                    "HolidayIdNo = @HolidayIdNo" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(holidayTransfer))
        End Function

        Public Function AddRecord(ByRef HolidayTransfer As HolidayTransfer) As Integer _
            Implements IDao(Of HolidayTransfer).AddRecord
            Dim sql As String =
                    " INSERT INTO [HolidayTransfer] " &
                    "(" &
                    "AppliedBy," &
                    "HolidayTransferIdNo" &
                    ") VALUES (" &
                    "@AppliedBy," &
                    "@HolidayTransferIdNo" &
                    ")"
            Return _db.Insert(sql, Take(HolidayTransfer))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, HolidayTransfer) =
                                    Function(reader) _
            New HolidayTransfer() With {
            .AppliedBy = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("AppliedBy")),
            .DateCreated = AATM.DataLayer.AdoNet.Extensions.AsNullableDateTime(reader("DateCreated")),
            .HolidayIdNo = AATM.DataLayer.AdoNet.Extensions.AsBool(reader("HolidayIdNo")),
            .IdNo = AATM.DataLayer.AdoNet.Extensions.AsId(Of Int32)(reader("IdNo"))
            }

        Private Function Take(holidayTransfer As HolidayTransfer) As Object()
            Return New Object() {
                                    "@AppliedBy", holidayTransfer.AppliedBy,
                                    "@HolidayIdNo", holidayTransfer.HolidayIdNo,
                                    "@DateCreated", holidayTransfer.DateCreated,
                                    "@IdNo", holidayTransfer.IdNo
                                    }
        End Function

    End Class

End Namespace