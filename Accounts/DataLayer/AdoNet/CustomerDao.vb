Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports CrystalDecisions.ReportSource

Namespace DataLayer.AdoNet
    ' Data access object for Customer
    ' ** DAO Pattern

    Public Class CustomerDao
        Inherits CommonDao
        Implements IDaoAll(Of Customer), IDaoContacts(Of Customer)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As Customer Implements IDaoAll(Of Customer).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, CustomerCode, CustomerName, CustomerNameAra, ContactPerson, ContactDesignation, Street, District, TownCity, " &
                    " ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Mobile, Fax, Email, Website, VatNumber, CrNumber, AccountStatus, " &
                    " ArAccountIdNo, RevAccountIdNo, DiscountSchemeIdNo, CreditLimit, SettlementDueDays, SettlementDiscount, PaymentDueDays, DateAccountOpen, " &
                    " BankIdNo, BankAccountNo, Iban, PaymentMethod, Notes, OpeningBalance, Active" &
                    "   FROM [Customer]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim x As Customer
            x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
            'Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Customer) _
            Implements IDaoAll(Of Customer).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "CustomerName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, CustomerCode, CustomerName, CustomerNameAra " &
                    "   FROM [Customer] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef customer As Customer) As Integer Implements IDaoAll(Of Customer).UpdateRecord
            Dim sql As String =
                    " UPDATE [Customer]" &
                    "   SET CustomerCode = @CustomerCode," &
                    "       CustomerName = @CustomerName," &
                    "       CustomerNameAra = @CustomerNameAra," &
                    "		ContactPerson = @ContactPerson," &
                    "       ContactDesignation = @ContactDesignation," &
                    "       Street = @Street," &
                    "       District = @District," &
                    "       TownCity = @TownCity," &
                    "       ProvinceState = @ProvinceState," &
                    "       CountryCode = @CountryCode," &
                    "       PoBox = @PoBox," &
                    "       ZipCode = @ZipCode," &
                    "       Phone1 = @Phone1," &
                    "       Phone2 = @Phone2," &
                    "       Mobile = @Mobile," &
                    "       Fax = @Fax," &
                    "       Email = @Email," &
                    "       Website = @Website," &
                    "       VatNumber = @VatNumber," &
                    "       CrNumber = @CrNumber," &
                    "       AccountStatus = @AccountStatus," &
                    "       ArAccountIdNo = @ArAccountIdNo," &
                    "       RevAccountIdNo = @RevAccountIdNo," &
                    "       DiscountSchemeIdNo = @DiscountSchemeIdNo," &
                    "       CreditLimit = @CreditLimit," &
                    "       SettlementDueDays = @SettlementDueDays," &
                    "       SettlementDiscount = @SettlementDiscount," &
                    "       PaymentDueDays = @PaymentDueDays," &
                    "       DateAccountOpen = @DateAccountOpen," &
                    "       BankAccountNo = @BankAccountNo," &
                    "       BankIdNo = @BankIdNo," &
                    "       Iban = @Iban," &
                    "       PaymentMethod = @PaymentMethod," &
                    "       Notes = @Notes," &
                    "       OpeningBalance = @OpeningBalance," &
                    "       Active = @Active" &
                    "  WHERE IdNo = @IdNo"

            Return Db.Update(sql, Take(customer))
        End Function

        Public Function AddRecord(ByRef customer As Customer) As Integer Implements IDaoAll(Of Customer).AddRecord
            Dim sql As String =
                    " INSERT INTO [Customer] " &
                    "        (CustomerCode,CustomerName,CustomerNameAra,ContactPerson,ContactDesignation,Street,District,TownCity," &
                    "         ProvinceState,CountryCode,PoBox,ZipCode,Phone1,Phone2,Mobile,Fax,Email,Website,VatNumber,CrNumber," &
                    "         AccountStatus,ArAccountIdNo,RevAccountIdNo,DiscountSchemeIdNo,CreditLimit,SettlementDueDays,SettlementDiscount,PaymentDueDays," &
                    "         DateAccountOpen,BankIdNo,BankAccountNo,Iban,PaymentMethod,Notes,OpeningBalance,Active)" &
                    " VALUES (@CustomerCode,@CustomerName,@CustomerNameAra,@ContactPerson,@ContactDesignation,@Street,@District,@TownCity," &
                    "         @ProvinceState,@CountryCode,@PoBox,@ZipCode,@Phone1,@Phone2,@Mobile,@Fax,@Email,@Website,@VatNumber,@CrNumber," &
                    "         @AccountStatus,@ArAccountIdNo,@RevAccountIdNo,@DiscountSchemeIdNo,@CreditLimit,@SettlementDueDays,@SettlementDiscount,@PaymentDueDays," &
                    "         @DateAccountOpen,@BankIdNo,@BankAccountNo,@Iban,@PaymentMethod,@Notes,@OpeningBalance,@Active)"
            Return Db.Insert(sql, Take(customer))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Customer) =
                                    Function(reader) _
            New Customer() With {
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .CustomerCode = Extensions.AsString(reader("CustomerCode")),
            .CustomerName = Extensions.AsString(reader("CustomerName")),
            .CustomerNameAra = Extensions.AsString(reader("CustomerNameAra")),
            .ContactPerson = Extensions.AsString(reader("ContactPerson")),
            .ContactDesignation = Extensions.AsString(reader("ContactDesignation")),
            .Street = Extensions.AsString(reader("Street")),
            .District = Extensions.AsString(reader("District")),
            .TownCity = Extensions.AsString(reader("TownCity")),
            .ProvinceState = Extensions.AsString(reader("ProvinceState")),
            .CountryCode = Extensions.AsString(reader("CountryCode")),
            .PoBox = Extensions.AsString(reader("PoBox")),
            .ZipCode = Extensions.AsString(reader("ZipCode")),
            .Phone1 = Extensions.AsString(reader("Phone1")),
            .Phone2 = Extensions.AsString(reader("Phone2")),
            .Mobile = Extensions.AsString(reader("Mobile")),
            .Fax = Extensions.AsString(reader("Fax")),
            .Email = Extensions.AsString(reader("Email")),
            .Website = Extensions.AsString(reader("Website")),
            .VatNumber = Extensions.AsString(reader("VatNumber")),
            .CrNumber = Extensions.AsString(reader("CrNumber")),
            .AccountStatus = Extensions.AsString(reader("AccountStatus")),
            .ArAccountIdNo = Extensions.AsNullable(Of Int32?)(reader("ArAccountIdNo")),
            .RevAccountIdNo = Extensions.AsNullable(Of Int32?)(reader("RevAccountIdNo")),
            .DiscountSchemeIdNo = Extensions.AsNullable(Of Int16?)(reader("DiscountSchemeIdNo")),
            .CreditLimit = Extensions.AsDecimal(reader("CreditLimit")),
            .SettlementDueDays = Extensions.AsInt(Of Short)(reader("SettlementDueDays")),
            .SettlementDiscount = Extensions.AsDecimal(reader("SettlementDiscount")),
            .PaymentDueDays = Extensions.AsInt(Of Short)(reader("PaymentDueDays")),
            .DateAccountOpen = Extensions.AsDateTime(reader("DateAccountOpen")),
            .BankIdNo = Extensions.AsNullable(Of Int16?)(reader("BankIdNo")),
            .BankAccountNo = Extensions.AsString(reader("BankAccountNo")),
            .Iban = Extensions.AsString(reader("Iban")),
            .PaymentMethod = Extensions.AsString(reader("PaymentMethod")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OpeningBalance = Extensions.AsDouble(reader("OpeningBalance")),
            .Active = Extensions.AsBool(reader("Active"))
            }

        Private Function Take(ByRef customer As Customer) As Object()
            Return New Object() {
                                    "@IdNo", customer.IdNo,
                                    "@CustomerCode", customer.CustomerCode,
                                    "@CustomerName", customer.CustomerName,
                                    "@CustomerNameAra", customer.CustomerNameAra,
                                    "@ContactPerson", customer.ContactPerson,
                                    "@ContactDesignation", customer.ContactDesignation,
                                    "@Street", customer.Street,
                                    "@District", customer.District,
                                    "@TownCity", customer.TownCity,
                                    "@ProvinceState", customer.ProvinceState,
                                    "@CountryCode", customer.CountryCode,
                                    "@PoBox", customer.PoBox,
                                    "@ZipCode", customer.ZipCode,
                                    "@Phone1", customer.Phone1,
                                    "@Phone2", customer.Phone2,
                                    "@Mobile", customer.Mobile,
                                    "@Fax", customer.Fax,
                                    "@Email", customer.Email,
                                    "@Website", customer.Website,
                                    "@VatNumber", customer.VatNumber,
                                    "@CrNumber", customer.CrNumber,
                                    "@AccountStatus", customer.AccountStatus,
                                    "@ArAccountIdNo", customer.ArAccountIdNo,
                                    "@RevAccountIdNo", customer.RevAccountIdNo,
                                    "@DiscountSchemeIdNo", customer.DiscountSchemeIdNo,
                                    "@CreditLimit", customer.CreditLimit,
                                    "@SettlementDueDays", customer.SettlementDueDays,
                                    "@SettlementDiscount", customer.SettlementDiscount,
                                    "@PaymentDueDays", customer.PaymentDueDays,
                                    "@DateAccountOpen", customer.DateAccountOpen,
                                    "@BankIdNo", customer.BankIdNo,
                                    "@BankAccountNo", customer.BankAccountNo,
                                    "@Iban", customer.Iban,
                                    "@PaymentMethod", customer.PaymentMethod,
                                    "@Notes", customer.Notes,
                                    "@OpeningBalance", customer.OpeningBalance,
                                    "@Active", customer.Active
                                }
        End Function

        Public Function UpdateOpeningBalance(ByRef bizObj As Customer) As Integer Implements IDaoContacts(Of Customer).UpdateOpeningBalance
            Dim sql As String
            Dim retVal As Integer = 0
            If bizObj.OpeningBalance <> 0 Then
                If Db.Scalar("Select Count(*) from ArOpenInvoice where JournalCode = 'BB' and JournalIdNo = " & bizObj.IdNo) = 0 Then
                    sql = "INSERT ArOpenInvoice ([JournalCode], [JournalIdNo], [JournalItemIdNo]) VALUES " &
                                                "('BB', @IdNo, @IdNo)"
                    Dim params() As Object = {"@IdNo", bizObj.IdNo}
                    retVal = Db.Insert(sql, params)
                End If
            End If
            Return retVal
        End Function

    End Class

End Namespace