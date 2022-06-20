Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for ShiftSummary
    ' ** DAO Pattern

    Public Class ShiftSummaryDao
        Inherits CommonDao
        Implements iDao(Of ShiftSummary), IDaoGetRecords(Of ShiftSummary)

        Private ReadOnly Db As New Db()

        Private Const FieldList = "Cards," &
                                  "Cash," &
                                  "DateCreated," &
                                  "DateEnd," &
                                  "DateStart," &
                                  "IdNo," &
                                  "UserIdNo"

        Public Function GetRecordByIdNo(idNo) As ShiftSummary Implements iDao(Of ShiftSummary).GetRecordByIdNo
            Dim sql As String =
                    " SELECT " & FieldList &
                    "   FROM ShiftSummary" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function UpdateRecord(ByRef ShiftSummary As ShiftSummary) As Integer Implements iDao(Of ShiftSummary).UpdateRecord
            Dim sql As String =
                    "UPDATE [ShiftSummary] Set " &
                    "Cards = @Cards, " &
                    "Cash = @Cash, " &
                    "DateEnd = @DateEnd, " &
                    "DateStart = @DateStart, " &
                    "UserIdNo = @UserIdNo " &
                    "WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(ShiftSummary))
        End Function

        Public Function AddRecord(ByRef ShiftSummary As ShiftSummary) As Integer Implements iDao(Of ShiftSummary).AddRecord
            Dim sql As String =
                    "INSERT INTO [ShiftSummary] " &
                    "(Cash,Cards,DateEnd,DateStart,UserIdNo) " &
                    "VALUES (@Cash,@Cards,@DateEnd,@DateStart,@UserIdNo)"
            Return Db.Insert(sql, Take(ShiftSummary))
        End Function

        Public Function GetDaoRecords(Optional filter As String = Nothing) As List(Of ShiftSummary) Implements IDaoGetRecords(Of ShiftSummary).GetDaoRecords
            Dim sql As String = "SELECT " &
                                FieldList &
                                " FROM ShiftSummary" &
                                IIf(filter Is Nothing, "", " WHERE " & filter)
            Return Db.Read(sql, Make).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, ShiftSummary) =
                                    Function(reader) _
            New ShiftSummary() With {
            .Cards = Extensions.AsDecimal(reader("Cards")),
            .Cash = Extensions.AsDecimal(reader("Cash")),
            .DateCreated = Extensions.AsDateTime(reader("DateCreated")),
            .DateEnd = Extensions.AsDateTime(reader("DateEnd")),
            .DateStart = Extensions.AsDateTime(reader("DateStart")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .UserIdNo = Extensions.AsInt(Of Int32)(reader("UserIdNo"))
            }

        Public Sub New()

        End Sub

        Private Function Take(shiftSummary As ShiftSummary) As Object()
            Return New Object() {
                                    "@Cards", shiftSummary.Cards,
                                    "@Cash", shiftSummary.Cash,
                                    "@DateEnd", shiftSummary.DateEnd,
                                    "@DateStart", shiftSummary.DateStart,
                                    "@IdNo", shiftSummary.IdNo,
                                    "@UserIdNo", shiftSummary.UserIdNo
                                }
        End Function

    End Class

End Namespace