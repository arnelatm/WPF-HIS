CREATE TRIGGER [dbo].[ArJournal_Audit] ON [dbo].[ArJournal]
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    INSERT [dbo].[AuditEvent] ([UserIdNo],[UserNameSnapshot],[Action],[EntityName],[RecordIdNo],[ReferenceNo],[BranchIdNo],[Description],[ApplicationName],[MachineName])
    SELECT TRY_CONVERT(SMALLINT,SESSION_CONTEXT(N'AuditUserIdNo')),TRY_CONVERT(NVARCHAR(100),SESSION_CONTEXT(N'AuditUserName')),
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' WHEN ISNULL(d.[Posted],0)=0 AND ISNULL(i.[Posted],0)=1 THEN 'Post' WHEN ISNULL(d.[Approved],0)=0 AND ISNULL(i.[Approved],0)=1 THEN 'Approve' WHEN ISNULL(d.[Cancelled],0)=0 AND ISNULL(i.[Cancelled],0)=1 THEN 'Cancel' ELSE 'Update' END,
        'ArJournal',COALESCE(i.[IdNo],d.[IdNo]),COALESCE(i.[ReferenceNo],d.[ReferenceNo]),TRY_CONVERT(SMALLINT,SESSION_CONTEXT(N'AuditBranchIdNo')),'AR journal record changed',TRY_CONVERT(NVARCHAR(128),SESSION_CONTEXT(N'AuditApplicationName')),TRY_CONVERT(NVARCHAR(128),SESSION_CONTEXT(N'AuditMachineName'))
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo];
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId],[FieldName],[OldValue],[NewValue])
        SELECT @AuditEventId,v.[FieldName],v.[OldValue],v.[NewValue]
        FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo]
        CROSS APPLY (VALUES (N'Posted',CONVERT(NVARCHAR(MAX),d.[Posted]),CONVERT(NVARCHAR(MAX),i.[Posted])),(N'Approved',CONVERT(NVARCHAR(MAX),d.[Approved]),CONVERT(NVARCHAR(MAX),i.[Approved])),(N'Cancelled',CONVERT(NVARCHAR(MAX),d.[Cancelled]),CONVERT(NVARCHAR(MAX),i.[Cancelled]))) v([FieldName],[OldValue],[NewValue])
        WHERE ISNULL(v.[OldValue],N'')<>ISNULL(v.[NewValue],N'');
    END;
END;
