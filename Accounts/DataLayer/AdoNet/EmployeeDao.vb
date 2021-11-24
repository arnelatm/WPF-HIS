Imports System.IO
Imports AATM.Accounts.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.GlobalFuncNSub
Imports Extensions = AATM.DataLayer.AdoNet.Extensions

Namespace DataLayer.AdoNet
    ' Data access object for Employee
    ' ** DAO Pattern

    Public Class EmployeeDao
        Inherits CommonDao
        Implements IDaoAll(Of Employee), IDaoAutoCode, IDaoList(Of EmployeeId)

        Private ReadOnly _db As New Db()

        Public Function GetRecordByIdNo(idNo) As Employee Implements IDaoAll(Of Employee).GetRecordByIdNo
            Dim sql As String =
                    " SELECT IdNo, EmployeeCode, Title, EmployeeName, EmployeeNameAra, Gender, BirthDate, BloodType, MaritalStatus, NationalityCode, ReligionIdNo, NationalIdNo, Street, District, TownCity, " &
                    " ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Email, DepartmentIdNo, DesignationIdNo, DutyHours, HiredDate, ReleasedDate, " &
                    " ArAccountIdNo, BankIdNo, BankAccountNo, Iban, Notes, OpeningBalance, Balance, PayCycleIdNo, PayGroupIdNo, PaymentMethod, SponsorType, Supervisor, SupervisorIdNo, Active, Picture" &
                    "   FROM [Employee]" &
                    " WHERE IdNo = @IdNo"
            Dim params() As Object = {"@IdNo", idNo}
            Dim data = _db.Read(sql, Make, params).FirstOrDefault()
            Dim deductionDao = New EmployeePayElementDao
            Dim earningDao = New EmployeePayElementDao
            Dim phoneDao = New EmployeePhoneDao
            Dim leaveDao = New EmployeeLeaveCreditDao
            Dim dd As List(Of EmployeePayElement) = deductionDao.GetDaoRecords("EmployeeIdNo = " & data.IdNo & " and PayElementKind = '" & GlobalFunctions.EnumToCode(PayElementKindSelection.Deduction) & "'")
            Dim er As List(Of EmployeePayElement) = earningDao.GetDaoRecords("EmployeeIdNo = " & data.IdNo & " and PayElementKind = '" & GlobalFunctions.EnumToCode(PayElementKindSelection.Earning) & "'")
            Dim ph As List(Of EmployeePhone) = phoneDao.GetRecordsWithGroupIdNo(data.IdNo, "sequence")
            Dim lc As List(Of EmployeeLeaveCredit) = leaveDao.GetRecordsWithGroupIdNo(data.IdNo, "Sequence")
            data.PayFrequency = CodeToEnum(Of PayFrequencySelection)(GetFieldWithIdNo(data.PayCycleIdNo, "PayCycle", "PayFrequency"))
            data.RegularEmployeeDeductions = dd
            data.RegularEmployeeEarnings = er
            data.EmployeePhones = ph
            data.EmployeeLeaveCredits = lc
            Return data
        End Function

        Public Function GetAll(Optional sortExpression As String = Nothing) As List(Of Employee) Implements IDaoAll(Of Employee).GetAll
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeCode, EmployeeName, EmployeeNameAra " &
                    "   FROM [Employee] order by " & sortExpression
            Return _db.Read(sql, Make).ToList()
        End Function

        Public Function GetEmployeeIdList(Optional sortExpression As String = Nothing) As List(Of EmployeeId) Implements IDaoList(Of EmployeeId).GetList
            If sortExpression Is Nothing Then
                sortExpression = "EmployeeName ASC"
            End If
            Dim sql As String =
                    " SELECT IdNo, EmployeeName, NationalIdNo, Picture" &
                    " FROM [Employee] where Active = 1 order by " & sortExpression
            Return _db.Read(sql, MakeIdList).ToList()
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
                    " BloodType = @BloodType," &
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
                    " PayCycleIdNo = @PayCycleIdNo," &
                    " PayGroupIdNo = @PayGroupIdNo," &
                    " PaymentMethod = @PaymentMethod," &
                    " Phone1 = @Phone1," &
                    " Phone2 = @Phone2," &
                    " PoBox = @PoBox," &
                    " ProvinceState = @ProvinceState," &
                    " ReleasedDate = @ReleasedDate," &
                    " ReligionIdNo = @ReligionIdNo," &
                    " SponsorType = @SponsorType," &
                    " Street = @Street," &
                    " Supervisor = @Supervisor," &
                    " SupervisorIdNo = @SupervisorIdNo," &
                    " Title = @Title," &
                    " TownCity = @TownCity," &
                    " ZipCode = @ZipCode," &
                    " Picture = @Picture" &
                    " WHERE IdNo = @IdNo"
            Return _db.Update(sql, Take(employee))
        End Function

        Public Function AddRecord(ByRef employee As Employee) As Integer Implements IDaoAll(Of Employee).AddRecord
            Dim sql As String =
                    " INSERT INTO [Employee] " &
                    "        (Title, EmployeeCode, EmployeeName, EmployeeNameAra, Gender, BirthDate, BloodType, MaritalStatus, NationalIdNo, ReligionIdNo, Street, District, TownCity, " &
                    "         ProvinceState, CountryCode, PoBox, ZipCode, Phone1, Phone2, Email, DepartmentIdNo, DesignationIdNo, HiredDate, ReleasedDate, " &
                    "         BankIdNo, BankAccountNo, Iban, Notes, OpeningBalance, Balance, DutyHours, PayCycleIdNo, PayGroupIdNo, PaymentMethod, SponsorType, Supervisor, SupervisorIdNo, Active, Picture)" &
                    " VALUES (@Title, @EmployeeCode, @EmployeeName, @EmployeeNameAra, @Gender, @BirthDate, @BloodType, @MaritalStatus, @NationalIdNo, @ReligionIdNo, @Street, @District, @TownCity, " &
                    "         @ProvinceState, @CountryCode, @PoBox, @ZipCode, @Phone1, @Phone2, @Email, @DepartmentIdNo, @DesignationIdNo, @HiredDate, @ReleasedDate, " &
                    "         @BankIdNo, @BankAccountNo, @Iban, @Notes, @OpeningBalance, @Balance, @DutyHours, @PayCycleIdNo, @PayGroupIdNo, @PaymentMethod, @SponsorType, @Supervisor, @SupervisorIdNo, @Active, @Picture)"
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
            .BloodType = Extensions.AsString(reader("BloodType")),
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
            .PayCycleIdNo = Extensions.AsNullable(Of Int16?)(reader("PayCycleIdNo")),
            .PayGroupIdNo = Extensions.AsNullable(Of Int16?)(reader("PayGroupIdNo")),
            .PaymentMethod = Extensions.AsChar(reader("PaymentMethod")),
            .Phone1 = Extensions.AsString(reader("Phone1")),
            .Phone2 = Extensions.AsString(reader("Phone2")),
            .PoBox = Extensions.AsString(reader("PoBox")),
            .ProvinceState = Extensions.AsString(reader("ProvinceState")),
            .ReleasedDate = Extensions.AsNullable(Of Date?)(reader("ReleasedDate")),
            .ReligionIdNo = Extensions.AsNullable(Of Int16?)(reader("ReligionIdNo")),
            .SponsorType = Extensions.AsChar(reader("SponsorType")),
            .Street = Extensions.AsString(reader("Street")),
            .Supervisor = Extensions.AsBool(reader("Supervisor")),
            .SupervisorIdNo = Extensions.AsInt(Of Int32)(reader("SupervisorIdNo")),
            .Title = Extensions.AsString(reader("Title")),
            .TownCity = Extensions.AsString(reader("TownCity")),
            .ZipCode = Extensions.AsString(reader("ZipCode")),
            .Picture = Extensions.AsImage(reader("Picture"))
            }

        Private Shared ReadOnly MakeIdList As Func(Of IDataReader, EmployeeId) = Function(reader) New EmployeeId() With {
            .EmployeeName = Extensions.AsString(reader("EmployeeName")),
            .IdNo = Extensions.AsId(Of Int32)(reader("IdNo")),
            .NationalIdNo = Extensions.AsString(reader("NationalIdNo")),
            .Picture = Extensions.AsImage(reader("Picture"))
        }

        Private Function Take(ByRef employee As Employee) As Object()
            Return New Object() {
                                    "@Active", employee.Active,
                                    "@Balance", employee.Balance,
                                    "@BankAccountNo", employee.BankAccountNo,
                                    "@BankIdNo", employee.BankIdNo,
                                    "@BirthDate", employee.BirthDate,
                                    "@BloodType", employee.BloodType,
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
                                    "@PayCycleIdNo", employee.PayCycleIdNo,
                                    "@PayGroupIdNo", employee.PayGroupIdNo,
                                    "@PaymentMethod", employee.PaymentMethod,
                                    "@Phone1", employee.Phone1,
                                    "@Phone2", employee.Phone2,
                                    "@PoBox", employee.PoBox,
                                    "@ProvinceState", employee.ProvinceState,
                                    "@ReleasedDate", employee.ReleasedDate,
                                    "@ReligionIdNo", employee.ReligionIdNo,
                                    "@SponsorType", employee.SponsorType,
                                    "@Street", employee.Street,
                                    "@Supervisor", employee.Supervisor,
                                    "@SupervisorIdNo", employee.SupervisorIdNo,
                                    "@Title", employee.Title,
                                    "@TownCity", employee.TownCity,
                                    "@ZipCode", employee.ZipCode,
                                    "@Picture", ToSqlImage(employee.Picture)
                                }
        End Function

        Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode.GenerateCode
            Return UpdateCode(_db, "Employee", "EmployeeCode", "IdNo", idNo)
        End Function

        Public Function ToSqlImage(ByVal imageIn As System.Drawing.Image) As Byte()
            If imageIn Is Nothing Then
                Return Nothing
            Else
                Dim data As Byte() = {}
                Dim saveImage As New Bitmap(imageIn)
                saveImage.Save("C:\temp\Picture.jpg", Imaging.ImageFormat.Jpeg)
                saveImage.Dispose()
                Dim cPictureBox As New PictureBox
                cPictureBox.Image = Image.FromFile("c:\temp\Picture.jpg")
                Using ms = New MemoryStream()
                    If imageIn IsNot Nothing Then
                        cPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                        data = ms.ToArray()
                    End If
                End Using
                Return data
            End If
        End Function

        Public Function EmployeeIdInsertTvp(ByRef tvpTable As DataTable) As Integer
            Return _db.InsertTvp("InsertEmployeeIdPrintingTvp", tvpTable)
        End Function

    End Class

End Namespace