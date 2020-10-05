Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Country
    ' ** DAO Pattern

    Public Class CountryTelCodeDao
        Inherits CommonDao
        Implements IDaoRead(Of CountryTelCode)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As CountryTelCode Implements IDaoRead(Of CountryTelCode).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, CountryName, CountryNameAra, CountryTelCode" &
                    "   FROM [Country]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of CountryTelCode) _
            Implements IDaoRead(Of CountryTelCode).GetAll
            If sortExpression = Nothing Then
                sortExpression = "CountryName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, CountryName, CountryNameAra, CountryTelCode" &
                    "   FROM [Country] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, CountryTelCode) =
                                    Function(reader) _
            New CountryTelCode() With {
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .CountryName = Extensions.AsString(reader("CountryName")),
            .CountryNameAra = Extensions.AsString(reader("CountryNameAra")),
            .CountryTelCode = Extensions.AsString(reader("CountryTelCode"))}

    End Class

End Namespace