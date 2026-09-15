CREATE TRIGGER [dbo].[EmployeePayElement_Audit]
ON [dbo].[EmployeePayElement]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'EmployeePayElement', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'EmployeePayElement record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac
    WHERE i.[IdNo] IS NULL OR d.[IdNo] IS NULL
       OR ISNULL(i.[EmployeeIdNo], 0) <> ISNULL(d.[EmployeeIdNo], 0)
       OR ISNULL(i.[PayElementIdNo], 0) <> ISNULL(d.[PayElementIdNo], 0)
       OR ISNULL(i.[Amount], 0) <> ISNULL(d.[Amount], 0)
       OR ISNULL(i.[Rate], 0) <> ISNULL(d.[Rate], 0)
       OR ISNULL(i.[Sequence], 0) <> ISNULL(d.[Sequence], 0)
       OR ISNULL(i.[Unit], '') <> ISNULL(d.[Unit], '');

    IF (SELECT COUNT(*) FROM inserted) = 1 AND (SELECT COUNT(*) FROM deleted) = 1
       AND EXISTS
       (
           SELECT 1
           FROM inserted AS i
           INNER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
           WHERE ISNULL(i.[EmployeeIdNo], 0) <> ISNULL(d.[EmployeeIdNo], 0)
              OR ISNULL(i.[PayElementIdNo], 0) <> ISNULL(d.[PayElementIdNo], 0)
              OR ISNULL(i.[Amount], 0) <> ISNULL(d.[Amount], 0)
              OR ISNULL(i.[Rate], 0) <> ISNULL(d.[Rate], 0)
              OR ISNULL(i.[Sequence], 0) <> ISNULL(d.[Sequence], 0)
              OR ISNULL(i.[Unit], '') <> ISNULL(d.[Unit], '')
       )
    BEGIN
        DECLARE @AuditEventId BIGINT = CONVERT(BIGINT, SCOPE_IDENTITY());
        INSERT INTO [dbo].[AuditFieldChange] ([AuditEventId], [FieldName], [OldValue], [NewValue])
        SELECT @AuditEventId, v.[FieldName], v.[OldValue], v.[NewValue]
        FROM inserted AS i
        INNER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
        CROSS APPLY (VALUES
            (N'EmployeeIdNo', CONVERT(NVARCHAR(MAX), d.[EmployeeIdNo]), CONVERT(NVARCHAR(MAX), i.[EmployeeIdNo])),
            (N'PayElementIdNo', CONVERT(NVARCHAR(MAX), d.[PayElementIdNo]), CONVERT(NVARCHAR(MAX), i.[PayElementIdNo])),
            (N'Amount', CONVERT(NVARCHAR(MAX), d.[Amount]), CONVERT(NVARCHAR(MAX), i.[Amount])),
            (N'Rate', CONVERT(NVARCHAR(MAX), d.[Rate]), CONVERT(NVARCHAR(MAX), i.[Rate])),
            (N'Sequence', CONVERT(NVARCHAR(MAX), d.[Sequence]), CONVERT(NVARCHAR(MAX), i.[Sequence])),
            (N'Unit', CONVERT(NVARCHAR(MAX), d.[Unit]) COLLATE DATABASE_DEFAULT, CONVERT(NVARCHAR(MAX), i.[Unit]) COLLATE DATABASE_DEFAULT)) v([FieldName], [OldValue], [NewValue])
        WHERE ISNULL(v.[OldValue], N'') <> ISNULL(v.[NewValue], N'');
    END;
END;
GO
