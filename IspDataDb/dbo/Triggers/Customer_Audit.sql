CREATE TRIGGER [dbo].[Customer_Audit]
ON [dbo].[Customer]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Customer', COALESCE(i.[IdNo], d.[IdNo]), ac.[BranchIdNo],
        'Customer record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
       AND EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
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
