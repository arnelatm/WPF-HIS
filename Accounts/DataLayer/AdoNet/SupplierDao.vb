Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Supplier
    ' ** DAO Pattern

    Public Class SupplierDao
        Inherits CommonDao
        Implements IDaoAll(Of Supplier), IDaoContacts(Of Supplier), IDaoAutoCode

        Private ReadOnly Db As New Db()

        Public Function GetRecordByIdNo(idNo) As Supplier Implements IDaoAll(Of Supplier).GetRecordByIdNo
            Dim sql As String =
                    "SELECT " &
                    "AccountStatus," &
                    "Active," &
                    "ApAccountIdNo," &
                    "BankAccountNo," &
                    "BankIdNo," &
                    "ContactDesignation," &
                    "ContactPerson," &
                    "CountryCode," &
                    "CreditLimit," &
                    "CrNumber," &
                    "DateAccountOpen," &
                    "District," &
                    "Email," &
                    "ExpAccountIdNo," &
                    "Fax," &
                    "Iban," &
                    "IdNo," &
                    "Mobile," &
                    "Notes," &
                    "OpeningBalance," &
                    "PaymentDueDays," &
                    "PaymentMethod," &
                    "Phone1," &
                    "Phone2," &
                    "PoBox," &
                    "ProvinceState," &
                    "SettlementDiscount," &
                    "SettlementDueDays," &
                    "Street," &
                    "SupplierCode," &
                    "SupplierName," &
                    "SupplierNameAra," &
                    "TownCity," &
                    "VatNumber," &
                    "Website," &
                    "ZipCode" &
                    " FROM [Supplier]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x As Supplier
            x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
            'Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Supplier) _
            Implements IDaoAll(Of Supplier).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "SupplierName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, SupplierCode, SupplierName, SupplierNameAra " &
                    "   FROM [Supplier] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef supplier As Supplier) As Integer Implements IDaoAll(Of Supplier).UpdateRecord
            Dim sql As String =
                    "UPDATE [Supplier] " &
                    "SET " &
                    "AccountStatus = @AccountStatus," &
                    "Active = @Active," &
                    "ApAccountIdNo = @ApAccountIdNo," &
                    "BankAccountNo = @BankAccountNo," &
                    "BankIdNo = @BankIdNo," &
                    "ContactDesignation = @ContactDesignation," &
                    "ContactPerson = @ContactPerson," &
                    "CountryCode = @CountryCode," &
                    "CreditLimit = @CreditLimit," &
                    "CrNumber = @CrNumber," &
                    "DateAccountOpen = @DateAccountOpen," &
                    "District = @District," &
                    "Email = @Email," &
                    "ExpAccountIdNo = @ExpAccountIdNo," &
                    "Fax = @Fax," &
                    "Iban = @Iban," &
                    "Mobile = @Mobile," &
                    "Notes = @Notes," &
                    "OpeningBalance = @OpeningBalance," &
                    "PaymentDueDays = @PaymentDueDays," &
                    "PaymentMethod = @PaymentMethod," &
                    "Phone1 = @Phone1," &
                    "Phone2 = @Phone2," &
                    "PoBox = @PoBox," &
                    "ProvinceState = @ProvinceState," &
                    "SettlementDiscount = @SettlementDiscount," &
                    "SettlementDueDays = @SettlementDueDays," &
                    "Street = @Street," &
                    "SupplierCode = @SupplierCode," &
                    "SupplierName = @SupplierName," &
                    "SupplierNameAra = @SupplierNameAra," &
                    "TownCity = @TownCity," &
                    "VatNumber = @VatNumber," &
                    "Website = @Website," &
                    "ZipCode = @ZipCode" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(supplier))
        End Function

        Public Function AddRecord(ByRef supplier As Supplier) As Integer Implements IDaoAll(Of Supplier).AddRecord
            Dim sql As String =
                    "INSERT INTO [Supplier] (" &
                    "AccountStatus," &
                    "Active," &
                    "ApAccountIdNo," &
                    "BankAccountNo," &
                    "BankIdNo," &
                    "ContactDesignation," &
                    "ContactPerson," &
                    "CountryCode," &
                    "CreditLimit," &
                    "CrNumber," &
                    "DateAccountOpen," &
                    "District," &
                    "Email," &
                    "ExpAccountIdNo," &
                    "Fax," &
                    "Iban," &
                    "Mobile," &
                    "Notes," &
                    "OpeningBalance," &
                    "PaymentDueDays," &
                    "PaymentMethod," &
                    "Phone1," &
                    "Phone2," &
                    "PoBox," &
                    "ProvinceState," &
                    "SettlementDiscount," &
                    "SettlementDueDays," &
                    "Street," &
                    "SupplierCode," &
                    "SupplierName," &
                    "SupplierNameAra," &
                    "TownCity," &
                    "VatNumber," &
                    "Website," &
                    "ZipCode" &
                    ") VALUES (" &
                    "@AccountStatus," &
                    "@Active," &
                    "@ApAccountIdNo," &
                    "@BankAccountNo," &
                    "@BankIdNo," &
                    "@ContactDesignation," &
                    "@ContactPerson," &
                    "@CountryCode," &
                    "@CreditLimit," &
                    "@CrNumber," &
                    "@DateAccountOpen," &
                    "@District," &
                    "@Email," &
                    "@ExpAccountIdNo," &
                    "@Fax," &
                    "@Iban," &
                    "@Mobile," &
                    "@Notes," &
                    "@OpeningBalance," &
                    "@PaymentDueDays," &
                    "@PaymentMethod," &
                    "@Phone1," &
                    "@Phone2," &
                    "@PoBox," &
                    "@ProvinceState," &
                    "@SettlementDiscount," &
                    "@SettlementDueDays," &
                    "@Street," &
                    "@SupplierCode," &
                    "@SupplierName," &
                    "@SupplierNameAra," &
                    "@TownCity," &
                    "@VatNumber," &
                    "@Website," &
                    "@ZipCode" &
                    ")"
            Return Db.Insert(sql, Take(supplier))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Supplier) =
                                    Function(reader) _
            New Supplier() With {
            .AccountStatus = Extensions.AsString(reader("AccountStatus")),
            .Active = Extensions.AsBool(reader("Active")),
            .ApAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("ApAccountIdNo")),
            .BankAccountNo = Extensions.AsString(reader("BankAccountNo")),
            .BankIdNo = Extensions.AsNullable(Of Int16?)(reader("BankIdNo")),
            .ContactDesignation = Extensions.AsString(reader("ContactDesignation")),
            .ContactPerson = Extensions.AsString(reader("ContactPerson")),
            .CountryCode = Extensions.AsString(reader("CountryCode")),
            .CreditLimit = Extensions.AsDecimal(reader("CreditLimit")),
            .CrNumber = Extensions.AsString(reader("CrNumber")),
            .DateAccountOpen = Extensions.AsDateTime(reader("DateAccountOpen")),
            .District = Extensions.AsString(reader("District")),
            .Email = Extensions.AsString(reader("Email")),
            .ExpAccountIdNo = Extensions.AsNullable(Of Int16?)(reader("ExpAccountIdNo")),
            .Fax = Extensions.AsString(reader("Fax")),
            .Iban = Extensions.AsString(reader("Iban")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .Mobile = Extensions.AsString(reader("Mobile")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OpeningBalance = Extensions.AsDouble(reader("OpeningBalance")),
            .PaymentDueDays = Extensions.AsInt(Of Short)(reader("PaymentDueDays")),
            .PaymentMethod = Extensions.AsString(reader("PaymentMethod")),
            .Phone1 = Extensions.AsString(reader("Phone1")),
            .Phone2 = Extensions.AsString(reader("Phone2")),
            .PoBox = Extensions.AsString(reader("PoBox")),
            .ProvinceState = Extensions.AsString(reader("ProvinceState")),
            .SettlementDiscount = Extensions.AsDecimal(reader("SettlementDiscount")),
            .SettlementDueDays = Extensions.AsInt(Of Short)(reader("SettlementDueDays")),
            .Street = Extensions.AsString(reader("Street")),
            .SupplierCode = Extensions.AsString(reader("SupplierCode")),
            .SupplierName = Extensions.AsString(reader("SupplierName")),
            .SupplierNameAra = Extensions.AsString(reader("SupplierNameAra")),
            .TownCity = Extensions.AsString(reader("TownCity")),
            .VatNumber = Extensions.AsString(reader("VatNumber")),
            .Website = Extensions.AsString(reader("Website")),
            .ZipCode = Extensions.AsString(reader("ZipCode"))
            }

        Private Function Take(supplier As Supplier) As Object()
            Return New Object() {
                                    "@AccountStatus", supplier.AccountStatus,
                                    "@Active", supplier.Active,
                                    "@ApAccountIdNo", supplier.ApAccountIdNo,
                                    "@BankAccountNo", supplier.BankAccountNo,
                                    "@BankIdNo", supplier.BankIdNo,
                                    "@ContactDesignation", supplier.ContactDesignation,
                                    "@ContactPerson", supplier.ContactPerson,
                                    "@CountryCode", supplier.CountryCode,
                                    "@CreditLimit", supplier.CreditLimit,
                                    "@CrNumber", supplier.CrNumber,
                                    "@DateAccountOpen", supplier.DateAccountOpen,
                                    "@District", supplier.District,
                                    "@Email", supplier.Email,
                                    "@ExpAccountIdNo", supplier.ExpAccountIdNo,
                                    "@Fax", supplier.Fax,
                                    "@Iban", supplier.Iban,
                                    "@IdNo", supplier.IdNo,
                                    "@Mobile", supplier.Mobile,
                                    "@Notes", supplier.Notes,
                                    "@OpeningBalance", supplier.OpeningBalance,
                                    "@PaymentDueDays", supplier.PaymentDueDays,
                                    "@PaymentMethod", supplier.PaymentMethod,
                                    "@Phone1", supplier.Phone1,
                                    "@Phone2", supplier.Phone2,
                                    "@PoBox", supplier.PoBox,
                                    "@ProvinceState", supplier.ProvinceState,
                                    "@SettlementDiscount", supplier.SettlementDiscount,
                                    "@SettlementDueDays", supplier.SettlementDueDays,
                                    "@Street", supplier.Street,
                                    "@SupplierCode", supplier.SupplierCode,
                                    "@SupplierName", supplier.SupplierName,
                                    "@SupplierNameAra", supplier.SupplierNameAra,
                                    "@TownCity", supplier.TownCity,
                                    "@VatNumber", supplier.VatNumber,
                                    "@Website", supplier.Website,
                                    "@ZipCode", supplier.ZipCode
                                }
        End Function

        Public Function UpdateOpeningBalance(ByRef bizObj As Supplier) As Integer Implements IDaoContacts(Of Supplier).UpdateOpeningBalance
            Dim sql As String
            Dim retVal As Integer = 0
            If bizObj.OpeningBalance <> 0 Then
                If Db.Scalar("Select Count(*) from ApOpenInvoice where JournalCode = 'BB' and JournalIdNo = " & bizObj.IdNo) = 0 Then
                    sql = "INSERT ApOpenInvoice ([JournalCode], [JournalIdNo], [JournalItemIdNo], [PaidAmount], [DiscountTaken]) VALUES " &
                          "('BB', @IdNo, @IdNo, 0, 0)"
                    Dim params() As Object = {"@IdNo", bizObj.IdNo}
                    retVal = Db.Insert(sql, params)
                End If
            End If
            Return retVal
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return UpdateCode(Db, "Supplier", "SupplierCode", "IdNo", idNo)
        End Function

    End Class

End Namespace