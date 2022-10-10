CREATE TYPE [dbo].[EmployeeDocumentInsert] AS TABLE (
    [DataImageIdNo]  INT          NULL,
    [DocumentIdNo]   SMALLINT     NULL,
    [DocumentNumber] VARCHAR (30) NULL,
    [EmployeeIdNo]   INT          NULL,
    [ExpiryDate]     DATE         NULL,
    [IssueDate]      DATE         NULL,
    [Sequence]       TINYINT      NOT NULL);

