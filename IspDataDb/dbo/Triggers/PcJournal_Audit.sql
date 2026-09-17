CREATE TRIGGER [dbo].[PcJournal_Audit] ON [dbo].[PcJournal]
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    INSERT [dbo].[AuditEvent] ([UserIdNo],[UserNameSnapshot],[Action],[EntityName],[RecordIdNo],[ReferenceNo],[BranchIdNo],[Description],[ApplicationName],[MachineName])
    SELECT ac.[UserIdNo],ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' WHEN ISNULL(d.[Posted],0)=0 AND ISNULL(i.[Posted],0)=1 THEN 'Post' WHEN ISNULL(d.[Approved],0)=0 AND ISNULL(i.[Approved],0)=1 THEN 'Approve' WHEN ISNULL(d.[Cancelled],0)=0 AND ISNULL(i.[Cancelled],0)=1 THEN 'Cancel' ELSE 'Update' END,
        'PcJournal',COALESCE(i.[IdNo],d.[IdNo]),COALESCE(i.[ReferenceNo],d.[ReferenceNo]),ac.[BranchIdNo],'Petty cash journal record changed',ac.[ApplicationName],ac.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
       AND EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId],[FieldName],[OldValue],[NewValue])
        SELECT @AuditEventId,v.[FieldName],v.[OldValue],v.[NewValue]
        FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo]
        CROSS APPLY (VALUES
            (N'TransactionDate',CONVERT(NVARCHAR(MAX),d.[TransactionDate],23),CONVERT(NVARCHAR(MAX),i.[TransactionDate],23)),
            (N'ReferenceNo',CONVERT(NVARCHAR(MAX),d.[ReferenceNo]),CONVERT(NVARCHAR(MAX),i.[ReferenceNo])),
            (N'Amount',CONVERT(NVARCHAR(MAX),d.[Amount]),CONVERT(NVARCHAR(MAX),i.[Amount])),
            (N'AccountIdNo',CONVERT(NVARCHAR(MAX),d.[AccountIdNo]),CONVERT(NVARCHAR(MAX),i.[AccountIdNo])),
            (N'PaymentType',CONVERT(NVARCHAR(MAX),d.[PaymentType]),CONVERT(NVARCHAR(MAX),i.[PaymentType])),
            (N'PayType',CONVERT(NVARCHAR(MAX),d.[PayType]),CONVERT(NVARCHAR(MAX),i.[PayType])),
            (N'PayeeIdNo',CONVERT(NVARCHAR(MAX),d.[PayeeIdNo]),CONVERT(NVARCHAR(MAX),i.[PayeeIdNo])),
            (N'PayeeName',CONVERT(NVARCHAR(MAX),d.[PayeeName]),CONVERT(NVARCHAR(MAX),i.[PayeeName])),
            (N'CheckNumber',CONVERT(NVARCHAR(MAX),d.[CheckNumber]),CONVERT(NVARCHAR(MAX),i.[CheckNumber])),
            (N'CheckDate',CONVERT(NVARCHAR(MAX),d.[CheckDate],23),CONVERT(NVARCHAR(MAX),i.[CheckDate],23)),
            (N'ORNumber',CONVERT(NVARCHAR(MAX),d.[ORNumber]),CONVERT(NVARCHAR(MAX),i.[ORNumber])),
            (N'DiscountTaken',CONVERT(NVARCHAR(MAX),d.[DiscountTaken]),CONVERT(NVARCHAR(MAX),i.[DiscountTaken])),
            (N'DiscountAccountIdNo',CONVERT(NVARCHAR(MAX),d.[DiscountAccountIdNo]),CONVERT(NVARCHAR(MAX),i.[DiscountAccountIdNo])),
            (N'Applied',CONVERT(NVARCHAR(MAX),d.[Applied]),CONVERT(NVARCHAR(MAX),i.[Applied])),
            (N'UnApplied',CONVERT(NVARCHAR(MAX),d.[UnApplied]),CONVERT(NVARCHAR(MAX),i.[UnApplied])),
            (N'VatNumber',CONVERT(NVARCHAR(MAX),d.[VatNumber]),CONVERT(NVARCHAR(MAX),i.[VatNumber])),
            (N'VatAmount',CONVERT(NVARCHAR(MAX),d.[VatAmount]),CONVERT(NVARCHAR(MAX),i.[VatAmount])),
            (N'Notes',CONVERT(NVARCHAR(MAX),d.[Notes]),CONVERT(NVARCHAR(MAX),i.[Notes])),
            (N'PcClosed',CONVERT(NVARCHAR(MAX),d.[PcClosed]),CONVERT(NVARCHAR(MAX),i.[PcClosed])),
            (N'CdJournalIdNo',CONVERT(NVARCHAR(MAX),d.[CdJournalIdNo]),CONVERT(NVARCHAR(MAX),i.[CdJournalIdNo])),
            (N'Approved',CONVERT(NVARCHAR(MAX),d.[Approved]),CONVERT(NVARCHAR(MAX),i.[Approved])),
            (N'Posted',CONVERT(NVARCHAR(MAX),d.[Posted]),CONVERT(NVARCHAR(MAX),i.[Posted])),
            (N'Cancelled',CONVERT(NVARCHAR(MAX),d.[Cancelled]),CONVERT(NVARCHAR(MAX),i.[Cancelled]))) v([FieldName],[OldValue],[NewValue])
        WHERE ISNULL(v.[OldValue],N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue],N'') COLLATE DATABASE_DEFAULT;
    END;
END;
