CREATE TYPE [dbo].[EmployeeDocumentUpdate] AS TABLE (
    [DataImageIdNo]  INT          NULL,
    [DocumentIdNo]   SMALLINT     NULL,
    [DocumentNumber] VARCHAR (30) NULL,
    [EmployeeIdNo]   INT          NULL,
    [ExpiryDate]     DATE         NULL,
    [IDNo]           INT          NOT NULL,
    [IssueDate]      DATE         NULL,
    [Sequence]       TINYINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC));

