CREATE TRIGGER [dbo].[EmployeePhone_Audit]
ON [dbo].[EmployeePhone]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'EmployeePhone', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'EmployeePhone record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac
    WHERE i.[IdNo] IS NULL OR d.[IdNo] IS NULL
       OR ISNULL(i.[EmployeeIdNo], 0) <> ISNULL(d.[EmployeeIdNo], 0)
       OR ISNULL(i.[PhoneTypeIdNo], 0) <> ISNULL(d.[PhoneTypeIdNo], 0)
       OR ISNULL(i.[CountryTelIdNo], 0) <> ISNULL(d.[CountryTelIdNo], 0)
       OR ISNULL(i.[AreaCode], '') <> ISNULL(d.[AreaCode], '')
       OR ISNULL(i.[PhoneNumber], '') <> ISNULL(d.[PhoneNumber], '')
       OR ISNULL(i.[Sequence], 0) <> ISNULL(d.[Sequence], 0);
END;
GO
