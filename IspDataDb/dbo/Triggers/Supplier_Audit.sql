CREATE TRIGGER [dbo].[Supplier_Audit]
ON [dbo].[Supplier]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Supplier', COALESCE(i.[IdNo], d.[IdNo]), ac.[BranchIdNo],
        'Supplier record changed', ac.[ApplicationName], ac.[MachineName]
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
            (N'SupplierCode', CONVERT(NVARCHAR(MAX), d.[SupplierCode]), CONVERT(NVARCHAR(MAX), i.[SupplierCode])),
            (N'SupplierName', CONVERT(NVARCHAR(MAX), d.[SupplierName]), CONVERT(NVARCHAR(MAX), i.[SupplierName])),
            (N'SupplierNameAra', CONVERT(NVARCHAR(MAX), d.[SupplierNameAra]), CONVERT(NVARCHAR(MAX), i.[SupplierNameAra])),
            (N'Active', CONVERT(NVARCHAR(MAX), d.[Active]), CONVERT(NVARCHAR(MAX), i.[Active]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') <> ISNULL(v.[NewValue], N'');
    END;
END;
