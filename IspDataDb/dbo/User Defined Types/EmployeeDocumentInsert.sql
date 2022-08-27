CREATE TYPE [dbo].[EmployeeDocumentInsert] AS TABLE (
    [DocumentIdNo]   SMALLINT        NULL,
    [DocumentImage]  INT             NULL,
    [DocumentNumber] VARCHAR (30)    NULL,
    [EmployeeIdNo]   INT             NULL,
    [ExpiryDate]     DATE            NULL,
    [IssueDate]      DATE            NULL,
    [Sequence]       TINYINT         NOT NULL);





