CREATE TRIGGER [dbo].[EmployeeDetails_Audit]
ON [dbo].[EmployeeDetails]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'EmployeeDetails', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'EmployeeDetails record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'BranchID', CONVERT(NVARCHAR(MAX), d.[BranchID]), CONVERT(NVARCHAR(MAX), i.[BranchID])),
            (N'EmployeeID', CONVERT(NVARCHAR(MAX), d.[EmployeeID]), CONVERT(NVARCHAR(MAX), i.[EmployeeID])),
            (N'FIrstName', CONVERT(NVARCHAR(MAX), d.[FIrstName]), CONVERT(NVARCHAR(MAX), i.[FIrstName])),
            (N'FirstNameAra', CONVERT(NVARCHAR(MAX), d.[FirstNameAra]), CONVERT(NVARCHAR(MAX), i.[FirstNameAra])),
            (N'BirthDate', CONVERT(NVARCHAR(MAX), d.[BirthDate], 23), CONVERT(NVARCHAR(MAX), i.[BirthDate], 23)),
            (N'DateJoined', CONVERT(NVARCHAR(MAX), d.[DateJoined], 23), CONVERT(NVARCHAR(MAX), i.[DateJoined], 23)),
            (N'DateReleased', CONVERT(NVARCHAR(MAX), d.[DateReleased], 23), CONVERT(NVARCHAR(MAX), i.[DateReleased], 23)),
            (N'Gender', CONVERT(NVARCHAR(MAX), d.[Gender]), CONVERT(NVARCHAR(MAX), i.[Gender])),
            (N'NationalID', CONVERT(NVARCHAR(MAX), d.[NationalID]), CONVERT(NVARCHAR(MAX), i.[NationalID])),
            (N'ReligionID', CONVERT(NVARCHAR(MAX), d.[ReligionID]), CONVERT(NVARCHAR(MAX), i.[ReligionID])),
            (N'IQAMANo', CONVERT(NVARCHAR(MAX), d.[IQAMANo]), CONVERT(NVARCHAR(MAX), i.[IQAMANo]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[EmployeeActions_Audit]
ON [dbo].[EmployeeActions]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'EmployeeActions', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'EmployeeActions record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayInformation_Audit]
ON [dbo].[PayInformation]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayInformation', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayInformation record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[RecurringPayElement_Audit]
ON [dbo].[RecurringPayElement]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'RecurringPayElement', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'RecurringPayElement record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Payroll_Audit]
ON [dbo].[Payroll]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Payroll', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Payroll record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayrollDetail_Audit]
ON [dbo].[PayrollDetail]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayrollDetail', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayrollDetail record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayrollPayElement_Audit]
ON [dbo].[PayrollPayElement]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayrollPayElement', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayrollPayElement record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayElement_Audit]
ON [dbo].[PayElement]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayElement', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayElement record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayElementItem_Audit]
ON [dbo].[PayElementItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayElementItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayElementItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayElementAccount_Audit]
ON [dbo].[PayElementAccount]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayElementAccount', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayElementAccount record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayElementGroup_Audit]
ON [dbo].[PayElementGroup]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayElementGroup', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayElementGroup record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayGroup_Audit]
ON [dbo].[PayGroup]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayGroup', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayGroup record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayCycle_Audit]
ON [dbo].[PayCycle]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayCycle', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayCycle record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PayPeriod_Audit]
ON [dbo].[PayPeriod]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PayPeriod', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PayPeriod record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PensionScheme_Audit]
ON [dbo].[PensionScheme]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PensionScheme', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PensionScheme record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PensionProvider_Audit]
ON [dbo].[PensionProvider]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PensionProvider', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PensionProvider record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PensionRate_Audit]
ON [dbo].[PensionRate]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PensionRate', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PensionRate record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[GeneralJournalItem_Audit]
ON [dbo].[GeneralJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'GeneralJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'GeneralJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
       AND (SELECT COUNT(*) FROM inserted) + (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'JournalIdNo', CONVERT(NVARCHAR(MAX), d.[JournalIdNo]), CONVERT(NVARCHAR(MAX), i.[JournalIdNo])),
            (N'AccountIdNo', CONVERT(NVARCHAR(MAX), d.[AccountIdNo]), CONVERT(NVARCHAR(MAX), i.[AccountIdNo])),
            (N'Debit', CONVERT(NVARCHAR(MAX), d.[Debit]), CONVERT(NVARCHAR(MAX), i.[Debit])),
            (N'Credit', CONVERT(NVARCHAR(MAX), d.[Credit]), CONVERT(NVARCHAR(MAX), i.[Credit])),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]), CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo])),
            (N'PayIdNo', CONVERT(NVARCHAR(MAX), d.[PayIdNo]), CONVERT(NVARCHAR(MAX), i.[PayIdNo])),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]), CONVERT(NVARCHAR(MAX), i.[Notes])),
            (N'Posted', CONVERT(NVARCHAR(MAX), d.[Posted]), CONVERT(NVARCHAR(MAX), i.[Posted]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[ApJournalItem_Audit]
ON [dbo].[ApJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'ApJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'ApJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
       AND (SELECT COUNT(*) FROM inserted) + (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'JournalIdNo', CONVERT(NVARCHAR(MAX), d.[JournalIdNo]), CONVERT(NVARCHAR(MAX), i.[JournalIdNo])),
            (N'AccountIdNo', CONVERT(NVARCHAR(MAX), d.[AccountIdNo]), CONVERT(NVARCHAR(MAX), i.[AccountIdNo])),
            (N'Debit', CONVERT(NVARCHAR(MAX), d.[Debit]), CONVERT(NVARCHAR(MAX), i.[Debit])),
            (N'Credit', CONVERT(NVARCHAR(MAX), d.[Credit]), CONVERT(NVARCHAR(MAX), i.[Credit])),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]), CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo])),
            (N'PayIdNo', CONVERT(NVARCHAR(MAX), d.[PayIdNo]), CONVERT(NVARCHAR(MAX), i.[PayIdNo])),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]), CONVERT(NVARCHAR(MAX), i.[Notes])),
            (N'Posted', CONVERT(NVARCHAR(MAX), d.[Posted]), CONVERT(NVARCHAR(MAX), i.[Posted]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[ArJournalItem_Audit]
ON [dbo].[ArJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'ArJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'ArJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
       AND (SELECT COUNT(*) FROM inserted) + (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'JournalIdNo', CONVERT(NVARCHAR(MAX), d.[JournalIdNo]), CONVERT(NVARCHAR(MAX), i.[JournalIdNo])),
            (N'AccountIdNo', CONVERT(NVARCHAR(MAX), d.[AccountIdNo]), CONVERT(NVARCHAR(MAX), i.[AccountIdNo])),
            (N'Debit', CONVERT(NVARCHAR(MAX), d.[Debit]), CONVERT(NVARCHAR(MAX), i.[Debit])),
            (N'Credit', CONVERT(NVARCHAR(MAX), d.[Credit]), CONVERT(NVARCHAR(MAX), i.[Credit])),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]), CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo])),
            (N'PayIdNo', CONVERT(NVARCHAR(MAX), d.[PayIdNo]), CONVERT(NVARCHAR(MAX), i.[PayIdNo])),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]), CONVERT(NVARCHAR(MAX), i.[Notes])),
            (N'Posted', CONVERT(NVARCHAR(MAX), d.[Posted]), CONVERT(NVARCHAR(MAX), i.[Posted]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[CashReceiptJournalItem_Audit]
ON [dbo].[CashReceiptJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CashReceiptJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CashReceiptJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
       AND (SELECT COUNT(*) FROM inserted) + (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'JournalIdNo', CONVERT(NVARCHAR(MAX), d.[JournalIdNo]), CONVERT(NVARCHAR(MAX), i.[JournalIdNo])),
            (N'AccountIdNo', CONVERT(NVARCHAR(MAX), d.[AccountIdNo]), CONVERT(NVARCHAR(MAX), i.[AccountIdNo])),
            (N'Debit', CONVERT(NVARCHAR(MAX), d.[Debit]), CONVERT(NVARCHAR(MAX), i.[Debit])),
            (N'Credit', CONVERT(NVARCHAR(MAX), d.[Credit]), CONVERT(NVARCHAR(MAX), i.[Credit])),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]), CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo])),
            (N'PayIdNo', CONVERT(NVARCHAR(MAX), d.[PayIdNo]), CONVERT(NVARCHAR(MAX), i.[PayIdNo])),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]), CONVERT(NVARCHAR(MAX), i.[Notes])),
            (N'Posted', CONVERT(NVARCHAR(MAX), d.[Posted]), CONVERT(NVARCHAR(MAX), i.[Posted]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[CdJournalItem_Audit]
ON [dbo].[CdJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AuditEvents TABLE
    (
        [AuditEventId] BIGINT NOT NULL,
        [RecordIdNo] INT NOT NULL
    );

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    OUTPUT inserted.[AuditEventId], inserted.[RecordIdNo]
        INTO @AuditEvents ([AuditEventId], [RecordIdNo])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CdJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CdJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;

    INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
    SELECT ae.[AuditEventId], N'Record fields', s.[OldValue], s.[NewValue]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    INNER JOIN @AuditEvents AS ae ON ae.[RecordIdNo] = CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo]))
    CROSS APPLY (VALUES
        (CASE WHEN d.[IdNo] IS NULL THEN NULL ELSE
            N'{"IdNo":' + CONVERT(NVARCHAR(30), d.[IdNo]) +
            N',"Sequence":' + CONVERT(NVARCHAR(30), d.[Sequence]) +
            N',"JournalIdNo":' + CONVERT(NVARCHAR(30), d.[JournalIdNo]) +
            N',"AccountIdNo":' + CONVERT(NVARCHAR(30), d.[AccountIdNo]) +
            N',"Debit":' + CONVERT(NVARCHAR(50), d.[Debit]) +
            N',"Credit":' + CONVERT(NVARCHAR(50), d.[Credit]) +
            N',"RevCostCenterIdNo":' + CONVERT(NVARCHAR(30), d.[RevCostCenterIdNo]) +
            N',"PayIdNo":' + CASE WHEN d.[PayIdNo] IS NULL THEN N'null' ELSE CONVERT(NVARCHAR(30), d.[PayIdNo]) END +
            N',"Notes":' + CASE WHEN d.[Notes] IS NULL THEN N'null' ELSE N'"' +
                REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(d.[Notes], N'\', N'\\'), N'"', N'\"'), CHAR(13), N'\r'), CHAR(10), N'\n'), CHAR(9), N'\t') + N'"' END +
            N',"Posted":' + CASE WHEN d.[Posted] = 1 THEN N'true' ELSE N'false' END +
            N',"OldAccountIdNo":' + CASE WHEN d.[OldAccountIdNo] IS NULL THEN N'null' ELSE CONVERT(NVARCHAR(30), d.[OldAccountIdNo]) END +
            N',"DateTimeStamp":"' + CONVERT(NVARCHAR(100), CONVERT(VARBINARY(8000), d.[DateTimeStamp]), 1) + N'"}' END,
         CASE WHEN i.[IdNo] IS NULL THEN NULL ELSE
            N'{"IdNo":' + CONVERT(NVARCHAR(30), i.[IdNo]) +
            N',"Sequence":' + CONVERT(NVARCHAR(30), i.[Sequence]) +
            N',"JournalIdNo":' + CONVERT(NVARCHAR(30), i.[JournalIdNo]) +
            N',"AccountIdNo":' + CONVERT(NVARCHAR(30), i.[AccountIdNo]) +
            N',"Debit":' + CONVERT(NVARCHAR(50), i.[Debit]) +
            N',"Credit":' + CONVERT(NVARCHAR(50), i.[Credit]) +
            N',"RevCostCenterIdNo":' + CONVERT(NVARCHAR(30), i.[RevCostCenterIdNo]) +
            N',"PayIdNo":' + CASE WHEN i.[PayIdNo] IS NULL THEN N'null' ELSE CONVERT(NVARCHAR(30), i.[PayIdNo]) END +
            N',"Notes":' + CASE WHEN i.[Notes] IS NULL THEN N'null' ELSE N'"' +
                REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(i.[Notes], N'\', N'\\'), N'"', N'\"'), CHAR(13), N'\r'), CHAR(10), N'\n'), CHAR(9), N'\t') + N'"' END +
            N',"Posted":' + CASE WHEN i.[Posted] = 1 THEN N'true' ELSE N'false' END +
            N',"OldAccountIdNo":' + CASE WHEN i.[OldAccountIdNo] IS NULL THEN N'null' ELSE CONVERT(NVARCHAR(30), i.[OldAccountIdNo]) END +
            N',"DateTimeStamp":"' + CONVERT(NVARCHAR(100), CONVERT(VARBINARY(8000), i.[DateTimeStamp]), 1) + N'"}' END)) s([OldValue], [NewValue]);
END;
GO

CREATE TRIGGER [dbo].[PcJournalItem_Audit]
ON [dbo].[PcJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PcJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PcJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
       AND (SELECT COUNT(*) FROM inserted) + (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'JournalIdNo', CONVERT(NVARCHAR(MAX), d.[JournalIdNo]), CONVERT(NVARCHAR(MAX), i.[JournalIdNo])),
            (N'AccountIdNo', CONVERT(NVARCHAR(MAX), d.[AccountIdNo]), CONVERT(NVARCHAR(MAX), i.[AccountIdNo])),
            (N'Debit', CONVERT(NVARCHAR(MAX), d.[Debit]), CONVERT(NVARCHAR(MAX), i.[Debit])),
            (N'Credit', CONVERT(NVARCHAR(MAX), d.[Credit]), CONVERT(NVARCHAR(MAX), i.[Credit])),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]), CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo])),
            (N'PayIdNo', CONVERT(NVARCHAR(MAX), d.[PayIdNo]), CONVERT(NVARCHAR(MAX), i.[PayIdNo])),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]), CONVERT(NVARCHAR(MAX), i.[Notes])),
            (N'OldAccountIdNo', CONVERT(NVARCHAR(MAX), d.[OldAccountIdNo]), CONVERT(NVARCHAR(MAX), i.[OldAccountIdNo])),
            (N'Posted', CONVERT(NVARCHAR(MAX), d.[Posted]), CONVERT(NVARCHAR(MAX), i.[Posted]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[SalesJournalItem_Audit]
ON [dbo].[SalesJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'SalesJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'SalesJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
       AND (SELECT COUNT(*) FROM inserted) + (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'JournalIdNo', CONVERT(NVARCHAR(MAX), d.[JournalIdNo]), CONVERT(NVARCHAR(MAX), i.[JournalIdNo])),
            (N'AccountIdNo', CONVERT(NVARCHAR(MAX), d.[AccountIdNo]), CONVERT(NVARCHAR(MAX), i.[AccountIdNo])),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]), CONVERT(NVARCHAR(MAX), i.[Notes])),
            (N'Debit', CONVERT(NVARCHAR(MAX), d.[Debit]), CONVERT(NVARCHAR(MAX), i.[Debit])),
            (N'Credit', CONVERT(NVARCHAR(MAX), d.[Credit]), CONVERT(NVARCHAR(MAX), i.[Credit])),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]), CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo])),
            (N'PayIdNo', CONVERT(NVARCHAR(MAX), d.[PayIdNo]), CONVERT(NVARCHAR(MAX), i.[PayIdNo])),
            (N'Posted', CONVERT(NVARCHAR(MAX), d.[Posted]), CONVERT(NVARCHAR(MAX), i.[Posted]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[ErJournalItem_Audit]
ON [dbo].[ErJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'ErJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'ErJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
    IF (SELECT COUNT(*) FROM inserted) <= 1 AND (SELECT COUNT(*) FROM deleted) <= 1
       AND (SELECT COUNT(*) FROM inserted) + (SELECT COUNT(*) FROM deleted) > 0
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'JournalIdNo', CONVERT(NVARCHAR(MAX), d.[JournalIdNo]), CONVERT(NVARCHAR(MAX), i.[JournalIdNo])),
            (N'AccountIdNo', CONVERT(NVARCHAR(MAX), d.[AccountIdNo]), CONVERT(NVARCHAR(MAX), i.[AccountIdNo])),
            (N'Debit', CONVERT(NVARCHAR(MAX), d.[Debit]), CONVERT(NVARCHAR(MAX), i.[Debit])),
            (N'Credit', CONVERT(NVARCHAR(MAX), d.[Credit]), CONVERT(NVARCHAR(MAX), i.[Credit])),
            (N'RevCostCenterIdNo', CONVERT(NVARCHAR(MAX), d.[RevCostCenterIdNo]), CONVERT(NVARCHAR(MAX), i.[RevCostCenterIdNo])),
            (N'PayIdNo', CONVERT(NVARCHAR(MAX), d.[PayIdNo]), CONVERT(NVARCHAR(MAX), i.[PayIdNo])),
            (N'Notes', CONVERT(NVARCHAR(MAX), d.[Notes]), CONVERT(NVARCHAR(MAX), i.[Notes])),
            (N'Posted', CONVERT(NVARCHAR(MAX), d.[Posted]), CONVERT(NVARCHAR(MAX), i.[Posted]))) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') COLLATE DATABASE_DEFAULT <> ISNULL(v.[NewValue], N'') COLLATE DATABASE_DEFAULT;
    END;
END;
GO

CREATE TRIGGER [dbo].[CkJournalItem_Audit]
ON [dbo].[CkJournalItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CkJournalItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CkJournalItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[ApOpenInvoice_Audit]
ON [dbo].[ApOpenInvoice]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'ApOpenInvoice', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'ApOpenInvoice record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[ArOpenInvoice_Audit]
ON [dbo].[ArOpenInvoice]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'ArOpenInvoice', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'ArOpenInvoice record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[ErOpenInvoice_Audit]
ON [dbo].[ErOpenInvoice]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'ErOpenInvoice', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'ErOpenInvoice record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[CdOiItem_Audit]
ON [dbo].[CdOiItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CdOiItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CdOiItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[CkOiItem_Audit]
ON [dbo].[CkOiItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CkOiItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CkOiItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PcOiItem_Audit]
ON [dbo].[PcOiItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PcOiItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PcOiItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[CsrOiItem_Audit]
ON [dbo].[CsrOiItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CsrOiItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CsrOiItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Purchase_Audit]
ON [dbo].[Purchase]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Purchase', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Purchase record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PurchaseDetail_Audit]
ON [dbo].[PurchaseDetail]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PurchaseDetail', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PurchaseDetail record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PurchaseOrder_Audit]
ON [dbo].[PurchaseOrder]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PurchaseOrder', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PurchaseOrder record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PurchaseOrderDetail_Audit]
ON [dbo].[PurchaseOrderDetail]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PurchaseOrderDetail', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PurchaseOrderDetail record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[PurchaseOrderSupplied_Audit]
ON [dbo].[PurchaseOrderSupplied]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'PurchaseOrderSupplied', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'PurchaseOrderSupplied record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Sale_Audit]
ON [dbo].[Sale]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Sale', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Sale record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[SaleDetail_Audit]
ON [dbo].[SaleDetail]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'SaleDetail', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'SaleDetail record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[SalesDeposit_Audit]
ON [dbo].[SalesDeposit]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'SalesDeposit', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'SalesDeposit record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[InvTransaction_Audit]
ON [dbo].[InvTransaction]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'InvTransaction', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'InvTransaction record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[InvTransactionDetail_Audit]
ON [dbo].[InvTransactionDetail]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'InvTransactionDetail', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'InvTransactionDetail record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[AccountReconciliation_Audit]
ON [dbo].[AccountReconciliation]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'AccountReconciliation', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'AccountReconciliation record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[AccountReconciliationItem_Audit]
ON [dbo].[AccountReconciliationItem]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'AccountReconciliationItem', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'AccountReconciliationItem record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Reconciliation_Audit]
ON [dbo].[Reconciliation]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Reconciliation', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Reconciliation record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Reconciled_Audit]
ON [dbo].[Reconciled]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Reconciled', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Reconciled record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[LastPosting_Audit]
ON [dbo].[LastPosting]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'LastPosting', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'LastPosting record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[AccountTypes_Audit]
ON [dbo].[AccountTypes]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'AccountTypes', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'AccountTypes record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[DefaultAccounts_Audit]
ON [dbo].[DefaultAccounts]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'DefaultAccounts', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'DefaultAccounts record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[JournalPrefix_Audit]
ON [dbo].[JournalPrefix]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'JournalPrefix', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'JournalPrefix record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[TransactionPrefix_Audit]
ON [dbo].[TransactionPrefix]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'TransactionPrefix', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'TransactionPrefix record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[NumberSeries_Audit]
ON [dbo].[NumberSeries]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'NumberSeries', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'NumberSeries record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Series_Audit]
ON [dbo].[Series]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    -- Series is system-maintained numbering metadata and is intentionally not audited.
    RETURN;
END;
GO

CREATE TRIGGER [dbo].[Bank_Audit]
ON [dbo].[Bank]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Bank', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Bank record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[BankAccount_Audit]
ON [dbo].[BankAccount]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'BankAccount', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'BankAccount record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[BankCharge_Audit]
ON [dbo].[BankCharge]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'BankCharge', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'BankCharge record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[CashCode_Audit]
ON [dbo].[CashCode]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CashCode', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CashCode record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[CashFlowAccountRule_Audit]
ON [dbo].[CashFlowAccountRule]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CashFlowAccountRule', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CashFlowAccountRule record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[CashFlowAllocation_Audit]
ON [dbo].[CashFlowAllocation]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CashFlowAllocation', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CashFlowAllocation record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[CostCenter_Audit]
ON [dbo].[CostCenter]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'CostCenter', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'CostCenter record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[RevCostCenter_Audit]
ON [dbo].[RevCostCenter]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'RevCostCenter', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'RevCostCenter record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[ProfitCenter_Audit]
ON [dbo].[ProfitCenter]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'ProfitCenter', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'ProfitCenter record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[RevenueGroup_Audit]
ON [dbo].[RevenueGroup]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'RevenueGroup', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'RevenueGroup record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Department_Audit]
ON [dbo].[Department]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Department', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Department record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO

CREATE TRIGGER [dbo].[Branch_Audit]
ON [dbo].[Branch]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'Branch', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'Branch record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac;
END;
GO
