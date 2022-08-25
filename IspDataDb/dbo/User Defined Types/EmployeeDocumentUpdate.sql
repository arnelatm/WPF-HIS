CREATE TYPE [dbo].[EmployeeDocumentUpdate] AS TABLE (
    [IDNo]           INT             NOT NULL,
    [EmployeeIdNo]   INT             NULL,
    [DocumentIdNo]   SMALLINT        NULL,
    [DocumentNumber] VARCHAR (30)    NULL,
    [IssueDate]      DATE            NULL,
    [ExpiryDate]     DATE            NULL,
    [Image]          VARBINARY (MAX) NULL,
    [Sequence]       TINYINT         NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

