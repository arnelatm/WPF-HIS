CREATE TRIGGER [dbo].[CdJournal_Audit] ON [dbo].[CdJournal]
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    INSERT [dbo].[AuditEvent] ([UserIdNo],[UserNameSnapshot],[Action],[EntityName],[RecordIdNo],[ReferenceNo],[BranchIdNo],[Description],[ApplicationName],[MachineName])
    SELECT ac.[UserIdNo],ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' WHEN ISNULL(d.[Posted],0)=0 AND ISNULL(i.[Posted],0)=1 THEN 'Post' WHEN ISNULL(d.[Approved],0)=0 AND ISNULL(i.[Approved],0)=1 THEN 'Approve' WHEN ISNULL(d.[Cancelled],0)=0 AND ISNULL(i.[Cancelled],0)=1 THEN 'Cancel' ELSE 'Update' END,
        'CdJournal',COALESCE(i.[IdNo],d.[IdNo]),COALESCE(i.[ReferenceNo],d.[ReferenceNo]),ac.[BranchIdNo],'Cash disbursement journal record changed',ac.[ApplicationName],ac.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
       AND EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId],[FieldName],[OldValue],[NewValue])
        SELECT @AuditEventId,v.[FieldName],v.[OldValue],v.[NewValue]
        FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo]
        CROSS APPLY (VALUES (N'Posted',CONVERT(NVARCHAR(MAX),d.[Posted]),CONVERT(NVARCHAR(MAX),i.[Posted])),(N'Approved',CONVERT(NVARCHAR(MAX),d.[Approved]),CONVERT(NVARCHAR(MAX),i.[Approved])),(N'Cancelled',CONVERT(NVARCHAR(MAX),d.[Cancelled]),CONVERT(NVARCHAR(MAX),i.[Cancelled]))) v([FieldName],[OldValue],[NewValue])
        WHERE ISNULL(v.[OldValue],N'')<>ISNULL(v.[NewValue],N'');
    END;
END;
