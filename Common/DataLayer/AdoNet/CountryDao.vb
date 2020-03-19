Imports AATM.Common.BusinessLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Country
    ' ** DAO Pattern

    Public Class CountryDao
        Inherits CommonDao
        Implements ICountryDao

        Private ReadOnly Db As New Db()

        'Public Function GetCountryByName(countryName As String) As Country Implements ICountryDao.GetCountryByName
        '    Throw New NotImplementedException
        'End Function

        Public Function GetRecordById(ByVal idNo As Integer) As Country Implements ICountryDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, CountryName, CountryNameAra, Nationality, NationalityAra, Flag32, Flag128, ISOA2, ISOA3, ISON, PhoneCode" &
                    "   FROM [Country]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "CountryName") As List(Of Country) Implements ICountryDao.GetAll
            Dim sql As String = " SELECT IDNo, CountryName, CountryNameAra, Nationality, NationalityAra, Flag32, Flag128, ISOA2, ISOA3, ISON, PhoneCode" &
                                "   FROM [Country] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef country As Country) As Integer Implements ICountryDao.UpdateRecord
            Dim sql As String =
                    " UPDATE [Country]" &
                    "    SET CountryName = @CountryName," &
                    "        CountryNameAra = @CountryNameAra," &
                    "        Nationality = @Nationality," &
                    "        NationalityAra = @NationalityAra," &
                    "        Flag32 = @Flag32," &
                    "        Flag128 = @Flag128," &
                    "        ISOA2 = @ISOA2," &
                    "        ISOA3 = @ISOA3," &
                    "        ISON = @ISON," &
                    "        PhoneCode = @PhoneCode" &
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(country))
        End Function

        Public Function AddRecord(ByRef country As Country) As Integer Implements ICountryDao.AddRecord
            Dim sql As String =
                    " INSERT INTO [Country] " &
                    " (CountryName,CountryNameAra,Nationality,NationalityAra,Flag32,Flag128,ISOA2,ISOA3,ISON,PhoneCode) " &
                    " VALUES (@CountryName,@CountryNameAra,@Nationality,@NationalityAra,@Flag32,@Flag128,@ISOA2,@ISOA3,@ISON,@PhoneCode)"
            Return Db.Insert(sql, Take(country))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Country) =
                                    Function(reader) _
            New Country() With {
            .IdNo = Extensions.AsId(reader("IDNo")),
            .CountryName = Extensions.AsString(reader("CountryName")),
            .CountryNameAra = Extensions.AsString(reader("CountryNameAra")),
            .Nationality = Extensions.AsString(reader("Nationality")),
            .NationalityAra = Extensions.AsString(reader("NationalityAra")),
            .Flag32 = Extensions.AsString(reader("Flag32")),
            .Flag128 = Extensions.AsString(reader("Flag128")),
            .Isoa2 = Extensions.AsString(reader("ISOA2")),
            .Isoa3 = Extensions.AsString(reader("ISOA3")),
            .Ison = Extensions.AsString(reader("ISON")),
            .PhoneCode = Extensions.AsString(reader("PhoneCode"))}

        Private Function Take(country As Country) As Object()
            Return New Object() {
                                    "@IDNo", country.IdNo,
                                    "@CountryName", country.CountryName,
                                    "@CountryNameAra", country.CountryNameAra,
                                    "@Nationality", country.Nationality,
                                    "@NationalityAra", country.NationalityAra,
                                    "@Flag32", country.Flag32,
                                    "@Flag128", country.Flag128,
                                    "@ISOA2", country.Isoa2,
                                    "@ISOA3", country.Isoa3,
                                    "@ISON", country.Ison,
                                    "@PhoneCode", country.PhoneCode}
        End Function

    End Class

End Namespace