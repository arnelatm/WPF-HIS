Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for PensionProvider
    ' ** DAO Pattern

    Public Class PensionProviderDao
        Inherits CommonDao
        Implements IDaoAll(Of PensionProvider)

        Private ReadOnly _db As New Db()

        Public Function GetRecordById(idNo) As PensionProvider Implements IDaoAll(Of PensionProvider).GetRecordById
            Dim sql As String =
                    "SELECT " &
                    "AccountIdNo," &
                    "Active," &
                    "BankAccountNo," &
                    "BankIdNo," &
                    "ContactDesignation," &
                    "ContactPerson," &
                    "CountryCode," &
                    "District," &
                    "Email," &
                    "Fax," &
                    "Iban," &
                    "IdNo," &
                    "Mobile," &
                    "Notes," &
                    "PaymentMethod," &
                    "Phone1," &
                    "Phone2," &
                    "PoBox," &
                    "ProvinceState," &
                    "Street," &
                    "PensionProviderCode," &
                    "PensionProviderName," &
                    "PensionProviderNameAra," &
                    "TownCity," &
                    "Website," &
                    "ZipCode" &
                    " FROM [PensionProvider]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x As PensionProvider
            x = _db.Read(sql, Make, params).FirstOrDefault()
            Return x
            'Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of PensionProvider) _
            Implements IDaoAll(Of PensionProvider).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "PensionProviderName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, PensionProviderCode, PensionProviderName, PensionProviderNameAra " &
                    "   FROM [PensionProvider] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef pensionProvider As PensionProvider) As Integer Implements IDaoAll(Of PensionProvider).UpdateRecord
            Dim sql As String =
                    "UPDATE [PensionProvider] SET " &
                    "AccountIdNo = @AccountIdNo," &
                    "Active = @Active," &
                    "BankAccountNo = @BankAccountNo," &
                    "BankIdNo = @BankIdNo," &
                    "ContactDesignation = @ContactDesignation," &
                    "ContactPerson = @ContactPerson," &
                    "CountryCode = @CountryCode," &
                    "District = @District," &
                    "Email = @Email," &
                    "Fax = @Fax," &
                    "Iban = @Iban," &
                    "Mobile = @Mobile," &
                    "Notes = @Notes," &
                    "PaymentMethod = @PaymentMethod," &
                    "Phone1 = @Phone1," &
                    "Phone2 = @Phone2," &
                    "PoBox = @PoBox," &
                    "ProvinceState = @ProvinceState," &
                    "Street = @Street," &
                    "PensionProviderCode = @PensionProviderCode," &
                    "PensionProviderName = @PensionProviderName," &
                    "PensionProviderNameAra = @PensionProviderNameAra," &
                    "TownCity = @TownCity," &
                    "Website = @Website," &
                    "ZipCode = @ZipCode" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(pensionProvider))
        End Function

        Public Function AddRecord(ByRef pensionProvider As PensionProvider) As Integer Implements IDaoAll(Of PensionProvider).AddRecord
            Dim sql As String =
                    "INSERT INTO [PensionProvider] (" &
                    "AccountIdNo," &
                    "Active," &
                    "BankAccountNo," &
                    "BankIdNo," &
                    "ContactDesignation," &
                    "ContactPerson," &
                    "CountryCode," &
                    "District," &
                    "Email," &
                    "Fax," &
                    "Iban," &
                    "Mobile," &
                    "Notes," &
                    "PaymentMethod," &
                    "Phone1," &
                    "Phone2," &
                    "PoBox," &
                    "ProvinceState," &
                    "Street," &
                    "PensionProviderCode," &
                    "PensionProviderName," &
                    "PensionProviderNameAra," &
                    "TownCity," &
                    "Website," &
                    "ZipCode" &
                    ") VALUES (" &
                    "@AccountIdNo," &
                    "@Active," &
                    "@BankAccountNo," &
                    "@BankIdNo," &
                    "@ContactDesignation," &
                    "@ContactPerson," &
                    "@CountryCode," &
                    "@District," &
                    "@Email," &
                    "@Fax," &
                    "@Iban," &
                    "@Mobile," &
                    "@Notes," &
                    "@PaymentMethod," &
                    "@Phone1," &
                    "@Phone2," &
                    "@PoBox," &
                    "@ProvinceState," &
                    "@Street," &
                    "@PensionProviderCode," &
                    "@PensionProviderName," &
                    "@PensionProviderNameAra," &
                    "@TownCity," &
                    "@Website," &
                    "@ZipCode" &
                    ")"
            Return _db.Insert(sql, Take(pensionProvider))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, PensionProvider) =
                                    Function(reader) _
            New PensionProvider() With {
            .AccountIdNo = Extensions.AsNullable(Of Int16?)(reader("AccountIdNo")),
            .Active = Extensions.AsBool(reader("Active")),
            .BankAccountNo = Extensions.AsString(reader("BankAccountNo")),
            .BankIdNo = Extensions.AsNullable(Of Int16?)(reader("BankIdNo")),
            .ContactDesignation = Extensions.AsString(reader("ContactDesignation")),
            .ContactPerson = Extensions.AsString(reader("ContactPerson")),
            .CountryCode = Extensions.AsString(reader("CountryCode")),
            .District = Extensions.AsString(reader("District")),
            .Email = Extensions.AsString(reader("Email")),
            .Fax = Extensions.AsString(reader("Fax")),
            .Iban = Extensions.AsString(reader("Iban")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Mobile = Extensions.AsString(reader("Mobile")),
            .Notes = Extensions.AsString(reader("Notes")),
            .PaymentMethod = Extensions.AsString(reader("PaymentMethod")),
            .Phone1 = Extensions.AsString(reader("Phone1")),
            .Phone2 = Extensions.AsString(reader("Phone2")),
            .PoBox = Extensions.AsString(reader("PoBox")),
            .ProvinceState = Extensions.AsString(reader("ProvinceState")),
            .Street = Extensions.AsString(reader("Street")),
            .PensionProviderCode = Extensions.AsString(reader("PensionProviderCode")),
            .PensionProviderName = Extensions.AsString(reader("PensionProviderName")),
            .PensionProviderNameAra = Extensions.AsString(reader("PensionProviderNameAra")),
            .TownCity = Extensions.AsString(reader("TownCity")),
            .Website = Extensions.AsString(reader("Website")),
            .ZipCode = Extensions.AsString(reader("ZipCode"))
            }

        Private Function Take(pensionProvider As PensionProvider) As Object()
            Return New Object() {
                                    "@AccountIdNo", pensionProvider.AccountIdNo,
                                    "@Active", pensionProvider.Active,
                                    "@BankAccountNo", pensionProvider.BankAccountNo,
                                    "@BankIdNo", pensionProvider.BankIdNo,
                                    "@ContactDesignation", pensionProvider.ContactDesignation,
                                    "@ContactPerson", pensionProvider.ContactPerson,
                                    "@CountryCode", pensionProvider.CountryCode,
                                    "@District", pensionProvider.District,
                                    "@Email", pensionProvider.Email,
                                    "@Fax", pensionProvider.Fax,
                                    "@Iban", pensionProvider.Iban,
                                    "@IdNo", pensionProvider.IdNo,
                                    "@Mobile", pensionProvider.Mobile,
                                    "@Notes", pensionProvider.Notes,
                                    "@PaymentMethod", pensionProvider.PaymentMethod,
                                    "@Phone1", pensionProvider.Phone1,
                                    "@Phone2", pensionProvider.Phone2,
                                    "@PoBox", pensionProvider.PoBox,
                                    "@ProvinceState", pensionProvider.ProvinceState,
                                    "@Street", pensionProvider.Street,
                                    "@PensionProviderCode", pensionProvider.PensionProviderCode,
                                    "@PensionProviderName", pensionProvider.PensionProviderName,
                                    "@PensionProviderNameAra", pensionProvider.PensionProviderNameAra,
                                    "@TownCity", pensionProvider.TownCity,
                                    "@Website", pensionProvider.Website,
                                    "@ZipCode", pensionProvider.ZipCode
                                }
        End Function

    End Class

End Namespace