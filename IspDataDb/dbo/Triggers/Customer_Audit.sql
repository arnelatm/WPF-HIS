CREATE TRIGGER [dbo].[Customer_Audit]
ON [dbo].[Customer]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT TRY_CONVERT(SMALLINT, SESSION_CONTEXT(N'AuditUserIdNo')), TRY_CONVERT(NVARCHAR(100), SESSION_CONTEXT(N'AuditUserName')),
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Customer', COALESCE(i.[IdNo], d.[IdNo]), TRY_CONVERT(SMALLINT, SESSION_CONTEXT(N'AuditBranchIdNo')),
        'Customer record changed', TRY_CONVERT(NVARCHAR(128), SESSION_CONTEXT(N'AuditApplicationName')), TRY_CONVERT(NVARCHAR(128), SESSION_CONTEXT(N'AuditMachineName'))
    FROM inserted AS i FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo];
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'CustomerCode', CONVERT(NVARCHAR(MAX), d.[CustomerCode]), CONVERT(NVARCHAR(MAX), i.[CustomerCode])),
            (N'CustomerName', CONVERT(NVARCHAR(MAX), d.[CustomerName]), CONVERT(NVARCHAR(MAX), i.[CustomerName])),
            (N'CustomerNameAra', CONVERT(NVARCHAR(MAX), d.[CustomerNameAra]), CONVERT(NVARCHAR(MAX), i.[CustomerNameAra])),
            (N'Active', CONVERT(NVARCHAR(MAX), d.[Active]), CONVERT(NVARCHAR(MAX), i.[Active]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') <> ISNULL(v.[NewValue], N'');
    END;
END;
