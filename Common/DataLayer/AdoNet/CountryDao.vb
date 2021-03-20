Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Country
    ' ** DAO Pattern

    Public Class CountryDao
        Inherits CommonDao
        Implements IDaoAll(Of Country)

        Private ReadOnly _db As New Db()

        'Public Function GetCountryByName(countryName As String) As Country Implements IDaoAll(Of Country).GetCountryByName
        '    Throw New NotImplementedException
        'End Function

        Public Function GetRecordByIdNo(idNo) As Country Implements IDaoAll(Of Country).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, CountryCode, CountryName, CountryNameAra, Nationality, NationalityAra, Flag32, Flag128, ISOA3, ISON, CountryTelCode" &
                    "   FROM [Country]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Return _db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Country) _
            Implements IDaoAll(Of Country).GetAll
            If sortExpression = Nothing Then
                sortExpression = "CountryName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, CountryCode, CountryName, CountryNameAra, Nationality, NationalityAra, Flag32, Flag128, ISOA3, ISON, CountryTelCode" &
                    "   FROM [Country] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef country As Country) As Integer Implements IDaoAll(Of Country).UpdateRecord
            Dim sql As String =
                    " UPDATE [Country] SET" &
                    " CountryCode = @CountryCode," &
                    " CountryName = @CountryName," &
                    " CountryNameAra = @CountryNameAra," &
                    " Nationality = @Nationality," &
                    " NationalityAra = @NationalityAra," &
                    " Flag32 = @Flag32," &
                    " Flag128 = @Flag128," &
                    " IsoA3 = @IsoA3," &
                    " IsoN = @IsoN," &
                    " CountryTelCode = @CountryTelCode" &
                    " WHERE IdNo = @IdNo"

            Return _db.Update(sql, Take(country))
        End Function

        Public Function AddRecord(ByRef country As Country) As Integer Implements IDaoAll(Of Country).AddRecord
            Dim sql As String =
                    " INSERT INTO [Country] " &
                    " (CountryCode, CountryName,CountryNameAra,Nationality,NationalityAra,Flag32,Flag128,IsoA3,IsoN,CountryTelCode) " &
                    " VALUES (@CountryCode,@CountryName,@CountryNameAra,@Nationality,@NationalityAra,@Flag32,@Flag128,@IsoA3,@IsoN,@CountryTelCode)"
            Return _db.Insert(sql, Take(country))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Country) =
                                    Function(reader) _
            New Country() With {
            .CountryCode = Extensions.AsString(reader("CountryCode")),
            .CountryName = Extensions.AsString(reader("CountryName")),
            .CountryNameAra = Extensions.AsString(reader("CountryNameAra")),
            .CountryTelCode = Extensions.AsString(reader("CountryTelCode")),
            .Flag128 = Extensions.AsString(reader("Flag128")),
            .Flag32 = Extensions.AsString(reader("Flag32")),
            .IdNo = Extensions.AsId(Of Int16)(reader("IdNo")),
            .ISOA3 = Extensions.AsString(reader("ISOA3")),
            .ISON = Extensions.AsString(reader("ISON")),
            .Nationality = Extensions.AsString(reader("Nationality")),
            .NationalityAra = Extensions.AsString(reader("NationalityAra"))
            }

        Private Function Take(country As Country) As Object()
            Return New Object() {
                                    "@CountryCode", country.CountryCode,
                                    "@CountryName", country.CountryName,
                                    "@CountryNameAra", country.CountryNameAra,
                                    "@CountryTelCode", country.CountryTelCode,
                                    "@Flag128", country.Flag128,
                                    "@Flag32", country.Flag32,
                                    "@IdNo", country.IdNo,
                                    "@IsoA3", country.ISOA3,
                                    "@IsoN", country.ISON,
                                    "@Nationality", country.Nationality,
                                    "@NationalityAra", country.NationalityAra}
        End Function

    End Class

End Namespace