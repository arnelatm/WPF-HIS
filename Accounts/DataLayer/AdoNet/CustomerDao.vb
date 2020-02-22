Imports AATM.DataLayer.AdoNet
Imports AATM.Accounts.BusinessLayer

Namespace DataLayer.AdoNet
    ' Data access object for Customer
    ' ** DAO Pattern

    Public Class CustomerDao
        Inherits CommonDaoOld
        Implements ICustomerDao

        Private Shared ReadOnly Db As New Db()

        Public Sub New()
            DbCommon = Db
        End Sub

        Public Function GetRecordById(idNo As Integer) As Customer Implements ICustomerDao.GetRecordById
            Dim sql As String =
                    " SELECT IDNo, CustomerCode, CustomerName, CustomerNameAra, ContactPerson, ContactDesignation, Street, District, TownCity, " &
                    " ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Mobile, Fax, Email, Website, VatNumber, CrNumber, AccountStatus, " &
                    " ArAccountIdNo, RevAccountIdNo, DiscountSchemeIdNo, CreditLimit, SettlementDueDays, SettlementDiscount, PaymentDueDays, DateAccountOpen, " &
                    " BankIdNo, BankAccountNo, Iban, PaymentMethod, Notes, OpeningBalance, Active" &
                    "   FROM [Customer]" &
                    " WHERE IDNo = @IDNo"
            Dim params() As Object = {"@IDNo", idNo}
            Dim x As Customer
            x = Db.Read(sql, Make, params).FirstOrDefault()
            Return x
            'Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = "CustomerName ASC") As List(Of Customer) _
            Implements ICustomerDao.GetAll
            Dim sql As String =
                    " SELECT IDNo, CustomerCode, CustomerName, CustomerNameAra " &
                    "   FROM [Customer] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef customer As Customer) As Integer Implements ICustomerDao.UpdateRecord
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
                    "  WHERE IDNo = @IDNo"

            Return Db.Update(sql, Take(customer))
        End Function

        Public Function AddRecord(ByRef customer As Customer) As Integer Implements ICustomerDao.AddRecord
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
            .IdNo = Extensions.AsId(reader("IDNo")),
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
            .ArAccountIdNo = Extensions.AsInt(Of Integer)(reader("ArAccountIdNo")),
            .RevAccountIdNo = Extensions.AsInt(Of Integer)(reader("RevAccountIdNo")),
            .DiscountSchemeIdNo = Extensions.AsInt(Of Short)(reader("DiscountSchemeIdNo")),
            .CreditLimit = Extensions.AsDecimal(reader("CreditLimit")),
            .SettlementDueDays = Extensions.AsInt(Of Short)(reader("SettlementDueDays")),
            .SettlementDiscount = Extensions.AsDecimal(reader("SettlementDiscount")),
            .PaymentDueDays = Extensions.AsInt(Of Short)(reader("PaymentDueDays")),
            .DateAccountOpen = Extensions.AsDateTime(reader("DateAccountOpen")),
            .BankIdNo = Extensions.AsInt(Of Short)(reader("BankIdNo")),
            .BankAccountNo = Extensions.AsString(reader("BankAccountNo")),
            .Iban = Extensions.AsString(reader("Iban")),
            .PaymentMethod = Extensions.AsString(reader("PaymentMethod")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OpeningBalance = Extensions.AsDouble(reader("OpeningBalance")),
            .Active = Extensions.AsBool(reader("Active"))
            }

        Private Function Take(ByRef customer As Customer) As Object()
            Return New Object() {
                                    "@IDNo", customer.IdNo,
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

    End Class

End Namespace