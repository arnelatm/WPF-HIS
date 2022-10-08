Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ItemCode
    ' ** DAO Pattern

    Public Class ItemCodeDao
        Inherits CommonDao
        Implements IDao(Of ItemCode)

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As ItemCode Implements IDao(Of ItemCode).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, ItemCodeCode, ItemCodeName, ItemCodeNameAra, CodeGroupIdNo" &
                    "   FROM [ItemCode]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef ItemCode As ItemCode) As Integer Implements IDao(Of ItemCode).UpdateRecord
            Dim sql As String =
                    " UPDATE [ItemCode]" &
                    "    SET ItemCodeCode = @ItemCodeCode," &
                    "        ItemCodeName = @ItemCodeName," &
                    "        ItemCodeNameAra = @ItemCodeNameAra," &
                    "        CodeGroupIdNo = @CodeGroupIdNo" &
                    "  WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(ItemCode))
        End Function

        Public Function AddRecord(ByRef ItemCode As ItemCode) As Integer Implements IDao(Of ItemCode).AddRecord
            Dim sql As String =
                    " INSERT INTO [ItemCode] " &
                    " (ItemCodeCode,ItemCodeName,ItemCodeNameAra,CodeGroupIdNo) " &
                    " VALUES (@ItemCodeCode,@ItemCodeName,@ItemCodeNameAra,@CodeGroupIdNo) "
            Return Db.Insert(sql, Take(ItemCode))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ItemCode) =
                                    Function(reader) _
            New ItemCode() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .ItemCodeCode = Extensions.AsString(reader("ItemCodeCode")),
            .ItemCodeName = Extensions.AsString(reader("ItemCodeName")),
            .ItemCodeNameAra = Extensions.AsString(reader("ItemCodeNameAra")),
            .CodeGroupIdNo = Extensions.AsInt(Of Int16)(reader("CodeGroupIdNo"))
            }

        Private Function Take(ItemCode As ItemCode) As Object()
            Return New Object() {
                                    "@ItemCodeCode", ItemCode.ItemCodeCode,
                                    "@ItemCodeName", ItemCode.ItemCodeName,
                                    "@ItemCodeNameAra", ItemCode.ItemCodeNameAra,
                                    "@CodeGroupIdNo", ItemCode.CodeGroupIdNo
                                }
        End Function

    End Class

End Namespace