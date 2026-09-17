CREATE TRIGGER [dbo].[ApJournal_Audit] ON [dbo].[ApJournal]
AFTER INSERT, UPDATE, DELETE AS
BEGIN
    SET NOCOUNT ON;
    INSERT [dbo].[AuditEvent] ([UserIdNo],[UserNameSnapshot],[Action],[EntityName],[RecordIdNo],[ReferenceNo],[BranchIdNo],[Description],[ApplicationName],[MachineName])
    SELECT ac.[UserIdNo],ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' WHEN ISNULL(d.[Posted],0)=0 AND ISNULL(i.[Posted],0)=1 THEN 'Post' WHEN ISNULL(d.[Approved],0)=0 AND ISNULL(i.[Approved],0)=1 THEN 'Approve' WHEN ISNULL(d.[Cancelled],0)=0 AND ISNULL(i.[Cancelled],0)=1 THEN 'Cancel' ELSE 'Update' END,
        'ApJournal',COALESCE(i.[IdNo],d.[IdNo]),COALESCE(i.[ReferenceNo],d.[ReferenceNo]),ac.[BranchIdNo],'AP journal record changed',ac.[ApplicationName],ac.[MachineName]
    FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
       AND EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId],[FieldName],[OldValue],[NewValue])
        SELECT @AuditEventId,v.[FieldName],v.[OldValue],v.[NewValue]
        FROM inserted i FULL OUTER JOIN deleted d ON d.[IdNo]=i.[IdNo]
        CROSS APPLY (VALUES (N'SupplierIdNo',CONVERT(NVARCHAR(MAX),d.[SupplierIdNo]),CONVERT(NVARCHAR(MAX),i.[SupplierIdNo])),(N'TransactionDate',CONVERT(NVARCHAR(MAX),d.[TransactionDate],23),CONVERT(NVARCHAR(MAX),i.[TransactionDate],23)),(N'ReferenceNo',CONVERT(NVARCHAR(MAX),d.[ReferenceNo]),CONVERT(NVARCHAR(MAX),i.[ReferenceNo])),(N'TransactionType',CONVERT(NVARCHAR(MAX),d.[TransactionType]),CONVERT(NVARCHAR(MAX),i.[TransactionType])),(N'Amount',CONVERT(NVARCHAR(MAX),d.[Amount]),CONVERT(NVARCHAR(MAX),i.[Amount])),(N'AccountIdNo',CONVERT(NVARCHAR(MAX),d.[AccountIdNo]),CONVERT(NVARCHAR(MAX),i.[AccountIdNo])),(N'DueDate',CONVERT(NVARCHAR(MAX),d.[DueDate],23),CONVERT(NVARCHAR(MAX),i.[DueDate],23)),(N'SettlementDueDate',CONVERT(NVARCHAR(MAX),d.[SettlementDueDate],23),CONVERT(NVARCHAR(MAX),i.[SettlementDueDate],23)),(N'SettlementDiscount',CONVERT(NVARCHAR(MAX),d.[SettlementDiscount]),CONVERT(NVARCHAR(MAX),i.[SettlementDiscount])),(N'InvoiceNo',CONVERT(NVARCHAR(MAX),d.[InvoiceNo]),CONVERT(NVARCHAR(MAX),i.[InvoiceNo])),(N'InvoiceDate',CONVERT(NVARCHAR(MAX),d.[InvoiceDate],23),CONVERT(NVARCHAR(MAX),i.[InvoiceDate],23)),(N'VatNumber',CONVERT(NVARCHAR(MAX),d.[VatNumber]),CONVERT(NVARCHAR(MAX),i.[VatNumber])),(N'VatAmount',CONVERT(NVARCHAR(MAX),d.[VatAmount]),CONVERT(NVARCHAR(MAX),i.[VatAmount])),(N'Notes',CONVERT(NVARCHAR(MAX),d.[Notes]),CONVERT(NVARCHAR(MAX),i.[Notes])),(N'Posted',CONVERT(NVARCHAR(MAX),d.[Posted]),CONVERT(NVARCHAR(MAX),i.[Posted])),(N'Approved',CONVERT(NVARCHAR(MAX),d.[Approved]),CONVERT(NVARCHAR(MAX),i.[Approved])),(N'Cancelled',CONVERT(NVARCHAR(MAX),d.[Cancelled]),CONVERT(NVARCHAR(MAX),i.[Cancelled]))) v([FieldName],[OldValue],[NewValue])
        WHERE ISNULL(v.[OldValue],N'') COLLATE DATABASE_DEFAULT<>ISNULL(v.[NewValue],N'') COLLATE DATABASE_DEFAULT;
    END;
END;
