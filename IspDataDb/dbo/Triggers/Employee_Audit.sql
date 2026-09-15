CREATE TRIGGER [dbo].[Employee_Audit]
ON [dbo].[Employee]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Employee', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Employee record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac
    WHERE d.[IdNo] IS NULL OR i.[IdNo] IS NULL
       OR EXISTS (
            SELECT i.[Active], i.[ActualDutyHours], i.[Balance], i.[BankAccountNo], i.[BankIdNo],
                   i.[BirthDate], i.[BloodType], i.[CountryCode], i.[DepartmentIdNo], i.[DesignationIdNo],
                   i.[District], i.[DutyHours], i.[Email], i.[EmployeeCode], i.[EmployeeName], i.[EmployeeNameAra],
                   i.[Gender], i.[HiredDate], i.[Iban], i.[MaritalStatus], i.[NationalIdNo], i.[NationalityCode],
                   i.[Notes], i.[OpeningBalance], i.[PayCycleIdNo], i.[PayGroupIdNo], i.[PaymentMethod],
                   i.[Phone1], i.[Phone2], i.[PoBox], i.[ProvinceState], i.[ReleasedDate], i.[ReligionIdNo],
                   i.[SponsorType], i.[Street], i.[Supervisor], i.[SupervisorIdNo], i.[Title], i.[TownCity],
                   i.[ZipCode], i.[Picture]
            EXCEPT
            SELECT d.[Active], d.[ActualDutyHours], d.[Balance], d.[BankAccountNo], d.[BankIdNo],
                   d.[BirthDate], d.[BloodType], d.[CountryCode], d.[DepartmentIdNo], d.[DesignationIdNo],
                   d.[District], d.[DutyHours], d.[Email], d.[EmployeeCode], d.[EmployeeName], d.[EmployeeNameAra],
                   d.[Gender], d.[HiredDate], d.[Iban], d.[MaritalStatus], d.[NationalIdNo], d.[NationalityCode],
                   d.[Notes], d.[OpeningBalance], d.[PayCycleIdNo], d.[PayGroupIdNo], d.[PaymentMethod],
                   d.[Phone1], d.[Phone2], d.[PoBox], d.[ProvinceState], d.[ReleasedDate], d.[ReligionIdNo],
                   d.[SponsorType], d.[Street], d.[Supervisor], d.[SupervisorIdNo], d.[Title], d.[TownCity],
                   d.[ZipCode], d.[Picture]
       );

    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
       AND EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT INTO [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'EmployeeCode', CONVERT(NVARCHAR(MAX), d.[EmployeeCode]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[EmployeeCode]) COLLATE DATABASE_DEFAULT),
            (N'EmployeeName', CONVERT(NVARCHAR(MAX), d.[EmployeeName]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[EmployeeName]) COLLATE DATABASE_DEFAULT),
            (N'EmployeeNameAra', CONVERT(NVARCHAR(MAX), d.[EmployeeNameAra]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[EmployeeNameAra]) COLLATE DATABASE_DEFAULT),
            (N'Gender', CONVERT(NVARCHAR(MAX), d.[Gender]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[Gender]) COLLATE DATABASE_DEFAULT),
            (N'MaritalStatus', CONVERT(NVARCHAR(MAX), d.[MaritalStatus]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[MaritalStatus]) COLLATE DATABASE_DEFAULT),
            (N'NationalityCode', CONVERT(NVARCHAR(MAX), d.[NationalityCode]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[NationalityCode]) COLLATE DATABASE_DEFAULT),
            (N'ReligionIdNo', CONVERT(NVARCHAR(MAX), d.[ReligionIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[ReligionIdNo]) COLLATE DATABASE_DEFAULT),
            (N'DepartmentIdNo', CONVERT(NVARCHAR(MAX), d.[DepartmentIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[DepartmentIdNo]) COLLATE DATABASE_DEFAULT),
            (N'DesignationIdNo', CONVERT(NVARCHAR(MAX), d.[DesignationIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[DesignationIdNo]) COLLATE DATABASE_DEFAULT),
            (N'HiredDate', CONVERT(NVARCHAR(MAX), d.[HiredDate]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[HiredDate]) COLLATE DATABASE_DEFAULT),
            (N'ReleasedDate', CONVERT(NVARCHAR(MAX), d.[ReleasedDate]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[ReleasedDate]) COLLATE DATABASE_DEFAULT),
            (N'ArAccountIdNo', CONVERT(NVARCHAR(MAX), d.[ArAccountIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[ArAccountIdNo]) COLLATE DATABASE_DEFAULT),
            (N'BankIdNo', CONVERT(NVARCHAR(MAX), d.[BankIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[BankIdNo]) COLLATE DATABASE_DEFAULT),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[Notes]) COLLATE DATABASE_DEFAULT),
            (N'OpeningBalance', CONVERT(NVARCHAR(MAX), d.[OpeningBalance]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[OpeningBalance]) COLLATE DATABASE_DEFAULT),
            (N'PaymentMethod', CONVERT(NVARCHAR(MAX), d.[PaymentMethod]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[PaymentMethod]) COLLATE DATABASE_DEFAULT),
            (N'PayCycleIdNo', CONVERT(NVARCHAR(MAX), d.[PayCycleIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[PayCycleIdNo]) COLLATE DATABASE_DEFAULT),
            (N'PayGroupIdNo', CONVERT(NVARCHAR(MAX), d.[PayGroupIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[PayGroupIdNo]) COLLATE DATABASE_DEFAULT),
            (N'PaySalariedOrHourly', CONVERT(NVARCHAR(MAX), d.[PaySalariedOrHourly]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[PaySalariedOrHourly]) COLLATE DATABASE_DEFAULT),
            (N'PayRateType', CONVERT(NVARCHAR(MAX), d.[PayRateType]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[PayRateType]) COLLATE DATABASE_DEFAULT),
            (N'PayRateAmount', CONVERT(NVARCHAR(MAX), d.[PayRateAmount]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[PayRateAmount]) COLLATE DATABASE_DEFAULT),
            (N'SponsorType', CONVERT(NVARCHAR(MAX), d.[SponsorType]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[SponsorType]) COLLATE DATABASE_DEFAULT),
            (N'OTRateRegular', CONVERT(NVARCHAR(MAX), d.[OTRateRegular]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[OTRateRegular]) COLLATE DATABASE_DEFAULT),
            (N'OTRateHoliday', CONVERT(NVARCHAR(MAX), d.[OTRateHoliday]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[OTRateHoliday]) COLLATE DATABASE_DEFAULT),
            (N'OTRateSpecial', CONVERT(NVARCHAR(MAX), d.[OTRateSpecial]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[OTRateSpecial]) COLLATE DATABASE_DEFAULT),
            (N'DutyHours', CONVERT(NVARCHAR(MAX), d.[DutyHours]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[DutyHours]) COLLATE DATABASE_DEFAULT),
            (N'ActualDutyHours', CONVERT(NVARCHAR(MAX), d.[ActualDutyHours]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[ActualDutyHours]) COLLATE DATABASE_DEFAULT),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo]) COLLATE DATABASE_DEFAULT),
            (N'Supervisor', CONVERT(NVARCHAR(MAX), d.[Supervisor]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[Supervisor]) COLLATE DATABASE_DEFAULT),
            (N'SupervisorIdNo', CONVERT(NVARCHAR(MAX), d.[SupervisorIdNo]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[SupervisorIdNo]) COLLATE DATABASE_DEFAULT),
            (N'Active', CONVERT(NVARCHAR(MAX), d.[Active]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[Active]) COLLATE DATABASE_DEFAULT)) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') <> ISNULL(v.[NewValue], N'');
    END;
END;
GO

