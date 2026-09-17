CREATE TRIGGER [dbo].[FiscalYearJournalPostingRun_Audit] ON [dbo].[FiscalYearJournalPostingRun]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'FiscalYearJournalPostingRun', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Fiscal year posting run changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;

    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        DECLARE @OldValues NVARCHAR(MAX) = (SELECT * FROM deleted FOR XML RAW);
        DECLARE @NewValues NVARCHAR(MAX) = (SELECT * FROM inserted FOR XML RAW);
        EXEC [dbo].[WriteAuditFieldSnapshot]
            @AuditEventId = @AuditEventId,
            @OldValues = @OldValues,
            @NewValues = @NewValues;
    END;
END;
GO

CREATE TRIGGER [dbo].[FiscalYearCloseRun_Audit] ON [dbo].[FiscalYearCloseRun]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'FiscalYearCloseRun', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Fiscal year close run changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;

    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        DECLARE @OldValues NVARCHAR(MAX) = (SELECT * FROM deleted FOR XML RAW);
        DECLARE @NewValues NVARCHAR(MAX) = (SELECT * FROM inserted FOR XML RAW);
        EXEC [dbo].[WriteAuditFieldSnapshot]
            @AuditEventId = @AuditEventId,
            @OldValues = @OldValues,
            @NewValues = @NewValues;
    END;
END;
GO
