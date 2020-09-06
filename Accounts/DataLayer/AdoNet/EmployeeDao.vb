Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Employee
    ' ** DAO Pattern

    Public Class EmployeeDao
        Inherits CommonDao
        Implements IDaoAll(Of Employee)

        Private ReadOnly Db As New Db()

        Public Function GetRecordById(idNo) As Employee Implements IDaoAll(Of Employee).GetRecordById
            Dim sql As String =
                    " SELECT IdNo, EmployeeCode, Title, EmployeeName, EmployeeNameAra, Gender, BirthDate, MaritalStatus, NationalityCode, ReligionIdNo, NationalIdNo, Street, District, TownCity, " &
                    " ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Email, DepartmentIdNo, DesignationIdNo, HiredDate, ReleasedDate, " &
                    " ArAccountIdNo, BankIdNo, BankAccountNo, Iban, Notes, OpeningBalance, Balance, PayFrequency, PaySalariedOrHourly, PayRateAmount, PayRateType, Active" &
                    "   FROM [Employee]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            'Dim x As Employee
            'x = Db.Read(sql, Make, params).FirstOrDefault()
            'Return x
            Return Db.Read(sql, Make, params).FirstOrDefault()
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Employee) _
            Implements IDaoAll(Of Employee).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeCode, EmployeeName, EmployeeNameAra " &
                    "   FROM [Employee] order by " & sortExpression
            Return Db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef employee As Employee) As Integer Implements IDaoAll(Of Employee).UpdateRecord
            Dim sql As String =
                    " UPDATE [Employee]" &
                    " SET EmployeeCode = @EmployeeCode," &
                    " Title = @Title," &
                    " EmployeeName = @EmployeeName," &
                    " EmployeeNameAra = @EmployeeNameAra," &
                    " Gender = @Gender," &
                    " BirthDate = @BirthDate," &
                    " MaritalStatus = @MaritalStatus," &
                    " NationalityCode = @NationalityCode," &
                    " ReligionIdNo = @ReligionIdNo," &
                    " NationalIdNo = @NationalIdNo," &
                    " Street = @Street," &
                    " District = @District," &
                    " TownCity = @TownCity," &
                    " ProvinceState = @ProvinceState," &
                    " CountryCode = @CountryCode," &
                    " PoBox = @PoBox," &
                    " ZipCode = @ZipCode," &
                    " Phone1 = @Phone1," &
                    " Phone2 = @Phone2," &
                    " Email = @Email," &
                    " DepartmentIdNo = @DepartmentIdNo," &
                    " DesignationIdNo = @DesignationIdNo," &
                    " HiredDate = @HiredDate," &
                    " ReleasedDate = @ReleasedDate," &
                    " ArAccountIdNo= @ArAccountIdNo," &
                    " BankIdNo = @BankIdNo," &
                    " BankAccountNo = @BankAccountNo," &
                    " Iban = @Iban," &
                    " Notes = @Notes," &
                    " OpeningBalance = @OpeningBalance," &
                    " Balance = @Balance," &
                    " PayFrequency = @PayFrequency," &
                    " PaySalariedOrHourly = @PaySalariedOrHourly," &
                    " PayRateAmount = @PayRateAmount," &
                    " PayRateType = @PayRateType," &
                    " Active = @Active" &
                    " WHERE IdNo = @IdNo"
            Return Db.Update(sql, Take(employee))
        End Function

        Public Function AddRecord(ByRef employee As Employee) As Integer Implements IDaoAll(Of Employee).AddRecord
            Dim sql As String =
                    " INSERT INTO [Employee] " &
                    "        (Title, EmployeeCode, EmployeeName, EmployeeNameAra, Gender, BirthDate, MaritalStatus, NationalIdNo, ReligionIdNo, Street, District, TownCity, " &
                    "         ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Email, DepartmentIdNo, DesignationIdNo, HiredDate, ReleasedDate, " &
                    "         ArAccountIdNo, BankIdNo, BankAccountNo, Iban, Notes, OpeningBalance, Balance,  PayFrequency, PaySalariedOrHourly, PayRateType, PayRateAmount, Active)" &
                    " VALUES (@Title, @EmployeeCode, @EmployeeName, @EmployeeNameAra, @Gender, @BirthDate, @MaritalStatus, @NationalIdNo, @ReligionIdNo, @Street, @District, @TownCity, " &
                    "         @ProvinceState, @CountryCode, @PoBox, @ZipCode, @Phone1, @Phone2, @Email, @DepartmentIdNo, @DesignationIdNo, @HiredDate, @ReleasedDate, " &
                    "         @ArAccountIdNo, @BankIdNo, @BankAccountNo, @Iban, @Notes, @OpeningBalance, @Balance, @PayFrequency, @PaySalariedOrHourly, @PayRateType, @PayRateAmount, @Active)"
            Return Db.Insert(sql, Take(employee))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Employee) =
                                    Function(reader) _
            New Employee() With {
            .Active = Extensions.AsBool(reader("Active")),
            .ArAccountIdNo = Extensions.AsNullable(Of Int32?)(reader("ArAccountIdNo")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .BankAccountNo = Extensions.AsString(reader("BankAccountNo")),
            .BankIdNo = Extensions.AsNullable(Of Int16?)(reader("BankIdNo")),
            .BirthDate = Extensions.AsNullable(Of Date?)(reader("BirthDate")),
            .CountryCode = Extensions.AsString(reader("CountryCode")),
            .DepartmentIdNo = Extensions.AsNullable(Of Int16?)(reader("DepartmentIdNo")),
            .DesignationIdNo = Extensions.AsNullable(Of Int16?)(reader("DesignationIdNo")),
            .District = Extensions.AsString(reader("District")),
            .Email = Extensions.AsString(reader("Email")),
            .EmployeeCode = Extensions.AsString(reader("EmployeeCode")),
            .EmployeeName = Extensions.AsString(reader("EmployeeName")),
            .EmployeeNameAra = Extensions.AsString(reader("EmployeeNameAra")),
            .Gender = Extensions.AsString(reader("Gender")),
            .HiredDate = Extensions.AsNullable(Of Date?)(reader("HiredDate")),
            .Iban = Extensions.AsString(reader("Iban")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .MaritalStatus = Extensions.AsString(reader("MaritalStatus")),
            .NationalIdNo = Extensions.AsString(reader("NationalIdNo")),
            .NationalityCode = Extensions.AsString(reader("NationalityCode")),
            .Notes = Extensions.AsString(reader("Notes")),
            .OpeningBalance = Extensions.AsDecimal(reader("OpeningBalance")),
            .PayFrequency = Extensions.AsString(reader("PayFrequency")),
            .PaySalariedOrHourly = Extensions.AsString(reader("PaySalariedOrHourly")),
            .PayRateType = Extensions.AsString(reader("PayRateType")),
            .PayRateAmount = Extensions.AsDecimal(reader("PayRateAmount")),
            .Phone1 = Extensions.AsString(reader("Phone1")),
            .Phone2 = Extensions.AsString(reader("Phone2")),
            .PoBox = Extensions.AsString(reader("PoBox")),
            .ProvinceState = Extensions.AsString(reader("ProvinceState")),
            .ReleasedDate = Extensions.AsNullable(Of Date?)(reader("ReleasedDate")),
            .ReligionIdNo = Extensions.AsNullable(Of Int16?)(reader("ReligionIdNo")),
            .Street = Extensions.AsString(reader("Street")),
            .Title = Extensions.AsString(reader("Title")),
            .TownCity = Extensions.AsString(reader("TownCity")),
            .ZipCode = Extensions.AsString(reader("ZipCode"))
            }

        Private Function Take(ByRef employee As Employee) As Object()
            Return New Object() {
                                    "@IdNo", employee.IdNo,
                                    "@EmployeeCode", employee.EmployeeCode,
                                    "@Title", employee.Title,
                                    "@EmployeeName", employee.EmployeeName,
                                    "@EmployeeNameAra", employee.EmployeeNameAra,
                                    "@Gender", employee.Gender,
                                    "@BirthDate", employee.BirthDate,
                                    "@MaritalStatus", employee.MaritalStatus,
                                    "@NationalityCode", employee.NationalityCode,
                                    "@ReligionIdNo", employee.ReligionIdNo,
                                    "@NationalIdNo", employee.NationalIdNo,
                                    "@Street", employee.Street,
                                    "@District", employee.District,
                                    "@TownCity", employee.TownCity,
                                    "@ProvinceState", employee.ProvinceState,
                                    "@CountryCode", employee.CountryCode,
                                    "@PoBox", employee.PoBox,
                                    "@ZipCode", employee.ZipCode,
                                    "@Phone1", employee.Phone1,
                                    "@Phone2", employee.Phone2,
                                    "@Email", employee.Email,
                                    "@DepartmentIdNo", employee.DepartmentIdNo,
                                    "@DesignationIdNo", employee.DesignationIdNo,
                                    "@HiredDate", employee.HiredDate,
                                    "@ReleasedDate", employee.ReleasedDate,
                                    "@ArAccountIdNo", employee.ArAccountIdNo,
                                    "@BankIdNo", employee.BankIdNo,
                                    "@BankAccountNo", employee.BankAccountNo,
                                    "@Iban", employee.Iban,
                                    "@Notes", employee.Notes,
                                    "@OpeningBalance", employee.OpeningBalance,
                                    "@Balance", employee.Balance,
                                    "@PayFrequency", employee.PayFrequency,
                                    "@PaySalariedOrHourly", employee.PaySalariedOrHourly,
                                    "@PayRateType", employee.PayRateType,
                                    "@PayRateAmount", employee.PayRateAmount,
                                    "@Active", employee.Active
                                }
        End Function

    End Class

End Namespace