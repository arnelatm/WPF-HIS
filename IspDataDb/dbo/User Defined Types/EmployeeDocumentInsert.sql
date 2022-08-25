CREATE TYPE [dbo].[EmployeeDocumentInsert] AS TABLE (
    [EmployeeIdNo]   INT             NULL,
    [DocumentIdNo]   SMALLINT        NULL,
    [DocumentNumber] VARCHAR (30)    NULL,
    [IssueDate]      DATE            NULL,
    [ExpiryDate]     DATE            NULL,
    [Image]          VARBINARY (MAX) NULL,
    [Sequence]       TINYINT         NOT NULL);

