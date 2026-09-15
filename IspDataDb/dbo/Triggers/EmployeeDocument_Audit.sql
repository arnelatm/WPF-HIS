CREATE TRIGGER [dbo].[EmployeeDocument_Audit]
ON [dbo].[EmployeeDocument]
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[AuditEvent]
    ([UserIdNo], [UserNameSnapshot], [Action], [EntityName], [RecordIdNo], [BranchIdNo], [Description], [ApplicationName], [MachineName])
    SELECT ac.[UserIdNo], ac.[UserNameSnapshot],
        CASE WHEN i.[IdNo] IS NULL THEN 'Delete' WHEN d.[IdNo] IS NULL THEN 'Insert' ELSE 'Update' END,
        'EmployeeDocument', CONVERT(INT, COALESCE(i.[IdNo], d.[IdNo])), ac.[BranchIdNo],
        'EmployeeDocument record changed', ac.[ApplicationName], ac.[MachineName]
    FROM inserted AS i
    FULL OUTER JOIN deleted AS d ON d.[IdNo] = i.[IdNo]
    CROSS JOIN [dbo].[GetAuditSessionContext]() AS ac
    WHERE i.[IdNo] IS NULL OR d.[IdNo] IS NULL
       OR ISNULL(i.[EmployeeIdNo], 0) <> ISNULL(d.[EmployeeIdNo], 0)
       OR ISNULL(i.[Sequence], 0) <> ISNULL(d.[Sequence], 0)
       OR ISNULL(i.[DocumentIdNo], 0) <> ISNULL(d.[DocumentIdNo], 0)
       OR ISNULL(i.[DataImageIdNo], 0) <> ISNULL(d.[DataImageIdNo], 0)
       OR ISNULL(i.[DocumentNumber], '') <> ISNULL(d.[DocumentNumber], '')
       OR ISNULL(i.[IssueDate], '19000101') <> ISNULL(d.[IssueDate], '19000101')
       OR ISNULL(i.[ExpiryDate], '19000101') <> ISNULL(d.[ExpiryDate], '19000101');
END;
GO
