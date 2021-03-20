Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for Employee
    ' ** DAO Pattern

    Public Class EmployeeDao
        Inherits CommonDao
        Implements IDaoAll(Of Employee), IDaoAutoCode

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As Employee Implements IDaoAll(Of Employee).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, EmployeeCode, Title, EmployeeName, EmployeeNameAra, Gender, BirthDate, MaritalStatus, NationalityCode, ReligionIdNo, NationalIdNo, Street, District, TownCity, " &
                    " ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Email, DepartmentIdNo, DesignationIdNo, DutyHours, HiredDate, ReleasedDate, " &
                    " ArAccountIdNo, BankIdNo, BankAccountNo, Iban, Notes, OpeningBalance, OtRateRegular, OtRateHoliday, OtRateSpecial, Balance, PayCycleIdNo, PayGroupIdNo, PaymentMethod, Active" &
                    "   FROM [Employee]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim deductionDao = New EmployeeDeductionDao
            Dim earningDao = New EmployeeEarningDao
            Dim phoneDao = New EmployeePhoneDao
            Dim d As List(Of EmployeeDeduction) = deductionDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
            Dim e As List(Of EmployeeEarning) = earningDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
            Dim p As List(Of EmployeePhone) = phoneDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
            data.RegularEmployeeDeductions = d
            data.RegularEmployeeEarnings = e
            data.EmployeePhones = p
            Return data
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Employee) _
            Implements IDaoAll(Of Employee).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeCode, EmployeeName, EmployeeNameAra " &
                    "   FROM [Employee] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetEmployeesInPayGroup(Optional sortExpression As String = Nothing) As List(Of Employee)
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeCode, EmployeeName, EmployeeNameAra, PayGroupIdNo " &
                    "   FROM [Employee] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function UpdateRecord(ByRef employee As Employee) As Integer Implements IDaoAll(Of Employee).UpdateRecord
            Dim sql As String =
                    " UPDATE [Employee] SET " &
                    " Active = @Active," &
                    " Balance = @Balance," &
                    " BankAccountNo = @BankAccountNo," &
                    " BankIdNo = @BankIdNo," &
                    " BirthDate = @BirthDate," &
                    " CountryCode = @CountryCode," &
                    " DepartmentIdNo = @DepartmentIdNo," &
                    " DesignationIdNo = @DesignationIdNo," &
                    " District = @District," &
                    " DutyHours = @DutyHours," &
                    " Email = @Email," &
                    " EmployeeCode = @EmployeeCode," &
                    " EmployeeName = @EmployeeName," &
                    " EmployeeNameAra = @EmployeeNameAra," &
                    " Gender = @Gender," &
                    " HiredDate = @HiredDate," &
                    " Iban = @Iban," &
                    " MaritalStatus = @MaritalStatus," &
                    " NationalIdNo = @NationalIdNo," &
                    " NationalityCode = @NationalityCode," &
                    " Notes = @Notes," &
                    " OpeningBalance = @OpeningBalance," &
                    " OtRateRegular = @OtRateRegular," &
                    " OtRateHoliday = @OtRateHoliday," &
                    " OtRateSpecial = @OtRateSpecial," &
                    " PayCycleIdNo = @PayCycleIdNo," &
                    " PayGroupIdNo = @PayGroupIdNo," &
                    " PaymentMethod = @PaymentMethod," &
                    " Phone1 = @Phone1," &
                    " Phone2 = @Phone2," &
                    " PoBox = @PoBox," &
                    " ProvinceState = @ProvinceState," &
                    " ReleasedDate = @ReleasedDate," &
                    " ReligionIdNo = @ReligionIdNo," &
                    " Street = @Street," &
                    " Title = @Title," &
                    " TownCity = @TownCity," &
                    " ZipCode = @ZipCode" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(employee))
        End Function

        Public Function AddRecord(ByRef employee As Employee) As Integer Implements IDaoAll(Of Employee).AddRecord
            Dim sql As String =
                    " INSERT INTO [Employee] " &
                    "        (Title, EmployeeCode, EmployeeName, EmployeeNameAra, Gender, BirthDate, MaritalStatus, NationalIdNo, ReligionIdNo, Street, District, TownCity, " &
                    "         ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Email, DepartmentIdNo, DesignationIdNo, HiredDate, ReleasedDate, " &
                    "         BankIdNo, BankAccountNo, Iban, Notes, OpeningBalance, OtRateRegular, OtRateHoliday, OtRateSpecial, Balance, DutyHours, PayCycleIdNo, PayGroupIdNo, PaymentMethod, Active)" &
                    " VALUES (@Title, @EmployeeCode, @EmployeeName, @EmployeeNameAra, @Gender, @BirthDate, @MaritalStatus, @NationalIdNo, @ReligionIdNo, @Street, @District, @TownCity, " &
                    "         @ProvinceState, @CountryCode, @PoBox, @ZipCode, @Phone1, @Phone2, @Email, @DepartmentIdNo, @DesignationIdNo, @HiredDate, @ReleasedDate, " &
                    "         @BankIdNo, @BankAccountNo, @Iban, @Notes, @OpeningBalance, @OtRateRegular, @OtRateHoliday, @OtRateSpecial, @Balance, @DutyHours, @PayCycleIdNo, @PayGroupIdNo, @PaymentMethod,  @Active)"
            Return _db.Insert(sql, Take(employee))
        End Function

        Private Shared ReadOnly Make As Func(Of IDataReader, Employee) =
                                    Function(reader) _
            New Employee() With {
            .Active = Extensions.AsBool(reader("Active")),
            .Balance = Extensions.AsDecimal(reader("Balance")),
            .BankAccountNo = Extensions.AsString(reader("BankAccountNo")),
            .BankIdNo = Extensions.AsNullable(Of Int16?)(reader("BankIdNo")),
            .BirthDate = Extensions.AsNullable(Of Date?)(reader("BirthDate")),
            .CountryCode = Extensions.AsString(reader("CountryCode")),
            .DepartmentIdNo = Extensions.AsNullable(Of Int16?)(reader("DepartmentIdNo")),
            .DesignationIdNo = Extensions.AsNullable(Of Int16?)(reader("DesignationIdNo")),
            .District = Extensions.AsString(reader("District")),
            .DutyHours = Extensions.AsString(reader("DutyHours")),
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
            .OtRateRegular = Extensions.AsDecimal(reader("OtRateRegular")),
            .OtRateHoliday = Extensions.AsDecimal(reader("OtRateHoliday")),
            .OtRateSpecial = Extensions.AsDecimal(reader("OtRateSpecial")),
            .PayCycleIdNo = Extensions.AsNullable(Of Int16?)(reader("PayCycleIdNo")),
            .PayGroupIdNo = Extensions.AsNullable(Of Int16?)(reader("PayGroupIdNo")),
            .PaymentMethod = Extensions.AsChar(reader("PaymentMethod")),
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
                                    "@Active", employee.Active,
                                    "@Balance", employee.Balance,
                                    "@BankAccountNo", employee.BankAccountNo,
                                    "@BankIdNo", employee.BankIdNo,
                                    "@BirthDate", employee.BirthDate,
                                    "@CountryCode", employee.CountryCode,
                                    "@DepartmentIdNo", employee.DepartmentIdNo,
                                    "@DesignationIdNo", employee.DesignationIdNo,
                                    "@District", employee.District,
                                    "@DutyHours", employee.DutyHours,
                                    "@Email", employee.Email,
                                    "@EmployeeCode", employee.EmployeeCode,
                                    "@EmployeeName", employee.EmployeeName,
                                    "@EmployeeNameAra", employee.EmployeeNameAra,
                                    "@Gender", employee.Gender,
                                    "@HiredDate", employee.HiredDate,
                                    "@Iban", employee.Iban,
                                    "@IdNo", employee.IdNo,
                                    "@MaritalStatus", employee.MaritalStatus,
                                    "@NationalIdNo", employee.NationalIdNo,
                                    "@NationalityCode", employee.NationalityCode,
                                    "@Notes", employee.Notes,
                                    "@OpeningBalance", employee.OpeningBalance,
                                    "@OtRateRegular", employee.OtRateRegular,
                                    "@OtRateHoliday", employee.OtRateHoliday,
                                    "@OtRateSpecial", employee.OtRateSpecial,
                                    "@PayCycleIdNo", employee.PayCycleIdNo,
                                    "@PayGroupIdNo", employee.PayGroupIdNo,
                                    "@PaymentMethod", employee.PaymentMethod,
                                    "@Phone1", employee.Phone1,
                                    "@Phone2", employee.Phone2,
                                    "@PoBox", employee.PoBox,
                                    "@ProvinceState", employee.ProvinceState,
                                    "@ReleasedDate", employee.ReleasedDate,
                                    "@ReligionIdNo", employee.ReligionIdNo,
                                    "@Street", employee.Street,
                                    "@Title", employee.Title,
                                    "@TownCity", employee.TownCity,
                                    "@ZipCode", employee.ZipCode
                                }
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return GetCode(_db, "Employee", "EmployeeCode", "IdNo", idNo)
        End Function

    End Class

End Namespace